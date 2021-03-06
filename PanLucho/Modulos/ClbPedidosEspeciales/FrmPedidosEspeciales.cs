﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
        OrdenGrid oFacturaGrid = new OrdenGrid();
        private int oId;
        private decimal subtotal = 0;
        private decimal iva = 0;
        private decimal totPAgar = 0;
        public FrmPedidosEspeciales()
        {
            InitializeComponent();
            var eventos = Eventos.ObtenerLista();

            repositoryItemLookUpEdit1.DataSource = eventos;
            repositoryItemLookUpEdit1.ValueMember = "Id";
            repositoryItemLookUpEdit1.DisplayMember = "Descripcion";
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
            ordenGridBindingSource.Clear();
            
            //ordenGridBindingSource.DataSource = null;
            //gridControl1.DataSource = null;
            //this.ordenGridBindingSource.DataSource = typeof(Componentes.Transaccion.OrdenGrid);
            while (gridView1.RowCount != 0)
            {
                gridView1.SelectAll();
                gridView1.DeleteSelectedRows();
            }
            //gridControl1.DataSource = ordenGridBindingSource;
            gridControl1.Refresh();
            gridView1.AddNewRow();
            txtSubTotal.Text = "0";
            txtIva.Text = "0";
            txtAbono.Text = "0";
        }

        protected override void Guardar()
        {
            base.Guardar();
            if (MessageBox.Show("Desea Guardar los Datos", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            if (txtAbono.Text == "" || txtAbono.Text == "0")
            {
                MessageBox.Show("El monto del Abono debe de ser al menos el 50%", Application.ProductName, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            if (txtCedRUC.Text == " " || string.IsNullOrEmpty(txtCedRUC.Text))
            {
                MessageBox.Show("Ingrese Datos del Cliente", Application.ProductName, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            if (VScroll)
            {
                
            }
            ObtenerYGuardar();
            Nuevo();
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
                case "Id":
                    {
                        if ((decimal)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Id") == oFacturaGrid.Id)
                        {
                            return;
                        }
                        var oProductos = new List<Producto>();
                        decimal cod = (decimal)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Id"); //es caseSensitive
                        oProductos = Productos.ObtenerParaVenta(cod.ToString(), 1, true);
                        var producto = oProductos[0];
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descripcion", producto.Descripcion);
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "DescripcionDetallada", producto.DescripcionDetallada);
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "UnidadMedida", producto.UnidadMedida);
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "existencias", producto.Existencias);
                        //this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "cantidad", producto.Cantidad);
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Precio", producto.Precio);
                        //this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descuento", producto.Descuento);
                        //this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "total", producto.Total);
                        return;
                    }
                case "Cantidad":
                    {
                        oFacturaGrid.Cantidad = (decimal)this.gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Cantidad");
                        oFacturaGrid.Precio = (decimal)this.gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Precio");
                        oFacturaGrid.Total = (oFacturaGrid.Precio * oFacturaGrid.Cantidad);
                        this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Total", oFacturaGrid.Total);
                        if (oFacturaGrid.Cantidad > 0)
                        {
                            calcular2();
                            return;
                        }
                        break;
                    }
                case "DescripcionDetallada":
                    {
                        if ((string)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "descripcionDetallada") == oFacturaGrid.DescripcionDetallada)
                        {
                            return;
                        }
                        var lista = new List<Producto>();
                        string like = (string)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DescripcionDetallada"); //es caseSensitive
                        lista = Productos.ObtenerParaVenta(like, 1, false);
                        frmConsulta frmCon = new frmConsulta();
                        if (lista.Count()!=1)
                        {
                            
                            frmCon.gridControl1.DataSource = lista;
                            frmCon.ShowDialog(); 
                        }
                        
                        if (frmCon.oGenerico != null)
                        {
                            var oProducto = (Producto)frmCon.oGenerico;
                            oFacturaGrid.Id = oProducto.Id;
                            //oFacturaGrid.Descripcion = oProducto.Descripcion;
                            oFacturaGrid.DescripcionDetallada = oProducto.DescripcionDetallada;
                            oFacturaGrid.UnidadMedida = oProducto.UnidadMedida;
                            oFacturaGrid.Cantidad = 0;
                            oFacturaGrid.Precio = oProducto.Precio;
                            //oFacturaGrid.descuento = 0;
                            //oFacturaGrid.total = (oFacturaGrid.precio * oFacturaGrid.cantidad) - oFacturaGrid.descuento;
                            //oFacturaGrid.existencias = oProducto.Existencias;

                            // this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descripcion", oFacturaGrid.descripcion);

                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "UnidadMedida", oFacturaGrid.UnidadMedida);
                            //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "existencias", oFacturaGrid.existencias);
                            //this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "cantidad", oFacturaGrid.cantidad);
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "precio", oFacturaGrid.Precio);
                            //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descuento", oFacturaGrid.descuento);
                            //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "total", oFacturaGrid.total);

                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Id", oFacturaGrid.Id);
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "DescripcionDetallada", oFacturaGrid.DescripcionDetallada);

                            return;
                        }
                        break;
                    }
                case "Observaciones":
                {
                    if (this.gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Cantidad")!=null)
                        oFacturaGrid.Cantidad = (decimal)this.gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Cantidad");
                    //oFacturaGrid.Total = (oFacturaGrid.precio * oFacturaGrid.cantidad) - oFacturaGrid.descuento;
                    //this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "total", oFacturaGrid.total);
                    if (oFacturaGrid.Cantidad > 0)
                    {
                        this.gridView1.AddNewRow();
                        //calcular2();
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
                oId = oCliente.Id;
                //txtId.Text = oCliente.Id.ToString();//this.FormModoParametro = FormModo.Edicion;
            }
        }
        private void calcular2()//funcional
        {
            FacturaGrid oGrid = new FacturaGrid();

            subtotal = 0;
            iva = 0;
            totPAgar = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                //oGrid = (FacturaGrid)gridView1.GetRow(0);
                if (gridView1.GetRowCellValue(i, coltotal) == null)
                {
                    continue;
                }
                subtotal += (decimal)gridView1.GetRowCellValue(i, coltotal);
            }

            txtSubTotal.Text = subtotal.ToString("0.00");
            iva = subtotal * 12 / 100;
            this.txtIva.Text = iva.ToString("F");
            totPAgar = subtotal + iva;
            //this.txtTotPagar.Text = totPAgar.ToString();

            //Cliente oCliente = new Cliente()
            //{
            //    Id = (int)gridView1.GetRowCellValue(1,colcantidad),
            //    NumeroIdentificacion = gridView1.GetRowCellValue(1, colcantidad).ToString(),
            //    Apellido =gridView1.GetRowCellValue(1,colcantidad).ToString()
            //};
        }
        private void ObtenerYGuardar()
        {
            try
            {
                OrdenEspecialCab oFactura = new OrdenEspecialCab();
                oFactura.IdCliente = Decimal.Parse(oId.ToString());
                oFactura.Id = 0;
                
                oFactura.SubTotal = Decimal.Parse(txtSubTotal.Text);
                oFactura.Iva = Decimal.Parse(txtIva.Text);
                oFactura.Abono = Decimal.Parse(txtAbono.Text);
                oFactura.FechaEntrega = DateTime.Now;
                oFactura.FechaCreacion = DateTime.Now;
                oFactura.UserCreador = "lquinter";
                oFactura.IdEstado = 1;
        
                decimal k = 1;
                List<OrdenEspecialDetalle> lista = new List<OrdenEspecialDetalle>();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if ((gridView1.GetRowCellValue(i, colunidadMedida)) == null)
                    {
                        continue;
                    }
                    oFacturaGrid = (OrdenGrid)gridView1.GetRow(i);

                    OrdenEspecialDetalle det = new OrdenEspecialDetalle(); //SE PUEDE MEJORAR . check
                    byte[] image = ImagenAArregloByte((Image)gridView1.GetRowCellValue(i, "Imagen"));
                    det.IdOrdenEspecialCab = 0; //no se sabe todavia
                    det.Linea = k;
                    det.IdProducto = (decimal)gridView1.GetRowCellValue(i, "Id");
                    det.Cantidad = (decimal)gridView1.GetRowCellValue(i, "Cantidad");
                    if (gridView1.GetRowCellValue(i, "IdEvento")!=null)
                    {
                        det.IdEvento = Decimal.Parse(gridView1.GetRowCellValue(i, "IdEvento").ToString());
                    }
                    det.IdEvento = Decimal.Parse(gridView1.GetRowCellValue(i, "IdEvento").ToString());
                    det.Color = (string)gridView1.GetRowCellValue(i, "Color").ToString();
                    det.Leyenda = (string)gridView1.GetRowCellValue(i, "Leyenda");
                    det.Imagen = image;
                    det.Observaciones = (string)gridView1.GetRowCellValue(i, "Observaciones");
                    lista.Add(det);
                    k++;
                    oFactura.Detalles = lista;
                }




                if (OrdenEspecialCabs.Crear(oFactura))
                {
                    MessageBox.Show("Pedido guardado", "Pan Lucho™", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public byte[] ImagenAArregloByte(Image imagen)
        {
            var ms = new MemoryStream();
            if (imagen != null)
                imagen.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private void txtAbono_Leave(object sender, EventArgs e)
        {
            if (decimal.Parse(txtAbono.Text) < (decimal.Parse(txtSubTotal.Text) + decimal.Parse(txtIva.Text)) / 2)
            {
                MessageBox.Show("El valor del Abono debe de ser el 50% del total del Pedido", Application.ProductName,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAbono.Text = "0";
                txtAbono.Focus();
                //txtSaldo.Text = (decimal.Parse(txtSubTotal.Text) + decimal.Parse(txtIva.Text)).ToString();
                return;
            }
            txtSaldo.Text = (decimal.Parse(txtSubTotal.Text) + decimal.Parse(txtIva.Text) - decimal.Parse(txtAbono.Text)).ToString("0.00");
            txtAbono.Text = decimal.Parse(txtAbono.Text).ToString("0.00");
        }
    }
}
