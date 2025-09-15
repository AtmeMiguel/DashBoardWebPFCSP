using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appCalidad.Presentacion.WebPage.Controllers
{
    public class InterfaceController : Controller
    {
        // GET: Interface
        public ActionResult Index()
        {
            return View();
        }

        // GET: Interface
        public ActionResult PagosxCaja()
        {
            string usuarioIdentity = User.Identity.Name;
            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            return View();
        }

        // GET: Interface
        public ActionResult Provision()
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