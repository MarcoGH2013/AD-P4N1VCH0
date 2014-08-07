using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controles;

namespace ClbCierreCaja
{
    public partial class FrmCierreCaja : Controles.frmMantenimiento
    {
        public FrmCierreCaja()
        {
            InitializeComponent();

            dateEdit1.DateTime = DateTime.Now;
        }

        private void FrmCierreCaja_Load(object sender, EventArgs e)
        {
            //BotonesSegunPermisos();//copy seguridad
        }
    }
}
