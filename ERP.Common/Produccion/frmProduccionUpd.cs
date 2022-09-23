using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Models.Produccion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ConexionBD.Enumerados;

namespace ERP.Common.Produccion
{
    public partial class frmProduccionUpd : XtraForm
    {
        ERPProdEntities oContext;
        private static frmProduccionUpd _instance;
        public PuntoVentaContext puntoVentaContext;
        ProduccionBusiness oProduccionB;
        cat_productos_base_conceptos conceptoEdit;
        public  accionForm accion;
        public int id;
        public int ProductoMateriaPrimaId;
        public bool habilitarCambioProducto { get; set; }
        public static frmProduccionUpd GetInstance()
        {

            if (_instance == null) _instance = new frmProduccionUpd();
            return _instance;
        }
        public frmProduccionUpd()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            oProduccionB = new ProduccionBusiness();
           
        }

        private void frmProduccionUpd_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dB_A2ABCA_ERPDevDataSet.cat_productos' table. You can move, or remove it, as needed.
            limpiarForm();
            llenarCombos();


            if (accion == accionForm.actualizar)
            {
                lkpProducto.EditValue = id;
                lkpProducto.Enabled = false;
            }
            else {
                lkpProducto.Enabled = true;
            }

            if (this.habilitarCambioProducto) {
                lkpProducto.Enabled = true;
            }

            llenarGrid();
            llenarGridConceptos();
        }

        #region eventos del grid

        public void llenarCombos()
        {
            try
            {
                lkpProducto.Properties.DataSource = oContext.cat_productos
                     .ToList();

                uiProductoBase.Properties.DataSource = 
                    oContext.cat_productos
                    .Where(w=> w.MateriaPrima == true)                       
                    .ToList();

                repLkpProducto.DataSource = oContext.cat_productos
                    .Where(w => w.MateriaPrima == true)
                    .ToList();

                uiConcepto.Properties.DataSource = oContext
                    .cat_conceptos.Where(w => w.Activo == true).ToList();



            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void llenarGrid()
        {
            try
            {
                int productoId = 0;
                int.TryParse(lkpProducto.EditValue == null ? "0" : lkpProducto.EditValue.ToString(), out productoId);

                List<ProduccionDetalleModel> lst = oProduccionB.GetDetalleByProducto(productoId); 
                uiGrid.DataSource = new BindingList<ProduccionDetalleModel>(lst); 
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void lkpProducto_EditValueChanged(object sender, EventArgs e)
        {
            limpiarForm();
            llenarGrid();
            llenarGridConceptos();

        }

        
        private void uiGuardar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                int productoId = 0;
                int.TryParse(lkpProducto.EditValue == null ? "0" : lkpProducto.EditValue.ToString(), out productoId);

                if (accion == accionForm.agregar)
                {
                   // DataTable dt = (DataTable)uiGrid.DataSource;


                    BindingList<ProduccionDetalleModel> lst = (BindingList<ProduccionDetalleModel>)uiGridView.DataSource;
                    
                    error = oProduccionB.InsertDetalle(productoId, lst.ToList());
                    llenarGrid();
                }


                if(error.Length > 0)
                {
                    XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    XtraMessageBox.Show("Proceso terminó con éxito", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmProduccionUpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiGridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            ProduccionDetalleModel entity = (ProduccionDetalleModel)e.Row;

            int productoId = entity.ProductoBaseId;

           string unidad =  oContext.cat_productos.Where(w => w.ProductoId == productoId).FirstOrDefault().cat_unidadesmed.Descripcion;
           
            uiGridView.SetRowCellValue(uiGridView.FocusedRowHandle, "Unidad", unidad);
        }

        private void uiGridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {

            ProduccionDetalleModel item = (ProduccionDetalleModel)e.Row;
            string error = oProduccionB.DeleteDetalle(item.ProductoMateriaPrimaId);

            if (error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void uiAgregar_Click(object sender, EventArgs e)
        {
            //uiGridView.AddNewRow();
        }

        private void uiGridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            int productoId = 0;
            int.TryParse(lkpProducto.EditValue == null ? "0" : lkpProducto.EditValue.ToString(), out productoId);

            ProduccionDetalleModel item = (ProduccionDetalleModel)e.Row;
            string error = oProduccionB.InsertDetalle(productoId, ref item);

            if (error.Length > 0)
            {

                //XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Valid = false;
                e.ErrorText = error;

            }
            else
            {
                uiGridView.SetRowCellValue(e.RowHandle, "ProductoMateriaPrimaId", item.ProductoMateriaPrimaId);
            }
        }

        private void uiGuardar1_Click(object sender, EventArgs e)
        {
            try
            {
                if(uiUnidadCocina.EditValue == null)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("La unidad para Cocina es requerida");
                    return;
                }
                int productoId = 0;
                int.TryParse(lkpProducto.EditValue == null ? "0" : lkpProducto.EditValue.ToString(), out productoId);

                cat_productos entityProducto = (cat_productos)uiProductoBase.GetSelectedDataRow();

                if(entityProducto != null)
                {
                    ProduccionDetalleModel item = new ProduccionDetalleModel();

                    if(ProductoMateriaPrimaId> 0)
                    {
                        item.ProductoMateriaPrimaId = ProductoMateriaPrimaId;
                    }
                    item.Cantidad = uiCantidad.Value;
                    item.ProductoId = productoId;
                    item.ProductoBaseId = entityProducto.ProductoId;
                    item.UnidadConcinaId = Convert.ToInt32(uiUnidadCocina.EditValue);
                    item.Cocina = uiCocina.Checked;
                    item.Requerido = uiRequerido.Checked;
                    item.Orden = Convert.ToInt32(uiOrden.Value);
                    item.GenerarSalidaVenta = uiGenerarSalida.Checked;
                    string error = oProduccionB.InsertDetalle(productoId, ref item);

                    if(error.Length > 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowError(error);
                    }
                    else
                    {
                       // ERP.Utils.MessageBoxUtil.ShowOk();
                        limpiarForm();
                        llenarGrid();
                    }
                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Selecciona un producto Base");
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

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            limpiarForm();
        }

        private void limpiarForm()
        {
            ProductoMateriaPrimaId = 0;
            uiProductoBase.EditValue = null;
            uiProductoBase.Text = "";
            uiCantidad.EditValue = 0;
            uiProductoBase.ReadOnly = false;
            uiUnidadCocina.EditValue = null;
            uiCocina.Checked = false;
            uiRequerido.Checked = false;
            uiOrden.EditValue = 0;
            uiGenerarSalida.Checked = true;
         
        }

        private void repBtnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                ProduccionDetalleModel item = (ProduccionDetalleModel)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                if (item.ProductoMateriaPrimaId > 0)
                {

                    uiProductoBase.EditValue = item.ProductoBaseId;
                    ProductoMateriaPrimaId = item.ProductoMateriaPrimaId;
                    uiCantidad.EditValue = item.Cantidad;
                    uiProductoBase.ReadOnly = true;
                    uiCocina.EditValue = item.Cocina;
                    uiRequerido.Checked = item.Requerido;
                    uiOrden.EditValue = item.Orden;
                    uiGenerarSalida.Checked = item.GenerarSalidaVenta;
                    cat_productos productoBase = oContext.cat_productos
                        .Where(w => w.ProductoId == item.ProductoBaseId).FirstOrDefault();

                    LoadUnidadCocina(productoBase.ClaveUnidadMedida ?? 0);

                    uiUnidadCocina.EditValue = item.UnidadConcinaId;
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

        private void repBtnDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(XtraMessageBox.Show("¿Está seguro(a) de continuar?","Aviso",MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProduccionDetalleModel item = (ProduccionDetalleModel)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    if (item.ProductoMateriaPrimaId > 0)
                    {
                        oProduccionB.DeleteDetalle(item.ProductoMateriaPrimaId);
                        llenarGrid();
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

        private void uiGuardarConcepto_Click(object sender, EventArgs e)
        {
            try
            {
                if(uiConcepto.EditValue != null)
                {
                    int conceptoId = Convert.ToInt32(uiConcepto.EditValue);
                    if(oContext.cat_productos_base_conceptos
                        .Where(w=> w.ConceptoId == conceptoId && w.ProductoId == id).Count() > 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("El concepto ya existe");
                        return;
                    }
                    cat_productos_base_conceptos entityNew = new cat_productos_base_conceptos();

                    entityNew.ConceptoId = Convert.ToInt32(uiConcepto.EditValue);
                    entityNew.ProductoId = Convert.ToInt32(lkpProducto.EditValue);

                    entityNew.RegistrarTiempo = uiRegistrarTiempo.Checked;
                    entityNew.RegistrarVolumen = uiRegistrarVolumen.Checked;
                    entityNew.CreadoEl = "";

                    oContext.cat_productos_base_conceptos.Add(entityNew);

                    oContext.SaveChanges();

                    llenarGridConceptos();

                    uiConcepto.EditValue = null;
                    uiRegistrarTiempo.Checked = false;
                    uiRegistrarVolumen.Checked = false;


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

        private void llenarGridConceptos()
        {
            try
            {
                
                oContext = new ERPProdEntities();
                uiGridConcepto.DataSource = oContext.cat_productos_base_conceptos
                    .Where(w=> w.ProductoId == id).ToList();
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

        private void repBtnConceptoDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("¿Está seguro(a) de continuar?", "Aviso", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                
                    cat_productos_base_conceptos entityDel = (cat_productos_base_conceptos)uiGridViewConcepto
                    .GetRow(uiGridViewConcepto.FocusedRowHandle);

                if(entityDel != null)
                {
                    cat_productos_base_conceptos entityDel2 = oContext
                        .cat_productos_base_conceptos
                        .Where(W => W.Id == entityDel.Id).FirstOrDefault();

                    oContext.cat_productos_base_conceptos.Remove(entityDel2);
                    oContext.SaveChanges();

                    llenarGridConceptos();
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

        private void uiProductoBase_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(uiProductoBase.GetSelectedDataRow() != null)
                {
                    cat_productos productoBase = (cat_productos)uiProductoBase.GetSelectedDataRow();
                    uiUnidad.Text = productoBase.cat_unidadesmed.DescripcionCorta;

                    LoadUnidadCocina(productoBase.ClaveUnidadMedida??0);


                }
                else
                {
                    uiUnidad.Text = "";
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

        private void LoadUnidadCocina(int unidadBaseId)
        {
            uiUnidadCocina.EditValue = null;
            oContext = new ERPProdEntities();
            uiUnidadCocina.Properties.DataSource = oContext.cat_unidadesmed
                .Where(w => w.Clave == unidadBaseId || w.DescripcionCorta.ToUpper().Contains("PIEZA")).ToList();

            uiUnidadCocina.EditValue = unidadBaseId;
        }
    }
}
