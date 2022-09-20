using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ERP.Reports
{
    /// <summary>
    /// Summary description for rptMovimientoInventario.
    /// </summary>
    public partial class rptEntradaCompra_Carta : GrapeCity.ActiveReports.SectionReport
    {
        public string autorizadoPor { get; set; }
        public rptEntradaCompra_Carta()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            uiAutorizadoPor.Text = autorizadoPor;
        }
    }
}
