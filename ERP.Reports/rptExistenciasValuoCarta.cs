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
        string tipo = "";
        
        public rptExistenciasValuoCarta(bool verLinea,bool verFamilia,bool verSubfamilia,bool verProductos,string _tipo)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            gpLinea.Visible = true;
            gpFamilia.Visible = verFamilia || verSubfamilia;
            gpSubfamilia.Visible = verSubfamilia || verProductos;
            detail.Visible = verProductos;
            this.tipo = _tipo;
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            if(this.tipo == "1")
            {
                this.label15.Text = "COSTO PROM.";
                this.label17.Text = "EXIST. VALUO COSTO PROM.";
            }
            if (this.tipo == "2")
            {
                this.label15.Text = "PRECIO VTA.";
                this.label17.Text = "EXIST. VALUO PRECIO VTA.";
            }

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
