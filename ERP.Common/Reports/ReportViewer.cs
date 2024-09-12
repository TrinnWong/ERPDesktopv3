using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Reports;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Reports
{
    public partial class ReportViewer : Form
    {
        ERPProdEntities oContext;
        string printerName { get; set; }
        bool vistaPrevia { get; set; }
        public short copias { get; set; }
        ImpresorasBusiness oImpresora;

        public ReportViewer()
        {
            InitializeComponent();

            oContext = new ERPProdEntities();
            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();
            PrinterSettings settings = new PrinterSettings();
            printerName = settings.PrinterName;
            vistaPrevia = entity.vistaPreviaImpresion ?? false;
            copias = 1;
               
            if (this.viewer1.Document.Printer.PrinterSettings != null)
            {
                this.viewer1.Document.Printer.PrinterSettings.PrinterName = printerName;
            }
        }

        public ReportViewer(int cajaId)
        {
            if(cajaId == 0)
            {

                InitializeComponent();

                PrinterSettings settings = new PrinterSettings();
                printerName = settings.PrinterName;
                if (this.viewer1.Document.Printer.PrinterSettings != null)
                {
                    this.viewer1.Document.Printer.PrinterSettings.PrinterName = printerName;
                }
            }
            else
            {
                InitializeComponent();

                oContext = new ERPProdEntities();
                cat_configuracion entity = ERP.Business.DataMemory.DataBucket.GetCatConfiguracion(false).FirstOrDefault();
                cat_cajas_impresora entityImpresora = ERP.Business.DataMemory.DataBucket.GetCajasImpresoras(false)
                    .Where(w => w.CajaId == cajaId).FirstOrDefault();

                printerName = entityImpresora.cat_impresoras.NombreRed;
                vistaPrevia = entity.vistaPreviaImpresion ?? false;
                copias = 1;

                if (this.viewer1.Document.Printer.PrinterSettings != null)
                {
                    this.viewer1.Document.Printer.PrinterSettings.PrinterName = printerName;
                }
            }
            
        }

        public ReportViewer(int sucursalId,int cajaId,bool comanda)
        {
            InitializeComponent();

            ImpresorasBusiness oImpresora = new ImpresorasBusiness();
            cat_impresoras entityImpresora;

            if (comanda)
            {
                entityImpresora = oImpresora.ObtenerComandaImpresora(sucursalId);
            }
            else
            {
                entityImpresora = oImpresora.ObtenerCajaImpresora(cajaId);
            }
            

            oContext = new ERPProdEntities();
            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            printerName = entityImpresora.NombreRed;
            vistaPrevia = entity.vistaPreviaImpresion ?? false;
            copias = 1;

            if (this.viewer1.Document.Printer.PrinterSettings != null)
            {
                this.viewer1.Document.Printer.PrinterSettings.PrinterName = printerName;
            }
        }

        public ReportViewer(PuntoVentaContext puntoVentaContext, bool comanda)
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            cat_configuracion entityConfig = oContext.cat_configuracion.FirstOrDefault();
            oImpresora = new ImpresorasBusiness();

            cat_impresoras entity=null;
            if (!comanda)
            {
                if(puntoVentaContext.nombreImpresoraCaja.Length == 0)
                {
                    entity = oImpresora.ObtenerCajaImpresora(puntoVentaContext.cajaId);
                    printerName = entity.NombreRed;

                }
                else
                {
                    printerName = puntoVentaContext.nombreImpresoraCaja;
                }
               
            }
            else
            {
                if(puntoVentaContext.nombreImpresoraComanda.Length == 0)
                {
                    entity = oImpresora.ObtenerComandaImpresora(puntoVentaContext.sucursalId);
                    printerName = entity.NombreRed;
                }
                else
                {
                    printerName = puntoVentaContext.nombreImpresoraComanda;
                }
                    
            }


            vistaPrevia = entityConfig.vistaPreviaImpresion ?? false;
            copias = 1;



            if (this.viewer1.Document.Printer.PrinterSettings != null)
            {
                this.viewer1.Document.Printer.PrinterSettings.PrinterName = printerName;
            }
        }
        public void setNUllPrint()
        {
           // this.viewer1.Document.Printer = new GrapeCity.ActiveReports.Extensibility.Printing.Printer();
            this.viewer1.Document.Printer.PrinterName = "";
            if (this.viewer1.Document.Printer.PrinterSettings != null)
            {
                
                this.viewer1.Document.Printer.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            }
        }
        private void showTicket2()
        {
            try
            {
                if (!vistaPrevia)
                {
                    if(printerName == "")
                    {
                        XtraMessageBox.Show("No hay una impresora seleccionada","ERROR",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    //for (int i = 0; i < copias; i++)
                    //{
                        this.viewer1.Document.Printer.PrinterName = printerName;
                    if(copias > 0)
                    {
                        this.viewer1.Document.Printer.PrinterSettings.Copies = copias;
                    }
                   
                        //this.viewer1.Document.Printer.PrinterSettings.Copies = copias;
                        this.viewer1.Print(false, false, false);
                   // }
                   // this.Show();
                   

                   // Thread.Sleep(1000);


                  //  this.Close();
                }
                else
                {
                    //this.viewer1.Document.Printer.PrinterName = "";
                    //if (this.viewer1.Document.Printer.PrinterSettings != null)
                    //{
                    //    this.viewer1.Document.Printer.PrinterSettings.PrinterName = "";
                    //}
                    this.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message, "ERROR");
            }
           
        }

        

        public void ShowTicket(ERP.Reports.rptPedido oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }

        public void ShowTicket(ERP.Reports.rptMovimientoInventario oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }

        public void ShowTicket(ERP.Reports.rptMovimientoInventarioCancelacion oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }

        public void ShowTicket(ERP.Reports.rptProductoSobranteDia oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }

        public void ShowTicket(ERP.Reports.rptPedidoDevolucion oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }


        public void ShowTicket(ERP.Reports.rptVentaTicket55MM oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }


        public void ShowTicket(ERP.Reports.TacosAna.rptInventarioReal oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }

        public void ShowTicket(rptDevolucionTicket oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }

        public void ShowTicket(rptPedidoPagoTicket oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }
        public void ShowTicket(rptVentaTicket_CartaM oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }

        public void ShowTicket(rptGastoTicket oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }


        public void ShowTicket(rptRetiroTicket oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }
        public void ShowTicket(rptCorteCajaPrevioV2 oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;

            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }
        public void ShowTicket(rptExistenciasCarta oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }

        public void ShowTicket(rptProductoImportacion oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }
        
            public void ShowTicket(rptCorteCajaCajero oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }
        public void ShowTicket(rptCorteCaja oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }

        public void ShowTicket(rptExistenciasTicket oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }
        public void ShowTicket(rptApartadoTicket oReport)
        {
          setNUllPrint();
           


            for (int i = 0; i < copias; i++)
            {
                this.viewer1.Document = oReport.Document;
                oReport.Document.Printer.PrinterName = "";
                oReport.Run();
                showTicket2();
            }
            
        }

        public void ShowTicket(rptExistenciasAgrupado oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }

        }
        

       
        public void ShowTicket(rptVentaTicket oReport)
        {
            try
            {


                setNUllPrint();

                oReport.Document.Printer.PrinterName = "";
                oReport.Document.Printer.PrinterSettings.Copies = copias;

                this.viewer1.Document = oReport.Document;
                oReport.Document.Printer.PrinterName = "";
                oReport.Document.PrintOptions.PrintPageBorder = false;
                oReport.PageSettings.PaperHeight -= 1;

                oReport.Run();
                showTicket2();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.StackTrace, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            
          
        }

        public void ShowTicket(ERP.Reports.TacosAna.rptVentaTicket oReport)
        {
            try
            {


                setNUllPrint();

                oReport.Document.Printer.PrinterName = "";

                this.viewer1.Document = oReport.Document;
                oReport.Document.Printer.PrinterName = "";
                oReport.Run();
                showTicket2();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.StackTrace, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }




        public void ShowTicket(subRptProductoExistencias oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;


            //if (this.viewer1.Document.Printer.PrinterSettings != null)
            //{
            //    this.viewer1.Document.Printer.PrinterName = printerName;
            //    this.viewer1.Document.Printer.PrinterSettings.PrinterName = printerName;
            //}
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            showTicket2();
        }
        

        public void ShowPreview(rptExistenciasValuoCarta oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;

            oReport.Run();


            this.Show();


        }
        public void ShowPreview(rptEntradaCompra_Carta oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();


            this.Show();


        }
        public void ShowPreview(rptEntradaCompra oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();
            for (int i = 0; i < copias; i++)
            {
                showTicket2();
            }



        }
        public void ShowPreview(rptMovimientoInventarioCancelacion oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;

            oReport.Run();


            this.Show();


        }
        public void ShowPreview(rptNotasVentaResumido_Mesa oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;

            oReport.Run();


            this.Show();


        }
        public void ShowPreview(rptClientesApartados oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;

            oReport.Run();


            this.Show();


        }
        public void ShowPreview(rptApartados oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;

            oReport.Run();


            this.Show();


        }

        public void ShowPreview(rptExistenciasCarta oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;

            oReport.Run();


            this.Show();


        }

        public void ShowPreview(rptProductosVendidos oReport)
        {
            setNUllPrint();

            this.viewer1.Document = oReport.Document;

            oReport.Run();


            this.Show();


        }

        public void ShowPreview(rptVentasVendedor oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;

            oReport.Run();


            this.Show();


        }

        public void ShowPreview(rptCorteCajaDetallado oReport)
        {
            setNUllPrint();
         
        
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();


            this.Show();


        }

        public void ShowPreview(rptCorteCajaResumido oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;
            oReport.Document.Printer.PrinterName = "";
            oReport.Run();


            this.Show();


        }

        public void ShowPreview(rptNotasVentaDetallado oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;

            oReport.Run();


            this.Show();


        }

        public void ShowPreview(rptNotasVentaResumido oReport)
        {
            setNUllPrint();
            this.viewer1.Document = oReport.Document;

            oReport.Run();


            this.Show();


        }

    }
}
