using ConexionBD;
using ConexionBD.Models;
using ERP.Common.Base;
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

namespace ERPv1.Inventarios
{
    public partial class frmEntradaDirectaList : FormBaseXtraForm
    {
       
        private static frmEntradaDirectaList _instance;
       
        public static frmEntradaDirectaList GetInstance()
        {
            if (_instance == null) _instance = new frmEntradaDirectaList();
            else _instance.BringToFront();
            return _instance;
        }
        public frmEntradaDirectaList()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void frmSalidasTraspasoList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            frmEntradaDirectaUpd frmo = frmEntradaDirectaUpd.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this.MdiParent; ;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.accionForm = (int)Enumerados.accionForm.agregar;
                frmo.tipoMovimientoForm = (int)Enumerados.tipoMovsInventario.entradaDirecta;
                frmo.Show();

            }
        }

        public void cargarGrid()
        {
            int tipoMov = (int)Enumerados.tipoMovsInventario.entradaDirecta;
            string folio = uiFolio.Text;



            uiGrid.DataSource = oContext.doc_inv_movimiento
                .Where(
                    w => w.TipoMovimientoId == tipoMov
                    && (
                        (uiPorFolio.Checked && (w.FolioMovimiento == folio || folio == ""))
                        ||
                        (
                            uiPorFechas.Checked &&
                            DbFunctions.TruncateTime(w.FechaMovimiento) >= uiDel.Value.Date
                            &&
                            DbFunctions.TruncateTime(w.FechaMovimiento) <= uiAl.Value.Date
                        )
                        )

                )
                .Select(
                    s => new
                    {
                        MovimientoId = s.MovimientoId,
                        Folio = s.FolioMovimiento,
                        Origen = s.cat_sucursales1.NombreSucursal,
                        Destino = s.cat_sucursales.NombreSucursal,
                        Fecha = s.FechaMovimiento,
                        Total = s.ImporteTotal,
                        Autorizado = s.Autorizado,
                        Cancelado = s.Cancelado??false
                    }
                )
                .ToList();
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
                        frmEntradaDirectaUpd frmo = frmEntradaDirectaUpd.GetInstance();

                        if (!frmo.Visible)
                        {
                            //frmo = new frmPuntoVenta();
                            frmo.MdiParent = this.MdiParent; ;
                            frmo.puntoVentaContext = this.puntoVentaContext;
                            frmo.accionForm = (int)Enumerados.accionForm.actualizar;
                            frmo.idForm = movimientoId;
                            frmo.tipoMovimientoForm = (int)Enumerados.tipoMovsInventario.entradaDirecta;
                            frmo.Show();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                                
            }
        }

        private void frmSalidasTraspasoList_Load(object sender, EventArgs e)
        {
            ValidarAcceso(frmMenu.GetInstance().puntoVentaContext.usuarioId,frmMenu.GetInstance().puntoVentaContext.sucursalId,
                "frmSalidasTraspasoList");
            uiPorFechas.Checked = true;
            cargarGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void uiPorFolio_CheckedChanged(object sender, EventArgs e)
        {
            if(uiPorFolio.Checked)
            {
                groupBox2.Enabled = false;
            }
            else
            {
                groupBox2.Enabled = true;
            }
        }

        private void uiPorFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (uiPorFechas.Checked)
            {
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
            }
        }
    }
}
