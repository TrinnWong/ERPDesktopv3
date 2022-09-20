using ConexionBD;
using ERP.Reports;
using ERPv1.rpt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPv1.rpt
{
    public partial class ReportViewer : Form
    {
        ERPProdEntities oContext;
        string printerName { get; set; }
        bool vistaPrevia { get; set; }
        public ReportViewer()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            printerName = entity.NombreImpresora;
            vistaPrevia = entity.vistaPreviaImpresion ?? false;
        }

        private void showTicket2()
        {
            try
            {
               

                if (!vistaPrevia)
                {
                   // this.Show();
                    this.viewer1.Document.Printer.PrinterName = printerName;
                    this.viewer1.Print(false, false, true);

                    Thread.Sleep(2000);


                  //  this.Close();
                }
                else
                {
                    
                    this.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message, "ERROR");
            }
           
        }

        public void setNUllPrint()
        {
            this.viewer1.Document.Printer.PrinterName = "";
            if (this.viewer1.Document.Printer.PrinterSettings != null)
            {
                this.viewer1.Document.Printer.PrinterSettings.PrinterName = "";
            }
        }
        public void ShowReport(rptMovimientoInventario oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Run();
            showTicket2();


        }
        public void ShowReport(rptMovimientoInventarioCancelacion oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Run();
            showTicket2();


        }

        public void ShowReport(rptTraspasoInventario oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Run();
            showTicket2();


        }


        public void ShowReport(rptEntradaCompra oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Run();
            showTicket2();
            //showTicket2();          


        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
