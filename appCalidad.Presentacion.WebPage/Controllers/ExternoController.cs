using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appCalidad.Presentacion.WebPage.Controllers
{
    public class ExternoController : Controller
    {
        // GET: Externo
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Presentacion()
        {
   
            return View();
        }

        [HttpGet]
        public ActionResult PresentacionPrueba()
        {

            return View();
        }
        

    }
}