using System;
using Componentes.ProveedorData;
using Componentes.Transaccion;

namespace Componentes.NivelMedio.Transacciones
{
    public static class OrdenEspecialCabs
    {
        #region Administración
        public static bool Crear(OrdenEspecialCab ordenespecialcab)
        {
            if (ordenespecialcab == null) throw new ArgumentNullException("ordenespecialcab");
            var sp = new SqlProveedorData();
            return sp.CrearOrdenEspecial(ordenespecialcab);
        }
        #endregion
        #region Selección Simple
        
        #endregion
        #region Selección Multiple
        
        #endregion
    }
}
