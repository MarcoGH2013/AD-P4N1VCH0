using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Componentes.Comun;
using Componentes.NivelMedio.Transacciones;
using Componentes.Transaccion;
using Controles;

namespace ClbFacturas
{
    public partial class FrmFactura : frmMantenimiento
    {
        public FrmFactura()
        {
            InitializeComponent();
            if (switchButton1.Value == false)
            { Bloquear(); }
        }

        protected override void Nuevo()
        {
            base.Nuevo();
        }

        protected override void Guardar()
        {
            base.Guardar();
        }

        protected override void Buscar()
        {
            base.Buscar();
        }

        protected override void Bloquear()
        {
            base.Bloquear();
        }

        protected override void Desbloquear()
        {
            base.Desbloquear();
        }

        private void switchButton1_ValueChanged(object sender, EventArgs e)
        {
            if (switchButton1.Value==true)
            {
                labelX8.Text = "Factura: DATOS DEL CLIENTE";
                Desbloquear();
            }
            else
            {
                labelX8.Text = "Factura: CONSUMIDOR FINAL";
                Bloquear();
            }
            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmConsulta fcon=new frmConsulta();
            fcon.ShowDialog();
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            //BotonesSegunPermisos();//copy seguridad
        }
    }
}
