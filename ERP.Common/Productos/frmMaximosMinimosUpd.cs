using ConexionBD;
using ERP.Common.Base;
using ERP.Common.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Productos
{
    public partial class frmMaximosMinimosUpd : FormBaseXtraForm
    {
        public bool deshabilitarSucursal = false;
        int err = 0;
        public static frmMaximosMinimosUpd GetInstance()
        {
            if (_instance == null) _instance = new frmMaximosMinimosUpd();
            return _instance;
        }
        private static frmMaximosMinimosUpd _instance;

        public frmMaximosMinimosUpd()
        {
            InitializeComponent();
        }

        private void LoadGrid()
        {
            try
            {
                uiGrid.DataSource = oContext.p_doc_productos_max_min_grd(Convert.ToInt32(uiSucursal.EditValue), true)
                    .ToList();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                 "ERP",
                                 this.Name,
                                 ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmMaximosMinimosUpd_Load(object sender, EventArgs e)
        {
            oContext = new ConexionBD.ERPProdEntities();
            oFormLoading = new LoadingForm("Procesando...");
            loadSucursales();
            if(deshabilitarSucursal)
            {
                uiSucursal.EditValue = this.puntoVentaContext.sucursalId;
                uiSucursal.Enabled = false;
            }
            LoadGrid();
        }

        private void uiSucursal_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            oFormLoading.Show();
            guardar();
            oFormLoading.Hide();
        }

        private void guardar()
        {
            try
            {
                foreach (p_doc_productos_max_min_grd_Result item in (List<p_doc_productos_max_min_grd_Result>)uiGrid.DataSource)
                {
                    oContext.p_doc_productos_max_min_ins_upd(Convert.ToInt32(uiSucursal.EditValue),
                        item.ProductoId, item.Maximo, item.Minimo);
                }

                LoadGrid();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                "ERP",
                                this.Name,
                                ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void loadSucursales()
        {
            try
            {
                uiSucursal.Properties.DataSource =
                    ERP.Business.SucursalBusiness.ObtenSucursalesPorUsuario(this.puntoVentaContext.empresaId,
                    this.puntoVentaContext.usuarioId);
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                "ERP",
                                this.Name,
                                ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmMaximosMinimosUpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
