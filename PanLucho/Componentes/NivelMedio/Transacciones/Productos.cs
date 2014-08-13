using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Componentes.Transaccion;
using Componentes.ProveedorData;

namespace Componentes.NivelMedio.Transacciones
{
    public static class Productos
    {
        #region Seleccion simple

        public static Producto ObtenerParaGrid(decimal codigo)
        {
            if (codigo <= 0) throw new ArgumentNullException("productoId");
            var sp = new SqlProveedorData();
            return sp.ObtenerProductoParaFactura(codigo);
        }

        #endregion

    }
}
