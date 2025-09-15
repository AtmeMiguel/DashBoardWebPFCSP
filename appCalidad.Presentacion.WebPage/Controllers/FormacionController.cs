using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appCalidad.Presentacion.WebPage.Controllers
{
    [Authorize]
    public class FormacionController : Controller
    {
        // GET: Formacion
        public ActionResult Tree()
        {
            return View();
        }
        public ActionResult Examen()
        {
            return View();
        }

        public ActionResult Modulo()
        {
            return View();
        }
    }
}