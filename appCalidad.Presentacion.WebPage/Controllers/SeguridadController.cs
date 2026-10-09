using appCalidad.Infraestructura.Datos.Utils;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
//using DocumentFormat.OpenXml.Drawing.Charts;
//using HtmlAgilityPack;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
//using System.IdentityModel.Claims;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace appCalidad.Presentacion.WebPage.Controllers
{

    public class SeguridadController : Controller
    {
        LogAppDash logApp_ = new LogAppDash();
        private static readonly HttpClient _httpClient = new HttpClient();
        [HttpGet]
        public ActionResult LoginPrueba()
        {
           
            FormsAuthentication.SignOut();
            return View();
        }



        //[HttpGet]
        //public ActionResult Login()
        //{
        //    ViewData["usuario"] = "";

        //    FormsAuthentication.SignOut();
        //    return View();
        //}


        [HttpGet]
        public ActionResult Logout()
        {
            // 1. Le decimos a OWIN que destruya la cookie llamada "ApplicationCookie"
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");

            // 2. Opcional: Si aún usabas alguna variable Session por ahí, puedes limpiarla por precaución
            Session.Clear();
            Session.Abandon();

            // 3. Redirigimos a tu pantalla de Login (ajusta los nombres según tu proyecto)
            return RedirectToAction("Login", "Seguridad");
        }

        [HttpGet]
        [AllowAnonymous] // Asegura que cualquiera pueda ver esta pantalla, incluso sin sesión
        public ActionResult Login()
        {
            ViewData["usuario"] = "";

            // Limpiamos la cookie de OWIN en lugar del antiguo FormsAuthentication
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");

            // Opcional: limpiar también la sesión tradicional por precaución
            Session.Clear();

            return View();
        }

        [HttpGet]
        public ActionResult RecuperarCuenta()
        {
          
            return View();
        }

        [HttpGet]
        public ActionResult RegistrarCuenta()
        {
           
            return View();
        }



        [HttpPost]
        public async Task<JsonResult> LoginUsu2(string USUARIO, string PASSWORD)
        {
            // Protección contra valores nulos antes de usar Trim/ToLower
            USUARIO = (USUARIO ?? "").Trim().ToLower();
            PASSWORD = (PASSWORD ?? "").Trim();

            if (USUARIO.Length > 0 && PASSWORD.Length > 0)
            {
                try
                {
                    var url = $"" + ConfigurationManager.AppSettings["SERVIDOR"] + "/api/Usuarios/VerificarUsuarioPagoPF";

                    AccessRequest c = new AccessRequest() { USUARIO = USUARIO, PASSWORD = PASSWORD, TIPOVAL = "login", TIPODOC = "" };

                    // Usando HttpClient estático o inyectado
                    // Se requiere el paquete de NuGet System.Net.Http.Json para usar PostAsJsonAsync
                    var response = await _httpClient.PostAsJsonAsync(url, c);

                    if (!response.IsSuccessStatusCode)
                        return Json(new { MSG = "Error de comunicación con el servicio." });

                    var Usuario = await response.Content.ReadFromJsonAsync<AccessResponses>();



                    
                    if (Usuario.MSG == "OK")
                                {
                                    // 1. Reemplazo de Session por Claims
                                    string apellidosCompletos = (Usuario.APELLIDO_PATERNO + " " + Usuario.APELLIDO_MATERNO).Trim();

                                    var claims = new[] {
                                        new Claim(ClaimTypes.NameIdentifier, Usuario.USUARIO),
                                        new Claim(ClaimTypes.Name, Usuario.NOMBRES),
                                        new Claim("Apellidos", apellidosCompletos) };

                                    var identity = new ClaimsIdentity(claims, "ApplicationCookie");

                                    // 2. Emisión de la cookie de OWIN
                                    var authManager = Request.GetOwinContext().Authentication;
                                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);

                                    // 3. Devolvemos "OK" y la URL a la que Vue debe redirigir
                                    string urlDestino = Url.Action("Bienvenida", "PagosPF");
                                    return Json(new { MSG = "OK", URL_REDIRECCION = urlDestino });
                                }
                                else
                                {
                                    return Json(new { MSG = Usuario.MSG });
                                }
                    
                }
                catch (HttpRequestException)
                {
                    return Json(new { MSG = "Respuesta de sistema: Ocurrió un error en la red." });
                }
                catch (Exception)
                {
                    return Json(new { MSG = "Respuesta de sistema: Ocurrió un error EX." });
                }
            }
            else
            {
                return Json(new { MSG = "Respuesta de sistema: Ingrese usuario y contraseña." });
            }
        }


        [HttpPost]
        public JsonResult LoginUsu2_HTTPREQUEST(string USUARIO, string PASSWORD)
        {
            // Protección contra valores nulos antes de usar Trim/ToLower
            USUARIO = (USUARIO ?? "").Trim().ToLower();
            PASSWORD = (PASSWORD ?? "").Trim();

            if (USUARIO.Length > 0 && PASSWORD.Length > 0)
            {
                try
                {
                    var url = $"" + ConfigurationManager.AppSettings["SERVIDOR"] + "/api/Usuarios/VerificarUsuarioPagoPF";

                    AccessRequest c = new AccessRequest() { USUARIO = USUARIO, PASSWORD = PASSWORD, TIPOVAL = "login", TIPODOC = "" };
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.Accept = "application/json";

                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        string json = JsonConvert.SerializeObject(c);
                        streamWriter.Write(json);
                    }

                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null)
                                return Json(new { MSG = "Error de comunicación con el servicio." });

                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                var Usuario = JsonConvert.DeserializeObject<AccessResponses>(responseBody);

                                if (Usuario.MSG == "OK")
                                {
                                    // 1. Reemplazo de Session por Claims
                                    string apellidosCompletos = (Usuario.APELLIDO_PATERNO + " " + Usuario.APELLIDO_MATERNO).Trim();

                                    var claims = new[] {
                                new Claim(ClaimTypes.NameIdentifier, Usuario.USUARIO),
                                new Claim(ClaimTypes.Name, Usuario.NOMBRES),
                                new Claim("Apellidos", apellidosCompletos) // Claim personalizado para los apellidos
                            };

                                    var identity = new ClaimsIdentity(claims, "ApplicationCookie");

                                    // 2. Emisión de la cookie de OWIN
                                    var authManager = Request.GetOwinContext().Authentication;
                                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);

                                    // 3. Devolvemos "OK" y la URL a la que Vue debe redirigir
                                    string urlDestino = Url.Action("Bienvenida", "PagosPF");
                                    return Json(new { MSG = "OK", URL_REDIRECCION = urlDestino });
                                }
                                else
                                {
                                    return Json(new { MSG = Usuario.MSG });
                                }
                            }
                        }
                    }
                }
                catch (WebException)
                {
                    return Json(new { MSG = "Respuesta de sistema: Ocurrió un error en la red." });
                }
            }
            else
            {
                return Json(new { MSG = "Respuesta de sistema: Ingrese usuario y contraseña." });
            }
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
           
            if (User.Identity.IsAuthenticated)
            {
                Session["ID_ROL"] = ID_ROL;
                Session["ROL"] = ROL;
                Session["ID_SEDE"] = ID_SEDE;
                Session["SEDE"] = SEDE;

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