using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ERP.Reports
{
    /// <summary>
    /// Summary description for rptExistenciasCarta.
    /// </summary>
    /// 
    
    public partial class rptExistenciasValuoCarta : GrapeCity.ActiveReports.SectionReport
    {
        
        public rptExistenciasValuoCarta(bool verLinea,bool verFamilia,bool verSubfamilia,bool verProductos)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            gpLinea.Visible = true;
            gpFamilia.Visible = verFamilia || verSubfamilia;
            gpSubfamilia.Visible = verSubfamilia || verProductos;
            detail.Visible = verProductos;
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {

        }

        private void gpSubfamilia_Format(object sender, EventArgs e)
        {

        }

        private void pageHeader_Format(object sender, EventArgs e)
        {
            subRptLogo oReportFoto = new subRptLogo();
            subRepFoto.Report = oReportFoto;

            uiFecha.Text = DateTime.Now.ToShortDateString();
        }
    }
}
