﻿namespace Componentes.Transaccion
{
    public class OrdenEspecialDetalle
    {
        #region AutoPropiedades
        public decimal IdOrdenEspecialCab { get; set; }
        public decimal Linea { get; set; }
        public decimal IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal IdEvento { get; set; }
        public string Color { get; set; }
        public string Leyenda { get; set; }
        public byte[] Imagen { get; set; }
        public string Observaciones { get; set; }
        #endregion
    }
}