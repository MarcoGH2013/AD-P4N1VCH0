using System;

namespace Componentes.Transaccion
{
    public class Producto
    {
        #region AutoPropiedades
        public decimal Id { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionDetallada { get; set; }
        public string ClaseProducto { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Existencias { get; set; }
        public decimal Precio { get; set; }
        public decimal IdEstado { get; set; }
        public bool EsGrabado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaEdicion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioEdicion { get; set; }
        #endregion
    }
}
