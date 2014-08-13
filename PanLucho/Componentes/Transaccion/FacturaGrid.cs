using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Componentes.Transaccion
{
    public class FacturaGrid
    {
        public decimal id { get; set; }
        public string descripcion { get; set; }
        public string descripcionDetallada { get; set; }
        public string unidadMedida { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal descuento { get; set; }
        public decimal total { get; set; }
        public decimal existencias { get; set; }

    }
}
