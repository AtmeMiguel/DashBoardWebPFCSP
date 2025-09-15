using appCalidad.Infraestructura.Datos.Repository;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using appCalidad.Service.Implementacion.Responses.CLARO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appCalidad.Presentacion.WebPage.Controllers.API
{
    [Authorize]
    public class EnlaceController : ApiController
    {
        private DEnlaceHandlers Enlace;
        public EnlaceController()
        {
            Enlace = new DEnlaceHandlers();
        }

        [Route("api/Enlace/AdministrarEnlace")]
        [HttpPost]
        public TResponses AdministrarEnlace(EnlaceRequest enlace)
        {
            return Enlace.AdministrarEnlace(enlace);
        }

        [Route("api/Enlace/ListarEnlaces")]
        [HttpPost]
        public List<EnlaceResponses> ListarEnlaces(TRequest comunicado)
        {
            return Enlace.ListarEnlaces(comunicado);
        }

        [Route("api/Enlace/ListarTree")]
        [HttpPost]
        public List<TreeResponses> ListarTree(TRequest comunicado)
        {
            return Enlace.ListarTree(comunicado);
        }

        [Route("api/Enlace/ListarGrillaCanalesClaro")]
        [HttpPost]
        public List<GrillaCanalesResponses> ListarGrillaCanalesClaro(TRequest comunicado)
        {
            return Enlace.ListarGrillaCanalesClaro(comunicado);
        }
        [Route("api/Enlace/ListarEdificiosLiberados")]
        [HttpPost]
        public List<GrillaEdificiosResponses> ListarEdificiosLiberados(TRequest comunicado)
        {
            return Enlace.ListarEdificiosLiberados(comunicado);
        }

        [Route("api/Enlace/ListarNodosLiberados")]
        [HttpPost]
        public List<GrillaNodosResponses> ListarNodosLiberados(TRequest comunicado)
        {
            return Enlace.ListarNodosLiberados(comunicado);
        }


        [Route("api/Enlace/ClienteCAE")]
        [HttpPost]
        public List<TResponses> ClienteCAE(TRequest cliente)
        {
            return Enlace.ClienteCAE(cliente);
        }
    }
}
