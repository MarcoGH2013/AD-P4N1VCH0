using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Componentes.ProveedorData;
using Componentes.Transaccion;
using DevComponents.DotNetBar;
using DevExpress.XtraPrinting.Native;
using Menu;

namespace Menu
{
    public partial class FrmSesion : DevComponents.DotNetBar.Metro.MetroForm
    {
        private SqlProveedorData oSqlProveedorData = new SqlProveedorData();
        public static List<UsuarioPermisos> LstUsuarioPermisos = new List<UsuarioPermisos>();
        public static Usuario oUsuarioInformacion = new Usuario();

        public FrmSesion()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrWhiteSpace(txtUser.Text)) || (string.IsNullOrWhiteSpace(txtPass.Text)))
                {
                    MessageBox.Show("Falta uno o más campos", "Pan Lucho™", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //IntentoInicio(txtUser.Text, txtPass.Text);
                    oUsuarioInformacion = oSqlProveedorData.ValidarCredenciales2(txtUser.Text, txtPass.Text);
                    if (oUsuarioInformacion==null)
                    {
                        MessageBox.Show("Nombre de usuario y/o clave incorrecta, recuerde que su nombre de usuario es su correo electrónico", "Pan Lucho™", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (oUsuarioInformacion.IdEstado != 1)
                    {
                        MessageBox.Show("El usuario " + oUsuarioInformacion.Nombre + " NO se encuentra habilitado, consulte con el administrador del sistema", "Pan Lucho™", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        IntentoInicio();
                    }

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show( "Lo sentimos, imposible conectar, inténtelo más tarde o consulte con el administrador del sistema ", "Pan Lucho™", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Pasando parametros al menu principal
        private void IntentoInicio()
        {
            if (oUsuarioInformacion.Nombre != null)
            {
                //MessageBox.Show("BIENVENIDO !!!! " + oUsuarioInformacion.Nombre + " " + oUsuarioInformacion.Apellido);
                LstUsuarioPermisos = oSqlProveedorData.LeerPermisos(oUsuarioInformacion.Id);
                FrmMenuPrincipal f = new FrmMenuPrincipal();
                f.Show();
                f.WindowState = FormWindowState.Maximized;
                if (Application.OpenForms["FrmMenuPrincipal"] != null)
                {
                    this.Visible = false;
                }
                else
                {
                    this.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Nombre de usuario y/o clave incorrecta, recuerde que su nombre de usuario es su correo electrónico", "Pan Lucho™", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        private void FrmSesion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}