using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request
{
    public class RolRequest
    {
        public int ID { get; set; }
        public string TITULO { get; set; }
        public string ICONO { get; set; }
        public string PAGINA { get; set; }

        public int ORDEN { get; set; }
        public int ID_USUARIO { get; set; }
        public int ID_MODULO { get; set; }
        public int ID_SEDE { get; set; }
    }
}
