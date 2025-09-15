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
    public class ComunicadoController : ApiController
    {
        private DComunicadoHandlers Comunicado;
        public ComunicadoController()
        {
            Comunicado = new DComunicadoHandlers();
        }
        
        [Route("api/Comunicado/ListarComunicadosxPrograma")]
        [HttpPost]
        public List<ComunicadoResponses> ListarComunicadosxPrograma(TRequest comunicado)
        {
            return Comunicado.ListarComunicadosxPrograma(comunicado);
        }

        [Route("api/Comunicado/ListarComunicadoxGrupo")]
        [HttpPost]
        public List<ComunicadoResponses> ListarComunicadoxGrupo(TRequest comunicado)
        {
            return Comunicado.ListarComunicadoxGrupo(comunicado);
        }

        [Route("api/Comunicado/MantenimientoComunicado")]
        [HttpPost]
        public TResponses MantenimientoComunicado(ComunicadoRequest comunicado)
        {
            return Comunicado.MantenimientoComunicado(comunicado);
        }

        [Route("api/Comunicado/AdministrarComunicado")]
        [HttpPost]
        public TResponses AdministrarComunicado(ComunicadoRequest comunicado)
        {
            return Comunicado.AdministrarComunicado(comunicado);
        }

        [Route("api/Comunicado/EliminarComunicado")]
        [HttpPost]
        public TResponses EliminarComunicado(ComunicadoRequest comunicado)
        {
            return Comunicado.EliminarComunicado(comunicado);
        }
        
    }
}
