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
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace ClbFacturas
{
    public partial class FrmFactura : frmMantenimiento
    {

        FacturaGrid oFacturaGrid= new FacturaGrid();
        private bool esEditado = false;
        private decimal subtotal = 0;
        private decimal iva = 0;
        private decimal totPAgar = 0;
        private RepositoryItemTextEdit itemNumberF4 = new RepositoryItemTextEdit();
        public FrmFactura()
        {
            InitializeComponent();
            CeldaSoloNumeros();
        }

        protected override void Nuevo()
        {
            base.Nuevo();
            this.switchButton1.Value = false;
            facturaGridBindingSource.Clear();
            gridControl1.DataSource = this.facturaGridBindingSource;
            this.gridView1.AddNewRow();
            if (switchButton1.Value == false)
            {
                Bloquear();
            }
        }

        protected override void Guardar()
        {
            base.Guardar();
            ObtenerYGuardar();
        }

        protected override void Deshacer()
        {
            base.Deshacer();
        }

        protected override void Buscar()
        {
            base.Buscar();
        }

        protected override void Bloquear()
        {
            base.Bloquear();
            buttonX1.Enabled = false;
            gridControl1.Enabled = true;
        }

        protected override void Desbloquear()
        {
            base.Desbloquear();
            buttonX1.Enabled = true;
            gridControl1.Enabled = true;
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
            this.gridControl1.Enabled = true;
            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmConsulta fcon = new frmConsulta();

            List<ClienteConsultaGrid> lista = Clientes.ObtenerListaParaGUI();
            fcon.gridControl1.DataSource = lista;

            fcon.ShowDialog();
           // var oCliente = new Cliente();
            if (fcon.oGenerico != null)
            {
                var oCliente = (ClienteConsultaGrid)fcon.oGenerico;
                txtCedRUC.Text = oCliente.numeroIdentificacion;
                txtCliente.Text = oCliente.nombre +" "+ oCliente.apellido;
                txtId.Text = oCliente.id.ToString();//this.FormModoParametro = FormModo.Edicion;
            }
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            //BotonesSegunPermisos();//copy seguridad
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //   if (e.Column.FieldName != "id") return;
            //if (esEditado)
            //{
            //    return;
            //}

            if (e.Column.FieldName == "id")
            {
                if ((decimal)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id") == oFacturaGrid.id)
                {
                    return;
                }
                List<Producto> lista = new List<Producto>();
                decimal cod = (decimal)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id"); //es caseSensitive
                lista = Productos.ObtenerParaVenta(cod.ToString(),1,true);

                foreach (var p in lista)
                {
                    oFacturaGrid.id = p.Id;
                    oFacturaGrid.descripcion = p.Descripcion;
                    oFacturaGrid.descripcionDetallada = p.DescripcionDetallada;
                    oFacturaGrid.unidadMedida = p.UnidadMedida;
                    oFacturaGrid.cantidad = 0;
                    oFacturaGrid.precio = p.Precio;
                    oFacturaGrid.descuento = 0;
                    oFacturaGrid.total = (oFacturaGrid.precio * oFacturaGrid.cantidad) - oFacturaGrid.descuento;
                    oFacturaGrid.existencias = p.Existencias;
                }

               // this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descripcion", oFacturaGrid.descripcion);
                this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descripcionDetallada", oFacturaGrid.descripcionDetallada);
                this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "unidadMedida", oFacturaGrid.unidadMedida);
                this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "existencias", oFacturaGrid.existencias);
               // this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "cantidad", oFacturaGrid.cantidad);
                this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "precio", oFacturaGrid.precio);
                this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descuento", oFacturaGrid.descuento);
                this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "total", oFacturaGrid.total);

                return;
            }

            if (e.Column.FieldName=="descripcionDetallada")
            {
                if ((string)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "descripcionDetallada") == oFacturaGrid.descripcionDetallada)
                {
                    return;
                }

                List<Producto> lista = new List<Producto>();
                string like = (string)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "descripcionDetallada"); //es caseSensitive
                lista = Productos.ObtenerParaVenta(like, 1, false);
                frmConsulta frmCon= new frmConsulta();
                frmCon.gridControl1.DataSource = lista;
                int columnas = gridView1.Columns.Count;
                if (columnas>5)
                {
                   //visible false todas las demas
                }
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
                    
                    this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "unidadMedida", oFacturaGrid.unidadMedida);
                    this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "existencias", oFacturaGrid.existencias);
                    //this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "cantidad", oFacturaGrid.cantidad);
                    this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "precio", oFacturaGrid.precio);
                    this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descuento", oFacturaGrid.descuento);
                    this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "total", oFacturaGrid.total);
                    
                    this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "id", oFacturaGrid.id);
                    this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "descripcionDetallada", oFacturaGrid.descripcionDetallada);

                    return;
                }
            }

            if (e.Column.FieldName == "cantidad")
            {
                oFacturaGrid.cantidad = (decimal)this.gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cantidad");
                oFacturaGrid.total = (oFacturaGrid.precio * oFacturaGrid.cantidad) - oFacturaGrid.descuento;
                this.gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "total", oFacturaGrid.total);
                if (oFacturaGrid.cantidad > 0)
                {
                    this.gridView1.AddNewRow();
                    calcular2();
                    return;
                }
            }

            
            return;
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
            this.txtTotPagar.Text = totPAgar.ToString();
            
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
                Factura oFactura= new Factura();
                if (switchButton1.Value)
                {
                    if (!(String.IsNullOrEmpty(txtId.Text)))
                    {
                        oFactura.idCliente = Decimal.Parse(txtId.Text);
                    }
                }
                else
                {
                    oFactura.idCliente = 1026;//consumidor final
                }
                oFactura.id = 0;
                oFactura.fechaFacturacion = DateTime.Now;
                oFactura.facturaSRI = "666666669666";
                oFactura.subTotal = Decimal.Parse(txtSubTotal.Text);
                oFactura.iva = Decimal.Parse(txtIva.Text);
                // oFactura.descuento = Decimal.Parse(txtDescuento.Text);
                oFactura.totalPagar = Decimal.Parse(txtTotPagar.Text);
                oFactura.fechaCreacion = DateTime.Now;
                oFactura.userCreador = info;//nick que identifica al usuario
                oFactura.procesado = false;//es decir no cerrada
                oFactura.esCancelado = false;
                oFactura.idSucursal = 1;

                decimal k = 1;
                List<FacturaDet> lista = new List<FacturaDet>();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if ((gridView1.GetRowCellValue(i, coltotal)) == null)
                    {
                        continue;
                    }
                    oFacturaGrid = (FacturaGrid)gridView1.GetRow(i);

                    FacturaDet det= new FacturaDet(); //SE PUEDE MEJORAR . check
                    
                    det.idFacturaCab = 0; //no se sabe todavia
                    det.linea = k;
                    det.idProducto = (decimal)gridView1.GetRowCellValue(i, "id");
                    det.cantidad = (decimal)gridView1.GetRowCellValue(i, "cantidad");
                    det.totalLinea = (decimal)gridView1.GetRowCellValue(i, "total");
                    det.descuentoPorcentaje = 0;
                    
                    lista.Add(det);
                    k++;
                    oFactura.detalles = lista;
                }
                
                

                if (Facturas.Guardar(oFactura))
                {
                    MessageBox.Show("Factura guardada", "Pan Lucho™", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void CeldaSoloNumeros()
        {
            itemNumberF4.AutoHeight = false;
            itemNumberF4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            itemNumberF4.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //itemNumberF4.Mask.EditMask = "f4";
            itemNumberF4.Mask.EditMask ="d";
            itemNumberF4.MaxLength = 2;//2 bytes .. 2 caracteres
            itemNumberF4.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            itemNumberF4.Mask.UseMaskAsDisplayFormat = true;
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName=="cantidad")
            {
                e.RepositoryItem = itemNumberF4;
            }
        }

        //private void calcular()
        //{
        //    FacturaGrid oFactGrid= new FacturaGrid();
        //    List<FacturaGrid> lista = gridView1.DataSource as List<FacturaGrid>;

        //    foreach (var linea in lista)
        //    {
        //        if (linea.total >0)
        //        {
        //            subtotal+= linea.total;
        //        }
        //    }
        //    this.txtSubTotal.Text = subtotal.ToString();
        //    iva =subtotal*(12/100);
        //    this.txtIva.Text = iva.ToString();
        //    totPAgar = subtotal + iva;
        //    this.txtTotPagar.Text = totPAgar.ToString();
        //}
    }
}
