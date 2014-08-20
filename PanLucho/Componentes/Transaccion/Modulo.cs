
namespace Componentes.Transaccion
{
    public class Modulo
    {
        #region AutoPropiedades
        public decimal Id { get; set; }
        public decimal IdModuloCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Assembler { get; set; }
        public string LibreriaClase { get; set; }
        public string NombreFormulario { get; set; }
        public string Imagen { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaEdicion { get; set; }
        public decimal IdEstado { get; set; }
        public string UsuarioEdicion { get; set; }
        #endregion
    }
}
