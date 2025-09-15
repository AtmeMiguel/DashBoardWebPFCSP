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
    public class ExcelCargasController : ApiController
    {
        private DExcelCargaHandlers eCargas;
        public ExcelCargasController()
        {
            eCargas = new DExcelCargaHandlers();
        }

        [Route("api/Excel/ListarCargasxPrograma")]
        [HttpPost]
        public List<TResponses> ListarCargasxPrograma(TRequest excel)
        {
            return eCargas.ListarCargasxPrograma(excel);
        }

        [Route("api/Excel/MantenimientoCarga")]
        [HttpPost]
        public TResponses MantenimientoCarga(TRequest excel)
        {
            return eCargas.MantenimientoCarga(excel);
        }
       
    }
}
