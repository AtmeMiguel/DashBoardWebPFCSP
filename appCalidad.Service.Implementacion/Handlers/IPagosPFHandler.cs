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
        List<PagoPFResponse> ListarContratosPagoPF(PagoPFRequest autObj);
        List<PagoPFResponse> InsertarCuotasPagoPF(PagoPFRequest autObj);
        List<PagoPFResponse> ListarCuotasPendientesPF(PagoPFRequest autObj);
    }
}
