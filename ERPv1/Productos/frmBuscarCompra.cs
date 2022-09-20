using ConexionBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Productos
{
    public partial class frmBuscarCompra : Form
    {
        ERPProdEntities oContext;
        public frmBuscarCompra()
        {
            InitializeComponent();
           
        }

        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();
            uiFechaInicio.Value = DateTime.Now;
            uiFechaFin.Value = DateTime.Now;
            BuscarTexto("");
        }

        private void BuscarTexto(string text)
        {
            DateTime fechaIni = uiFechaInicio.Value;
            DateTime fechaFin = uiFechaFin.Value;

            uiGridClientes.DataSource = oContext.doc_productos_compra
                .Where(
                    w=> DbFunctions.TruncateTime(w.FechaRegistro) >= DbFunctions.TruncateTime(fechaIni) &&
                    DbFunctions.TruncateTime(w.FechaRegistro) <= DbFunctions.TruncateTime(fechaFin)
                ).Select(
                    s => new
                    {
                       folio = s.ProductoCompraId,
                       proveedor = s.cat_proveedores.Nombre,
                       fecha = s.FechaRegistro,
                       total = s.Total,
                       activo = s.Activo
                    }
                ).ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BuscarTexto(uiBuscar.Text);
        }

        private void seleccionarCliente(int index)
        {
            int rowIndex = index;;

            if (uiGridClientes.CurrentCell.RowIndex >= 0)
            {
                string clave = uiGridClientes.Rows[rowIndex].Cells["Folio"].Value.ToString();
                

                frmProductosCompra oForm = (frmProductosCompra)this.Owner.MdiChildren.Where(w=> w.Name == "frmProductosCompra").FirstOrDefault();

                if(oForm != null)
                {
                    oForm.asignarFolio(int.Parse(clave));
                    this.Close();
                }

               
            }
            }

        private void uiGridClientes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                seleccionarCliente(uiGridClientes.CurrentCell.RowIndex - 1);
            }
        }

        private void uiGridClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarCliente(uiGridClientes.CurrentCell.RowIndex);
        }

        private void uiBuscar_Click(object sender, EventArgs e)
        {
            BuscarTexto("");
        }
    }
}
