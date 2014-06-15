using System;
//using ttttttSystem.Collections.Generic;

using Componentes.ProveedorData;
using Componentes.Transaccion;

namespace Componentes.NivelMedio.Transacciones
{
    public class Clientes
    {
        #region Administración

        public static int Crear(Cliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException("cliente");
            var sp = new SqlProveedorData();
            return sp.CrearCliente(cliente);
        }

        public static int Actualizar(Cliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException("cliente");
            var sp = new SqlProveedorData();
            return sp.ActualizarCliente(cliente);
        }
        
        #endregion
        #region Selección Simple

        public static Cliente Obtener(int clienteid)
        {
            if (clienteid <= 0) throw new ArgumentNullException("clienteid");
            var sp = new SqlProveedorData();
            return sp.Obtener(clienteid);
        }

        #endregion
    }
}
