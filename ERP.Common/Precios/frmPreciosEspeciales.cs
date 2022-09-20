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

namespace ERP.Common.Precios
{
    public partial class frmPreciosEspeciales : FormBaseXtraForm
    {
        doc_precios_especiales entity;
        int err = 0;

        private static frmPreciosEspeciales _instance;
        public static frmPreciosEspeciales GetInstance()
        {
            if (_instance == null) _instance = new frmPreciosEspeciales();
            else _instance.BringToFront();
            return _instance;
        }
        public frmPreciosEspeciales()
        {
            InitializeComponent();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(entity.Id == 0)
                {
                    entity = new doc_precios_especiales();
                    entity.Descripcion = uiNombrePrecio.Text;
                    entity.FechaVigencia = uiVigencia.DateTime;
                    entity.HoraVigencia = DateTime.Now;
                    entity.CreadoEl = DateTime.Now;
                    entity.CreadoPor = puntoVentaContext.usuarioId;
                    entity.SucursalId = puntoVentaContext.sucursalId;
                    entity = oContext.doc_precios_especiales.Add(entity);
                    oContext.SaveChanges();                    
                }
                else
                {
                    doc_precios_especiales entityUpd = oContext.doc_precios_especiales
                        .Where(w => w.Id == entity.Id).FirstOrDefault();

                    entityUpd.Descripcion = uiNombrePrecio.Text;
                    entityUpd.FechaVigencia = uiVigencia.DateTime;
                    entityUpd.SucursalId = puntoVentaContext.sucursalId;
                    oContext.SaveChanges();
                }
                ERP.Utils.MessageBoxUtil.ShowOk();
                LoadPreciosEspeciales();

                uiPreciosEspeciales.EditValue = entity.Id;

                if (entity.Id > 0)
                {
                    uiGC.Enabled = true;
                }
                else {
                    uiGC.Enabled = false;   
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

        private void LoadPreciosEspeciales()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiPreciosEspeciales.Properties.DataSource = oContext.doc_precios_especiales
                    .Where(w=> w.SucursalId == puntoVentaContext.sucursalId)                    
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

        private void frmPreciosEspeciales_Load(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();
            entity = new doc_precios_especiales();
            LoadPreciosEspeciales();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            uiPreciosEspeciales.EditValue = null;
            uiNombrePrecio.Text = "";
            uiVigencia.DateTime = DateTime.Now;
        }

        private void uiBuscarProductos_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            try
            {
                uiGrid.DataSource = oContext.p_doc_precios_especiales_grd(entity.Id,
                    uiBuscador.Text,
                    uiSoloPrecioEspecial.Checked).ToList();
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

        private void uiPreciosEspeciales_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(uiPreciosEspeciales.GetSelectedDataRow() != null)
                {
                    entity = (doc_precios_especiales)uiPreciosEspeciales.GetSelectedDataRow();

                    uiNombrePrecio.Text = entity.Descripcion;
                    uiVigencia.DateTime = entity.FechaVigencia;

                    uiGC.Enabled = true;
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

        private void frmPreciosEspeciales_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;  
        }

        private void uiBuscador_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadGrid();
            }
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EspecificarAumento(decimal aumento)
        {
            try
            {
                List<p_doc_precios_especiales_grd_Result> lst = (List<p_doc_precios_especiales_grd_Result>)uiGrid.DataSource;

                for (int i = 0; i < lst.Count(); i++)
                {
                    lst[i].MontoAdicional = aumento;
                    lst[i].PrecioEspecial = 0;
                    lst[i].PrecioEspecialFinal = lst[i].PrecioVenta + aumento;

                    
                }

                uiGrid.DataSource = lst;
                uiGrid.RefreshDataSource();
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

        private void uiAumentoMasivo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void uiAumentoMasivo_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                EspecificarAumento(uiAumentoMasivo.Value);
                uiAumentoMasivo.EditValue = 0;
            }
            
        }

        private void GuardarPrecios()
        {
            try
            {
                if (entity.Id == 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("No se ha seleccionado un grupo de productos especiales");
                    return;
                }
                List<p_doc_precios_especiales_grd_Result> lst = (List<p_doc_precios_especiales_grd_Result>)uiGrid.DataSource;

                foreach (var item in lst)
                {
                    if(item.PrecioEspecialDetalleId > 0)
                    {
                        doc_precios_especiales_detalle entityDet = oContext.doc_precios_especiales_detalle
                            .Where(w => w.Id == item.PrecioEspecialDetalleId).FirstOrDefault();

                        entityDet.MontoAdicional = item.MontoAdicional??0;
                        entityDet.PrecioEspecial = item.MontoAdicional >0 ? 0: item.PrecioEspecial??0;
                        entityDet.ModificadoPor = puntoVentaContext.usuarioId;
                        entityDet.ModificadoEl = DateTime.Now;

                        oContext.SaveChanges();

                    }
                    else
                    {
                        doc_precios_especiales_detalle entityDetNew = new doc_precios_especiales_detalle();

                        entityDetNew.CreadoEl = DateTime.Now;
                        entityDetNew.CreadoPor = puntoVentaContext.usuarioId;
                        entityDetNew.MontoAdicional = item.MontoAdicional??0;
                        entityDetNew.PrecioEspecial = item.PrecioEspecial??0;
                        entityDetNew.ProductoId = item.ProductoId;
                        entityDetNew.PrecioEspeciaId = entity.Id;

                        oContext.doc_precios_especiales_detalle.Add(entityDetNew);
                        oContext.SaveChanges();
                    }

                }

                ERP.Utils.MessageBoxUtil.ShowOk();
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

        private void uiGuardarPrecios_Click(object sender, EventArgs e)
        {
            if(XtraMessageBox.Show("¿Este proceso puede tardar varios minutos?, ¿Está seguro(a) de continar?","Aviso",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GuardarPrecios();
            }
        }
    }
}
