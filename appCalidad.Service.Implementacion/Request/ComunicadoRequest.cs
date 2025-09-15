using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request
{
    public class ComunicadoRequest
    {
        public int ID { get; set; }
        public string TITULO { get; set; }
        public string CONTENIDO { get; set; }
        public string FORMADOR { get; set; }
        public string BANNER { get; set; }
        public string EXT { get; set; }
        public int PRIORIDAD { get; set; }
        public int CONFIRMAR { get; set; }

        public int ID_USUARIO { get; set; }
        public int ID_GRUPO { get; set; }
        public int ID_SEDE { get; set; }
        public int TIPO { get; set; }
    }
}
