using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Componentes.ProveedorData;
using Componentes.Transaccion;

namespace Componentes.NivelMedio.Transacciones
{
    public static class Usuarios
    {
        #region Constructors

        #endregion
        #region Management
        public static decimal Crear(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException("usuario");
            var sp = new SqlProveedorData();
            return sp.CrearUsuario(usuario);
        }
        public static decimal Actualizar(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException("usuario");
            var sp = new SqlProveedorData();
            return sp.ActualizarUsuario(usuario);
        }
        public static int Eliminar(int usuario)
        {
            if (usuario == null) throw new ArgumentNullException("usuario");
            var sp = new SqlProveedorData();
            return sp.EliminarUsuario(usuario);
        }
        #endregion
        #region Single Selection
        public static Usuario Obtener(int usuarioId)
        {
            if (usuarioId <= 0) throw new ArgumentNullException("usuarioId");
            var sp = new SqlProveedorData();
            return sp.ObtenerUsuario(usuarioId);
        }
        #endregion
        #region Multiple Selection
        public static List<Usuario> ObtenerLista()
        {
            var sp = new SqlProveedorData();
            return sp.ObtenerUsuarios();
        }
        #endregion
    }
}