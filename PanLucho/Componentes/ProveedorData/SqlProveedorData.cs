using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using System.Windows.Forms;
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

        public List<Cliente> ObtenerClientes2()
        {
            Database db = DatabaseFactory.CreateDatabase("basedatos");
            var sp = db.GetStoredProcCommand(PropietarioBD + "." + "spClienteObtenerLista");
            sp.CommandType = CommandType.StoredProcedure;

            List<Cliente> lista = new List<Cliente>();
            using (IDataReader dataReader = db.ExecuteReader(sp))
            {
                while (dataReader.Read())
                {
                    lista.Add(RellenarClienteDeLectorIData2(dataReader));
                }
                dataReader.Close();
            }
            sp.Dispose();
            return lista;
        }

        #endregion

        #region Región de Relleno

        public static Cliente RellenarClienteDeLectorIData(IDataRecord valorData)
        {
            var cliente = new Cliente();
            if (valorData != null)
            {
                cliente.Id                   = int.Parse(valorData["Id"].ToString());
                cliente.Nombre               = (string)valorData["Nombre"];
                cliente.Apellido             = (string)valorData["Apellido"];
                cliente.TipoIdentificacion   = (string)valorData["TipoIdentificacion"];
                cliente.NumeroIdentificacion = (string)valorData["NumeroIdentificacion"];

                cliente.Ecorreo              = (string)valorData["Ecorreo"];

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

        public static Cliente RellenarClienteDeLectorIData2(IDataRecord datos)
        {
            try
            {
                var cliente = new Cliente();
                if (datos != null)
                {
                    cliente.Id = Convert.ToInt32(datos["Id"].ToString());
                    cliente.Nombre = datos["Nombre"].ToString();
                    cliente.Apellido = datos["Apellido"].ToString();
                    cliente.TipoIdentificacion = datos["TipoIdentificacion"].ToString();
                    cliente.NumeroIdentificacion = datos["NumeroIdentificacion"].ToString();
                    
                    if (!string.IsNullOrEmpty(datos["Ecorreo"].ToString()))
                        cliente.Ecorreo = datos["Ecorreo"].ToString();

                    if (!string.IsNullOrEmpty(datos["FechaNacimiento"].ToString()))
                        cliente.FechaNacimiento = (DateTime)datos["FechaNacimiento"];
                    cliente.Estado = Convert.ToInt32(datos["Estado"].ToString());
                    //cliente.FechaCreacion = (DateTime)valorData["FechaCreacion"];
                    //cliente.FechaModificacion = (DateTime)valorData["FechaEdicion"];

                    //if (!string.IsNullOrEmpty(valorData["UsuarioCreacion"].ToString()))
                    //    cliente.UsuarioCreacion = (string)valorData["UsuarioCreacion"];

                    //if (!string.IsNullOrEmpty(valorData["UsuarioEdicion"].ToString()))
                    //    cliente.UsuarioActualizacion = (string)valorData["UsuarioEdicion"];
                }
                return cliente;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                return null;
            }
        }

        #endregion

        #endregion
        #region Usuarios

        #region Administración
        /// <summary>
        /// Crear el usuario n.
        /// </summary>
        /// <param name="usuario">El usuario.</param>
        /// <returns></returns>
        public decimal CrearUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                Database miBase = DatabaseFactory.CreateDatabase("basedatos");
                string sp = string.Format("{0}.spUsuarioInsertar", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@IdRol", DbType.Decimal, usuario.IdRol);
                miBase.AddInParameter(dbc, "@Nombre", DbType.String, usuario.Nombre);
                miBase.AddInParameter(dbc, "@Apellido", DbType.String, usuario.Apellido);
                miBase.AddInParameter(dbc, "@Ecorreo", DbType.String, usuario.Ecorreo);
                miBase.AddInParameter(dbc, "@Identificacion", DbType.String, usuario.Identificacion);
                miBase.AddInParameter(dbc, "@Contrasena", DbType.String, usuario.Contrasena);
                miBase.AddInParameter(dbc, "@FechaCreacion", DbType.DateTime, usuario.FechaCreacion);
                miBase.AddInParameter(dbc, "@FechaEdicion", DbType.DateTime, usuario.FechaEdicion);
                miBase.AddInParameter(dbc, "@IdEstado", DbType.Decimal, usuario.IdEstado);
                miBase.AddOutParameter(dbc, "@Id", DbType.Int32, 4);

                miBase.ExecuteNonQuery(dbc);

                usuario.Id = (int)miBase.GetParameterValue(dbc, "@Id");
                return usuario.Id;
            }
            else throw new ArgumentNullException("usuario");
        }
        /// <summary>
        /// Actuliza el usuario.
        /// </summary>
        /// <param name="usuario">El usuario.</param>
        public decimal ActualizarUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                Database miBase = DatabaseFactory.CreateDatabase("basedatos");
                string sp = string.Format("{0}.spUsuarioActualizar", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Id", DbType.Decimal, usuario.Id);
                miBase.AddInParameter(dbc, "@IdRol", DbType.Decimal, usuario.IdRol);
                miBase.AddInParameter(dbc, "@Nombre", DbType.String, usuario.Nombre);
                miBase.AddInParameter(dbc, "@Apellido", DbType.String, usuario.Apellido);
                miBase.AddInParameter(dbc, "@Ecorreo", DbType.String, usuario.Ecorreo);
                miBase.AddInParameter(dbc, "@Identificacion", DbType.String, usuario.Identificacion);
                miBase.AddInParameter(dbc, "@Contrasena", DbType.String, usuario.Contrasena);
                miBase.AddInParameter(dbc, "@FechaCreacion", DbType.DateTime, usuario.FechaCreacion);
                miBase.AddInParameter(dbc, "@FechaEdicion", DbType.DateTime, usuario.FechaEdicion);
                miBase.AddInParameter(dbc, "@IdEstado", DbType.Decimal, usuario.IdEstado);

                return miBase.ExecuteNonQuery(dbc); 
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
                Database miBase = DatabaseFactory.CreateDatabase("basedatos");
                string sp = string.Format("{0}.spUsuarioEliminar", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Id", DbType.Int32, usuarioId);

                return miBase.ExecuteNonQuery(dbc);
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
                Database miBase = DatabaseFactory.CreateDatabase("basedatos");
                string sp = string.Format("{0}.spUsuarioObtener", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Id", DbType.Int32, usuarioId);

                Usuario usuario = new Usuario();
                using (IDataReader dataReader = miBase.ExecuteReader(dbc))
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
            Database miBase = DatabaseFactory.CreateDatabase("basedatos");
            string sp = string.Format("{0}.spUsuarioObtenerLista", PropietarioBD);

            DbCommand dbc = miBase.GetStoredProcCommand(sp);
            dbc.CommandType = CommandType.StoredProcedure;

            var usuarios = new List<Usuario>();
            using (IDataReader dataReader = miBase.ExecuteReader(dbc))
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
                usuario.Id             = (Decimal)valorData["Id"];
                usuario.IdRol          = (Decimal)valorData["IdRol"];
                usuario.Nombre         = (String)valorData["Nombre"];
                usuario.Apellido       = (String)valorData["Apellido"];
                usuario.Ecorreo        = (String)valorData["Ecorreo"];
                usuario.Identificacion = (String)valorData["Identificacion"];
                usuario.Contrasena     = (String)valorData["Contrasena"];
                usuario.FechaCreacion  = (DateTime)valorData["FechaCreacion"];
                usuario.FechaEdicion   = (DateTime)valorData["FechaEdicion"];
                usuario.IdEstado       = (Decimal)valorData["IdEstado"];
            }
            return usuario;
        }
        #endregion
        #endregion
        #region Modulos

        #region Administración
        /// <summary>
        /// Crear el modulo n.
        /// </summary>
        /// <param name="modulo">The modulo.</param>
        /// <returns></returns>
        public int CrearModulo(Modulo modulo)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (modulo != null)
            {
                string sp = string.Format("{0}.spModuloInsertar", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@IdModuloCategoria", DbType.Decimal, modulo.IdModuloCategoria);
                miBase.AddInParameter(dbc, "@Nombre", DbType.String, modulo.Nombre);
                miBase.AddInParameter(dbc, "@Descripcion", DbType.String, modulo.Descripcion);
                miBase.AddInParameter(dbc, "@Assembler", DbType.String, modulo.Assembler);
                miBase.AddInParameter(dbc, "@LibreriaClase", DbType.String, modulo.LibreriaClase);
                miBase.AddInParameter(dbc, "@NombreFormulario", DbType.String, modulo.NombreFormulario);
                miBase.AddInParameter(dbc, "@Imagen", DbType.String, modulo.Imagen);
                miBase.AddInParameter(dbc, "@FechaCreacion", DbType.DateTime, modulo.FechaCreacion);
                miBase.AddInParameter(dbc, "@FechaEdicion", DbType.DateTime, modulo.FechaEdicion);
                miBase.AddInParameter(dbc, "@IdEstado", DbType.Decimal, modulo.IdEstado);
                miBase.AddInParameter(dbc, "@UsuarioEdicion", DbType.String, modulo.UsuarioEdicion);
                miBase.AddOutParameter(dbc, "@Id", DbType.Int32, 4);

                miBase.ExecuteNonQuery(dbc);

                modulo.Id = (int)miBase.GetParameterValue(dbc, "@Id");
                return (int)modulo.Id;
            }
            else throw new ArgumentNullException("modulo");
        }
        /// <summary>
        /// Actuliza el modulo.
        /// </summary>
        /// <param name="modulo">The modulo.</param>
        public int ActualizarModulo(Modulo modulo)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (modulo != null)
            {
                string sp = string.Format("{0}.spModuloActualizar", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Id", DbType.Decimal, modulo.Id);
                miBase.AddInParameter(dbc, "@IdModuloCategoria", DbType.Decimal, modulo.IdModuloCategoria);
                miBase.AddInParameter(dbc, "@Nombre", DbType.String, modulo.Nombre);
                miBase.AddInParameter(dbc, "@Descripcion", DbType.String, modulo.Descripcion);
                miBase.AddInParameter(dbc, "@Assembler", DbType.String, modulo.Assembler);
                miBase.AddInParameter(dbc, "@LibreriaClase", DbType.String, modulo.LibreriaClase);
                miBase.AddInParameter(dbc, "@NombreFormulario", DbType.String, modulo.NombreFormulario);
                miBase.AddInParameter(dbc, "@Imagen", DbType.String, modulo.Imagen);
                miBase.AddInParameter(dbc, "@FechaCreacion", DbType.DateTime, modulo.FechaCreacion);
                miBase.AddInParameter(dbc, "@FechaEdicion", DbType.DateTime, modulo.FechaEdicion);
                miBase.AddInParameter(dbc, "@IdEstado", DbType.Decimal, modulo.IdEstado);
                miBase.AddInParameter(dbc, "@UsuarioEdicion", DbType.String, modulo.UsuarioEdicion);

                return miBase.ExecuteNonQuery(dbc);
            }
            else throw new ArgumentNullException("modulo");
        }
        /// <summary>
        /// Elimina el modulo.
        /// </summary>
        /// <param name="moduloId">The modulo id.</param>
        public int EliminarModulo(int moduloId)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (moduloId >= 0)
            {
                string sp = string.Format("{0}.spModuloEliminar", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Id", DbType.Int32, moduloId);

                return miBase.ExecuteNonQuery(dbc);
            }
            else throw new ArgumentNullException("moduloId");
        }
        #endregion

        #region Selección Simple
        /// <summary>
        /// Obtiene el modulo.
        /// </summary>
        /// <param name="moduloId">The modulo id.</param>
        /// <returns></returns>
        public Modulo ObtenerModulo(int moduloId)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (moduloId >= 0)
            {
                string sp = string.Format("{0}.spModuloObtener", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Id", DbType.Int32, moduloId);

                Modulo modulo = new Modulo();
                using (IDataReader dataReader = miBase.ExecuteReader(dbc))
                {
                    while (dataReader.Read())
                    {
                        modulo = RellenarModuloDeLectorIData(dataReader);
                    }
                    dataReader.Close();
                }
                dbc.Dispose();

                return modulo;
            }
            else throw new ArgumentNullException("moduloId");
        }
        #endregion

        #region Selección múltiple
        /// <summary>
        /// Obtine el modulo.
        /// </summary>
        /// <returns></returns>
        public List<Modulo> ObtenerModulos()
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            string sp = string.Format("{0}.spModuloObtenerLista", PropietarioBD);

            DbCommand dbc = miBase.GetStoredProcCommand(sp);
            dbc.CommandType = CommandType.StoredProcedure;

            var modulos = new List<Modulo>();
            using (IDataReader dataReader = miBase.ExecuteReader(dbc))
            {
                while (dataReader.Read())
                {
                    modulos.Add(RellenarModuloDeLectorIData(dataReader));
                }
                dataReader.Close();
            }
            dbc.Dispose();
            return modulos;
        }
        #endregion

        #region Región de Relleno
        /// <summary>
        /// Rellena el modulo del IDataReader.
        /// </summary>
        /// <param name="valorData">El registro modulo.</param>
        /// <returns></returns>
        public static Modulo RellenarModuloDeLectorIData(IDataRecord valorData)
        {
            var modulo = new Modulo();
            if (valorData != null)
            {
                modulo.Id = (decimal) valorData["Id"];
                modulo.IdModuloCategoria = (Decimal)valorData["IdModuloCategoria"];
                modulo.Nombre = (String)valorData["Nombre"];
                modulo.Descripcion = (String)valorData["Descripcion"];
                modulo.Assembler = (String)valorData["Assembler"];
                modulo.LibreriaClase = (String)valorData["LibreriaClase"];
                modulo.NombreFormulario = (String)valorData["NombreFormulario"];
                modulo.Imagen = (String)valorData["Imagen"];
                modulo.FechaCreacion = (DateTime)valorData["FechaCreacion"];
                modulo.FechaEdicion = (DateTime)valorData["FechaEdicion"];
                modulo.IdEstado = (Decimal)valorData["IdEstado"];
                modulo.UsuarioEdicion = (String)valorData["UsuarioEdicion"];
            }
            return modulo;
        }
        #endregion
        #endregion
        #region ModuloCategorias

        #region Administración
        /// <summary>
        /// Crear el modulocategoria n.
        /// </summary>
        /// <param name="modulocategoria">El modulocategoria.</param>
        /// <returns></returns>
        public int CrearModuloCategoria(ModuloCategoria modulocategoria)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (modulocategoria != null)
            {
                string sp = string.Format("{0}.spModuloCategoriaInsertar", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Nombre", DbType.String, modulocategoria.Nombre);
                miBase.AddInParameter(dbc, "@Descripcion", DbType.String, modulocategoria.Descripcion);
                miBase.AddInParameter(dbc, "@FechaCreacion", DbType.DateTime, modulocategoria.FechaCreacion);
                miBase.AddInParameter(dbc, "@FechaEdicion", DbType.DateTime, modulocategoria.FechaEdicion);
                miBase.AddInParameter(dbc, "@IdEstado", DbType.Decimal, modulocategoria.IdEstado);
                miBase.AddInParameter(dbc, "@UsuarioEdicion", DbType.String, modulocategoria.UsuarioEdicion);
                miBase.AddOutParameter(dbc, "@Id", DbType.Int32, 4);

                miBase.ExecuteNonQuery(dbc);

                modulocategoria.Id = (int)miBase.GetParameterValue(dbc, "@Id");
                return (int)modulocategoria.Id;
            }
            else throw new ArgumentNullException("modulocategoria");
        }
        /// <summary>
        /// Actuliza el modulocategoria.
        /// </summary>
        /// <param name="modulocategoria">El modulocategoria.</param>
        public int ActualizarModuloCategoria(ModuloCategoria modulocategoria)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (modulocategoria != null)
            {
                string sp = string.Format("{0}.spModuloCategoriaActualizar", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Id", DbType.Decimal, modulocategoria.Id);
                miBase.AddInParameter(dbc, "@Nombre", DbType.String, modulocategoria.Nombre);
                miBase.AddInParameter(dbc, "@Descripcion", DbType.String, modulocategoria.Descripcion);
                miBase.AddInParameter(dbc, "@FechaCreacion", DbType.DateTime, modulocategoria.FechaCreacion);
                miBase.AddInParameter(dbc, "@FechaEdicion", DbType.DateTime, modulocategoria.FechaEdicion);
                miBase.AddInParameter(dbc, "@IdEstado", DbType.Decimal, modulocategoria.IdEstado);
                miBase.AddInParameter(dbc, "@UsuarioEdicion", DbType.String, modulocategoria.UsuarioEdicion);
                return miBase.ExecuteNonQuery(dbc);
            }
            else throw new ArgumentNullException("modulocategoria");
        }
        /// <summary>
        /// Elimina el modulocategoria.
        /// </summary>
        /// <param name="modulocategoriaId">El modulocategoria id.</param>
        public int EliminarModuloCategoria(int modulocategoriaId)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (modulocategoriaId >= 0)
            {
                string sp = string.Format("{0}.spModuloCategoriaEliminar", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Id", DbType.Int32, modulocategoriaId);

                return miBase.ExecuteNonQuery(dbc);
            }
            else throw new ArgumentNullException("modulocategoriaId");
        }
        #endregion

        #region Selección Simple
        /// <summary>
        /// Obtiene el modulocategoria.
        /// </summary>
        /// <param name="modulocategoriaId">El modulocategoria id.</param>
        /// <returns></returns>
        public ModuloCategoria ObtenerModuloCategoria(int modulocategoriaId)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (modulocategoriaId >= 0)
            {
                string sp = string.Format("{0}.spModuloCategoriaObtener", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Id", DbType.Int32, modulocategoriaId);

                ModuloCategoria modulocategoria = new ModuloCategoria();
                using (IDataReader dataReader = miBase.ExecuteReader(dbc))
                {
                    while (dataReader.Read())
                    {
                        modulocategoria = RellenarModuloCategoriaDeLectorIData(dataReader);
                    }
                    dataReader.Close();
                }
                dbc.Dispose();

                return modulocategoria;
            }
            else throw new ArgumentNullException("modulocategoriaId");
        }
        #endregion

        #region Selección múltiple
        /// <summary>
        /// Obtiene el modulocategoria.
        /// </summary>
        /// <returns></returns>
        public List<ModuloCategoria> ObtenerModuloCategorias()
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            string sp = string.Format("{0}.spModuloCategoriaObtenerLista", PropietarioBD);

            DbCommand dbc = miBase.GetStoredProcCommand(sp);
            dbc.CommandType = CommandType.StoredProcedure;

            var modulocategorias = new List<ModuloCategoria>();
            using (IDataReader dataReader = miBase.ExecuteReader(dbc))
            {
                while (dataReader.Read())
                {
                    modulocategorias.Add(RellenarModuloCategoriaDeLectorIData(dataReader));
                }
                dataReader.Close();
            }
            dbc.Dispose();
            return modulocategorias;
        }
        #endregion

        #region Región de Relleno
        /// <summary>
        /// Rellena el modulocategoria del IDataReader.
        /// </summary>
        /// <param name="valorData">El registro modulocategoria.</param>
        /// <returns></returns>
        public static ModuloCategoria RellenarModuloCategoriaDeLectorIData(IDataRecord valorData)
        {
            var modulocategoria = new ModuloCategoria();
            if (valorData != null)
            {
                modulocategoria.Nombre = (String)valorData["Nombre"];
                modulocategoria.Descripcion = (String)valorData["Descripcion"];
                modulocategoria.FechaCreacion = (DateTime)valorData["FechaCreacion"];
                modulocategoria.FechaEdicion = (DateTime)valorData["FechaEdicion"];
                modulocategoria.IdEstado = (Decimal)valorData["IdEstado"];
                modulocategoria.UsuarioEdicion = (String)valorData["UsuarioEdicion"];
            }
            return modulocategoria;
        }
        #endregion
        #endregion
        #region Rols

        #region Administración
        /// <summary>
        /// Crear el rol n.
        /// </summary>
        /// <param name="rol">El rol.</param>
        /// <returns></returns>
        public int CrearRol(Rol rol)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (rol != null)
            {
                string sp = string.Format("{0}.spRolInsertar", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Nombre", DbType.String, rol.Nombre);
                miBase.AddInParameter(dbc, "@Descripcion", DbType.String, rol.Descripcion);
                miBase.AddInParameter(dbc, "@IdEstado", DbType.Decimal, rol.IdEstado);
                miBase.AddOutParameter(dbc, "@Id", DbType.Int32, 4);

                miBase.ExecuteNonQuery(dbc);

                rol.Id = (int)miBase.GetParameterValue(dbc, "@Id");
                return (int)rol.Id;
            }
            else throw new ArgumentNullException("rol");
        }
        /// <summary>
        /// Actuliza el rol.
        /// </summary>
        /// <param name="rol">El rol.</param>
        public int ActualizarRol(Rol rol)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (rol != null)
            {
                string sp = string.Format("{0}.spRolActualizar", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Id", DbType.Decimal, rol.Id);
                miBase.AddInParameter(dbc, "@Nombre", DbType.String, rol.Nombre);
                miBase.AddInParameter(dbc, "@Descripcion", DbType.String, rol.Descripcion);
                miBase.AddInParameter(dbc, "@IdEstado", DbType.Decimal, rol.IdEstado);
                
                return miBase.ExecuteNonQuery(dbc);
            }
            else throw new ArgumentNullException("rol");
        }
        /// <summary>
        /// Elimina el rol.
        /// </summary>
        /// <param name="rolId">El rol id.</param>
        public int EliminarRol(int rolId)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (rolId >= 0)
            {
                string sp = string.Format("{0}.spRolEliminar", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Id", DbType.Int32, rolId);

                return miBase.ExecuteNonQuery(dbc);
            }
            else throw new ArgumentNullException("rolId");
        }
        #endregion

        #region Selección Simple
        /// <summary>
        /// Obtiene el rol.
        /// </summary>
        /// <param name="rolId">El rol id.</param>
        /// <returns></returns>
        public Rol ObtenerRol(int rolId)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (rolId >= 0)
            {
                string sp = string.Format("{0}.spRolObtener", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Id", DbType.Int32, rolId);

                Rol rol = new Rol();
                using (IDataReader dataReader = miBase.ExecuteReader(dbc))
                {
                    while (dataReader.Read())
                    {
                        rol = RellenarRolDeLectorIData(dataReader);
                    }
                    dataReader.Close();
                }
                dbc.Dispose();

                return rol;
            }
            else throw new ArgumentNullException("rolId");
        }
        #endregion

        #region Selección múltiple
        /// <summary>
        /// Obtine el rol.
        /// </summary>
        /// <returns></returns>
        public List<Rol> ObtenerRols()
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            string sp = string.Format("{0}.spRolObtenerLista", PropietarioBD);

            DbCommand dbc = miBase.GetStoredProcCommand(sp);
            dbc.CommandType = CommandType.StoredProcedure;

            List<Rol> rols = new List<Rol>();
            using (IDataReader dataReader = miBase.ExecuteReader(dbc))
            {
                while (dataReader.Read())
                {
                    rols.Add(RellenarRolDeLectorIData(dataReader));
                }
                dataReader.Close();
            }
            dbc.Dispose();
            return rols;
        }
        #endregion

        #region Región de Relleno
        /// <summary>
        /// Rellena el rol del IDataReader.
        /// </summary>
        /// <param name="valorData">El registro rol.</param>
        /// <returns></returns>
        public static Rol RellenarRolDeLectorIData(IDataRecord valorData)
        {
            var rol = new Rol();
            if (valorData != null)
            {
                rol.Id = (decimal) valorData["Id"];
                rol.Nombre = (String)valorData["Nombre"];
                rol.Descripcion = (String)valorData["Descripcion"];
                rol.IdEstado = (Decimal)valorData["IdEstado"];
            }
            return rol;
        }
        #endregion
        #endregion
        #region ModulosXRols

        #region Administración
        /// <summary>
        /// Crear el modulosxrol n.
        /// </summary>
        /// <param name="modulosxrol">El modulosxrol.</param>
        /// <returns></returns>
        public int CrearModulosXRol(ModulosXRol modulosxrol)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (modulosxrol != null)
            {
                string sp = string.Format("{0}.spModulosXRolInsertar", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@IdRol", DbType.Decimal, modulosxrol.IdRol);
                miBase.AddInParameter(dbc, "@IdModulo", DbType.Decimal, modulosxrol.IdModulo);
                miBase.AddInParameter(dbc, "@Parametros", DbType.String, modulosxrol.Parametros);
                miBase.AddOutParameter(dbc, "@Id", DbType.Int32, 4);

                miBase.ExecuteNonQuery(dbc);

                modulosxrol.Id = (int)miBase.GetParameterValue(dbc, "@Id");
                return (int)modulosxrol.Id;
            }
            else throw new ArgumentNullException("modulosxrol");
        }
        /// <summary>
        /// Actuliza el modulosxrol.
        /// </summary>
        /// <param name="modulosxrol">El modulosxrol.</param>
        public int ActualizarModulosXRol(ModulosXRol modulosxrol)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (modulosxrol != null)
            {
                string sp = string.Format("{0}.spModulosXRolActualizar", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Id", DbType.Decimal, modulosxrol.Id);
                miBase.AddInParameter(dbc, "@IdRol", DbType.Decimal, modulosxrol.IdRol);
                miBase.AddInParameter(dbc, "@IdModulo", DbType.Decimal, modulosxrol.IdModulo);
                miBase.AddInParameter(dbc, "@Parametros", DbType.String, modulosxrol.Parametros);
                return miBase.ExecuteNonQuery(dbc);
            }
            else throw new ArgumentNullException("modulosxrol");
        }
        /// <summary>
        /// Elimina los modulosxrol.
        /// </summary>
        /// <param name="rolId">El rol id.</param>
        public int EliminarModulosXRolXRol(int rolId)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (rolId >= 0)
            {
                string sp = string.Format("{0}.spModulosXRolEliminar", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@IdRol", DbType.Int32, rolId);

                return miBase.ExecuteNonQuery(dbc);
            }
            else throw new ArgumentNullException("rolId");
        }
        #endregion

        #region Selección Simple
        /// <summary>
        /// Obtiene el modulosxrol.
        /// </summary>
        /// <param name="modulosxrolId">El modulosxrol id.</param>
        /// <returns></returns>
        public ModulosXRol ObtenerModulosXRol(int modulosxrolId)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (modulosxrolId >= 0)
            {
                string sp = string.Format("{0}.spModulosXRolObtener", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Id", DbType.Int32, modulosxrolId);

                ModulosXRol modulosxrol = new ModulosXRol();
                using (IDataReader dataReader = miBase.ExecuteReader(dbc))
                {
                    while (dataReader.Read())
                    {
                        modulosxrol = RellenarModulosXRolDeLectorIData(dataReader);
                    }
                    dataReader.Close();
                }
                dbc.Dispose();

                return modulosxrol;
            }
            else throw new ArgumentNullException("modulosxrolId");
        }
        #endregion

        #region Selección múltiple
        /// <summary>
        /// Obtine el modulosxrol.
        /// </summary>
        /// <returns></returns>
        public List<ModulosXRol> ObtenerModulosXRols(int rolId)
        {
            if (rolId <= 0) throw new ArgumentNullException("rolId");
            try
            {
                Database database = DatabaseFactory.CreateDatabase("basedatos");
                string sql = " SELECT ";
                sql += " IdModulo,Parametros,IdRol";
                sql += " FROM ModulosXRol ";
                sql += " WHERE IdRol=@RolId";


                DbCommand dbc = database.GetSqlStringCommand(sql);
                dbc.CommandType = CommandType.Text;
                database.AddInParameter(dbc, "@RolId", DbType.Int32, rolId);

                List<ModulosXRol> rolmodules = new List<ModulosXRol>();
                using (IDataReader dataReader = database.ExecuteReader(dbc))
                {
                    while (dataReader.Read())
                    {
                        rolmodules.Add(RellenarModulosXRolDeLectorIData(dataReader));
                    }
                    dataReader.Close();
                }
                dbc.Dispose();
                return rolmodules;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Región de Relleno
        /// <summary>
        /// Rellena el modulosxrol del IDataReader.
        /// </summary>
        /// <param name="valorData">El registro modulosxrol.</param>
        /// <returns></returns>
        public static ModulosXRol RellenarModulosXRolDeLectorIData(IDataRecord valorData)
        {
            var modulosxrol = new ModulosXRol();
            if (valorData != null)
            {
                modulosxrol.IdRol = (Decimal)valorData["IdRol"];
                modulosxrol.IdModulo = (Decimal)valorData["IdModulo"];
                modulosxrol.Parametros = (String)valorData["Parametros"];
            }
            return modulosxrol;
        }
        #endregion
        #endregion
        #region Metodos Seguridad

        public bool ValidarCredenciales(string nick, string pass)
        {
            try
            {
                var miBase = DatabaseFactory.CreateDatabase("basedatos");
                

                object obj=miBase.ExecuteScalar(CommandType.Text,
                    "Select * from Usuario where Ecorreo='" + nick + "' and contrasena='" + pass + "' and IdEstado=1");
                if (obj!= null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error SqlProveedorData-InicioSesion");
                return false;
            }
        }
        public Usuario ValidarCredenciales3(string nick, string pass){//funcional
            try
            {
                var miBase = DatabaseFactory.CreateDatabase("basedatos");
                string query = "select id from Usuario where Ecorreo=@Ecorreo";
                DbCommand cmd = miBase.GetSqlStringCommand(query);
                miBase.AddInParameter(cmd, "Ecorreo", DbType.String, nick);
                //miBase.AddInParameter(cmd, "contrasena", DbType.String, pass);

                object obj = miBase.ExecuteScalar(cmd);
                int codigo = Convert.ToInt32(obj);
                cmd.Dispose();

                Usuario oUser = new Usuario();

                if (obj != null)
                {
                    oUser = ObtenerUsuario(codigo);
                    return oUser;
                }
                else
                {
                    return oUser;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error SqlProveedorData-ValidarCredenciales3");
                return null;
            }
        }

        public Usuario ValidarCredenciales2(string nick, string pass)
        {
            try
            {
                var miBase = DatabaseFactory.CreateDatabase("basedatos");
                string query = "select id from Usuario where Ecorreo=@Ecorreo and contrasena=@contrasena";
                DbCommand cmd = miBase.GetSqlStringCommand(query);
                miBase.AddInParameter(cmd, "Ecorreo", DbType.String, nick);
                miBase.AddInParameter(cmd, "contrasena", DbType.String, pass);

                object obj = miBase.ExecuteScalar(cmd);
                int codigo = Convert.ToInt32(obj);
                cmd.Dispose();

                Usuario oUser = new Usuario();

                if (obj != null)
                {
                    oUser=ObtenerUsuario(codigo);
                    return oUser;
                }
                else
                {
                    return oUser;
                }
            }
            catch (Exception){
                Console.WriteLine("Error SqlProveedorData-ValidarCredenciales2");
                return null;
            }
        }

        

        public List<UsuarioPermisos> LeerPermisos(decimal idUsuario)
        {
            try
            {
                List<UsuarioPermisos> listaPermisos= new List<UsuarioPermisos>();
                
                var miBase = DatabaseFactory.CreateDatabase("basedatos");
                string query = "select * from vwUsuarioPermisos where IdUsuario=" + idUsuario;

                using (IDataReader dr=miBase.ExecuteReader(CommandType.Text, query))
                {
                    while (dr.Read())
                    {
                        listaPermisos.Add(LLenarPermisosDeIData(dr));
                    }
                    dr.Close();
                    return listaPermisos;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private UsuarioPermisos LLenarPermisosDeIData(IDataReader dr)
        {
            try
            {
                UsuarioPermisos oUsuarioPermisos= new UsuarioPermisos();
                if (dr != null)
                {
                    oUsuarioPermisos.id = Convert.ToInt32(dr["id"]);
                    oUsuarioPermisos.idUsuario = (decimal) dr["IdUsuario"];
                    oUsuarioPermisos.nick=(string)dr["Nick"];
                    oUsuarioPermisos.descripcion = (string) dr["Descripcion"];
                    oUsuarioPermisos.nombreForm= (string) dr["NombreFormulario"];
                    oUsuarioPermisos.libreriaClase = (string) dr["LibreriaClase"];
                    oUsuarioPermisos.menu = (string) dr["Menu"];
                    oUsuarioPermisos.permisos = (string) dr["Permisos"];
                }
                return oUsuarioPermisos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
                return null;
            }
        }

        
        #endregion
        #region Producto
        public List<Producto> ObtenerProductosVenta(string filtro, decimal estado, Boolean esCodigo)
        {
            var database = DatabaseFactory.CreateDatabase("basedatos");
            var sp = string.Format("{0}.spProductosObtenerParaVenta", PropietarioBD);

            var dbc = database.GetStoredProcCommand(sp);
            dbc.CommandType = CommandType.StoredProcedure;

            if (filtro != null)
                database.AddInParameter(dbc, "@Filtro", DbType.String, filtro.ToUpper());

            database.AddInParameter(dbc, "@Estado", DbType.Decimal, estado);
            database.AddInParameter(dbc, "@EsCodigo", DbType.Boolean, esCodigo);

            var products = new List<Producto>();
            using (var dataReader = database.ExecuteReader(dbc))
            {
                while (dataReader.Read())
                {
                    products.Add(RellenarProductoDeLectorIData(dataReader));
                }
                dataReader.Close();
            }
            dbc.Dispose();

            return products;
        }
        #region Región de Relleno
        /// <summary> Rellena el producto del IDataReader.
        /// </summary>
        /// <param name="valorData">El registro producto.</param>
        /// <returns></returns>
        public static Producto RellenarProductoDeLectorIData(IDataRecord valorData)
        {
            try
            {
                var producto = new Producto();
                if (valorData != null)
                {
                    producto.Id = (Decimal) valorData["Id"];
                    producto.Descripcion = (String)valorData["Descripcion"];
                    producto.DescripcionDetallada = (String)valorData["DescripcionDetallada"];
                    producto.ClaseProducto = (String)valorData["ClaseProducto"];
                    producto.UnidadMedida = (String)valorData["UnidadMedida"];
                    producto.Existencias = (Decimal)valorData["Existencias"];
                    producto.Precio = (Decimal)valorData["Precio"];
                    producto.IdEstado = (Decimal)valorData["IdEstado"];
                    producto.EsGrabado = (Boolean)valorData["EsGrabado"];
                    producto.FechaCreacion = (DateTime)valorData["FechaCreacion"];
                    producto.FechaEdicion = (DateTime)valorData["FechaEdicion"];
                    producto.UsuarioCreacion = (String)valorData["UsuarioCreacion"];
                    producto.UsuarioEdicion = (String)valorData["UsuarioEdicion"];
                }
                return producto;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
            return null;}

        #endregion
        #endregion
        #region Eventos

        #region Selección múltiple
        /// <summary>
        /// Obtine el evento.
        /// </summary>
        /// <returns></returns>
        public List<Evento> ObtenerEventos()
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            string sp = string.Format("{0}.spEventoObtenerLista", PropietarioBD);

            DbCommand dbc = miBase.GetStoredProcCommand(sp);
            dbc.CommandType = CommandType.StoredProcedure;
            List<Evento> eventos = new List<Evento>();
            using (IDataReader dataReader = miBase.ExecuteReader(dbc))
            {
                while (dataReader.Read())
                {
                    eventos.Add(RellenarEventoDeLectorIData(dataReader));
                }
                dataReader.Close();
            }
            dbc.Dispose();
            return eventos;
        }
        #endregion

        #region Región de Relleno
        /// <summary>
        /// Rellena el evento del IDataReader.
        /// </summary>
        /// <param name="valorData">El registro evento.</param>
        /// <returns></returns>
        public static Evento RellenarEventoDeLectorIData(IDataRecord valorData)
        {
            var evento = new Evento();
            if (valorData != null)
            {
                evento.Id = (Decimal)valorData["Id"];
                evento.Descripcion = (String)valorData["Descripcion"];
                evento.IdEstado = (Decimal)valorData["IdEstado"];
            }
            return evento;
        }
        #endregion
        #endregion
        #region Facturacion

        public bool FacturaGuardar(Factura factura)//factura ya debe estar depurada
        {
            var codigoCabecera = FacturaCabeceraGuardar(factura);
            if (codigoCabecera == 0) return false;
            if (!(FacturaDetalleGuardar(codigoCabecera, factura))) return false;

            return true;
        }

        private decimal FacturaCabeceraGuardar(Factura oFactura)
        {
            try
            {
                var db = DatabaseFactory.CreateDatabase("basedatos");
                var sp = db.GetStoredProcCommand(PropietarioBD + "." + "spFacturaCabInsert");
                sp.CommandType = CommandType.StoredProcedure;
               // db.AddInParameter(sp, "@Id", DbType.Decimal, 0); //por el identity
                db.AddInParameter(sp, "@IdCliente", DbType.Decimal, oFactura.idCliente);
                db.AddInParameter(sp, "@FechaFacturacion", DbType.Date, oFactura.fechaFacturacion);
                db.AddInParameter(sp, "@FacturaSRI", DbType.String, oFactura.facturaSRI);
                db.AddInParameter(sp, "@SubTotal", DbType.Decimal, oFactura.subTotal);
                db.AddInParameter(sp, "@IVA", DbType.Decimal, oFactura.iva);
                db.AddInParameter(sp, "@Descuento", DbType.Decimal, oFactura.descuento);
                db.AddInParameter(sp, "@TotalPagar", DbType.Decimal, oFactura.totalPagar);
                db.AddInParameter(sp, "@FechaCreacion", DbType.Date, oFactura.fechaCreacion);
                db.AddInParameter(sp, "@UserCreador", DbType.String, oFactura.userCreador);
                db.AddInParameter(sp, "@Procesado", DbType.Boolean, oFactura.procesado);
                db.AddInParameter(sp, "@EsCancelado", DbType.Boolean, oFactura.esCancelado);
                db.AddInParameter(sp, "@IdSucursal", DbType.Decimal, oFactura.idSucursal);

                db.AddOutParameter(sp, "@Id", DbType.Int32, 4);
                db.ExecuteNonQuery(sp);
                var cod1 = db.GetParameterValue(sp, "@Id");
                //var cod = db.GetParameterValue(sp, "@Id");//valor q retorna Stores procedure es el Id del registro hecho
                return Decimal.Parse(cod1.ToString());}
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return 0;
            }
        }

        private bool FacturaDetalleGuardar(decimal codCabecera, Factura oFactura)
        {
            var db = DatabaseFactory.CreateDatabase("basedatos");


            

            foreach (var d in oFactura.detalles)//lista ya tiene q estar validada
            {
                if (d.idProducto == 0)
                {
                    continue;
                }
                var sp = db.GetStoredProcCommand(PropietarioBD + "." + "spFacturaDetalleInsert");
                sp.CommandType = CommandType.StoredProcedure;
                db.AddInParameter(sp, "@IdFacturaCab", DbType.Decimal, codCabecera); 
                db.AddInParameter(sp, "@linea", DbType.Decimal, d.linea);
                db.AddInParameter(sp, "@IdProducto", DbType.Decimal, d.idProducto);
                db.AddInParameter(sp, "@Cantidad", DbType.Decimal, d.cantidad);
                db.AddInParameter(sp, "@TotalLinea", DbType.Decimal, d.totalLinea);
                db.AddInParameter(sp, "@Iva", DbType.Decimal, d.iva);
                db.AddInParameter(sp, "@DescuentoPorcentaje", DbType.Decimal, d.descuentoPorcentaje);
                db.AddInParameter(sp, "@DescuentoValor", DbType.Decimal, d.descuentoValor);
                db.ExecuteNonQuery(sp);
                decimal cod = (decimal)db.GetParameterValue(sp, "@IdFacturaCab");//valor q retorna Stores procedure es el Id del registro hecho
                sp.Dispose();//importante
                sp.Connection.Close();//importante
                if (cod == 0) return false;
                
                
            }

           
                
            return true;
        }

        public Producto ObtenerProductoParaFactura(decimal codigo) //funcional
        {
            try
            {
                //if (codigo==0)
                //{
                //    return null;
                //}
                Producto p = new Producto();
                Database db = DatabaseFactory.CreateDatabase("basedatos"); //ver app.config
                using (IDataReader dataReader = db.ExecuteReader(PropietarioBD +"."+"spProductoObtenerParaFactura", codigo))
                {
                    if (dataReader.Read())
                    {
                        p = LlenarProductoDeIData(dataReader);
                    }
                }
                return p;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        private Producto LlenarProductoDeIData(IDataReader datos)
        {
            try
            {
                Producto pro = new Producto();
                if (datos != null)
                {
                    pro.Id = (decimal) datos["Id"];
                    pro.Descripcion = (string) datos["Descripcion"];
                    pro.DescripcionDetallada = (string) datos["DescripcionDetallada"];
                    pro.UnidadMedida = (string)datos["UnidadMedida"];
                    pro.Existencias = (decimal) datos["Existencias"];
                    pro.Precio = (decimal) datos["Precio"];
                    //if (!string.IsNullOrEmpty(datos["cantidad"].ToString()))
                    //{
                    //    oProducto.cantidad = (int)datos["Cantidad"];
                    //}
                }
                return pro;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        #endregion
        #region Pedidos

        #region Administración
        public bool CrearOrdenEspecial(OrdenEspecialCab factura)//factura ya debe estar depurada
        {
            var codigoCabecera = CrearOrdenEspecialCab(factura);
            if (codigoCabecera == 0) return false;
            return CrearOrdenEspecialDet(codigoCabecera, factura);
        }

        private decimal CrearOrdenEspecialCab(OrdenEspecialCab ordenespecialcab)
        {
            try
            {
                var miBase = DatabaseFactory.CreateDatabase("basedatos");
                var dbc = miBase.GetStoredProcCommand(PropietarioBD + "." + "spOrdenEspecialCabInsertar");
                dbc.CommandType = CommandType.StoredProcedure;
                // db.AddInParameter(sp, "@Id", DbType.Decimal, 0); //por el identity
                miBase.AddInParameter(dbc, "@IdCliente", DbType.Decimal, ordenespecialcab.IdCliente);
                miBase.AddInParameter(dbc, "@SubTotal", DbType.Decimal, ordenespecialcab.SubTotal);
                miBase.AddInParameter(dbc, "@Iva", DbType.Decimal, ordenespecialcab.Iva);
                miBase.AddInParameter(dbc, "@Abono", DbType.Decimal, ordenespecialcab.Abono);
                miBase.AddInParameter(dbc, "@FechaEntrega", DbType.DateTime, ordenespecialcab.FechaEntrega);
                miBase.AddInParameter(dbc, "@FechaCreacion", DbType.DateTime, ordenespecialcab.FechaCreacion);
                miBase.AddInParameter(dbc, "@UserCreador", DbType.String, ordenespecialcab.UserCreador);
                miBase.AddInParameter(dbc, "@IdEstado", DbType.Decimal, ordenespecialcab.IdEstado);

                miBase.AddOutParameter(dbc, "@Id", DbType.Int32, 4);
                miBase.ExecuteNonQuery(dbc);
                ordenespecialcab.Id = (int)miBase.GetParameterValue(dbc, "@Id");
                //var cod = db.GetParameterValue(sp, "@Id");//valor q retorna Stores procedure es el Id del registro hecho
                return ordenespecialcab.Id;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return 0;
            }
        }

        private bool CrearOrdenEspecialDet(decimal codCabecera, OrdenEspecialCab oFactura)
        {
            var _Db = DatabaseFactory.CreateDatabase("basedatos");
            var dbc = _Db.GetStoredProcCommand(PropietarioBD + "." + "spOrdenEspecialDetalleInsertar");
            dbc.CommandType = CommandType.StoredProcedure;


            foreach (var d in oFactura.Detalles)//lista ya tiene q estar validada
            {
                if (d.IdProducto == 0)
                {
                    continue;
                }
                _Db.AddInParameter(dbc, "@IdOrdenEspecialCab", DbType.Decimal, codCabecera);
                _Db.AddInParameter(dbc, "@Linea", DbType.Decimal, d.Linea);
                _Db.AddInParameter(dbc, "@IdProducto", DbType.Decimal, d.IdProducto);
                _Db.AddInParameter(dbc, "@Cantidad", DbType.Decimal, d.Cantidad);
                _Db.AddInParameter(dbc, "@IdEvento", DbType.Decimal, d.IdEvento);
                _Db.AddInParameter(dbc, "@Color", DbType.String, d.Color);
                _Db.AddInParameter(dbc, "@Leyenda", DbType.String, d.Leyenda);
                _Db.AddInParameter(dbc, "@Imagen", DbType.Binary, d.Imagen);
                _Db.AddInParameter(dbc, "@Observaciones", DbType.String, d.Observaciones);
                _Db.ExecuteNonQuery(dbc);
                decimal cod = (decimal)_Db.GetParameterValue(dbc, "@IdOrdenEspecialCab");//valor q retorna Stores procedure es el Id del registro hecho
                if (cod == 0) return false;
            }
            return true;
        }
        /// <summary>
        /// Crear el ordenespecialcab n.
        /// </summary>
        /// <param name="ordenespecialcab">El ordenespecialcab.</param>
        /// <returns></returns>
        //public int CrearOrdenEspecialCab(OrdenEspecialCab ordenespecialcab)
        //{
        //    var miBase = DatabaseFactory.CreateDatabase("basedatos");
        //    if (ordenespecialcab != null)
        //    {
        //        string sp = string.Format("{0}.spOrdenEspecialCabInsertar", PropietarioBD);

        //        DbCommand dbc = miBase.GetStoredProcCommand(sp);
        //        dbc.CommandType = CommandType.StoredProcedure;

        //        miBase.AddInParameter(dbc, "@IdCliente", DbType.Decimal, ordenespecialcab.IdCliente);
        //        miBase.AddInParameter(dbc, "@SubTotal", DbType.Decimal, ordenespecialcab.SubTotal);
        //        miBase.AddInParameter(dbc, "@Iva", DbType.Decimal, ordenespecialcab.Iva);
        //        miBase.AddInParameter(dbc, "@Abono", DbType.Decimal, ordenespecialcab.Abono);
        //        miBase.AddInParameter(dbc, "@FechaEntrega", DbType.DateTime, ordenespecialcab.FechaEntrega);
        //        miBase.AddInParameter(dbc, "@FechaCreacion", DbType.DateTime, ordenespecialcab.FechaCreacion);
        //        miBase.AddInParameter(dbc, "@UserCreador", DbType.String, ordenespecialcab.UserCreador);
        //        miBase.AddInParameter(dbc, "@IdEstado", DbType.Decimal, ordenespecialcab.IdEstado);
        //        miBase.AddOutParameter(dbc, "@Id", DbType.Int32, 4);

        //        miBase.ExecuteNonQuery(dbc);

        //        ordenespecialcab.Id = (int)miBase.GetParameterValue(dbc, "@Id");
        //        return ordenespecialcab.Id;
        //    }
        //    else throw new ArgumentNullException("ordenespecialcab");
        //}
        /// <summary>
        /// Actuliza el ordenespecialcab.
        /// </summary>
        /// <param name="ordenespecialcab">El ordenespecialcab.</param>
        public void ActualizarOrdenEspecialCab(OrdenEspecialCab ordenespecialcab)
        {
            var miBase = DatabaseFactory.CreateDatabase("basedatos");
            if (ordenespecialcab != null)
            {
                string sp = string.Format("{0}.spOrdenEspecialCabActualizar", PropietarioBD);

                DbCommand dbc = miBase.GetStoredProcCommand(sp);
                dbc.CommandType = CommandType.StoredProcedure;

                miBase.AddInParameter(dbc, "@Id", DbType.Int32, ordenespecialcab.Id);
                miBase.AddInParameter(dbc, "@IdCliente", DbType.Decimal, ordenespecialcab.IdCliente);
                miBase.AddInParameter(dbc, "@SubTotal", DbType.Decimal, ordenespecialcab.SubTotal);
                miBase.AddInParameter(dbc, "@Iva", DbType.Decimal, ordenespecialcab.Iva);
                miBase.AddInParameter(dbc, "@Abono", DbType.Decimal, ordenespecialcab.Abono);
                miBase.AddInParameter(dbc, "@FechaEntrega", DbType.DateTime, ordenespecialcab.FechaEntrega);
                miBase.AddInParameter(dbc, "@FechaCreacion", DbType.DateTime, ordenespecialcab.FechaCreacion);
                miBase.AddInParameter(dbc, "@UserCreador", DbType.String, ordenespecialcab.UserCreador);
                miBase.AddInParameter(dbc, "@IdEstado", DbType.Decimal, ordenespecialcab.IdEstado);

                miBase.ExecuteNonQuery(dbc);

                return;
            }
            else throw new ArgumentNullException("ordenespecialcab");
        }
        
        #endregion

        #region Selección Simple
        
        #endregion

        #region Selección múltiple
        
        #endregion

        #region Región de Relleno
        /// <summary>
        /// Rellena el ordenespecialcab del IDataReader.
        /// </summary>
        /// <param name="valorData">El registro ordenespecialcab.</param>
        /// <returns></returns>
        public static OrdenEspecialCab RellenarOrdenEspecialCabDeLectorIData(IDataRecord valorData)
        {
            var ordenespecialcab = new OrdenEspecialCab();
            if (valorData != null)
            {
                ordenespecialcab.IdCliente = (Decimal)valorData["IdCliente"];
                ordenespecialcab.SubTotal = (Decimal)valorData["SubTotal"];
                ordenespecialcab.Iva = (Decimal)valorData["Iva"];
                ordenespecialcab.Abono = (Decimal)valorData["Abono"];
                ordenespecialcab.FechaEntrega = (DateTime)valorData["FechaEntrega"];
                ordenespecialcab.FechaCreacion = (DateTime)valorData["FechaCreacion"];
                ordenespecialcab.UserCreador = (String)valorData["UserCreador"];
                ordenespecialcab.IdEstado = (Decimal)valorData["IdEstado"];
            }
            return ordenespecialcab;
        }
        #endregion
        #endregion
    }
}
