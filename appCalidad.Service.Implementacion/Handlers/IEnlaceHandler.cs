using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using appCalidad.Service.Implementacion.Responses.CLARO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Handlers
{
    public interface IEnlaceHandler
    {
        List<EnlaceResponses> ListarEnlaces(TRequest comunicado);
        TResponses AdministrarEnlace(EnlaceRequest enlace);
        List<TreeResponses> ListarTree(TRequest comunicado);
        List<GrillaCanalesResponses> ListarGrillaCanalesClaro(TRequest comunicado);
        List<GrillaEdificiosResponses> ListarEdificiosLiberados(TRequest customer);
        List<GrillaNodosResponses> ListarNodosLiberados(TRequest customer);
        List<TResponses> ClienteCAE(TRequest preventiva);
    }
}
