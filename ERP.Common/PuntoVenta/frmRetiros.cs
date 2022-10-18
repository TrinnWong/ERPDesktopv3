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

namespace ERP.Common.PuntoVenta
{
    public partial class frmRetiros : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        int err=0;
        public List<DeclaracionFondoModel> lstDenominaciones;

        public frmRetiros()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            
        }

        private void AbrirDeclaracionFondo()
        {
            try
            {
                lstDenominaciones = new List<DeclaracionFondoModel>();
                frmDeclaracionFondoDialog oForm = new frmDeclaracionFondoDialog();
                oForm.puntoVentaContext = this.puntoVentaContext;
                oForm.ShowDialog();

                if (oForm.DialogResult == DialogResult.OK)
                {
                    this.uiMonto.Value = oForm.model2.Sum(s => s.total??0);
                    lstDenominaciones = oForm.model2;
                }

            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                  "ERP",
                                  this.Name,
                                  ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardar()
        {
            try
            {       
                if(lstDenominaciones.Count() == 0)
                {
                    AbrirDeclaracionFondo();
                }
                
                oContext = new ERPProdEntities();

                DateTime? fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                decimal? disponibleEfectivo = oContext.p_caja_efectivo_disponible_sel(this.puntoVentaContext.cajaId, fechaActual).FirstOrDefault().Value;

                if (uiMonto.Value > disponibleEfectivo)
                {
                    if(ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,this.puntoVentaContext.sucursalId, "PVRetirosQuitarMontoDisponible",this.puntoVentaContext.usuarioId))
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("No hay fondos suficientes para realizar el retiro");
                        return;
                    }
                    else
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("Aún no se dispone del efectivo solicitado, efectivo disponible $" + string.Format("{0:C}", disponibleEfectivo));
                        return;
                    }
                  
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

                //Declaracion de Fondo
                foreach (var itemDeno in lstDenominaciones)
                {
                    doc_retiros_denominaciones oRetiroDenominacion = new doc_retiros_denominaciones();

                    oRetiroDenominacion.RetiroId = entity.RetiroId;
                    oRetiroDenominacion.Cantidad = itemDeno.cantidad??0;
                    oRetiroDenominacion.CreadoEl = DateTime.Now;
                    oRetiroDenominacion.CreadoPor = puntoVentaContext.usuarioId;
                    oRetiroDenominacion.DenominacionId = itemDeno.clave;
                    oRetiroDenominacion.Total = itemDeno.total??0;
                    oRetiroDenominacion.ValorDenominacion = itemDeno.valor;

                    oContext.doc_retiros_denominaciones.Add(oRetiroDenominacion);
                    oContext.SaveChanges();


                }

                MessageBox.Show("RETIRO REGISTRADO", "AVISO");


                rptRetiroTicket oTicket = new rptRetiroTicket();

                ReportViewer oViewer = new ReportViewer(this.puntoVentaContext.cajaId);

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

        private void frmRetiros_Load(object sender, EventArgs e)
        {
            AbrirDeclaracionFondo();
        }
    }
}
