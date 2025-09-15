using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Request.CLARO;
using appCalidad.Service.Implementacion.Responses;
using appCalidad.Service.Implementacion.Responses.CLARO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Handlers
{
    public interface IOfrecimientoHandler
    {
        TResponses AdministrarOfrecimiento(OfrecimientoRequest ofrecimiento);
        List<OfrecimientoResponses> ListarOfrecimiento(TRequest ofrecimiento);

        TResponses AdministrarPreventiva(PreventivaRequest preventiva);
        List<BandejaBackofficeResponses> ListarBandejaPreventiva(TRequest preventiva);
        List<TResponses> ListarAgendamientos(TRequest agenda);
        
        TResponses AdministrarRetenciones(RetencionesRequest retenciones);


        List<CustomerIDResponses> ListarCustomer(TRequest customer);
        TResponses AdministrarCustomer(CustomerIDRequest customer);

        List<TResponses> ListarCustomerAntiguos(CustomerIDRequest customer);
        TResponses MostrarCustomerID(CustomerIDRequest customer);

        List<BandejaBackofficeResponses> ListarBandejaRetenciones(TRequest retenciones);
    }
}
