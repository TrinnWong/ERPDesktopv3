using ConexionBD;
using ERP.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Inventarios
{
    public partial class frmInventarioMovList : FormBaseXtraForm
    {
        public ERP.Business.Enumerados.tipoMovimientoInventario tipoMovimientoInv;
        int err = 0;
        private static frmInventarioMovList _instance;
        public static frmInventarioMovList GetInstance()
        {
            if (_instance == null) _instance = new frmInventarioMovList();
            else _instance.BringToFront();
            return _instance;
        }
        public frmInventarioMovList()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmInventarioMovList_Load(object sender, EventArgs e)
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();
                uiTitulo.Text = oContext.cat_tipos_movimiento_inventario
                    .Where(w => w.TipoMovimientoInventarioId == (int)tipoMovimientoInv)
                    .FirstOrDefault().Descripcion;

                uiDel.EditValue = DateTime.Now;
                uiAl.EditValue = DateTime.Now;
                uiSucursal.Properties.DataSource = ERP.Business.SucursalBusiness.ObtenSucursalesPorUsuario(this.puntoVentaContext.empresaId,
                    this.puntoVentaContext.usuarioId).ToList();

                LoadGrid();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                            "ERP",
                            this.Name,
                            ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LoadGrid()
        {
            try
            {
                oContext = new ERPProdEntities();
                int sucursalId = Convert.ToInt32(uiSucursal.EditValue);
                uiGrid.DataSource = oContext.doc_inv_movimiento
                    .Where(w => 
                    w.SucursalId == sucursalId &&
                    ((w.FechaMovimiento.Year * 10000)+(w.FechaMovimiento.Month * 100) + w.FechaMovimiento.Day) >= ((uiDel.DateTime.Year * 10000) + (uiDel.DateTime.Month * 100) + uiDel.DateTime.Day) &&
                    ((w.FechaMovimiento.Year * 10000) + (w.FechaMovimiento.Month * 100) + w.FechaMovimiento.Day) <= ((uiAl.DateTime.Year * 10000) + (uiAl.DateTime.Month * 100) + uiAl.DateTime.Day) &&
                    w.Activo == true &&
                    w.TipoMovimientoId == (int)this.tipoMovimientoInv
                    ).OrderByDescending(O=> O.MovimientoId).ToList();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                            "ERP",
                            this.Name,
                            ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void frmInventarioMovList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiSucursal_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void repBtnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    frmInventarioMovRegistro frmo = frmInventarioMovRegistro.GetInstance();
                    if (!frmo.Visible)
                    {
                        frmo.MdiParent = this.MdiParent;
                        frmo.puntoVentaContext = this.puntoVentaContext;
                        frmo.StartPosition = FormStartPosition.CenterScreen;
                        frmo.WindowState = FormWindowState.Maximized;
                        frmo.tipoMovimiento = ERP.Business.Enumerados.tipoMovimientoInventario.AjustePorEntrada;
                        frmo.MovimientoInventarioId = ((doc_inv_movimiento)uiGridView.GetRow(uiGridView.FocusedRowHandle)).MovimientoId;
                        
                        frmo.Show();
                    }
                }
                
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                            "ERP",
                            this.Name,
                            ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiAgregar_Click(object sender, EventArgs e)
        {

            frmInventarioMovRegistro frmo = frmInventarioMovRegistro.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this.MdiParent;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.tipoMovimiento = this.tipoMovimientoInv;
                frmo.MovimientoInventarioId = 0;

                frmo.Show();
            }
        }
    }
}
