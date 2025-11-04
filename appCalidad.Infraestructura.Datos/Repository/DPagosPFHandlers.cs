
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

        public List<PagoPFResponse> ListarCuotasPendientesPF(PagoPFRequest autObj)
        {
            List<PagoPFResponse> Consulta = new List<PagoPFResponse>();
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_CONTRATO", value: autObj.CONTRATO.ToLower(), direction: ParameterDirection.Input);
            param.Add(name: "OUT_CURSOR", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            Consulta = DbConnection.Query<PagoPFResponse>("CHSP.pf_proyectocobranza.SPCuotasPendientes",
             param: param, commandType: CommandType.StoredProcedure).ToList();

            return Consulta;
        }


        public List<PagoPFResponse> ListarCuotasPagadasPF(PagoPFRequest autObj)
        {
            List<PagoPFResponse> Consulta = new List<PagoPFResponse>();
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_CONTRATO", value: autObj.CONTRATO.ToLower(), direction: ParameterDirection.Input);
            param.Add(name: "OUT_CURSOR", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            Consulta = DbConnection.Query<PagoPFResponse>("CHSP.pf_proyectocobranza.SPReportePagosxContrato",
             param: param, commandType: CommandType.StoredProcedure).ToList();

            return Consulta;
        }


        public List<PagoPFResponse> ListarCuotasPendientesGeneralPF(PagoPFRequest autObj)
        {
            List<PagoPFResponse> Consulta = new List<PagoPFResponse>();
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_NUMERO", value: autObj.DOCUMENTO.ToLower(), direction: ParameterDirection.Input);
            param.Add(name: "OUT_CURSOR", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            Consulta = DbConnection.Query<PagoPFResponse>("CHSP.pf_proyectocobranza.SPCuotasPendientesGeneral",
             param: param, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public List<PagoPFResponse> ListarCuotasPagadasGeneralPF(PagoPFRequest autObj)
        {
            List<PagoPFResponse> Consulta = new List<PagoPFResponse>();
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_NUMERO", value: autObj.DOCUMENTO.ToLower(), direction: ParameterDirection.Input);
            param.Add(name: "OUT_CURSOR", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            Consulta = DbConnection.Query<PagoPFResponse>("CHSP.pf_proyectocobranza.SPReportePagosGeneral",
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
            param.Add("psec_contratopf", value: autObj.SEC_CONTRATO, direction: ParameterDirection.Input);
            param.Add("pnum_contrato", value: autObj.CONTRATO, direction: ParameterDirection.Input);
            param.Add("pdocu_afi", value: autObj.DOCUMENTO.ToLower(), direction: ParameterDirection.Input);
            param.Add("pmonto", value: Convert.ToDecimal(autObj.MONTO), direction: ParameterDirection.Input);
           // param.Add("pmonto", value: Convert.ToDecimal("698.89"), direction: ParameterDirection.Input);
            param.Add("pestado_transac", value: autObj.ESTADO, direction: ParameterDirection.Input);
            param.Add("pcodigo_operacion", value: autObj.SECUENCIA, direction: ParameterDirection.Input);

            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            Consulta = DbConnection.Query<PagoPFResponse>("CHSP.PK_DS_PAGOS_PF.INSERTAR_TRANSACCION_CUOTA",
             param: param, commandType: CommandType.StoredProcedure).ToList();

            return Consulta;
        }

        public PagoPFResponse obtenerMontoCotizacion(PagoPFRequest items)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_CODIGO_OPERACION", value: items.SECUENCIA, direction: ParameterDirection.Input);
            param.Add("P_NUM_CONTRATO", value: items.CONTRATO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            PagoPFResponse myRefcurs = DbConnection.Query<PagoPFResponse>("CHSP.PK_DS_PAGOS_PF.RETORNA_MONTO_CUO",
                param: param, commandType: CommandType.StoredProcedure).First();

            myRefcurs.MONTO = Convert.ToString(Convert.ToDecimal(myRefcurs.MONTO) / 100);

            return myRefcurs;


        }




        public List<SynapsisResponse> GenerarAutenticacionSynapsisPf(SynapsisRequest opc)
        {
            List<SynapsisResponse> authenticator = new List<SynapsisResponse>();


            // string APIKEY = ConfigurationManager.AppSettings["APIKEY_" + opc.COD_EMPRESA];
            // string SIGNATUREKEY = ConfigurationManager.AppSettings["SECRET_" + opc.COD_EMPRESA];

            string APIKEY = opc.APIKEY;
            string SIGNATUREKEY = opc.SECRET;
            //string APIKEY = System.Configuration.ConfigurationManager.AppSettings["APIKEY_" + opc.COD_EMPRESA];


            //var APIKEY = Configuration["APIKEY_" + opc.COD_EMPRESA];
            //var SIGNATUREKEY = Configuration["SECRET_" + opc.COD_EMPRESA];

            var SIGNATURE = generateSignature(opc.COD_PETITORIO, opc.COD_CURRENCY, opc.PURCHASEAMOUNT, APIKEY, SIGNATUREKEY);

            SynapsisResponse objaut = new SynapsisResponse();
            objaut.identifier = APIKEY;
            objaut.signature = SIGNATURE;
            authenticator.Add(objaut);


            //  return JsonConvert.SerializeObject(authenticator);
            return authenticator;
        }


        public static string generateSignature(string COD_PETITORIO, string COD_CURRENCY, string PURCHASEAMOUNT, string APIKEY, string SIGNATUREKEY)
        {
            string orderNumber = COD_PETITORIO;//transaction.order.number;
            string currencyCode = COD_CURRENCY;//transaction.order.currency.code;
            string amount = PURCHASEAMOUNT;//transaction.order.amount;

            var rawSignature = APIKEY + orderNumber + currencyCode + amount + SIGNATUREKEY;

            return _SHA512(rawSignature);
        }

        public static string _SHA512(string input)
        {
            var bInput = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var bSign = hash.ComputeHash(bInput);

                var hexStrSign = new System.Text.StringBuilder(128);

                foreach (var byteOfSign in bSign)
                    hexStrSign.Append(byteOfSign.ToString("X2"));
                return hexStrSign.ToString();
            }
        }




    }
}
