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
    }
}
