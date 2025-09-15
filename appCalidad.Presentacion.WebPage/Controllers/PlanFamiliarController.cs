using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appCalidad.Presentacion.WebPage.Controllers
{
    public class PlanFamiliarController : Controller
    {
        // GET: PlanFamiliar - Cotización y afiliación
        public ActionResult Reportes()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        // GET: PlanFamiliar - Cotización y afiliación
        public ActionResult Index()
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