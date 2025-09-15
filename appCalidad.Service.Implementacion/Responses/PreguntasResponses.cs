using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Responses
{
    public class PreguntasResponses
    {
        public int N_PREGUNTA { get; set; }
        public int N_RESPUESTA { get; set; }
        public int ID_RESPUESTA { get; set; }
        public int ID_PREGUNTA { get; set; }
        public string PREGUNTA { get; set; }
        public string RESPUESTA { get; set; }
        public int VALOR { get; set; }
        public string ESTADO { get; set; }
        public string BANNER { get; set; }
        public string CONTENIDO { get; set; }
    }
}
