using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request
{
    public class DocPagoRequest
    {


        public int CONFIRMAR { get; set; }

        public int ID_USUARIO { get; set; }

        public string TIPO { get; set; }

        public string NOMBRE_USUARIO { get; set; }


        /*Auxiliares*/
        public string ACCION { get; set; }
        public string FEC_INI { get; set; }
        public string FEC_FIN { get; set; }
        public int ID_SEDE { get; set; }
        public string RUTA { get; set; }
        public string MAIL { get; set; }

        public string FEC_ESTADO_INI { get; set; }
        public string FEC_ESTADO_FIN { get; set; }

        /*Propiedades de Tabla NCAUTOLOTEC,NCAUTOLOTED*/
        public string FLG_ORIGEN_CAB { get; set; }
        public string DFECHA_CAB { get; set; }
        public string DRESP_CAB { get; set; }
        public string DNROLOTE_CAB { get; set; }
        public string DLOTFEC_CAB { get; set; }
        public string DTIPOIPC_CAB { get; set; }
        public string FLG_ESTLOT_CAB { get; set; }
        public string IDENT_CAB { get; set; }
        public string FLG_EST_CAB { get; set; }
        public string FLG_PM_CAB { get; set; }


        public string FLG_ORIGEN { get; set; }
        public string DFECHA { get; set; }
        public string DNROLOTE { get; set; }
        public string SNROFAC { get; set; }
        public string DNROFAC { get; set; }
        public string FLG_ESTREG { get; set; }
        public string FLG_EST_DOC { get; set; }
        public string AUTO_POR { get; set; }
        public string DFECHA_APRO { get; set; }
        public string COD_OBS { get; set; }

        public string FLG_FOR_PAG { get; set; }

    }
}
