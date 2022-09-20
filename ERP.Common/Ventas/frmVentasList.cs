using ConexionBD;
using ERP.Common.Base;
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

namespace ERP.Common.Ventas
{
    public partial class frmVentasList : FormBaseXtraForm
    {
        private bool ventasDia { get; set; }
        private static frmVentasList _instance;
        public static frmVentasList GetInstance()
        {
            if (_instance == null) _instance = new frmVentasList();
            else _instance.BringToFront();
            return _instance;
        }
        public frmVentasList()
        {
            InitializeComponent();
        }

        private void frmVentasList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void loadGrid()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiGrid.DataSource = oContext.doc_ventas
                    .Where(w => DbFunctions.TruncateTime(w.Fecha)  == DbFunctions.TruncateTime(DateTime.Now) &&
                    w.SucursalId == puntoVentaContext.sucursalId
                    )
                    .OrderByDescending(o=> o.Fecha)
                    .ToList();

                uiGridView.ExpandAllGroups();
                
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(
                    puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmVentasList_Load(object sender, EventArgs e)
        {
            oContext = new ConexionBD.ERPProdEntities();
            loadGrid();
        }

        private void uiRefrescar_Click(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void HabilitarDeshabilitarAcciones()
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    uiCancelar.Enabled = true;
                    uiReimprimir.Enabled = true;
                }
                else
                {
                    uiCancelar.Enabled = false;
                    uiReimprimir.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(
                   puntoVentaContext.usuarioId,
                          "ERP",
                          this.Name,
                          ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiGridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            HabilitarDeshabilitarAcciones();
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (uiGridView.FocusedRowHandle >= 0)
                {
                    doc_ventas venta = (doc_ventas)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    ERP.Common.PuntoVenta.PuntoVentaAcciones.CancelarTicketSolicitud((int)venta.VentaId,puntoVentaContext);
                }
                


            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(
                    puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiReimprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (uiGridView.FocusedRowHandle >= 0)
                {
                    doc_ventas venta = (doc_ventas)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    ERP.Common.PuntoVenta.PuntoVentaAcciones.ReimprimirTicket((int)venta.VentaId, puntoVentaContext);
                }



            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(
                    puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
    }
}
