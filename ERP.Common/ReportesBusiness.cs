using ConexionBD;
using ERP.Common.Reports;
using ERP.Reports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common
{
    public class ReportesBusiness
    {
        ERPProdEntities oContext;
        public ReportesBusiness()
        {
            oContext = new ERPProdEntities();
        }

        public string enviarReporteCorreo(int sucursalId,string asunto, List<System.Net.Mail.Attachment> attachmentList)
        {
            string error = "";

            try
            {
                cat_sucursales entity = oContext.cat_sucursales.Where(w => w.Clave == sucursalId).FirstOrDefault();
                asunto = entity.NombreSucursal + "-"+asunto;

                if ((entity.ServidorMailSMTP == null ? "" : entity.ServidorMailSMTP) == "")
                {
                    error = "No fue posible enviar el corte de caja por correo. Falta configurar el servidor de correo para la sucursal";
                }
                else
                {
                    Mail oMail = new Mail(entity.ServidorMailSMTP, entity.ServidorMailFrom, int.Parse(entity.ServidorMailPort.ToString()), entity.ServidorMailPassword);

                    //Obtener los usuarios de tipo supervisor general
                    //List<cat_usuarios> usuarios = oContext.cat_usuarios.Where(w=> w.EsSupervisor == true && w.Email != "" && w.Email != null).ToList();
                    cat_configuracion entityConf = oContext.cat_configuracion.FirstOrDefault();

                    string emailEnvio = "";

                    if (entityConf != null)
                    {
                        emailEnvio = entityConf.SuperEmail1 != null ? entityConf.SuperEmail1 + ";" : "";
                        emailEnvio = emailEnvio + (entityConf.SuperEmail2 != null ? entityConf.SuperEmail2 + ";" : "");
                        emailEnvio = emailEnvio + (entityConf.SuperEmail3 != null ? entityConf.SuperEmail3 + ";" : "");
                        emailEnvio = emailEnvio + (entityConf.SuperEmail4 != null ? entityConf.SuperEmail4 + ";" : "");

                        if (emailEnvio.Length > 0)
                        {
                            oMail.Send(asunto, emailEnvio, asunto, "", attachmentList);
                        }
                        else
                        {
                            error = "No hay usuarios de tipo supervisrp con un email registrado. No fue posible enviar el corte de caja por correo";
                        }
                    }
                    else
                    {
                        error = "No existe registro de configuración";
                    }

                }
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }

        public string enviarReporteCorreoEnc(int sucursalId, rptNotasVentaResumido oReport)
        {
            string error = "";

            try
            {
                List<System.Net.Mail.Attachment> attachmentList = new List<System.Net.Mail.Attachment>();
                ActiveReportExportTo exportTool = new ActiveReportExportTo();
                Stream pdfStream = new System.IO.MemoryStream();
                pdfStream = exportTool.ToPDF(oReport);

                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(pdfStream, "Notas_Venta_Resumido.pdf", "application/pdf");
                attachmentList.Add(attachment);

                error = enviarReporteCorreo(sucursalId,"Reporte Notas de Venta Resumido", attachmentList);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }


        public string enviarReporteCorreoEnc(int sucursalId, rptNotasVentaResumido_Mesa oReport)
        {
            string error = "";

            try
            {
                List<System.Net.Mail.Attachment> attachmentList = new List<System.Net.Mail.Attachment>();
                ActiveReportExportTo exportTool = new ActiveReportExportTo();
                Stream pdfStream = new System.IO.MemoryStream();
                pdfStream = exportTool.ToPDF(oReport);

                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(pdfStream, "Notas_Venta_Resumido.pdf", "application/pdf");
                attachmentList.Add(attachment);

                error = enviarReporteCorreo(sucursalId, "Reporte Notas de Venta Resumido", attachmentList);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }

        public string enviarReporteCorreoEnc(int sucursalId, rptNotasVentaDetallado oReport)
        {
            string error = "";

            try
            {
                List<System.Net.Mail.Attachment> attachmentList = new List<System.Net.Mail.Attachment>();
                ActiveReportExportTo exportTool = new ActiveReportExportTo();
                Stream pdfStream = new System.IO.MemoryStream();
                pdfStream = exportTool.ToPDF(oReport);

                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(pdfStream, "Notas_Venta_Detallado.pdf", "application/pdf");
                attachmentList.Add(attachment);

                error = enviarReporteCorreo(sucursalId,"Reporte Notas de Venta Detallado", attachmentList);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }
        
        public string enviarReporteCorreoEnc(int sucursalId, rptVentasVendedor oReport)
        {
            string error = "";

            try
            {
                List<System.Net.Mail.Attachment> attachmentList = new List<System.Net.Mail.Attachment>();
                ActiveReportExportTo exportTool = new ActiveReportExportTo();
                Stream pdfStream = new System.IO.MemoryStream();
                pdfStream = exportTool.ToPDF(oReport);

                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(pdfStream, "Ventas_Vendedor.pdf", "application/pdf");
                attachmentList.Add(attachment);

                error = enviarReporteCorreo(sucursalId,"Ventas Vendedor", attachmentList);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }
        
        public string enviarReporteCorreoEnc(int sucursalId, rptProductosVendidos oReport)
        {
            string error = "";

            try
            {
                List<System.Net.Mail.Attachment> attachmentList = new List<System.Net.Mail.Attachment>();
                ActiveReportExportTo exportTool = new ActiveReportExportTo();
                Stream pdfStream = new System.IO.MemoryStream();
                pdfStream = exportTool.ToPDF(oReport);

                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(pdfStream, "productosVendidos.pdf", "application/pdf");
                attachmentList.Add(attachment);

                error = enviarReporteCorreo(sucursalId,"Reporte de Productos Vendidos", attachmentList);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }
        
        public string enviarReporteCorreoEnc(int sucursalId, rptCorteCajaResumido oReport)
        {
            string error = "";

            try
            {
                List<System.Net.Mail.Attachment> attachmentList = new List<System.Net.Mail.Attachment>();
                ActiveReportExportTo exportTool = new ActiveReportExportTo();
                Stream pdfStream = new System.IO.MemoryStream();
                pdfStream = exportTool.ToPDF(oReport);

                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(pdfStream, "Corte_de_Caja_Resumido.pdf", "application/pdf");
                attachmentList.Add(attachment);

                error = enviarReporteCorreo(sucursalId,"Reporte de Corte de Caja Resumido", attachmentList);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }
        
        public string enviarReporteCorreoEnc(int sucursalId, rptCorteCajaDetallado oReport)
        {
            string error = "";

            try
            {
                List<System.Net.Mail.Attachment> attachmentList = new List<System.Net.Mail.Attachment>();
                ActiveReportExportTo exportTool = new ActiveReportExportTo();
                Stream pdfStream = new System.IO.MemoryStream();
                pdfStream = exportTool.ToPDF(oReport);

                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(pdfStream, "Corte_de_Caja_Detallado.pdf", "application/pdf");
                attachmentList.Add(attachment);

                error = enviarReporteCorreo(sucursalId,"Corte_Caja_Detallado", attachmentList);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }
        
        public string enviarReporteCorreoEnc(int sucursalId, rptApartados oReport)
        {
            string error = "";

            try
            {
                List<System.Net.Mail.Attachment> attachmentList = new List<System.Net.Mail.Attachment>();
                ActiveReportExportTo exportTool = new ActiveReportExportTo();
                Stream pdfStream = new System.IO.MemoryStream();
                pdfStream = exportTool.ToPDF(oReport);

                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(pdfStream, "Apartados.pdf", "application/pdf");
                attachmentList.Add(attachment);

                error = enviarReporteCorreo(sucursalId,"Reporte de Apartados", attachmentList);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }
        
        public string enviarReporteCorreoEnc(int sucursalId, rptClientesApartados oReport)
        {
            string error = "";

            try
            {
                List<System.Net.Mail.Attachment> attachmentList = new List<System.Net.Mail.Attachment>();
                ActiveReportExportTo exportTool = new ActiveReportExportTo();
                Stream pdfStream = new System.IO.MemoryStream();
                pdfStream = exportTool.ToPDF(oReport);

                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(pdfStream, "Clientes_Apartados.pdf", "application/pdf");
                attachmentList.Add(attachment);

                error = enviarReporteCorreo(sucursalId,"Reporte de Clientes-Apartados",attachmentList);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }
        
        public string enviarReporteCorreoEnc(int sucursalId, subRptProductoExistencias oReport)
        {
            string error = "";

            try
            {
                List<System.Net.Mail.Attachment> attachmentList = new List<System.Net.Mail.Attachment>();
                ActiveReportExportTo exportTool = new ActiveReportExportTo();
                Stream pdfStream = new System.IO.MemoryStream();
                pdfStream = exportTool.ToPDF(oReport);

                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(pdfStream, "Prductos_Existencias.pdf", "application/pdf");
                attachmentList.Add(attachment);

                error = enviarReporteCorreo(sucursalId,"Reporte de Productos-Existencias" ,attachmentList);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }

        public string enviarReporteCorreoEnc(int sucursalId, rptExistenciasTicket oReport)
        {
            string error = "";

            try
            {
                List<System.Net.Mail.Attachment> attachmentList = new List<System.Net.Mail.Attachment>();
                ActiveReportExportTo exportTool = new ActiveReportExportTo();
                Stream pdfStream = new System.IO.MemoryStream();
                pdfStream = exportTool.ToPDF(oReport);

                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(pdfStream, "Existencias.pdf", "application/pdf");
                attachmentList.Add(attachment);

                error = enviarReporteCorreo(sucursalId,"Reporte de Existencias", attachmentList);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }


        public static void imprimirMovInventarioCancelacion(int MovimientoInventarioId,int ProductoCompraId)
        {
            ERPProdEntities oContext = new ERPProdEntities();
            rptMovimientoInventarioCancelacion oTicket = new rptMovimientoInventarioCancelacion();
            ReportViewer oViewer = new ReportViewer();
            oContext = new ERPProdEntities();
            var ds = oContext.p_rpt_movimiento_cancela_inv(MovimientoInventarioId, ProductoCompraId).ToList();
            oTicket.DataSource = ds;
            oTicket.autorizadoPor = ds.FirstOrDefault().AutorizadoPor;
            oViewer.ShowPreview(oTicket);
        }
    }
}
