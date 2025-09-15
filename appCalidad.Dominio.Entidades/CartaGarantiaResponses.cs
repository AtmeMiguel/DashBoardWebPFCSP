using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Dominio.Entidades
{
    public class CartaGarantiaResponses
    {
        public int ID { get; set; }
        public string USUARIO { get; set; }
        public string USUARIO_FIRMA { get; set; }
        public string DETALLE { get; set; }
        public string FECHA { get; set; }

        public string ANO_CARTA { get; set; }
        public string NUM_CARTA { get; set; }
        public string FIRMA { get; set; }
        public string SEDE { get; set; }
        public string AFILIADO { get; set; }
        public string COD_ASEGURADEP { get; set; }
        public string CONTRATANTE { get; set; }
        public string NUMCONTRATOPF { get; set; }
        public string PROMOTOR { get; set; }
        public string DSC_PLAN { get; set; }
        public string COD_PLAN { get; set; }
        public string FEC_INI_AFILIACION { get; set; }
        public string FEC_INI_AFILIACION_IMP { get; set; }
        public string FEC_HOSPITALIZACION { get; set; }
        public string FEC_SOLICITUD { get; set; }
        public string FEC_APRO_CARTA { get; set; }
        public string CMP { get; set; }
        public string MEDICO_TRATANTE { get; set; }

        public string CIE { get; set; }
        public string DIAGNOSTICO { get; set; }
        public string LIM_CARTA { get; set; }
        public string LIM_CARTA_APROBADA { get; set; }

        public string COPAGO { get; set; }
        public string COBERTURA { get; set; }
        public string DEDUCIBLE { get; set; }
        public string AREA { get; set; }
        public string PLAN_TRABAJO { get; set; }

        public string DSC_MOTIVO { get; set; }
        public string PROCEDIMIENTO1 { get; set; }
        public string CODPROC1 { get; set; }
        public string OBSERVACION { get; set; }
        public string OBSERVACION_ { get; set; }

        public string COD_EMPRESA { get; set; }
        public string COD_SUCURSAL { get; set; }
        public string COMPLEJIDAD_CARTA { get; set; }
        public string FECHA_ATENCION { get; set; }
        public string ESTADO { get; set; }
        public string IMPORTANTE { get; set; }
        public string BENECICIO_MAXIMO { get; set; }
        public string SINIESTRO_ACUMULADO { get; set; }
        public string SALDO_CONSUMIR { get; set; }
        public List<coberturaAprobada> COBERTURAS { get; set; }

    }

    public class coberturaAprobada
    {
        public int ID { get; set; }
        public string COBERTURA { get; set; }
        public string COPAGO { get; set; }
        public string DEDUCIBLE { get; set; }

    }
}
