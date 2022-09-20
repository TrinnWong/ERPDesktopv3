using ConexionBD;
using ERP.Common.Base;
using ERP.Common.Produccion;
using ERP.Common.Traspasos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Produccion.Desktop
{
    public partial class frmPanelInicio : FormBaseXtraForm
    {

        private static frmPanelInicio _instance;

        public static frmPanelInicio GetInstance()
        {
            if (_instance == null) _instance = new frmPanelInicio();
            else _instance.BringToFront();
            return _instance;
        }
        public frmPanelInicio()
        {
            InitializeComponent();
        }

        private void frmPanelInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiProduccionNuevo_Click(object sender, EventArgs e)
        {
            frmProduccionSucursalUpd frmo = frmProduccionSucursalUpd.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = frmMain.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Nuevo();
                frmo.Show();

            }
        }

        private void calcularTotales()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();

                List<doc_produccion> lstProduccion =
                    oContext.doc_produccion
                    .Where(w => w.Activo && w.SucursalId == puntoVentaContext.sucursalId
                    && w.EstatusProduccionId == (int)ERP.Business.Enumerados.estatusProduccion.En_Produccion
                    ).ToList();

                uiProduccionEn.Text = String.Format("EN PRODUCCIÓN ({0})", lstProduccion.Where(w => w.EstatusProduccionId == (int)ERP.Business.Enumerados.estatusProduccion.En_Produccion).Count().ToString());

                DateTime fechaAct = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                lstProduccion =
                   oContext.doc_produccion
                   .Where(w => w.Activo && w.SucursalId == puntoVentaContext.sucursalId
                   && w.EstatusProduccionId == (int)ERP.Business.Enumerados.estatusProduccion.Produccion_Terminada
                   && System.Data.Entity.DbFunctions.TruncateTime(w.FechaHoraFin) == System.Data.Entity.DbFunctions.TruncateTime(fechaAct)
                   ).ToList();

                uiProduccionTerminada.Text = String.Format("TERMINADOS HOY ({0})", lstProduccion.Where(w => w.EstatusProduccionId == (int)ERP.Business.Enumerados.estatusProduccion.Produccion_Terminada).Count().ToString());
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                   "ERP",
                                   this.Name,
                                   ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmPanelInicio_Load(object sender, EventArgs e)
        {
            calcularTotales();
        }

        private void uiProduccionEn_Click(object sender, EventArgs e)
        {
            frmProduccionSucursalList frmo = frmProduccionSucursalList.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.IDEstatus = (int)ERP.Business.Enumerados.estatusProduccion.En_Produccion;
                frmo.MdiParent = frmMain.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                
                frmo.Show();

            }
        }

        private void uiProduccionTerminada_Click(object sender, EventArgs e)
        {
            frmProduccionSucursalList frmo = frmProduccionSucursalList.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.IDEstatus = (int)ERP.Business.Enumerados.estatusProduccion.Produccion_Terminada;
                frmo.MdiParent = frmMain.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
               
                frmo.Show();

            }
        }

        private void uiTraspasoSucursal_Click(object sender, EventArgs e)
        {
            frmTraspasosSalidaLite frmo = frmTraspasosSalidaLite.GetInstance();

            if (!frmo.Visible)
            {
                
                frmo.MdiParent = frmMain.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;              
                frmo.Show();

            }
        }
    }
}
