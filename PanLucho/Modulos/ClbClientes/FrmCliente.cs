using System;

using System.Windows.Forms;
using Componentes.Comun;
using Componentes.NivelMedio.Transacciones;
using Componentes.Transaccion;
using Controles;

namespace ClbClientes
{
    public partial class FrmCliente : frmMantenimiento
    {
        public int Codigo;
        public string UsuarioCreacion;
        public DateTime FechaCreacion;
        public Cliente Cliente=new Cliente(); 
        

        public string Identification { get; set; }
        public FrmCliente()
        {
            InitializeComponent();
            //dtpFechaNacimiento.Value = DateTime.Now;
            txtIdentificacion.Text = Parametros;

            txtIdentificacion.KeyPress += Comun.SoloNumeros;
            txtNombre.KeyPress += Comun.SoloLetras;
            txtApellido.KeyPress += Comun.SoloLetras;
            
        }
        


        

        protected override void Nuevo()
        {
            base.Nuevo();
            txtIdentificacion.Focus();
            txtIdentificacion.Text = Identification;
            //cbxTipo.SelectedIndex = 0;
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
            if (string.IsNullOrEmpty(txtIdentificacion.Text))
            {
                errorProvider1.SetError(txtIdentificacion, "Ingrese Numero de Cedula");
                valid = false;
            }

            
            if (valid)
                try
                {
                    switch (FormModoParametro)
                    {
                        case FormModo.Predeterminado:
                            {
                                if (MessageBox.Show("Esta seguro de Grabar?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    return;
                                var cliente = new Cliente
                                                   {
                                                       Nombre = txtNombre.Text,
                                                       Apellido = txtApellido.Text,
                                                       NumeroIdentificacion = txtIdentificacion.Text,
                                                       Ecorreo = txtECorreo.Text,
                                                       FechaNacimiento = dtpFechaNacimiento.Value,
                                                       Estado = 1,
                                                       FechaCreacion = DateTime.Now,
                                                       FechaModificacion = DateTime.Now,
                                                       UsuarioCreacion = "variable",
                                                       UsuarioActualizacion = "variable",
                                                   };
                                switch (txtIdentificacion.Text.Length)
                                {
                                    case 10:
                                        cliente.TipoIdentificacion = "C"; break;
                                    case 13:
                                        cliente.TipoIdentificacion = "R"; break;
                                    default:
                                        cliente.TipoIdentificacion = "P"; break;
                                }

                                var codigo = Clientes.Crear(cliente);
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
                                var cliente = new Cliente
                                                   {
                                                       Id = Codigo,
                                                       Nombre = txtNombre.Text,
                                                       Apellido = txtApellido.Text,
                                                       NumeroIdentificacion = txtIdentificacion.Text,
                                                       
                                                       Ecorreo = txtECorreo.Text,
                                                       FechaNacimiento = dtpFechaNacimiento.Value,
                                                       Estado = 1,
                                                       FechaCreacion = DateTime.Now,
                                                       FechaModificacion = DateTime.Now,
                                                       UsuarioCreacion = "vari",
                                                       UsuarioActualizacion = "variableLogin"
                                                   };
                                switch (txtIdentificacion.Text.Length)
                                {
                                    case 10:
                                        cliente.TipoIdentificacion = "C"; break;
                                    case 13:
                                        cliente.TipoIdentificacion = "R"; break;
                                    default:
                                        cliente.TipoIdentificacion = "P"; break;
                                }
                                Clientes.Actualizar(cliente);
                                Cliente = cliente;
                                LimpiarContenidoControles();
                                MessageBox.Show("Datos Modificados con Exito", Application.ProductName,
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                FormModoParametro=FormModo.Nuevo;

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
            fcon.gridControl1.DataSource = Clientes.ObtenerLista();
            fcon.ShowDialog();
            var oCliente = new Cliente();
            if (fcon.oGenerico!=null)
            {
                oCliente = (Cliente) fcon.oGenerico;
                Codigo = oCliente.Id;
                txtIdentificacion.Text = oCliente.NumeroIdentificacion;
                txtNombre.Text = oCliente.Nombre;
                txtApellido.Text = oCliente.Apellido;
                dtpFechaNacimiento.Value =(DateTime) oCliente.FechaNacimiento;
                txtECorreo.Text = oCliente.Ecorreo;
                this.FormModoParametro=FormModo.Edicion;
            }
        }

        protected override void Eliminar()
        {
            base.Eliminar();
            Clientes.Eliminar(Codigo);
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            BotonesSegunPermisos();//copy seguridad
        }
      
    }
}
