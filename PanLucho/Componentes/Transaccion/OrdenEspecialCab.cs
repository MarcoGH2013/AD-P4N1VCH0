using System.Collections.Generic;

namespace Componentes.Transaccion
{
    public class OrdenEspecialCab
    {
        #region AutoPropiedades
        public decimal Id { get; set; }
        public decimal IdCliente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Abono { get; set; }
        public List<OrdenEspecialDetalle> Detalles { get; set; }
        public System.DateTime FechaEntrega { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UserCreador { get; set; }
        public decimal IdEstado { get; set; }
        #endregion
    }
}
