using appCalidad.Infraestructura.Datos.Repository;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace appCalidad.Presentacion.WebPage.Controllers.API
{
    [Authorize]
    public class NotasCreditoController : ApiController
    {

        private DDocPagoHandlers Docpago;
        //int idsede = Convert.ToInt32(HttpContext.Current.Request.Headers["parSed"]);
        private string usuario = "";

        public NotasCreditoController()
        {
            usuario = User.Identity.Name;
            //Docpago = new DDocPagoHandlers(idsede);
            Docpago = new DDocPagoHandlers();
        }

        [Route("api/NotasCredito/ListarDocPagoxPrograma")]
        [HttpPost]
        public List<DocPagoResponses> ListarDocPagoxPrograma(DocPagoRequest docpago)
        {

            return Docpago.ListarDocPagoxPrograma(docpago);
        }

        [Route("api/NotasCredito/AdministrarDocPago")]
        [HttpPost]
        public DocPagoResponses AdministrarDocPago(DocPagoRequest docpago)
        {
            docpago.AUTO_POR = usuario;
            var ruta = HttpContext.Current.Request.MapPath(@"~/Recursos/plantillas/");
            docpago.RUTA = ruta;
            return Docpago.AdministrarDocPago(docpago);
        }




    }
}
