using ConexionBD;
using ConexionBD.Models;
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
    public partial class frmApartadosListCliente : Form
    {
        public bool soloConSaldo;
        public int clienteId;
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        public frmApartadosListCliente()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        public void llenarGrid()
        {
            try
            {

                int sucursalId = puntoVentaContext.sucursalId;
                uiGrid.DataSource = oContext.doc_apartados
                     .Where(
                         w => w.ClienteId == clienteId &&
                         w.SucursalId == sucursalId &&
                         (
                           ( w.Saldo > 0 && uiSoloConSaldo.Checked)
                           ||
                           !uiSoloConSaldo.Checked
                         )
                    )
                    .Select(
                         s => new
                         {
                             ID = s.ApartadoId,
                             Cliente = s.ClienteId,
                             NombreCliente = s.cat_clientes.Nombre,
                             FechaRegistro = s.CreadoEl,
                             s.Saldo
                         }
                    ).ToList();



                if (uiGrid.Columns.Count > 0)
                {
                    this.uiGrid.Columns[4].DefaultCellStyle.Format = "c2";
                    this.uiGrid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void frmApartadosListCliente_Load(object sender, EventArgs e)
        {
            if (clienteId > 0)
            {
                uiCliente.Text = oContext.cat_clientes.Where(w => w.ClienteId == clienteId).FirstOrDefault().Nombre;
                uiSoloConSaldo.Checked = soloConSaldo;
                llenarGrid();


            }
            
        }

        private void uiGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int movimientoId = int.Parse(uiGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());

                    if (movimientoId > 0)
                    {
                        frmApartadosUpd frmo = frmApartadosUpd.GetInstance();

                      

                        if (!frmo.Visible)
                        {
                            //frmo = new frmPuntoVenta();
                            frmo.MdiParent = frmApartadosList.GetInstance().MdiParent;
                            frmo.puntoVentaContext = this.puntoVentaContext;
                            frmo.accionForm = (int)Enumerados.accionForm.actualizar;
                            frmo.idForm = movimientoId;
                            this.Close();
                            frmo.Show();
                            

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void uiSoloConSaldo_CheckedChanged(object sender, EventArgs e)
        {
            llenarGrid();
        }
    }
}
