namespace ERP.Reports
{
    /// <summary>
    /// Summary description for subRptCorteCajaVales.
    /// </summary>
    partial class subRptCorteCajaVales
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(subRptCorteCajaVales));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.reportHeader1 = new GrapeCity.ActiveReports.SectionReportModel.ReportHeader();
            this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.reportFooter1 = new GrapeCity.ActiveReports.SectionReportModel.ReportFooter();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4});
            this.detail.Height = 0.2083334F;
            this.detail.Name = "detail";
            // 
            // textBox1
            // 
            this.textBox1.DataField = "Folio";
            this.textBox1.Height = 0.2F;
            this.textBox1.Left = 0.08900001F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-size: 6.75pt; ddo-char-set: 0";
            this.textBox1.Text = "textBox1";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.5460001F;
            // 
            // textBox2
            // 
            this.textBox2.CurrencyCulture = new System.Globalization.CultureInfo("es-MX");
            this.textBox2.DataField = "MontoTicket";
            this.textBox2.Height = 0.2F;
            this.textBox2.Left = 0.6350001F;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "font-size: 6.75pt; text-align: right; ddo-char-set: 0";
            this.textBox2.Text = "textBox1";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.8019999F;
            // 
            // textBox3
            // 
            this.textBox3.DataField = "FolioVale";
            this.textBox3.Height = 0.2F;
            this.textBox3.Left = 1.473F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "font-size: 6.75pt; text-align: right; ddo-char-set: 0";
            this.textBox3.Text = "textBox1";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.5270001F;
            // 
            // textBox4
            // 
            this.textBox4.CurrencyCulture = new System.Globalization.CultureInfo("es-MX");
            this.textBox4.DataField = "MontoVale";
            this.textBox4.Height = 0.2F;
            this.textBox4.Left = 2.019F;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "font-size: 6.75pt; text-align: right; ddo-char-set: 0";
            this.textBox4.Text = "textBox1";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.7310002F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // reportHeader1
            // 
            this.reportHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label1,
            this.label2,
            this.label3,
            this.label4,
            this.label5});
            this.reportHeader1.Height = 0.5520833F;
            this.reportHeader1.Name = "reportHeader1";
            // 
            // label1
            // 
            this.label1.Height = 0.2F;
            this.label1.HyperLink = null;
            this.label1.Left = 0.6350001F;
            this.label1.Name = "label1";
            this.label1.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label1.Text = "VALES";
            this.label1.Top = 0F;
            this.label1.Width = 1.927F;
            // 
            // label2
            // 
            this.label2.Height = 0.294F;
            this.label2.HyperLink = null;
            this.label2.Left = 0.089F;
            this.label2.Name = "label2";
            this.label2.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label2.Text = "FOLIO VTA";
            this.label2.Top = 0.258F;
            this.label2.Width = 0.5460001F;
            // 
            // label3
            // 
            this.label3.Height = 0.179F;
            this.label3.HyperLink = null;
            this.label3.Left = 0.6350001F;
            this.label3.Name = "label3";
            this.label3.Style = "font-size: 6pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label3.Text = "MONTO TICKET";
            this.label3.Top = 0.373F;
            this.label3.Width = 0.817F;
            // 
            // label4
            // 
            this.label4.Height = 0.294F;
            this.label4.HyperLink = null;
            this.label4.Left = 1.452F;
            this.label4.Name = "label4";
            this.label4.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label4.Text = "FOLIO VALE";
            this.label4.Top = 0.258F;
            this.label4.Width = 0.567F;
            // 
            // label5
            // 
            this.label5.Height = 0.179F;
            this.label5.HyperLink = null;
            this.label5.Left = 2.019F;
            this.label5.Name = "label5";
            this.label5.Style = "font-size: 6pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label5.Text = "MONTO VALE";
            this.label5.Top = 0.373F;
            this.label5.Width = 0.7310002F;
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0F;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // subRptCorteCajaVales
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.5F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 5F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperName = "Custom paper";
            this.PageSettings.PaperWidth = 3F;
            this.PrintWidth = 2.825416F;
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private GrapeCity.ActiveReports.SectionReportModel.ReportHeader reportHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label1;
        private GrapeCity.ActiveReports.SectionReportModel.ReportFooter reportFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label3;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox2;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox3;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox4;
        private GrapeCity.ActiveReports.SectionReportModel.Label label4;
        private GrapeCity.ActiveReports.SectionReportModel.Label label5;
    }
}
