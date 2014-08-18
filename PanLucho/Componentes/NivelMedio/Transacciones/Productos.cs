using System;
using System.Collections.Generic;

using Componentes.Transaccion;
using Componentes.ProveedorData;

namespace Componentes.NivelMedio.Transacciones
{
    public static class Productos
    {
        #region Seleccion simple

        public static Producto ObtenerParaGrid(decimal codigo)
        {
            if (codigo <= 0) throw new ArgumentNullException("codigo");
            var sp = new SqlProveedorData();
            return sp.ObtenerProductoParaFactura(codigo);
        }
        public static List<Producto> ObtenerParaVenta(string filtro, decimal estado, Boolean esCodido)
        {
            var sp = new SqlProveedorData();
            return sp.ObtenerProductosVenta(filtro, estado, esCodido);
        }
        #endregion

    }
}
