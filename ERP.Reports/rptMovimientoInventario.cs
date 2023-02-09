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
    public partial class rptMovimientoInventario : GrapeCity.ActiveReports.SectionReport
    {
        public string autorizadoPor { get; set; }
        public string comentarios { get; set; }
        public rptMovimientoInventario()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            uiAutorizadoPor.Text = autorizadoPor;
            textBox3.Text = comentarios;
        }
    }
}
