using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request.CLARO
{
    public class RetencionesRequest
    {
        public int ID { get; set; }
        public string SIAC { get; set; }
        public string SN { get; set; }
        public string TELEFONO { get; set; }
        public string PROYECTO { get; set; }
        public string CONTRATO { get; set; }
        public string CUSTOMER_ID { get; set; }
        public string TIPO_PRODUCTO { get; set; }
        public string COBERTURA { get; set; }
        public string MOTIVO { get; set; }
        public string SUB_MOTIVO { get; set; }
        public string SUB_MOTIVO_1 { get; set; }
        public string SUB_MOTIVO_2 { get; set; }

        public string MUDANZA_SINCOBERTURA { get; set; }
        public string REFERENCIA_SINCOBERTURA { get; set; }

        public string NIVEL6 { get; set; }
        public string NIVEL7 { get; set; }
        public string NIVEL8 { get; set; }
        public string NIVEL9 { get; set; }

        public string TIPO_GESTION { get; set; }
        public string SUB_GESTION { get; set; }
        public string TIPO_SOLICITUD { get; set; }
        public string CODIGO_INTERACCION { get; set; }
        public string RESULTADO { get; set; }
        public string OBSERVACION { get; set; }
        public string PLANTILLA { get; set; }
        public string USUARIO { get; set; }
        public int TIPO { get; set; }
    }
}
