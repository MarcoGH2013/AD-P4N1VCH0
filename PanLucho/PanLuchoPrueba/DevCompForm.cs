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

namespace PanLuchoPrueba
{
    public partial class DevCompForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public DevCompForm()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.IsEmpty() || txtPass.Text.IsEmpty())
            {
                MessageBox.Show("Falta uno o más campos", "Pan Lucho" , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                FrmMenuPrincipal f=new FrmMenuPrincipal();
                f.Show();
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
    }
}