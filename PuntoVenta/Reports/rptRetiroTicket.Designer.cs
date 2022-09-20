namespace PuntoVenta.Reports
{
    /// <summary>
    /// Summary description for rptVentaTicket.
    /// </summary>
    partial class rptRetiroTicket
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rptRetiroTicket));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox8 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox9 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox7 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox10 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox11 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox12 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.pageBreak1 = new GrapeCity.ActiveReports.SectionReportModel.PageBreak();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.groupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.groupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.textBox13 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox14 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.pageBreak2 = new GrapeCity.ActiveReports.SectionReportModel.PageBreak();
            this.subRepFoto = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
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
            this.textBox4,
            this.textBox6,
            this.textBox8,
            this.textBox9,
            this.label9,
            this.textBox7,
            this.textBox3,
            this.textBox5,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.pageBreak1});
            this.detail.Height = 1.741667F;
            this.detail.Name = "detail";
            // 
            // textBox1
            // 
            this.textBox1.DataField = "NombreSucursal";
            this.textBox1.Height = 0.169F;
            this.textBox1.Left = 0.07600001F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.textBox1.Text = "textBox1";
            this.textBox1.Top = 0.148F;
            this.textBox1.Width = 2.886F;
            // 
            // textBox2
            // 
            this.textBox2.DataField = "Direccion";
            this.textBox2.Height = 0.148F;
            this.textBox2.Left = 0.08400001F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.textBox2.Text = "textBox1";
            this.textBox2.Top = 0.317F;
            this.textBox2.Width = 2.886F;
            // 
            // textBox4
            // 
            this.textBox4.Height = 0.148F;
            this.textBox4.Left = 0.8340001F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "font-size: 8.25pt; text-align: right; ddo-char-set: 0";
            this.textBox4.Text = "FOLIO RETIRO:";
            this.textBox4.Top = 0.465F;
            this.textBox4.Width = 1.1F;
            // 
            // textBox6
            // 
            this.textBox6.Height = 0.148F;
            this.textBox6.Left = 0.188F;
            this.textBox6.Name = "textBox6";
            this.textBox6.Style = "font-size: 8.25pt; text-align: left; ddo-char-set: 0";
            this.textBox6.Text = "FECHA:";
            this.textBox6.Top = 0.613F;
            this.textBox6.Width = 0.5440002F;
            // 
            // textBox8
            // 
            this.textBox8.Height = 0.148F;
            this.textBox8.Left = 1.405F;
            this.textBox8.Name = "textBox8";
            this.textBox8.Style = "font-size: 8.25pt; text-align: left; ddo-char-set: 0";
            this.textBox8.Text = "HORA:";
            this.textBox8.Top = 0.613F;
            this.textBox8.Width = 0.6560001F;
            // 
            // textBox9
            // 
            this.textBox9.DataField = "HORA";
            this.textBox9.Height = 0.148F;
            this.textBox9.Left = 1.853F;
            this.textBox9.Name = "textBox9";
            this.textBox9.Style = "font-size: 8.25pt; text-align: left; ddo-char-set: 0";
            this.textBox9.Text = null;
            this.textBox9.Top = 0.613F;
            this.textBox9.Width = 1.037F;
            // 
            // label9
            // 
            this.label9.DataField = "FECHA";
            this.label9.Height = 0.148F;
            this.label9.HyperLink = null;
            this.label9.Left = 0.7070001F;
            this.label9.Name = "label9";
            this.label9.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.label9.Text = "label9";
            this.label9.Top = 0.613F;
            this.label9.Width = 0.6980001F;
            // 
            // textBox7
            // 
            this.textBox7.DataField = "RFC";
            this.textBox7.Height = 0.148F;
            this.textBox7.Left = 0.07600001F;
            this.textBox7.Name = "textBox7";
            this.textBox7.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.textBox7.Text = "RFC";
            this.textBox7.Top = 0F;
            this.textBox7.Width = 2.886F;
            // 
            // textBox3
            // 
            this.textBox3.DataField = "RetiroId";
            this.textBox3.Height = 0.148F;
            this.textBox3.Left = 1.934F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "font-size: 8.25pt; text-align: left; ddo-char-set: 0";
            this.textBox3.Text = null;
            this.textBox3.Top = 0.465F;
            this.textBox3.Width = 1.028F;
            // 
            // textBox5
            // 
            this.textBox5.Height = 0.2F;
            this.textBox5.Left = 0.08400005F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0";
            this.textBox5.Text = "MONTO RETIRO:";
            this.textBox5.Top = 0.823F;
            this.textBox5.Width = 1.412F;
            // 
            // textBox10
            // 
            this.textBox10.CurrencyCulture = new System.Globalization.CultureInfo("es-MX");
            this.textBox10.DataField = "MontoRetiro";
            this.textBox10.Height = 0.2F;
            this.textBox10.Left = 1.548F;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0";
            this.textBox10.Text = null;
            this.textBox10.Top = 0.823F;
            this.textBox10.Width = 1.342F;
            // 
            // textBox11
            // 
            this.textBox11.Height = 0.2F;
            this.textBox11.Left = 0.1360001F;
            this.textBox11.Name = "textBox11";
            this.textBox11.Style = "font-size: 8.25pt; text-align: right; ddo-char-set: 0";
            this.textBox11.Text = "OBSERVACIONES:";
            this.textBox11.Top = 1.115F;
            this.textBox11.Width = 1.412F;
            // 
            // textBox12
            // 
            this.textBox12.DataField = "Observaciones";
            this.textBox12.Height = 0.2F;
            this.textBox12.Left = 1.548F;
            this.textBox12.Name = "textBox12";
            this.textBox12.Style = "font-size: 8.25pt; text-align: left; ddo-char-set: 0";
            this.textBox12.Text = null;
            this.textBox12.Top = 1.115F;
            this.textBox12.Width = 1.193F;
            // 
            // pageBreak1
            // 
            this.pageBreak1.Height = 0.01F;
            this.pageBreak1.Left = 0F;
            this.pageBreak1.Name = "pageBreak1";
            this.pageBreak1.Size = new System.Drawing.SizeF(6.5F, 0.01F);
            this.pageBreak1.Top = 1.729F;
            this.pageBreak1.Width = 6.5F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.subRepFoto});
            this.groupHeader1.Height = 0.5833333F;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.Format += new System.EventHandler(this.groupHeader1_Format);
            // 
            // groupFooter1
            // 
            this.groupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.textBox13,
            this.textBox14,
            this.line1,
            this.pageBreak2});
            this.groupFooter1.Height = 0.9583334F;
            this.groupFooter1.Name = "groupFooter1";
            this.groupFooter1.Format += new System.EventHandler(this.groupFooter1_Format);
            this.groupFooter1.BeforePrint += new System.EventHandler(this.groupFooter1_BeforePrint);
            // 
            // textBox13
            // 
            this.textBox13.Height = 0.2F;
            this.textBox13.Left = 0.136F;
            this.textBox13.Name = "textBox13";
            this.textBox13.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.textBox13.Text = "REGISTRADOR POR:";
            this.textBox13.Top = 0.06400001F;
            this.textBox13.Width = 2.806F;
            // 
            // textBox14
            // 
            this.textBox14.DataField = "Usuario";
            this.textBox14.DistinctField = "Usuario";
            this.textBox14.Height = 0.2F;
            this.textBox14.Left = 0.136F;
            this.textBox14.Name = "textBox14";
            this.textBox14.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.textBox14.Text = null;
            this.textBox14.Top = 0.5100001F;
            this.textBox14.Width = 2.806F;
            // 
            // line1
            // 
            this.line1.Height = 0F;
            this.line1.Left = 0.4050001F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0.5100001F;
            this.line1.Width = 2.336F;
            this.line1.X1 = 0.4050001F;
            this.line1.X2 = 2.741F;
            this.line1.Y1 = 0.5100001F;
            this.line1.Y2 = 0.5100001F;
            // 
            // pageBreak2
            // 
            this.pageBreak2.Height = 0.2F;
            this.pageBreak2.Left = 0F;
            this.pageBreak2.Name = "pageBreak2";
            this.pageBreak2.Size = new System.Drawing.SizeF(6.5F, 0.2F);
            this.pageBreak2.Top = 0.8750001F;
            this.pageBreak2.Width = 6.5F;
            // 
            // subRepFoto
            // 
            this.subRepFoto.CloseBorder = false;
            this.subRepFoto.Height = 0.524F;
            this.subRepFoto.Left = 0F;
            this.subRepFoto.Name = "subRepFoto";
            this.subRepFoto.Report = null;
            this.subRepFoto.ReportName = "";
            this.subRepFoto.Top = 0.04529166F;
            this.subRepFoto.Width = 3F;
            // 
            // rptRetiroTicket
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
            this.PrintWidth = 2.989584F;
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private GrapeCity.ActiveReports.SectionReportModel.GroupHeader groupHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.GroupFooter groupFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox2;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox4;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox6;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox8;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox9;
        private GrapeCity.ActiveReports.SectionReportModel.Label label9;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox7;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox3;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox5;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox10;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox11;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox12;
        private GrapeCity.ActiveReports.SectionReportModel.PageBreak pageBreak1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox13;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox14;
        private GrapeCity.ActiveReports.SectionReportModel.Line line1;
        private GrapeCity.ActiveReports.SectionReportModel.PageBreak pageBreak2;
        private GrapeCity.ActiveReports.SectionReportModel.SubReport subRepFoto;
    }
}
