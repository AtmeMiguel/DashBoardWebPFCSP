using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using System.IO;
using System.Net.Mail;
using System.ComponentModel;
using System.Configuration;
using System.Collections;
using com.sun.net.httpserver;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;

/// <summary>
/// Descripción breve de CorreoElectronico
/// </summary>
public class CorreoElectronico
{
    public CorreoElectronico()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public CorreoElectronico(Boolean flEnvioAsync)
    {
        fl_envio_async = flEnvioAsync;
    }

    private Boolean _fl_envio_async = true;
    public Boolean fl_envio_async
    {
        get { return _fl_envio_async; }
        set { _fl_envio_async = value; }
    }

    private string _no_error;
    public string no_error
    {
        get { return _no_error; }
        set { _no_error = value; }
    }
    static bool mailSent = false;
    private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
    {
        MailMessage mail = (MailMessage)e.UserState;
        string no_asunto = mail.Subject;
        if (e.Error != null)
        {
            //Console.WriteLine("Error {1} ocurrido mientras se enviaba el correo [{0}] ", no_asunto, e.Error.ToString());
            mailSent = false;
        }
        else if (e.Cancelled)
        {
            mailSent = false;
            //Console.WriteLine("Envio cancelado de correo con asunto [{0}].", no_asunto);
        }
        else
        {
            //Console.WriteLine("Mensaje [{1}] enviado.", no_asunto);
            mailSent = true;
        }
    }

    public string EnviarMensajeCorreo(String Asunto, ArrayList Para, ArrayList Copia, ArrayList CopiaOculta, String Body, ArrayList rutaAdjuntos)
    {
        var msgCorreo = "OK";
        System.Collections.Specialized.NameValueCollection nvc = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("groupSanPablo/sectionEmail");
        
        Int32 intResp = 0;
        StringBuilder strHTML = new StringBuilder();
        strHTML.Append(Body);

        //Validando retorno del HTML
        if (strHTML.ToString().Equals("-1") || strHTML.ToString().Equals("-2"))
        {
            //-1 Error al cargar la Plantilla
            //-2 Error al rrellenar Plantilla
            intResp = Int32.Parse(strHTML.ToString());
            msgCorreo = "Error en Plantilla" + intResp.ToString();
            return msgCorreo;
        }
        else
        {
            MailMessage oEmail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
           
                 oEmail.From = new MailAddress(nvc["MailAddress"], nvc["DisplayName"]);
                // oEmail.From = new MailAddress("atmemiguel@gmail.com", "miguel");

                //Agrega destinatario "To"
                foreach (string to in Para) { oEmail.To.Add(to); }
                //Agrega destinatario "CC"
                foreach (string cc in Copia) { oEmail.CC.Add(cc); }
                //Agrega destinatario "Bcc"
                foreach (string bcc in CopiaOculta) { oEmail.Bcc.Add(bcc); }
                //Agrega adjuntos
                foreach (string path_Archivo in rutaAdjuntos) { oEmail.Attachments.Add(new Attachment(path_Archivo)); }

                oEmail.Subject = Asunto;
                oEmail.Body = strHTML.ToString();
                //oEmail.BodyEncoding = System.Text.Encoding.UTF8; //mflower UTF8
                oEmail.IsBodyHtml = true;
                oEmail.Priority = System.Net.Mail.MailPriority.High;
                smtp.Host = nvc[0].ToString();
                smtp.Port = Int32.Parse(nvc[1].ToString());
                smtp.Credentials = new System.Net.NetworkCredential(nvc[2].ToString(), nvc[3].ToString());

                if (fl_envio_async)
                {
                    smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                    object userState = oEmail;
                    try
                    {
                        smtp.SendAsync(oEmail, userState);
                    }
                    catch (Exception ex)
                    {
                     
                        msgCorreo = string.Format("{0}|{1}", ex.Message, (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                        //System.Web.HttpContext.Current.Response.Write("1 > " + ex.Message);
                    }
                    finally
                    { }
                }
                else
                {
                    smtp.Send(oEmail);
                }
            }
            catch (Exception ex)
            {
             

                msgCorreo = string.Format("{0}|{1}", ex.Message, (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
               // System.Web.HttpContext.Current.Response.Write("1 > " + ex.Message);
            }
            finally
            {
                oEmail = null;
                smtp = null;
            }
        }
        return msgCorreo;
    }



    //####  AUTORIZACION DE WEB PAGOS ######
    public string EnviarCorreoAutorizacion(AutorizacionPFResponse autObj,string tipo_aut)
    {
        var msgCorreo = "";
        try
        {
            System.Collections.Specialized.NameValueCollection nvc = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("groupSanPablo/sectionEmail");
            CorreoElectronico oEmail = new CorreoElectronico(false);
            ArrayList Para = new ArrayList();
            ArrayList Copia = new ArrayList();
            ArrayList CopiaOculta = new ArrayList();
            String Body = "";
            String Asunto = "";
            ArrayList rutaAdjuntos = new ArrayList();

            if (nvc["EnviaCorreo"] != "SI")
            {
                msgCorreo = "Flag de envio esta deshabilitado";
                return msgCorreo;
            }

            //*se agrega destinatarios 
            string split = "";
            split = autObj.DESTINATARIO;
            if (split == "")
            {
                msgCorreo = "No hay correo destinatario";
                return msgCorreo;
            }
            List<string> lstmail = new List<string>();
            lstmail = split.Split(',').ToList();


            foreach (var item in lstmail)
            {
                Para.Add(item);
            }



            //*se agrega copia oculta
            var copiaOculta = nvc["AdminMail"].ToString();
            CopiaOculta.Add(copiaOculta);

            //*se agrega copia
            //Copia.Add("");
            if (tipo_aut == "recuperar_cuenta")
            {
                var ruta = System.Web.HttpContext.Current.Request.MapPath(@"~/Recursos/plantillas/");
                ruta = ruta + "correoRecuperarCuenta.html";
                //Body = getPlantilla_CorreoAprobacionDocPagoHTML(docpago);
                Body = getPlantilla_RecuperarCuentaPagosHTML(autObj, ruta);
                Asunto = "Recuperemos tu cuenta - usuario: " + autObj.LLAVE_ORIGEN + " - " + autObj.NOMBRES;
            }
            else if (tipo_aut == "registrar_cuenta")
            {
                //docpago.RUTA = docpago.RUTA + "correoRechazarDocPago.html";
                //Body = getPlantilla_CorreoRechazoDocPagoHTML(docpago);
                //Asunto = "Factura Rechazada " + docpago.SNROFAC + '-' + docpago.DNROFAC;
            }

            msgCorreo = oEmail.EnviarMensajeCorreo(Asunto, Para, Copia, CopiaOculta, Body, rutaAdjuntos);

        }
        catch (Exception ex)
        {
            msgCorreo = ex.Message;
        }

        return msgCorreo;

    }


    //####  CONTROL DE NOTA DE CREDITO ######
    public string EnviarCorreoAprobacionRechazo(DocPagoRequest docpago)
    {
        var msgCorreo = "";
        try
        {
            System.Collections.Specialized.NameValueCollection nvc = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("groupSanPablo/sectionEmail");
            CorreoElectronico oEmail = new CorreoElectronico(false);
            ArrayList Para = new ArrayList();
            ArrayList Copia = new ArrayList();
            ArrayList CopiaOculta = new ArrayList();
            String Body = "";
            String Asunto = "";
            ArrayList rutaAdjuntos = new ArrayList();

            if (nvc["EnviaCorreo"] != "SI")
            {
                msgCorreo = "Flag de envio esta deshabilitado";
                return msgCorreo;
            }

            //*se agrega destinatarios 
            string split = "";
            split = docpago.MAIL;
            if (split == "")
            {
                msgCorreo = "No hay correo destinatario";
                return msgCorreo;
            }
            List<string> lstmail = new List<string>();
            lstmail = split.Split(',').ToList();


            foreach (var item in lstmail)
            {
                Para.Add(item);
            }



            //*se agrega copia oculta
            var copiaOculta = nvc["AdminMail"].ToString();
            CopiaOculta.Add(copiaOculta);

            //*se agrega copia
            //Copia.Add("");

            if (docpago.FLG_EST_DOC == "A")
            {
                docpago.RUTA = docpago.RUTA + "correoAprobarDocPago.html";
                Body = getPlantilla_CorreoAprobacionDocPagoHTML(docpago);
                Asunto = "Factura Aprobada " + docpago.SNROFAC + '-' + docpago.DNROFAC;
            }
            else if (docpago.FLG_EST_DOC == "R")
            {
                docpago.RUTA = docpago.RUTA + "correoRechazarDocPago.html";
                Body = getPlantilla_CorreoRechazoDocPagoHTML(docpago);
                Asunto = "Factura Rechazada " + docpago.SNROFAC + '-' + docpago.DNROFAC;
            }

            msgCorreo = oEmail.EnviarMensajeCorreo(Asunto, Para, Copia, CopiaOculta, Body, rutaAdjuntos);

        }
        catch (Exception ex)
        {
            msgCorreo=ex.Message;
        }

        return msgCorreo;

    }


    public String getPlantilla_RecuperarCuentaPagosHTML(AutorizacionPFResponse obj,string ruta)
    {

        StringBuilder strBodyHTML = new StringBuilder();


        string strRutaPlantilla = ruta;
        try
        {

            //  string[] ArregloSRC = ObtenerEnlacesImg("R", COD_EMPRESA, FLG_TELECONSULTA);
            if (!File.Exists(strRutaPlantilla))
                strBodyHTML.Append("-1");
            else
            {

                FileStream stream = new FileStream(strRutaPlantilla, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                string linea = null;
                while (reader.Peek() > -1)
                {
                    linea = reader.ReadLine().ToString();
                    linea = linea.Replace("[__LLAVE__]", obj.LLAVE_ORIGEN);
                    linea = linea.Replace("[__CODAUT__]", obj.CODIGO_AUT);

                    strBodyHTML.Append(linea);
                }
                reader.Close();
            }
        }
        catch
        {
            strBodyHTML = new StringBuilder();
            strBodyHTML.Append("-2");
        }
        return strBodyHTML.ToString();

    }



    public String getPlantilla_CorreoAprobacionDocPagoHTML(DocPagoRequest docpago)
    {

        StringBuilder strBodyHTML = new StringBuilder();


        string strRutaPlantilla = docpago.RUTA;
        try
        {

            //  string[] ArregloSRC = ObtenerEnlacesImg("R", COD_EMPRESA, FLG_TELECONSULTA);
            if (!File.Exists(strRutaPlantilla))
                strBodyHTML.Append("-1");
            else
            {

                FileStream stream = new FileStream(strRutaPlantilla, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                string linea = null;
                while (reader.Peek() > -1)
                {
                    linea = reader.ReadLine().ToString();
                    linea = linea.Replace("[__DESCRIPCION__]", docpago.SNROFAC +'-'+ docpago.DNROFAC );
                    linea = linea.Replace("[__COD_OBS__]", docpago.COD_OBS);

                    strBodyHTML.Append(linea);
                }
                reader.Close();
            }
        }
        catch
        {
            strBodyHTML = new StringBuilder();
            strBodyHTML.Append("-2");
        }
        return strBodyHTML.ToString();

    }


    public String getPlantilla_CorreoRechazoDocPagoHTML(DocPagoRequest docpago)
    {

        StringBuilder strBodyHTML = new StringBuilder();


        string strRutaPlantilla = docpago.RUTA;
        try
        {

            //  string[] ArregloSRC = ObtenerEnlacesImg("R", COD_EMPRESA, FLG_TELECONSULTA);
            if (!File.Exists(strRutaPlantilla))
                strBodyHTML.Append("-1");
            else
            {

                FileStream stream = new FileStream(strRutaPlantilla, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                string linea = null;
                while (reader.Peek() > -1)
                {
                    linea = reader.ReadLine().ToString();
                    linea = linea.Replace("[__DESCRIPCION__]", docpago.SNROFAC + '-' + docpago.DNROFAC);
                    linea = linea.Replace("[__COD_OBS__]", docpago.COD_OBS);

                    strBodyHTML.Append(linea);
                }
                reader.Close();
            }
        }
        catch
        {
            strBodyHTML = new StringBuilder();
            strBodyHTML.Append("-2");
        }
        return strBodyHTML.ToString();

    }


    //####  FIN ######
 
}