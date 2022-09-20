using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using ConexionBD;
using System.Linq;

namespace ERP.Reports
{
    
    /// <summary>
    /// Summary description for rptVentaTicket.
    /// </summary>
    public partial class rptVentaTicket55MM : GrapeCity.ActiveReports.SectionReport
    {
        public bool esReimpreso { get; set; }
        public bool esAdmin { get; set; }
        bool desglozarMonto { get; set; }
        string giro { get; set; }

        ERPProdEntities oContext;
        public rptVentaTicket55MM()
        {
           
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            oContext = new ERPProdEntities();
            cat_configuracion entityConf = oContext.cat_configuracion.FirstOrDefault();
            desglozarMonto = entityConf.DesgloceMontoTicket ?? false;
            giro = entityConf.Giro;
        }

        private void rptVentaTicket_ReportStart(object sender, EventArgs e)
        {
           
        }

        private void groupFooter1_Format(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();

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
                   

                    #region restaurante info

                    if(giro == Enumerados.systemGiro.REST.ToString())
                    {
                        subRptVentaTicket_Rest oReport1 = new subRptVentaTicket_Rest();
                       
                    }
                    else
                    {
                      
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

          



        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            subRptLogo oReportFoto = new subRptLogo();
            subRepFoto.Report = oReportFoto;

        }
    }
}
