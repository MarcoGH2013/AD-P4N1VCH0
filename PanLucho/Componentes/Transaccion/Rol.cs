using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Componentes.Transaccion
{
    public class Rol
    {
        #region AutoPropiedades
        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal IdEstado { get; set; }
        #endregion
    }
}
