using appCalidad.Infraestructura.Datos.Repository;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appCalidad.Presentacion.WebPage.Controllers
{
    public class ExcelCargasController : Controller
    {
        private DExcelCargaHandlers DExcel;
        public ExcelCargasController()
        {
            DExcel = new DExcelCargaHandlers();
        }

        // GET: ExcelCargas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExcelCarga(string idGrupo, string idPrograma, string idUsuario)
        {
            Session["ID_GRUPO"] = idGrupo;
            Session["ID_SEDE"] = idPrograma;
            Session["ID_USUARIO"] = idUsuario;
            return View();
        }
    }
}