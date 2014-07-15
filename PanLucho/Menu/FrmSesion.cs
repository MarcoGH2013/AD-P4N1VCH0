using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevExpress.XtraPrinting.Native;
using Menu;

namespace Menu
{
    public partial class FrmSesion : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FrmSesion()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(txtUser.Text)) || (string.IsNullOrWhiteSpace(txtPass.Text)))
            {
                MessageBox.Show("Falta uno o más campos", "Pan Lucho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                FrmMenuPrincipal f = new FrmMenuPrincipal();
                f.Show();
                f.WindowState=FormWindowState.Maximized;
                if (Application.OpenForms["FrmMenuPrincipal"] != null)
                {
                    this.Visible = false;
                }
                else
                {
                    this.Visible = true;
                }
            }
        }

        private void FrmSesion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}