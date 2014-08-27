using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Componentes.ProveedorData;
using Componentes.Transaccion;

namespace Componentes.NivelMedio.Transacciones
{
    public static class Eventos
    {
        #region Selección Multiple
        public static List<Evento> ObtenerLista()
        {
            var sp = new SqlProveedorData();
            return sp.ObtenerEventos();
        }
        #endregion
    }
}
