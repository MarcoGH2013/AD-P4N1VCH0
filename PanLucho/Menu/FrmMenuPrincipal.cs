using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClbCierreCaja;
using ClbClientes;
using ClbFacturas;
using ClbPedidosEspeciales;
using ClbRoles;
using ClbUsuarios;


namespace Menu
{
    public partial class FrmMenuPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private FrmSesion oFrmSesion= new FrmSesion();

        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void iSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Application.Exit();
                this.Dispose(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void iClientes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                 FrmCliente f = new FrmCliente();
                    f.MdiParent = this;
                    f.Show();   
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Si sale se cerrará su sesión, esta seguro que desea salir del programa? ", "Pan Lucho™", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void FrmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["FrmSesion"] != null)
            {
                oFrmSesion.Visible = true;
                oFrmSesion.Activate();
            }
        }

        private void iCierreCaja_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //this.MdiParent = null;
                FrmCierreCaja f = new FrmCierreCaja();
                f.MdiParent = this;
                f.Show();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void iCerrarSesion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void iUsuarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //this.MdiParent = null;
                FrmUsuarios f = new FrmUsuarios();
                f.MdiParent = this;
               // f.StartPosition = FormStartPosition.CenterScreen;
                f.Show();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void iRoles_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FrmRoles f = new FrmRoles();
                f.MdiParent = this;
                f.Show();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void iFactura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FrmFactura f = new FrmFactura();
                f.MdiParent = this;
                f.Show();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void iPedidoEspecial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FrmPedidosEspeciales f = new FrmPedidosEspeciales();
                f.MdiParent = this;
                f.Show();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private bool noChild()
        {
            Form[] fcChild = MdiChildren;
            if (fcChild.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
