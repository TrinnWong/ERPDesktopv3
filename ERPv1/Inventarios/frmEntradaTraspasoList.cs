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
    public partial class frmEntradaTraspasoList : FormBaseXtraForm
    {
       
        private static frmEntradaTraspasoList _instance;
        
        public static frmEntradaTraspasoList GetInstance()
        {
            if (_instance == null) _instance = new frmEntradaTraspasoList();
            else _instance.BringToFront();
            return _instance;
        }
        public frmEntradaTraspasoList()
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

            frmEntradaTraspasoUpd frmo = frmEntradaTraspasoUpd.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this.MdiParent; ;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.accionForm = (int)Enumerados.accionForm.agregar;
                frmo.tipoMovimientoForm = (int)Enumerados.tipoMovsInventario.entradaPorTraspaso;
                frmo.Show();

            }
        }

        public void cargarGrid()
        {
            int tipoMov = (int)Enumerados.tipoMovsInventario.entradaPorTraspaso;
            string folio = uiFolio.Text;



            uiGrid.DataSource = oContext.doc_inv_movimiento
                .Where(
                    w => w.SucursalId == this.puntoVentaContext.sucursalId &&
                    w.TipoMovimientoId == tipoMov
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
                        Origen = s.cat_sucursales2.NombreSucursal,
                        Destino = s.cat_sucursales3.NombreSucursal,
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
                        frmEntradaTraspasoUpd frmo = frmEntradaTraspasoUpd.GetInstance();

                        if (!frmo.Visible)
                        {
                            //frmo = new frmPuntoVenta();
                            frmo.MdiParent = this.MdiParent; ;
                            frmo.puntoVentaContext = this.puntoVentaContext;
                            frmo.accionForm = (int)Enumerados.accionForm.actualizar;
                            frmo.idForm = movimientoId;
                            frmo.tipoMovimientoForm = (int)Enumerados.tipoMovsInventario.entradaPorTraspaso;
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
            ValidarAcceso(frmMenu.GetInstance().puntoVentaContext.usuarioId,
                frmMenu.GetInstance().puntoVentaContext.sucursalId, "frmSalidasTraspasoList");
            cargarGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }
    }
}
