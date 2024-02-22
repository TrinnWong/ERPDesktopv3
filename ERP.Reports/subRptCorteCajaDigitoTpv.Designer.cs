namespace ERP.Reports
{
    /// <summary>
    /// Summary description for subRptCorteCajaDigitoTpv.
    /// </summary>
    partial class subRptCorteCajaDigitoTpv
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(subRptCorteCajaDigitoTpv));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.reportHeader1 = new GrapeCity.ActiveReports.SectionReportModel.ReportHeader();
            this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.reportFooter1 = new GrapeCity.ActiveReports.SectionReportModel.ReportFooter();
            this.groupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.groupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
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
            this.textBox3});
            this.detail.Height = 0.2291667F;
            this.detail.Name = "detail";
            // 
            // textBox1
            // 
            this.textBox1.DataField = "Folio";
            this.textBox1.Height = 0.2F;
            this.textBox1.Left = 0.305F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.textBox1.Text = null;
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.5460001F;
            // 
            // textBox2
            // 
            this.textBox2.CurrencyCulture = new System.Globalization.CultureInfo("es-MX");
            this.textBox2.DataField = "Importe";
            this.textBox2.Height = 0.2F;
            this.textBox2.Left = 0.851F;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "font-size: 8.25pt; text-align: right; ddo-char-set: 0";
            this.textBox2.Text = null;
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.9320002F;
            // 
            // textBox3
            // 
            this.textBox3.DataField = "Digito";
            this.textBox3.Height = 0.2F;
            this.textBox3.Left = 1.783F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "font-size: 8.25pt; text-align: right; ddo-char-set: 0";
            this.textBox3.Text = null;
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.8379999F;
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
            this.label4});
            this.reportHeader1.Height = 0.4791666F;
            this.reportHeader1.Name = "reportHeader1";
            // 
            // label1
            // 
            this.label1.Height = 0.2F;
            this.label1.HyperLink = null;
            this.label1.Left = 0.48F;
            this.label1.Name = "label1";
            this.label1.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label1.Text = "DETALLE DIGITO TARJETAS";
            this.label1.Top = 0F;
            this.label1.Width = 1.927F;
            // 
            // label2
            // 
            this.label2.Height = 0.179F;
            this.label2.HyperLink = null;
            this.label2.Left = 0.3049999F;
            this.label2.Name = "label2";
            this.label2.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label2.Text = "FOLIO";
            this.label2.Top = 0.28F;
            this.label2.Width = 0.5460001F;
            // 
            // label3
            // 
            this.label3.Height = 0.179F;
            this.label3.HyperLink = null;
            this.label3.Left = 0.851F;
            this.label3.Name = "label3";
            this.label3.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label3.Text = "IMPORTE";
            this.label3.Top = 0.28F;
            this.label3.Width = 0.932F;
            // 
            // label4
            // 
            this.label4.Height = 0.179F;
            this.label4.HyperLink = null;
            this.label4.Left = 1.783F;
            this.label4.Name = "label4";
            this.label4.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label4.Text = "DIG. TPV";
            this.label4.Top = 0.28F;
            this.label4.Width = 0.838F;
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0F;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // groupHeader1
            // 
            this.groupHeader1.Height = 0F;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // groupFooter1
            // 
            this.groupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label5,
            this.textBox4});
            this.groupFooter1.Height = 0.1979167F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // label5
            // 
            this.label5.Height = 0.179F;
            this.label5.HyperLink = null;
            this.label5.Left = 0.305F;
            this.label5.Name = "label5";
            this.label5.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label5.Text = "TOTAL";
            this.label5.Top = 0F;
            this.label5.Width = 0.5460001F;
            // 
            // textBox4
            // 
            this.textBox4.CurrencyCulture = new System.Globalization.CultureInfo("es-MX");
            this.textBox4.DataField = "Importe";
            this.textBox4.Height = 0.2F;
            this.textBox4.Left = 0.851F;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "font-size: 8.25pt; text-align: right; ddo-char-set: 0";
            this.textBox4.SummaryGroup = "groupHeader1";
            this.textBox4.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox4.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox4.Text = null;
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.932F;
            // 
            // subRptCorteCajaDigitoTpv
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 5F;
            this.PageSettings.Margins.Left = 5F;
            this.PageSettings.Margins.Right = 5F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperName = "Custom paper";
            this.PageSettings.PaperWidth = 3F;
            this.PrintWidth = 2.78125F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
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
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private GrapeCity.ActiveReports.SectionReportModel.ReportHeader reportHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.ReportFooter reportFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label3;
        private GrapeCity.ActiveReports.SectionReportModel.Label label4;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox2;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox3;
        private GrapeCity.ActiveReports.SectionReportModel.GroupHeader groupHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.GroupFooter groupFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label5;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox4;
    }
}
