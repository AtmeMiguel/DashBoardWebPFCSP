using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request
{
   public class SynapsisRequest
    {

        public string COD_PETITORIO { get; set; }
        public string COD_CURRENCY { get; set; }
        public string PURCHASEAMOUNT { get; set; }

        public string COD_EMPRESA { get; set; }
       
    }

    public class SynapsisPlanRequest
    {

        public int IDTITULAR { get; set; }
        public int IDPLAN { get; set; }
        public string IND_MOD { get; set; }
        public string SECUENCIA { get; set; }
        public string TIPO { get; set; }

    }


}
