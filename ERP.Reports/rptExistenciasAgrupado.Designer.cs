namespace ERP.Reports
{
    /// <summary>
    /// Summary description for rptExistenciasAgrupado.
    /// </summary>
    partial class rptExistenciasAgrupado
    {
        private GrapeCity.ActiveReports.SectionReportModel.PageHeader pageHeader;
        private GrapeCity.ActiveReports.SectionReportModel.Detail detail;
        private GrapeCity.ActiveReports.SectionReportModel.PageFooter pageFooter;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rptExistenciasAgrupado));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label1,
            this.label3,
            this.label2,
            this.label4});
            this.pageHeader.Height = 0.773F;
            this.pageHeader.Name = "pageHeader";
            // 
            // label1
            // 
            this.label1.Height = 0.2F;
            this.label1.HyperLink = null;
            this.label1.Left = 0.135F;
            this.label1.Name = "label1";
            this.label1.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
            this.label1.Text = "REPORTE DE EXISTENCIAS AGRUPADAS";
            this.label1.Top = 0.07300001F;
            this.label1.Width = 2.792F;
            // 
            // label3
            // 
            this.label3.DataField = "Sucursal";
            this.label3.Height = 0.2F;
            this.label3.HyperLink = null;
            this.label3.Left = 0.8850001F;
            this.label3.Name = "label3";
            this.label3.Style = "";
            this.label3.Text = "";
            this.label3.Top = 0.273F;
            this.label3.Width = 1F;
            // 
            // label2
            // 
            this.label2.DataField = "Tipo";
            this.label2.Height = 0.2F;
            this.label2.HyperLink = null;
            this.label2.Left = 0.135F;
            this.label2.Name = "label2";
            this.label2.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
            this.label2.Text = "";
            this.label2.Top = 0.573F;
            this.label2.Width = 1.948F;
            // 
            // label4
            // 
            this.label4.Height = 0.2F;
            this.label4.HyperLink = null;
            this.label4.Left = 2.083F;
            this.label4.Name = "label4";
            this.label4.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
            this.label4.Text = "Existencia";
            this.label4.Top = 0.573F;
            this.label4.Width = 0.709F;
            // 
            // detail
            // 
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label5,
            this.label6});
            this.detail.Height = 0.1979167F;
            this.detail.Name = "detail";
            // 
            // label5
            // 
            this.label5.DataField = "Descripcion";
            this.label5.Height = 0.2F;
            this.label5.HyperLink = null;
            this.label5.Left = 0.135F;
            this.label5.Name = "label5";
            this.label5.Style = "";
            this.label5.Text = "label5";
            this.label5.Top = 0F;
            this.label5.Width = 1.948F;
            // 
            // label6
            // 
            this.label6.DataField = "Existencia";
            this.label6.Height = 0.2F;
            this.label6.HyperLink = null;
            this.label6.Left = 2.083F;
            this.label6.Name = "label6";
            this.label6.Style = "";
            this.label6.Text = "label6";
            this.label6.Top = 0F;
            this.label6.Width = 0.7089999F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // rptExistenciasAgrupado
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperName = "Custom paper";
            this.PageSettings.PaperWidth = 3F;
            this.PrintWidth = 2.979167F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private GrapeCity.ActiveReports.SectionReportModel.Label label1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label3;
        private GrapeCity.ActiveReports.SectionReportModel.Label label2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label4;
        private GrapeCity.ActiveReports.SectionReportModel.Label label5;
        private GrapeCity.ActiveReports.SectionReportModel.Label label6;
    }
}
