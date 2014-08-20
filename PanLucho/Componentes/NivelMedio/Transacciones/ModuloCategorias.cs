using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Componentes.ProveedorData;
using Componentes.Transaccion;

namespace Componentes.NivelMedio.Transacciones
{
    public static class ModuloCategorias
    {
        #region Administración
        public static int Crear(ModuloCategoria modulocategoria)
        {
            if (modulocategoria == null) throw new ArgumentNullException("modulocategoria");
            var sp = new SqlProveedorData();
            return sp.CrearModuloCategoria(modulocategoria);
        }
        public static int Actualizar(ModuloCategoria modulocategoria)
        {
            if (modulocategoria == null) throw new ArgumentNullException("modulocategoria");
            var sp = new SqlProveedorData();
            return sp.ActualizarModuloCategoria(modulocategoria);
        }
        public static int Eliminar(int modulocategoriaId)
        {
            if (modulocategoriaId == null) throw new ArgumentNullException("modulocategoriaId");
            var sp = new SqlProveedorData();
            return sp.EliminarModuloCategoria(modulocategoriaId);
        }
        #endregion
        #region Selección Simple
        public static ModuloCategoria Obtener(int modulocategoriaId)
        {
            if (modulocategoriaId <= 0) throw new ArgumentNullException("modulocategoriaId");
            var sp = new SqlProveedorData();
            return sp.ObtenerModuloCategoria(modulocategoriaId);
        }
        #endregion
        #region Selección Multiple
        public static List<ModuloCategoria> ObtenerLista()
        {
            var sp = new SqlProveedorData();
            return sp.ObtenerModuloCategorias();
        }
        #endregion
    }
}
