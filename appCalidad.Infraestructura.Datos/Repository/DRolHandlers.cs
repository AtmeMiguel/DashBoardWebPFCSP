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
    public class DRolHandlers : IRolHandler
    {
        private readonly IDbConnection DbConnection;
        Conexiones con = new Conexiones();
        public DRolHandlers()
        {
            DbConnection = con.ConstruirConexion();
        }

        public RolResponses EliminarRol(RolRequest rol)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: rol.ID, direction: ParameterDirection.Input);
            param.Add("P_ID_USUARIO", value: rol.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            RolResponses myRefcurs = DbConnection.Query<RolResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_ELI_ROLES",
                param: param, commandType: CommandType.StoredProcedure).First();
            return myRefcurs;
        }

        public List<RolResponses> ListarRolesxPrograma(RolRequest rol)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: rol.ID_SEDE, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            List<RolResponses> myRefcurs = DbConnection.Query<RolResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_LIS_ROLES",
                param: param, commandType: CommandType.StoredProcedure).ToList();
            return myRefcurs;
        }

        public RolResponses MantenimientoRol(RolRequest rol)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: rol.ID, direction: ParameterDirection.Input);
            param.Add("P_TITULO", value: rol.TITULO, direction: ParameterDirection.Input);
            param.Add("P_ID_SEDE", value: rol.ID_SEDE, direction: ParameterDirection.Input);
            param.Add("P_ID_USUARIO", value: rol.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            RolResponses myRefcurs = DbConnection.Query<RolResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_ADM_ROLES",
                param: param, commandType: CommandType.StoredProcedure).First();
            return myRefcurs;
        }

        public List<RolResponses> ListarModulos(RolRequest rol)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: rol.ID_SEDE, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            List<RolResponses> myRefcurs = DbConnection.Query<RolResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_LIS_MODULOS",
                param: param, commandType: CommandType.StoredProcedure).ToList();
            return myRefcurs;
        }

        public RolResponses MantenimientoModulo(RolRequest rol)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: rol.ID, direction: ParameterDirection.Input);
            param.Add("P_TITULO", value: rol.TITULO, direction: ParameterDirection.Input);
            param.Add("P_ICONO", value: rol.ICONO, direction: ParameterDirection.Input);
            param.Add("P_PAGINA", value: rol.PAGINA, direction: ParameterDirection.Input);
            param.Add("P_ID_USUARIO", value: rol.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            RolResponses myRefcurs = DbConnection.Query<RolResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_ADM_MODULOS",
                param: param, commandType: CommandType.StoredProcedure).First();
            return myRefcurs;
        }

        public RolResponses EliminarModulo(RolRequest modulo)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: modulo.ID, direction: ParameterDirection.Input);
            param.Add("P_ID_USUARIO", value: modulo.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            RolResponses myRefcurs = DbConnection.Query<RolResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_ELI_MODULOS",
                param: param, commandType: CommandType.StoredProcedure).First();
            return myRefcurs;
        }

        public RolResponses AgregarModulosxRol(RolRequest rol)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: rol.ID_MODULO, direction: ParameterDirection.Input);
            param.Add("P_ID_ROL", value: rol.ID, direction: ParameterDirection.Input);
            param.Add("P_ORDEN", value: rol.ORDEN, direction: ParameterDirection.Input);
            param.Add("P_ID_USUARIO", value: rol.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            RolResponses myRefcurs = DbConnection.Query<RolResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_ADD_MODULOSxROL",
                param: param, commandType: CommandType.StoredProcedure).First();
            return myRefcurs;
        }

        public RolResponses EliminarModulosxRol(RolRequest rol)
        {
            OracleDynamicParameters param = new OracleDynamicParameters();
            param.Add("P_ID", value: rol.ID, direction: ParameterDirection.Input);
            param.Add("P_ID_USUARIO", value: rol.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "P_RETORNO", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            RolResponses myRefcurs = DbConnection.Query<RolResponses>("CHSP.PK_DS_ADMINISTRADOR.SP_ELI_MODULOSxROL",
                param: param, commandType: CommandType.StoredProcedure).First();
            return myRefcurs;
        }
    }
}
