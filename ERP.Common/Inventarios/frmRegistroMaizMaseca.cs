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

namespace ERP.Common.Inventarios
{
    public partial class frmRegistroMaizMaseca : FormBaseXtraForm
    {
        string error = "";
        ConexionBD.doc_maiz_maseca_rendimiento entitySelect;
        int err = 0;
        public frmRegistroMaizMaseca()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            try
            {
                uiFecha.EditValue = DateTime.Now;
                uiMaizSacos.EditValue = 0;
                uiMasecaSacos.EditValue = 0;

                entitySelect = new doc_maiz_maseca_rendimiento();
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

        private void Guardar()
        {
            try
            {

                double kgTortillaMaiz = 0;
                double KgTortillaMaseca = 0;

                if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                   this.puntoVentaContext.sucursalId, "PROD-EquivalenciaMaizSacoTortillaKg", this.puntoVentaContext.usuarioId,ref error))
                {
                    kgTortillaMaiz = Convert.ToDouble(error);
                }

                if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                   this.puntoVentaContext.sucursalId, "PROD-EquivalenciaMasecaSacoTortillaKg", this.puntoVentaContext.usuarioId, ref error))
                {
                    KgTortillaMaseca = Convert.ToDouble(error);
                }

                if(kgTortillaMaiz <= 0 || KgTortillaMaseca <= 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario configurar la preferencia EquivalenciaMaizSacoTortillaKg y EquivalenciaMasecaSacoTortillaKg, por favor avise al administrador");
                    return;
                }

                doc_maiz_maseca_rendimiento entityUpd = new doc_maiz_maseca_rendimiento();

                if(entitySelect.Id == 0)
                {
                    entityUpd.Id = (oContext.doc_maiz_maseca_rendimiento
                        .Max(m => (int?)m.Id) ?? 0) + 1;
                    entityUpd.MaizSacos = Convert.ToDouble(uiMaizSacos.EditValue);
                    entityUpd.MasecaSacos = Convert.ToDouble(uiMasecaSacos.EditValue);
                    entityUpd.TortillaMaizRendimiento = kgTortillaMaiz * Convert.ToDouble(uiMaizSacos.EditValue);
                    entityUpd.TortillaMasecaRendimiento = KgTortillaMaseca * Convert.ToDouble(uiMasecaSacos.EditValue);
                    entityUpd.TortillaTotalRendimiento = entityUpd.TortillaMaizRendimiento + entityUpd.TortillaMasecaRendimiento;
                    entityUpd.CreadoEl = DateTime.Now;
                    entityUpd.CreadoPor = puntoVentaContext.usuarioId;
                    oContext.doc_maiz_maseca_rendimiento.Add(entityUpd);

                }
                else
                {
                    entityUpd = oContext.doc_maiz_maseca_rendimiento
                        .Where(w => w.Id == entitySelect.Id).FirstOrDefault();

                    entityUpd.MaizSacos = Convert.ToDouble(uiMaizSacos.EditValue);
                    entityUpd.MasecaSacos = Convert.ToDouble(uiMasecaSacos.EditValue);
                    entityUpd.ModificadoEl = DateTime.Now;
                    entityUpd.ModificadoPor = puntoVentaContext.usuarioId;
                    entityUpd.TortillaMaizRendimiento = kgTortillaMaiz * Convert.ToDouble(uiMaizSacos.EditValue);
                    entityUpd.TortillaMasecaRendimiento = KgTortillaMaseca * Convert.ToDouble(uiMasecaSacos.EditValue);
                    entityUpd.TortillaTotalRendimiento = entityUpd.TortillaMaizRendimiento + entityUpd.TortillaMasecaRendimiento;

                    oContext.SaveChanges();
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

        private void frmRegistroMaizMaseca_Load(object sender, EventArgs e)
        {
            entitySelect = new ConexionBD.doc_maiz_maseca_rendimiento();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void repBtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    entitySelect = (doc_maiz_maseca_rendimiento)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    uiMaizSacos.EditValue = entitySelect.MaizSacos;
                    uiMasecaSacos.EditValue = entitySelect.MasecaSacos;
                    uiFecha.EditValue = entitySelect.Fecha;
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

        private void repBtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (uiGridView.FocusedRowHandle >= 0)
                {
                    if(XtraMessageBox.Show("¿Está seguro(a) de continuar?","Aviso",
                        MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        entitySelect = (doc_maiz_maseca_rendimiento)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                        doc_maiz_maseca_rendimiento entityDel = oContext.doc_maiz_maseca_rendimiento
                            .Where(w => w.Id == entitySelect.Id).FirstOrDefault();

                        oContext.doc_maiz_maseca_rendimiento.Remove(entityDel);
                        oContext.SaveChanges();
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
    }
}
