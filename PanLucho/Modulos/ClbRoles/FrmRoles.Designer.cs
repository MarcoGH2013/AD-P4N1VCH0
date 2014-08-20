namespace ClbRoles
{
    partial class FrmRoles
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
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Nuevo", 0, 0);
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Deshacer", 1, 1);
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Eliminar", 2, 2);
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Grabar", 3, 3);
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Salir", 4, 4);
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("", 5, 5);
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("", 6, 6);
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("", 7, 7);
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("", 9, 9);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvwModulos = new System.Windows.Forms.TreeView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.tvwObjecto = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkEstado);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(678, 81);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del rol";
            // 
            // chkEstado
            // 
            this.chkEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEstado.Checked = true;
            this.chkEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstado.Location = new System.Drawing.Point(29, 59);
            this.chkEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(130, 18);
            this.chkEstado.TabIndex = 3;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(144, 34);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(399, 22);
            this.txtDescripcion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.LightYellow;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(144, 14);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(243, 22);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.Validated += new System.EventHandler(this.txtName_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.splitContainer1);
            this.groupBox2.Location = new System.Drawing.Point(5, 122);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(678, 236);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Permisos (Modulo -> Objetos)";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvwModulos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tvwObjecto);
            this.splitContainer1.Size = new System.Drawing.Size(672, 217);
            this.splitContainer1.SplitterDistance = 341;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvwModulos
            // 
            this.tvwModulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwModulos.ImageIndex = 0;
            this.tvwModulos.ImageList = this.imageList2;
            this.tvwModulos.Location = new System.Drawing.Point(3, 2);
            this.tvwModulos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tvwModulos.Name = "tvwModulos";
            this.tvwModulos.SelectedImageIndex = 0;
            this.tvwModulos.Size = new System.Drawing.Size(331, 209);
            this.tvwModulos.TabIndex = 4;
            this.tvwModulos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwModules_AfterSelect);
            this.tvwModulos.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwModulos_NodeMouseDoubleClick);
            this.tvwModulos.Enter += new System.EventHandler(this.tvwModules_Enter);
            this.tvwModulos.Leave += new System.EventHandler(this.tvwModules_Leave);
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tvwObjecto
            // 
            this.tvwObjecto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwObjecto.CheckBoxes = true;
            this.tvwObjecto.Enabled = false;
            this.tvwObjecto.ImageIndex = 0;
            this.tvwObjecto.ImageList = this.imageList1;
            this.tvwObjecto.Location = new System.Drawing.Point(1, 2);
            this.tvwObjecto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tvwObjecto.Name = "tvwObjecto";
            treeNode10.ImageIndex = 0;
            treeNode10.Name = "Node2";
            treeNode10.SelectedImageIndex = 0;
            treeNode10.Tag = "c";
            treeNode10.Text = "Nuevo";
            treeNode11.ImageIndex = 1;
            treeNode11.Name = "Node3";
            treeNode11.SelectedImageIndex = 1;
            treeNode11.Tag = "u";
            treeNode11.Text = "Deshacer";
            treeNode12.ImageIndex = 2;
            treeNode12.Name = "Node4";
            treeNode12.SelectedImageIndex = 2;
            treeNode12.Tag = "d";
            treeNode12.Text = "Eliminar";
            treeNode13.ImageIndex = 3;
            treeNode13.Name = "Node5";
            treeNode13.SelectedImageIndex = 3;
            treeNode13.Tag = "c";
            treeNode13.Text = "Grabar";
            treeNode14.ImageIndex = 4;
            treeNode14.Name = "Grabar&Cerrar";
            treeNode14.SelectedImageIndex = 4;
            treeNode14.Tag = "00";
            treeNode14.Text = "Salir";
            treeNode15.ImageIndex = 5;
            treeNode15.Name = "Node6";
            treeNode15.SelectedImageIndex = 5;
            treeNode15.Tag = "06";
            treeNode15.Text = "";
            treeNode16.ImageIndex = 6;
            treeNode16.Name = "Node7";
            treeNode16.SelectedImageIndex = 6;
            treeNode16.Tag = "07";
            treeNode16.Text = "";
            treeNode17.ImageIndex = 7;
            treeNode17.Name = "Node8";
            treeNode17.SelectedImageIndex = 7;
            treeNode17.Tag = "08";
            treeNode17.Text = "";
            treeNode18.ImageIndex = 9;
            treeNode18.Name = "Node10";
            treeNode18.SelectedImageIndex = 9;
            treeNode18.Tag = "09";
            treeNode18.Text = "";
            this.tvwObjecto.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            this.tvwObjecto.SelectedImageIndex = 0;
            this.tvwObjecto.Size = new System.Drawing.Size(322, 209);
            this.tvwObjecto.TabIndex = 5;
            this.tvwObjecto.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwObject_BeforeCheck);
            this.tvwObjecto.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwObject_AfterCheck);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblMensaje});
            this.statusStrip1.Location = new System.Drawing.Point(0, 358);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(695, 22);
            this.statusStrip1.TabIndex = 6;
            // 
            // tlblMensaje
            // 
            this.tlblMensaje.AutoSize = false;
            this.tlblMensaje.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tlblMensaje.Name = "tlblMensaje";
            this.tlblMensaje.Size = new System.Drawing.Size(300, 17);
            this.tlblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 380);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmRoles";
            this.Text = "Mantenimiento de roles";
            this.Load += new System.EventHandler(this.FrmRolModule_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvwModulos;
        private System.Windows.Forms.TreeView tvwObjecto;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblMensaje;
    }
}