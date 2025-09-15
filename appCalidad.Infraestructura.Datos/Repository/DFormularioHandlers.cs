using appCalidad.Infraestructura.Datos.Connection;
using appCalidad.Service.Implementacion.Handlers;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using Dapper;
using Dapper.Oracle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Infraestructura.Datos.Repository
{
    public class DFormularioHandlers : IFormularioHandler
    {
        private readonly IDbConnection DbConnection;
        Conexiones con = new Conexiones();

        //private readonly IDbConnection DbConnectionCRM;
        //Conexiones conCRM = new Conexiones();

        public DFormularioHandlers()
        {
            DbConnection = con.ConstruirConexion();
            //DbConnectionCRM = con.ConstruirConexionSede(1);
        }

        public List<FormularioResponses> ListarFormulariosxPrograma(TRequest form)
        {

            var Consulta = DbConnection.Query<FormularioResponses>("Control.SP_ADMINISTRAR_FORMULARIOS", new
            {
                ID = form.ID,
                ID_SEDE = form.ID_SEDE,
                ID_USUARIO = form.ID_USUARIO,
                TIPO = form.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public TResponses MantenimientoFormulario(FormularioRequest form)
        {
            var Consulta = DbConnection.Query<TResponses>("Control.SP_ADMINISTRAR_FORMULARIOS", new
            {
                ID = form.ID,
                ID_SOURCE = form.ID_SOURCE,
                TITULO = form.TITULO,
                CAMPO_1 = form.CAMPO_1,
                CAMPO_2 = form.CAMPO_2,
                CAMPO_3 = form.CAMPO_3,

                ID_GRUPO = form.ID_GRUPO,
                ID_SEDE = form.ID_SEDE,
                ID_USUARIO = form.ID_USUARIO,
                TIPO = form.TIPO,
            }, commandType: CommandType.StoredProcedure).First();
            return Consulta;
        }

        public TResponses MantenimientoFormularioCRM(TRequest form)
        {

            var Consulta = DbConnection.Query<TResponses>("Control.SP_ADMINISTRAR_FORMULARIOS", new
            {
                ID = form.ID,
                ID_SOURCE = form.ID_SOURCE,
                TITULO = form.CONTENIDO,
                CAMPO_1 = form.CAMPO,
                ID_GRUPO = form.ID_GRUPO,
                ID_SEDE = form.ID_SEDE,
                ID_USUARIO = form.ID_USUARIO,
                TIPO = form.TIPO,
            }, commandType: CommandType.StoredProcedure).First();
            return Consulta;
        }

        public List<ControlResponses> ListarPreguntasxFormulario(TRequest form)
        {
            var Consulta = DbConnection.Query<ControlResponses>("Control.SP_ADMINISTRAR_FORMULARIOS", new
            {
                ID = form.ID,
                ID_SEDE = form.ID_SEDE,
                ID_USUARIO = form.ID_USUARIO,
                TIPO = form.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public TResponses MantenimientoPregunta(FormularioRequest form)
        {
            var Consulta = DbConnection.Query<TResponses>("Control.SP_ADMINISTRAR_FORMULARIOS", new
            {
                ID = form.ID,
                TITULO = form.TITULO,
                CAMPO_1 = form.CAMPO_1,
                CAMPO_2 = form.CAMPO_2,
                CAMPO_3 = form.CAMPO_3,

                ID_SEDE = form.ID_SEDE,
                ID_USUARIO = form.ID_USUARIO,
                TIPO = form.TIPO,
            }, commandType: CommandType.StoredProcedure).First();
            return Consulta;
        }

        public List<ItemsResponses> ListarRespuestasxPregunta(TRequest form)
        {
            var Consulta = DbConnection.Query<ItemsResponses>("Control.SP_ADMINISTRAR_FORMULARIOS", new
            {
                ID = form.ID,
                ID_SEDE = form.ID_SEDE,
                ID_USUARIO = form.ID_USUARIO,
                TIPO = form.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public TResponses MantenimientoRespuesta(FormularioRequest form)
        {
            var Consulta = DbConnection.Query<TResponses>("Control.SP_ADMINISTRAR_FORMULARIOS", new
            {
                ID = form.ID,
                ID_GRUPO = form.ID_GRUPO,
                TITULO = form.TITULO,
                CAMPO_1 = form.CAMPO_1,
                CAMPO_2 = form.CAMPO_2,
                CAMPO_3 = form.CAMPO_3,

                ID_SEDE = form.ID_SEDE,
                ID_USUARIO = form.ID_USUARIO,
                TIPO = form.TIPO,
            }, commandType: CommandType.StoredProcedure).First();
            return Consulta;
        }

        public List<FormularioGrupoResponses> ListarFormulariosxGrupo(TRequest form)
        {
            var Consulta = DbConnection.Query<FormularioGrupoResponses>("Control.SP_ADMINISTRAR_FORMULARIOS", new
            {
                ID = form.ID,
                ID_GRUPO = form.ID_GRUPO,
                ID_SEDE = form.ID_SEDE,
                ID_USUARIO = form.ID_USUARIO,
                TIPO = form.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public List<FormularioResponses> ListarFormulariosGrupoxUsuario(TRequest form)
        {
            var Consulta = DbConnection.Query<FormularioResponses>("Control.SP_ADMINISTRAR_FORMULARIOS", new
            {
                ID = form.ID,
                ID_GRUPO = form.ID_GRUPO,
                ID_SEDE = form.ID_SEDE,
                ID_USUARIO = form.ID_USUARIO,
                TIPO = form.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public List<PreguntasResponses> ListarPreguntasxExamen(TRequest form)
        {
            var Consulta = DbConnection.Query<PreguntasResponses>("Control.SP_ADMINISTRAR_FORMULARIOS", new
            {
                ID = form.ID,
                //ID_GRUPO = form.ID_GRUPO,
                ID_SEDE = form.ID_SEDE,
                ID_USUARIO = form.ID_USUARIO,
                TIPO = form.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public List<ItemsResponses> ListarUsuariosxInicioFormulario(TRequest form)
        {
            var Consulta = DbConnection.Query<ItemsResponses>("Control.SP_ADMINISTRAR_FORMULARIOS", new
            {
                ID = form.ID,
                ID_GRUPO = form.ID_GRUPO,
                ID_SEDE = form.ID_SEDE,
                ID_USUARIO = form.ID_USUARIO,
                TIPO = form.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public List<TResponses> ListarPlantilla(TRequest form)
        {
            var Consulta = DbConnection.Query<TResponses>("Control.SP_ADMINISTRAR_FORMULARIOS", new
            {
                ID = form.ID,
                ID_SOURCE = form.ID_SOURCE,
                ID_GRUPO = form.ID_GRUPO,
                ID_SEDE = form.ID_SEDE,
                ID_USUARIO = form.ID_USUARIO,
                TIPO = form.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }
        //////////////////////////////////////////////////////////////
        ///
        public TResponses Mantenimiento(FormularioRequest form)
        {
            var Consulta = DbConnection.Query<TResponses>("Control.SP_ADMINISTRAR_FORMULARIOS_II", new
            {
                ID = form.ID,
                ID_SOURCE = form.ID_SOURCE,
                TITULO = form.TITULO,
                CAMPO_1 = form.CAMPO_1,
                CAMPO_2 = form.CAMPO_2,
                CAMPO_3 = form.CAMPO_3,
                CAMPO_4 = form.CAMPO_4,
                CAMPO_5 = form.CAMPO_5,

                ID_GRUPO = form.ID_GRUPO,
                ID_SEDE = form.ID_SEDE,
                ID_USUARIO = form.ID_USUARIO,
                TIPO = form.TIPO,
            }, commandType: CommandType.StoredProcedure).First();
            return Consulta;
        }

        public List<TResponses> Listar(TRequest form)
        {
            var Consulta = DbConnection.Query<TResponses>("Control.SP_ADMINISTRAR_FORMULARIOS_II", new
            {
                ID = form.ID,
                ID_SOURCE = form.ID_SOURCE,
                TITULO = form.TITULO,
                ID_SEDE = form.ID_SEDE,
                ID_GRUPO = form.ID_GRUPO,
                ID_USUARIO = form.ID_USUARIO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public List<ComunicadoResponses> ListarGaleriaxCarga(TRequest carga)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: carga.ID, direction: ParameterDirection.Input);
            param.Add("P_ID_USUARIO", value: carga.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add("P_ID_SEDE", value: carga.ID_SEDE, direction: ParameterDirection.Input);
            param.Add("P_USUARIO", value: carga.TITULO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            List<ComunicadoResponses> myRefcurs = DbConnection.Query<ComunicadoResponses>("CHSP.PK_PP_ADMINISTRADOR.SP_LIS_ARCHIVOSxCARGA",
                param: param, commandType: CommandType.StoredProcedure).ToList();
            return myRefcurs;
        }

        public TResponses MantenimientoQUEUE(TRequest form)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: form.ID, direction: ParameterDirection.Input);
            param.Add("P_ID_SOURCE", value: form.ID_SOURCE, direction: ParameterDirection.Input);
            param.Add("P_TITULO", value: form.TITULO, direction: ParameterDirection.Input);
            param.Add("P_ID_SEDE", value: form.ID_SEDE, direction: ParameterDirection.Input);
            param.Add("P_ID_GRUPO", value: form.ID_GRUPO, direction: ParameterDirection.Input);
            param.Add("P_ID_USUARIO", value: form.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add("P_STATUS", value: form.TIPO, direction: ParameterDirection.Input);
            param.Add("P_MENSAJE", value: form.CAMPO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            TResponses myRefcurs = DbConnection.Query<TResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_ADM_QUEUExGRUPO",
                param: param, commandType: CommandType.StoredProcedure).First();
            return myRefcurs;
        }

        public TResponses MantenimientoGaleria(TRequest carga)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: carga.ID, direction: ParameterDirection.Input);
            param.Add("P_ID_USUARIO", value: carga.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add("P_STATUS", value: carga.TIPO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            TResponses myRefcurs = DbConnection.Query<TResponses>("CHSP.PK_PP_ADMINISTRADOR.SP_ELI_ARCHIVOSxCARGA",
                param: param, commandType: CommandType.StoredProcedure).First();
            return myRefcurs;
        }

    }
}
