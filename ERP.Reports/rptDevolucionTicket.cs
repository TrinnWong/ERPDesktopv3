using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using ERP.Reports;

namespace ERP.Reports
{
    /// <summary>
    /// Summary description for rptDevolucionTicket.
    /// </summary>
    public partial class rptDevolucionTicket : GrapeCity.ActiveReports.SectionReport
    {

        public rptDevolucionTicket()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            subRptLogo oReportFoto = new subRptLogo();
            subRepFoto.Report = oReportFoto;
        }
    }
}
