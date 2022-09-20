using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common
{
  public  class ActiveReportExportTo
    {
        public Stream ToPDF(GrapeCity.ActiveReports.SectionReport report)
        {

            GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport pdfExport = new GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport();
            GrapeCity.ActiveReports.Export.Document.DocumentRenderingExtension documentExport = new GrapeCity.ActiveReports.Export.Document.DocumentRenderingExtension();
                                 
            System.IO.Stream stram = new System.IO.MemoryStream();
            System.IO.MemoryStream memStream = new MemoryStream();


            report.Run();

            pdfExport.Export(report.Document, stram);



            stram.Position = 0;
            return stram;
            // return CopyStream(stram);

        }


        public Stream ToPDF(GrapeCity.ActiveReports.SectionReport report, decimal zoom)
        {

            GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport pdfExport = new GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport();
            GrapeCity.ActiveReports.Export.Document.DocumentRenderingExtension documentExport = new GrapeCity.ActiveReports.Export.Document.DocumentRenderingExtension();




            System.IO.Stream stram = new System.IO.MemoryStream();
            System.IO.MemoryStream memStream = new MemoryStream();




            report.Run();

            pdfExport.Export(report.Document, stram);



            stram.Position = 0;
            return stram;
            // return CopyStream(stram);

        }

        //public Stream ToExcel(GrapeCity.ActiveReports.SectionReport report)
        //{

        //    GrapeCity.ActiveReports.Export.Excel.Section.XlsExport pdfExport = new GrapeCity.ActiveReports.Export.Excel.Section.XlsExport();
        //    GrapeCity.ActiveReports.Export.Document.DocumentRenderingExtension documentExport = new GrapeCity.ActiveReports.Export.Document.DocumentRenderingExtension();



        //    System.IO.Stream stram = new System.IO.MemoryStream();
        //    System.IO.MemoryStream memStream = new MemoryStream();


        //    report.Run();

        //    pdfExport.Export(report.Document, stram);



        //    stram.Position = 0;
        //    return stram;
        //    // return CopyStream(stram);

        //}

        //public Stream ToWord(GrapeCity.ActiveReports.SectionReport report)
        //{

        //    GrapeCity.ActiveReports.Export.Word.Section.RtfExport pdfExport = new GrapeCity.ActiveReports.Export.Word.Section.RtfExport();
        //    GrapeCity.ActiveReports.Export.Document.DocumentRenderingExtension documentExport = new GrapeCity.ActiveReports.Export.Document.DocumentRenderingExtension();



        //    System.IO.Stream stram = new System.IO.MemoryStream();
        //    System.IO.MemoryStream memStream = new MemoryStream();


        //    report.Run();

        //    pdfExport.Export(report.Document, stram);



        //    stram.Position = 0;
        //    return stram;
        //    // return CopyStream(stram);

        //}


        public static MemoryStream CopyStream(Stream input)
        {
            MemoryStream output = new MemoryStream();
            byte[] buffer = new byte[16 * 1024];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
            output.Position = 0;
            return output;
        }

        //public static MemoryStream CopyStream(GrapeCity.ActiveReports.SectionReport report)
        //{
        //    MemoryStream output = new MemoryStream();
        //    byte[] buffer = new byte[16 * 1024];
        //    int read;
        //    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
        //    {
        //        output.Write(buffer, 0, read);
        //    }

        //    return output;
        //}

        public Stream ToPDFEmail(GrapeCity.ActiveReports.SectionReport report)
        {

            GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport pdfExport = new GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport();
            GrapeCity.ActiveReports.Export.Document.DocumentRenderingExtension documentExport = new GrapeCity.ActiveReports.Export.Document.DocumentRenderingExtension();

            System.IO.Stream stram = new System.IO.MemoryStream();
            report.Run();



            pdfExport.Export(report.Document, stram);
            stram.Position = 0;
            return stram;
        }
    }
}
