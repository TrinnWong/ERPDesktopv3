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
    public partial class rptPedido : GrapeCity.ActiveReports.SectionReport
    {   
        public rptPedido()
        {
           
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
           
        }

        private void rptVentaTicket_ReportStart(object sender, EventArgs e)
        {
           
        }

        private void groupFooter1_Format(object sender, EventArgs e)
        {
           
           
        }

        private void groupFooter1_BeforePrint(object sender, EventArgs e)
        {
            

          



        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {

        }
    }
}
