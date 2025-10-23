
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

        public List<PagoPFResponse> InsertarCuotasPagoPF(PagoPFRequest autObj)
        {
            /*
        psec_emisionpf      IN                  VARCHAR2,
        pnum_emicuotapf     IN                  VARCHAR2,
        psec_contratopf     IN                  VARCHAR2,
        pnum_contrato       IN                  VARCHAR2,
        pdocu_afi           IN                  VARCHAR2,
        pmonto              IN                  NUMBER,
        pestado_transac     IN                  VARCHAR2,
        pcodigo_operacion   IN                  VARCHAR2,
        P_RETORNO OUT cur_cursor
             
             */

            List<PagoPFResponse> Consulta = new List<PagoPFResponse>();
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("psec_emisionpf", value: autObj.EMISION, direction: ParameterDirection.Input);
            param.Add("pnum_emicuotapf", value: autObj.N_CUOTA, direction: ParameterDirection.Input);
            param.Add("psec_contratopf", value: autObj.CONTRATO, direction: ParameterDirection.Input);
            param.Add("pnum_contrato", value: autObj.SEC_CONTRATO, direction: ParameterDirection.Input);
            param.Add("pdocu_afi", value: autObj.DOCUMENTO.ToLower(), direction: ParameterDirection.Input);
            param.Add("pmonto", value: Convert.ToDouble(autObj.MONTO), direction: ParameterDirection.Input);
            param.Add("pestado_transac", value: autObj.ESTADO, direction: ParameterDirection.Input);
            param.Add("pcodigo_operacion", value: autObj.SECUENCIA, direction: ParameterDirection.Input);

            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            Consulta = DbConnection.Query<PagoPFResponse>("CHSP.PK_DS_PAGOS_PF.INSERTAR_TRANSACCION_CUOTA",
             param: param, commandType: CommandType.StoredProcedure).ToList();

            return Consulta;
        }



    }
}
