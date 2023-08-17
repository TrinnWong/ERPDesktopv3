using ConexionBD;
using ConexionBD.Models;
using ERP.Common.Reports;
using ERP.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Dialogos
{
    public partial class frmRetiroAutomatico : Form
    {
        public PuntoVentaContext puntoVentaContext;
        public decimal cantidadRetiro = 0;
        public frmRetiroAutomatico()
        {
            InitializeComponent();
        }

        private void uiOk_Click(object sender, EventArgs e)
        {
            uiOk.Enabled = false;            
            guardar();
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void guardar()
        {
            try
            {


                ERPProdEntities oContext = new ERPProdEntities();

                DateTime? fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                decimal? disponibleEfectivo = oContext.p_caja_efectivo_disponible_sel(this.puntoVentaContext.cajaId, fechaActual).FirstOrDefault().Value;



                doc_retiros entity = new doc_retiros();
                entity.CajaId = this.puntoVentaContext.cajaId;
                entity.CreadoPor = this.puntoVentaContext.usuarioId;
                entity.FechaRetiro = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                entity.MontoRetiro = uiMontoRetiro.Value;
                entity.Observaciones = "Retiro automático de sistema punto de venta";
                entity.RetiroId = oContext.doc_retiros.Count() > 0 ? oContext.doc_retiros.Max(m => m.RetiroId) + 1 : 1;
                entity.SucursalId = this.puntoVentaContext.sucursalId;

                oContext.doc_retiros.Add(entity);
                oContext.SaveChanges();               


                rptRetiroTicket oTicket = new rptRetiroTicket();

                ReportViewer oViewer = new ReportViewer(this.puntoVentaContext.cajaId);

                oTicket.DataSource = oContext.p_rpt_retiro_ticket(entity.RetiroId).ToList();

                oViewer.ShowTicket(oTicket);

                this.DialogResult = DialogResult.OK;
                
                this.Close();


            }
            catch (Exception ex)
            {
                uiOk.Enabled = true;
                MessageBox.Show(ex.Message, "ERROR");
                this.Close();
            }
        }

        private void frmRetiroAutomatico_Load(object sender, EventArgs e)
        {
            uiMontoRetiro.EditValue = this.cantidadRetiro;
        }
    }
}
