using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Componentes.ProveedorData;
using Componentes.Transaccion;

namespace Componentes.NivelMedio.Transacciones
{
    public static class Roles
    {
        #region Administración
        public static int Crear(Rol rol)
        {
            if (rol == null) throw new ArgumentNullException("rol");
            var sp = new SqlProveedorData();
            return sp.CrearRol(rol);
        }
        public static int Actualizar(Rol rol)
        {
            if (rol == null) throw new ArgumentNullException("rol");
            var sp = new SqlProveedorData();
            return sp.ActualizarRol(rol);
        }
        public static int Eliminar(int rol)
        {
            if (rol == null) throw new ArgumentNullException("rol");
            var sp = new SqlProveedorData();
            return sp.EliminarRol(rol);
        }
        #endregion
        #region Selección Simple
        public static Rol Obtener(int rolId)
        {
            if (rolId <= 0) throw new ArgumentNullException("rolId");
            var sp = new SqlProveedorData();
            return sp.ObtenerRol(rolId);
        }
        #endregion
        #region Selección Multiple
        public static List<Rol> ObtenerLista()
        {
            var sp = new SqlProveedorData();
            return sp.ObtenerRols();
        }
        #endregion
    }
}
