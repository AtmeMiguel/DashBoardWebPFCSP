using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request
{
    public class AccessRequest
    {
        public string ID { get; set; }
        public string USUARIO { get; set; }
        public string PASSWORD { get; set; }
        public string TIPOVAL { get; set; }
        public string CORREO { get; set; }
        public string TIPO { get; set; }
        public string TIPODOC { get; set; }

        public string CODIGOAUT { get; set; }
        /*PARA REGISTRO DE USUARIO*/
        public string TIPODOCUMENTO { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string DIRECCION { get; set; }
        public string FECHA_NACIMIENTO { get; set; }
        public string CEL_AFI { get; set; }
        public string TEL_AFI { get; set; }

    }
}
