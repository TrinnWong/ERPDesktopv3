namespace ERP.Reports
{
    /// <summary>
    /// Summary description for subRptLogo.
    /// </summary>
    partial class subRptVentaTicket_Rest
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(subRptVentaTicket_Rest));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.textBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.reportHeader1 = new GrapeCity.ActiveReports.SectionReportModel.ReportHeader();
            this.reportFooter1 = new GrapeCity.ActiveReports.SectionReportModel.ReportFooter();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
            // 
            // detail
            // 
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.textBox6,
            this.textBox1,
            this.textBox2,
            this.textBox3});
            this.detail.Height = 0.1597222F;
            this.detail.Name = "detail";
            // 
            // textBox6
            // 
            this.textBox6.Height = 0.151F;
            this.textBox6.Left = 0.06799996F;
            this.textBox6.Name = "textBox6";
            this.textBox6.Style = "font-size: 8.25pt; text-align: left; ddo-char-set: 0";
            this.textBox6.Text = "Personas:";
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.557F;
            // 
            // textBox1
            // 
            this.textBox1.DataField = "Personas";
            this.textBox1.Height = 0.151F;
            this.textBox1.Left = 0.625F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-size: 8.25pt; text-align: left; ddo-char-set: 0";
            this.textBox1.Text = "Personas:";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.557F;
            // 
            // textBox2
            // 
            this.textBox2.Height = 0.151F;
            this.textBox2.Left = 1.25F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "font-size: 8.25pt; text-align: left; ddo-char-set: 0";
            this.textBox2.Text = "Mesa:";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.396F;
            // 
            // textBox3
            // 
            this.textBox3.DataField = "Mesas";
            this.textBox3.Height = 0.151F;
            this.textBox3.Left = 1.631F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "font-size: 8.25pt; text-align: left; ddo-char-set: 0";
            this.textBox3.Text = "Mesa:";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.931F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0.01041667F;
            this.pageFooter.Name = "pageFooter";
            // 
            // reportHeader1
            // 
            this.reportHeader1.Height = 0F;
            this.reportHeader1.Name = "reportHeader1";
            this.reportHeader1.Format += new System.EventHandler(this.reportHeader1_Format);
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0F;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // subRptVentaTicket_Rest
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
            this.PrintWidth = 2.697222F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.Sections.Add(this.reportFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private GrapeCity.ActiveReports.SectionReportModel.ReportHeader reportHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.ReportFooter reportFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox6;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox2;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox3;
    }
}
