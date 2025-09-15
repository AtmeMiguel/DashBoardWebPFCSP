using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Responses
{
    public class FDinamico
    {
        public int ID { get; set; }
        public int ID_SOURCE { get; set; }
        public string MODULO { get; set; }
        public string COLUMNA { get; set; }
        public string TITULO { get; set; }
        public string VALOR { get; set; }
        public int ID_CONTROL { get; set; }
        public string CONTROL { get; set; }
        public string OCULTAR { get; set; }
        public int MN { get; set; }
        public int MX { get; set; }
        public int EDITABLE { get; set; }
        public int ID_FORMULARIO { get; set; }

    }
}
