namespace Menu
{
    partial class FrmSesion
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.simpleButton1.Location = new System.Drawing.Point(60, 108);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(159, 23);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Iniciar sesión";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.EditValue = "Matriz";
            this.lookUpEdit1.Location = new System.Drawing.Point(81, 82);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre5", "Matriz")});
            this.lookUpEdit1.Size = new System.Drawing.Size(162, 20);
            this.lookUpEdit1.TabIndex = 3;
            this.lookUpEdit1.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(44, 85);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Local:";
            this.labelControl1.Visible = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.BackColor2 = System.Drawing.Color.Gainsboro;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Bauhaus 93", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelControl4.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.labelControl4.Location = new System.Drawing.Point(51, 136);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(187, 39);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "PAN LUCHO";
            // 
            // txtPass
            // 
            this.txtPass.EditValue = "Contrasena";
            this.txtPass.Location = new System.Drawing.Point(44, 47);
            this.txtPass.Name = "txtPass";
            this.txtPass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtPass.Properties.NullText = "Escriba la contraseña";
            this.txtPass.Properties.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(199, 22);
            this.txtPass.TabIndex = 2;
            this.txtPass.ToolTip = "Escriba la clave que le fué designada a su usuario, recuerde no dársela a nadie";
            this.txtPass.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtPass.ToolTipTitle = "Contrasena";
            // 
            // txtUser
            // 
            this.txtUser.EditValue = "Nombre de usuario";
            this.txtUser.Location = new System.Drawing.Point(44, 8);
            this.txtUser.Name = "txtUser";
            this.txtUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtUser.Properties.NullText = "Escriba la contraseña";
            this.txtUser.Size = new System.Drawing.Size(199, 22);
            this.txtUser.TabIndex = 1;
            this.txtUser.ToolTip = "Escriba el nombre por la empresa para acceder al sistema Pan Lucho";
            this.txtUser.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtUser.ToolTipTitle = "Usuario";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Matriz"});
            this.comboBox1.Location = new System.Drawing.Point(171, 120);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Visible = false;
            // 
            // simpleButton2
            // 
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton2.Location = new System.Drawing.Point(254, 147);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(26, 26);
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "?";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // FrmSesion
            // 
            this.AcceptButton = this.simpleButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 174);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lookUpEdit1);
            this.Controls.Add(this.simpleButton1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(297, 210);
            this.MinimumSize = new System.Drawing.Size(297, 210);
            this.Name = "FrmSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PanLucho - Inicio de sesión";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSesion_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtPass;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private System.Windows.Forms.ComboBox comboBox1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
    }
