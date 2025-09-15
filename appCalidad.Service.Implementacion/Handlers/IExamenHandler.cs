using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Handlers
{
    public interface IExamenHandler
    {
        List<ExamenResponses> ListarExamenesxGrupo(ExamenRequest examen);
        List<PreguntasResponses> ListarPreguntasxExamen(ExamenRequest examen);
        List<ExamenNotasResponses> ListarExamenNotas(TRequest examen);
    }
}
