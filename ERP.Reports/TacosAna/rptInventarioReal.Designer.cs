namespace ERP.Reports.TacosAna
{
    /// <summary>
    /// Summary description for rptVentaTicket.
    /// </summary>
    partial class rptInventarioReal
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rptInventarioReal));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.textBox11 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox12 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox14 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.pageBreak1 = new GrapeCity.ActiveReports.SectionReportModel.PageBreak();
            this.groupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line4 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.groupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.line1,
            this.label5});
            this.pageHeader.Height = 0.3020833F;
            this.pageHeader.Name = "pageHeader";
            // 
            // line1
            // 
            this.line1.Height = 0F;
            this.line1.Left = 7.45058E-09F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 1.781F;
            this.line1.Width = 3.833F;
            this.line1.X1 = 7.45058E-09F;
            this.line1.X2 = 3.833F;
            this.line1.Y1 = 1.781F;
            this.line1.Y2 = 1.781F;
            // 
            // detail
            // 
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.textBox11,
            this.textBox12,
            this.textBox14,
            this.textBox1});
            this.detail.Height = 0.148F;
            this.detail.Name = "detail";
            // 
            // textBox11
            // 
            this.textBox11.DataField = "DescripcionCorta";
            this.textBox11.Height = 0.148F;
            this.textBox11.Left = 0.125F;
            this.textBox11.Name = "textBox11";
            this.textBox11.Style = "font-size: 6.75pt; ddo-char-set: 0";
            this.textBox11.Text = "textBox10";
            this.textBox11.Top = 0F;
            this.textBox11.Width = 1.187F;
            // 
            // textBox12
            // 
            this.textBox12.CurrencyCulture = new System.Globalization.CultureInfo("es-MX");
            this.textBox12.DataField = "Diferencia";
            this.textBox12.Height = 0.148F;
            this.textBox12.Left = 2.329F;
            this.textBox12.Name = "textBox12";
            this.textBox12.OutputFormat = resources.GetString("textBox12.OutputFormat");
            this.textBox12.Style = "font-size: 6.75pt; text-align: right; ddo-char-set: 0";
            this.textBox12.Text = "textBox10";
            this.textBox12.Top = 0F;
            this.textBox12.Width = 0.5110002F;
            // 
            // textBox14
            // 
            this.textBox14.CurrencyCulture = new System.Globalization.CultureInfo("es-MX");
            this.textBox14.DataField = "CantidadReal";
            this.textBox14.Height = 0.148F;
            this.textBox14.Left = 1.878F;
            this.textBox14.Name = "textBox14";
            this.textBox14.OutputFormat = resources.GetString("textBox14.OutputFormat");
            this.textBox14.Style = "font-size: 6.75pt; text-align: right; ddo-char-set: 0";
            this.textBox14.Text = "textBox10";
            this.textBox14.Top = 0F;
            this.textBox14.Width = 0.4389999F;
            // 
            // textBox1
            // 
            this.textBox1.CurrencyCulture = new System.Globalization.CultureInfo("es-MX");
            this.textBox1.DataField = "CantidadTeorica";
            this.textBox1.Height = 0.148F;
            this.textBox1.Left = 1.333F;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "font-size: 6.75pt; text-align: right; ddo-char-set: 0";
            this.textBox1.Text = "textBox10";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.4999999F;
            // 
            // pageFooter
            // 
            this.pageFooter.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.pageBreak1});
            this.pageFooter.Height = 0.1979167F;
            this.pageFooter.Name = "pageFooter";
            // 
            // pageBreak1
            // 
            this.pageBreak1.Height = 0.01F;
            this.pageBreak1.Left = 0F;
            this.pageBreak1.Name = "pageBreak1";
            this.pageBreak1.Size = new System.Drawing.SizeF(6.5F, 0.01F);
            this.pageBreak1.Top = 0.06200001F;
            this.pageBreak1.Width = 6.5F;
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label2,
            this.label1,
            this.label3,
            this.label4,
            this.line3,
            this.line4});
            this.groupHeader1.Height = 0.1449445F;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.Format += new System.EventHandler(this.groupHeader1_Format);
            // 
            // label2
            // 
            this.label2.Height = 0.138F;
            this.label2.HyperLink = null;
            this.label2.Left = 2.437F;
            this.label2.Name = "label2";
            this.label2.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.label2.Text = "DIF";
            this.label2.Top = 0F;
            this.label2.Width = 0.4030001F;
            // 
            // label1
            // 
            this.label1.Height = 0.138F;
            this.label1.HyperLink = null;
            this.label1.Left = 0.1700001F;
            this.label1.Name = "label1";
            this.label1.Style = "font-size: 6.75pt; ddo-char-set: 0";
            this.label1.Text = "PROD";
            this.label1.Top = 0F;
            this.label1.Width = 0.436F;
            // 
            // label3
            // 
            this.label3.Height = 0.138F;
            this.label3.HyperLink = null;
            this.label3.Left = 1.875F;
            this.label3.Name = "label3";
            this.label3.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.label3.Text = "REAL";
            this.label3.Top = 0F;
            this.label3.Width = 0.4420002F;
            // 
            // label4
            // 
            this.label4.Height = 0.138F;
            this.label4.HyperLink = null;
            this.label4.Left = 1.375F;
            this.label4.Name = "label4";
            this.label4.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.label4.Text = "TEO";
            this.label4.Top = 0F;
            this.label4.Width = 0.375F;
            // 
            // line3
            // 
            this.line3.Height = 0F;
            this.line3.Left = 0.1060001F;
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0F;
            this.line3.Width = 2.824F;
            this.line3.X1 = 0.1060001F;
            this.line3.X2 = 2.93F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // line4
            // 
            this.line4.Height = 0F;
            this.line4.Left = 0.062F;
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 0.138F;
            this.line4.Width = 2.824F;
            this.line4.X1 = 0.062F;
            this.line4.X2 = 2.886F;
            this.line4.Y1 = 0.138F;
            this.line4.Y2 = 0.138F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            this.groupFooter1.Format += new System.EventHandler(this.groupFooter1_Format);
            this.groupFooter1.BeforePrint += new System.EventHandler(this.groupFooter1_BeforePrint);
            // 
            // label5
            // 
            this.label5.Height = 0.2F;
            this.label5.HyperLink = null;
            this.label5.Left = 0.8750001F;
            this.label5.Name = "label5";
            this.label5.Style = "";
            this.label5.Text = "INVENTARIO REAL";
            this.label5.Top = 0F;
            this.label5.Width = 1.312F;
            // 
            // rptInventarioReal
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.1F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.1F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperName = "Custom paper";
            this.PageSettings.PaperWidth = 3F;
            this.PrintWidth = 2.9025F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rptVentaTicket_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private GrapeCity.ActiveReports.SectionReportModel.Line line1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox11;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox12;
        private GrapeCity.ActiveReports.SectionReportModel.GroupHeader groupHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.GroupFooter groupFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox14;
        private GrapeCity.ActiveReports.SectionReportModel.Label label1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label3;
        private GrapeCity.ActiveReports.SectionReportModel.Label label4;
        private GrapeCity.ActiveReports.SectionReportModel.PageBreak pageBreak1;
        private GrapeCity.ActiveReports.SectionReportModel.Line line3;
        private GrapeCity.ActiveReports.SectionReportModel.Line line4;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label5;
    }
}
