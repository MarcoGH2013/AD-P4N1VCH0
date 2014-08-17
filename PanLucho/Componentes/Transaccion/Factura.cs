using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Componentes.Transaccion
{
    class Factura
    {
        public decimal id { get; set; }
        public decimal idCliente { get; set; }
        public DateTime? fechaFacturacion { get; set; }
        public string facturaSRI { get; set; }
        public decimal subTotal { get; set; }
        public decimal iva { get; set; }
        public decimal descuento { get; set; }
        public decimal totalPagar { get; set; }
        public List<FacturaDet> detalles { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public string userCreador { get; set; }
        public bool procesado { get; set; }
        public bool esCancelado { get; set; }
        public decimal? idSucursal { get; set; }
    }
}
