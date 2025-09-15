using appCalidad.Infraestructura.Datos.Connection;
using appCalidad.Service.Implementacion.Handlers;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using com.sun.net.httpserver;
using Dapper;
using Dapper.Oracle;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace appCalidad.Infraestructura.Datos.Repository
{
    public class DDocPagoHandlers : IDocPagoHandler
    {

        //private readonly IDbConnection DbConnectionSede;
        Conexiones con = new Conexiones();
        public DDocPagoHandlers(int idsede = 0)
        {
            //DbConnectionSede = con.ConstruirConexionSede(idsede);
        }
        CorreoElectronico oEmail = new CorreoElectronico(false);

        public List<DocPagoResponses> ListarDocPagoxPrograma(DocPagoRequest docpago)
        {

           
            var DbConnectionSede = con.ConstruirConexionSede(docpago.ID_SEDE);
            /* (P_TIPO in varchar,P_ESTADO in varchar,P_FEC_INI in varchar,P_FEC_FIN in varchar,P_SNROFAC  in varchar,P_DNROFAC in varchaR,P_RETORNO out sys_refcursor);*/
           string varPaquete= ConfigurationManager.AppSettings["pkg_" + docpago.ID_SEDE].ToString();
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_TIPO", value: docpago.TIPO, direction: ParameterDirection.Input);
            param.Add("P_ESTADO", value: docpago.FLG_EST_DOC, direction: ParameterDirection.Input);
            param.Add("P_FEC_INI", value: docpago.FEC_INI, direction: ParameterDirection.Input);
            param.Add("P_FEC_FIN", value: docpago.FEC_FIN, direction: ParameterDirection.Input);
            param.Add("P_SNROFAC", value: docpago.SNROFAC, direction: ParameterDirection.Input);
            param.Add("P_DNROFAC", value: docpago.DNROFAC, direction: ParameterDirection.Input);
            param.Add("P_DRESP_CAB", value: docpago.DRESP_CAB, direction: ParameterDirection.Input);
            param.Add("P_FEC_ESTADO_INI", value: docpago.FEC_ESTADO_INI, direction: ParameterDirection.Input);
            param.Add("P_FEC_ESTADO_FIN", value: docpago.FEC_ESTADO_FIN, direction: ParameterDirection.Input);
            param.Add("P_FLG_FOR_PAG", value: docpago.FLG_FOR_PAG, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            /*var Consulta = DbConnectionSede.Query<DocPagoResponses>("CHSP.PK_DS_AUTORIZACION_NOTACREDITO.SP_LISTAR_DOC_PAG",
                 param: param, commandType: CommandType.StoredProcedure).ToList();*/
            var Consulta = DbConnectionSede.Query<DocPagoResponses>(varPaquete + "SP_LISTAR_DOC_PAG",
            param: param, commandType: CommandType.StoredProcedure).ToList();

            return Consulta;


        }

        public DocPagoResponses AdministrarDocPago(DocPagoRequest docpago)
        {
            var DbConnectionSede = con.ConstruirConexionSede(docpago.ID_SEDE);
            string varPaquete = ConfigurationManager.AppSettings["pkg_" + docpago.ID_SEDE].ToString();
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_TIPO", value: docpago.TIPO, direction: ParameterDirection.Input);
            param.Add("P_ESTADO", value: docpago.FLG_EST_DOC, direction: ParameterDirection.Input);
            param.Add("P_AUTO_POR", value: docpago.AUTO_POR, direction: ParameterDirection.Input);
            param.Add("P_COD_OBS", value: docpago.COD_OBS, direction: ParameterDirection.Input);
            param.Add("P_SNROFAC", value: docpago.SNROFAC, direction: ParameterDirection.Input);
            param.Add("P_DNROFAC", value: docpago.DNROFAC, direction: ParameterDirection.Input);
            param.Add("P_DNROLOTE", value: docpago.DNROLOTE, direction: ParameterDirection.Input);
            param.Add("P_NOMBRE_USUARIO", value: docpago.NOMBRE_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            /*var Consulta = DbConnectionSede.Query<DocPagoResponses>("CHSP.PK_DS_AUTORIZACION_NOTACREDITO.SP_ACTUALIZAR_DOC_PAG",
                param: param, commandType: CommandType.StoredProcedure).First();*/

            var Consulta = DbConnectionSede.Query<DocPagoResponses>(varPaquete + "SP_ACTUALIZAR_DOC_PAG",
             param: param, commandType: CommandType.StoredProcedure).First();

            string msgCorreo = oEmail.EnviarCorreoAprobacionRechazo(docpago);
            Consulta.ERROR = msgCorreo;

            return Consulta;
        }

    }
}