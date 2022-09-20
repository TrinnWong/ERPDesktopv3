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

namespace ERP.Produccion.Desktop
{
    public partial class frmProduccionSolicitudUpd : FormBaseXtraForm
    {
        ERP.Business.ProduccionSolicitudBusiness oProduccionSolicitud;
        string error = "";
        int err = 0;
        public int idForm { get; set; }
        doc_produccion_solicitud entityForm;
        doc_produccion_solicitud_detalle entityDetForm;

        private static frmProduccionSolicitudUpd _instance;
        public static frmProduccionSolicitudUpd GetInstance()
        {

            if (_instance == null) _instance = new frmProduccionSolicitudUpd();
            return _instance;
        }

        public frmProduccionSolicitudUpd()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            oProduccionSolicitud = new Business.ProduccionSolicitudBusiness();
           
        }

        #region funciones
        private void LoadForm()
        {
            try
            {
                LoadLkpSucursales();
                LoadLkpProductos();
               
                if (this.idForm > 0)
                {
                    entityForm = oContext.doc_produccion_solicitud
                        .Where(w => w.ProduccionSolicitudId == this.idForm).FirstOrDefault();

                    if(entityForm != null)
                    {
                        uiID.EditValue = entityForm.ProduccionSolicitudId;
                        uiSucursalDe.EditValue = entityForm.DeSucursalId;
                        uiParaSucursal.EditValue = entityForm.ParaSucursalId;
                        uiCompletada.EditValue = entityForm.Completada;
                        uiActiva.EditValue = entityForm.Activa;
                        uiFechaRequerida.EditValue = entityForm.FechaProgramada;
                        uiEnviada.Checked = entityForm.Enviada??false;
                        LoadLkpDepartamento();
                        uiDepartamento.EditValue = entityForm.DepartamentoId;
                    }
                    LoadGridDetalle();
                    LimpiarCaptura();
                }
                else
                {
                    uiSucursalDe.EditValue = puntoVentaContext.sucursalId;
                    uiID.EditValue = 0;
                    uiFechaRequerida.EditValue = DateTime.Now;
                    uiActiva.Checked = true;
                }

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
            if(this.idForm > 0 )
            {
                groupControlCaptura.Enabled = true;
                uiEnviar.Enabled = true;
            }
            else
            {
                groupControlCaptura.Enabled = false;
                uiEnviar.Enabled = false;
                uiInvRequerido.Enabled = false;
            }
            if (uiEnviada.Checked)
            {
                uiGuardar.Enabled = false;
                uiEnviar.Enabled = false;
                uiInvRequerido.Enabled = true;
                groupControlCaptura.Enabled = false;
                colRepDel.OptionsColumn.AllowEdit = false;
                colRepEdit.OptionsColumn.AllowEdit = false;
                repBtnDel.ReadOnly = true;
                repBtnEdit.ReadOnly = true;
            }
            else
            {
                uiInvRequerido.Enabled = false;
                repBtnDel.ReadOnly = false;
                repBtnEdit.ReadOnly = false;
                colRepDel.OptionsColumn.AllowEdit = true;
                colRepEdit.OptionsColumn.AllowEdit = true;

            }

        }

        private void LimpiarCaptura()
        {
            uiProducto.EditValue = null;
            uiUnidad.EditValue = "";
            uiCantidad.EditValue = 0;
            entityDetForm = null;

        }

        private void LoadLkpProductos()
        {
            try
            {
                oContext = new ERPProdEntities();

                uiProducto.Properties.DataSource = oContext.cat_productos
                    .Where(
                        w => w.cat_productos_base.Count() > 0 &&
                        w.Estatus == true
                    ).ToList();
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

        private void LoadLkpSucursales()
        {
            try
            {
                oContext = new ERPProdEntities();

                uiSucursalDe.Properties.DataSource = oContext.cat_sucursales.ToList();
                uiParaSucursal.Properties.DataSource = oContext.cat_sucursales.ToList();
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

        private void LoadGridDetalle()
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

        private void LoadLkpDepartamento()
        {
            try
            {
                int sucursal = Convert.ToInt32(uiParaSucursal.EditValue);

                uiDepartamento.Properties.DataSource = oContext.cat_departamentos
                    .Where(w => w.cat_sucursales_departamentos.Where(s1 => s1.SucursalId == sucursal).Count() > 0)
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
        #endregion
        private void uiGuardar_Click(object sender, EventArgs e)
        {
           
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private cat_unidadesmed GetUnidadProducto()
        {
            try
            {
                cat_productos prodLkp = (cat_productos)uiProducto.GetSelectedDataRow();

               return prodLkp != null ?
                        prodLkp.cat_productos_base != null ?
                        (prodLkp.cat_productos_base.FirstOrDefault().cat_unidadesmed == null ? prodLkp.cat_unidadesmed : prodLkp.cat_productos_base.FirstOrDefault().cat_unidadesmed) :
                        prodLkp.cat_unidadesmed
                        : new cat_unidadesmed();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                     "ERP",
                                                     this.Name,
                                                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }

            return new cat_unidadesmed();
        }

        private void uiProducto_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
              uiUnidad.Text = GetUnidadProducto().DescripcionCorta ?? "";
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

        private void uiGuardarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
             

                entityDetForm = entityDetForm == null ? new doc_produccion_solicitud_detalle() : entityDetForm;
                entityDetForm.ProduccionSolicitudId = this.idForm;
                entityDetForm.ProductoId = Convert.ToInt32(uiProducto.EditValue);
                entityDetForm.UnidadId = GetUnidadProducto().Clave;
                entityDetForm.Cantidad = (double)uiCantidad.Value;

                error = oProduccionSolicitud.GuardarDetalle(entityDetForm, puntoVentaContext.sucursalId, puntoVentaContext.usuarioId);

                if(error.Length > 0)
                {
                   
                    ERP.Utils.MessageBoxUtil.ShowError(error);
                }
                else
                {
                    entityDetForm = new doc_produccion_solicitud_detalle();
                    LimpiarCaptura();
                    LoadGridDetalle();
                    ERP.Utils.MessageBoxUtil.ShowOk();
                }
            }
            catch (Exception ex)
            {

                LimpiarCaptura();
                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                     "ERP",
                                                     this.Name,
                                                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void repBtnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                entityDetForm = (doc_produccion_solicitud_detalle)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                uiProducto.EditValue = entityDetForm.ProductoId;
                uiCantidad.EditValue = entityDetForm.Cantidad;

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

        private void repBtnDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if( XtraMessageBox.Show("¿Está seguro(a) de eliminar el registro?", "Aviso",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                entityDetForm = (doc_produccion_solicitud_detalle)uiGridView.GetRow(uiGridView.FocusedRowHandle);
                error= oProduccionSolicitud.EliminarDetalle(entityDetForm.Id, puntoVentaContext.usuarioId, puntoVentaContext.sucursalId);

                if(error.Length > 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowError(error);
                }
                else
                {
                    LoadGridDetalle();
                    ERP.Utils.MessageBoxUtil.ShowOk();
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

        private void frmProduccionSolicitudUpd_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void frmProduccionSolicitudUpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiCancelarDetalle_Click(object sender, EventArgs e)
        {
           
            LimpiarCaptura();
        }

        private void uiGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {

                entityForm = new doc_produccion_solicitud();
                entityForm.ProduccionSolicitudId = this.idForm;
                entityForm.Activa = uiActiva.Checked;
                entityForm.Completada = uiCompletada.Checked;
                entityForm.DeSucursalId = Convert.ToInt32(uiSucursalDe.EditValue);
                entityForm.FechaProgramada = uiFechaRequerida.DateTime;
                entityForm.ParaSucursalId = Convert.ToInt32(uiParaSucursal.EditValue);
                entityForm.DepartamentoId = Convert.ToInt32( uiDepartamento.EditValue);
                error = oProduccionSolicitud.Guardar(ref entityForm, puntoVentaContext.sucursalId, puntoVentaContext.usuarioId);

                if (error.Length > 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowError(error);
                }
                else
                {
                    this.idForm = entityForm.ProduccionSolicitudId;
                    HabilitarDeshabilitar();
                    ERP.Utils.MessageBoxUtil.ShowOk();
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

        private void uiCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiEnviar_Click(object sender, EventArgs e)
        {
            try
            {

                if(XtraMessageBox.Show("¿Está seguro(a) de continuar?, no será posible revertir el envío","AVISO",MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question)!= DialogResult.Yes)
                {
                    return;
                }
                if(((List<doc_produccion_solicitud_detalle>)uiGrid.DataSource).Count() == 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("No hay productos para enviar la solicitud");
                    return;
                }

                error = oProduccionSolicitud.Enviar(this.idForm, puntoVentaContext.sucursalId, puntoVentaContext.usuarioId);

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
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                    "ERP",
                                                    this.Name,
                                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiInvRequerido_Click(object sender, EventArgs e)
        {
            ERP.Common.Produccion.frmProduccionSolicitudRequeridoList oForm = new Common.Produccion.frmProduccionSolicitudRequeridoList();

            oForm.puntoVentaContext = this.puntoVentaContext;
            oForm.produccionSolicitudID = this.idForm;
            oForm.ShowDialog();
        }

        private void uiParaSucursal_EditValueChanged(object sender, EventArgs e)
        {
            LoadLkpDepartamento();
        }
    }
}
