using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Componentes.Transaccion
{
    public class ModuloCategoria
    {
        public decimal id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string fechaCreacion { get; set; }
        public string fechaEdicion { get; set; }
        public decimal idEstado { get; set; }
        public string usuarioEdicion { get; set; }
    }
}
