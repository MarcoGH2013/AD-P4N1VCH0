//using System;

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Componentes.Comun;
using Componentes.NivelMedio.Transacciones;
using Componentes.Transaccion;
using Controles;
using Componentes;

namespace ClbUsuarios
{
    public partial class FrmUsuarios : frmMantenimiento
    {
        public decimal Codigo;
        public FrmUsuarios()
        {
            InitializeComponent();
            txtNombre.KeyPress += Comun.SoloLetras;
            txtApellido.KeyPress += Comun.SoloLetras;
        }
        protected override void Nuevo()
        {
            base.Nuevo();
            txtUsuario.Focus();
        }

        protected override void Guardar()
        {
            base.Guardar();
            var valid = true;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Debe de Ingresar Nombre de Cliente");
                valid = false;
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                errorProvider1.SetError(txtApellido, "Debe de Ingresar Apellido del Cliente");
                valid = false;
            }
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                errorProvider1.SetError(txtUsuario, "Ingrese Nombre de Usuario");
                valid = false;
            }
            if (string.IsNullOrEmpty(txtContraseña.Text))
            {
                errorProvider1.SetError(txtContraseña, "Ingrese Contrasena");
                valid = false;
            }
            if (txtContraseña.Text!=txtRepetir.Text)
            {
                errorProvider1.SetError(txtContraseña, "Repeticion de contraseñas distintas");
                valid = false;
            }
            if (valid)
                try
                {
                    switch (FormModoParametro)
                    {
                        case FormModo.Predeterminado:
                            {
                            //C:\Users\kerberos\Documents\Visual Studio 2010\Projects\PanLucho\Modulos\ClbCierreCaja\Class3.cs
                                if (MessageBox.Show("Esta seguro de Grabar?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    return;
                                var cliente = new Usuario
                                {
                                    Nombre = txtNombre.Text,
                                    Apellido = txtApellido.Text,
                                    Identificacion = txtUsuario.Text,
                                    Ecorreo = txtECorreo.Text,
                                    Contrasena = txtContraseña.Text,
                                    IdEstado = 1,
                                    FechaCreacion = DateTime.Now,
                                    FechaEdicion = DateTime.Now,
                                    IdRol =cbxRol.SelectedIndex+1,
                                    
                                };
                                
                                var codigo = Usuarios.Crear(cliente);
                                LimpiarContenidoControles();
                                MessageBox.Show("Datos Guardados con Exito", Application.ProductName,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                                //Dispose();
                                //Cliente = Clientes.Obtener(codigo);


                                break;
                            }

                        case FormModo.Edicion:
                            {
                                if (
                                    MessageBox.Show("Está seguro de actualizar?", Application.ProductName,
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    return;
                                var cliente = new Usuario
                                {
                                    Id = Codigo,
                                    Nombre = txtNombre.Text,
                                    Apellido = txtApellido.Text,
                                    Identificacion = txtUsuario.Text,
                                    Ecorreo = txtECorreo.Text,
                                    Contrasena = txtContraseña.Text,
                                    IdEstado = 1,
                                    FechaCreacion = DateTime.Now,
                                    FechaEdicion = DateTime.Now,
                                    IdRol = cbxRol.SelectedIndex + 1,
                                };
                                
                                Usuarios.Actualizar(cliente);
                                //Usuario = cliente;
                                LimpiarContenidoControles();
                                MessageBox.Show("Datos Modificados con Exito", Application.ProductName,
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                FormModoParametro = FormModo.Nuevo;

                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + "Error al Guardar los Datos", Application.ProductName,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        protected override void Buscar()
        {
            base.Buscar();
            frmConsulta fcon = new frmConsulta();
            fcon.gridControl1.DataSource = Usuarios.ObtenerLista();
            fcon.ShowDialog();
            var oCliente = new Usuario();
            if (fcon.oGenerico != null)
            {
                oCliente             = (Usuario)fcon.oGenerico;
                Codigo               = oCliente.Id;
                txtUsuario.Text      = oCliente.Identificacion;
                txtNombre.Text       = oCliente.Nombre;
                cbxRol.SelectedIndex = int.Parse((oCliente.IdRol - 1).ToString());
                txtApellido.Text     = oCliente.Apellido;
                txtContraseña.Text   = oCliente.Contrasena;
                txtECorreo.Text      = oCliente.Ecorreo;
                this.FormModoParametro = FormModo.Edicion;
            }

        }

        protected override void Eliminar()
        {
            base.Eliminar();
            Usuarios.Eliminar(int.Parse(Codigo.ToString("G")));//new
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            //BotonesSegunPermisos();//copy seguridad
        }

    }
}
