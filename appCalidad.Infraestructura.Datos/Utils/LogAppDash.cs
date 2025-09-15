using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Infraestructura.Datos.Utils
{
    public class LogAppDash
    {
        public LogAppDash()
        {

        }

        public void NuevoRegistroLog(string nombre, string lsIdSms, string rutalog)
        {
            string RutaArchivo = string.Empty;
            RutaArchivo = @Convert.ToString(ConfigurationManager.AppSettings[rutalog])+ nombre;
            string lsAnioMes = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM");
            RutaArchivo = RutaArchivo + "_" + lsAnioMes + ".txt";
            RegistroLog(lsIdSms, RutaArchivo);
        }

        public void RegistroLog(string lsIdSms, string lsPath)
        {
            string path = string.Empty;
            string line = string.Empty;
            string RegistroLinea = "FECHA REGISTRO: " + DateTime.Now.ToString() + " | MENSAJE: " + lsIdSms;
            try   //Abrir el Archivo LOG para reescribirlo
            {
                System.IO.StreamWriter archivo = new System.IO.StreamWriter(lsPath, true);
                archivo.WriteLine(RegistroLinea);
                archivo.Close();
            }
            catch (Exception e)   //throw;
            {
                string lsAnioMes = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM");
                string RutaArchivo = "C:\\logSistemas\\ERROR_ELIMINAR_AL_SOLUCIONAR" + "_" + lsAnioMes + ".txt";
                RegistroLog(e.Message + lsIdSms, RutaArchivo);
            }

        }
    }

    
}
