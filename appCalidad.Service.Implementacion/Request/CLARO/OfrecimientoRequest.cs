using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request.CLARO
{
    public class OfrecimientoRequest
    {
        public int ID { get; set; }
        public int ID_SOURCE { get; set; }
        public string OFRECIMIENTO { get; set; }
        public string GESTION { get; set; }
        public string TIPO_DESCUENTO { get; set; }
        public string MESES { get; set; }
        public string ESTADO { get; set; }
        public string MOTIVO { get; set; }
        public string MOTIVO_II { get; set; }
        public string FECHA { get; set; }
        public string OBSERVACION { get; set; }

        public string USUARIO { get; set; }
        public int ID_GRUPO { get; set; }
        public int TIPO { get; set; }
    }
}
