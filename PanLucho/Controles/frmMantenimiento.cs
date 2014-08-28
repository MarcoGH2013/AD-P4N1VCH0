using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace Controles
{
    public class frmMantenimiento : Form
    {
        #region Windows Form Codigo generado por el diseñador
        private ToolStrip tstMenu;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbDeshacer;
        private ToolStripButton tsbEliminar;
        private ToolStripButton tsbGuardar;
        private ToolStripButton tsbBuscar;
        private ToolStripButton tsbSalir;
        
        private void InitializeComponent()
        {
            this.tstMenu = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbDeshacer = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsbBuscar = new System.Windows.Forms.ToolStripButton();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.tstMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tstMenu
            // 
            this.tstMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbDeshacer,
            this.tsbEliminar,
            this.tsbGuardar,
            this.tsbBuscar,
            this.tsbSalir});
            this.tstMenu.Location = new System.Drawing.Point(0, 0);
            this.tstMenu.Name = "tstMenu";
            this.tstMenu.Size = new System.Drawing.Size(530, 39);
            this.tstMenu.TabIndex = 1;
            this.tstMenu.Text = "Barra de Menú";
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = global::Controles.Properties.Resources.Agregar;
            this.tsbNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(36, 36);
            this.tsbNuevo.Tag = "c";
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbDeshacer
            // 
            this.tsbDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeshacer.Image = global::Controles.Properties.Resources.Modificar;
            this.tsbDeshacer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeshacer.Name = "tsbDeshacer";
            this.tsbDeshacer.Size = new System.Drawing.Size(36, 36);
            this.tsbDeshacer.Tag = "u";
            this.tsbDeshacer.Text = "Deshacer";
            this.tsbDeshacer.ToolTipText = "Deshacer";
            this.tsbDeshacer.Click += new System.EventHandler(this.tsbDeshacer_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = global::Controles.Properties.Resources.Eliminar;
            this.tsbEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(36, 36);
            this.tsbEliminar.Tag = "d";
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // tsbGuardar
            // 
            this.tsbGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuardar.Image = global::Controles.Properties.Resources.Guardar;
            this.tsbGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardar.Name = "tsbGuardar";
            this.tsbGuardar.Size = new System.Drawing.Size(36, 36);
            this.tsbGuardar.Tag = "c";
            this.tsbGuardar.Text = "Guardar";
            this.tsbGuardar.Click += new System.EventHandler(this.tsbGuardad_Click);
            // 
            // tsbBuscar
            // 
            this.tsbBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBuscar.Image = global::Controles.Properties.Resources.Buscar;
            this.tsbBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBuscar.Name = "tsbBuscar";
            this.tsbBuscar.Size = new System.Drawing.Size(36, 36);
            this.tsbBuscar.Tag = "r";
            this.tsbBuscar.Text = "Buscar";
            this.tsbBuscar.Click += new System.EventHandler(this.tsbBuscar_Click);
            // 
            // tsbSalir
            // 
            this.tsbSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSalir.Image = global::Controles.Properties.Resources.Cerrar;
            this.tsbSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(36, 36);
            this.tsbSalir.Tag = "00";
            this.tsbSalir.Text = "Cerrar";
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // frmMantenimiento
            // 
            this.ClientSize = new System.Drawing.Size(530, 420);
            this.Controls.Add(this.tstMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMantenimiento";
            this.Tag = "";
            this.tstMenu.ResumeLayout(false);
            this.tstMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private FormModo formModoParametro = FormModo.Predeterminado;
        
        public frmMantenimiento()
        {
            InitializeComponent();
        }

        public FormModo FormModoParametro
        {
            get { return formModoParametro; }
            set { formModoParametro = value; }
        }
        public string Parametros { get; set; } //ej: c|r|u|d

        public string info { get; set; } //

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            EstablecerColorFocoCajaTexto();
            if (string.IsNullOrEmpty(Parametros))
            {
                ModoPredeterminado();
            }
            BotonVisible();
        }

        public void BotonVisible()
        {
            if (!string.IsNullOrEmpty(Tag.ToString()))
            {
                foreach (ToolStripItem control in tstMenu.Items)
                {
                    if (Tag.ToString().Contains(control.Tag.ToString()) || control.Tag.ToString().Contains("00"))
                        control.Visible = true;
                    else
                        control.Visible = false;
                }
            }
        }
        
        private void EstablecerColorFocoCajaTexto()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBoxX)
                {
                    var txt = (TextBoxX) control;
                    txt.FocusHighlightColor = Color.FromArgb(0, 255, 255);
                    txt.FocusHighlightEnabled = true;
                }
                if (control.HasChildren)
                {
                    EstablecerColorFocoCajaTextoRecursiva(control);
                }
            }
        }

        private void EstablecerColorFocoCajaTextoRecursiva(Control control)
        {
            foreach (Control subControl in control.Controls)
            {
                if (subControl is TextBoxX)
                {
                    var txt = (TextBoxX) subControl;
                    txt.FocusHighlightColor = Color.FromArgb(0, 255,255);
                    txt.FocusHighlightEnabled = true;
                }
                if (subControl.HasChildren)
                {
                    EstablecerColorFocoCajaTextoRecursiva(subControl);
                }
            }
        }

        protected void ModoPredeterminado()
        {
            InactivarTodoControl();
            DeshabilitarTodaBarraHerramienta();
            tsbNuevo.Enabled = true;
            tsbBuscar.Enabled = true;
            formModoParametro=FormModo.Predeterminado;
        }

        protected virtual void ModoNuevo()
        {
            LimpiarContenidoControles();
            DeshabilitarTodaBarraHerramienta();
            ActivarTodoControl();
            tsbGuardar.Enabled = true;
            tsbDeshacer.Enabled = true;
            formModoParametro=FormModo.Nuevo;

        }

        public void ModoEdicion()
        {
            ActivarTodoControl();
            DeshabilitarTodaBarraHerramienta();
            tsbGuardar.Enabled = true;
            tsbDeshacer.Enabled = true;
            formModoParametro=FormModo.Edicion;
        }
        public void InactivarTodoControl()
        {
            foreach (Control control in Controls)
            {
                if (!(control is ToolStrip))
                    control.Enabled = false;
                InactivarTodoControlRecursiva(control);
            }
        }

        public void InactivarTodoControlRecursiva(Control control)
        {
            foreach (Control subControl in control.Controls)
            {
                if (!(subControl is ToolStrip))
                    subControl.Enabled = false;
                InactivarTodoControlRecursiva(subControl);
            }
        }

        public void DeshabilitarTodaBarraHerramienta()
        {
            foreach (ToolStripItem mnuBoton in tstMenu.Items.Cast<ToolStripItem>().Where(mnuBoton => !mnuBoton.Tag.ToString().Contains("00")))
            {
                mnuBoton.Enabled = false;
            }
        }

        public void ActivarTodoControl()
        {
            foreach (Control control in Controls)
            {
                if (!(control is ToolStrip))
                    control.Enabled = true;
                ActivarTodoControlRecursiva(control);
            }
        }

        public void ActivarTodoControlRecursiva(Control control)
        {
            foreach (Control subControl in control.Controls)
            {
                if (!(subControl is ToolStrip))
                    subControl.Enabled = true;
                ActivarTodoControlRecursiva(subControl);
            }
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        protected virtual void Nuevo()
        {
            ModoNuevo();
        }
        public void LimpiarContenidoControles()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                    control.Text = "";
                else LimpiarContenidoRecursivoControles(control);
            }
        }
        private void LimpiarContenidoRecursivoControles(Control control)
        {
            foreach (Control controlItem in control.Controls)
            {
                if (controlItem is TextBox)
                    controlItem.Text = "";
                else LimpiarContenidoRecursivoControles(controlItem);

            }
        }

        protected virtual void BotonesSegunPermisos()
        {
            OcultarControles();
            if (Parametros!=null)
            {
                String[] permiso = Parametros.Split('|');
                foreach (var i in permiso)
                {
                    switch (i[0])
                    {
                        case 'c':
                            tsbNuevo.Visible = true;
                            tsbGuardar.Visible=true;
                            break;
                        case 'r':
                            tsbBuscar.Visible = true;
                            break;
                        case 'u':
                            tsbDeshacer.Visible = true;
                            break;
                        case 'd':
                            tsbEliminar.Visible = true;
                            break;
                        default:
                            OcultarControles();
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos asignados a esta pantalla, se han inhabilitado todas las opciones, " +
                                "consulte con el administrador del sistema", "Pan Lucho™", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OcultarControles()
        {
            tsbNuevo.Visible = false;
            tsbGuardar.Visible = false;
            tsbBuscar.Visible = false;
            tsbDeshacer.Visible = false;
            tsbEliminar.Visible = false;
        }

        protected virtual void Bloquear()
        {
            BloquearControles();
        }

        public void BloquearControles() //Bloquea solo cajas de texto?
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                    control.Enabled=false;
                else BloquearControlesRecursivo(control);
            }
        }
        private void BloquearControlesRecursivo(Control control)
        {
            foreach (Control controlItem in control.Controls)
            {
                if (controlItem is TextBox)
                    controlItem.Enabled=false;
                else BloquearControlesRecursivo(controlItem);

            }
        }

        protected virtual void Desbloquear()
        {
            DesbloquearControles();
        }

        public void DesbloquearControles() //Bloquea solo cajas de texto?
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                    control.Enabled = true;
                else DesbloquearControlesRecursivo(control);
            }
        }
        private void DesbloquearControlesRecursivo(Control control)
        {
            foreach (Control controlItem in control.Controls)
            {
                if (controlItem is TextBox)
                    controlItem.Enabled = true;
                else DesbloquearControlesRecursivo(controlItem);

            }
        }

        private void tsbDeshacer_Click(object sender, EventArgs e)
        {
            Deshacer();
        }

        protected virtual void Deshacer()
        {
            ModoPredeterminado();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        protected virtual void Eliminar()
        {
            
        }

        private void tsbGuardad_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        protected virtual void Guardar()
        {
            
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected virtual void Buscar()
        {
            ModoEdicion();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    public enum FormModo
    {
        Nuevo = 0,
        Edicion = 1,
        Predeterminado = 2
    }
}
