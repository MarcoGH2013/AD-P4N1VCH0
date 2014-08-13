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
using DevExpress.XtraGrid.Views.Grid;

namespace ClbFacturas
{
    public partial class FrmFactura : frmMantenimiento
    {
        FacturaGrid oFacturaGrid= new FacturaGrid();
        public FrmFactura()
        {
            InitializeComponent();
            if (switchButton1.Value == false)
            { Bloquear(); }
        }

        protected override void Nuevo()
        {
            base.Nuevo();
            gridView1.AddNewRow();
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
         //   if (e.Column.FieldName != "id") return;
            if (e.Column.FieldName == "id")
            {
                Producto oProducto = new Producto();
                decimal cod = (decimal) gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id"); //es caseSensitive
                oProducto = Productos.ObtenerParaGrid(cod);

                oFacturaGrid.id = oProducto.id;
                oFacturaGrid.descripcion = oProducto.descripcion;
                oFacturaGrid.descripcionDetallada = oProducto.descripcionDetallada;
                oFacturaGrid.unidadMedida = oProducto.unidadMedida;
                oFacturaGrid.cantidad = 1;
                oFacturaGrid.precio = oProducto.precio;
                oFacturaGrid.descuento = 0;
                oFacturaGrid.total = (oFacturaGrid.precio*oFacturaGrid.cantidad) - oFacturaGrid.descuento;
                oFacturaGrid.existencias = oProducto.existencias;

                this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descripcion", oFacturaGrid.descripcion);
                this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descripcionDetallada", oFacturaGrid.descripcionDetallada);
                this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "unidadMedida", oFacturaGrid.unidadMedida);
                this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "existencias", oFacturaGrid.existencias);
                this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "cantidad", oFacturaGrid.cantidad);
                this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "precio", oFacturaGrid.precio);
                this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descuento", oFacturaGrid.descuento);
                this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "total", oFacturaGrid.total);
            
            }

            if (e.Column.FieldName == "cantidad")
            {
                oFacturaGrid.cantidad = (decimal)this.gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cantidad");
                oFacturaGrid.total = (oFacturaGrid.precio * oFacturaGrid.cantidad) - oFacturaGrid.descuento;
                this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "total", oFacturaGrid.total);
            }

            return;
     
        }
    }
}
