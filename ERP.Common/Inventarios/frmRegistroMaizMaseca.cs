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

namespace ERP.Common.Inventarios
{
    public partial class frmRegistroMaizMaseca : FormBaseXtraForm
    {
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
                doc_maiz_maseca_rendimiento entityUpd = new doc_maiz_maseca_rendimiento();

                if(entitySelect.Id == 0)
                {
                    entityUpd.Id = (oContext.doc_maiz_maseca_rendimiento
                        .Max(m => (int?)m.Id) ?? 0) + 1;
                    entityUpd.MaizSacos = Convert.ToDouble(uiMaizSacos.EditValue);
                    entityUpd.MasecaSacos = Convert.ToDouble(uiMasecaSacos.EditValue);
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
    }
}
