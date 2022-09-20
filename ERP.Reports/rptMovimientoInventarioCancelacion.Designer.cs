namespace ERP.Reports
{
    /// <summary>
    /// Summary description for rptMovimientoInventario.
    /// </summary>
    partial class rptMovimientoInventarioCancelacion
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rptMovimientoInventarioCancelacion));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.reportHeader1 = new GrapeCity.ActiveReports.SectionReportModel.ReportHeader();
            this.label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.reportFooter1 = new GrapeCity.ActiveReports.SectionReportModel.ReportFooter();
            this.label12 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.pageBreak1 = new GrapeCity.ActiveReports.SectionReportModel.PageBreak();
            this.uiAutorizadoPor = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiAutorizadoPor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
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
            this.label10,
            this.label11,
            this.textBox2});
            this.detail.Height = 0.2F;
            this.detail.Name = "detail";
            // 
            // label10
            // 
            this.label10.DataField = "ProductoClave";
            this.label10.Height = 0.2F;
            this.label10.HyperLink = null;
            this.label10.Left = 0F;
            this.label10.Name = "label10";
            this.label10.Style = "font-size: 6.75pt; text-align: right; ddo-char-set: 0";
            this.label10.Text = "CLAVE";
            this.label10.Top = 0F;
            this.label10.Width = 0.625F;
            // 
            // label11
            // 
            this.label11.DataField = "Producto";
            this.label11.Height = 0.2F;
            this.label11.HyperLink = null;
            this.label11.Left = 0.657F;
            this.label11.Name = "label11";
            this.label11.Style = "font-size: 6.75pt; ddo-char-set: 0";
            this.label11.Text = "DESCRIPCIÓN";
            this.label11.Top = 0F;
            this.label11.Width = 1.655F;
            // 
            // textBox2
            // 
            this.textBox2.DataField = "CantidadMov";
            this.textBox2.Height = 0.2F;
            this.textBox2.Left = 2.312F;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "font-size: 8.25pt; text-align: right; ddo-char-set: 0";
            this.textBox2.Text = "000.000";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.5209997F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // label1
            // 
            this.label1.DataField = "TipoMovimiento";
            this.label1.Height = 0.169F;
            this.label1.HyperLink = null;
            this.label1.Left = 0.08400023F;
            this.label1.Name = "label1";
            this.label1.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label1.Text = "TipoMovimiento";
            this.label1.Top = 0.2389999F;
            this.label1.Width = 2.791F;
            // 
            // reportHeader1
            // 
            this.reportHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label9,
            this.label1,
            this.label2,
            this.label3,
            this.label4,
            this.textBox1,
            this.label5,
            this.label6,
            this.line1,
            this.label7,
            this.label8,
            this.line2,
            this.label13});
            this.reportHeader1.Height = 1.15625F;
            this.reportHeader1.Name = "reportHeader1";
            // 
            // label9
            // 
            this.label9.Height = 0.2F;
            this.label9.HyperLink = null;
            this.label9.Left = 2.406F;
            this.label9.Name = "label9";
            this.label9.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.label9.Text = "CANT";
            this.label9.Top = 0.937F;
            this.label9.Width = 0.4686661F;
            // 
            // label2
            // 
            this.label2.Height = 0.2F;
            this.label2.HyperLink = null;
            this.label2.Left = 0.2190002F;
            this.label2.Name = "label2";
            this.label2.Style = "font-size: 8.25pt; font-weight: bold; ddo-char-set: 0";
            this.label2.Text = "Folio:";
            this.label2.Top = 0.6579999F;
            this.label2.Width = 0.406F;
            // 
            // label3
            // 
            this.label3.DataField = "Folio";
            this.label3.Height = 0.2F;
            this.label3.HyperLink = null;
            this.label3.Left = 0.6250002F;
            this.label3.Name = "label3";
            this.label3.Style = "";
            this.label3.Text = "label3";
            this.label3.Top = 0.6579999F;
            this.label3.Width = 0.8330001F;
            // 
            // label4
            // 
            this.label4.Height = 0.2F;
            this.label4.HyperLink = null;
            this.label4.Left = 1.458F;
            this.label4.Name = "label4";
            this.label4.Style = "font-size: 8.25pt; font-weight: bold; ddo-char-set: 0";
            this.label4.Text = "Fecha:";
            this.label4.Top = 0.6579999F;
            this.label4.Width = 0.406F;
            // 
            // textBox1
            // 
            this.textBox1.DataField = "FechaMovimiento";
            this.textBox1.Height = 0.2F;
            this.textBox1.Left = 1.864F;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.textBox1.Text = "textBox1";
            this.textBox1.Top = 0.6579999F;
            this.textBox1.Width = 1.011F;
            // 
            // label5
            // 
            this.label5.Height = 0.2F;
            this.label5.HyperLink = null;
            this.label5.Left = 0.08400024F;
            this.label5.Name = "label5";
            this.label5.Style = "font-size: 8.25pt; font-weight: bold; ddo-char-set: 0";
            this.label5.Text = "Sucursal:";
            this.label5.Top = 0.4079999F;
            this.label5.Width = 0.573F;
            // 
            // label6
            // 
            this.label6.DataField = "SucursalOrigen";
            this.label6.Height = 0.2F;
            this.label6.HyperLink = null;
            this.label6.Left = 0.6570002F;
            this.label6.Name = "label6";
            this.label6.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.label6.Text = "label3";
            this.label6.Top = 0.4079999F;
            this.label6.Width = 2.218F;
            // 
            // line1
            // 
            this.line1.Height = 0F;
            this.line1.Left = 0.08400024F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0.937F;
            this.line1.Width = 2.791F;
            this.line1.X1 = 0.08400024F;
            this.line1.X2 = 2.875F;
            this.line1.Y1 = 0.937F;
            this.line1.Y2 = 0.937F;
            // 
            // label7
            // 
            this.label7.Height = 0.2F;
            this.label7.HyperLink = null;
            this.label7.Left = 0.08400024F;
            this.label7.Name = "label7";
            this.label7.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.label7.Text = "CLAVE";
            this.label7.Top = 0.945F;
            this.label7.Width = 0.4580001F;
            // 
            // label8
            // 
            this.label8.Height = 0.2F;
            this.label8.HyperLink = null;
            this.label8.Left = 0.5420004F;
            this.label8.Name = "label8";
            this.label8.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.label8.Text = "DESCRIPCIÓN";
            this.label8.Top = 0.9449999F;
            this.label8.Width = 1.749F;
            // 
            // line2
            // 
            this.line2.Height = 0F;
            this.line2.Left = 0.08400024F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 1.145F;
            this.line2.Width = 2.791F;
            this.line2.X1 = 0.08400024F;
            this.line2.X2 = 2.875F;
            this.line2.Y1 = 1.145F;
            this.line2.Y2 = 1.145F;
            // 
            // reportFooter1
            // 
            this.reportFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label12,
            this.line3,
            this.pageBreak1,
            this.uiAutorizadoPor});
            this.reportFooter1.Height = 0.875F;
            this.reportFooter1.Name = "reportFooter1";
            this.reportFooter1.Format += new System.EventHandler(this.reportFooter1_Format);
            // 
            // label12
            // 
            this.label12.Height = 0.2F;
            this.label12.HyperLink = null;
            this.label12.Left = 0.167F;
            this.label12.Name = "label12";
            this.label12.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.label12.Text = "CANCELADO POR";
            this.label12.Top = 0.062F;
            this.label12.Width = 1.104F;
            // 
            // line3
            // 
            this.line3.Height = 0F;
            this.line3.Left = 0.167F;
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0.5F;
            this.line3.Width = 1.104F;
            this.line3.X1 = 0.167F;
            this.line3.X2 = 1.271F;
            this.line3.Y1 = 0.5F;
            this.line3.Y2 = 0.5F;
            // 
            // pageBreak1
            // 
            this.pageBreak1.Height = 0.2F;
            this.pageBreak1.Left = 0F;
            this.pageBreak1.Name = "pageBreak1";
            this.pageBreak1.Size = new System.Drawing.SizeF(6.5F, 0.2F);
            this.pageBreak1.Top = 0.7710001F;
            this.pageBreak1.Width = 6.5F;
            // 
            // uiAutorizadoPor
            // 
            this.uiAutorizadoPor.DataField = "AutorizadoPor";
            this.uiAutorizadoPor.Height = 0.2F;
            this.uiAutorizadoPor.Left = 0.167F;
            this.uiAutorizadoPor.Name = "uiAutorizadoPor";
            this.uiAutorizadoPor.OutputFormat = resources.GetString("uiAutorizadoPor.OutputFormat");
            this.uiAutorizadoPor.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.uiAutorizadoPor.Text = "textBox1";
            this.uiAutorizadoPor.Top = 0.5F;
            this.uiAutorizadoPor.Width = 1.011F;
            // 
            // label13
            // 
            this.label13.Height = 0.169F;
            this.label13.HyperLink = null;
            this.label13.Left = 0.08400001F;
            this.label13.Name = "label13";
            this.label13.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label13.Text = "CANCELACIÓN";
            this.label13.Top = 0.06999999F;
            this.label13.Width = 2.791F;
            // 
            // rptMovimientoInventarioCancelacion
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
            this.PageSettings.PaperWidth = 4F;
            this.PrintWidth = 2.958333F;
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
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiAutorizadoPor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private GrapeCity.ActiveReports.SectionReportModel.Label label10;
        private GrapeCity.ActiveReports.SectionReportModel.Label label11;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label1;
        private GrapeCity.ActiveReports.SectionReportModel.ReportHeader reportHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label9;
        private GrapeCity.ActiveReports.SectionReportModel.Label label2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label3;
        private GrapeCity.ActiveReports.SectionReportModel.Label label4;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label5;
        private GrapeCity.ActiveReports.SectionReportModel.Label label6;
        private GrapeCity.ActiveReports.SectionReportModel.Line line1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label7;
        private GrapeCity.ActiveReports.SectionReportModel.Label label8;
        private GrapeCity.ActiveReports.SectionReportModel.Line line2;
        private GrapeCity.ActiveReports.SectionReportModel.ReportFooter reportFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label12;
        private GrapeCity.ActiveReports.SectionReportModel.Line line3;
        private GrapeCity.ActiveReports.SectionReportModel.PageBreak pageBreak1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox uiAutorizadoPor;
        private GrapeCity.ActiveReports.SectionReportModel.Label label13;
    }
}
