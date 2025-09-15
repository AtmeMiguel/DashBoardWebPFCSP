using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request
{
    public class MailRequest
    {
        public int ID { get; set; }
        public int ID_SMTP { get; set; }
        public string TO { get; set; }
        public string CC { get; set; }
        public string SUBJECT { get; set; }
        public string BODY { get; set; }
        public string USER { get; set; }
        public string ATTACHMENT { get; set; }
    }
}
