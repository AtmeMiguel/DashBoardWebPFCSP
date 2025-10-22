using appCalidad.Infraestructura.Datos.Repository;
//using appCalidad.Presentacion.WebPage.Controllers.JWT;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Security;


namespace appCalidad.Presentacion.WebPage.Controllers.API
{

    [Authorize]
    public class PagosPFController : ApiController
    {
        private DPagosPFHandlers pagos;
        public PagosPFController()
        {
            pagos = new DPagosPFHandlers();
        }

    
        [Route("api/PagosPF/ListarContratosPagoPF")]
        [HttpPost]
        public List<PagoPFResponse> ListarContratosPagoPF(PagoPFRequest obj)
        {
            List<PagoPFResponse> data = new List<PagoPFResponse>();

            data = pagos.ListarContratosPagoPF(obj);
            return data;
        }

        [Route("api/PagosPF/ListarCuotasPagoPF")]
        [HttpPost]
        public List<PagoPFResponse> ListarCuotasPagoPF(PagoPFRequest obj)
        {
            List<PagoPFResponse> data = new List<PagoPFResponse>();

            data = pagos.ListarCuotasPagoPF(obj);
            return data;
        }

    }
}