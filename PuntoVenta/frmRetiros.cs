using ConexionBD;
using ConexionBD.Models;
using PuntoVenta.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class frmRetiros : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;

        public frmRetiros()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardar()
        {
            try
            {
                oContext = new ERPProdEntities();

                DateTime? fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                decimal? disponibleEfectivo = oContext.p_caja_efectivo_disponible_sel(this.puntoVentaContext.cajaId, fechaActual).FirstOrDefault().Value;

                if (uiMonto.Value > disponibleEfectivo)
                {
                    MessageBox.Show("Aún no se dispone del efectivo solicitado, efectivo disponible $" + string.Format("{0:C}", disponibleEfectivo));
                    return;
                }

                doc_retiros entity = new doc_retiros();
                entity.CajaId = this.puntoVentaContext.cajaId;
                entity.CreadoPor = this.puntoVentaContext.usuarioId;
                entity.FechaRetiro = this.oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                entity.MontoRetiro = uiMonto.Value;
                entity.Observaciones = uiObservaciones.Text;
                entity.RetiroId = this.oContext.doc_retiros.Count() > 0 ? this.oContext.doc_retiros.Max(m => m.RetiroId) + 1 : 1;
                entity.SucursalId = this.puntoVentaContext.sucursalId;

                oContext.doc_retiros.Add(entity);
                oContext.SaveChanges();

                MessageBox.Show("RETIRO REGISTRADO", "AVISO");


                rptRetiroTicket oTicket = new rptRetiroTicket();

                ReportViewer oViewer = new ReportViewer();

                oTicket.DataSource = oContext.p_rpt_retiro_ticket(entity.RetiroId).ToList();

                oViewer.ShowTicket(oTicket);
               // oViewer.Show();



                this.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
