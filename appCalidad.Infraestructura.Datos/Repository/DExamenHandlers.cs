using appCalidad.Infraestructura.Datos.Connection;
using appCalidad.Service.Implementacion.Handlers;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Infraestructura.Datos.Repository
{
    public class DExamenHandlers : IExamenHandler
    {
        private readonly IDbConnection DbConnection;
        Conexiones con = new Conexiones();

        public DExamenHandlers()
        {
            DbConnection = con.ConstruirConexion();
        }

        public List<ExamenResponses> ListarExamenesxGrupo(ExamenRequest examen)
        {
            var Consulta = DbConnection.Query<ExamenResponses>("Control.SP_ADMINISTRAR_FORMULARIOS", new
            {
                ID = examen.ID,

                TITULO = examen.TITULO,
                FECHA = "",

                ID_USUARIO = examen.ID_USUARIO,
                ID_SEDE = examen.ID,
                TIPO = examen.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public List<PreguntasResponses> ListarPreguntasxExamen(ExamenRequest examen)
        {
            var Consulta = DbConnection.Query<PreguntasResponses>("Control.SP_ADMINISTRAR_FORMULARIOS", new
            {
                ID = examen.ID,
                USUARIO = examen.ID_USUARIO,
                TIPO = examen.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public List<ExamenNotasResponses> ListarExamenNotas(TRequest examen)
        {
            var Consulta = DbConnection.Query<ExamenNotasResponses>("Control.SP_ADMINISTRAR_FORMULARIOS", new
            {
                ID_USUARIO = examen.ID_USUARIO,
                TIPO = examen.TIPO
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }
    }
}
