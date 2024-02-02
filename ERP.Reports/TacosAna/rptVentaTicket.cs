using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using ConexionBD;
using System.Linq;

namespace ERP.Reports.TacosAna
{
    
    /// <summary>
    /// Summary description for rptVentaTicket.
    /// </summary>
    public partial class rptVentaTicket : GrapeCity.ActiveReports.SectionReport
    {
        public bool esReimpreso { get; set; }
        public bool esAdmin { get; set; }
        bool desglozarMonto { get; set; }
        string giro { get; set; }
        public int ventaId { get; set; }
        public bool cancelado { get; set; }
        ERPProdEntities oContext;
        public rptVentaTicket()
        {
           
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            oContext = new ERPProdEntities(true);
            cat_configuracion entityConf = oContext.cat_configuracion.FirstOrDefault();
            desglozarMonto = entityConf.DesgloceMontoTicket ?? false;
            giro = entityConf.Giro;
        }

        public rptVentaTicket(int _ventaId)
        {
            ventaId = _ventaId;

            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            oContext = new ERPProdEntities(true);
            cat_configuracion entityConf = oContext.cat_configuracion.FirstOrDefault();
            desglozarMonto = entityConf.DesgloceMontoTicket ?? false;
            giro = entityConf.Giro;

            

        }

        private void rptVentaTicket_ReportStart(object sender, EventArgs e)
        {
           
        }

        private void groupFooter1_Format(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities(true);

            try
            {
                cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

                if (entity != null)
                {
                    //lblDesc.Visible = entity.DesgloceMontoTicket??false;
                    //uiDesc.Visible = entity.DesgloceMontoTicket ?? false;
                    lblSub.Visible = entity.DesgloceMontoTicket ?? false;
                    uiSubTotal.Visible = entity.DesgloceMontoTicket ?? false;
                    lblImpuesto.Visible = entity.DesgloceMontoTicket ?? false;
                    uiImpuesto.Visible = entity.DesgloceMontoTicket ?? false;
                }


                uiReimpreso.Visible = esReimpreso;


               

                int folio;

                int.TryParse(uiFolio.Text, out folio);

                if (uiFolio.Text != "" && uiFolio.Text != null)
                {
                    #region formaspago
                        subRptVentaFormasPago oReport = new subRptVentaFormasPago();

                        subFormasPago.Report = oReport;
                        subFormasPago.Report.DataSource = oContext.p_rpt_venta_ticket_formaspago(ventaId).ToList();
                    #endregion

                    #region restaurante info

                    if(giro == Enumerados.systemGiro.REST.ToString())
                    {
                        subRptVentaTicket_Rest oReport1 = new subRptVentaTicket_Rest();
                        subReport1.Visible = true;
                        subReport1.Report = oReport1;
                        subReport1.Report.DataSource = oContext.p_rpt_VentaTicket_Restaurante(ventaId).ToList();

                    }
                    else
                    {
                        subReport1.Visible = false;
                    }
                    #endregion


                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        private void groupFooter1_BeforePrint(object sender, EventArgs e)
        {
            
            uiReimpreso.Visible = esReimpreso;

           // lblDesc.Visible = desglozarMonto;
            lblImpuesto.Visible = desglozarMonto;
            lblSub.Visible = desglozarMonto;
           // uiDesc.Visible = desglozarMonto;
            uiImpuesto.Visible = desglozarMonto;
            uiSubTotal.Visible = desglozarMonto;

            if(((List<p_rpt_VentaTicket_Result>)this.DataSource).Count() > 0)
            {
                textBox21.Visible = (((List<p_rpt_VentaTicket_Result>)this.DataSource).FirstOrDefault().MotivoCancelacion == null ? "" : ((List<p_rpt_VentaTicket_Result>)this.DataSource).FirstOrDefault().MotivoCancelacion).Length > 0 ? true : false;
            }

            



        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
           

        }
    }
}
