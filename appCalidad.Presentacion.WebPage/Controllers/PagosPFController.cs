using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using appCalidad.Infraestructura.Datos;
using appCalidad.Infraestructura.Datos.Repository;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using Newtonsoft.Json;

namespace appCalidad.Presentacion.WebPage.Controllers
{

    public class PagosPFController : Controller
    {

        //private DDocPagoHandlers Docpago;
        private Export _export;
        public PagosPFController()
        {
            //Docpago = new DDocPagoHandlers();
            _export = new Export();
        }


        [HttpGet]
        public ActionResult recusupagpf1(string llave, string codAut,string indxv)
        {
            llave = llave.Trim().ToLower();
            codAut = codAut.Trim().ToLower();
       

            if (llave.Length > 0 && codAut.Length > 0)
            {
                try
                {
                    var url = $"" + ConfigurationManager.AppSettings["API_SERVIDOR"] + "/api/Usuarios/ValidarEnlaceDeIngreso";

                     AccessRequest parametros = new AccessRequest() { USUARIO = llave, CODIGOAUT = codAut};
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        string json = JsonConvert.SerializeObject(parametros);
                        streamWriter.Write(json);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }

                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) return View();
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                var Usuario = JsonConvert.DeserializeObject<AccessResponses>(responseBody);
                                if (Usuario.MSG == "OK")
                                {

                                    Session["Usuario"] = Usuario.USUARIO;
                                    Session["Nombres"] = Usuario.NOMBRES;
                                    Session["Apellidos"] = Usuario.APELLIDO_PATERNO + " " + Usuario.APELLIDO_MATERNO;


                                    //Session["Token"] = Usuario.access_token;
                                    FormsAuthentication.SetAuthCookie(Usuario.USUARIO.ToString(), false);
                                    return RedirectToAction("MiCuenta", "PagosPF");
                                }
                                else
                                {
                                    //TempData["Message"] = Usuario.MSG;
                                    return RedirectToAction("Error", "PagosPF",new { codigo =codAut , llave = llave, msg  = Usuario.MSG });
                                }

                            }
                        }
                    }
                }
                catch (WebException e)
                {
                    return RedirectToAction("Error", "PagosPF", new { codigo = codAut, llave = llave, msg = "Respuesta de sistema: Ocurrio un error " + e.Message });
                }
            }
            else
            {
                return RedirectToAction("Error", "PagosPF", new { codigo = codAut, llave = llave, msg = "Respuesta de sistema: el enlace no tiene el formato correcto." });
            }
            
        }


        // GET: Bienvenida
        [HttpGet]
        public ActionResult Bienvenida()
        {

            ViewBag.opcionSel = "inicio";

            string usuarioIdentity = User.Identity.Name;

            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }


            return View();
        }

        // GET: Bienvenida
        [HttpGet]
        public ActionResult Error(string codigo,string llave, string msg)
        {
            ViewBag.codigo =codigo ;
            ViewBag.llave =llave;
            ViewBag.msg = msg;
            //ViewBag.Message = TempData["Message"];
            return View();
        }


        public ActionResult MiCuenta()
        {
            ViewBag.opcionSel = "cuenta";
            string usuarioIdentity = User.Identity.Name;

            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }


            return View();
        }

        public ActionResult ConsultarDocumentos()
        {
            return View();
        }

        public ActionResult Pagar()
        {
            string usuarioIdentity = User.Identity.Name;

            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }

            ViewBag.opcionSel = "pagar";
            return View();
        }

        public ActionResult ReporteExcel(string estado = "", string fecini = "", string fecfin = "", string nroserie = "", string nrofactura = "", string responsable = "")
        {
            DateTime fecha;

            if (!DateTime.TryParse(fecini, out fecha))
            {
                fecini = "";
            }

            if (!DateTime.TryParse(fecfin, out fecha))
            {
                fecfin = "";
            }
            DocPagoRequest docpago = new DocPagoRequest()
            {
                TIPO = "",
                FLG_EST_DOC = estado,
                FEC_INI = fecini,
                FEC_FIN = fecfin,
                SNROFAC = nroserie,
                DNROFAC = nrofactura,
                DRESP_CAB = responsable
            };
            var resultado = new List<DocPagoResponses>();
            _export.ToExcel(Response, resultado, "prueba_excel");

            return View();
        }


    }
}