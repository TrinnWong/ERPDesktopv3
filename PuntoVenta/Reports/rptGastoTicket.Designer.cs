namespace PuntoVenta.Reports
{
    /// <summary>
    /// Summary description for rptGastoTicket.
    /// </summary>
    partial class rptGastoTicket
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rptGastoTicket));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.subRepFoto = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.reportHeader1 = new GrapeCity.ActiveReports.SectionReportModel.ReportHeader();
            this.reportFooter1 = new GrapeCity.ActiveReports.SectionReportModel.ReportFooter();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label1,
            this.label2,
            this.label9,
            this.subRepFoto});
            this.pageHeader.Height = 1.25F;
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
            // 
            // label1
            // 
            this.label1.DataField = "Empresa";
            this.label1.Height = 0.148F;
            this.label1.HyperLink = null;
            this.label1.Left = 0F;
            this.label1.Name = "label1";
            this.label1.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.label1.Text = "label1";
            this.label1.Top = 0.747F;
            this.label1.Width = 2.895F;
            // 
            // label2
            // 
            this.label2.DataField = "Sucursal";
            this.label2.Height = 0.148F;
            this.label2.HyperLink = null;
            this.label2.Left = 0F;
            this.label2.Name = "label2";
            this.label2.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.label2.Text = "label1";
            this.label2.Top = 0.8950002F;
            this.label2.Width = 2.895F;
            // 
            // label9
            // 
            this.label9.Height = 0.2F;
            this.label9.HyperLink = null;
            this.label9.Left = 0F;
            this.label9.Name = "label9";
            this.label9.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label9.Text = "COMPROBANTE DE GASTO";
            this.label9.Top = 1.043F;
            this.label9.Width = 2.895F;
            // 
            // subRepFoto
            // 
            this.subRepFoto.CloseBorder = false;
            this.subRepFoto.Height = 0.747F;
            this.subRepFoto.Left = 0F;
            this.subRepFoto.Name = "subRepFoto";
            this.subRepFoto.Report = null;
            this.subRepFoto.ReportName = "";
            this.subRepFoto.Top = 0F;
            this.subRepFoto.Width = 3F;
            // 
            // detail
            // 
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label8,
            this.label3,
            this.textBox1,
            this.label4,
            this.textBox2,
            this.label5,
            this.textBox3,
            this.label6,
            this.textBox4,
            this.label7,
            this.line1,
            this.label10,
            this.textBox5});
            this.detail.Height = 1.916667F;
            this.detail.Name = "detail";
            // 
            // label8
            // 
            this.label8.DataField = "RegistradoPor";
            this.label8.Height = 0.1579999F;
            this.label8.HyperLink = null;
            this.label8.Left = 0.106F;
            this.label8.Name = "label8";
            this.label8.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label8.Text = "MONTO";
            this.label8.Top = 1.562F;
            this.label8.Width = 2.865F;
            // 
            // label3
            // 
            this.label3.Height = 0.134F;
            this.label3.HyperLink = null;
            this.label3.Left = 0.342F;
            this.label3.Name = "label3";
            this.label3.Style = "font-size: 8.25pt; font-weight: bold; text-align: right; ddo-char-set: 0";
            this.label3.Text = "CONCEPTO:";
            this.label3.Top = 0.295F;
            this.label3.Width = 1.22F;
            // 
            // textBox1
            // 
            this.textBox1.DataField = "Concepto";
            this.textBox1.Height = 0.134F;
            this.textBox1.Left = 1.708F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.textBox1.Text = "textBox1";
            this.textBox1.Top = 0.295F;
            this.textBox1.Width = 1.239F;
            // 
            // label4
            // 
            this.label4.Height = 0.158F;
            this.label4.HyperLink = null;
            this.label4.Left = 0.206F;
            this.label4.Name = "label4";
            this.label4.Style = "font-size: 8.25pt; font-weight: bold; text-align: right; ddo-char-set: 0";
            this.label4.Text = "CENTRO COSTO:";
            this.label4.Top = 0.137F;
            this.label4.Width = 1.356F;
            // 
            // textBox2
            // 
            this.textBox2.DataField = "CentroCosto";
            this.textBox2.Height = 0.158F;
            this.textBox2.Left = 1.708F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.textBox2.Text = "textBox1";
            this.textBox2.Top = 0.137F;
            this.textBox2.Width = 1.251F;
            // 
            // label5
            // 
            this.label5.Height = 0.148F;
            this.label5.HyperLink = null;
            this.label5.Left = 0.106F;
            this.label5.Name = "label5";
            this.label5.Style = "font-size: 8.25pt; font-weight: bold; text-align: right; ddo-char-set: 0";
            this.label5.Text = "OBSERVACIONES:";
            this.label5.Top = 0.429F;
            this.label5.Width = 1.468F;
            // 
            // textBox3
            // 
            this.textBox3.DataField = "Obervaciones";
            this.textBox3.Height = 0.148F;
            this.textBox3.Left = 1.708F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.textBox3.Text = "textBox1";
            this.textBox3.Top = 0.429F;
            this.textBox3.Width = 1.251F;
            // 
            // label6
            // 
            this.label6.Height = 0.2F;
            this.label6.HyperLink = null;
            this.label6.Left = 0.106F;
            this.label6.Name = "label6";
            this.label6.Style = "font-size: 9.75pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label6.Text = "MONTO";
            this.label6.Top = 0.6390001F;
            this.label6.Width = 2.865F;
            // 
            // textBox4
            // 
            this.textBox4.CurrencyCulture = new System.Globalization.CultureInfo("es-MX");
            this.textBox4.DataField = "Monto";
            this.textBox4.Height = 0.2F;
            this.textBox4.Left = 0.106F;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.textBox4.Text = "textBox4";
            this.textBox4.Top = 0.839F;
            this.textBox4.Width = 2.865F;
            // 
            // label7
            // 
            this.label7.Height = 0.1579999F;
            this.label7.HyperLink = null;
            this.label7.Left = 0.106F;
            this.label7.Name = "label7";
            this.label7.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label7.Text = "REGISTRADO POR";
            this.label7.Top = 1.039F;
            this.label7.Width = 2.865F;
            // 
            // line1
            // 
            this.line1.Height = 0F;
            this.line1.Left = 0.206F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 1.51F;
            this.line1.Width = 2.624F;
            this.line1.X1 = 0.206F;
            this.line1.X2 = 2.83F;
            this.line1.Y1 = 1.51F;
            this.line1.Y2 = 1.51F;
            // 
            // label10
            // 
            this.label10.Height = 0.137F;
            this.label10.HyperLink = null;
            this.label10.Left = 0.206F;
            this.label10.Name = "label10";
            this.label10.Style = "font-size: 8.25pt; font-weight: bold; text-align: right; ddo-char-set: 0";
            this.label10.Text = "FECHA:";
            this.label10.Top = 0F;
            this.label10.Width = 1.356F;
            // 
            // textBox5
            // 
            this.textBox5.DataField = "Fecha";
            this.textBox5.Height = 0.137F;
            this.textBox5.Left = 1.708F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.textBox5.Text = "textBox1";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 1.250999F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // reportHeader1
            // 
            this.reportHeader1.Height = 0.02083333F;
            this.reportHeader1.Name = "reportHeader1";
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0.01041667F;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // rptGastoTicket
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
            this.PageSettings.PaperWidth = 4F;
            this.PrintWidth = 2.979167F;
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
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private GrapeCity.ActiveReports.SectionReportModel.Label label1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label3;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label4;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label5;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox3;
        private GrapeCity.ActiveReports.SectionReportModel.Label label6;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox4;
        private GrapeCity.ActiveReports.SectionReportModel.Label label7;
        private GrapeCity.ActiveReports.SectionReportModel.Line line1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label8;
        private GrapeCity.ActiveReports.SectionReportModel.ReportHeader reportHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.ReportFooter reportFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label9;
        private GrapeCity.ActiveReports.SectionReportModel.Label label10;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox5;
        private GrapeCity.ActiveReports.SectionReportModel.SubReport subRepFoto;
    }
}
