using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Responses
{
    public class ItemsListaResponses
    {
        public string Message { get; set; }
        public List<ListaItems> listaListas { get; set; }

        public class ListaItems
        {
            public int ID_CONTROL { get; set; }
            public List<Items> listaItems { get; set; }
        }
        
        public class Items
        {
            public int ID { get; set; }
            public int ID_CONTROL { get; set; }
            public string TITULO { get; set; }
            public int ID_PADRE { get; set; }
            public string DETALLE { get; set; }
            public string CAMPO1 { get; set; }
            public string CAMPO2 { get; set; }
            public string CAMPO3 { get; set; }
        }
    }
}
