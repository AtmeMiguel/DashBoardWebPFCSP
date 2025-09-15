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
    public class DExcelCargaHandlers : IExcelCargaHandler
    {
        private readonly IDbConnection DbCon;
        Conexiones con = new Conexiones();
        public DExcelCargaHandlers()
        {
            DbCon = con.ConstruirConexion();
        }

        public List<TResponses> ListarCargasxPrograma(TRequest excel)
        {
            var Consulta = DbCon.Query<TResponses>("Cargas.SP_ADMINISTRAR_CARGA", new
            {
                ID = excel.ID,
                ID_GRUPO = excel.ID_GRUPO,
                ID_USUARIO = excel.ID_USUARIO,
                ID_SEDE = excel.ID_SEDE,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public TResponses MantenimientoCarga(TRequest excel)
        {
            TResponses Consulta = DbCon.Query<TResponses>("Cargas.SP_ADMINISTRAR_CARGA", new
            {
                ID = excel.ID,
                TITULO = excel.CAMPO,
                CANTIDAD = excel.CONTENIDO,

                ID_GRUPO = excel.ID_GRUPO,
                ID_USUARIO = excel.ID_USUARIO,
                ID_SEDE = excel.ID_SEDE,
                TIPO = excel.TIPO,
            }, commandType: CommandType.StoredProcedure).First();
            return Consulta;
        }


    }
}
