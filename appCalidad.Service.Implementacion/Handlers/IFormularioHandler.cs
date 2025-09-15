using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Handlers
{
    public interface IFormularioHandler
    {
        List<FormularioResponses> ListarFormulariosxPrograma(TRequest form);
        List<FormularioGrupoResponses> ListarFormulariosxGrupo(TRequest form);
        List<FormularioResponses> ListarFormulariosGrupoxUsuario(TRequest form);
        List<ItemsResponses> ListarUsuariosxInicioFormulario(TRequest form);

        TResponses MantenimientoFormulario(FormularioRequest form);
        TResponses MantenimientoFormularioCRM(TRequest form);

        List<ControlResponses> ListarPreguntasxFormulario(TRequest form);
        List<PreguntasResponses> ListarPreguntasxExamen(TRequest form);
        TResponses MantenimientoPregunta(FormularioRequest form);

        List<ItemsResponses> ListarRespuestasxPregunta(TRequest form);
        TResponses MantenimientoRespuesta(FormularioRequest form);

        List<TResponses> ListarPlantilla(TRequest form);


        TResponses Mantenimiento(FormularioRequest form);
        List<TResponses> Listar(TRequest form);
        TResponses MantenimientoQUEUE(TRequest form);

        List<ComunicadoResponses> ListarGaleriaxCarga(TRequest carga);
        TResponses MantenimientoGaleria(TRequest carga);

    }
}
