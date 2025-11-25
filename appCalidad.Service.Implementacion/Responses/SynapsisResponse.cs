using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Responses
{
    public class SynapsisResponse
    {
        public string identifier { get; set; }
        public string signature { get; set; }
   

    }

    public class SynapsisPlanResponse
    {

        public int IDPLAN { get; set; }
        public string MONTO { get; set; }
        public string CODIGO_PEDIDO { get; set; }
        public string MONTO_TOTAL { get; set; }

        public string nombre { get; set; }
        public string apepat { get; set; }
        public string apemat { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string docafi { get; set; }

        public string idcliente { get; set; }
        public string canprod { get; set; }

        public string SECUENCIA { get; set; }

        public string MSG { get; set; }


    }


}
