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
    public interface IOpcionesCRMHandler
    {
        List<OpcionesResponses> ListarOpcionesCRM(TRequest opc);
        TResponses AdministrarOpcionesCRM(OpcionesRequest opc);
    }
}
