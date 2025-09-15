using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appCalidad.Presentacion.WebPage.Controllers
{
    public class ControlCumplimientoController : Controller
    {
        // GET: ControlCumplimiento
        public ActionResult Index()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        // GET: ControlCumplimiento
        public ActionResult Horarios()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }
        // GET: ControlCumplimiento
        public ActionResult Reporte()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        // GET: ControlCumplimiento
        public ActionResult Cierre()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        // GET: ControlCumplimiento
        public ActionResult VisorCierre()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }
    }
}