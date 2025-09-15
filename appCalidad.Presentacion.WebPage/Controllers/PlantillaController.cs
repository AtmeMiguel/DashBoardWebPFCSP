using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appCalidad.Presentacion.WebPage.Controllers
{
    [Authorize]
    public class PlantillaController : Controller
    {
        // GET: Plantilla
        public ActionResult Imagen(string idComunicado, string idUsuario)
        {
            Session["ID_COMUNICADO"] = idComunicado;
            Session["ID_USUARIO"] = idUsuario;
            ViewBag.Message = "Iniciando proceso de carga:";
            return View();
        }

        public ActionResult Formulario()
        {
            return View();
        }

        public ActionResult FormularioVenta()
        {
            return View();
        }

        public ActionResult FormularioDinamico()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

    }
}