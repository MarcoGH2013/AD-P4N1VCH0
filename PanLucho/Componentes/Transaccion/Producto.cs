using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Componentes.Transaccion
{
    public class Producto
    {
        public decimal id { get; set; }
        public string descripcion { get; set; }
        public string descripcionDetallada { get; set; }
        public string claseProducto  { get; set; }
        public string unidadMedida { get; set; }
        public decimal existencias { get; set; }
        public decimal precio { get; set; }
        public decimal idEstado { get; set; }
        public bool esGrabado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaEdicion { get; set; }
        public string usuarioCreacion { get; set; }
        public string usuarioEdicion { get; set; }
    }
}
