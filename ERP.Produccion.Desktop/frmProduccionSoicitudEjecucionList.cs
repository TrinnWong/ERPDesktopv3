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

namespace ERP.Produccion.Desktop
{
    public partial class frmProduccionSoicitudEjecucionList : FormBaseXtraForm
    {
        int err=0;
        string error = "";
        private static frmProduccionSoicitudEjecucionList _instance;
        public static frmProduccionSoicitudEjecucionList GetInstance()
        {

            if (_instance == null) _instance = new frmProduccionSoicitudEjecucionList();
            return _instance;
        }
        public frmProduccionSoicitudEjecucionList()
        {
            InitializeComponent();
        }

        public void LoadGrid()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();
                uiGrid.DataSource = oContext.doc_produccion_solicitud
                    .Where(w => w.ParaSucursalId == puntoVentaContext.sucursalId 
                    && (w.Terminada??false) == false 
                    && w.Activa == true)
                    .Select(
                        s=> new ERP.Models.ProduccionSolicitud.ProduccionSolicitudGridModel()
                        {
                             activa = s.Activa,
                            terminada = s.Terminada ?? false,
                               CreadoEl = s.CreadoEl,
                                deSucursal = s.cat_sucursales.NombreSucursal,
                                paraSucursal = s.cat_sucursales1.NombreSucursal,
                                 produccionSolicitudId = s.ProduccionSolicitudId
                        }
                    ).ToList();
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

        private void frmProduccionSoicitudEjecucionList_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void repBtnVer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(uiGridView.FocusedRowHandle >= 0)
            {
                ERP.Models.ProduccionSolicitud.ProduccionSolicitudGridModel row = (ERP.Models.ProduccionSolicitud.ProduccionSolicitudGridModel)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                frmProduccionSolicitudEjecucionForm frmo = frmProduccionSolicitudEjecucionForm.GetInstance();

                if (!frmo.Visible)
                {
                    frmo.MdiParent = frmMain.GetInstance();
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.WindowState = FormWindowState.Maximized;
                    frmo.idForm = row.produccionSolicitudId;
                    frmo.Show();

                }
            }
            
        }

        private void frmProduccionSoicitudEjecucionList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiRefrescar_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}
