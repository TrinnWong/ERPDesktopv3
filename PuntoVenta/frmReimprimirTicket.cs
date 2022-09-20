using ConexionBD;
using ConexionBD.Models;
using PuntoVenta.Reports;
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

namespace PuntoVenta
{
    public partial class frmReimprimirTicket : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmReimprimirTicket _instance;
        public bool esReimpresion = false;
        public static frmReimprimirTicket GetInstance()
        {
            if (_instance == null) _instance = new frmReimprimirTicket();
            return _instance;
        }

        public frmReimprimirTicket()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void frmReimprimirTicket_Load(object sender, EventArgs e)
        {
            uiFechaIni.Value = DateTime.Now;
            uiFechaFin.Value = DateTime.Now;

            HabilitarDeshabilitar();
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
            DateTime fechaIni = uiFechaIni.Value;
            DateTime fechaFin = uiFechaFin.Value;
            string folio = uiFolio.Text;

            uiTicket.DataSource = oContext.doc_ventas
                .Where(
                    w => (w.Folio.ToString() == folio && uiBuscarFolio.Checked)
                    ||
                    (
                   DbFunctions.TruncateTime( w.Fecha) >= DbFunctions.TruncateTime(fechaIni) && DbFunctions.TruncateTime(w.Fecha) <= DbFunctions.TruncateTime(fechaFin )
                    && uiBuscarFechas.Checked)
                ).Select(
                    s => new
                    {
                        folio = s.Folio,
                        fecha = s.Fecha,
                        descuento = s.TotalDescuento,
                        subtotal = s.SubTotal,
                        impuestos = s.Impuestos,
                        total = s.TotalVenta,
                        Estatus = s.Activo ==true ? "Activo" : "Cancelado"
                    }
                ).ToList();


        }

        private void uiBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void uiTicket_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ERP.Reports.rptVentaTicket oTicket = new ERP.Reports.rptVentaTicket();
            ERP.Reports.rptVentaTicket_CartaM oTicketMediaC = new ERP.Reports.rptVentaTicket_CartaM();
            ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer();

            string folio = uiTicket.Rows[e.RowIndex].Cells["Folio"].Value.ToString();

            if (esReimpresion)
            {
                if (folio != "")
                {
                    int folioInt;

                    if (int.TryParse(folio, out folioInt))
                    {
                        doc_ventas venta = oContext.doc_ventas.Where(w => w.VentaId == folioInt).FirstOrDefault();
                        if (venta != null)
                        {
                            if (venta.Activo == false)
                            {
                                MessageBox.Show("El ticket esta cancelado", "ERROR");
                                return;
                            }
                        }
                        else {
                            MessageBox.Show("El ticket no existe","ERROR");
                            return;
                        }
                    }
                    doc_reimpresion_ticket entityReimpresion = new doc_reimpresion_ticket();
                    entityReimpresion.ReimpresionTicketId = oContext.doc_reimpresion_ticket.Count() > 0 ?
                        oContext.doc_reimpresion_ticket.Max(m => m.ReimpresionTicketId) + 1 : 1;
                    entityReimpresion.CajaId = frmMenu.GetInstance().puntoVentaContext.cajaId;
                    entityReimpresion.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                    entityReimpresion.CreadoPor = frmMenu.GetInstance().puntoVentaContext.usuarioId;
                    entityReimpresion.FechaReimpresion = entityReimpresion.CreadoEl;
                    entityReimpresion.VentaId = folioInt;

                    oContext.doc_reimpresion_ticket.Add(entityReimpresion);
                    oContext.SaveChanges();


                   // int sucursalId = this.puntoVentaContext.sucursalId;
                    cat_configuracion entityConf = oContext.cat_configuracion
                        .FirstOrDefault();

                    if (entityConf.ImprimirTicketMediaCarta == true)
                    {
                        oTicketMediaC.DataSource = oContext.p_rpt_VentaTicket(int.Parse(folio)).ToList();
                        oTicketMediaC.esReimpreso = true;

                        oViewer.ShowTicket(oTicketMediaC);
                    }
                    else {
                        oTicket.DataSource = oContext.p_rpt_VentaTicket(int.Parse(folio)).ToList();
                        oTicket.esReimpreso = true;

                        oViewer.ShowTicket(oTicket);
                    }

                    
                    //oViewer.Show();

                    


                }
            }
            else
            {
                frmPuntoVenta oForm = frmPuntoVenta.GetInstance();

                oForm.buscarTicket(folio);

                frmMenu frm = oForm.MdiParent as frmMenu;
                frm.HabilitarDeshabilitarMenu(true, true, true, false, false, false, false);

                this.Close();
            }
           
           
        }

        private void frmReimprimirTicket_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
    }
}
