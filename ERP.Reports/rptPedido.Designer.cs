namespace ERP.Reports
{
    /// <summary>
    /// Summary description for rptVentaTicket.
    /// </summary>
    partial class rptPedido
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rptPedido));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.textBox10 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox11 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.groupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.textBox15 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line4 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.textBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox7 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.groupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.textBox8 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox9 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox12 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.line1});
            this.pageHeader.Height = 0.01041666F;
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
            this.textBox10,
            this.textBox11,
            this.textBox2,
            this.textBox3});
            this.detail.Height = 0.148F;
            this.detail.Name = "detail";
            // 
            // textBox10
            // 
            this.textBox10.DataField = "Cantidad";
            this.textBox10.Height = 0.148F;
            this.textBox10.Left = 1.187F;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "font-size: 6.75pt; text-align: right; ddo-char-set: 0";
            this.textBox10.Text = "000.0000";
            this.textBox10.Top = 0F;
            this.textBox10.Width = 0.458F;
            // 
            // textBox11
            // 
            this.textBox11.DataField = "Producto";
            this.textBox11.Height = 0.148F;
            this.textBox11.Left = 0.082F;
            this.textBox11.Name = "textBox11";
            this.textBox11.Style = "font-size: 6.75pt; ddo-char-set: 0";
            this.textBox11.Text = "textBox10";
            this.textBox11.Top = 0F;
            this.textBox11.Width = 1.187F;
            // 
            // textBox2
            // 
            this.textBox2.CurrencyCulture = new System.Globalization.CultureInfo("en-US");
            this.textBox2.DataField = "Precio";
            this.textBox2.Height = 0.148F;
            this.textBox2.Left = 1.75F;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "font-size: 6.75pt; ddo-char-set: 0";
            this.textBox2.Text = "textBox10";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.5619998F;
            // 
            // textBox3
            // 
            this.textBox3.CurrencyCulture = new System.Globalization.CultureInfo("en-US");
            this.textBox3.DataField = "Total";
            this.textBox3.Height = 0.148F;
            this.textBox3.Left = 2.315F;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "font-size: 6.75pt; text-align: right; ddo-char-set: 0";
            this.textBox3.Text = "textBox10";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.497F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.textBox15,
            this.label4,
            this.label3,
            this.textBox4,
            this.textBox6,
            this.label1,
            this.label2,
            this.line3,
            this.line4,
            this.textBox5,
            this.textBox1,
            this.textBox7,
            this.textBox9,
            this.textBox12});
            this.groupHeader1.Height = 1.266028F;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.Format += new System.EventHandler(this.groupHeader1_Format);
            // 
            // textBox15
            // 
            this.textBox15.DataField = "Direccion";
            this.textBox15.Height = 0.2F;
            this.textBox15.Left = 0.062F;
            this.textBox15.Name = "textBox15";
            this.textBox15.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.textBox15.Text = null;
            this.textBox15.Top = 0.928F;
            this.textBox15.Width = 2.843F;
            // 
            // label4
            // 
            this.label4.Height = 0.138F;
            this.label4.HyperLink = null;
            this.label4.Left = 2.303F;
            this.label4.Name = "label4";
            this.label4.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.label4.Text = "TOTAL";
            this.label4.Top = 1.128F;
            this.label4.Width = 0.54F;
            // 
            // label3
            // 
            this.label3.Height = 0.138F;
            this.label3.HyperLink = null;
            this.label3.Left = 1.741F;
            this.label3.Name = "label3";
            this.label3.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.label3.Text = "P.U.";
            this.label3.Top = 1.128F;
            this.label3.Width = 0.415F;
            // 
            // textBox4
            // 
            this.textBox4.DataField = "Folio";
            this.textBox4.Height = 0.2F;
            this.textBox4.Left = 0F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.textBox4.Text = "FOLIO VENTA";
            this.textBox4.Top = 0.06200004F;
            this.textBox4.Width = 2.896F;
            // 
            // textBox6
            // 
            this.textBox6.Height = 0.151F;
            this.textBox6.Left = 0.06200005F;
            this.textBox6.Name = "textBox6";
            this.textBox6.Style = "font-size: 8.25pt; text-align: left; ddo-char-set: 0";
            this.textBox6.Text = "FECHA:";
            this.textBox6.Top = 0.262F;
            this.textBox6.Width = 0.6070001F;
            // 
            // label1
            // 
            this.label1.Height = 0.138F;
            this.label1.HyperLink = null;
            this.label1.Left = 1.178F;
            this.label1.Name = "label1";
            this.label1.Style = "font-size: 6.75pt; ddo-char-set: 0";
            this.label1.Text = "CANT";
            this.label1.Top = 1.128F;
            this.label1.Width = 0.436F;
            // 
            // label2
            // 
            this.label2.Height = 0.138F;
            this.label2.HyperLink = null;
            this.label2.Left = 0.05300004F;
            this.label2.Name = "label2";
            this.label2.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.label2.Text = "DESCRIPCION";
            this.label2.Top = 1.128F;
            this.label2.Width = 1.125F;
            // 
            // line3
            // 
            this.line3.Height = 0F;
            this.line3.Left = 0.05300006F;
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 1.128F;
            this.line3.Width = 2.824F;
            this.line3.X1 = 0.05300006F;
            this.line3.X2 = 2.877F;
            this.line3.Y1 = 1.128F;
            this.line3.Y2 = 1.128F;
            // 
            // line4
            // 
            this.line4.Height = 0F;
            this.line4.Left = 0.04400006F;
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 1.266F;
            this.line4.Width = 2.824F;
            this.line4.X1 = 0.04400006F;
            this.line4.X2 = 2.868F;
            this.line4.Y1 = 1.266F;
            this.line4.Y2 = 1.266F;
            // 
            // textBox5
            // 
            this.textBox5.DataField = "Cliente";
            this.textBox5.Height = 0.151F;
            this.textBox5.Left = 0.706F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.textBox5.Text = null;
            this.textBox5.Top = 0.696F;
            this.textBox5.Width = 2.199F;
            // 
            // textBox1
            // 
            this.textBox1.DataField = "FechaPedido";
            this.textBox1.Height = 0.148F;
            this.textBox1.Left = 0.687F;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "font-size: 6.75pt; text-align: left; ddo-char-set: 0";
            this.textBox1.Text = "000.0000";
            this.textBox1.Top = 0.25F;
            this.textBox1.Width = 1.125F;
            // 
            // textBox7
            // 
            this.textBox7.Height = 0.151F;
            this.textBox7.Left = 0.07200006F;
            this.textBox7.Name = "textBox7";
            this.textBox7.Style = "font-size: 8.25pt; text-align: left; ddo-char-set: 0";
            this.textBox7.Text = "CLIENTE:";
            this.textBox7.Top = 0.696F;
            this.textBox7.Width = 0.6070001F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.textBox8});
            this.groupFooter1.Height = 0.2290835F;
            this.groupFooter1.Name = "groupFooter1";
            this.groupFooter1.Format += new System.EventHandler(this.groupFooter1_Format);
            this.groupFooter1.BeforePrint += new System.EventHandler(this.groupFooter1_BeforePrint);
            // 
            // textBox8
            // 
            this.textBox8.CurrencyCulture = new System.Globalization.CultureInfo("en-US");
            this.textBox8.DataField = "Total";
            this.textBox8.DistinctField = "Total";
            this.textBox8.Height = 0.148F;
            this.textBox8.Left = 2.062F;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "font-size: 7.2pt; font-weight: bold; text-align: right; ddo-char-set: 0";
            this.textBox8.SummaryGroup = "groupHeader1";
            this.textBox8.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox8.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal;
            this.textBox8.Text = "textBox10";
            this.textBox8.Top = 0F;
            this.textBox8.Width = 0.7519999F;
            // 
            // textBox9
            // 
            this.textBox9.DataField = "SucursalProduccion";
            this.textBox9.Height = 0.151F;
            this.textBox9.Left = 0.872F;
            this.textBox9.Name = "textBox9";
            this.textBox9.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.textBox9.Text = null;
            this.textBox9.Top = 0.483F;
            this.textBox9.Width = 2.024F;
            // 
            // textBox12
            // 
            this.textBox12.Height = 0.151F;
            this.textBox12.Left = 0.063F;
            this.textBox12.Name = "textBox12";
            this.textBox12.Style = "font-size: 8.25pt; text-align: left; ddo-char-set: 0";
            this.textBox12.Text = "SUCURSAL:";
            this.textBox12.Top = 0.483F;
            this.textBox12.Width = 0.699F;
            // 
            // rptPedido
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
            this.PrintWidth = 2.95F;
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private GrapeCity.ActiveReports.SectionReportModel.Line line1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox10;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox11;
        private GrapeCity.ActiveReports.SectionReportModel.GroupHeader groupHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.GroupFooter groupFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox4;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox6;
        private GrapeCity.ActiveReports.SectionReportModel.Label label1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label2;
        private GrapeCity.ActiveReports.SectionReportModel.Line line3;
        private GrapeCity.ActiveReports.SectionReportModel.Line line4;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox5;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox15;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox2;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox3;
        private GrapeCity.ActiveReports.SectionReportModel.Label label4;
        private GrapeCity.ActiveReports.SectionReportModel.Label label3;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox7;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox8;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox9;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox12;
    }
}
