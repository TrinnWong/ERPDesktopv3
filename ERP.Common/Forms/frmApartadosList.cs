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
    public partial class frmApartadosList : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmApartadosList _instance;
        public static frmApartadosList GetInstance()
        {

            if (_instance == null) _instance = new frmApartadosList();
            return _instance;
        }

        public frmApartadosList()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();

          
        }

        public void LlenarGrid()
        {
            int cliente = 0;

            int.TryParse(uiCliente.Text, out cliente);


            var resultado = oContext.p_doc_apartados_consulta_grd(this.puntoVentaContext.sucursalId, uiBuscarTexto.Text,uiSoloConSaldo.Checked).ToList();

            uiGrid.DataSource = resultado;

            if (uiGrid.Columns.Count > 0)
            {
                this.uiGrid.Columns[2].DefaultCellStyle.Format = "c2";
                this.uiGrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            
        }

        private void frmApartadosList_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void uiBuscar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void frmApartadosList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmApartadosUpd frmo = frmApartadosUpd.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this.MdiParent;
                frmo.accionForm = (int)Enumerados.accionForm.agregar;
                frmo.Show();
            }
        }

        private void uiGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int movimientoId = int.Parse(uiGrid.Rows[e.RowIndex].Cells["ClienteId"].Value.ToString());

                    if (movimientoId > 0)
                    {
                        frmApartadosListCliente frmo = new frmApartadosListCliente();

                        frmo.puntoVentaContext = this.puntoVentaContext;
                        frmo.clienteId = movimientoId;
                        frmo.StartPosition = FormStartPosition.CenterParent;
                        frmo.soloConSaldo = uiSoloConSaldo.Checked;
                        frmo.ShowDialog();

                        //if (!frmo.Visible)
                        //{
                        //    //frmo = new frmPuntoVenta();
                        //    //frmo.MdiParent = this.MdiParent; ;
                        //    //frmo.puntoVentaContext = this.puntoVentaContext;
                        //    //frmo.accionForm = (int)Enumerados.accionForm.actualizar;
                        //    //frmo.idForm = movimientoId;
                        //    //frmo.Show();

                        //}
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void uiBuscarTexto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LlenarGrid();
            }
        }
    }
}
