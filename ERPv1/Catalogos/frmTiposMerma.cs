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

namespace ERPv1.Catalogos
{
    public partial class frmTiposMerma : FormBaseXtraForm
    {
        int err;
        private static frmTiposMerma _instance;
        private cat_tipos_mermas entity;
        public static frmTiposMerma GetInstance()
        {
            if (_instance == null) _instance = new frmTiposMerma();
            else _instance.BringToFront();
            return _instance;
        }
        public frmTiposMerma()
        {
            InitializeComponent();
        }

        private void frmTiposMerma_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void LoadGrid()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiGrid.DataSource = oContext.cat_tipos_mermas.ToList();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(
                      puntoVentaContext.usuarioId,
                             "ERP",
                             this.Name,
                             ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmTiposMerma_Load(object sender, EventArgs e)
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();
                entity = new cat_tipos_mermas();
                LoadGrid();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(
                      puntoVentaContext.usuarioId,
                             "ERP",
                             this.Name,
                             ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            try
            {
                if(uiTipo.Text.Trim().Length == 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowError("El tipo es requerido");
                    return;
                }
                cat_tipos_mermas entitySave = new cat_tipos_mermas();
                if(entity.TipoMermaId > 0)
                {
                    entitySave = oContext.cat_tipos_mermas.Where(w => w.TipoMermaId == entity.TipoMermaId)
                        .FirstOrDefault();

                    entitySave.Tipo = uiTipo.Text;
                    oContext.SaveChanges();
                }
                else
                {
                    entitySave.TipoMermaId = (short)((oContext.cat_tipos_mermas.Max(m => (short?)m.TipoMermaId) ?? 0) + 1);
                    entitySave.Tipo = uiTipo.Text;
                    entitySave.CreadoEl = DateTime.Now;

                    oContext.cat_tipos_mermas.Add(entitySave);
                    oContext.SaveChanges();
                }

                LimpiarEdicion();
                LoadGrid();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(
                     puntoVentaContext.usuarioId,
                            "ERP",
                            this.Name,
                            ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LimpiarEdicion()
        {
            uiTipo.Text = "";
            entity = new cat_tipos_mermas();
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Eliminar()
        {
            try
            {
                if (uiGridView.FocusedRowHandle >= 0)
                {
                    if(XtraMessageBox.Show("¿Está seguro(a) de continuar?","Atención", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                        entity = (cat_tipos_mermas)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                        entity = oContext.cat_tipos_mermas.Where(w => w.TipoMermaId == entity.TipoMermaId)
                            .FirstOrDefault();

                        oContext.cat_tipos_mermas.Remove(entity);
                        oContext.SaveChanges();

                        LoadGrid();
                    }
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(
                    puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void Editar()
        {
            try
            {
                if (uiGridView.FocusedRowHandle >= 0)
                {
                    entity = (cat_tipos_mermas)uiGridView.GetRow(uiGridView.FocusedRowHandle);
                    uiTipo.Text = entity.Tipo;
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(
                    puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void repBtnEdit_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void repBtnEliminar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Eliminar();
        }

        private void uiLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarEdicion();
        }
    }
}
