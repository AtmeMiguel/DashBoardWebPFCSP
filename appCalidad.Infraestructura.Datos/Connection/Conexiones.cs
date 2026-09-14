using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace appCalidad.Infraestructura.Datos.Connection
{
    public class Conexiones
    {

        public IDbConnection ConstruirConexion()
        {
            return new OracleConnection(ConfigurationManager.AppSettings["cn_1"].ToString());
            //return new OracleConnection(this.connString);
        }

        public IDbConnection ConstruirConexionSede(int idSede)
        {
            string cone = ConfigurationManager.AppSettings["cn_" + idSede].ToString();

            return new OracleConnection(cone);
        }
    }
}
