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
        public int TIPO { get; set; }
    }
}
