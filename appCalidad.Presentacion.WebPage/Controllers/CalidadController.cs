using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appCalidad.Presentacion.WebPage.Controllers
{
    [Authorize]
    public class CalidadController : Controller
    {
        // GET: Calidad
        public ActionResult Monitor()
        {
            return View();
        }

        public ActionResult Agente()
        {
            return View();
        }

        public ActionResult Gestion()
        {
            return View();
        }

        public ActionResult Busqueda()
        {
            return View();
        }
        public ActionResult BusquedaAdmin()
        {
            return View();
        }

        public ActionResult NuevoRegistro()
        {
            return View();
        }

        public ActionResult Galeria()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        public ActionResult Formulario()
        {
            return View();
        }
    }
}