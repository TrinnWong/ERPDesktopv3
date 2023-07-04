using ConexionBD;
using ConexionBD.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TacosAna.Desktop
{
    public partial class frmBuscarTicket : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmBuscarTicket _instance;
        public bool esReimpresion = false;
        public static frmBuscarTicket GetInstance()
        {
            if (_instance == null) _instance = new frmBuscarTicket();
            else _instance.BringToFront();
            return _instance;
        }

        public frmBuscarTicket()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void frmReimprimirTicket_Load(object sender, EventArgs e)
        {
            uiFechaIni.DateTime = DateTime.Now;
            uiFechaFin.DateTime = DateTime.Now;

            HabilitarDeshabilitar();
            buscar();

            
        }

        private void HabilitarDeshabilitar()
        {
            if (uiBuscarFolio.Checked)
            {
                gpFolio.Enabled = true;
                gpFechas.Enabled = false;
            }
            else {
                gpFechas.Enabled = true;
                gpFolio.Enabled = false;
                uiFolio.Text = "";
            }
        }

        private void uiBuscarFechas_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarDeshabilitar();
        }

        private void buscar()
        {
            DateTime fechaIni = uiFechaIni.DateTime.Date.AddDays(-1);
            DateTime fechaFin = uiFechaFin.DateTime.Date;
            string folio = uiFolio.Text;

            uiTicket.DataSource = oContext.doc_ventas
                .Where(
                    w => 
                    w.SucursalId == puntoVentaContext.sucursalId &&
                    (
                        (
                            w.Folio.ToString() == folio && uiBuscarFolio.Checked &&
                            DbFunctions.TruncateTime(w.Fecha) >= DbFunctions.TruncateTime(fechaIni) && DbFunctions.TruncateTime(w.Fecha) <= DbFunctions.TruncateTime(fechaFin)
                        )
                        ||
                        (
                       DbFunctions.TruncateTime( w.Fecha) >= DbFunctions.TruncateTime(fechaIni) && DbFunctions.TruncateTime(w.Fecha) <= DbFunctions.TruncateTime(fechaFin )
                        && uiBuscarFechas.Checked)
                    )
                ).Select(
                    s => new
                    {
                        folio = s.Folio,
                        fecha = s.Fecha,
                        descuento = s.TotalDescuento,
                        subtotal = s.SubTotal,
                        impuestos = s.Impuestos,
                        total = s.TotalVenta,
                        Estatus = s.Activo ==true ? "Activo" : "Cancelado",
                        ventaId = s.VentaId,
                        facturar=s.Facturar
                    }
                ).OrderByDescending(s=> s.ventaId).ToList();


        }

        private void uiBuscar_Click(object sender, EventArgs e)
        {
           buscar();
        }

       

        private void frmReimprimirTicket_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void repVer_Click(object sender, EventArgs e)
        {
            int rowHandle = uigvTicket.FocusedRowHandle;

            if(rowHandle >= 0)
            {
                int ventaId = Convert.ToInt32( uigvTicket.GetRowCellValue(rowHandle, "ventaId"));

                if(ventaId > 0)
                {
                    if (uiVerVenta.Checked)
                    {
                        if (frmPuntoVenta.GetInstance().Visible)
                        {
                            frmPuntoVenta.GetInstance().obtenerVenta(ventaId);
                        }
                    }
                    if (uiReimprimir.Checked)
                    {
                        ERP.Reports.rptVentaTicket oTicket = new ERP.Reports.rptVentaTicket();
                        ERP.Reports.rptVentaTicket_CartaM oTicketMediaC = new ERP.Reports.rptVentaTicket_CartaM();
                        ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer();

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
    }
}
