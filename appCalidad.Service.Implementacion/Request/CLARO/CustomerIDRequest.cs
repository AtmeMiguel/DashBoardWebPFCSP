using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request.CLARO
{
    public class CustomerIDRequest
    {
        public string CUSTOMER_ID { get; set; }
        public string TOTAL { get; set; }
        public string CLIENTE { get; set; }
        public string PRODUCTO { get; set; }
        public string CATEGORIA { get; set; }
        public string DESCUENTO { get; set; }
        public string PLANTILLA { get; set; }
        public int ID_USUARIO { get; set; }
        public int ID_SOURCE { get; set; }
        public int BASE { get; set; }
        public int TIPO { get; set; }
    }
}
