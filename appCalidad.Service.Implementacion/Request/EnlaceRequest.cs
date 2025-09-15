using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request
{
    public class EnlaceRequest
    {
        public int ID { get; set; }
        public string TITULO { get; set; }
        public string CONTENIDO { get; set; }
        public string ENLACE { get; set; }
        public string MODO { get; set; }

        public int ID_USUARIO { get; set; }
        public int ID_GRUPO { get; set; }
        public int ID_SEDE { get; set; }
        public int TIPO { get; set; }
    }
}
