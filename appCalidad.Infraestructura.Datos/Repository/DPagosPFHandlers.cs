
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
using System.Security.Cryptography;

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


        public MensajePFResponse EnviarMensajePagoPF(MensajePFRequest user)
        {
            MensajePFResponse myRefcurs = new MensajePFResponse();
            try
            {

               
                OracleDynamicParameters param = new OracleDynamicParameters();
                param.Add("pdoc_afi", value: user.DOCUMENTO.ToLower(), direction: ParameterDirection.Input);
                param.Add("pnombres", value: user.NOMBRES, direction: ParameterDirection.Input);
                param.Add("papellidos", value: user.APELLIDOS, direction: ParameterDirection.Input);
                param.Add("pemail", value: user.CORREO, direction: ParameterDirection.Input);
                param.Add("ptcel", value: user.CELULAR, direction: ParameterDirection.Input);
                param.Add("pmensaje", value: user.MENSAJE, direction: ParameterDirection.Input);
                param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var myRefcursBase = DbConnection.Query<MensajePFResponse>("chsp.PK_DS_PAGOS_PF.INSERTAR_MENSAJE_AFILIADO",
                    param: param, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    myRefcurs.MSG = myRefcursBase.MSG == null ? "" : myRefcursBase.MSG;
                    myRefcurs.DOCUMENTO = myRefcursBase.DOCUMENTO == null ? "" : myRefcursBase.DOCUMENTO.ToLower();


                //mensaje registrado
                if (myRefcurs.MSG == "OK")
                {

                    if (user.DOCUMENTO != null && user.CORREO != null && user.NOMBRES != null && user.MENSAJE != null)
                    {
                        System.Collections.Specialized.NameValueCollection nvc = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("groupSanPablo/sectionEmail");
                        string destinatario = nvc["PFMail"];
                        AutorizacionPFResponse obj = new AutorizacionPFResponse();
                        obj.LLAVE_ORIGEN = user.DOCUMENTO;
                        obj.NOMBRES = user.NOMBRES;
                        obj.APELLIDOS = user.APELLIDOS;
                        obj.DESTINATARIO = destinatario;
                        obj.CELULAR = user.CELULAR;
                        obj.MSG = user.MENSAJE;
                        obj.CORREO = user.CORREO;

                        string msgCorreo = oEmail.EnviarCorreoAutorizacion(obj, "contactanos");


                    }
                }

            }
            catch (Exception ex)
            {
                myRefcurs.MSG = ex.Message;
            }

            return myRefcurs;
        }




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


        public List<PagoPFResponse> InsertarCuotasFormaPagoPF(PagoPFRequest autObj)
        {
            List<PagoPFResponse> Consulta = new List<PagoPFResponse>();
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("psec_emisionpf", value: autObj.EMISION, direction: ParameterDirection.Input);
            param.Add("pnum_emicuotapf", value: autObj.N_CUOTA, direction: ParameterDirection.Input);
            param.Add("psec_contratopf", value: autObj.SEC_CONTRATO, direction: ParameterDirection.Input);
            param.Add("pnum_contrato", value: autObj.CONTRATO, direction: ParameterDirection.Input);
            param.Add("pdocu_afi", value: autObj.DOCUMENTO.ToLower(), direction: ParameterDirection.Input);
            param.Add("pmonto", value: Convert.ToDecimal(autObj.MONTO), direction: ParameterDirection.Input);
            param.Add("pestado_transac", value: autObj.ESTADO, direction: ParameterDirection.Input);
            param.Add("pcodigo_operacion", value: autObj.SECUENCIA, direction: ParameterDirection.Input);
            param.Add("pformapag", value: autObj.FORMA_PAG, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            //  Consulta = DbConnection.Query<PagoPFResponse>("CHSP.PK_DS_PAGOS_PF.INSERTAR_TRANSACCION_CUOTA_V2",
            Consulta = DbConnection.Query<PagoPFResponse>("CHSP.PK_DS_PAGOS_PF.INSERTAR_TRANSACCION_CUOTA_V3",
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

       
        public Dictionary<string, string> GenerarAutenticacionSynapsisPfV2(string transaction,string apikey,string secretkey )
        {
            // Parámetros de la API
            var x_apikey = apikey;
            var x_secretkey = secretkey;

            // Generar el timestamp (fecha actual en formato ISO)
            var timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
          
            // Crear el payload con el cuerpo de la transacción y el timestamp
            var payload = new
            {
                timestamp = timestamp,
                body = transaction
            };

            // Serializar el payload a JSON
            var payloadStr = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

            // Generar la firma HMAC-SHA512
            var signature = GenerateHMACSHA512(payloadStr, secretkey);

            // Crear el objeto de autenticación con los headers necesarios
            var authenticator = new Dictionary<string, string>
        {
            { "apikey", apikey },
            { "signature", signature },
            { "timestamp", timestamp }
        };
           
            return authenticator;
        }



        // Método para generar la firma HMAC-SHA512
        public static string GenerateHMACSHA512(string payloadStr, string secretkey)
        {
            // Convertir la clave secreta y el payload a bytes
            byte[] keyBytes = Encoding.UTF8.GetBytes(secretkey);
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payloadStr);

            // Crear un objeto HMACSHA512 con la clave secreta
            using (HMACSHA512 hmacsha512 = new HMACSHA512(keyBytes))
            {
                // Calcular la firma
                byte[] hashBytes = hmacsha512.ComputeHash(payloadBytes);

                // Convertir el array de bytes en una cadena hexadecimal
                return ToHexString(hashBytes);
            }
        }

        // Método para convertir un array de bytes en una cadena hexadecimal
        private static string ToHexString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }



        public List<SynapsisResponse> GenerarAutenticacionSynapsisPf(SynapsisRequest opc)
        {
            List<SynapsisResponse> authenticator = new List<SynapsisResponse>();

            string APIKEY = opc.APIKEY;
            string SIGNATUREKEY = opc.SECRET;

            var SIGNATURE = generateSignature(opc.COD_PETITORIO, opc.COD_CURRENCY, opc.PURCHASEAMOUNT, APIKEY, SIGNATUREKEY);

            SynapsisResponse objaut = new SynapsisResponse();
            objaut.identifier = APIKEY;
            objaut.signature = SIGNATURE;
            authenticator.Add(objaut);

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
