using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Componentes.NivelMedio.Transacciones;
using Componentes.Transaccion;
using Controles;

namespace ClbPedidosEspeciales
{
    public partial class FrmPedidosEspeciales : frmMantenimiento
    {
        FacturaGrid oFacturaGrid = new FacturaGrid();
        public FrmPedidosEspeciales()
        {
            InitializeComponent();
            var eventos = Eventos.GetList();

            foreach (var evento in eventos)
            {repositoryItemComboBox1.Items.Add(evento.Descripcion);
            }
            Color[] colores = new Color[] {
                Color.Yellow,
                Color.Blue,    // <- color 2
                Color.Red,     // <- color 0
                Color.White,   // <- color 1
                Color.Green,
                // <- ...
                Color.Pink
            };
            
            
            repositoryItemColorEdit1.CustomColors = colores;
        }

        protected override void Nuevo()
        {
            base.Nuevo();
            gridView1.AddNewRow();
            
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //   if (e.Column.FieldName != "id") return;
            //if (esEditado)
            //{
            //    return;
            //}
            switch (e.Column.FieldName)
            {
                case "id":
                    {
                        if ((decimal)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id") == oFacturaGrid.id)
                        {
                            return;
                        }
                        var oProductos = new List<Producto>();
                        decimal cod = (decimal)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id"); //es caseSensitive
                        oProductos = Productos.ObtenerParaVenta(cod.ToString(), 1, true);
                        var producto = oProductos[0];
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descripcion", producto.Descripcion);
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descripcionDetallada", producto.DescripcionDetallada);
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "unidadMedida", producto.UnidadMedida);
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "existencias", producto.Existencias);
                        //this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "cantidad", producto.Cantidad);
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "precio", producto.Precio);
                        //this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descuento", producto.Descuento);
                        //this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "total", producto.Total);
                        return;
                    }
                case "cantidad":
                    {
                        break;
                    }
                case "descripcionDetallada":
                    {
                        if ((string)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "descripcionDetallada") == oFacturaGrid.descripcionDetallada)
                        {
                            return;
                        }
                        var lista = new List<Producto>();
                        string like = (string)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "descripcionDetallada"); //es caseSensitive
                        lista = Productos.ObtenerParaVenta(like, 1, false);
                        frmConsulta frmCon = new frmConsulta();
                        frmCon.gridControl1.DataSource = lista;
                        frmCon.ShowDialog();
                        if (frmCon.oGenerico != null)
                        {
                            var oProducto = (Producto)frmCon.oGenerico;
                            oFacturaGrid.id = oProducto.Id;
                            oFacturaGrid.descripcion = oProducto.Descripcion;
                            oFacturaGrid.descripcionDetallada = oProducto.DescripcionDetallada;
                            oFacturaGrid.unidadMedida = oProducto.UnidadMedida;
                            oFacturaGrid.cantidad = 0;
                            oFacturaGrid.precio = oProducto.Precio;
                            oFacturaGrid.descuento = 0;
                            oFacturaGrid.total = (oFacturaGrid.precio * oFacturaGrid.cantidad) - oFacturaGrid.descuento;
                            oFacturaGrid.existencias = oProducto.Existencias;

                            // this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descripcion", oFacturaGrid.descripcion);

                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "unidadMedida", oFacturaGrid.unidadMedida);
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "existencias", oFacturaGrid.existencias);
                            //this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "cantidad", oFacturaGrid.cantidad);
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "precio", oFacturaGrid.precio);
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descuento", oFacturaGrid.descuento);
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "total", oFacturaGrid.total);

                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "id", oFacturaGrid.id);
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descripcionDetallada", oFacturaGrid.descripcionDetallada);

                            return;
                        }
                        break;
                    }
            }
            //if (e.Column.FieldName == "id")
            //{
            //    Producto oProducto = new Producto();
            //    decimal cod = (decimal)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id"); //es caseSensitive
            //    oProducto = Productos.ObtenerParaGrid(cod);

            //    oFacturaGrid.id = oProducto.Id;
            //    oFacturaGrid.descripcion = oProducto.Descripcion;
            //    oFacturaGrid.descripcionDetallada = oProducto.DescripcionDetallada;
            //    oFacturaGrid.unidadMedida = oProducto.UnidadMedida;
            //    oFacturaGrid.cantidad = 0;
            //    oFacturaGrid.precio = oProducto.Precio;
            //    oFacturaGrid.descuento = 0;
            //    oFacturaGrid.total = (oFacturaGrid.precio * oFacturaGrid.cantidad) - oFacturaGrid.descuento;
            //    oFacturaGrid.existencias = oProducto.Existencias;

            //    this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descripcion", oFacturaGrid.descripcion);
            //    this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descripcionDetallada", oFacturaGrid.descripcionDetallada);
            //    this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "unidadMedida", oFacturaGrid.unidadMedida);
            //    this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "existencias", oFacturaGrid.existencias);
            //    this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "cantidad", oFacturaGrid.cantidad);
            //    this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "precio", oFacturaGrid.precio);
            //    this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descuento", oFacturaGrid.descuento);
            //    this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "total", oFacturaGrid.total);

            //    return;
            //}

            //if (e.Column.FieldName == "cantidad")
            //{
            //    oFacturaGrid.cantidad = (decimal)this.gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cantidad");
            //    oFacturaGrid.total = (oFacturaGrid.precio * oFacturaGrid.cantidad) - oFacturaGrid.descuento;
            //    this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "total", oFacturaGrid.total);
            //    if (oFacturaGrid.cantidad > 0)
            //    {
            //        this.gridView1.AddNewRow();
            //        return;
            //    }
            //}
            return;
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmConsulta fcon = new frmConsulta();
            fcon.gridControl1.DataSource = Clientes.ObtenerLista2();
            fcon.ShowDialog();
            // var oCliente = new Cliente();
            if (fcon.oGenerico != null)
            {
                var oCliente = (Cliente)fcon.oGenerico;
                txtCedRUC.Text = oCliente.NumeroIdentificacion;
                txtCliente.Text = oCliente.NombreCompleto;
                //txtId.Text = oCliente.Id.ToString();//this.FormModoParametro = FormModo.Edicion;
            }
        }
    }
}
