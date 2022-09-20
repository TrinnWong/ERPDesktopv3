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
    public partial class frmProduccionSolicitudEjecucionForm : FormBaseXtraForm
    {
        int err;
        string error = "";
        public int idForm { get; set; }
        doc_produccion_solicitud entity;
        private static frmProduccionSolicitudEjecucionForm _instance;
        public static frmProduccionSolicitudEjecucionForm GetInstance()
        {

            if (_instance == null) _instance = new frmProduccionSolicitudEjecucionForm();
            return _instance;
        }

        ERP.Business.ProduccionSolicitudBusiness oProduccionSolicitud;
        public frmProduccionSolicitudEjecucionForm()
        {
            InitializeComponent();
            oContext = new ConexionBD.ERPProdEntities();
            oProduccionSolicitud = new Business.ProduccionSolicitudBusiness();
        }

        public void LoadGrid()
        {
            try
            {
               
                uiGrid.DataSource = oContext.doc_produccion_solicitud_detalle
                    .Where(w => w.ProduccionSolicitudId == this.idForm).ToList();
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

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProduccionSolicitudEjecucionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void frmProduccionSolicitudEjecucionForm_Load(object sender, EventArgs e)
        {
            try
            {
                entity = oContext.doc_produccion_solicitud
                .Where(w => w.ProduccionSolicitudId == this.idForm).FirstOrDefault();
                uiID.Value = entity.ProduccionSolicitudId;
                uiFechaRequerida.EditValue = entity.FechaProgramada;
                LoadGrid();
                HabilitarDeshabilitar();
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

        private void HabilitarDeshabilitar()
        {
            if(entity.Iniciada == true)
            {
                uiIniciar.Enabled = false;
            }
            else
            {
                uiIniciar.Enabled = true;
            }

            if(entity.Iniciada == true)
            {
                uiTerminar.Enabled = true; 
            }
            else
            {
                uiTerminar.Enabled = false;
            }

            if(entity.Terminada == true)
            {
                uiTerminar.Enabled = false;
            }
        }

        private void uiIniciar_Click(object sender, EventArgs e)
        {
            error = oProduccionSolicitud.Iniciar(this.idForm, this.puntoVentaContext.usuarioId, this.puntoVentaContext.sucursalId);

            if(error.Length > 0)
            {
                ERP.Utils.MessageBoxUtil.ShowError(error);
            }
            else
            {
                oContext = new ERPProdEntities();
                entity = oContext.doc_produccion_solicitud
              .Where(w => w.ProduccionSolicitudId == this.idForm).FirstOrDefault();

                HabilitarDeshabilitar();
                ERP.Utils.MessageBoxUtil.ShowOk();
            }
        }

        private void uiTerminar_Click(object sender, EventArgs e)
        {
            error = oProduccionSolicitud.Terminar(this.idForm, this.puntoVentaContext.usuarioId, this.puntoVentaContext.sucursalId);

            if (error.Length > 0)
            {
                ERP.Utils.MessageBoxUtil.ShowError(error);
            }
            else
            {
                oContext = new ERPProdEntities();
                entity = oContext.doc_produccion_solicitud
               .Where(w => w.ProduccionSolicitudId == this.idForm).FirstOrDefault();

                HabilitarDeshabilitar();
                ERP.Utils.MessageBoxUtil.ShowOk();
            }
        }

        private void uiAjusteUnidades_Click(object sender, EventArgs e)
        {

                ERP.Common.Produccion.frmProduccionSolicitudRequeridoAjusteUnidad frmo = ERP.Common.Produccion.frmProduccionSolicitudRequeridoAjusteUnidad.GetInstance();

                if (!frmo.Visible)
                {
                    frmo.MdiParent = frmMain.GetInstance();
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.WindowState = FormWindowState.Maximized;
                    frmo.idForm = this.idForm;
                    frmo.Show();

                }
            
        }

        private void uiInvRequerido_Click(object sender, EventArgs e)
        {
            ERP.Common.Produccion.frmProduccionSolicitudRequeridoList oForm = new Common.Produccion.frmProduccionSolicitudRequeridoList();

            oForm.puntoVentaContext = this.puntoVentaContext;
            oForm.produccionSolicitudID = this.idForm;
            oForm.ShowDialog();
        }
    }
}
