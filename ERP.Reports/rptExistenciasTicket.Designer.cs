﻿namespace ERP.Reports
{
    /// <summary>
    /// Summary description for rptExistenciasCarta.
    /// </summary>
    partial class rptExistenciasTicket
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rptExistenciasTicket));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.subRepFoto = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label12 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.uiFecha = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label14 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.gpLinea = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.groupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.gpFamilia = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.groupFooter2 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.gpSubfamilia = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.groupFooter3 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label1,
            this.label2,
            this.subRepFoto,
            this.label4,
            this.label12,
            this.uiFecha,
            this.label14,
            this.textBox5});
            this.pageHeader.Height = 1.632F;
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
            // 
            // label1
            // 
            this.label1.Height = 0.2F;
            this.label1.HyperLink = null;
            this.label1.Left = 0F;
            this.label1.Name = "label1";
            this.label1.Style = "font-size: 9.75pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label1.Text = "REPORTE DE EXISTENCIAS";
            this.label1.Top = 0.927F;
            this.label1.Width = 2.963F;
            // 
            // label2
            // 
            this.label2.DataField = "Sucursal";
            this.label2.Height = 0.2F;
            this.label2.HyperLink = null;
            this.label2.Left = 0F;
            this.label2.Name = "label2";
            this.label2.Style = "font-size: 9.75pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label2.Text = "t";
            this.label2.Top = 1.127F;
            this.label2.Width = 2.963F;
            // 
            // subRepFoto
            // 
            this.subRepFoto.CloseBorder = false;
            this.subRepFoto.Height = 0.7220001F;
            this.subRepFoto.Left = 0.141F;
            this.subRepFoto.Name = "subRepFoto";
            this.subRepFoto.Report = null;
            this.subRepFoto.ReportName = "";
            this.subRepFoto.Top = 0.08400001F;
            this.subRepFoto.Width = 1.875F;
            // 
            // label4
            // 
            this.label4.Height = 0.2F;
            this.label4.HyperLink = null;
            this.label4.Left = 2.463F;
            this.label4.Name = "label4";
            this.label4.Style = "font-size: 9.75pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label4.Text = "EXIS.";
            this.label4.Top = 1.327F;
            this.label4.Width = 0.5000005F;
            // 
            // label12
            // 
            this.label12.Height = 0.137F;
            this.label12.HyperLink = null;
            this.label12.Left = 0.141F;
            this.label12.Name = "label12";
            this.label12.Style = "font-size: 6.25pt; font-weight: bold; ddo-char-set: 0";
            this.label12.Text = "Fecha Reporte:";
            this.label12.Top = 1.327F;
            this.label12.Width = 0.984F;
            // 
            // uiFecha
            // 
            this.uiFecha.Height = 0.1369999F;
            this.uiFecha.Left = 1.125F;
            this.uiFecha.Name = "uiFecha";
            this.uiFecha.OutputFormat = resources.GetString("uiFecha.OutputFormat");
            this.uiFecha.Style = "font-size: 8.25pt; text-align: right; ddo-char-set: 0";
            this.uiFecha.Text = "textBox5";
            this.uiFecha.Top = 1.327F;
            this.uiFecha.Width = 0.687F;
            // 
            // label14
            // 
            this.label14.Height = 0.1370001F;
            this.label14.HyperLink = null;
            this.label14.Left = 0.141F;
            this.label14.Name = "label14";
            this.label14.Style = "font-size: 6.25pt; font-weight: bold; ddo-char-set: 0";
            this.label14.Text = "Fecha Existencias:";
            this.label14.Top = 1.495F;
            this.label14.Width = 0.984F;
            // 
            // textBox5
            // 
            this.textBox5.DataField = "FechaHasta";
            this.textBox5.Height = 0.1369999F;
            this.textBox5.Left = 1.125F;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "font-size: 8.25pt; text-align: right; ddo-char-set: 0";
            this.textBox5.Text = "textBox5";
            this.textBox5.Top = 1.495F;
            this.textBox5.Width = 0.687F;
            // 
            // detail
            // 
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label11,
            this.textBox4,
            this.label13});
            this.detail.Height = 0.2F;
            this.detail.Name = "detail";
            // 
            // label11
            // 
            this.label11.DataField = "Clave";
            this.label11.Height = 0.2F;
            this.label11.HyperLink = null;
            this.label11.Left = 0.07800001F;
            this.label11.Name = "label11";
            this.label11.Style = "font-size: 6.75pt; ddo-char-set: 0";
            this.label11.Text = "label5";
            this.label11.Top = 0F;
            this.label11.Width = 0.4480001F;
            // 
            // textBox4
            // 
            this.textBox4.DataField = "ExistenciaTeorica";
            this.textBox4.Height = 0.2F;
            this.textBox4.Left = 2.463F;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "font-size: 6.75pt; text-align: right; ddo-char-set: 0";
            this.textBox4.Text = "textBox1";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.4159999F;
            // 
            // label13
            // 
            this.label13.DataField = "DescripcionCorta";
            this.label13.Height = 0.2F;
            this.label13.HyperLink = null;
            this.label13.Left = 0.5F;
            this.label13.Name = "label13";
            this.label13.Style = "font-size: 6.75pt; ddo-char-set: 0";
            this.label13.Text = "label5";
            this.label13.Top = 0F;
            this.label13.Width = 1.875F;
            // 
            // pageFooter
            // 
            this.pageFooter.Name = "pageFooter";
            // 
            // gpLinea
            // 
            this.gpLinea.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label5,
            this.label3,
            this.textBox1,
            this.line1});
            this.gpLinea.DataField = "ClaveLinea";
            this.gpLinea.Height = 0.2F;
            this.gpLinea.Name = "gpLinea";
            this.gpLinea.Format += new System.EventHandler(this.groupHeader1_Format);
            // 
            // label5
            // 
            this.label5.DataField = "Linea";
            this.label5.Height = 0.2F;
            this.label5.HyperLink = null;
            this.label5.Left = 0.406F;
            this.label5.Name = "label5";
            this.label5.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; ddo-char-set: 0";
            this.label5.Text = "label5";
            this.label5.Top = 0F;
            this.label5.Width = 2.089F;
            // 
            // label3
            // 
            this.label3.Height = 0.148F;
            this.label3.HyperLink = null;
            this.label3.Left = 0.078F;
            this.label3.Name = "label3";
            this.label3.Style = "font-family: Microsoft Sans Serif; font-size: 6pt; font-weight: bold; text-align:" +
    " center; ddo-char-set: 0";
            this.label3.Text = "LÍNEA";
            this.label3.Top = 0F;
            this.label3.Width = 0.328F;
            // 
            // textBox1
            // 
            this.textBox1.DataField = "ExistenciaTeorica";
            this.textBox1.Height = 0.2F;
            this.textBox1.Left = 2.463F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; text-align: right; ddo-char" +
    "-set: 0";
            this.textBox1.SummaryGroup = "gpLinea";
            this.textBox1.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox1.Text = "textBox1";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.468F;
            // 
            // line1
            // 
            this.line1.Height = 0F;
            this.line1.Left = 0.406F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0.2F;
            this.line1.Width = 2.557F;
            this.line1.X1 = 0.406F;
            this.line1.X2 = 2.963F;
            this.line1.Y1 = 0.2F;
            this.line1.Y2 = 0.2F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // gpFamilia
            // 
            this.gpFamilia.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label7,
            this.label9,
            this.textBox2,
            this.line2});
            this.gpFamilia.DataField = "ClaveFamilia";
            this.gpFamilia.Height = 0.4270834F;
            this.gpFamilia.Name = "gpFamilia";
            // 
            // label7
            // 
            this.label7.DataField = "Familia";
            this.label7.Height = 0.2F;
            this.label7.HyperLink = null;
            this.label7.Left = 0.552F;
            this.label7.Name = "label7";
            this.label7.Style = "font-family: Microsoft Sans Serif; font-size: 6pt; ddo-char-set: 0";
            this.label7.Text = "label5";
            this.label7.Top = 0F;
            this.label7.Width = 1.943F;
            // 
            // label9
            // 
            this.label9.Height = 0.2F;
            this.label9.HyperLink = null;
            this.label9.Left = 0.07800001F;
            this.label9.Name = "label9";
            this.label9.Style = "font-family: Microsoft Sans Serif; font-size: 6pt; font-weight: bold; text-align:" +
    " center; ddo-char-set: 0";
            this.label9.Text = "FAMILIA";
            this.label9.Top = 0F;
            this.label9.Width = 0.474F;
            // 
            // textBox2
            // 
            this.textBox2.DataField = "ExistenciaTeorica";
            this.textBox2.Height = 0.2F;
            this.textBox2.Left = 2.463F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "font-family: Microsoft Sans Serif; font-size: 6pt; text-align: right; ddo-char-se" +
    "t: 0";
            this.textBox2.SummaryGroup = "gpFamilia";
            this.textBox2.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox2.Text = "textBox1";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.4679999F;
            // 
            // line2
            // 
            this.line2.Height = 0F;
            this.line2.Left = 0.552F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0.2F;
            this.line2.Width = 2.411F;
            this.line2.X1 = 0.552F;
            this.line2.X2 = 2.963F;
            this.line2.Y1 = 0.2F;
            this.line2.Y2 = 0.2F;
            // 
            // groupFooter2
            // 
            this.groupFooter2.Height = 0.01041667F;
            this.groupFooter2.Name = "groupFooter2";
            // 
            // gpSubfamilia
            // 
            this.gpSubfamilia.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label6,
            this.label8,
            this.textBox3,
            this.label10,
            this.line3});
            this.gpSubfamilia.DataField = "ClaveSubFamilia";
            this.gpSubfamilia.Height = 0.4375F;
            this.gpSubfamilia.Name = "gpSubfamilia";
            this.gpSubfamilia.Format += new System.EventHandler(this.gpSubfamilia_Format);
            // 
            // label6
            // 
            this.label6.DataField = "Subfamilia";
            this.label6.Height = 0.2F;
            this.label6.HyperLink = null;
            this.label6.Left = 0.552F;
            this.label6.Name = "label6";
            this.label6.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; ddo-char-set: 0";
            this.label6.Text = "label5";
            this.label6.Top = 0F;
            this.label6.Width = 1.943F;
            // 
            // label8
            // 
            this.label8.Height = 0.2F;
            this.label8.HyperLink = null;
            this.label8.Left = 0.07799995F;
            this.label8.Name = "label8";
            this.label8.Style = "font-family: Microsoft Sans Serif; font-size: 6pt; font-weight: bold; text-align:" +
    " center; ddo-char-set: 0";
            this.label8.Text = "SUBFAM.";
            this.label8.Top = 0F;
            this.label8.Width = 0.4740001F;
            // 
            // textBox3
            // 
            this.textBox3.DataField = "ExistenciaTeorica";
            this.textBox3.Height = 0.2F;
            this.textBox3.Left = 2.463F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "font-family: Microsoft Sans Serif; font-size: 6.75pt; text-align: right; ddo-char" +
    "-set: 0";
            this.textBox3.SummaryGroup = "gpSubfamilia";
            this.textBox3.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox3.Text = "textBox1";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.4679999F;
            // 
            // label10
            // 
            this.label10.Height = 0.127F;
            this.label10.HyperLink = null;
            this.label10.Left = 0.07800001F;
            this.label10.Name = "label10";
            this.label10.Style = "font-size: 6.75pt; font-weight: bold; text-align: left; ddo-char-set: 0";
            this.label10.Text = "PRODUCTO";
            this.label10.Top = 0.31F;
            this.label10.Width = 0.901F;
            // 
            // line3
            // 
            this.line3.Height = 0F;
            this.line3.Left = 0.552F;
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0.2F;
            this.line3.Width = 2.411F;
            this.line3.X1 = 0.552F;
            this.line3.X2 = 2.963F;
            this.line3.Y1 = 0.2F;
            this.line3.Y2 = 0.2F;
            // 
            // groupFooter3
            // 
            this.groupFooter3.Height = 0F;
            this.groupFooter3.Name = "groupFooter3";
            // 
            // rptExistenciasTicket
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
            this.Sections.Add(this.gpLinea);
            this.Sections.Add(this.gpFamilia);
            this.Sections.Add(this.gpSubfamilia);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter3);
            this.Sections.Add(this.groupFooter2);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private GrapeCity.ActiveReports.SectionReportModel.Label label1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label2;
        private GrapeCity.ActiveReports.SectionReportModel.SubReport subRepFoto;
        private GrapeCity.ActiveReports.SectionReportModel.Label label4;
        private GrapeCity.ActiveReports.SectionReportModel.GroupHeader gpLinea;
        private GrapeCity.ActiveReports.SectionReportModel.Label label5;
        private GrapeCity.ActiveReports.SectionReportModel.GroupFooter groupFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.GroupHeader gpFamilia;
        private GrapeCity.ActiveReports.SectionReportModel.GroupFooter groupFooter2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label3;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label7;
        private GrapeCity.ActiveReports.SectionReportModel.Label label9;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox2;
        private GrapeCity.ActiveReports.SectionReportModel.GroupHeader gpSubfamilia;
        private GrapeCity.ActiveReports.SectionReportModel.Label label6;
        private GrapeCity.ActiveReports.SectionReportModel.Label label8;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox3;
        private GrapeCity.ActiveReports.SectionReportModel.GroupFooter groupFooter3;
        private GrapeCity.ActiveReports.SectionReportModel.Label label11;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox4;
        private GrapeCity.ActiveReports.SectionReportModel.Label label10;
        private GrapeCity.ActiveReports.SectionReportModel.Line line1;
        private GrapeCity.ActiveReports.SectionReportModel.Line line2;
        private GrapeCity.ActiveReports.SectionReportModel.Line line3;
        private GrapeCity.ActiveReports.SectionReportModel.Label label12;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox uiFecha;
        private GrapeCity.ActiveReports.SectionReportModel.Label label13;
        private GrapeCity.ActiveReports.SectionReportModel.Label label14;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox5;
    }
}
