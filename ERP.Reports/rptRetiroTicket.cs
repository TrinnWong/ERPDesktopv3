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
    public partial class rptRetiroTicket : GrapeCity.ActiveReports.SectionReport
    {
        //public bool esReimpreso { get; set; }
        //bool desglozarMonto { get; set; }
        //ERPEntities oContext;
        public rptRetiroTicket()
        {
           
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //oContext = new ERPEntities();
            //desglozarMonto = oContext.cat_configuracion.FirstOrDefault().DesgloceMontoTicket ?? false;
            
        }

        private void rptVentaTicket_ReportStart(object sender, EventArgs e)
        {
           
        }

        private void groupFooter1_Format(object sender, EventArgs e)
        {
            //uiReimpreso.Visible = esReimpreso;
        }

        private void groupFooter1_BeforePrint(object sender, EventArgs e)
        {
            
            //uiReimpreso.Visible = esReimpreso;

            //lblDesc.Visible = desglozarMonto;
            //lblImpuesto.Visible = desglozarMonto;
            //lblSub.Visible = desglozarMonto;
            //uiDesc.Visible = desglozarMonto;
            //uiImpuesto.Visible = desglozarMonto;
            //uiSubTotal.Visible = desglozarMonto;

        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            subRptLogo oReportFoto = new subRptLogo();
            
        }
    }
}
