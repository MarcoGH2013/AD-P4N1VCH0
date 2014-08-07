using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controles;

namespace ClbPedidosEspeciales
{
    public partial class FrmPedidosEspeciales : frmMantenimiento
    {
        public FrmPedidosEspeciales()
        {
            InitializeComponent();
        }

        protected override void Buscar()
        {
            base.Buscar();
            frmConsulta fcon = new frmConsulta();
            fcon.ShowDialog();
        }

        private void FrmPedidosEspeciales_Load(object sender, EventArgs e)
        {
          //  BotonesSegunPermisos();//copy seguridad
        }
    }
}
