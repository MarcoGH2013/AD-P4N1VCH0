using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Componentes.ProveedorData;
using Componentes.Transaccion;

namespace Componentes.NivelMedio.Transacciones
{
    public static class Modulos
    {
        #region Administración
        public static int Crear(Modulo modulo)
        {
            if (modulo == null) throw new ArgumentNullException("modulo");
            var sp = new SqlProveedorData();
            return sp.CrearModulo(modulo);
        }
        public static int Actualizar(Modulo modulo)
        {
            if (modulo == null) throw new ArgumentNullException("modulo");
            var sp = new SqlProveedorData();
            return sp.ActualizarModulo(modulo);
        }
        public static int Eliminar(int moduloId)
        {
            if (moduloId == null) throw new ArgumentNullException("moduloId");
            var sp = new SqlProveedorData();
            return sp.EliminarModulo(moduloId);
        }
        #endregion
        #region Selección Simple
        public static Modulo Obtener(int moduloId)
        {
            if (moduloId <= 0) throw new ArgumentNullException("moduloId");
            var sp = new SqlProveedorData();
            return sp.ObtenerModulo(moduloId);
        }
        #endregion
        #region Selección Multiple
        public static List<Modulo> ObtenerLista()
        {
            var sp = new SqlProveedorData();
            return sp.ObtenerModulos();
        }
        #endregion
    }
}
