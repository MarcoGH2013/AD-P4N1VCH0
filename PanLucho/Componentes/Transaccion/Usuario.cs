namespace Componentes.Transaccion
{
    public class Usuario
    {
        #region AutoPropiedades
        public decimal Id { get; set; }
        public decimal IdRol { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ecorreo { get; set; }
        public string Identificacion { get; set; }
        public string Contrasena { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaEdicion { get; set; }
        public decimal IdEstado { get; set; }
        #endregion
    }
}

