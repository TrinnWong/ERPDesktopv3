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

namespace ERP.Common.Produccion
{
    public partial class frmProduccionSolicitudAceptacionList : FormBaseXtraForm
    {
        int err=0;
        string error = "";
        private static frmProduccionSolicitudAceptacionList _instance;
        public static frmProduccionSolicitudAceptacionList GetInstance()
        {

            if (_instance == null) _instance = new frmProduccionSolicitudAceptacionList();
            return _instance;
        }
        public frmProduccionSolicitudAceptacionList()
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
                    && w.Terminada == true 
                    && w.Activa == true
                    && (w.Aceptada??false) == false)
                    .Select(
                        s=> new ERP.Models.ProduccionSolicitud.ProduccionSolicitudGridModel()
                        {
                             activa = s.Activa,
                              completada = s.Completada,
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

                ERP.Common.Produccion.frmProduccionSolictudAceptacion frmo = frmProduccionSolictudAceptacion.GetInstance();

                if (!frmo.Visible)
                {
                    frmo.MdiParent = this.MdiParent;
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

        private void uiRefresh_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}
