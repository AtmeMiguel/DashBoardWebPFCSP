using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request
{
    public class FormularioRequest
    {
        public int ID { get; set; }
        public int ID_SOURCE { get; set; }
        
        public string TITULO { get; set; }
        public string CAMPO_1 { get; set; }
        public string CAMPO_2 { get; set; }
        public string CAMPO_3 { get; set; }
        public string CAMPO_4 { get; set; }
        public string CAMPO_5 { get; set; }

        public int ID_USUARIO { get; set; }
        public int ID_GRUPO { get; set; }
        public int ID_SEDE { get; set; }
        public int TIPO { get; set; }
    }
}
