using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controles;

namespace ClbFacturas
{
    public partial class FrmReporteFactura : frmMantenimiento
    {
        public FrmReporteFactura()
        {
            InitializeComponent();
        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtClienteCod.Enabled == false)
            {
                txtClienteCod.Enabled = true;
                txtClienteNom.Enabled = true;
                btnBuscarClient.Enabled = true;
            }
            else
            {
                txtClienteCod.Enabled = false;
                txtClienteNom.Enabled = false;
                btnBuscarClient.Enabled = false;
            }
        }

        private void checkButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (txtVendedorCod.Enabled == false)
            {
                txtVendedorCod.Enabled = true;
                txtVendedorNomb.Enabled = true;
                btnBuscarVende.Enabled = true;
            }
            else
            {
                txtVendedorCod.Enabled = false;
                txtVendedorNomb.Enabled = false;
                btnBuscarVende.Enabled = false;
            }
        }

    }
}
