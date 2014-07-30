using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Componentes.Transaccion
{
    public class UsuarioPermisos
    {
        public int id { get; set; }
        public decimal idUsuario { get; set; }
        public string nick { get; set; }
        public string descripcion { get; set; }
        public string nombreForm { get; set; }
        public string libreriaClase { get; set; }
        public string menu { get; set; }
        public string permisos { get; set; }
    }
}
