using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request
{
    public class AutorizacionPFRequest
    {
        public string LLAVE_ORIGEN { get; set; }
        public string TIPO_AUT { get; set; }
        public string TIPO_ENV { get; set; }

        public string ID { get; set; }
        public string ESTADO { get; set; }

    }
}
