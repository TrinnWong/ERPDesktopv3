namespace ERP.Reports
{
    /// <summary>
    /// Summary description for rptDevolucionTicket.
    /// </summary>
    partial class rptDevolucionTicket
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rptDevolucionTicket));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.groupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.subRepFoto = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.groupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.textBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.pageBreak1 = new GrapeCity.ActiveReports.SectionReportModel.PageBreak();
            this.textBox7 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
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
            this.label4,
            this.textBox1,
            this.label5,
            this.textBox2,
            this.label6,
            this.textBox3,
            this.label8,
            this.textBox5,
            this.label9,
            this.textBox6});
            this.detail.Height = 1.510417F;
            this.detail.Name = "detail";
            // 
            // label4
            // 
            this.label4.Height = 0.169F;
            this.label4.HyperLink = null;
            this.label4.Left = 1.625F;
            this.label4.Name = "label4";
            this.label4.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label4.Text = "FECHA DEV.";
            this.label4.Top = 0F;
            this.label4.Width = 1.281F;
            // 
            // textBox1
            // 
            this.textBox1.DataField = "FechaRegistro";
            this.textBox1.Height = 0.2F;
            this.textBox1.Left = 1.625F;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.textBox1.Text = "textBox1";
            this.textBox1.Top = 0.169F;
            this.textBox1.Width = 1.281F;
            // 
            // label5
            // 
            this.label5.Height = 0.169F;
            this.label5.HyperLink = null;
            this.label5.Left = 0.156F;
            this.label5.Name = "label5";
            this.label5.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label5.Text = "FOLIO DEV.";
            this.label5.Top = 0F;
            this.label5.Width = 1.469F;
            // 
            // textBox2
            // 
            this.textBox2.DataField = "DevolucionId";
            this.textBox2.Height = 0.2F;
            this.textBox2.Left = 0.156F;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.textBox2.Text = "textBox1";
            this.textBox2.Top = 0.169F;
            this.textBox2.Width = 1.469F;
            // 
            // label6
            // 
            this.label6.Height = 0.169F;
            this.label6.HyperLink = null;
            this.label6.Left = 0.156F;
            this.label6.Name = "label6";
            this.label6.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label6.Text = "MONTO";
            this.label6.Top = 0.738F;
            this.label6.Width = 2.75F;
            // 
            // textBox3
            // 
            this.textBox3.CurrencyCulture = new System.Globalization.CultureInfo("es-MX");
            this.textBox3.DataField = "Total";
            this.textBox3.Height = 0.2F;
            this.textBox3.Left = 0.156F;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.textBox3.Text = "textBox1";
            this.textBox3.Top = 0.9070001F;
            this.textBox3.Width = 2.75F;
            // 
            // label8
            // 
            this.label8.Height = 0.169F;
            this.label8.HyperLink = null;
            this.label8.Left = 0.156F;
            this.label8.Name = "label8";
            this.label8.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label8.Text = "TICKET";
            this.label8.Top = 0.369F;
            this.label8.Width = 2.75F;
            // 
            // textBox5
            // 
            this.textBox5.DataField = "VentaId";
            this.textBox5.Height = 0.2F;
            this.textBox5.Left = 0.156F;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.textBox5.Text = "textBox1";
            this.textBox5.Top = 0.538F;
            this.textBox5.Width = 2.75F;
            // 
            // label9
            // 
            this.label9.Height = 0.169F;
            this.label9.HyperLink = null;
            this.label9.Left = 0.156F;
            this.label9.Name = "label9";
            this.label9.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label9.Text = "VENCIMIENTO";
            this.label9.Top = 1.107F;
            this.label9.Width = 2.75F;
            // 
            // textBox6
            // 
            this.textBox6.DataField = "FechaVencimiento";
            this.textBox6.Height = 0.2F;
            this.textBox6.Left = 0.156F;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.textBox6.Text = "textBox1";
            this.textBox6.Top = 1.276F;
            this.textBox6.Width = 2.75F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label1,
            this.label2,
            this.label3,
            this.label10,
            this.subRepFoto});
            this.groupHeader1.Height = 1.45725F;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.Format += new System.EventHandler(this.groupHeader1_Format);
            // 
            // label1
            // 
            this.label1.DataField = "Empresa";
            this.label1.Height = 0.169F;
            this.label1.HyperLink = null;
            this.label1.Left = 0.093F;
            this.label1.Name = "label1";
            this.label1.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.label1.Text = "label1";
            this.label1.Top = 0.7600001F;
            this.label1.Width = 2.687F;
            // 
            // label2
            // 
            this.label2.DataField = "Sucursal";
            this.label2.Height = 0.169F;
            this.label2.HyperLink = null;
            this.label2.Left = 0.093F;
            this.label2.Name = "label2";
            this.label2.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.label2.Text = "label1";
            this.label2.Top = 0.9290001F;
            this.label2.Width = 2.687F;
            // 
            // label3
            // 
            this.label3.Height = 0.169F;
            this.label3.HyperLink = null;
            this.label3.Left = 0.093F;
            this.label3.Name = "label3";
            this.label3.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label3.Text = "VALE DEVOLUCIÓN";
            this.label3.Top = 1.098F;
            this.label3.Width = 2.687F;
            // 
            // label10
            // 
            this.label10.DataField = "TipoDevolucion";
            this.label10.Height = 0.169F;
            this.label10.HyperLink = null;
            this.label10.Left = 0.093F;
            this.label10.Name = "label10";
            this.label10.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.label10.Text = "label1";
            this.label10.Top = 1.267F;
            this.label10.Width = 2.687F;
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
            this.subRepFoto.Width = 2.969F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.textBox4,
            this.label7,
            this.line1,
            this.pageBreak1,
            this.textBox7});
            this.groupFooter1.Height = 1.1875F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // textBox4
            // 
            this.textBox4.DataField = "RegistradoPor";
            this.textBox4.Height = 0.2F;
            this.textBox4.Left = 0.156F;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.textBox4.Text = "textBox1";
            this.textBox4.Top = 0.535F;
            this.textBox4.Width = 2.75F;
            // 
            // label7
            // 
            this.label7.Height = 0.169F;
            this.label7.HyperLink = null;
            this.label7.Left = 0.156F;
            this.label7.Name = "label7";
            this.label7.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label7.Text = "REGISTRADO POR";
            this.label7.Top = 0.06600001F;
            this.label7.Width = 2.75F;
            // 
            // line1
            // 
            this.line1.Height = 0.01000005F;
            this.line1.Left = 0.729F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0.525F;
            this.line1.Width = 1.542F;
            this.line1.X1 = 0.729F;
            this.line1.X2 = 2.271F;
            this.line1.Y1 = 0.535F;
            this.line1.Y2 = 0.525F;
            // 
            // pageBreak1
            // 
            this.pageBreak1.Height = 0.01F;
            this.pageBreak1.Left = 0F;
            this.pageBreak1.Name = "pageBreak1";
            this.pageBreak1.Size = new System.Drawing.SizeF(6.5F, 0.01F);
            this.pageBreak1.Top = 1.087F;
            this.pageBreak1.Width = 6.5F;
            // 
            // textBox7
            // 
            this.textBox7.CurrencyCulture = new System.Globalization.CultureInfo("es-MX");
            this.textBox7.Height = 0.294F;
            this.textBox7.Left = 0.156F;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "font-family: Arial Narrow; font-size: 8.25pt; font-style: italic; font-weight: bo" +
    "ld; text-align: center; ddo-char-set: 0";
            this.textBox7.Text = "Este vale solo es válido en la sucursal donde haya sido adquirido el producto";
            this.textBox7.Top = 0.735F;
            this.textBox7.Width = 2.75F;
            // 
            // rptDevolucionTicket
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
            this.PrintWidth = 2.96875F;
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
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private GrapeCity.ActiveReports.SectionReportModel.Label label4;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label5;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label6;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox3;
        private GrapeCity.ActiveReports.SectionReportModel.GroupHeader groupHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label3;
        private GrapeCity.ActiveReports.SectionReportModel.GroupFooter groupFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox4;
        private GrapeCity.ActiveReports.SectionReportModel.Label label7;
        private GrapeCity.ActiveReports.SectionReportModel.Line line1;
        private GrapeCity.ActiveReports.SectionReportModel.PageBreak pageBreak1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label8;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox5;
        private GrapeCity.ActiveReports.SectionReportModel.Label label9;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox6;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox7;
        private GrapeCity.ActiveReports.SectionReportModel.Label label10;
        private GrapeCity.ActiveReports.SectionReportModel.SubReport subRepFoto;
    }
}
