using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Business;
using ERP.Common.Basculas;
using ERP.Common.Bitacora;
using ERP.Common.Catalogos;
using ERP.Common.Forms;
using ERP.Common.Inventarios;
using ERP.Common.Pedido;
using ERP.Common.Productos;
using ERP.Common.PuntoVenta;
using ERP.Common.Seguridad;
using ERP.Common.Sincronizar;
using ERP.Common.Traspasos;
using ERP.Common.Utils;
using ERP.Common.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;


namespace PuntoVenta.Desktop
{
    public partial class frmMain : XtraForm
    {
        string error = "";
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

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();
            if (oContext.sis_preferencias_empresa
                .Where(w => w.sis_preferencias.Preferencia == "PermitirEntradaDirectaPV").Count() > 0)
            {
                uiEntradaDirecta.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                uiEntradaDirecta.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                this.puntoVentaContext.sucursalId, "PVBotonRegistroBasculaPedidosApp", this.puntoVentaContext.usuarioId))
            {
                frmBasculaExpressVenta frmo = frmBasculaExpressVenta.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.MdiParent = this;
                    frmo.WindowState = FormWindowState.Maximized;
                    frmo.Show();
                }
            }
            else
            {
                frmPuntoVenta frmo = frmPuntoVenta.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    frmo.MdiParent = this;
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.WindowState = FormWindowState.Maximized;
                    frmo.Show();

                }
            }

            if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
               this.puntoVentaContext.sucursalId, "PV-Local", this.puntoVentaContext.usuarioId))
            {
                uiSincronizar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                uiSincronizar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void uiMenuNuevaVenta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPuntoVenta frmo = frmPuntoVenta.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
            else
            {
                frmo.inicializar();
            }
        }

        private void uiMenuConfigBascula_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ERP.Business.Tools.NetworkUtil.ValidateInternet())
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("SE REQUIERE INTERNET PARA CONTINUAR");
                return;
            }

            frmVentasList frmo = frmVentasList.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.Show();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            oContext = new ERPProdEntities();

            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            bool abrir = false;

            if (entity.RetiroReqClaveSup ?? false)
            {
                frmAdminPass oForm = new frmAdminPass();

                oForm.StartPosition = FormStartPosition.CenterScreen;
                oForm.ShowDialog();

                if (oForm.DialogResult == DialogResult.OK)
                {
                    abrir = true;
                }
            }
            else
            {
                abrir = true;
            }

            if (abrir)
            {
                string error = RawPrinterHelper.AbreCajon(this.puntoVentaContext.nombreImpresoraCaja);
                if (error.Length > 0)
                {
                    XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                frmRetiros frm = new frmRetiros();
                frm.puntoVentaContext = this.puntoVentaContext;
                frm.ShowDialog();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            oContext = new ERPProdEntities();

            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            bool abrir = false;

            if (entity.ReqClaveSupGastosPV ?? false)
            {
                frmAdminPass oForm = new frmAdminPass();

                oForm.StartPosition = FormStartPosition.CenterScreen;
                oForm.ShowDialog();

                if (oForm.DialogResult == DialogResult.OK)
                {
                    abrir = true;
                }
            }
            else
            {
                abrir = true;
            }

            if (abrir)
            {
                abrirGastos();
            }
        }

        public void abrirGastos()
        {
            string error = RawPrinterHelper.AbreCajon(this.puntoVentaContext.nombreImpresoraCaja);
            if (error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            frmGastos frmo = new frmGastos();
            frmo.puntoVentaContext = this.puntoVentaContext;
            frmo.accionForm = (int)ConexionBD.Enumerados.accionForm.agregar;
            frmo.StartPosition = FormStartPosition.CenterScreen;
            frmo.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAdminPass oForm = new frmAdminPass();
            oForm.WindowState = FormWindowState.Normal;
            oForm.StartPosition = FormStartPosition.CenterScreen;

            oForm.ShowDialog();

            if (oForm.DialogResult == DialogResult.OK)
            {
                frmImpresoras frmo = frmImpresoras.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.MdiParent = this;
                    frmo.WindowState = FormWindowState.Maximized;
                    frmo.Show();
                }
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAdminPass oForm = new frmAdminPass();
            oForm.WindowState = FormWindowState.Normal;
            oForm.StartPosition = FormStartPosition.CenterScreen;

            oForm.ShowDialog();

            if (oForm.DialogResult == DialogResult.OK)
            {
                frmCajasImpresoras frmo = frmCajasImpresoras.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.MdiParent = this;
                    frmo.WindowState = FormWindowState.Normal;
                    frmo.Show();
                }
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (puntoVentaContext.esSupervisor)
            {
                try
                {
                    oContext = new ERPProdEntities();

                    int sesionId = puntoVentaContext.sesionId;
                    doc_sesiones_punto_venta entity = oContext.doc_sesiones_punto_venta
                        .Where(w => w.SesionId == sesionId).FirstOrDefault();

                    entity.Finalizada = true;
                    entity.FechaUltimaConexion = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                    oContext.SaveChanges();

                    this.Close();
                    // System.Windows.Forms.Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                this.Close();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ERP.Business.Tools.NetworkUtil.ValidateInternet())
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("SE REQUIERE INTERNET PARA CONTINUAR");
                return;
            }

            LoadingForm oFormLoading = new LoadingForm("Procesando");
            SincronizacionBusiness oSincronizar = new SincronizacionBusiness();

            string msg = "";
            oContext = new ERPProdEntities();

            //Realizar Sincronización de TODO
            oFormLoading.Show();
            if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
              this.puntoVentaContext.sucursalId, "PV-Local", this.puntoVentaContext.usuarioId))
            {
                oSincronizar.ExportANube();
            }
            
            oFormLoading.Hide();

            //Si es Tortillería, validar que los datos necesarios.
            if (oContext.cat_configuracion.FirstOrDefault().Giro == "TORTI" &&
                !ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                   this.puntoVentaContext.sucursalId, "QuitarVal-MasecaMaizCorte", this.puntoVentaContext.usuarioId))
            {
                List<p_doc_corte_caja_tortilleria_Result> lstResult = oContext.p_doc_corte_caja_tortilleria(this.puntoVentaContext.sucursalId,
                    DateTime.Now,
                    DateTime.Now,
                    puntoVentaContext.usuarioId).ToList();

                if (lstResult.Count() > 0)
                {
                    if (lstResult.Where(w => w.Clave == "MAIZS").Sum(s => s.Cantidad) == 0)
                    {
                        msg = "Es necesario registrar los sacos de Maiz usados para producción en el día " + DateTime.Now.AddDays(-1).ToShortDateString();
                    }
                    if (lstResult.Where(w => w.Clave == "MASECAS").Sum(s => s.Cantidad) == 0)
                    {
                        msg = msg + "|Es necesario registrar los sacos de Maseca usados para producción en el día " + DateTime.Now.AddDays(-1).ToShortDateString();
                    }
                    if (lstResult.FirstOrDefault().TotalRetiros == 0)
                    {
                        msg = msg + "|Es necesario registrar los retiros del día (Venta de Mostrador y Repartos) ";
                    }
                    //SOBRANTES
                    if (lstResult.Where(w => w.TipoId == 6).Sum(s => s.Cantidad) == 0)
                    {
                        msg = msg + "|Es necesario registrar los sobrantes del día " + DateTime.Now.ToShortDateString();
                    }

                    if (msg.Length > 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning(msg);
                        return;
                    }
                }
            }

            if (!ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                this.puntoVentaContext.sucursalId,
                "PVCorteCajaOcultarDetalleCajero", this.puntoVentaContext.usuarioId))
            {
                frmCorteCajaGen frmo = frmCorteCajaGen.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.MdiParent = this;
                    frmo.Show();
                }
            }
            else
            {
                frmCorteCajaGen frmo = frmCorteCajaGen.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.MdiParent = this;
                    if (frmo.generarCorteCaja(false, false))
                    {
                        error = ERP.Business.CorteCajaBusiness.imprimirCorteCajero(puntoVentaContext.sucursalId, puntoVentaContext.cajaId, puntoVentaContext.usuarioId);

                        if (error.Length > 0)
                        {
                            ERP.Utils.MessageBoxUtil.ShowError(error);
                        }
                        else
                        {
                            ERP.Utils.MessageBoxUtil.ShowWarning("SE REINICIARÁ EL SISTEMA");
                            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                            Application.Exit();
                            this.Close();
                        }
                    }
                }
            }
        }

        private void timerClearMemoryData_Tick(object sender, EventArgs e)
        {
            //ERP.Business.DataMemory.DataBucket.ClearData();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBasculaExpressVenta frmo = frmBasculaExpressVenta.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;
                frmo.Show();
            }
        }

        private void uiProductoSobrante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ERP.Business.Tools.NetworkUtil.ValidateInternet())
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("SE REQUIERE INTERNET PARA CONTINUAR");
                return;
            }

            frmSobrantesRegistro oForm = new frmSobrantesRegistro();
            oForm.dtProcess = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
            oForm.habilitarFecha = false;
            oForm.puntoVentaContext = this.puntoVentaContext;
            oForm.StartPosition = FormStartPosition.CenterScreen;
            oForm.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCapturaInventarioReal frmo = frmCapturaInventarioReal.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;
                frmo.Show();
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAceptacionSucursal frmo = frmAceptacionSucursal.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;
                frmo.Show();
            }
        }

        private void btnDesperdicioMasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRecepcionProducto frmo = frmRecepcionProducto.GetInstance();
            if (!frmo.Visible)
            {
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Normal;
                frmo.tipoMovimiento = ConexionBD.Enumerados.tipoMovsInventario.desperdicioInventario;
                frmo.ClaveProductoDefault = "2";
                frmo.ShowDialog();
            }
        }

        private void uiDesperdicioTortilla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRecepcionProducto frmo = frmRecepcionProducto.GetInstance();
            if (!frmo.Visible)
            {
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Normal;
                frmo.tipoMovimiento = ConexionBD.Enumerados.tipoMovsInventario.desperdicioInventario;
                frmo.ClaveProductoDefault = "1";
                frmo.ShowDialog();
            }
        }

        private void uiTraspasos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void uiDevoluciones_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ERP.Business.Tools.NetworkUtil.ValidateInternet())
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("SE REQUIERE INTERNET PARA CONTINUAR");
                return;
            }
            abrirDevoluciones();
        }

        public void abrirDevoluciones()
        {
            frmDevoluciones frmo = frmDevoluciones.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;

                frmo.Show();
            }
        }

        private void uiEntradaDirecta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRecepcionProducto frmo = frmRecepcionProducto.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.tipoMovimiento = ConexionBD.Enumerados.tipoMovsInventario.entradaDirecta;
                frmo.Show();
            }
        }

        private void uiSalidaDirecta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRecepcionProducto frmo = frmRecepcionProducto.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.tipoMovimiento = ConexionBD.Enumerados.tipoMovsInventario.ajustePorSalida;
                frmo.Show();
            }
        }

        private void uiSincronizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAdminPass oForm = new frmAdminPass();
            oForm.WindowState = FormWindowState.Normal;
            oForm.StartPosition = FormStartPosition.CenterScreen;

            oForm.ShowDialog();

            if (oForm.DialogResult == DialogResult.OK)
            {
                frmSincronizarNube frmo = frmSincronizarNube.GetInstance();
                if (!frmo.Visible)
                {
                    frmo.MdiParent = this;
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.StartPosition = FormStartPosition.CenterScreen;
                    frmo.WindowState = FormWindowState.Maximized;

                    frmo.Show();
                }
            }


           
        }

        private void uiMnuBascula_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (Process.GetProcessesByName("ERP.Background.Task").Count() > 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Ya existe una instanacia de la tarea abierta");
                }
                else
                {
                    Process p = new Process();
                    ProcessStartInfo psi = new ProcessStartInfo(@"ERP.Background.Task.exe");

                    p.StartInfo = psi;
                    p.Start();
                }
            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMain.GetInstance().puntoVentaContext.usuarioId,
                                       "ERP",
                                       this.Name,
                                       ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void btnReimprimirUltimoCorteCajero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ERP.Business.Tools.NetworkUtil.ValidateInternet())
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("SE REQUIERE INTERNET PARA CONTINUAR");
                return;
            }

            ERP.Business.CorteCajaBusiness.imprimirCorteCajero(puntoVentaContext.sucursalId, puntoVentaContext.cajaId, puntoVentaContext.usuarioId);
        }

        private void frmMain_HelpButtonClicked(object sender, CancelEventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            oContext = new ERPProdEntities();

            int sesionId = puntoVentaContext.sesionId;
            doc_sesiones_punto_venta entity = oContext.doc_sesiones_punto_venta
                .Where(w => w.SesionId == sesionId).FirstOrDefault();

            entity.Finalizada = true;
            entity.FechaUltimaConexion = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

            oContext.SaveChanges();

        }

        private void uiMenuReimprimirCorteSupervisor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ERP.Business.Tools.NetworkUtil.ValidateInternet())
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("SE REQUIERE INTERNET PARA CONTINUAR");
                return;
            }

            frmAdminPass oForm = new frmAdminPass();

            oForm.StartPosition = FormStartPosition.CenterScreen;
            oForm.ShowDialog();

            if (oForm.DialogResult == DialogResult.OK)
            {
                frmCorteCajaGen frmo = frmCorteCajaGen.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.MdiParent = this;
                    frmo.Show();
                }
            }
        }

        private void mnuMaizMaseca_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ERP.Business.Tools.NetworkUtil.ValidateInternet())
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("SE REQUIERE INTERNET PARA CONTINUAR");
                return;
            }
            frmAdminPass oForm = new frmAdminPass();

            oForm.StartPosition = FormStartPosition.CenterScreen;
            oForm.ShowDialog();

            if (oForm.DialogResult == DialogResult.OK)
            {
                frmRegistroMaizMaseca frmo = frmRegistroMaizMaseca.GetInstance();
                if (!frmo.Visible)
                {
                    frmo.MdiParent = this;
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.StartPosition = FormStartPosition.CenterScreen;
                    frmo.WindowState = FormWindowState.Maximized;
                    frmo.Show();
                }
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void timerToCheckNetwork_Tick(object sender, EventArgs e)
        {

            //Si es LOCAL no mandar aviso de internet
            if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
               this.puntoVentaContext.sucursalId, "PV-Local", this.puntoVentaContext.usuarioId))
            {
                return;
            }
          


            string estadoConexionaRed = "";
            bool RedActiva = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

            if (!RedActiva)
            {
                estadoConexionaRed = "No hay conexión a Internet";
                ERP.Utils.MessageBoxUtil.ShowWarning(estadoConexionaRed);
            }
            else
            {
                //estadoConexionaRed = "Se estableció conexión con la red local";
                //Console.WriteLine(estadoConexionaRed);

                string estadoConexionInternet = "";
                System.Uri Url = new System.Uri("https://www.google.com/");

                System.Net.WebRequest WebRequest;
                WebRequest = System.Net.WebRequest.Create(Url);
                System.Net.WebResponse objetoResp;

                try
                {
                    objetoResp = WebRequest.GetResponse();
                    estadoConexionInternet = "Se establecio conexión a internet corretamente.";
                    //Console.WriteLine(estadoConexionaRed);
                    objetoResp.Close();
                }
                catch (Exception ex)
                {
                    estadoConexionInternet = "No hay conexión a Internet " + ex.Message;
                    ERP.Utils.MessageBoxUtil.ShowWarning(estadoConexionInternet);
                }
                WebRequest = null;
            }
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPuntoVenta frmo1 = frmPuntoVenta.GetInstance();

            if (!frmo1.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo1.MdiParent = this;
                frmo1.puntoVentaContext = this.puntoVentaContext;
                frmo1.WindowState = FormWindowState.Maximized;
                frmo1.Show();
            }
            else
            {
                frmo1.inicializar();
            }

            if (!ERP.Business.Tools.NetworkUtil.ValidateInternet())
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("SE REQUIERE INTERNET PARA CONTINUAR");
                return;
            }

            frmRepartosTortillaCaptura frmo = new frmRepartosTortillaCaptura();
            frmo.puntoVentaContext = this.puntoVentaContext;
            frmo.StartPosition = FormStartPosition.CenterScreen;
            frmo.ShowDialog();
          
        }

        private void uiTimerSincroniza_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Process.GetProcessesByName("ERP.Console.Task").Count() == 0)
                {
                  
                    Process p = new Process();
                    ProcessStartInfo psi = new ProcessStartInfo(@"ERP.Console.Task.exe");

                    p.StartInfo = psi;
                    p.Start();
                }
            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMain.GetInstance().puntoVentaContext.usuarioId,
                                       "ERP",
                                       this.Name,
                                       ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiToolsBitacora_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBitacoraExcepciones frmo = frmBitacoraExcepciones.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void uiRepartoDevoluciones_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ERP.Common.Pedido.PedidoDevolucionVentasDirectas oForm = new PedidoDevolucionVentasDirectas();

            oForm.puntoVentaContext = this.puntoVentaContext;
            oForm.StartPosition = FormStartPosition.CenterScreen;
            oForm.ShowDialog();
        }
    }
}
