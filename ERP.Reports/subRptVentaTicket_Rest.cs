using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using ConexionBD;
using System.Linq;
using System.IO;
using System.Drawing.Imaging;

namespace ERP.Reports
{
    /// <summary>
    /// Summary description for subRptLogo.
    /// </summary>
    public partial class subRptVentaTicket_Rest : GrapeCity.ActiveReports.SectionReport
    {

        public subRptVentaTicket_Rest()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {
            
        }

        private void reportHeader1_Format(object sender, EventArgs e)
        {
           
        }
    }
}
