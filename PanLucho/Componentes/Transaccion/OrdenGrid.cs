using System.Drawing;

namespace Componentes.Transaccion
{
    public class OrdenGrid
    {
        #region AutoPropiedades
        public decimal Id { get; set; }
        public string DescripcionDetallada { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public string IdEvento { get; set; }
        public Color Color { get; set; }
        public string Leyenda { get; set; }
        public Image Imagen { get; set; }
        public string Observaciones { get; set; }
        #endregion
    }
}
