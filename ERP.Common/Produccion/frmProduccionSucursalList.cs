using ConexionBD;
using ERP.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Produccion
{
    public partial class frmProduccionSucursalList : FormBaseXtraForm
    {
        public int IDEstatus { get; set; }
        private static frmProduccionSucursalList _instance;
        public static frmProduccionSucursalList GetInstance()
        {
            if (_instance == null) _instance = new frmProduccionSucursalList();
            else _instance.BringToFront();
            return _instance;
        }
        public frmProduccionSucursalList()
        {
            InitializeComponent();
        }

        private void frmProduccionSucursalList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void LoadEstatus()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();

                uiEstatusProd.Properties.DataSource =
                    oContext.cat_estatus_produccion.ToList();

                if(this.IDEstatus > 0)
                {
                    uiEstatusProd.EditValue = this.IDEstatus;
                }
            }
            catch (Exception ex)
            {


                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
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
                oContext = new ConexionBD.ERPProdEntities();
                DateTime fechaDel = uiDel.DateTime;
                DateTime fechaAl = uiAl.DateTime;

                IDEstatus = Convert.ToInt32(uiEstatusProd.EditValue);
                uiGrid.DataSource = oContext.doc_produccion
                    .Where(w=> (w.EstatusProduccionId == IDEstatus || IDEstatus == 0) && w.Activo
                    && w.SucursalId == puntoVentaContext.sucursalId
                    && System.Data.Entity.DbFunctions.TruncateTime(w.CreadoEl) >= System.Data.Entity.DbFunctions.TruncateTime(fechaDel) &&
                    System.Data.Entity.DbFunctions.TruncateTime(w.CreadoEl) <= System.Data.Entity.DbFunctions.TruncateTime(fechaAl))
                    .ToList();
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                   "ERP",
                                   this.Name,
                                   ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmProduccionSucursalList_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        public void LoadForm()
        {
            uiDel.EditValue = DateTime.Now;
            uiAl.EditValue = DateTime.Now;
            LoadEstatus();
            LoadGrid();
        }

        private void repBtnVer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                doc_produccion entity = (doc_produccion)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                if(entity!= null)
                {
                    frmProduccionSucursalUpd frmo = frmProduccionSucursalUpd.GetInstance();

                    if (!frmo.Visible)
                    {
                        //frmo = new frmPuntoVenta();
                        frmo.ID = entity.ProduccionId;
                        frmo.MdiParent = this.MdiParent;
                        frmo.puntoVentaContext = this.puntoVentaContext;
                        frmo.WindowState = FormWindowState.Maximized;
                        frmo.Show();

                    }
                }
                
               
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
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
    }
}
