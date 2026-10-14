using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Handlers
{
   public interface IPagosPFHandler
    {
        Task<MensajePFResponse> EnviarMensajePagoPF(MensajePFRequest user);

        Task<List<PagoPFResponse>> ListarContratosPagoPF(PagoPFRequest autObj);

        Task<List<PagoPFResponse>> ListarCuotasPendientesPF(PagoPFRequest autObj);


        List<PagoPFResponse> InsertarCuotasPagoPF(PagoPFRequest autObj);


    }
}
