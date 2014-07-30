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
                string pa = string.Format("{0}.spClienteActualizar", PropietarioBD);

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
                miBase.AddInParameter(bdc, "@FechaEdicion", DbType.DateTime, cliente.FechaModificacion);
                miBase.AddInParameter(bdc, "@UsuarioCreacion", DbType.String, cliente.UsuarioCreacion);
                miBase.AddInParameter(bdc, "@UsuarioEdicion", DbType.String, cliente.UsuarioActualizacion);

                return miBase.ExecuteNonQuery(bdc);
                }
            else throw new ArgumentNullException("cliente");
        }
        public int EliminarCliente(int id)
        {
            if (id >= 0)
            {
                Database database = DatabaseFactory.CreateDatabase("basedatos");
                string sp = string.Format("{0}.spClienteEliminar", PropietarioBD);

                DbCommand dbc = database.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                database.AddInParameter(dbc, "@id", DbType.Int32, id);

                return database.ExecuteNonQuery(dbc);

            }
            throw new ArgumentNullException("id");
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
            string pa = string.Format("{0}.spClienteObtenerLista", PropietarioBD);

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
                cliente.Id = int.Parse(valorData["Id"].ToString());
                cliente.Nombre = (string)valorData["Nombre"];
                cliente.Apellido = (string)valorData["Apellido"];
                cliente.TipoIdentificacion = (string)valorData["TipoIdentificacion"];
                cliente.NumeroIdentificacion = (string)valorData["NumeroIdentificacion"];


                cliente.Ecorreo = (string)valorData["Ecorreo"];

                if (!string.IsNullOrEmpty(valorData["FechaNacimiento"].ToString()))
                    cliente.FechaNacimiento = (DateTime)valorData["FechaNacimiento"];

                cliente.Estado = int.Parse(valorData["Estado"].ToString());
                cliente.FechaCreacion = (DateTime)valorData["FechaCreacion"];
                cliente.FechaModificacion = (DateTime)valorData["FechaEdicion"];

                if (!string.IsNullOrEmpty(valorData["UsuarioCreacion"].ToString()))
                    cliente.UsuarioCreacion = (string)valorData["UsuarioCreacion"];

                if (!string.IsNullOrEmpty(valorData["UsuarioEdicion"].ToString()))
                    cliente.UsuarioActualizacion = (string)valorData["UsuarioEdicion"];
            }
            return cliente;
        }

        #endregion

        #endregion
        #region Usuarios

        #region Administración
        /// <summary>
        /// Crear el usuario n.
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        /// <returns></returns>
        public decimal CrearUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                Database _Db = DatabaseFactory.CreateDatabase("basedatos");
                string sp = string.Format("{0}.spUsuarioInsertar", PropietarioBD);

                DbCommand dbc = _Db.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                _Db.AddInParameter(dbc, "@IdRol", DbType.Decimal, usuario.IdRol);
                _Db.AddInParameter(dbc, "@Nombre", DbType.String, usuario.Nombre);
                _Db.AddInParameter(dbc, "@Apellido", DbType.String, usuario.Apellido);
                _Db.AddInParameter(dbc, "@Ecorreo", DbType.String, usuario.Ecorreo);
                _Db.AddInParameter(dbc, "@Identificacion", DbType.String, usuario.Identificacion);
                _Db.AddInParameter(dbc, "@Contraseña", DbType.String, usuario.Contraseña);
                _Db.AddInParameter(dbc, "@FechaCreacion", DbType.DateTime, usuario.FechaCreacion);
                _Db.AddInParameter(dbc, "@FechaEdicion", DbType.DateTime, usuario.FechaEdicion);
                _Db.AddInParameter(dbc, "@IdEstado", DbType.Decimal, usuario.IdEstado);
                _Db.AddOutParameter(dbc, "@Id", DbType.Int32, 4);

                _Db.ExecuteNonQuery(dbc);

                usuario.Id = (int)_Db.GetParameterValue(dbc, "@Id");
                return usuario.Id;
            }
            else throw new ArgumentNullException("usuario");
        }
        /// <summary>
        /// Actuliza el usuario.
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        public void ActualizarUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                Database _Db = DatabaseFactory.CreateDatabase("basedatos");
                string sp = string.Format("{0}.spUsuarioActualizar", PropietarioBD);

                DbCommand dbc = _Db.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                _Db.AddInParameter(dbc, "@Id", DbType.Decimal, usuario.Id);
                _Db.AddInParameter(dbc, "@IdRol", DbType.Decimal, usuario.IdRol);
                _Db.AddInParameter(dbc, "@Nombre", DbType.String, usuario.Nombre);
                _Db.AddInParameter(dbc, "@Apellido", DbType.String, usuario.Apellido);
                _Db.AddInParameter(dbc, "@Ecorreo", DbType.String, usuario.Ecorreo);
                _Db.AddInParameter(dbc, "@Identificacion", DbType.String, usuario.Identificacion);
                _Db.AddInParameter(dbc, "@Contraseña", DbType.String, usuario.Contraseña);
                _Db.AddInParameter(dbc, "@FechaCreacion", DbType.DateTime, usuario.FechaCreacion);
                _Db.AddInParameter(dbc, "@FechaEdicion", DbType.DateTime, usuario.FechaEdicion);
                _Db.AddInParameter(dbc, "@IdEstado", DbType.Decimal, usuario.IdEstado);

                _Db.ExecuteNonQuery(dbc);

                return;
            }
            else throw new ArgumentNullException("usuario");
        }
        /// <summary>
        /// Elimina el usuario.
        /// </summary>
        /// <param name="usuarioId">The usuario id.</param>
        public int EliminarUsuario(int usuarioId)
        {
            if (usuarioId >= 0)
            {
                Database _Db = DatabaseFactory.CreateDatabase("basedatos");
                string sp = string.Format("{0}.spUsuarioEliminar", PropietarioBD);

                DbCommand dbc = _Db.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                _Db.AddInParameter(dbc, "@Id", DbType.Int32, usuarioId);

                return _Db.ExecuteNonQuery(dbc);
            }
            else throw new ArgumentNullException("usuarioId");
        }
        #endregion

        #region Selección Simple
        /// <summary>
        /// Obtiene el usuario.
        /// </summary>
        /// <param name="usuarioId">The usuario id.</param>
        /// <returns></returns>
        public Usuario ObtenerUsuario(int usuarioId)
        {
            if (usuarioId >= 0)
            {
                Database _Db = DatabaseFactory.CreateDatabase("basedatos");
                string sp = string.Format("{0}.spUsuarioObtener", PropietarioBD);

                DbCommand dbc = _Db.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                _Db.AddInParameter(dbc, "@Id", DbType.Int32, usuarioId);

                Usuario usuario = new Usuario();
                using (IDataReader dataReader = _Db.ExecuteReader(dbc))
                {
                    while (dataReader.Read())
                    {
                        usuario = RellenarUsuarioDeLectorIData(dataReader);
                    }
                    dataReader.Close();
                }
                dbc.Dispose();

                return usuario;
            }
            else throw new ArgumentNullException("usuarioId");
        }
        #endregion

        #region Selección múltiple
        /// <summary>
        /// Obtine el usuario.
        /// </summary>
        /// <returns></returns>
        public List<Usuario> ObtenerUsuarios()
        {
            Database _Db = DatabaseFactory.CreateDatabase("basedatos");
            string sp = string.Format("{0}.spUsuarioObtenerLista", PropietarioBD);

            DbCommand dbc = _Db.GetStoredProcCommand(sp);
            dbc.CommandType = CommandType.StoredProcedure;

            var usuarios = new List<Usuario>();
            using (IDataReader dataReader = _Db.ExecuteReader(dbc))
            {
                while (dataReader.Read())
                {
                    usuarios.Add(RellenarUsuarioDeLectorIData(dataReader));
                }
                dataReader.Close();
            }
            dbc.Dispose();
            return usuarios;
        }
        #endregion

        #region Región de Relleno
        /// <summary>
        /// Rellena el usuario del IDataReader.
        /// </summary>
        /// <param name="valorData">El registro usuario.</param>
        /// <returns></returns>
        public static Usuario RellenarUsuarioDeLectorIData(IDataRecord valorData)
        {
            var usuario = new Usuario();
            if (valorData != null)
            {
                usuario.IdRol = (Decimal)valorData["IdRol"];
                usuario.Nombre = (String)valorData["Nombre"];
                usuario.Apellido = (String)valorData["Apellido"];
                usuario.Ecorreo = (String)valorData["Ecorreo"];
                usuario.Identificacion = (String)valorData["Identificacion"];
                usuario.Contraseña = (String)valorData["Contraseña"];
                usuario.FechaCreacion = (DateTime)valorData["FechaCreacion"];
                usuario.FechaEdicion = (DateTime)valorData["FechaEdicion"];
                usuario.IdEstado = (Decimal)valorData["IdEstado"];
            }
            return usuario;
        }
        #endregion
        #endregion
    }
}
