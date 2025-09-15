using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Handlers
{
    public interface IComunicadoHandler
    {
        List<ComunicadoResponses> ListarComunicadosxPrograma(TRequest comunicado);
        List<ComunicadoResponses> ListarComunicadoxGrupo(TRequest comunicado);

        TResponses AdministrarComunicado(ComunicadoRequest comunicado);
        TResponses MantenimientoComunicado(ComunicadoRequest comunicado);
        TResponses EliminarComunicado(ComunicadoRequest comunicado);
    }
}
