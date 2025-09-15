using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Responses
{
    public class TResponses
    {
        public int ID { get; set; }
        public int ID_SOURCE { get; set; }
        public string TITULO { get; set; }
        public string RESULTADO { get; set; }
        public string PLANTILLA { get; set; }

        public string ACCIONES { get; set; }
        public int ID_GRUPO { get; set; }
        public int ID_ROL { get; set; }
        public int ID_USUARIO { get; set; }
        public string USUARIO { get; set; }
        public string FECHA { get; set; }
    }
}
