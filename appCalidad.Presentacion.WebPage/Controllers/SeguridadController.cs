using appCalidad.Infraestructura.Datos.Utils;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using DocumentFormat.OpenXml.Drawing.Charts;
//using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Claims;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace appCalidad.Presentacion.WebPage.Controllers
{

    public class SeguridadController : Controller
    {
        LogAppDash logApp_ = new LogAppDash();

        [HttpGet]
        public ActionResult LoginPrueba()
        {
            //string uri = ConfigurationManager.AppSettings["API_SERVIDOR"];
            //logApp_.NuevoRegistroLog(this.GetType().Name, uri, "rutalog");
            //Session["apiServidor"] = uri;// ConfigurationManager.AppSettings["API_SERVIDOR"];
            FormsAuthentication.SignOut();
            return View();
        }



        [HttpGet]
        public ActionResult Login()
        {
            //string uri = ConfigurationManager.AppSettings["API_SERVIDOR"];
            //logApp_.NuevoRegistroLog(this.GetType().Name, uri, "rutalog");
            //Session["apiServidor"] = uri;// ConfigurationManager.AppSettings["API_SERVIDOR"];
            FormsAuthentication.SignOut();
            return View();
        }

        [HttpGet]
        public ActionResult RecuperarCuenta()
        {
            //string uri = ConfigurationManager.AppSettings["API_SERVIDOR"];
            //logApp_.NuevoRegistroLog(this.GetType().Name, uri, "rutalog");
            //Session["apiServidor"] = uri;// ConfigurationManager.AppSettings["API_SERVIDOR"];
            //FormsAuthentication.SignOut();
            return View();
        }

        [HttpGet]
        public ActionResult RegistrarCuenta()
        {
            //string uri = ConfigurationManager.AppSettings["API_SERVIDOR"];
            //logApp_.NuevoRegistroLog(this.GetType().Name, uri, "rutalog");
            //Session["apiServidor"] = uri;// ConfigurationManager.AppSettings["API_SERVIDOR"];
            //FormsAuthentication.SignOut();
            return View();
        }
        /*
        [HttpPost]
        public ActionResult Login(string USUARIO, string PASSWORD)
        {
            
            if (USUARIO.Length > 0 && PASSWORD.Length > 0)
            {
                try
                {                  
                    var url = $"" + ConfigurationManager.AppSettings["API_SERVIDOR"] + "/api/Usuario/Login";

                    AccessRequest c = new AccessRequest() { USUARIO = USUARIO, PASSWORD = PASSWORD };
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

                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) return View();
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                var Usuario = JsonConvert.DeserializeObject<Us>(responseBody);
                                if (Usuario.userInfo.id > 0)
                                {
                                     
                                    Session["Usuario"] = Usuario.userInfo.usuario;
                                    Session["Nombres"] = Usuario.userInfo.nombres;
                                    Session["Apellidos"] = Usuario.userInfo.apellidos;
                                    Session["Token"] = Usuario.access_token;
                                    FormsAuthentication.SetAuthCookie(Usuario.userInfo.id.ToString(), false);
                                    return RedirectToAction("AsignarRol", "Seguridad");
                                }
                              
                            }
                        }
                    }
                }
                catch (WebException e)
                {
                    ViewBag.EMessage = e.Message;
                    ViewBag.Message = "USUARIO O PASSWORD INCORRECTOS.";
                }
            }
            else
            {
                    ViewBag.Message = "INGRESE USUARIO Y PASSWORD.";
            }
            return View();
        }*/


        [HttpPost]
        public ActionResult Login(string USUARIO, string PASSWORD)
        {

            if (USUARIO.Length > 0 && PASSWORD.Length > 0)
            {
                try
                {
                    var url = $"" + ConfigurationManager.AppSettings["API_SERVIDOR"] + "/api/Usuarios/VerificarUsuarioPagoPF";
                   
                    AccessRequest c = new AccessRequest() { USUARIO = USUARIO, PASSWORD = PASSWORD, TIPOVAL ="login",TIPODOC="" };
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

                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) return View();
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                var Usuario = JsonConvert.DeserializeObject<AccessResponses>(responseBody);
                                if (Usuario.MSG =="OK")
                                {

                                    Session["Usuario"] = Usuario.USUARIO;
                                    Session["Nombres"] = Usuario.NOMBRES;
                                    Session["Apellidos"] = Usuario.APELLIDO_PATERNO + " " + Usuario.APELLIDO_MATERNO;


                                    //Session["Token"] = Usuario.access_token;
                                    FormsAuthentication.SetAuthCookie(Usuario.USUARIO.ToString(), false);
                                    return RedirectToAction("AsignarRol", "Seguridad");
                                }
                                else
                                {
                                    ViewBag.Message = Usuario.MSG;
                                }

                            }
                        }
                    }
                }
                catch (WebException e)
                {
                    ViewBag.EMessage = e.Message;
                    ViewBag.Message = "Respuesta de sistema: Ocurrio un error contacte con Soporte.";
                }
            }
            else
            {
                ViewBag.Message = "Respuesta de sistema: Ingrese usuario y contraseña.";
            }
            return View();
        }



        [HttpGet]
        public ActionResult AsignarRol()
        {
            ViewBag.Errores = "Todo OK";
            List<Roles> rolo = new List<Roles>();
            if (User.Identity.IsAuthenticated)
            {
                logApp_.NuevoRegistroLog(this.GetType().Name, "user identity -> " + User.Identity.Name, "rutalog");
                try
                {
                    var usId = User.Identity.Name;
                RolesxUsuario c = new RolesxUsuario() { ID = usId, USUARIO = "", NOMBRES = "", PASSWORD = "", APELLIDOS = "" };
                var url = $"" + ConfigurationManager.AppSettings["API_SERVIDOR"] + "/api/Usuario/ListarRolesxUsuario";
                var request = (HttpWebRequest)WebRequest.Create(url);  // 

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
                
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) return View();
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                List<Roles> r = JsonConvert.DeserializeObject<List<Roles>>(responseBody);
                                foreach (var fila in r)
                                {
                                    Roles Filas = new Roles();
                                    Filas.ID = fila.ID;
                                    Filas.ID_ROL = fila.ID_ROL;
                                    Filas.TITULO = fila.TITULO;
                                    Filas.ID_SEDE = fila.ID_SEDE;
                                    Filas.SEDE = fila.SEDE;
                                    rolo.Add(Filas);
                                }

                                if (rolo.Count == 1)
                                {
                                    Session["ID_ROL"] = rolo[0].ID_ROL;
                                    Session["ROL"] = rolo[0].TITULO;
                                    Session["ID_SEDE"] = rolo[0].ID_SEDE;
                                    Session["SEDE"] = rolo[0].SEDE;

                                    logApp_.NuevoRegistroLog(this.GetType().Name, "Asignar rol -> " + Session["ROL"].ToString(), "rutalog");
                                    return RedirectToAction("Home", "Seguridad");
                                }
                                else if (rolo.Count > 1)
                                {
                                    ViewBag.Listado = rolo;
                                }
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    ViewBag.Errores = ex.Message;
                }
            }
            else
            {
                logApp_.NuevoRegistroLog(this.GetType().Name, "No hay user identity", "rutalog");
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        //[Authorize]
        [HttpGet]
        public ActionResult Inter(string ID, string ID_ROL, string ROL, string SEDE, string ID_SEDE)
        {
            //var sede = Encoding.UTF8.GetBytes(SEDE);
            //var sede1 = Encoding.Default.GetString(sede);
            //sede = HttpUtility.HtmlDecode(sede.ToString());
            if (User.Identity.IsAuthenticated)
            {
                Session["ID_ROL"] = ID_ROL;
                Session["ROL"] = ROL;
                Session["ID_SEDE"] = ID_SEDE;
                Session["SEDE"] = SEDE;


                //  aqui
                // FormsAuthentication.SetAuthCookie(ID.ToString(), false);
                // return RedirectToAction("Home", "Seguridad");

                //   hasta a qui
                UsuarioRequest c = new UsuarioRequest() { ROL = ROL };
                var url = $"" + ConfigurationManager.AppSettings["API_SERVIDOR"] + "/api/Usuario/TokenRol";
                var request = (HttpWebRequest)WebRequest.Create(url);   // 

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
                    // Session["Token"] = "";
                    // FormsAuthentication.SetAuthCookie(ID.ToString(), false);
                    // return RedirectToAction("Home", "Seguridad");
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) return View();
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                var Usuario = JsonConvert.DeserializeObject<Us>(responseBody);
                                if (Usuario.userInfo.id > 0)
                                {
                                    Session["Token"] = Usuario.access_token;
                                    FormsAuthentication.SetAuthCookie(Usuario.userInfo.id.ToString(), false);
                                    return RedirectToAction("Home", "Seguridad");
                                }
                            }
                        }
                    }
                }
                catch (WebException e)
                {
                    return RedirectToAction("Login", "Seguridad");
                    //ViewBag.Listado = ex.Message;
                }
                if (Int32.Parse(ID) > 0) { return RedirectToAction("Home", "Seguridad"); } else { return RedirectToAction("Login", "Seguridad"); }
            }
            return View();
        }


        //[Authorize]
        public ActionResult Home()
        {
            string usuarioIdentity = User.Identity.Name;

            if (usuarioIdentity == "" || Session["Usuario"] == null || Session["ID_ROL"] is null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        [Authorize]
        public ActionResult Perfil()
        {
            return View();
        }

        [Authorize]
        public ActionResult Notas()
        {
            return View();
        }


        public class Us
        {
            public string access_token { get; set; }
            public userInfo userInfo { get; set; }
        }

        public class userInfo
        {
            public int id { get; set; }
            public string usuario { get; set; }
            public string nombres { get; set; }
            public string apellidos { get; set; }
            public string correo { get; set; }

            public string rol { get; set; }
            public string accessToken { get; set; }
        }

        public class Roles
        {
            public int ID { get; set; }
            public int ID_ROL { get; set; }
            public string TITULO { get; set; }
            public int ID_SEDE { get; set; }
            public string SEDE { get; set; }
        }

        public class RolesxUsuario
        {
            public string ID { get; set; }
            public string USUARIO { get; set; }
            public string NOMBRES { get; set; }
            public string PASSWORD { get; set; }
            public string APELLIDOS { get; set; }
        }
    }
}