namespace Menu
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPrincipal));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageCollection1_x16 = new DevExpress.Utils.ImageCollection(this.components);
            this.iSalir = new DevExpress.XtraBars.BarButtonItem();
            this.iCerrarSesion = new DevExpress.XtraBars.BarButtonItem();
            this.iUsuarios = new DevExpress.XtraBars.BarButtonItem();
            this.iRoles = new DevExpress.XtraBars.BarButtonItem();
            this.iFactura = new DevExpress.XtraBars.BarButtonItem();
            this.iClientes = new DevExpress.XtraBars.BarButtonItem();
            this.iPedidoEspecial = new DevExpress.XtraBars.BarButtonItem();
            this.iPedidoProductos = new DevExpress.XtraBars.BarButtonItem();
            this.iCierreCaja = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1_x32 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.Pedidos = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage5 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage6 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage7 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage8 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage9 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage10 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup12 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1_x16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1_x32)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Images = this.imageCollection1_x16;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.iSalir,
            this.iCerrarSesion,
            this.iUsuarios,
            this.iRoles,
            this.iFactura,
            this.iClientes,
            this.iPedidoEspecial,
            this.iPedidoProductos,
            this.iCierreCaja});
            this.ribbon.LargeImages = this.imageCollection1_x32;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 10;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3,
            this.ribbonPage4,
            this.ribbonPage5});
            this.ribbon.Size = new System.Drawing.Size(784, 142);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // imageCollection1_x16
            // 
            this.imageCollection1_x16.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1_x16.ImageStream")));
            this.imageCollection1_x16.InsertImage(global::Menu.Properties.Resources.help32x32__2_, "help32x32__2_", typeof(global::Menu.Properties.Resources), 0);
            this.imageCollection1_x16.Images.SetKeyName(0, "help32x32__2_");
            this.imageCollection1_x16.InsertImage(global::Menu.Properties.Resources.customer__2_, "customer__2_", typeof(global::Menu.Properties.Resources), 1);
            this.imageCollection1_x16.Images.SetKeyName(1, "customer__2_");
            this.imageCollection1_x16.InsertImage(global::Menu.Properties.Resources.specialOrder__2_, "specialOrder__2_", typeof(global::Menu.Properties.Resources), 2);
            this.imageCollection1_x16.Images.SetKeyName(2, "specialOrder__2_");
            this.imageCollection1_x16.InsertImage(global::Menu.Properties.Resources.roles__2_, "roles__2_", typeof(global::Menu.Properties.Resources), 3);
            this.imageCollection1_x16.Images.SetKeyName(3, "roles__2_");
            this.imageCollection1_x16.InsertImage(global::Menu.Properties.Resources.specialOrderInvoice__2_, "specialOrderInvoice__2_", typeof(global::Menu.Properties.Resources), 4);
            this.imageCollection1_x16.Images.SetKeyName(4, "specialOrderInvoice__2_");
            this.imageCollection1_x16.InsertImage(global::Menu.Properties.Resources.log_out_32__2_, "log_out_32__2_", typeof(global::Menu.Properties.Resources), 5);
            this.imageCollection1_x16.Images.SetKeyName(5, "log_out_32__2_");
            this.imageCollection1_x16.InsertImage(global::Menu.Properties.Resources.disconnect__2_, "disconnect__2_", typeof(global::Menu.Properties.Resources), 6);
            this.imageCollection1_x16.Images.SetKeyName(6, "disconnect__2_");
            this.imageCollection1_x16.InsertImage(global::Menu.Properties.Resources.user__2_, "user__2_", typeof(global::Menu.Properties.Resources), 7);
            this.imageCollection1_x16.Images.SetKeyName(7, "user__2_");
            this.imageCollection1_x16.InsertImage(global::Menu.Properties.Resources.invoice__2_, "invoice__2_", typeof(global::Menu.Properties.Resources), 8);
            this.imageCollection1_x16.Images.SetKeyName(8, "invoice__2_");
            this.imageCollection1_x16.InsertImage(global::Menu.Properties.Resources.closeCash__2_, "closeCash__2_", typeof(global::Menu.Properties.Resources), 9);
            this.imageCollection1_x16.Images.SetKeyName(9, "closeCash__2_");
            this.imageCollection1_x16.InsertImage(global::Menu.Properties.Resources.breads__2_, "breads__2_", typeof(global::Menu.Properties.Resources), 10);
            this.imageCollection1_x16.Images.SetKeyName(10, "breads__2_");
            // 
            // iSalir
            // 
            this.iSalir.Caption = "Salir";
            this.iSalir.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.iSalir.Description = "Salir del sistema Pan Lucho";
            this.iSalir.Hint = "Salir del sistema Pan Lucho.";
            this.iSalir.Id = 1;
            this.iSalir.ImageIndex = 5;
            this.iSalir.LargeImageIndex = 5;
            this.iSalir.Name = "iSalir";
            this.iSalir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iSalir_ItemClick);
            // 
            // iCerrarSesion
            // 
            this.iCerrarSesion.Caption = "Cerrar sesión";
            this.iCerrarSesion.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.iCerrarSesion.Description = "Cierra la sesión actual para poder ingresar con un usuario diferente, sin salir d" +
    "el sistema";
            this.iCerrarSesion.Hint = "Cierra la sesión actual para poder ingresar con un usuario diferente, sin salir d" +
    "el sistema.";
            this.iCerrarSesion.Id = 2;
            this.iCerrarSesion.ImageIndex = 6;
            this.iCerrarSesion.LargeImageIndex = 6;
            this.iCerrarSesion.Name = "iCerrarSesion";
            this.iCerrarSesion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iCerrarSesion_ItemClick);
            // 
            // iUsuarios
            // 
            this.iUsuarios.Caption = "Usuarios";
            this.iUsuarios.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.iUsuarios.Description = "Editar información variada de los usuarios";
            this.iUsuarios.Hint = "Editar información variada de los usuarios.";
            this.iUsuarios.Id = 3;
            this.iUsuarios.ImageIndex = 7;
            this.iUsuarios.LargeImageIndex = 7;
            this.iUsuarios.Name = "iUsuarios";
            this.iUsuarios.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iUsuarios_ItemClick);
            // 
            // iRoles
            // 
            this.iRoles.Caption = "Roles";
            this.iRoles.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.iRoles.Description = "Administrar los permisos que poseen los usuarios";
            this.iRoles.Hint = "Administrar los permisos que poseen los usuarios.";
            this.iRoles.Id = 4;
            this.iRoles.ImageIndex = 3;
            this.iRoles.LargeImageIndex = 3;
            this.iRoles.Name = "iRoles";
            // 
            // iFactura
            // 
            this.iFactura.Caption = "Facturar";
            this.iFactura.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.iFactura.Description = "Registar la venta de los productos";
            this.iFactura.Hint = "Registar la venta de los productos.";
            this.iFactura.Id = 5;
            this.iFactura.ImageIndex = 8;
            this.iFactura.LargeImageIndex = 8;
            this.iFactura.Name = "iFactura";
            // 
            // iClientes
            // 
            this.iClientes.Caption = "Clientes";
            this.iClientes.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.iClientes.Description = "Registrar información acerca de los clientes";
            this.iClientes.Hint = "Registrar información acerca de los clientes.";
            this.iClientes.Id = 6;
            this.iClientes.ImageIndex = 1;
            this.iClientes.LargeImageIndex = 1;
            this.iClientes.Name = "iClientes";
            this.iClientes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iClientes_ItemClick);
            // 
            // iPedidoEspecial
            // 
            this.iPedidoEspecial.Caption = "Pedido especial";
            this.iPedidoEspecial.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.iPedidoEspecial.Description = "Registra información detallada de un pedido con características inusuales";
            this.iPedidoEspecial.Hint = "Registra información detallada de un pedido con características inusuales.";
            this.iPedidoEspecial.Id = 7;
            this.iPedidoEspecial.ImageIndex = 2;
            this.iPedidoEspecial.LargeImageIndex = 2;
            this.iPedidoEspecial.Name = "iPedidoEspecial";
            // 
            // iPedidoProductos
            // 
            this.iPedidoProductos.Caption = "Pedidos productos";
            this.iPedidoProductos.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.iPedidoProductos.Description = "Se crean requerimientos de productos faltantes a la matriz";
            this.iPedidoProductos.Hint = "Se crean requerimientos de productos faltantes a la matriz.";
            this.iPedidoProductos.Id = 8;
            this.iPedidoProductos.ImageIndex = 10;
            this.iPedidoProductos.LargeImageIndex = 10;
            this.iPedidoProductos.Name = "iPedidoProductos";
            // 
            // iCierreCaja
            // 
            this.iCierreCaja.Caption = "Cierre de caja";
            this.iCierreCaja.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.iCierreCaja.Description = "Se realiza el proceso de cierre de caja";
            this.iCierreCaja.Hint = "Se realiza el proceso de cierre de caja.";
            this.iCierreCaja.Id = 9;
            this.iCierreCaja.ImageIndex = 9;
            this.iCierreCaja.LargeImageIndex = 9;
            this.iCierreCaja.Name = "iCierreCaja";
            this.iCierreCaja.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iCierreCaja_ItemClick);
            // 
            // imageCollection1_x32
            // 
            this.imageCollection1_x32.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1_x32.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1_x32.ImageStream")));
            this.imageCollection1_x32.InsertImage(global::Menu.Properties.Resources.help32x32__2_, "help32x32__2_", typeof(global::Menu.Properties.Resources), 0);
            this.imageCollection1_x32.Images.SetKeyName(0, "help32x32__2_");
            this.imageCollection1_x32.InsertImage(global::Menu.Properties.Resources.customer__2_, "customer__2_", typeof(global::Menu.Properties.Resources), 1);
            this.imageCollection1_x32.Images.SetKeyName(1, "customer__2_");
            this.imageCollection1_x32.InsertImage(global::Menu.Properties.Resources.specialOrder__2_, "specialOrder__2_", typeof(global::Menu.Properties.Resources), 2);
            this.imageCollection1_x32.Images.SetKeyName(2, "specialOrder__2_");
            this.imageCollection1_x32.InsertImage(global::Menu.Properties.Resources.roles__2_, "roles__2_", typeof(global::Menu.Properties.Resources), 3);
            this.imageCollection1_x32.Images.SetKeyName(3, "roles__2_");
            this.imageCollection1_x32.InsertImage(global::Menu.Properties.Resources.specialOrderInvoice__2_, "specialOrderInvoice__2_", typeof(global::Menu.Properties.Resources), 4);
            this.imageCollection1_x32.Images.SetKeyName(4, "specialOrderInvoice__2_");
            this.imageCollection1_x32.InsertImage(global::Menu.Properties.Resources.log_out_32__2_, "log_out_32__2_", typeof(global::Menu.Properties.Resources), 5);
            this.imageCollection1_x32.Images.SetKeyName(5, "log_out_32__2_");
            this.imageCollection1_x32.InsertImage(global::Menu.Properties.Resources.disconnect__2_, "disconnect__2_", typeof(global::Menu.Properties.Resources), 6);
            this.imageCollection1_x32.Images.SetKeyName(6, "disconnect__2_");
            this.imageCollection1_x32.InsertImage(global::Menu.Properties.Resources.user__2_, "user__2_", typeof(global::Menu.Properties.Resources), 7);
            this.imageCollection1_x32.Images.SetKeyName(7, "user__2_");
            this.imageCollection1_x32.InsertImage(global::Menu.Properties.Resources.invoice__2_, "invoice__2_", typeof(global::Menu.Properties.Resources), 8);
            this.imageCollection1_x32.Images.SetKeyName(8, "invoice__2_");
            this.imageCollection1_x32.InsertImage(global::Menu.Properties.Resources.closeCash__2_, "closeCash__2_", typeof(global::Menu.Properties.Resources), 9);
            this.imageCollection1_x32.Images.SetKeyName(9, "closeCash__2_");
            this.imageCollection1_x32.InsertImage(global::Menu.Properties.Resources.breads__2_, "breads__2_", typeof(global::Menu.Properties.Resources), 10);
            this.imageCollection1_x32.Images.SetKeyName(10, "breads__2_");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "INICIO";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.iSalir);
            this.ribbonPageGroup1.ItemLinks.Add(this.iCerrarSesion);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Inicio";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "SEGURIDAD";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.iUsuarios);
            this.ribbonPageGroup2.ItemLinks.Add(this.iRoles);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Seguridad";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "VENTAS";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.iFactura);
            this.ribbonPageGroup4.ItemLinks.Add(this.iClientes);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Facturación";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.iPedidoEspecial);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Pedidos";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.Pedidos});
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "INVENTARIO";
            this.ribbonPage4.Visible = false;
            // 
            // Pedidos
            // 
            this.Pedidos.ItemLinks.Add(this.iPedidoProductos);
            this.Pedidos.Name = "Pedidos";
            this.Pedidos.Text = "Inventario";
            // 
            // ribbonPage5
            // 
            this.ribbonPage5.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6});
            this.ribbonPage5.Name = "ribbonPage5";
            this.ribbonPage5.Text = "GASTOS Y PAGOS";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.iCierreCaja);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Gastos y pagos";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 537);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(784, 27);
            // 
            // ribbonPage6
            // 
            this.ribbonPage6.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup7});
            this.ribbonPage6.Name = "ribbonPage6";
            this.ribbonPage6.Text = "INICIO";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "ribbonPageGroup1";
            // 
            // ribbonPage7
            // 
            this.ribbonPage7.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup8});
            this.ribbonPage7.Name = "ribbonPage7";
            this.ribbonPage7.Text = "SEGURIDAD";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.Text = "Seguridad";
            // 
            // ribbonPage8
            // 
            this.ribbonPage8.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup9,
            this.ribbonPageGroup10});
            this.ribbonPage8.Name = "ribbonPage8";
            this.ribbonPage8.Text = "VENTAS";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.Text = "Facturación";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.Text = "Pedidos especiales";
            // 
            // ribbonPage9
            // 
            this.ribbonPage9.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup11});
            this.ribbonPage9.Name = "ribbonPage9";
            this.ribbonPage9.Text = "INVENTARIO";
            // 
            // ribbonPageGroup11
            // 
            this.ribbonPageGroup11.Name = "ribbonPageGroup11";
            this.ribbonPageGroup11.Text = "Inventario";
            // 
            // ribbonPage10
            // 
            this.ribbonPage10.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup12});
            this.ribbonPage10.Name = "ribbonPage10";
            this.ribbonPage10.Text = "GASTOS Y PAGOS";
            // 
            // ribbonPageGroup12
            // 
            this.ribbonPageGroup12.Name = "ribbonPageGroup12";
            this.ribbonPageGroup12.Text = "Gastos y pagos";
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "FrmMenuPrincipal";
            this.Text = "FrmMenuPrincipal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenuPrincipal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMenuPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1_x16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1_x32)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup Pedidos;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage9;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup11;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage10;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup12;
        private DevExpress.Utils.ImageCollection imageCollection1_x16;
        private DevExpress.Utils.ImageCollection imageCollection1_x32;
        private DevExpress.XtraBars.BarButtonItem iSalir;
        private DevExpress.XtraBars.BarButtonItem iCerrarSesion;
        private DevExpress.XtraBars.BarButtonItem iUsuarios;
        private DevExpress.XtraBars.BarButtonItem iRoles;
        private DevExpress.XtraBars.BarButtonItem iFactura;
        private DevExpress.XtraBars.BarButtonItem iClientes;
        private DevExpress.XtraBars.BarButtonItem iPedidoEspecial;
        private DevExpress.XtraBars.BarButtonItem iPedidoProductos;
        private DevExpress.XtraBars.BarButtonItem iCierreCaja;

    }
}