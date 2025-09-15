using appCalidad.Infraestructura.Datos.Repository;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appCalidad.Presentacion.WebPage.Controllers.API
{
    [Authorize]
    public class ExamenController : ApiController
    {
        private DExamenHandlers Examen;
        public ExamenController()
        {
            Examen = new DExamenHandlers();
        }

        [Route("api/Examen/ListarExamenesxGrupo")]
        [HttpPost]
        public List<ExamenResponses> ListarExamenesxGrupo(ExamenRequest examen)
        {
            return Examen.ListarExamenesxGrupo(examen);
        }
        
        [Route("api/Examen/ListarPreguntasxExamen")]
        [HttpPost]
        public List<PreguntasResponses> ListarPreguntasxExamen(ExamenRequest examen)
        {
            return Examen.ListarPreguntasxExamen(examen);
        }

        [Route("api/Examen/ListarExamenNotas")]
        [HttpPost]
        public List<ExamenNotasResponses> ListarExamenNotas(TRequest examen)
        {
            return Examen.ListarExamenNotas(examen);
        }
        
    }
}
