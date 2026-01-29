using appCalidad.Infraestructura.Datos.Repository;
//using appCalidad.Presentacion.WebPage.Controllers.JWT;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using System;
using System.Collections.Generic;
using System.Configuration;
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



        [Route("api/PagosPF/EnviarMsgPagoPF")]
        [HttpPost]
        public MensajePFResponse EnviarMsgPagoPF(MensajePFRequest mensaje)
        {
            MensajePFResponse Respuesta = new MensajePFResponse();
            Respuesta = pagos.EnviarMensajePagoPF(mensaje);
            return Respuesta;
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

            data = pagos.ListarCuotasPendientesPF(obj);
            return data;
        }

        [Route("api/PagosPF/ListarCuotasPagadasPF")]
        [HttpPost]
        public List<PagoPFResponse> ListarCuotasPagadasPF(PagoPFRequest obj)
        {
            List<PagoPFResponse> data = new List<PagoPFResponse>();

            data = pagos.ListarCuotasPagadasPF(obj);
            return data;
        }


        [Route("api/PagosPF/ListarCuoPenGenPF")]
        [HttpPost]
        public List<PagoPFResponse> ListarCuotasPendientesGeneralPF(PagoPFRequest obj)
        {
            List<PagoPFResponse> data = new List<PagoPFResponse>();

            data = pagos.ListarCuotasPendientesGeneralPF(obj);
            return data;
        }


        [Route("api/PagosPF/ListarCuoPagGenPF")]
        [HttpPost]
        public List<PagoPFResponse> ListarCuotasPagadasGeneralPF(PagoPFRequest obj)
        {
            List<PagoPFResponse> data = new List<PagoPFResponse>();

            data = pagos.ListarCuotasPagadasGeneralPF(obj);
            return data;
        }



        [Route("api/PagosPF/RegTransCuota")]
        [HttpPost]
        public List<PagoPFResponse> InsertarCuotasPagoPF(PagoPFRequest obj)
        {
            List<PagoPFResponse> data = new List<PagoPFResponse>();

            data = pagos.InsertarCuotasPagoPF(obj);
            return data;
        }

        [Route("api/PagosPF/RegTransCuotaFormPag")]
        [HttpPost]
        public List<PagoPFResponse> InsertarCuotasFormaPagoPF(PagoPFRequest obj)
        {
            List<PagoPFResponse> data = new List<PagoPFResponse>();

            data = pagos.InsertarCuotasFormaPagoPF(obj);
            return data;
        }

        /*VALIDAR T_PAGO*/
        [Route("api/PagosPF/ValidarTPago")]
        [HttpPost]
        public List<PagoPFResponse> ValidarTablaPagoWeb(PagoPFRequest obj)
        {
            List<PagoPFResponse> data = new List<PagoPFResponse>();

            data = pagos.ValidarTablaPagoWeb(obj);
            return data;
        }



        [Route("api/PagosPF/ObtMnt")]
        [HttpPost]
        public PagoPFResponse obtenerMontoCotizacion(PagoPFRequest items)
        {
            return pagos.obtenerMontoCotizacion(items);
        }


        /*Agregado para pago cotizaciones*/
        [Route("api/PagosPF/GenAut")]
        [HttpPost]
        public Dictionary<string, string> GenerarAutenticacionSynapsisPfV2(SynapsisRequestV2 items)
        {
             
            string apikey = ConfigurationManager.AppSettings["APIKEY_1001"].ToString(); // _configuration.GetValue<string>("APIKEY_" + items.COD_EMPRESA);
            string secretkey = ConfigurationManager.AppSettings["SECRET_1001"].ToString(); //_configuration.GetValue<string>("SECRET_" + items.COD_EMPRESA);
            return pagos.GenerarAutenticacionSynapsisPfV2(items.TRANSACTION,apikey,secretkey); // (items);
            
        }


    }
}