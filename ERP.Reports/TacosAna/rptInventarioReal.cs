using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using ConexionBD;
using System.Linq;

namespace ERP.Reports.TacosAna
{
    
    /// <summary>
    /// Summary description for rptVentaTicket.
    /// </summary>
    public partial class rptInventarioReal : GrapeCity.ActiveReports.SectionReport
    {
        public bool esReimpreso { get; set; }
        public bool esAdmin { get; set; }
        bool desglozarMonto { get; set; }
        string giro { get; set; }
        public int ventaId { get; set; }
        public bool cancelado { get; set; }
        ERPProdEntities oContext;
        public rptInventarioReal()
        {
           
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            oContext = new ERPProdEntities();
           
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
