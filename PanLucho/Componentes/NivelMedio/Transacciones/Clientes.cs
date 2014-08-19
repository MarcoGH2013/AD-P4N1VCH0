using System;
//using System.Collections.Generic;
using System.Collections.Generic;
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
        public static int Eliminar(int customerId)
        {
            if (customerId == null) throw new ArgumentNullException("customerId");
            var sp = new SqlProveedorData();
            return sp.EliminarCliente(customerId);
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
        #region Selección Multiple

        public static List<Cliente> ObtenerLista()
        {
            var sp = new SqlProveedorData();
            return sp.ObtenerClientes();
        }
        public static List<Cliente> ObtenerLista2()
        {
            var sp = new SqlProveedorData();
            return sp.ObtenerClientes2();
        }
        #endregion
    }
}
