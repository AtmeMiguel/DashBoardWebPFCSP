using appCalidad.Infraestructura.Datos;
using appCalidad.Infraestructura.Datos.Encryptar;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static appCalidad.Presentacion.WebPage.Controllers.SeguridadController;
using System.Web.Security;
using Rotativa;
using System.Data;
using appCalidad.Dominio.Entidades;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace appCalidad.Presentacion.WebPage.Controllers
{
    public class CartaGarantiaController : Controller
    {
        // GET: PlanFamiliar
        public ActionResult Index(string idSource)
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" )
            {
                return RedirectToAction("Login", "Seguridad");
            }
            Session["apiServidor"] = ConfigurationManager.AppSettings["API_SERVIDOR"];
            int idSource2 = Convert.ToInt32(idSource);
            CartaGarantiaResponses r = new CartaGarantiaResponses();

            CartaGarantia c = new CartaGarantia() { ID = idSource2, ID_USUARIO = 22, USUARIO = "" };
            var url = $"" + Session["apiServidor"] + "/api/CartaGarantia/ListarCartaPDF";
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Headers.Add("Authorization", "Bearer " + Session["Token"]);
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(c);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return View();
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            r = JsonConvert.DeserializeObject<CartaGarantiaResponses>(responseBody);
                            r.LIM_CARTA_APROBADA = decimal.Parse(r.LIM_CARTA_APROBADA).ToString("N2");
                            r.FECHA = DateTime.Now.ToString("dddd dd MMMM yyyy");  // , CultureInfo.CreateSpecificCulture("es-PE")
                            r.SEDE = r.SEDE.Replace("TOMOMEDIC", "");
                            //return View(r);
                        }
                    }
                }

                CartaGarantia c2 = new CartaGarantia() { ID = idSource2, ID_USUARIO = 22, USUARIO = "" };
                var url2 = $"" + Session["apiServidor"] + "/api/CartaGarantia/ListarCoberturasAgregadas";
                var request2 = (HttpWebRequest)WebRequest.Create(url2);

                request2.Method = "POST";
                request2.ContentType = "application/json";
                request2.Accept = "application/json";
                request2.Headers.Add("Authorization", "Bearer " + Session["Token"]);
                using (var streamWriter = new StreamWriter(request2.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(c2);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                url = $"" + Session["apiServidor"] + "/api/CartaGarantia/ListarCoberturasAgregadas";
                using (WebResponse response2 = request2.GetResponse())
                {
                    using (Stream strReader = response2.GetResponseStream())
                    {
                        if (strReader == null) return View();
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            r.COBERTURAS = JsonConvert.DeserializeObject<List<coberturaAprobada>>(responseBody);
                        }
                    }
                }
            }
            catch (WebException e)
            {
                ViewBag.Listado = e.Message;
            }
            return View(r);
        }

        public ActionResult EditarCarta()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        public ActionResult Administrador()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "")
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        // GET: PlanFamiliar
        public ActionResult Editar()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        // GET: PlanFamiliar
        public ActionResult Verificar()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        public ActionResult Aprobador()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        public ActionResult Autorizador()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        public ActionResult Reportes()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        public ActionResult ReportesxFecRegistro()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        // GET: PlanFamiliar
        public ActionResult BuscarCarta()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        // GET: PlanFamiliar
        public ActionResult BuscarPaciente()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        public ActionResult Print(string idSource, string idUsuario, string numCarta)
        {
            string customSwitches = "--footer-html " + Server.MapPath("~/Views/Shared/Footer.html");
            //Session["id"] = idSource;
            return new ActionAsPdf("Index", new { idSource = idSource }) 
            { 
                FileName = numCarta + " _" + ".pdf" ,
                CustomSwitches = customSwitches
            };
        }
        //../CartaGarantia/
        public ActionResult ImagenCarta(string idSource, string idUsuario)
        {
            Session["ID_SOURCE"] = idSource;
            Session["ID_USUARIO"] = idUsuario;
            ViewBag.Message = "Iniciando proceso de carga:";
            return View();
        }

        [HttpPost]
        public ActionResult ImagenCarta(HttpPostedFileBase file)
        {
            try
            {
                //Int32 idFile = 0; 
                var idSource = Session["ID_SOURCE"] as string;
                ViewBag.Message = "";
                if (file != null && file.ContentLength > 0) //(1 * 1024))
                {
                    string ruta = DateTime.Now.ToString("yyyyMM");
                    string strFolder = Server.MapPath("~/Recursos/Archivos/" + ruta);
                    //string strFolder = Server.MapPath(@"E:\\FILE_PF\\" + ruta);

                    //string uploadDir = @"E:\Uploads2";
                    //if (!Directory.Exists(uploadDir))
                    //{
                    //    Directory.CreateDirectory(uploadDir);
                    //}

                    //// Generar el nombre del archivo y la ruta completa
                    //var filePath = Path.Combine(uploadDir, Path.GetFileName(file.FileName));

                    //// Guardar el archivo en la carpeta
                    //file.SaveAs(filePath);



                    if (!Directory.Exists(strFolder))           // Create the folder if it does not exist.
                    {
                        Directory.CreateDirectory(strFolder);
                    }

                    var extension = Path.GetExtension(file.FileName);
                    extension = extension.ToLower();
                    var peso = file.ContentLength;
                    var allowedExtensions = new[] { ".png", ".jpg", ".gif", ".jpeg", ".pdf" };
                    //string path = Path.Combine(Server.MapPath("~/Recursos/Comunicado"), Path.GetFileName(idComunicado + extension));

                    if (allowedExtensions.Contains(extension))
                    {
                        string userip = Request.UserHostAddress;
                        String token = Encrypt.GeneratePassword();

                        ruta = (DateTime.Now.ToString("yyyyMM") + "/" + DateTime.Now.ToString("yyyyMMdd"));
                        strFolder = Server.MapPath("~/Recursos/Archivos/" + ruta);
                        if (!Directory.Exists(strFolder))// Create the folder if it does not exist.
                        {
                            Directory.CreateDirectory(strFolder);
                        }

                        Session["apiServidor"] = ConfigurationManager.AppSettings["API_SERVIDOR"];
                        // Consumir el api de login
                        File c = new File()
                        {
                            ID_SOURCE = Int32.Parse(idSource),
                            TITULO = file.FileName,
                            EXT = extension,
                            PESO = peso.ToString(),
                            IP = userip,
                            COD_EMPRESA = "01",
                            COD_SUCURSAL = "01",
                            USUARIO = (string)Session["USUARIO"],
                            RUTA = ruta,
                            TOKEN = token,

                        };
                        var url = $"" + Session["apiServidor"] + "/api/CartaGarantia/InsertarArchivos";
                        var request = (HttpWebRequest)WebRequest.Create(url);

                        request.Method = "POST";
                        request.ContentType = "application/json";
                        request.Accept = "application/json";
                        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                        {
                            string json = JsonConvert.SerializeObject(c);
                            streamWriter.Write(json);
                            streamWriter.Flush();
                            streamWriter.Close();
                        }
                        try
                        {
                            using (WebResponse response = request.GetResponse())
                            {
                                using (Stream strReader = response.GetResponseStream())
                                {
                                    if (strReader == null) return View();
                                    using (StreamReader objReader = new StreamReader(strReader))
                                    {
                                        string responseBody = objReader.ReadToEnd();
                                        var Arch = JsonConvert.DeserializeObject<File>(responseBody);
                                        if (Arch.ID_FILE > 0)
                                        {
                                            string path = Path.Combine(strFolder, Path.GetFileName(Arch.ID_FILE + token + extension));
                                            file.SaveAs(path);


                                            c.ID_FILE = Arch.ID_FILE;
                                            url = $"" + Session["apiServidor"] + "/api/CartaGarantia/ActualizarArchivos";
                                            var request1 = (HttpWebRequest)WebRequest.Create(url);

                                            request1.Method = "POST";
                                            request1.ContentType = "application/json";
                                            request1.Accept = "application/json";
                                            using (var streamWriter = new StreamWriter(request1.GetRequestStream()))
                                            {
                                                string json = JsonConvert.SerializeObject(c);
                                                streamWriter.Write(json);
                                                streamWriter.Flush();
                                                streamWriter.Close();
                                            }
                                            using (WebResponse response1 = request1.GetResponse())
                                            {
                                                using (Stream strReader1 = response1.GetResponseStream())
                                                {
                                                    if (strReader == null) return View();
                                                    using (StreamReader objReader1 = new StreamReader(strReader1))
                                                    {
                                                        string responseBody1 = objReader1.ReadToEnd();
                                                        var Arch1 = JsonConvert.DeserializeObject<File>(responseBody1);
                                                        if (Arch1.ID_FILE > 0)
                                                        {
                                                            ViewBag.ID = Arch1.ID_FILE;
                                                            ViewBag.Message = "CORRECTO";
                                                        }
                                                    }
                                                }
                                            }
                                            //                 string sfile = cliente.UpdateArchivosCargados(idFile, idCarga, titulo, codEmpresa, codUsuario);
                                            // BE_FileList Archivo2 = JsonConvert.DeserializeObject<BE_FileList>(sfile);
                                            //Int32.TryParse(Archivo2[0].ID_FILE, out idFile);

                                            //if (idFile > 0) { Session["img"] = "/FileServer/Files/" + ruta + "/" + (idFile.ToString()) + "_" + token + extension; } else { Session["img"] = "/FileServer/Files/errorSistema.png"; }

                                        }
                                    }
                                }
                            }
                        }
                        catch (WebException e)
                        {
                            ViewBag.Message = e.Message;
                        }
                    }
                }
                else
                {
                    ViewBag.Message = "Archivo incorrecto";
                }
            }
            catch (Exception e)
            {
                ViewBag.ID = 0;
                ViewBag.Message = e.Message;
            }
            //ViewBag.Message = "Cargado correctamente";
            return View();
        }

        //public class CartaGarantia
        //{
        //    public int ID { get; set; } = 0;
        //    public int ID_USUARIO { get; set; } = 0;
        //    public string USUARIO { get; set; } = "";

        //}

        public class File
        {
            public int ID_FILE { get; set; } = 0;
            public int ID_SOURCE { get; set; } = 0;
            public int ID_CARGA { get; set; } = 0;
            public string TITULO { get; set; }
            public string EXT { get; set; }
            public string PESO { get; set; }
            public string IP { get; set; }
            public string COD_EMPRESA { get; set; }
            public string COD_SUCURSAL { get; set; }
            public string USUARIO { get; set; }
            public string RUTA { get; set; }
            public string TOKEN { get; set; }
        }

        public class FileResponse
        {

        }


    }
}