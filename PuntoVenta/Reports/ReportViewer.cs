using ConexionBD;
using ERP.Reports;
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

namespace PuntoVenta.Reports
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
                    this.viewer1.Document.Printer.PrinterName = "";
                    if (this.viewer1.Document.Printer.PrinterSettings != null)
                    {
                        this.viewer1.Document.Printer.PrinterSettings.PrinterName = "";
                    }
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
        public void ShowTicket(rptVentaTicket oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            showTicket2();


        }
        

        public void ShowTicket(rptVentaTicket_CartaM oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Run();
            showTicket2();


        }
        public void ShowTicket(rptCorteCajaPrevioV2 oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Run();
            showTicket2();


        }

        public void ShowTicket(rptDevolucionTicket oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Run();
            showTicket2();


        }

        public void ShowTicket(rptGastoTicket oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;

            oReport.Run();
            showTicket2();
        }

        public void ShowTicket(rptRetiroTicket oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;

            oReport.Run();
            showTicket2();
        }

        public void ShowTicket(rptCorteCaja oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;

            oReport.Run();
            showTicket2();
        }


    }
}
