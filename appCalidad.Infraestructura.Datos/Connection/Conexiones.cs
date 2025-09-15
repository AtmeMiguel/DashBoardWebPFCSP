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
        //#### Cadenas de test ####//
        /*    

        //string connString = "DATA SOURCE=(DESCRIPTION=(LOAD_BALANCE=yes)(ADDRESS=(PROTOCOL=TCP)(HOST=192.1.0.191)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=chspsp))));USER ID = VDIAZO; Password=vdiazo123";
        string connString = "DATA SOURCE=(DESCRIPTION=(LOAD_BALANCE=yes)(ADDRESS=(PROTOCOL=TCP)(HOST=192.1.0.191)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=chspsp))));USER ID =VDIAZO; Password=vdiazo123";

        string connStringSP = "DATA SOURCE=(DESCRIPTION=(LOAD_BALANCE=yes)(ADDRESS=(PROTOCOL=TCP)(HOST=192.1.0.191)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=chspsp))));USER ID =VDIAZO; Password=vdiazo123";
        string connStringSG = "DATA SOURCE=(DESCRIPTION=(LOAD_BALANCE=yes)(ADDRESS=(PROTOCOL=TCP)(HOST=192.1.0.191)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=chspsgts))));USER ID = VDIAZO; Password=vdiazo123";
        string connStringSN = "DATA SOURCE=(DESCRIPTION=(LOAD_BALANCE=yes)(ADDRESS=(PROTOCOL=TCP)(HOST=192.1.0.192)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=chspjnts))));USER ID = VDIAZO; Password=vdiazo123";
        string connStringSMS = "DATA SOURCE=(DESCRIPTION=(LOAD_BALANCE=yes)(ADDRESS=(PROTOCOL=TCP)(HOST=192.1.0.192)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=chspjnts))));USER ID = VDIAZO; Password=vdiazo123";
        string connStringSJB = "DATA SOURCE=(DESCRIPTION=(LOAD_BALANCE=yes)(ADDRESS=(PROTOCOL=TCP)(HOST=192.1.0.192)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=chspjnts))));USER ID = VDIAZO; Password=vdiazo123";
        string connStringSH = "DATA SOURCE=(DESCRIPTION=(LOAD_BALANCE=yes)(ADDRESS=(PROTOCOL=TCP)(HOST=192.1.0.192)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=chspjnts))));USER ID = VDIAZO; Password=vdiazo123";
        string connStringAQP = "DATA SOURCE=(DESCRIPTION=(LOAD_BALANCE=yes)(ADDRESS=(PROTOCOL=TCP)(HOST=192.1.0.192)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=chspjnts))));USER ID = VDIAZO; Password=vdiazo123";
        string connStringLM = "DATA SOURCE=(DESCRIPTION=(LOAD_BALANCE=yes)(ADDRESS=(PROTOCOL=TCP)(HOST=192.1.0.192)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=chspjnts))));USER ID = VDIAZO; Password=vdiazo123";
        string connStringPRIMAVERA = "DATA SOURCE=(DESCRIPTION=(LOAD_BALANCE=yes)(ADDRESS=(PROTOCOL=TCP)(HOST=192.1.0.191)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=chspsp))));USER ID =VDIAZO; Password=vdiazo123";

        string connStringLV = "DATA SOURCE=(DESCRIPTION=(LOAD_BALANCE=yes)(ADDRESS=(PROTOCOL=TCP)(HOST=192.1.0.212)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=chspsm))));USER ID =VDIAZO; Password=vdiazo123";
         */



        //#### Cadenas de produccion ####//
        /*   
        string connString = "DATA SOURCE=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.1.0.81)(PORT = 1521)) (ADDRESS = (PROTOCOL = TCP)(HOST = 192.1.0.82)(PORT = 1521)) (LOAD_BALANCE = yes)(CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = chsp)));USER ID = PORTAL_WEB; Password=mc*#$5214%NcP";

        string connStringSP = "DATA SOURCE=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.1.0.81)(PORT = 1521)) (ADDRESS = (PROTOCOL = TCP)(HOST = 192.1.0.82)(PORT = 1521)) (LOAD_BALANCE = yes)(CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = chsp)));USER ID = PORTAL_WEB; Password=mc*#$5214%NcP";
    
        string connStringSG = "DATA SOURCE=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.40.2)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=chspsg))));USER ID = PORTAL_WEB; Password=mc*#$5214%NcP";
        
        string connStringSN = "DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.20.5)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=chsp))));USER ID = PORTAL_WEB; Password=mc*#$5214%NcP";
      
        string connStringSMS = "DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.30.2)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=chspsm))));USER ID = PORTAL_WEB; Password=mc*#$5214%NcP";
       

       string connStringSH = "DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=chspsh-scan.sanpablo.com.pe)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=CHSPSH)));USER ID = PORTAL_WEB; Password=mc*#$5214%NcP";


        string connStringAQP = "DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=racaqp-scan.sanpablo.com.pe)(PORT=1579))(CONNECT_DATA=(SERVICE_NAME=chspaqp))));USER ID = PORTAL_WEB; Password=mc*#$5214%NcP";
     
        string connStringSJB = "DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=chspsjb-scan.sanpablo.com.pe)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=chsp))));USER ID = PORTAL_WEB; Password=mc*#$5214%NcP";
     
        string connStringLM = "DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.74.24)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=chsplm))));USER ID = PORTAL_WEB; Password=mc*#$5214%NcP";
       
        
        string connStringPRIMAVERA = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=chsppri-scan.sanpablo.com.pe)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=CHSPPRI)));USER ID = PORTAL_WEB; Password=mc*#$5214%NcP";


        string connStringLV = "DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=scanchsplv)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=chsplv)));USER ID = PORTAL_WEB; Password=mc*#$5214%NcP";


        string connStringSPDer = "DATA SOURCE=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.1.0.81)(PORT = 1521)) (ADDRESS = (PROTOCOL = TCP)(HOST = 192.1.0.82)(PORT = 1521)) (LOAD_BALANCE = yes)(CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = chsp)));USER ID = PORTAL_WEB; Password=mc*#$5214%NcP";
         */

        public IDbConnection ConstruirConexion()
        {
            return new OracleConnection(ConfigurationManager.AppSettings["cn_1"].ToString());
            //return new OracleConnection(this.connString);
        }

        public IDbConnection ConstruirConexionSede(int idSede)
        {
            string cone = ConfigurationManager.AppSettings["cn_" + idSede].ToString();

            /*
            switch (idSede)
            {

                case 1:     cone = this.connStringSP;       break;
                case 2:     cone = this.connStringSG;       break;
                case 5:     cone = this.connStringSH;       break;
                case 6:     cone = this.connStringSJB;      break;

                case 7: cone = this.connStringLV; break;

                case 9:     cone = this.connStringSN;       break;
                case 10:    cone = this.connStringSMS;      break;
                //case 23:    cone = this.connString;         break;
                case 13:    cone = this.connStringLM;       break;
                case 17:    cone = this.connStringPRIMAVERA;break;
                case 21:    cone = this.connStringAQP;      break;

                case 39: cone = this.connStringSPDer; break;


                default:
                    cone = "ERROR";
                    break;
            }*/

            return new OracleConnection(cone);
        }
    }
}
