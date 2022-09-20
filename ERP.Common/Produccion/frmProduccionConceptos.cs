using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Business;
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
    public partial class frmProduccionConceptos : FormBaseXtraForm
    {
        int errN = 0;
        string error = "";
        public int ProduccionID { get; set; }
        public List<cat_productos_base_conceptos> lstConceptos { get; set; }
        public List<doc_produccion_conceptos> lstProduccionConceptos { get; set; }
        private static frmProduccionConceptos _instance;
        short numBotones = 10;
        int conceptoSeleccionadoId;

        ProduccionConceptosBusiness oProduccionConceptosBusiness;
        cat_productos_base_conceptos conceptoInfo;
        public static frmProduccionConceptos GetInstance()
        {
            if (_instance == null) _instance = new frmProduccionConceptos();
            else _instance.BringToFront();
            return _instance;
        }

        public frmProduccionConceptos()
        {
            InitializeComponent();
            oProduccionConceptosBusiness = new ProduccionConceptosBusiness();
        }

        private void ClearObjects()
        {
            oProduccionConceptosBusiness = null;
        }

        private void LlenarBotones()
        {
            try
            {
                short i = 1;
                foreach (var item in lstConceptos)
                {
                    Control controlA = Controls.Find("uiConcepto" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.AccessibleName = item.cat_conceptos.ConceptoId.ToString();
                        controlA.Text = item.cat_conceptos.Descripcion;
                    }
                    i++;
                }

                /****Habilitar todos los botones****/
                for (short j = 1; j <= numBotones; j++)
                {
                    Control controlA = Controls.Find("uiConcepto" + j.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.Enabled = true;

                    }
                }




                /*Deshabilitar botones sin productos*/
                if ((lstConceptos.Count() + 1) <= numBotones)
                {
                    for (int j = (lstConceptos.Count() + 1); j <= numBotones; j++)
                    {
                        Control controlA = Controls.Find("uiConcepto" + j.ToString(), true).FirstOrDefault();
                        if (controlA != null)
                        {
                            controlA.Enabled = false;
                            controlA.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(
                    puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmProduccionConceptos_Load(object sender, EventArgs e)
        {
            uiConcepto1.Click += new EventHandler(button_Click);
            uiConcepto2.Click += new EventHandler(button_Click);
            uiConcepto3.Click += new EventHandler(button_Click);
            uiConcepto4.Click += new EventHandler(button_Click);
            uiConcepto5.Click += new EventHandler(button_Click);
            uiConcepto6.Click += new EventHandler(button_Click);
            uiConcepto7.Click += new EventHandler(button_Click);
            uiConcepto8.Click += new EventHandler(button_Click);
            uiConcepto9.Click += new EventHandler(button_Click);
            uiConcepto10.Click += new EventHandler(button_Click);
            LlenarBotones();
            llenarGrid();
        }


        private void button_Click(object sender, System.EventArgs e)
        {
            try
            {
                Control controlBTtn = Controls.Find(((SimpleButton)sender).Name, true).FirstOrDefault();
                if (controlBTtn == null)
                    return;
                conceptoSeleccionadoId = Convert.ToInt32(controlBTtn.AccessibleName);

                if(conceptoSeleccionadoId > 0)
                {
                    uiAgregar.Enabled = true;
                    conceptoInfo = lstConceptos.Where(w => w.ConceptoId == conceptoSeleccionadoId)
                        .FirstOrDefault();
                    uiConcepto.Text = conceptoInfo.cat_conceptos.Descripcion;

                    if(conceptoInfo.RegistrarTiempo == true)
                    {
                        uiInicio.EditValue = DateTime.Now;
                        uiFin.EditValue = DateTime.Now;
                        uiInicio.Enabled = true;
                        uiFin.Enabled = true;                        
                    }
                    else
                    {
                        uiInicio.Enabled = false;
                        uiFin.Enabled = false;
                    }
                    if (conceptoInfo.RegistrarVolumen == true)
                    {
                            uiVolumen.Enabled = true;
                    }
                    else
                    {
                        uiVolumen.Enabled = false;
                    }

                }
                else
                {
                    uiAgregar.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(
                    puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void llenarGrid()
        {
            try
            {
                oContext = new ERPProdEntities();
                lstProduccionConceptos = oContext.doc_produccion_conceptos
                    .Where(w => w.ProduccionId == this.ProduccionID).ToList();

                uiGrid.DataSource = lstProduccionConceptos;
            }
            catch (Exception ex)
            {

                errN = ERP.Business.SisBitacoraBusiness.Insert(
                   puntoVentaContext.usuarioId,
                          "ERP",
                          this.Name,
                          ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(errN);
            }
        }

        private void uiIniciar_Click(object sender, EventArgs e)
        {

        }

        private void frmProduccionConceptos_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearObjects();
        }

        private void uiAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                doc_produccion_conceptos entityProduccionCNew = new doc_produccion_conceptos();

                entityProduccionCNew.Cantidad = uiVolumen.Value;
                entityProduccionCNew.ConceptoId = conceptoSeleccionadoId;
                entityProduccionCNew.Inicio = conceptoInfo.RegistrarTiempo == true ? uiInicio.DateTime : (DateTime?)null;
                entityProduccionCNew.Fin = conceptoInfo.RegistrarTiempo == true ? uiFin.DateTime : (DateTime?)null;
                entityProduccionCNew.ProduccionId = this.ProduccionID;
                entityProduccionCNew = oProduccionConceptosBusiness.Guardar(entityProduccionCNew, conceptoInfo.ProductoId,
                    this.puntoVentaContext.usuarioId,this.puntoVentaContext.sucursalId, ref error);

                if(error.Length> 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowError(error);
                }
                else
                {
                    llenarGrid();
                    ERP.Utils.MessageBoxUtil.ShowOk();
                }

            }
            catch (Exception ex)
            {

                errN = ERP.Business.SisBitacoraBusiness.Insert(
                     puntoVentaContext.usuarioId,
                            "ERP",
                            this.Name,
                            ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(errN);
            }
        }

        private void repBtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    doc_produccion_conceptos entitySel = (doc_produccion_conceptos)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    if(XtraMessageBox.Show("¿Está seguro(a) de continuar?","ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (entitySel != null)
                        {
                            error = oProduccionConceptosBusiness.Eliminar(entitySel.ProduccionConceptoId, puntoVentaContext.usuarioId, puntoVentaContext.sucursalId);

                            if (error.Length > 0)
                            {
                                ERP.Utils.MessageBoxUtil.ShowError(error);
                            }
                            else
                            {
                                llenarGrid();
                                ERP.Utils.MessageBoxUtil.ShowOk();
                            }
                        }
                    }

                   
                }
            }
            catch (Exception ex)
            {

                errN = ERP.Business.SisBitacoraBusiness.Insert(
                      puntoVentaContext.usuarioId,
                             "ERP",
                             this.Name,
                             ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(errN);
            }
        }
    }
}
