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
    public class DComunicadoHandlers : IComunicadoHandler
    {
        private readonly IDbConnection DbConnection;
        Conexiones con = new Conexiones();
        public DComunicadoHandlers()
        {
            DbConnection = con.ConstruirConexion();
        }

        public TResponses AdministrarComunicado(ComunicadoRequest comunicado)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: comunicado.ID, direction: ParameterDirection.Input);
            param.Add("P_TITULO", value: comunicado.TITULO, direction: ParameterDirection.Input);
            param.Add("P_CONTENIDO", value: comunicado.CONTENIDO, direction: ParameterDirection.Input);
            param.Add("P_CONFIRMAR", value: comunicado.CONFIRMAR, direction: ParameterDirection.Input);
            param.Add("P_ID_USUARIO", value: comunicado.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            var Consulta = DbConnection.Query<TResponses>("CHSP.PK_DS_BUILDER.DASH_ADM_COMUNICADO_CUERPO",
                param: param, commandType: CommandType.StoredProcedure).First();
            return Consulta;

            /*
            var Consulta = DbConnection.Query<TResponses>("Seguridad.DASH_ADM_COMUNICADO_IMAGEN", new
            {
                ID = comunicado.ID,
                TITULO    = comunicado.TITULO,
                CONTENIDO = comunicado.CONTENIDO,
                FORMADOR = comunicado.FORMADOR,
                BANNER = comunicado.BANNER,
                EXT = comunicado.EXT,
                PRIORIDAD = comunicado.PRIORIDAD,
                CONFIRMAR = comunicado.CONFIRMAR,

                ID_USUARIO = comunicado.ID_USUARIO,
                ID_GRUPO = comunicado.ID_GRUPO,
                ID_SEDE = comunicado.ID_SEDE,
                TIPO = comunicado.TIPO,
            }, commandType: CommandType.StoredProcedure).First();
            return Consulta;
            */

        }

        public List<ComunicadoResponses> ListarComunicadosxPrograma(TRequest comunicado)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            var Consulta = DbConnection.Query<ComunicadoResponses>("CHSP.PK_DS_BUILDER.SEG_LISTAR_COMUNICADOS",
                param: param, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;

            /*var Consulta = DbConnection.Query<ComunicadoResponses>("SEG_LISTAR_COMUNICADOS", new
            {
                ID = comunicado.ID,

                ID_USUARIO = comunicado.ID_USUARIO,
                ID_SEDE = comunicado.ID_SEDE,
                TIPO = comunicado.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
            */
        }

        public List<ComunicadoResponses> ListarComunicadoxGrupo(TRequest comunicado)
        {
            var Consulta = DbConnection.Query<ComunicadoResponses>("Seguridad.SP_ADMINISTRAR_COMUNICADOS", new
            {
                ID = comunicado.ID,

                ID_USUARIO = comunicado.ID_USUARIO,
                ID_GRUPO = comunicado.ID_GRUPO,
                ID_SEDE = comunicado.ID_SEDE,
                TIPO = comunicado.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public TResponses MantenimientoComunicado(ComunicadoRequest comunicado)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: comunicado.ID, direction: ParameterDirection.Input);
            param.Add("P_TITULO", value: comunicado.BANNER, direction: ParameterDirection.Input);
            param.Add("P_EXT", value: comunicado.EXT, direction: ParameterDirection.Input);
            param.Add("P_ID_USUARIO", value: comunicado.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            var Consulta = DbConnection.Query<TResponses>("CHSP.PK_DS_BUILDER.DASH_ADM_COMUNICADO_IMAGEN",
                param: param, commandType: CommandType.StoredProcedure).First();
            return Consulta;
        }

        public TResponses EliminarComunicado(ComunicadoRequest comunicado)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: comunicado.ID, direction: ParameterDirection.Input);
            param.Add("P_ID_USUARIO", value: comunicado.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            var Consulta = DbConnection.Query<TResponses>("CHSP.PK_DS_BUILDER.DASH_ADM_COMUNICADO_ELIMINAR",
                param: param, commandType: CommandType.StoredProcedure).First();
            return Consulta;
        }

        
        
    }
}
