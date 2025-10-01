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
    public class DUsuarioHandlers : IUsuarioHandler
    {
        private readonly IDbConnection DbConnection;
        Conexiones con = new Conexiones();
        public DUsuarioHandlers()
        {
            DbConnection = con.ConstruirConexion();
        }

        CorreoElectronico oEmail = new CorreoElectronico(false);

        public AutorizacionPFResponse GenerarEnlacePagPF(AutorizacionPFRequest autObj)
        {
            AutorizacionPFResponse Consulta = new AutorizacionPFResponse();
              OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_LLAVE_ORIGEN", value: autObj.LLAVE_ORIGEN, direction: ParameterDirection.Input);
            param.Add("P_TIPO_AUT", value: autObj.TIPO_AUT, direction: ParameterDirection.Input);
            param.Add("P_TIPO_ENV", value: autObj.TIPO_ENV, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            /*var Consulta = DbConnectionSede.Query<DocPagoResponses>("CHSP.PK_DS_AUTORIZACION_NOTACREDITO.SP_ACTUALIZAR_DOC_PAG",
                param: param, commandType: CommandType.StoredProcedure).First();*/

            Consulta = DbConnection.Query<AutorizacionPFResponse>("CHSP.PK_DS_PAGOS_PF.GENERAR_CODIGO_AUT",
             param: param, commandType: CommandType.StoredProcedure).First();
          
            Consulta.MSG = Consulta.MSG == null ? "" : Consulta.MSG;
            Consulta.CODIGO_AUT = Consulta.CODIGO_AUT ==null? "" : Consulta.CODIGO_AUT;
            Consulta.LLAVE_ORIGEN = Consulta.LLAVE_ORIGEN == null ? "" : Consulta.LLAVE_ORIGEN;
            Consulta.DESTINATARIO = Consulta.DESTINATARIO == null ? "" : Consulta.DESTINATARIO;
            Consulta.DETALLE_ENVIO = Consulta.DETALLE_ENVIO == null ? "" : Consulta.DETALLE_ENVIO;
            Consulta.ID = Consulta.ID == null ? "" : Consulta.ID;
            if (Consulta.MSG =="OK")
            {
                Consulta.DETALLE_ENVIO = "";
                if (Consulta.LLAVE_ORIGEN != null && Consulta.DESTINATARIO != null && Consulta.CODIGO_AUT !=null && Consulta.ID !=null)
                {
                    if (Consulta.DESTINATARIO.ToLower() == "atmemiguel@gmail.com")
                    {
                        string msgCorreo = oEmail.EnviarCorreoAutorizacion(Consulta, "recuperar_cuenta");
                        Consulta.DETALLE_ENVIO = msgCorreo;

                        if (msgCorreo =="OK")
                        {
                            AutorizacionPFRequest objUpdateCodAut = new AutorizacionPFRequest();
                            objUpdateCodAut.ID = Consulta.ID;
                            objUpdateCodAut.ESTADO = "enviado";
                            objUpdateCodAut.LLAVE_ORIGEN =Consulta.LLAVE_ORIGEN;
                            objUpdateCodAut.TIPO_AUT = "recuperar_cuenta";
                            objUpdateCodAut.TIPO_ENV = "";
                            var rpta= updateCodAutPagosPF(objUpdateCodAut);

                        }

                    }

                }
            }

          
        

            return Consulta;
        }


        public AutorizacionPFResponse updateCodAutPagosPF(AutorizacionPFRequest autObj)
        {
            AutorizacionPFResponse Consulta = new AutorizacionPFResponse();
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: autObj.ID, direction: ParameterDirection.Input);
            param.Add("P_LLAVE_ORIGEN", value: autObj.LLAVE_ORIGEN, direction: ParameterDirection.Input);
            param.Add("P_TIPO_AUT", value: autObj.TIPO_AUT, direction: ParameterDirection.Input);
            param.Add("P_TIPO_ENV", value: autObj.TIPO_ENV, direction: ParameterDirection.Input);
            param.Add("P_ESTADO", value: autObj.ESTADO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            /*var Consulta = DbConnectionSede.Query<DocPagoResponses>("CHSP.PK_DS_AUTORIZACION_NOTACREDITO.SP_ACTUALIZAR_DOC_PAG",
                param: param, commandType: CommandType.StoredProcedure).First();*/

        Consulta = DbConnection.Query<AutorizacionPFResponse>("CHSP.PK_DS_PAGOS_PF.UPDATE_CODIGO_AUT",
             param: param, commandType: CommandType.StoredProcedure).First();

            Consulta.MSG = Consulta.MSG == null ? "" : Consulta.MSG;
            Consulta.CODIGO_AUT = Consulta.CODIGO_AUT == null ? "" : Consulta.CODIGO_AUT;
            Consulta.LLAVE_ORIGEN = Consulta.LLAVE_ORIGEN == null ? "" : Consulta.LLAVE_ORIGEN;
            Consulta.DESTINATARIO = Consulta.DESTINATARIO == null ? "" : Consulta.DESTINATARIO;
            Consulta.DETALLE_ENVIO = Consulta.DETALLE_ENVIO == null ? "" : Consulta.DETALLE_ENVIO;
            Consulta.ID = Consulta.ID == null ? "" : Consulta.ID;

            return Consulta;
        }



        public AccessResponses VerificarUsuarioPagosPF(AccessRequest user)
        {
           
            string clavencryptada = Encryptar.Encrypt.GetMD5(user.PASSWORD);
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_USUARIO", value: user.USUARIO, direction: ParameterDirection.Input);
            param.Add("P_PASSWORD", value: clavencryptada, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            AccessResponses myRefcurs = DbConnection.Query<AccessResponses>("CHSP.PK_DS_PAGOS_PF.VALIDAR_USUARIO",
                param: param, commandType: CommandType.StoredProcedure).First();
            return myRefcurs;
        }

        public AccessResponses VerificarUsuario(AccessRequest user)
        {
            string clavencryptada = Encryptar.Encrypt.GetSHA256(user.PASSWORD);
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_USUARIO", value: user.USUARIO, direction: ParameterDirection.Input);
            param.Add("P_PASSWORD", value: clavencryptada, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            AccessResponses myRefcurs = DbConnection.Query<AccessResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_VAL_USUARIOS",
                param: param, commandType: CommandType.StoredProcedure).First();
            return myRefcurs;
        }
        public List<RolResponses> ListarRolesxUsuario(AccessRequest user)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: user.ID, direction: ParameterDirection.Input);
            param.Add("P_USUARIO", value: user.USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            List<RolResponses> myRefcurs = DbConnection.Query<RolResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_LIS_ROLESxUSUARIO",
                param: param, commandType: CommandType.StoredProcedure).ToList();
            return myRefcurs;
        }

        public List<RolResponses> ListarModulosxRol(AccessRequest user)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: user.ID, direction: ParameterDirection.Input);
            param.Add("P_USUARIO", value: user.USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            List<RolResponses> myRefcurs = DbConnection.Query<RolResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_LIS_MODULOSxUSUARIO",
                param: param, commandType: CommandType.StoredProcedure).ToList();
            return myRefcurs;
        }

        public List<UsuarioResponses> ListarUsuarios(TRequest user)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: user.ID, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            var myRefcurs = DbConnection.Query<UsuarioResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_LIS_USUARIOS",
                param: param, commandType: CommandType.StoredProcedure).ToList();
            return myRefcurs;
        }

        public TResponses MantenimientoUsuario(UsuarioRequest user)
        {
            string clavencryptada = "";
            if (user.ID == 0)
            {
                clavencryptada = (user.PASSWORD.Length > 1 ? Encryptar.Encrypt.GetSHA256(user.PASSWORD) : Encryptar.Encrypt.GetSHA256(user.USUARIO));
            }
            else
            {
                clavencryptada = (user.PASSWORD.Length > 5 ? Encryptar.Encrypt.GetSHA256(user.PASSWORD) : "");
            }

            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: user.ID, direction: ParameterDirection.Input);
            param.Add("P_USUARIO", value: user.USUARIO, direction: ParameterDirection.Input);
            param.Add("P_PASSWORD", value: clavencryptada, direction: ParameterDirection.Input);
            param.Add("P_NOMBRES", value: user.NOMBRES, direction: ParameterDirection.Input);
            param.Add("P_APELLIDOS", value: user.APELLIDOS, direction: ParameterDirection.Input);
            param.Add("P_CORREO", value: user.CORREO, direction: ParameterDirection.Input);
            param.Add("P_ID_USUARIO", value: user.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            TResponses myRefcurs = DbConnection.Query<TResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_ADM_USUARIOS",
                param: param, commandType: CommandType.StoredProcedure).First();
            return myRefcurs;
        }

        public TResponses EliminarUsuario(UsuarioRequest user)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: user.ID, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            TResponses myRefcurs = DbConnection.Query<TResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_ELI_USUARIOS",
                param: param, commandType: CommandType.StoredProcedure).First();
            return myRefcurs;
        }

        public TResponses EliminarRolesxUsuario(TRequest rol)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: rol.ID, direction: ParameterDirection.Input);
            param.Add("P_ID_USUARIO", value: rol.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            TResponses myRefcurs = DbConnection.Query<TResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_ELI_ROLESxUSUARIO",
                param: param, commandType: CommandType.StoredProcedure).First();
            return myRefcurs;
        }

        public TResponses AgregarRolesxUsuario(TRequest rol)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: rol.ID, direction: ParameterDirection.Input);
            param.Add("P_ID_ROL", value: rol.ID_ROL, direction: ParameterDirection.Input);
            param.Add("P_ID_USUARIO", value: rol.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            TResponses myRefcurs = DbConnection.Query<TResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_ADD_ROLESxUSUARIO",
                param: param, commandType: CommandType.StoredProcedure).First();
            return myRefcurs;
        }

        //



        public List<ComunicadoResponses> ListarComunicadosxUsuario(AccessRequest usuario)
        {
            var Consulta = DbConnection.Query<ComunicadoResponses>("Seguridad.SP_ADMINISTRAR_USUARIO", new
            {
                ID = usuario.ID,
                USUARIO = usuario.USUARIO,
                PASSWORD = usuario.PASSWORD,
                TIPO = usuario.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }


        public TResponses MantenimientoAsistencia(TRequest asistencia)
        {
            TResponses Consulta = DbConnection.Query<TResponses>("Seguridad.SP_ADMINISTRAR_ASISTENCIA", new
            {
                ID = asistencia.ID,
                CONTENIDO = asistencia.CONTENIDO,

                ID_CONTROL = asistencia.ID_CONTROL,
                ID_USUARIO = asistencia.ID_USUARIO,
                ID_GRUPO = asistencia.ID_GRUPO,
                ID_SEDE = asistencia.ID_SEDE,
                TIPO = asistencia.TIPO,
            }, commandType: CommandType.StoredProcedure).First();
            return Consulta;
        }

        public List<TResponses> ListaAsistencia(TRequest asistencia)
        {
            var Consulta = DbConnection.Query<TResponses>("Seguridad.SP_ADMINISTRAR_ASISTENCIA", new
            {
                ID_SEDE = asistencia.ID_SEDE,
                ID_USUARIO = asistencia.ID_USUARIO,
                TIPO = asistencia.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public UsuarioResponses VerUsuario(TRequest user)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: user.ID, direction: ParameterDirection.Input);
            param.Add("P_ACCES_TOKEN", value: user.CONTENIDO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            UsuarioResponses myRefcurs = DbConnection.Query<UsuarioResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_VER_USUARIO",
                param: param, commandType: CommandType.StoredProcedure).First();
            return myRefcurs;
        }

        public List<UsuarioResponses> ListarUsuariosxGrupo(TRequest grupo)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: grupo.ID, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            var myRefcurs = DbConnection.Query<UsuarioResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_LIS_USUARIOSxGRUPO",
                param: param, commandType: CommandType.StoredProcedure).ToList();
            return myRefcurs;
        }

        public List<UsuarioResponses> ListarUsuariosxCarga_T(TRequest grupo)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: grupo.ID, direction: ParameterDirection.Input);
            param.Add("P_ID_SEDE", value: grupo.ID_SEDE, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            var myRefcurs = DbConnection.Query<UsuarioResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_LIS_USUARIOSxCARGA_T",
                param: param, commandType: CommandType.StoredProcedure).ToList();
            return myRefcurs;


            
        }
    }

}
