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
using Controles;
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
        private List<UsuarioPermisos> LstUsuarioPermisos;
        private Usuario oUsuarioInformacion;
        
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
            CargarPermisos();
        }

        private void iSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Application.Exit();
                //this.Dispose(true);
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
                            //f.Parametros = p.permisos;
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
                    foreach (var p in permissionsAll)
                    {
                        if (p.libreriaClase+"."+p.nombreForm == typeof(FrmUsuarios).ToString())
                        {
                            FrmUsuarios f = new FrmUsuarios();
                            f.Parametros = p.permisos;
                            f.MdiParent = this;
                            f.Show();
                            break;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Bienvenido a su sesión " + usuarioInformacion.Nombre + " " + usuarioInformacion.Apellido
                                             + " - " + usuarioInformacion.Ecorreo;
            cargarMenus();
        }


        private void cargarMenus()
        {
            foreach (var per in permissionsAll)
            {
                String frmPermitido = per.libreriaClase + "." + per.nombreForm;
                if (per.menu == ribbonPage2.Text) //SEGURIDAD
                {
                    if (this.ribbonPage2.Visible== false)
                    {
                        this.ribbonPage2.Visible = true;
                        this.ribbonPageGroup2.Visible = true;
                    }
                    
                    if (frmPermitido == typeof(FrmUsuarios).ToString())
                    {
                        this.iUsuarios.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    if (frmPermitido == typeof(FrmRoles).ToString())
                    {
                        this.iRoles.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                }

                if (per.menu == ribbonPage3.Text) //VENTAS
                {
                    if (this.ribbonPage3.Visible==false)
                    {
                        this.ribbonPage3.Visible = true;
                        this.ribbonPageGroup4.Visible = true;
                        this.ribbonPageGroup3.Visible = true;
                        this.ribbonPageGroup5.Visible = true;

                    }

                    if (frmPermitido == typeof(FrmFactura).ToString())
                    {
                        this.iFactura.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    if (frmPermitido == typeof(FrmCliente).ToString())
                    {
                        this.iClientes.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    if (frmPermitido == typeof(FrmPedidosEspeciales).ToString())
                    {
                        this.iPedidoEspecial.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    if (frmPermitido == typeof(FrmReporteFactura).ToString())
                    {
                        this.iReporteFacturas.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                }

                if (per.menu == ribbonPage4.Text) //INVENTARIO
                {
                    if (this.ribbonPage4.Visible == false)
                    {
                        this.ribbonPage4.Visible = true;
                        this.rpgPedidos.Visible = true;
                    }
                }

                if (per.menu == ribbonPage5.Text) //GASTOS-PAGOS
                {
                    if (this.ribbonPage5.Visible == false)
                    {
                        this.ribbonPage5.Visible = true;
                        this.ribbonPageGroup6.Visible = true;
                    }

                    if (frmPermitido == typeof(FrmCierreCaja).ToString())
                    {
                        this.iCierreCaja.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                }
            }
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
                           // MessageBox.Show("La ventana se encuentra abierta", "Pan Lucho™", MessageBoxButtons.OK,MessageBoxIcon.Information);
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
                            //MessageBox.Show("La ventana se encuentra abierta", "Pan Lucho™", MessageBoxButtons.OK,MessageBoxIcon.Information);
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
                            //MessageBox.Show("La ventana se encuentra abierta", "Pan Lucho™", MessageBoxButtons.OK,MessageBoxIcon.Information);
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
                         //   MessageBox.Show("La ventana se encuentra abierta", "Pan Lucho™", MessageBoxButtons.OK,MessageBoxIcon.Information);
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

        #region Codigo obsoleto
        private String dividirCadena(String cadena)//sin uso
        {
            String[] clase = cadena.Split(',');//ej: ClbUsuario.FrmUsuarios, Text: Permite la administracion de usuarios
            return clase[0];//ej: ClbUsuarios.FrmUsuarios
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
        #endregion        

    }
}
