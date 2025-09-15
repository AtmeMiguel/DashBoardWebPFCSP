using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Responses
{
    public class DocPagoResponses
    {

        public string ID { get; set; }
        public string CONFIRMAR { get; set; }
        public string ACCIONES { get; set; }
        public string USUARIO { get; set; }
        public string FECHA { get; set; }

        /*Auxiliares*/
        public string ACCION { get; set; }
        public string MSG { get; set; }
        public string SELECCIONAR { get; set; }
        public string MARCADO { get; set; }

        public string APROBADO { get; set; }

        public string PENDIENTE { get; set; }

        public string RECHAZADO { get; set; }

        public string CANTIDAD { get; set; }

        public string MAIL { get; set; }

        public string ERROR { get; set; }

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

        public string MOTIVO { get; set; }
        public string OBSERVACION { get; set; }
        public string MTO_TOTC { get; set; } //MONTO FACTURA CON IGV

        //Nuevos campos 11/04/2023

        public string FLG_FOR_PAG { get; set; }

        public string COD_EMPRESA { get; set; }

        public string COD_SUCURSAL { get; set; }

        public string FLG_PM { get; set; }


    }
}
