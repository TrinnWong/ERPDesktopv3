using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using ConexionBD;
using System.Linq;
using ERP.Reports;

namespace ERP.Reports
{
    
    /// <summary>
    /// Summary description for rptVentaTicket.
    /// </summary>
    public partial class rptVentaTicket_CartaM : GrapeCity.ActiveReports.SectionReport
    {
        public bool esReimpreso { get; set; }
        public bool esAdmin { get; set; }
        bool desglozarMonto { get; set; }

        ERPProdEntities oContext;
        public rptVentaTicket_CartaM()
        {
           
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            oContext = new ERPProdEntities(true);
            desglozarMonto = oContext.cat_configuracion.FirstOrDefault().DesgloceMontoTicket ?? false;
            
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
                        subFormasPago.Report.DataSource = oContext.p_rpt_venta_ticket_formaspago(folio).ToList();
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

          



        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            


  subRptLogo  oReportFoto = new subRptLogo();
            subRepFoto.Report = oReportFoto;
            
            
        }
    }
}
