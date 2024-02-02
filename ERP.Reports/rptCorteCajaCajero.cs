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
    /// Summary description for rptCorteCaja.
    /// </summary>
    public partial class rptCorteCajaCajero : GrapeCity.ActiveReports.SectionReport
    {
        public bool esAdmin{get;set;}
        ERPProdEntities oContext;
        public rptCorteCajaCajero()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            oContext = new ERPProdEntities(true);
            this.Document.PrintOptions.Margin = new GrapeCity.ActiveReports.Extensibility.Printing.Margin(0, 0, 0, 0);
            this.Document.PrintOptions.PrintPageBorder = false;
            
        }

       
        private void detail_Format(object sender, EventArgs e)
        {
            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if (entity != null)
            {

                detail.Visible = entity.CajeroIncluirDetalleVenta ?? false;
                
            }
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {
            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

           

            subRptLogo oReportFoto = new subRptLogo();
            subRepFoto.Report = oReportFoto;
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            

        }

        private void groupFooter1_Format(object sender, EventArgs e)
        {
            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            int folio;

            int.TryParse(uiCorteId.Text, out folio);   

        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {

            int folio;

            int.TryParse(uiCorteId.Text, out folio);
            subRptVentaFormasPago oReportGas = new subRptVentaFormasPago();
            
          
            
        }

        private void rptCorteCaja_ReportStart(object sender, EventArgs e)
        {

        }
    }
}
