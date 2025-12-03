using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request
{
    public class PagoPFRequest
    {
        public string DOCUMENTO { get; set; }
        public string CONTRATO { get; set; }


        public string TIPOPLAN { get; set; }
        public string N_CUOTA { get; set; }
     
        public string VENCIMIENTO { get; set; }
        public string MONTO { get; set; }
        public string ESTADO { get; set; }
        public string EMISION { get; set; }
        public string SEC_CONTRATO { get; set; }
        public string NOMBREPLAN { get; set; }
        public string SECUENCIA { get; set; }
        public string FORMA_PAG { get; set; }

    }
}
