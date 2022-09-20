using ConexionBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.PuntoVenta
{
    public partial class frmBuscarProducto : Form
    {

        private ProductoModel0 productoSeleccionado;
        ERPProdEntities oContext;
        public frmBuscarProducto()
        {
            InitializeComponent();
            uiGridProducto.AutoGenerateColumns = false;
        }

        private void frmBuscarProducto_Load(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();
            productoSeleccionado = new ProductoModel0();
            CargarProductos("");


        }

        private void CargarProductos(string text)
        {
            uiGridProducto.DataSource = oContext.p_BuscarProductos(text,false,0,false);
        }

        private void uiBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarProductos(uiBuscar.Text);
        }

        private void uiGridProducto_KeyUp(object sender, KeyEventArgs e)
        {
            string error = "";
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarProducto( (uiGridProducto.CurrentCell.RowIndex - 1) <0 ? 0 : (uiGridProducto.CurrentCell.RowIndex - 1));
            }
            else
            {
                int rowIndex = uiGridProducto.CurrentCell.RowIndex;
                if (rowIndex > 0)
                {
                    uiGridProducto.CurrentCell = uiGridProducto.Rows[uiGridProducto.CurrentCell.RowIndex].Cells["Cantidad"];
                }

            }


        }

        private void uiGridProducto_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView gr = (DataGridView)sender;

            if (gr.SelectedRows.Count > 0)
            {
                gr.CurrentCell = gr.Rows[gr.CurrentCell.RowIndex].Cells["Cantidad"];
            }


        }

        private string validarAgregarProducto()
        {
            string error = "";
            if (productoSeleccionado.precioUnitario <= 0)
            {
                error = "No es posible agregar un producto sin precio";
            }

            return error;

        }

        private void uiGridProducto_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void uiGridProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarProducto(uiGridProducto.CurrentCell.RowIndex);
        }

        private void SeleccionarProducto(int rowIndex)
        {
            string error = "";
            if (uiGridProducto.CurrentCell.RowIndex >= 0)
            {

                productoSeleccionado.cantidad = uiGridProducto.Rows[rowIndex].Cells["Cantidad"].Value != null ?
                                                decimal.Parse(uiGridProducto.Rows[rowIndex].Cells["Cantidad"].Value.ToString()) :
                                                1;
                productoSeleccionado.descripcion = uiGridProducto.Rows[rowIndex].Cells["Descripcion"].Value != null ?
                                                uiGridProducto.Rows[rowIndex].Cells["Descripcion"].Value.ToString() :
                                                "";
                productoSeleccionado.precioUnitario = uiGridProducto.Rows[rowIndex].Cells["Precio"].Value != null ?
                                                decimal.Parse(uiGridProducto.Rows[rowIndex].Cells["Precio"].Value.ToString()) :
                                                0;
                productoSeleccionado.productoId = uiGridProducto.Rows[rowIndex].Cells["ID"].Value != null ?
                                                int.Parse(uiGridProducto.Rows[rowIndex].Cells["ID"].Value.ToString()) :
                                                0;

                productoSeleccionado.total = productoSeleccionado.cantidad * productoSeleccionado.precioUnitario;
                productoSeleccionado.clave = uiGridProducto.Rows[rowIndex].Cells["Clave"].Value != null ?
                                                uiGridProducto.Rows[rowIndex].Cells["Clave"].Value.ToString() :
                                                "";

                productoSeleccionado.porcImpuestos = uiGridProducto.Rows[rowIndex].Cells["impuestos"].Value != null ?
                                                decimal.Parse(uiGridProducto.Rows[rowIndex].Cells["impuestos"].Value.ToString()) :
                                                0;

                productoSeleccionado.impuestos = productoSeleccionado.total / (1 + (productoSeleccionado.porcImpuestos / 100));
                productoSeleccionado.impuestos = productoSeleccionado.total - productoSeleccionado.impuestos;

               error = validarAgregarProducto();

                if (error.Length > 0)
                {
                    MessageBox.Show(error, "ERROR");

                }
                else
                {
                    frmPuntoVenta oForm = (frmPuntoVenta)this.Owner.MdiChildren[0];

                    oForm.AgregarProducto(productoSeleccionado);
                    this.Close();


                }


            }
        }

    }
}
