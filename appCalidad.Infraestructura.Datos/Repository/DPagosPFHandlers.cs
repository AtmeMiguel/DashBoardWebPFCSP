
using appCalidad.Infraestructura.Datos.Connection;
using appCalidad.Service.Implementacion;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using appCalidad.Service.Implementacion.Handlers;
using Dapper;
using Dapper.Oracle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Web;

namespace appCalidad.Infraestructura.Datos.Repository
{
    public class DPagosPFHandlers : IPagosPFHandler
    {
        private readonly IDbConnection DbConnection;
        Conexiones con = new Conexiones();
        public DPagosPFHandlers()
        {
            DbConnection = con.ConstruirConexion();
        }

        CorreoElectronico oEmail = new CorreoElectronico(false);


        public List<PagoPFResponse> ListarContratosPagoPF(PagoPFRequest autObj)
        {
            List<PagoPFResponse> Consulta = new List<PagoPFResponse>();
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_NUMERO", value: autObj.DOCUMENTO.ToLower(), direction: ParameterDirection.Input);
            param.Add(name: "OUT_CURSOR", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            Consulta = DbConnection.Query<PagoPFResponse>("CHSP.pf_proyectocobranza.SPContratosAfiliado",
             param: param, commandType: CommandType.StoredProcedure).ToList();

            return Consulta;
        }

        public List<PagoPFResponse> ListarCuotasPagoPF(PagoPFRequest autObj)
        {
            List<PagoPFResponse> Consulta = new List<PagoPFResponse>();
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_CONTRATO", value: autObj.CONTRATO.ToLower(), direction: ParameterDirection.Input);
            param.Add(name: "OUT_CURSOR", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            Consulta = DbConnection.Query<PagoPFResponse>("CHSP.pf_proyectocobranza.SPCuotasPendientes",
             param: param, commandType: CommandType.StoredProcedure).ToList();

            return Consulta;
        }

   
    }
}
