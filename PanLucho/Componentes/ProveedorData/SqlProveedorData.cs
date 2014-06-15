using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Componentes.Transaccion;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Componentes.ProveedorData
{
    public class SqlProveedorData
    {
        private const string PropietarioBD = "dbo";
        #region Clientes

        #region Administración

        public int CrearCliente(Cliente cliente)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (cliente == null)
                throw new ArgumentNullException("cliente");
            var pa = string.Format("{0}.spClienteInsertar", PropietarioBD);
            var bdc = miBase.GetStoredProcCommand(pa);
            bdc.CommandType = CommandType.StoredProcedure;

            miBase.AddInParameter(bdc, "@Nombre", DbType.String, cliente.Nombre);
            miBase.AddInParameter(bdc, "@Apellido", DbType.String, cliente.Apellido);
            miBase.AddInParameter(bdc, "@TipoIdentificacion", DbType.String, cliente.TipoIdentificacion);
            miBase.AddInParameter(bdc, "@NumeroIdentificacion", DbType.String, cliente.NumeroIdentificacion);


            miBase.AddInParameter(bdc, "@Ecorreo", DbType.String, cliente.Ecorreo);
            if (cliente.FechaNacimiento.HasValue)
                miBase.AddInParameter(bdc, "@FechaNacimiento", DbType.Date, cliente.FechaNacimiento);

            miBase.AddInParameter(bdc, "@Estado", DbType.Boolean, cliente.Estado);
            miBase.AddInParameter(bdc, "@FechaCreacion", DbType.DateTime, cliente.FechaCreacion);
            miBase.AddInParameter(bdc, "@FechaEdicion", DbType.DateTime, cliente.FechaModificacion);
            miBase.AddInParameter(bdc, "@UsuarioCreacion", DbType.String, cliente.UsuarioCreacion);
            miBase.AddInParameter(bdc, "@UsuarioEdicion", DbType.String, cliente.UsuarioActualizacion);
            miBase.AddOutParameter(bdc, "@Id", DbType.Int32, 4);

            miBase.ExecuteNonQuery(bdc);

            cliente.Id = (Int32)miBase.GetParameterValue(bdc, "@Id");
            return cliente.Id;
        }

        public int ActualizarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                Database miBase = DatabaseFactory.CreateDatabase("basedatos");
                string pa = string.Format("{0}.spClientesActualizar", PropietarioBD);

                DbCommand bdc = miBase.GetStoredProcCommand(pa);
                bdc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(bdc, "@Id", DbType.Int32, cliente.Id);
                miBase.AddInParameter(bdc, "@Nombre", DbType.String, cliente.Nombre);
                miBase.AddInParameter(bdc, "@Apellido", DbType.String, cliente.Apellido);
                miBase.AddInParameter(bdc, "@TipoIdentificacion", DbType.String, cliente.TipoIdentificacion);
                miBase.AddInParameter(bdc, "@NumeroIdentificacion", DbType.String, cliente.NumeroIdentificacion);

                miBase.AddInParameter(bdc, "@Ecorreo", DbType.String, cliente.Ecorreo);
                miBase.AddInParameter(bdc, "@FechaNacimiento", DbType.Date, cliente.FechaNacimiento);
                miBase.AddInParameter(bdc, "@Estado", DbType.Boolean, cliente.Estado);
                miBase.AddInParameter(bdc, "@FechaCreacion", DbType.DateTime, cliente.FechaCreacion);
                miBase.AddInParameter(bdc, "@FechaModificacion", DbType.DateTime, cliente.FechaModificacion);
                miBase.AddInParameter(bdc, "@UsuarioCreacion", DbType.String, cliente.UsuarioCreacion);
                miBase.AddInParameter(bdc, "@UsuarioActualizacion", DbType.String, cliente.UsuarioActualizacion);

                return miBase.ExecuteNonQuery(bdc);

            }
            throw new ArgumentNullException("cliente");
        }

        #endregion

        #region Selección Simple

        public Cliente Obtener(int codigo)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            var pa = string.Format("{0}.spClienteObtener", PropietarioBD);

            var bdc = miBase.GetStoredProcCommand(pa);
            bdc.CommandType = CommandType.StoredProcedure;

            miBase.AddInParameter(bdc, "@Id", DbType.String, codigo);

            var customer = new Cliente();
            using (var lectorDatos = miBase.ExecuteReader(bdc))
            {
                while (lectorDatos.Read())
                {
                    customer = RellenarClienteDeLectorIData(lectorDatos);
                }
                lectorDatos.Close();
            }
            bdc.Dispose();

            return customer;
        }

        #endregion

        #region Selección Multiple

        public List<Cliente> ObtenerClientes()
        {
            Database miBase = DatabaseFactory.CreateDatabase("basedatos");
            string pa = string.Format("{0}.spClientesObtenerLista", PropietarioBD);

            DbCommand bdc = miBase.GetStoredProcCommand(pa);
            bdc.CommandType = CommandType.StoredProcedure;

            List<Cliente> clientes = new List<Cliente>();
            using (IDataReader lectorDatos = miBase.ExecuteReader(bdc))
            {
                while (lectorDatos.Read())
                {
                    clientes.Add(RellenarClienteDeLectorIData(lectorDatos));
                }
                lectorDatos.Close();
            }
            bdc.Dispose();
            return clientes;
        }

        #endregion

        #region Región de Relleno

        public static Cliente RellenarClienteDeLectorIData(IDataRecord valorData)
        {
            var cliente = new Cliente();
            if (valorData != null)
            {
                cliente.Id = (int)valorData["Id"];
                cliente.Nombre = (string)valorData["Nombre"];
                cliente.Apellido = (string)valorData["Apellido"];
                cliente.TipoIdentificacion = (string)valorData["TipoIdentificacion"];
                cliente.NumeroIdentificacion = (string)valorData["NumeroIdentificacion"];


                cliente.Ecorreo = (string)valorData["Ecorreo"];

                if (!string.IsNullOrEmpty(valorData["FechaNacimiento"].ToString()))
                    cliente.FechaNacimiento = (DateTime)valorData["FechaNacimiento"];

                cliente.Estado = (Int16)valorData["Estado"];
                cliente.FechaCreacion = (DateTime)valorData["FechaCreacion"];
                cliente.FechaModificacion = (DateTime)valorData["FechaModificacion"];

                if (!string.IsNullOrEmpty(valorData["UsuarioCreacion"].ToString()))
                    cliente.UsuarioCreacion = (string)valorData["UsuarioCreacion"];

                if (!string.IsNullOrEmpty(valorData["UsuarioActualizacion"].ToString()))
                    cliente.UsuarioActualizacion = (string)valorData["UsuarioActualizacion"];
            }
            return cliente;
        }

        #endregion

        #endregion
    }
}
