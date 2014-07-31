using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Windows.Forms;
using ClbCierreCaja;
using ClbClientes;
using ClbFacturas;
using ClbPedidosEspeciales;
using ClbRoles;
using ClbUsuarios;
using Componentes.Transaccion;
using DevExpress.XtraBars;


namespace Menu
{
    public partial class FrmMenuPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private FrmSesion oFrmSesion= new FrmSesion();
        private Form[] hijos;
        //public List<UsuarioPermisos> lstUsuarioPermisos = new List<UsuarioPermisos>(); 
        

        public static List<UsuarioPermisos> permissionsAll = new List<UsuarioPermisos>();
        public static Usuario usuarioInformacion = new Usuario();
        private void CargarPermisos()
        {
            permissionsAll = FrmSesion.LstUsuarioPermisos;
            usuarioInformacion = FrmSesion.oUsuarioInformacion;
            toolStripStatusLabel1.Text = "Bienvenido a su sesión " + usuarioInformacion.Nombre + " " + usuarioInformacion.Apellido
                +" - " + usuarioInformacion.Ecorreo;
        }

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

        private void iClientes_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                hijos = MdiChildren;
                bool mostrar = true;
                if (hijos.Count() != 0)
                {
                    foreach (var frm in MdiChildren)
                    {
                        if (frm.GetType() == typeof(FrmCliente))
                        {
                            MessageBox.Show("La ventana se encuentra abierta", "Pan Lucho™", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            frm.Focus();
                            mostrar = false;
                        }
                    }
                }
                if (mostrar == true)
                {
                    FrmCliente f = new FrmCliente();
                    f.MdiParent = this;
                    f.Show();
                }
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
                hijos = MdiChildren;
                bool mostrar = true;
                if (hijos.Count() != 0)
                {
                    foreach (var frm in MdiChildren)
                    {
                        if (frm.GetType() == typeof(FrmCierreCaja))
                        {
                            MessageBox.Show("La ventana se encuentra abierta", "Pan Lucho™", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            frm.Focus();
                            mostrar = false;
                        }
                    }
                }
                if (mostrar == true)
                {
                    FrmCierreCaja f = new FrmCierreCaja();
                    f.MdiParent = this;
                    f.Show();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void iCerrarSesion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void iUsuarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                hijos = MdiChildren;
                bool mostrar = true;
                if (hijos.Count() != 0)
                {
                    foreach (var frm in MdiChildren)
                    {
                        if (frm.GetType() == typeof(FrmUsuarios))
                        {
                            MessageBox.Show("La ventana se encuentra abierta", "Pan Lucho™", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            frm.Focus();
                            mostrar = false;
                        }
                    }
                }
                if (mostrar == true)
                {
                    FrmUsuarios f = new FrmUsuarios();
                    f.MdiParent = this;
                    f.Show();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "....Sin conexión...";
            CargarPermisos();
        }

        private void iRoles_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                hijos = MdiChildren;
                bool mostrar = true;
                if (hijos.Count() != 0)
                {
                    foreach (var frm in MdiChildren)
                    {
                        if (frm.GetType() == typeof(FrmRoles))
                        {
                            MessageBox.Show("La ventana se encuentra abierta", "Pan Lucho™", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            frm.Focus();
                            mostrar = false;
                        }
                    }
                }
                if (mostrar == true)
                {
                    FrmRoles f = new FrmRoles();
                    f.MdiParent = this;
                    f.Show();
                }
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
                hijos = MdiChildren;
                bool mostrar = true;
                if (hijos.Count() != 0)
                {
                    foreach (var frm in MdiChildren)
                    {
                        if (frm.GetType() == typeof(FrmFactura))
                        {
                            MessageBox.Show("La ventana se encuentra abierta", "Pan Lucho™", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            frm.Focus();
                            mostrar = false;
                        }
                    }
                }
                if (mostrar == true)
                {
                    FrmFactura f = new FrmFactura();
                    f.MdiParent = this;
                    f.Show();
                }
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
                hijos = MdiChildren;
                bool mostrar = true;
                if (hijos.Count() != 0)
                {
                    foreach (var frm in MdiChildren)
                    {
                        if (frm.GetType() == typeof(FrmPedidosEspeciales))
                        {
                            MessageBox.Show("La ventana se encuentra abierta", "Pan Lucho™", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            frm.Focus();
                            mostrar = false;
                        }
                    }
                }
                if (mostrar == true)
                {
                    FrmPedidosEspeciales f = new FrmPedidosEspeciales();
                    f.MdiParent = this;
                    f.Show();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

       
        private void iReporteFacturas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                hijos = MdiChildren;
                bool mostrar = true;
                if (hijos.Count() != 0)
                {
                    foreach (var frm in MdiChildren)
                    {
                        if (frm.GetType() == typeof(FrmReporteFactura))
                        {
                            MessageBox.Show("La ventana se encuentra abierta", "Pan Lucho™", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            frm.Focus();
                            mostrar = false;
                        }
                    }
                }
                if (mostrar == true)
                {
                    FrmReporteFactura f = new FrmReporteFactura();
                    f.MdiParent = this;
                    f.Show();
                }
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
