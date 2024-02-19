using ConexionBD;
using ConexionBD.Models;
using ERP.Common.Reports;
using ERP.Common.Seguridad;
using ERP.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.PuntoVenta
{
    public class PuntoVentaAcciones
    {
        private static void CancelarTicket(int ventaId, PuntoVentaContext puntoVentaContext)
        {
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();
                doc_ventas venta = oContext.doc_ventas
                    .Where(w=> w.VentaId == ventaId).FirstOrDefault();

                if (!venta.Activo)
                {
                    MessageBox.Show("NO ES POSIBLE VOLVER A CANCELAR EL TICKET", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                

                frmCancelarTicket oFrm = new frmCancelarTicket();
                oFrm.ventaId = ventaId;
                oFrm.StartPosition = FormStartPosition.CenterParent;
                oFrm.puntoVentaContext = puntoVentaContext;
                oFrm.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static void CancelarTicketSolicitud(int ventaId, PuntoVentaContext puntoVentaContext)
        {
            ERPProdEntities oContext = new ERPProdEntities();

            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if (entity.ReqClaveSupCancelaTicketPV ?? false)
            {
                frmAdminPass oForm = new frmAdminPass();
                oForm.WindowState = FormWindowState.Normal;
                oForm.StartPosition = FormStartPosition.CenterScreen;

                oForm.ShowDialog();

                if (oForm.DialogResult == DialogResult.OK)
                {
                    CancelarTicket(ventaId,puntoVentaContext);
                }
            }
            else
            {
                CancelarTicket(ventaId,puntoVentaContext);
            }
        }

        public static void ReimprimirTicket(int ventaId, PuntoVentaContext puntoVentaContext)
        {
            rptVentaTicket oTicket = new rptVentaTicket();
            rptVentaTicket_CartaM oTicketMediaC = new rptVentaTicket_CartaM();
            ReportViewer oViewer = new ReportViewer();
            ERPProdEntities oContext = new ERPProdEntities(true);
            

            if (ventaId > 0)
            {
               

                if (ventaId >0)
                {
                    doc_ventas venta = oContext.doc_ventas.Where(w => w.VentaId == ventaId).FirstOrDefault();
                    if (venta != null)
                    {
                        if (venta.Activo == false)
                        {
                            MessageBox.Show("El ticket esta cancelado", "ERROR");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El ticket no existe", "ERROR");
                        return;
                    }
                }
                doc_reimpresion_ticket entityReimpresion = new doc_reimpresion_ticket();
                entityReimpresion.ReimpresionTicketId = oContext.doc_reimpresion_ticket.Count() > 0 ?
                    oContext.doc_reimpresion_ticket.Max(m => m.ReimpresionTicketId) + 1 : 1;
                entityReimpresion.CajaId = puntoVentaContext.cajaId;
                entityReimpresion.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                entityReimpresion.CreadoPor = puntoVentaContext.usuarioId;
                entityReimpresion.FechaReimpresion = entityReimpresion.CreadoEl;
                entityReimpresion.VentaId = ventaId;

                oContext.doc_reimpresion_ticket.Add(entityReimpresion);
                oContext.SaveChanges();


                // int sucursalId = this.puntoVentaContext.sucursalId;
                cat_configuracion entityConf = oContext.cat_configuracion
                    .FirstOrDefault();

                if (entityConf.ImprimirTicketMediaCarta == true)
                {
                    oTicketMediaC.DataSource = oContext.p_rpt_VentaTicket(ventaId).ToList();
                    oTicketMediaC.esReimpreso = true;

                    oViewer.ShowTicket(oTicketMediaC);
                }
                else
                {
                    oTicket.DataSource = oContext.p_rpt_VentaTicket(ventaId).ToList();
                    oTicket.esReimpreso = true;

                    oViewer.ShowTicket(oTicket);
                }

                
            }
        }
    }
}
