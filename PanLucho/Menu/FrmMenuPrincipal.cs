using System;
using System.Collections.Generic;
using System.ComponentModel;using System.Data;
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
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Controls;


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
                this.Dispose(true);
                Application.Exit();
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
                            //MessageBox.Show("La ventana se encuentra abierta", "Pan Lucho™", MessageBoxButtons.OK,
                            //    MessageBoxIcon.Information);
                            frm.Focus();
                            mostrar = false;
                        }
                    }
                }
                if (mostrar == true)
                {
                            var permiso = (from a in permissionsAll
                                           where
                                               a.libreriaClase == typeof(FrmCliente).Namespace &&
                                               a.nombreForm == typeof(FrmCliente).Name
                                           select a.permisos).First();
                            FrmCliente f = new FrmCliente() { Tag = permiso }; //llamar en evento Load a: BotonesSegunPermisos();
                            //f.Parametros = permiso;//enviando ej: c|r|u|d
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
               // this.Close();
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
                            //MessageBox.Show("La ventana se encuentra abierta", "Pan Lucho™", MessageBoxButtons.OK,
                            //    MessageBoxIcon.Information);
                            frm.Focus();
                            mostrar = false;
                        }
                    }
                }
                if (mostrar == true)
                {
                    var permiso = (from a in permissionsAll
                                   where
                                       a.libreriaClase == typeof(FrmCierreCaja).Namespace &&
                                       a.nombreForm == typeof(FrmCierreCaja).Name
                                   select a.permisos).First();
                    FrmCierreCaja f = new FrmCierreCaja() { Tag = permiso };
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
                            //MessageBox.Show("La ventana se encuentra abierta", "Pan Lucho™", MessageBoxButtons.OK,
                            //    MessageBoxIcon.Information);
                            frm.Focus();
                            mostrar = false;
                        }
                    }
                }
                if (mostrar == true)
                {
                    var permiso = (from a in permissionsAll where
                                    a.libreriaClase == typeof (FrmUsuarios).Namespace && 
                                    a.nombreForm== typeof(FrmUsuarios).Name select  a.permisos).First();
                    FrmUsuarios f = new FrmUsuarios(){Tag = permiso}; //llamar en evento Load a: BotonesSegunPermisos();
                  //  f.Parametros = permiso;//enviando ej: c|r|u|d
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
                    var permiso = (from a in permissionsAll
                                   where
                                       a.libreriaClase == typeof(FrmRoles).Namespace &&
                                       a.nombreForm == typeof(FrmRoles).Name
                                   select a.permisos).First();
                    FrmRoles f = new FrmRoles(){Tag = permiso}; //llamar en evento Load a: BotonesSegunPermisos();
                  //  f.Parametros = permiso;//enviando ej: c|r|u|d
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
                    var permiso = (from a in permissionsAll
                                   where
                                       a.libreriaClase == typeof(FrmFactura).Namespace &&
                                       a.nombreForm == typeof(FrmFactura).Name
                                   select a.permisos).First();
                    FrmFactura f = new FrmFactura() { Tag = permiso }; //llamar en evento Load a: BotonesSegunPermisos();
                //    f.Parametros = permiso;//enviando ej: c|r|u|d
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
                    var permiso = (from a in permissionsAll
                                   where
                                       a.libreriaClase == typeof(FrmPedidosEspeciales).Namespace &&
                                       a.nombreForm == typeof(FrmPedidosEspeciales).Name
                                   select a.permisos).First();
                    FrmPedidosEspeciales f = new FrmPedidosEspeciales() { Tag = permiso }; //llamar en evento Load a: BotonesSegunPermisos();
             //       f.Parametros = permiso;//enviando ej: c|r|u|d
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
                    var permiso = (from a in permissionsAll
                                   where
                                       a.libreriaClase == typeof(FrmReporteFactura).Namespace &&
                                       a.nombreForm == typeof(FrmReporteFactura).Name
                                   select a.permisos).First();
                    FrmReporteFactura f = new FrmReporteFactura() { Tag = permiso }; //llamar en evento Load a: BotonesSegunPermisos();
                    //       f.Parametros = permiso;//enviando ej: c|r|u|d
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

        private void iPedidoProductos_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

    }
}
