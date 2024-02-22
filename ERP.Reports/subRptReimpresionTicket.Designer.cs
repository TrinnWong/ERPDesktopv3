namespace ERP.Reports
{
    /// <summary>
    /// Summary description for subRptReimpresionTicket.
    /// </summary>
    partial class subRptReimpresionTicket
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(subRptReimpresionTicket));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.reportHeader1 = new GrapeCity.ActiveReports.SectionReportModel.ReportHeader();
            this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.reportFooter1 = new GrapeCity.ActiveReports.SectionReportModel.ReportFooter();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
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
            this.textBox2,
            this.textBox1,
            this.textBox3});
            this.detail.Height = 0.1770834F;
            this.detail.Name = "detail";
            // 
            // textBox2
            // 
            this.textBox2.DataField = "Folio";
            this.textBox2.Height = 0.179F;
            this.textBox2.Left = 0.141F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.textBox2.Text = "textBox1";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.5730001F;
            // 
            // textBox1
            // 
            this.textBox1.DataField = "FechaReimpresion";
            this.textBox1.Height = 0.179F;
            this.textBox1.Left = 0.714F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.textBox1.Text = "textBox1";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 1.147F;
            // 
            // textBox3
            // 
            this.textBox3.DataField = "ReimpresoPor";
            this.textBox3.Height = 0.179F;
            this.textBox3.Left = 1.861F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "font-size: 8.25pt; ddo-char-set: 0";
            this.textBox3.Text = "textBox1";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.7640003F;
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
            this.reportHeader1.Height = 0.4583333F;
            this.reportHeader1.Name = "reportHeader1";
            // 
            // label1
            // 
            this.label1.Height = 0.158F;
            this.label1.HyperLink = null;
            this.label1.Left = 0.141F;
            this.label1.Name = "label1";
            this.label1.Style = "font-size: 8.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label1.Text = "REIMPRESIÓN DE TICKETS";
            this.label1.Top = 0F;
            this.label1.Width = 2.484F;
            // 
            // label2
            // 
            this.label2.Height = 0.169F;
            this.label2.HyperLink = null;
            this.label2.Left = 0.141F;
            this.label2.Name = "label2";
            this.label2.Style = "font-size: 8.25pt; font-weight: bold; ddo-char-set: 0";
            this.label2.Text = "FOLIO";
            this.label2.Top = 0.27F;
            this.label2.Width = 0.573F;
            // 
            // label3
            // 
            this.label3.Height = 0.169F;
            this.label3.HyperLink = null;
            this.label3.Left = 0.714F;
            this.label3.Name = "label3";
            this.label3.Style = "font-size: 8.25pt; font-weight: bold; ddo-char-set: 0";
            this.label3.Text = "FECHA Y HORA";
            this.label3.Top = 0.27F;
            this.label3.Width = 1.147F;
            // 
            // label4
            // 
            this.label4.Height = 0.169F;
            this.label4.HyperLink = null;
            this.label4.Left = 1.861F;
            this.label4.Name = "label4";
            this.label4.Style = "font-size: 8.25pt; font-weight: bold; ddo-char-set: 0";
            this.label4.Text = "USUARIO";
            this.label4.Top = 0.27F;
            this.label4.Width = 0.7640004F;
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0F;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // subRptReimpresionTicket
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperName = "Custom paper";
            this.PageSettings.PaperWidth = 3F;
            this.PrintWidth = 2.828F;
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private GrapeCity.ActiveReports.SectionReportModel.ReportHeader reportHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.ReportFooter reportFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label3;
        private GrapeCity.ActiveReports.SectionReportModel.Label label4;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox2;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox3;
    }
}
