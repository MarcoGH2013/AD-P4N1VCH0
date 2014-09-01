using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Componentes.Transaccion
{
    public class ClienteConsultaGrid
    {
        public decimal id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string TipoIdentificacion { get; set; }
        public string numeroIdentificacion { get; set; }
        public string usuario { get; set; }//ecorreo
    }
}
