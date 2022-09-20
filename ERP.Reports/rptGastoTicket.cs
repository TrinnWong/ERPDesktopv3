using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using ERP.Reports;

namespace ERP.Reports
{
    /// <summary>
    /// Summary description for rptGastoTicket.
    /// </summary>
    public partial class rptGastoTicket : GrapeCity.ActiveReports.SectionReport
    {

        public rptGastoTicket()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {
            subRptLogo oReportFoto = new subRptLogo();
            subRepFoto.Report = oReportFoto;
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {

        }
    }
}
