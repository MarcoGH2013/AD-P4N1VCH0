using System;

namespace Componentes.Transaccion
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string TipoIdentificacion { get; set; }

        public string NumeroIdentificacion { get; set; }

        public string Ecorreo { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public int Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        public string UsuarioCreacion { get; set; }

        public string UsuarioActualizacion { get; set; }

        public string NombreCompleto
        {
            get
            {
                return string.Format("{0} {1}", Nombre, Apellido);
            }
        }
    }
}
