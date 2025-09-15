using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Responses
{
    public class FormularioResponses
    {
        public int ID { get; set; }
        public string TITULO { get; set; }
        public string CANTIDAD { get; set; }
        public string FECHA_INI { get; set; }
        public string FECHA_FIN { get; set; }

        public string ACCIONES { get; set; }
        public string USUARIO { get; set; }
        public string FECHA { get; set; }
    }
}
