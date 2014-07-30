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
        public List<UsuarioPermisos> LstPermisos= new List<UsuarioPermisos>();
        public FrmSesion()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(txtUser.Text)) || (string.IsNullOrWhiteSpace(txtPass.Text)))
            {MessageBox.Show("Falta uno o más campos", "Pan Lucho™", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                IntentoInicio(txtUser.Text, txtPass.Text);
                //FrmMenuPrincipal f = new FrmMenuPrincipal();
                //f.Show();
                //f.WindowState=FormWindowState.Maximized;
                //if (Application.OpenForms["FrmMenuPrincipal"] != null)
                //{
                //    this.Visible = false;
                //}
                //else
                //{
                //    this.Visible = true;
                //}
            }
        }

        private void IntentoInicio(string nick, string contrasena)
        {
            Usuario oUsuario = new Usuario();
            oUsuario = oSqlProveedorData.ValidarCredenciales2(nick, contrasena);
            if (oUsuario.Nombre!=null)
            {
                MessageBox.Show("BIENVENIDO !!!! " + oUsuario.Nombre + " " + oUsuario.Apellido);
                LstPermisos = oSqlProveedorData.LeerPermisos(oUsuario.Id);
                MessageBox.Show(LstPermisos.ToString());
            }
            //if (oSqlProveedorData.ValidarCredenciales2(nick, contrasena))
            //{
            //    MessageBox.Show("Usuario encontrado");

            //}
            //else
            //{
            //    MessageBox.Show("Usuario no existe o esta deshabilitado");
            //}            
        }

        private void FrmSesion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}