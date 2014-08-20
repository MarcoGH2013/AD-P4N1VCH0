﻿

namespace Componentes.Transaccion
{
    public class ModuloCategoria
    {
        #region AutoPropiedades
        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaEdicion { get; set; }
        public decimal IdEstado { get; set; }
        public string UsuarioEdicion { get; set; }
        #endregion
    }
}
