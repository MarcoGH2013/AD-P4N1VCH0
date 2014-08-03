using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controles;

namespace ClbRoles
{
    public partial class FrmRoles : frmMantenimiento
    {
        public FrmRoles()
        {
            InitializeComponent();
        }

        private void FrmRoles_Load(object sender, EventArgs e)
        {
            BotonesSegunPermisos();//copy seguridad
        }
    }
}
