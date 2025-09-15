using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request
{
    public class ExamenRequest
    {
        public string ID { get; set; }
        public string ID_USUARIO { get; set; }
        public int ID_SEDE { get; set; }
        
        public string TITULO { get; set; }
        public int TIPO { get; set; }
    }
}
