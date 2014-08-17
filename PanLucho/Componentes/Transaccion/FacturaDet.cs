using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Componentes.Transaccion
{
    public class FacturaDet
    {
        public decimal idFacturaCab { get; set; }
        public decimal linea { get; set; }
        public decimal idProducto { get; set; }
        public decimal cantidad { get; set; }
        public decimal totalLinea { get; set; }
        public decimal? iva { get; set; }
        public decimal? descuentoPorcentaje { get; set; }
        public decimal? descuentoValor { get; set; }
    }
}
