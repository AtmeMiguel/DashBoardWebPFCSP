using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Responses
{
    public class AccessResponses
    {
     
        public string ID { get; set; }
        public string USUARIO { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string CORREO { get; set; }
        public string ACCESS_TOKEN { get; set; }
        public string RESULTADO { get; set; }
        public string PLANTILLA { get; set; }

        public string NRODOCUMENTO { get; set; }
        public string TIPODOCUMENTO { get; set; }

        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string DIRECCION { get; set; }
        public string FECHA_NACIMIENTO { get; set; }

        public string MSG { get; set; }
    }
}
