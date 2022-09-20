using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Business.Tools;
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
    public partial class frmProduccionSolicitudRequeridoAjusteUnidad : FormBaseXtraForm
    {
        int err = 0;
        string error = "";
        private static frmProduccionSolicitudRequeridoAjusteUnidad _instance;
        public int idForm { get; set; }
        public doc_produccion_solicitud entity {get;set;}
        BasculaLectura basculaControlador;
        doc_produccion_solicitud_requerido rowGrid1;
        ERP.Business.ProduccionSolicitudBusiness oProduccionSolicitud;
       
        public static frmProduccionSolicitudRequeridoAjusteUnidad GetInstance()
        {
            if (_instance == null) _instance = new frmProduccionSolicitudRequeridoAjusteUnidad();
            return _instance;
        }
        public frmProduccionSolicitudRequeridoAjusteUnidad()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            oProduccionSolicitud = new Business.ProduccionSolicitudBusiness();
        }

        private void frmProduccionSolicitudRequeridoAjusteUnidad_Load(object sender, EventArgs e)
        {
            try
            {
                basculaControlador = new BasculaLectura(this.puntoVentaContext);
                entity = oContext.doc_produccion_solicitud
                    .Where(w => w.ProduccionSolicitudId == idForm).FirstOrDefault();

                if (entity.Iniciada == true)
                {
                    uiGuardar.Enabled = false;
                    uiCancelar.Enabled = false;
                    gridColumn2.OptionsColumn.AllowEdit = false;
                }

                LoadGrid();
                LoadGridAjuste();
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

        public void LoadGrid()
        {
            try
            {
                uiGrid.DataSource = oContext.doc_produccion_solicitud_requerido
                    .Where(w => w.doc_produccion_solicitud_detalle.ProduccionSolicitudId == idForm &&
                    w.UnidadRequeridaId != w.cat_productos.ClaveUnidadMedida)
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


        public void LoadGridAjuste()
        {
            try
            {
                uiGridAjuste.DataSource = oContext.doc_produccion_solicitud_ajuste_unidad
                     .Where(w => w.doc_produccion_solicitud_detalle.ProduccionSolicitudId == idForm).ToList();
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

        private void frmProduccionSolicitudRequeridoAjusteUnidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            basculaControlador.cerrarBascula(); 
            _instance = null;
        }


        private void SeleccionGrid()
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    rowGrid1 = (doc_produccion_solicitud_requerido)uiGridView.GetRow(uiGridView.FocusedRowHandle);
                    uiCantidad.EditValue = 0;
                    uiProducto.Text = rowGrid1.cat_productos.Clave + "-"+ rowGrid1.cat_productos.Descripcion;
                    uiUnidad.Text = rowGrid1.cat_productos.cat_unidadesmed.DescripcionCorta;


                    if (rowGrid1.cat_productos.ProdVtaBascula == true)
                    {
                        uiCantidad.Enabled = false;
                        timer1.Enabled = true;
                        basculaControlador.abrirBascula();
                    }
                    else
                    {
                        timer1.Enabled = false;
                        uiCantidad.Enabled = true;
                        uiCantidad.Focus();
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

        private void LimpiarCaptura()
        {
            uiCantidad.EditValue = 0;
            uiProducto.EditValue = null;
            uiUnidad.Text = "";
            rowGrid1 = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                uiCantidad.EditValue = basculaControlador.ObtenPeso();
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

        private void repBtnSeleccion_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SeleccionGrid();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                doc_produccion_solicitud_ajuste_unidad datos = new doc_produccion_solicitud_ajuste_unidad();

                datos.Cantidad = (double)uiCantidad.Value;
                datos.ProduccionSolicitudDetalleId = rowGrid1.ProduccionSolicitudDetalleId;
                datos.ProductoId = rowGrid1.ProductoRequeridoId;
                datos.UnidadId = rowGrid1.cat_productos.ClaveUnidadMedida??0;

                error = oProduccionSolicitud.GuardarAjusteUnidad(datos, puntoVentaContext.usuarioId, puntoVentaContext.sucursalId);

                if(error.Length > 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowError(error);
                }
                else
                {
                    LimpiarCaptura();
                    LoadGridAjuste();
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

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCaptura();
        }

        private void repBtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(XtraMessageBox.Show("¿Está seguro(a) de eliminar este registro?","Aviso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                doc_produccion_solicitud_ajuste_unidad datos = (doc_produccion_solicitud_ajuste_unidad)uiGridAjusteView.GetRow(uiGridAjusteView.FocusedRowHandle);

               

                error = oProduccionSolicitud.EliminarAjusteUnidad(datos.Id, puntoVentaContext.usuarioId, puntoVentaContext.sucursalId);

                if (error.Length > 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowError(error);
                }
                else
                {
                    LimpiarCaptura();
                    LoadGridAjuste();
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
    }
}
