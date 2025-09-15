using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using appCalidad.Infraestructura.Datos;
using appCalidad.Infraestructura.Datos.Repository;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;



namespace appCalidad.Presentacion.WebPage.Controllers
{

    public class NotasCreditoController : Controller
    {

        //private DDocPagoHandlers Docpago;
        private Export _export;
        public NotasCreditoController()
        {
            //Docpago = new DDocPagoHandlers();
            _export = new Export();
        }

        // GET: NotasCredito

        public ActionResult Bandeja()
        {
            string usuarioIdentity = User.Identity.Name;

            if (usuarioIdentity == "" || Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }


            return View();
        }

        public ActionResult ConsultarDocumentos()
        {
            return View();
        }


        public ActionResult ReporteExcel(string estado = "", string fecini = "", string fecfin = "", string nroserie = "", string nrofactura = "", string responsable = "")
        {
            DateTime fecha;

            if (!DateTime.TryParse(fecini, out fecha))
            {
                fecini = "";
            }

            if (!DateTime.TryParse(fecfin, out fecha))
            {
                fecfin = "";
            }
            DocPagoRequest docpago = new DocPagoRequest()
            {
                TIPO = "",
                FLG_EST_DOC = estado,
                FEC_INI = fecini,
                FEC_FIN = fecfin,
                SNROFAC = nroserie,
                DNROFAC = nrofactura,
                DRESP_CAB = responsable
            };
            var resultado = new List<DocPagoResponses>();
            /*
            List<DocPagoResponses> lst = Docpago.ListarDocPagoxPrograma(docpago);

            var resultado = lst.Select(x =>
                 new
                 {
                     NROLOTE = x.DNROLOTE,
                     FECHA = x.DFECHA_CAB,
                     SERIE = x.SNROFAC,
                     CORRELATIVO = x.DNROFAC,
                     ESTADO = x.FLG_EST_DOC
                 }
              ).ToList();
            */


            _export.ToExcel(Response, resultado, "prueba_excel");

            return View();
        }


    }
}