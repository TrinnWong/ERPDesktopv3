using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Common.Basculas;
using ERP.Common.Inventarios;
using ERP.Common.Produccion;
using ERP.Common.PuntoVenta;
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
    public partial class frmMain : XtraForm
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmMain _instance;

        public static frmMain GetInstance()
        {
            if (_instance == null) _instance = new frmMain();
            else _instance.BringToFront();
            return _instance;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void abrirPanelInicio()
        {
            //frmPanelInicio frmo = frmPanelInicio.GetInstance();

            //if (!frmo.Visible)
            //{
            //    //frmo = new frmPuntoVenta();
            //    frmo.MdiParent = this;
            //    frmo.puntoVentaContext = this.puntoVentaContext;
            //    frmo.WindowState = FormWindowState.Maximized;
            //    frmo.Show();

            //}

            //frmProduccionFormV2022_1 frmo = frmProduccionFormV2022_1.GetInstance();

            //if (!frmo.Visible)
            //{
            //    //frmo = new frmPuntoVenta();
            //    frmo.MdiParent = frmMain.GetInstance();
            //    frmo.puntoVentaContext = this.puntoVentaContext;
            //    frmo.WindowState = FormWindowState.Maximized;
            //    //frmo.Nuevo();
            //    frmo.Show();

            //}

            frmProduccionFormFast frmo = frmProduccionFormFast.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = frmMain.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                //frmo.Nuevo();
                frmo.Show();

            }
        }
        private void uiProduccionPanelInicio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            abrirPanelInicio();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            abrirPanelInicio();
        }

        private void uiConfiguracionBascula_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BasculaConfiguracion frmo = BasculaConfiguracion.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();

            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void uiProduccionNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmProduccionSucursalUpd frmo = frmProduccionSucursalUpd.GetInstance();

            //if (!frmo.Visible)
            //{
            //    //frmo = new frmPuntoVenta();
            //    frmo.MdiParent = frmMain.GetInstance();
            //    frmo.puntoVentaContext = this.puntoVentaContext;
            //    frmo.WindowState = FormWindowState.Maximized;
            //    frmo.Nuevo();
            //    frmo.Show();

            //}

            //frmProduccionFormV2022_1 frmo = frmProduccionFormV2022_1.GetInstance();

            //if (!frmo.Visible)
            //{
            //    //frmo = new frmPuntoVenta();
            //    frmo.MdiParent = frmMain.GetInstance();
            //    frmo.puntoVentaContext = this.puntoVentaContext;
            //    frmo.WindowState = FormWindowState.Maximized;
            //    //frmo.Nuevo();
            //    frmo.Show();

            //}

            frmProduccionFormFast frmo = frmProduccionFormFast.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = frmMain.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                //frmo.Nuevo();
                frmo.Show();

            }
        }

        private void uiProduccionEn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void uiProduccionTerminado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void uiTraspasosSalida_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTraspasosSalidaLite frmo = frmTraspasosSalidaLite.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = frmMain.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                
                frmo.Show();

            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBasculaExpress frmo = frmBasculaExpress.GetInstance();

            if (!frmo.Visible)
            {
                frmo.MdiParent = frmMain.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();

            }
        }

        private void uiBtnProduccionCocina_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmProduccionSolicitudList frmo = frmProduccionSolicitudList.GetInstance();

            if (!frmo.Visible)
            {
                frmo.MdiParent = frmMain.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();

            }
        }

        private void uiBtnProduccionCocinaEjec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmProduccionSoicitudEjecucionList frmo = frmProduccionSoicitudEjecucionList.GetInstance();

            if (!frmo.Visible)
            {
                frmo.MdiParent = frmMain.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();

            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ERP.Common.Produccion.frmProduccionSolicitudAceptacionList frmo = frmProduccionSolicitudAceptacionList.GetInstance();

            if (!frmo.Visible)
            {
                frmo.MdiParent = frmMain.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();

            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRecepcionProducto frmo = frmRecepcionProducto.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.tipoMovimiento = Enumerados.tipoMovsInventario.entradaDirecta;
                frmo.Show();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRecepcionProducto frmo = frmRecepcionProducto.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.tipoMovimiento = Enumerados.tipoMovsInventario.ajustePorSalida;
                frmo.Show();
            }
        }
    }
}
