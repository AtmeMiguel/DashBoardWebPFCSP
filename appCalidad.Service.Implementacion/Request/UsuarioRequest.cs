using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Request
{
    public class UsuarioRequest
    {
        public int ID { get; set; }
        public string USUARIO { get; set; }
        public string PASSWORD { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string CORREO { get; set; }
        public string ROL { get; set; }

        public int ID_GRUPO { get; set; }
        public int ID_USUARIO { get; set; }
        public int ID_SEDE { get; set; }
    }
}
