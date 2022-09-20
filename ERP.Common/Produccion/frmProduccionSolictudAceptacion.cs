using ConexionBD;
using DevExpress.XtraEditors;
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
    public partial class frmProduccionSolictudAceptacion : FormBaseXtraForm
    {
        int err = 0;
        string error = "";
        public int idForm { get; set; }
        ERP.Business.ProduccionSolicitudBusiness oProduccionSolicitud;
        doc_produccion_solicitud dataForm;
        private static frmProduccionSolictudAceptacion _instance;
        public static frmProduccionSolictudAceptacion GetInstance()
        {
            if (_instance == null) _instance = new frmProduccionSolictudAceptacion();
            else _instance.BringToFront();
            return _instance;
        }
        public frmProduccionSolictudAceptacion()
        {
            InitializeComponent();
            oContext = new ConexionBD.ERPProdEntities();
            oProduccionSolicitud = new Business.ProduccionSolicitudBusiness();
        }

        private void frmProduccionSolictudAceptacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void LoadForm()
        {
            try
            {
                oContext = new ERPProdEntities();
                dataForm = oContext.doc_produccion_solicitud
                    .Where(w => w.ProduccionSolicitudId == idForm).FirstOrDefault();

                uiID.EditValue = idForm;
                uiFechaProgramada.EditValue = dataForm.FechaProgramada;

                if(dataForm.Aceptada == true)
                {
                    uiGuardar.Enabled = false;
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

        private void LoadGrid()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiGrid.DataSource = oContext.doc_produccion_solicitud_detalle
                    .Where(w => w.ProduccionSolicitudId == idForm)
                    .Select(s=> new ERP.Models.ProduccionSolicitud.ProduccionSolicitudAceptacionGrd() {
                         cantidadAceptacion = s.doc_produccion_solicitud_aceptacion.Count() > 0 ? s.doc_produccion_solicitud_aceptacion.Sum(s1=> s1.Cantidad ) : 0,
                          cantidadSolicitada = s.Cantidad,
                           clave = s.cat_productos.Clave,
                            produccionSolicitudAceptcionId = s.doc_produccion_solicitud_aceptacion.Count() > 0 ? s.doc_produccion_solicitud_aceptacion.Max(max=> max.ProduccionSolicitudAceptacionId) : 0,
                             produccionSolicitudDetalleId = s.Id,
                              producto = s.cat_productos.Descripcion,
                               unidad = s.cat_unidadesmed.DescripcionCorta,
                                unidadId = s.UnidadId,
                                productoId = s.ProductoId,
                                comentarios = s.doc_produccion_solicitud_aceptacion.Count() > 0 ? s.doc_produccion_solicitud_aceptacion.Max(max=> max.Comentarios) : ""
                    })
                    .ToList();
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

        private void frmProduccionSolictudAceptacion_Load(object sender, EventArgs e)
        {
            LoadForm();
            LoadGrid();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            if(XtraMessageBox.Show("¿Está seguro(a) de continuar?, no será posible revertir los cambios","AVISO",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
               error = oProduccionSolicitud.GuardarAceptacion(this.idForm,
                    (List<ERP.Models.ProduccionSolicitud.ProduccionSolicitudAceptacionGrd>)uiGrid.DataSource,
                    this.puntoVentaContext.usuarioId,
                    this.puntoVentaContext.sucursalId
                    );

                if(error.Length > 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowError(error);
                }
                else
                {
                    LoadForm();
                    ERP.Utils.MessageBoxUtil.ShowOk();
                }
            }
           
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
