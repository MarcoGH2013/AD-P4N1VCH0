using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Componentes.ProveedorData;
using Componentes.Transaccion;

namespace Componentes.NivelMedio.Transacciones
{
    public static class ModulosXRols
    {
        #region Administración
        public static int Crear(ModulosXRol modulosxrol)
        {
            if (modulosxrol == null) throw new ArgumentNullException("modulosxrol");
            var sp = new SqlProveedorData();
            return sp.CrearModulosXRol(modulosxrol);
        }
        public static int Actualizar(ModulosXRol modulosxrol)
        {
            if (modulosxrol == null) throw new ArgumentNullException("modulosxrol");
            var sp = new SqlProveedorData();
            return sp.ActualizarModulosXRol(modulosxrol);
        }
        public static int EliminarXRol(int rolId)
        {
            if (rolId == null) throw new ArgumentNullException("rolId");
            var sp = new SqlProveedorData();
            return sp.EliminarModulosXRolXRol(rolId);
        }
        #endregion
        #region Selección Simple
        public static ModulosXRol Obtener(int modulosxrolId)
        {
            if (modulosxrolId <= 0) throw new ArgumentNullException("modulosxrolId");
            var sp = new SqlProveedorData();
            return sp.ObtenerModulosXRol(modulosxrolId);
        }
        #endregion
        #region Selección Multiple
        public static List<ModulosXRol> ObtenerLista(int rolId)
        {
            if (rolId <= 0) throw new ArgumentNullException("rolId");
            var sp = new SqlProveedorData();
            return sp.ObtenerModulosXRols(rolId);
        }
        #endregion
    }
}
