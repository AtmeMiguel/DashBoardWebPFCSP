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
    //[Authorize]
    public class FormularioController : ApiController
    {
        private DFormularioHandlers Formulario;
        public FormularioController()
        {
            Formulario = new DFormularioHandlers();
        }

        [Route("api/Formulario/ListarFormulariosxPrograma")]
        [HttpPost]
        public List<FormularioResponses> ListarExamenesxGrupo(TRequest form)
        {
            return Formulario.ListarFormulariosxPrograma(form);
        }

        [Route("api/Formulario/ListarFormulariosxGrupo")]
        [HttpPost]
        public List<FormularioGrupoResponses> ListarFormulariosxGrupo(TRequest form)
        {
            return Formulario.ListarFormulariosxGrupo(form);
        }

        [Route("api/Formulario/ListarFormulariosGrupoxUsuario")]
        [HttpPost]
        public List<FormularioResponses> ListarFormulariosGrupoxUsuario(TRequest form)
        {
            return Formulario.ListarFormulariosGrupoxUsuario(form);
        }
        

        [Route("api/Formulario/MantenimientoFormulario")]
        [HttpPost]
        public TResponses MantenimientoFormulario(FormularioRequest form)
        {
            return Formulario.MantenimientoFormulario(form);
        }

        [Route("api/Formulario/MantenimientoFormularioCRM")]
        [HttpPost]
        public TResponses MantenimientoFormularioCRM(TRequest form)
        {
            return Formulario.MantenimientoFormularioCRM(form);
        }

        [Route("api/Formulario/ListarPreguntasxFormulario")]
        [HttpPost]
        public List<ControlResponses> ListarPreguntasxFormulario(TRequest form)
        {
            return Formulario.ListarPreguntasxFormulario(form);
        }
        
        [Route("api/Formulario/ListarPreguntasxExamen")]
        [HttpPost]
        public List<PreguntasResponses> ListarPreguntasxExamen(TRequest form)
        {
            return Formulario.ListarPreguntasxExamen(form);
        }

        

        [Route("api/Formulario/MantenimientoPregunta")]
        [HttpPost]
        public TResponses MantenimientoPregunta(FormularioRequest form)
        {
            return Formulario.MantenimientoPregunta(form);
        }

        [Route("api/Formulario/ListarRespuestasxPregunta")]
        [HttpPost]
        public List<ItemsResponses> ListarRespuestasxPregunta(TRequest form)
        {
            return Formulario.ListarRespuestasxPregunta(form);
        }

        [Route("api/Formulario/MantenimientoRespuesta")]
        [HttpPost]
        public TResponses MantenimientoRespuesta(FormularioRequest form)
        {
            return Formulario.MantenimientoRespuesta(form);
        }

        [Route("api/Formulario/ListarUsuariosxInicioFormulario")]
        [HttpPost]
        public List<ItemsResponses> ListarUsuariosxInicioFormulario(TRequest form)
        {
            return Formulario.ListarUsuariosxInicioFormulario(form);
        }
        
        [Route("api/Formulario/ListarPlantilla")]
        [HttpPost]
        public List<TResponses> ListarPlantilla(TRequest form)
        {
            return Formulario.ListarPlantilla(form);
        }

        [Route("api/Formulario/Mantenimiento")]
        [HttpPost]
        public TResponses Mantenimiento(FormularioRequest form)
        {
            return Formulario.Mantenimiento(form);
        }

        [Route("api/Formulario/Listar")]
        [HttpPost]
        public List<TResponses> Listar(TRequest form)
        {
            return Formulario.Listar(form);
        }

        [Route("api/Formulario/ListarGaleriaxCarga")]
        [HttpPost]
        public List<ComunicadoResponses> ListarGaleriaxCarga(TRequest carga)
        {
            return Formulario.ListarGaleriaxCarga(carga);
        }

        [Route("api/Formulario/MantenimientoQUEUE")]
        [HttpPost]
        public TResponses MantenimientoQUEUE(TRequest carga)
        {
            return Formulario.MantenimientoQUEUE(carga);
        }

        [Route("api/Formulario/MantenimientoGaleria")]
        [HttpPost]
        public TResponses MantenimientoGaleria(TRequest carga)
        {
            return Formulario.MantenimientoGaleria(carga);
        }
        
    }
}
