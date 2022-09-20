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

namespace Productos
{
    public partial class frmBuscarProveedor : Form
    {
        ERPProdEntities oContext;
        public frmBuscarProveedor()
        {
            InitializeComponent();
           
        }

        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();
            BuscarTexto("");
        }

        private void BuscarTexto(string text)
        {
            uiGridClientes.DataSource = oContext.cat_proveedores
                .Where(
                    w => w.Nombre.Contains(text)
                    || w.ProveedorId.ToString().Contains(text)
                    || w.RFC.Contains(text)
                ).Select(
                    s => new
                    {
                        Clave = s.ProveedorId,
                        Nombre = s.Nombre,
                        RFC = s.RFC
                    }
                ).ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BuscarTexto(uiBuscar.Text);
        }

        private void seleccionarCliente(int index)
        {
            try
            {
                int rowIndex = index;

                if (uiGridClientes.CurrentCell.RowIndex >= 0)
                {
                    string clave = uiGridClientes.Rows[rowIndex].Cells["Clave"].Value.ToString();
                    string nombre = uiGridClientes.Rows[rowIndex].Cells["Nombre"].Value.ToString();


                    frmProductosCompra oForm = (frmProductosCompra)this.Owner.MdiChildren.Where(w=> w.Name== "frmProductosCompra").FirstOrDefault();

                    if(oForm != null)
                    {
                        oForm.asignarCliente(int.Parse(clave), nombre);
                        this.Close();
                    }

                    
                }
            }
            catch (Exception)
            {

                
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
    }
}
