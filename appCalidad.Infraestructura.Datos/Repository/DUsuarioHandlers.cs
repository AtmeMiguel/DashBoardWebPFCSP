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
            param.Add("P_TIPO_DOC", value: autObj.TIPO_DOC, direction: ParameterDirection.Input);
            param.Add("P_DESTINATARIO", value: autObj.DESTINATARIO, direction: ParameterDirection.Input);
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

                Consulta.MSG = "Ocurrio un error en envio.";

                Consulta.DETALLE_ENVIO = "";
                if (Consulta.LLAVE_ORIGEN != null && Consulta.DESTINATARIO != null && Consulta.CODIGO_AUT !=null && Consulta.ID !=null)
                {
                    //if (Consulta.DESTINATARIO.ToLower() == "atmemiguel@gmail.com" || Consulta.DESTINATARIO.ToLower() == "atmemarcos@gmail.com" )
                    //{

                        if (autObj.TIPO_AUT== "recuperar_cuenta")
                        {
                            string msgCorreo = oEmail.EnviarCorreoAutorizacion(Consulta, "recuperar_cuenta");
                            Consulta.DETALLE_ENVIO = msgCorreo;

                            if (msgCorreo == "OK")
                            {
                                AutorizacionPFRequest objUpdateCodAut = new AutorizacionPFRequest();
                                objUpdateCodAut.ID = Consulta.ID;
                                objUpdateCodAut.ESTADO = "enviado";
                                objUpdateCodAut.LLAVE_ORIGEN = Consulta.LLAVE_ORIGEN;
                                objUpdateCodAut.TIPO_AUT = "recuperar_cuenta";
                                objUpdateCodAut.TIPO_ENV = "";
                                var rpta = updateCodAutPagosPF(objUpdateCodAut);
                                if (rpta.MSG=="OK")
                                {
                                      Consulta.MSG = "OK";
                                }
                            }
                        }
                        else if (autObj.TIPO_AUT == "registro_cuenta")
                        {
                            string msgCorreo = oEmail.EnviarCorreoAutorizacion(Consulta, "registro_cuenta");
                            Consulta.DETALLE_ENVIO = msgCorreo;

                            if (msgCorreo == "OK")
                            {
                                AutorizacionPFRequest objUpdateCodAut = new AutorizacionPFRequest();
                                objUpdateCodAut.ID = Consulta.ID;
                                objUpdateCodAut.ESTADO = "enviado";
                                objUpdateCodAut.LLAVE_ORIGEN = Consulta.LLAVE_ORIGEN;
                                objUpdateCodAut.TIPO_AUT = "registro_cuenta";
                                objUpdateCodAut.TIPO_ENV = "";
                                var rpta = updateCodAutPagosPF(objUpdateCodAut);

                                if (rpta.MSG == "OK")
                                {
                                    Consulta.MSG = "OK";
                                }
                                else
                                {
                                    Consulta.MSG = rpta.MSG;
                                }


                            }
                        }
                        
                    //}

                }
            }

            return Consulta;
        }


        public AutorizacionPFResponse VerificarCodigoPagoPF(AutorizacionPFRequest autObj)
        {
            AutorizacionPFResponse Consulta = new AutorizacionPFResponse();
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_LLAVE", value: autObj.LLAVE_ORIGEN, direction: ParameterDirection.Input);
            param.Add("P_TIPOVAL", value: autObj.TIPO_AUT, direction: ParameterDirection.Input);
            param.Add("P_DESTINATARIO", value: autObj.DESTINATARIO, direction: ParameterDirection.Input);
            param.Add("P_CODIGO", value: autObj.CODIGO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            /*var Consulta = DbConnectionSede.Query<DocPagoResponses>("CHSP.PK_DS_AUTORIZACION_NOTACREDITO.SP_ACTUALIZAR_DOC_PAG",
                param: param, commandType: CommandType.StoredProcedure).First();*/

            Consulta = DbConnection.Query<AutorizacionPFResponse>("CHSP.PK_DS_PAGOS_PF.VALIDAR_CODIGO",
             param: param, commandType: CommandType.StoredProcedure).First();

            Consulta.MSG = Consulta.MSG == null ? "" : Consulta.MSG;
            Consulta.CODIGO_AUT = Consulta.CODIGO_AUT == null ? "" : Consulta.CODIGO_AUT;
            Consulta.LLAVE_ORIGEN = Consulta.LLAVE_ORIGEN == null ? "" : Consulta.LLAVE_ORIGEN;
            Consulta.DESTINATARIO = Consulta.DESTINATARIO == null ? "" : Consulta.DESTINATARIO;
            Consulta.DETALLE_ENVIO = Consulta.DETALLE_ENVIO == null ? "" : Consulta.DETALLE_ENVIO;
            Consulta.ID = Consulta.ID == null ? "" : Consulta.ID;

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



        public AccessResponses insertarUsuarioPagosPF(AccessRequest user)
        {
            user.PASSWORD = user.PASSWORD.Trim();
            string clavencryptada = Encryptar.Encrypt.GetMD5(user.PASSWORD);
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_DOCU_AFI", value: user.USUARIO, direction: ParameterDirection.Input);
            param.Add("P_TIPO_DOC", value: user.TIPODOC , direction: ParameterDirection.Input);
            param.Add("P_NOM_AFI", value: user.NOMBRES, direction: ParameterDirection.Input);
            param.Add("P_APE_PAT_AFI", value: user.APELLIDO_PATERNO, direction: ParameterDirection.Input);
            param.Add("P_APE_MAT_AFI", value: user.APELLIDO_MATERNO, direction: ParameterDirection.Input);
            param.Add("P_FECHA_NAC_AFI", value: user.FECHA_NACIMIENTO, direction: ParameterDirection.Input);
            param.Add("P_PASS_USER_AFI", value: clavencryptada, direction: ParameterDirection.Input);
            param.Add("P_EMAIL_AFI", value: user.CORREO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            AccessResponses myRefcurs = DbConnection.Query<AccessResponses>("CHSP.PK_DS_PAGOS_PF.INSERTAR_USUARIO",
                param: param, commandType: CommandType.StoredProcedure).First();
            

            //cuenta_registrada
            if (myRefcurs.MSG == "OK") {

                if (user.USUARIO != null && user.CORREO != null && user.NOMBRES != null)
                {
                    AutorizacionPFResponse obj = new AutorizacionPFResponse();
                    obj.LLAVE_ORIGEN = user.USUARIO;
                    obj.NOMBRES = user.NOMBRES;
                    obj.DESTINATARIO = user.CORREO; 
                        string msgCorreo = oEmail.EnviarCorreoAutorizacion(obj, "cuenta_registrada");
                       

                 }
            }
            return myRefcurs;

        }

        public AccessResponses VerificarUsuarioPagosPF(AccessRequest user)
        {
           
            string clavencryptada = Encryptar.Encrypt.GetMD5(user.PASSWORD);
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_USUARIO", value: user.USUARIO, direction: ParameterDirection.Input);
            param.Add("P_PASSWORD", value: clavencryptada, direction: ParameterDirection.Input);
            param.Add("P_TIPODOC", value: user.TIPODOC, direction: ParameterDirection.Input);
            param.Add("P_TIPOVAL", value: user.TIPOVAL, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            AccessResponses myRefcurs = DbConnection.Query<AccessResponses>("CHSP.PK_DS_PAGOS_PF.VALIDAR_USUARIO",
                param: param, commandType: CommandType.StoredProcedure).First();
            return myRefcurs;
        }


        public AccessResponses VerificarAfiliadoPagoPF(AccessRequest user)
        {

            AccessResponses myRefcurs = new AccessResponses();

            try
            {
            //se solicitara a ricardo store para que indique si documento es valido
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("PNUMERO", value: user.USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "OUT_CURSOR", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            var  myRefcursBase = DbConnection.Query<AccessResponses>("chsp.pf_proyectocobranza.SPValidaDNI",
                param: param, commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (myRefcursBase == null)
                {
                    myRefcurs.MSG = "No se encontro el Nro. de Documento: " + user.USUARIO + " en la base de afiliados.";
                }
                else
                {

                    myRefcurs.MSG = "OK";
                    myRefcurs.USUARIO = myRefcursBase.NRODOCUMENTO == null ? "" : myRefcursBase.NRODOCUMENTO;
                    myRefcurs.NOMBRES = myRefcursBase.NOMBRES == null ? "" : myRefcursBase.NOMBRES;
                    myRefcurs.APELLIDO_PATERNO = myRefcursBase.APELLIDO_PATERNO == null ? "" : myRefcursBase.APELLIDO_PATERNO;
                    myRefcurs.APELLIDO_MATERNO = myRefcursBase.APELLIDO_MATERNO == null ? "" : myRefcursBase.APELLIDO_MATERNO;
                    myRefcurs.DIRECCION = myRefcursBase.DIRECCION == null ? "" : myRefcursBase.DIRECCION;
                    myRefcurs.FECHA_NACIMIENTO = myRefcursBase.FECHA_NACIMIENTO == null ? "" : myRefcursBase.FECHA_NACIMIENTO;


                }
            }
            catch (Exception ex)
            {
                myRefcurs.MSG = ex.Message;
            }

            return myRefcurs;
        }

        public AccessResponses VerificarCorreoPagosPF(AccessRequest user)
        {

            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_CORREO", value: user.CORREO, direction: ParameterDirection.Input);
            param.Add("P_LLAVE", value: user.USUARIO, direction: ParameterDirection.Input);
            param.Add("P_TIPOVAL", value: user.TIPOVAL, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            AccessResponses myRefcurs = DbConnection.Query<AccessResponses>("CHSP.PK_DS_PAGOS_PF.VALIDAR_CORREO",
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
