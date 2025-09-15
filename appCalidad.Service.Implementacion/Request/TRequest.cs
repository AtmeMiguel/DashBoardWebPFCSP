using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request
{
    public class TRequest
    {
        public int ID { get; set; }
        public int? ID_SOURCE { get; set; }
        public string TITULO { get; set; }
        public string CONTENIDO { get; set; } = "";
        public string CAMPO { get; set; } = "";


        public int? ID_USUARIO { get; set; }
        public int? ID_CONTROL { get; set; }
        public int? ID_GRUPO { get; set; }
        public int? ID_ROL { get; set; }
        public int? ID_SEDE { get; set; }
        public int? TIPO { get; set; }
    }


}
