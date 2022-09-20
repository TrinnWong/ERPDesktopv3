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

namespace ERP.Common.Forms
{
    public partial class frmBuscarCliente : Form
    {
        ERPProdEntities oContext;
        public int opcionERP;
        public frmBuscarCliente()
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
            uiGridClientes.DataSource = oContext.cat_clientes
                .Where(
                    w => w.Nombre.Contains(text)
                    || w.ClienteId.ToString().Contains(text)
                    || w.RFC.Contains(text)
                ).Select(
                    s => new
                    {
                        Clave = s.ClienteId,
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
            int rowIndex = index;;

            if (uiGridClientes.CurrentCell.RowIndex >= 0)
            {
                string clave = uiGridClientes.Rows[rowIndex].Cells["Clave"].Value.ToString();
                string nombre = uiGridClientes.Rows[rowIndex].Cells["Nombre"].Value.ToString();

                cat_clientes cliente = new cat_clientes();

                cliente.ClienteId = int.Parse(clave);
                cliente.Nombre = nombre;

                if (opcionERP == (int)Enumerados.opcionesERP.apartadosUpd)
                {
                    frmApartadosUpd.GetInstance().SeleccionarCliente(cliente);
                }
                //frmPuntoVenta oForm = (frmPuntoVenta)this.Owner.MdiChildren[0];

                //oForm.asignarCliente(int.Parse(clave), nombre);
                this.Close();
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
