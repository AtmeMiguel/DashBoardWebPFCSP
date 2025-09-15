using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request.CLARO
{
    public class OpcionesRequest
    {
        public int ID { get; set; }
        public int ID_CONTROL { get; set; }
        public string VALUE { get; set; }
        public string DEPENDENCIA { get; set; }
        public int ID_DEPENDENCIA { get; set; }
        public string FECHA { get; set; }
        public string OBSERVACION { get; set; }
        public string SPEECH { get; set; }
        public string DESCARTES { get; set; }
        public string ACCIONES { get; set; }
        public string USUARIO { get; set; }
        public int ID_SERVICIO { get; set; }
        public int TIPO { get; set; }
    }
}
