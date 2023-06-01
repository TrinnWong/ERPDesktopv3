using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using ERP.Common;
using ERP.Common.Catalogos;
using ERP.Common.Configuracion;
using ERP.Common.Inventarios;
using ERP.Common.Procesos.Restaurante;
using ERP.Common.Productos;
using ERP.Common.PuntoVenta;
using ERP.Common.Reports;
using ERP.Common.Seguridad;
using ERP.Common.Utils;
using ERP.Procesos;
using ERP.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace TacosAna.Desktop
{
    public partial class frmMenuRestTA : XtraForm
    {
        int err;
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmMenuRestTA _instance;
        object mdiParenAux;
        public frmMenuRestTA()
        {
            InitializeComponent();
        }

        public void selectTabPuntoVenta()
        {
            this.ribbonControl1.SelectedPage = rbCuenta;
        }
        public static frmMenuRestTA GetInstance()
        {
            if (_instance == null) _instance = new frmMenuRestTA();
            else _instance.BringToFront();
            return _instance;
        }

        private void AbrirPuntoDeVenta()
        {/*
            frmPuntoVentaRest frmo = frmPuntoVentaRest.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;                
                frmo.Show();
                

            }
            else
            {
                frmo.nuevaCuenta(0);
            }*/

            frmPuntoVenta frmo = frmPuntoVenta.GetInstance();

            if (!frmo.Visible)
            {
                frmo.WindowState = FormWindowState.Maximized;
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();


            }

        }

     

        public void AbrirComanda()
        {
            //frmPuntoVentaRest.GetInstance().Close();
           // frmPuntoVentaRest.GetInstance().nuevaCuenta(0);

            frmComandaNueva frmo = new frmComandaNueva();
            frmo.puntoVentaContext = this.puntoVentaContext;
            frmo.StartPosition = FormStartPosition.CenterParent;
            frmo.ShowDialog();



        }

        private void frmMenuRest_Load(object sender, EventArgs e)
        {

            /*
            int cajaId = puntoVentaContext.cajaId;
            int sucursalId = puntoVentaContext.sucursalId;
            oContext = new ERPProdEntities();
            if (
               oContext.cat_cajas
               .Where(w => w.Clave == cajaId)
               .FirstOrDefault().cat_cajas_impresora.Count == 0
               ||
               oContext.cat_impresoras_comandas
               .Where(w=> w.cat_impresoras.SucursalId == sucursalId).Count() == 0
                )
            {
                frmConfigImpresora frm = new frmConfigImpresora();
                frm.puntoVentaContext = this.puntoVentaContext;
                frm.StartPosition = FormStartPosition.CenterParent;
                //frm.MdiParent = this.MdiParent;
                frm.ShowDialog();
            }
            else
            {
                AbrirComanda();
            */
            AbrirPuntoDeVenta();
        }

        private void uiMenuNuevaCuenta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AbrirPuntoDeVenta();
        }

        private void btnCerrarSesion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void uiMenuNuevaComanda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AbrirComanda();
        }

        private void uiMenuImprimirComanda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmPuntoVentaRest.GetInstance().imprimirComanda();

               
            }
            catch (Exception )
            {
                                
            }
        }

        private void uiMenuCuentaList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TacosAna.Desktop.frmCuentasListado frm = new TacosAna.Desktop.frmCuentasListado();
            frm.tipo = 1;
            frm.puntoVentaContext = this.puntoVentaContext;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.llenarGrid();
            frm.ShowDialog();
        }

        private void uiMenuImprimirCuenta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmPuntoVentaRest.GetInstance().imprimirCuenta();


            }
            catch (Exception)
            {

            }
        }

        private void uiMenuPagar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPuntoVentaRest.GetInstance().abrirFormasPago();
        }

        private void uiMenuBuscarTicket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AbrirPuntoDeVentaTicket();
            ERP.Common.PuntoVenta.frmReimprimirTicket f = new ERP.Common.PuntoVenta.frmReimprimirTicket();
            f.Text = "Buscar Ticket";
            f.puntoVentaContext = this.puntoVentaContext;
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog(this);
        }

        private void AbrirPuntoDeVentaTicket()
        {
           /* ERP.Common.PuntoVenta.frmPuntoVenta frmo = ERP.Common.PuntoVenta.frmPuntoVenta.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;
                frmo.Show();
                if (mdiParenAux == null)
                {
                    mdiParenAux = frmo.MdiParent;
                }

            }
*/

        }

        private void uiMenuReimprimirTicket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            oContext = new ERPProdEntities();

            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if (entity.ReqClaveSupReimpresionTicketPV ?? false)
            {
                frmAutorizacion frm = new frmAutorizacion();
                frm.puntoVentaContext = this.puntoVentaContext;
                frm.opcionLlamado = (int)ConexionBD.Enumerados.opcionesPV.reimpresionTicket;
                frm.ShowDialog();
            }
            else
            {
                frmReimprimirTicket frm = new frmReimprimirTicket();
                frm.puntoVentaContext = this.puntoVentaContext;
                frm.esReimpresion = true;
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void uiMenuCancelarCuenta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPuntoVentaRest.GetInstance().cancelarCuenta();
        }

        private void frmMenuRest_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void uiRetiros_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

            if(abrir)
            {
                string error = RawPrinterHelper.AbreCajon(this.puntoVentaContext.nombreImpresoraCaja);
                if(error.Length > 0)
                {
                    XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                frmRetiros frm = new frmRetiros();
                frm.puntoVentaContext = this.puntoVentaContext;
                frm.ShowDialog();
            }
           
        }

        public void abrirGastos()
        {
            string error = RawPrinterHelper.AbreCajon(this.puntoVentaContext.nombreImpresoraCaja);
            if (error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            frmGastosList frmo = frmGastosList.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;
                frmo.Show();
            }
        }

        private void uiGastos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void uiCorteCaja_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCorteCajaGen frmo = frmCorteCajaGen.GetInstance();
            frmo.puntoVentaContext = this.puntoVentaContext;
            if (frmo.generarCorteCaja(false,false))
            {
                imprimirCorteCajero();
                System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                Application.Exit();
                this.Close();
            }
            
        }

        public void CorteCaja(List<DeclaracionFondoModel> denominaciones, bool permitirCorteCero)
        {
            try
            {
                string error = RawPrinterHelper.AbreCajon(this.puntoVentaContext.nombreImpresoraCaja);
                if (error.Length > 0)
                {
                    XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                oContext = new ERPProdEntities();
                DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                ObjectParameter pCorteCajaId = new ObjectParameter("pCorteCajaId", 0);
                ObjectParameter pCorteCajaId_REC = new ObjectParameter("pCorteCajaId", 0);

                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        oContext.p_corte_caja_generacion(this.puntoVentaContext.cajaId, this.puntoVentaContext.usuarioId, fechaActual, pCorteCajaId, permitirCorteCero);
                        if (denominaciones != null)
                        {
                            foreach (DeclaracionFondoModel item in denominaciones)
                            {
                                if (item.total > 0)
                                {
                                    oContext.doc_corte_caja_denominaciones_ins(int.Parse(pCorteCajaId.Value.ToString()), item.clave, item.cantidad, item.valor, item.total, this.puntoVentaContext.usuarioId);
                                }

                            }
                        }


                        if(puntoVentaContext.tieneRec)
                        {
                            oContext.p_corte_caja_generacion_rec(this.puntoVentaContext.cajaId, this.puntoVentaContext.usuarioId, fechaActual, pCorteCajaId_REC, permitirCorteCero);
                        }

                        scope.Complete();
                    }
                    catch (Exception ex)
                    {

                        XtraMessageBox.Show("Ocurrió un error generar el corte", "ERROR",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                }
                   
            


                rptCorteCajaCajero oCorte = new rptCorteCajaCajero();
                ReportViewer oViewer = new ReportViewer();

                oCorte.DataSource = oContext.p_rpt_corte_caja_cajero(this.puntoVentaContext.sucursalId,DateTime.Now,puntoVentaContext.cajaId).ToList();




                oCorte.esAdmin = this.puntoVentaContext.esSupervisor;
                try
                {
                    oViewer.ShowTicket(oCorte);
                }
                catch (Exception)
                {

                    
                }
              
                //oViewer.Show();

                MessageBox.Show("El corte de caja se generó con éxito", "AVISO");

                #region enviar por correo

                List<System.Net.Mail.Attachment> attachmentList = new List<System.Net.Mail.Attachment>();
                ActiveReportExportTo exportTool = new ActiveReportExportTo();

                #region obtener corte de caja
                if(puntoVentaContext.tieneRec)
                {
                    oCorte.DataSource = oContext.p_rpt_corte_caja_enc_rec(int.Parse(pCorteCajaId_REC.Value.ToString())).ToList();
                }
                else
                {
                    oCorte.DataSource = oContext.p_rpt_corte_caja_enc(int.Parse(pCorteCajaId.Value.ToString())).ToList();
                }
                oCorte.esAdmin = this.puntoVentaContext.esSupervisor;


                Stream pdfStream = new System.IO.MemoryStream();
                oCorte.Document.Printer.PrinterName = "";
                pdfStream = exportTool.ToPDF(oCorte);

                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(pdfStream, "Corte_de_Caja.pdf", "application/pdf");
                attachmentList.Add(attachment);

                #endregion

                #region obtener reporte notas venta

                rptNotasVentaResumido oReportventa = new rptNotasVentaResumido();

                int sucursal = this.puntoVentaContext.sucursalId;
                int caja = this.puntoVentaContext.cajaId;
                DateTime fecha = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                oReportventa.DataSource = oContext.p_rpt_notas_venta_resumido(
                    sucursal,
                    caja,
                    0,
                    fecha,
                    fecha).ToList();

                pdfStream = new System.IO.MemoryStream();
                oReportventa.Document.Printer.PrinterName = "";
                pdfStream = exportTool.ToPDF(oReportventa);



                attachment = new System.Net.Mail.Attachment(pdfStream, "Notas_Venta_Resumido.pdf", "application/pdf");
                attachmentList.Add(attachment);
                #endregion



                int sucursalId = puntoVentaContext.sucursalId;

                cat_sucursales entity = oContext.cat_sucursales.Where(w => w.Clave == sucursalId).FirstOrDefault();

                if ((entity.ServidorMailSMTP == null ? "" : entity.ServidorMailSMTP) == "")
                {
                    MessageBox.Show("No fue posible enviar el corte de caja por correo. Falta configurar el servidor de correo para la sucursal", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            oMail.Send("Corte de Caja", emailEnvio, "CORTE DE CAJA", "", attachmentList);
                        }
                        else
                        {
                            MessageBox.Show("No hay usuarios de tipo supervisrp con un email registrado. No fue posible enviar el corte de caja por correo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe registro de configuración", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }







                }





                #endregion

                MessageBox.Show("*****EL SISTEMA SE REINICIARÁ AL DAR CLICK*******", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                this.Close();



            }
            catch (Exception ex)
            {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(message, "ERROR");

            }
        }

        private void uiImpresoras_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            frmAdminPass oForm = new frmAdminPass();
            oForm.WindowState = FormWindowState.Normal;
            oForm.StartPosition = FormStartPosition.CenterScreen;
           
            oForm.ShowDialog();

            if(oForm.DialogResult == DialogResult.OK)
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

        private void uiImpresoraTicketPV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void uiImpresoraComanda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           

            frmAdminPass oForm = new frmAdminPass();
            oForm.WindowState = FormWindowState.Normal;
            oForm.StartPosition = FormStartPosition.CenterScreen;

            oForm.ShowDialog();

            if (oForm.DialogResult == DialogResult.OK)
            {
                frmComandaImpresora frmo = frmComandaImpresora.GetInstance();

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

        private void uiCancelarTicket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            oContext = new ERPProdEntities();

            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if (entity.ReqClaveSupCancelaTicketPV ?? false)
            {
                frmAdminPass oForm = new frmAdminPass();
                oForm.WindowState = FormWindowState.Normal;
                oForm.StartPosition = FormStartPosition.CenterScreen;

                oForm.ShowDialog();

                if (oForm.DialogResult == DialogResult.OK)
                {
                    cancelarTicket();
                }
            }
            else
            {
                cancelarTicket();
            }
        }

        public void cancelarTicket()
        {
            //AbrirPuntoDeVentaOld();
           frmPuntoVenta frmo = frmPuntoVenta.GetInstance();
            if (!frmo.Visible)
            {
                MessageBox.Show("Es necesario primero buscar el ticket a cancelar", "ERROR");
            }
            else
            {
                frmo.cancelarTicket();

            }
        }

        private void uiAbrirCajon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           string error= RawPrinterHelper.AbreCajon(this.puntoVentaContext.nombreImpresoraCaja);

            if(error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiNuevaVenta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AbrirPuntoDeVentaOld();
            frmPuntoVenta frmo = frmPuntoVenta.GetInstance();
            if (!frmo.Visible)
            {
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
                frmo.Inicializar();
            }
            else
            {
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Inicializar();

            }
        }

        private void uiGuardarTemp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPuntoVenta frmo = frmPuntoVenta.GetInstance();
            if (!frmo.Visible)
            {
                XtraMessageBox.Show("No tiene ninguna cuenta abierta");
            }
            else
            {
                // frmo.guardarTemporal();
                if (frmo.esVentaPorTelefono)
                {
                    frmPedidoNotas frm = new frmPedidoNotas();
                    frm.TipoPedido = ERP.Business.Enumerados.tipoPedido.PedidoTelefono;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Este pedido no se puede guardar temporalmente, es necesario cobrar anticipo", "AVISO",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                

            }
        }

        private void uiBuscarTicket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBuscarTicket frmo = frmBuscarTicket.GetInstance();
            if (!frmo.Visible)
            {
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;
                frmo.StartPosition = FormStartPosition.CenterParent;
                frmo.WindowState = FormWindowState.Normal;
                frmo.BringToFront();
                frmo.Show();
                
            }
           
        }

        public void EnableMenu(bool nuevaVenta,bool guardarTemporal,bool buscarTemporal,
            bool reimprimirTicket,bool buscarTicket)
        {
            uiNuevaVenta.Enabled = nuevaVenta;
            uiGuardarTemp.Enabled = guardarTemporal;
            uiMenuCuentaList.Enabled = buscarTemporal;
            uiMenuReimprimirTicket.Enabled = reimprimirTicket;
            uiBuscarTicket.Enabled = buscarTicket;
        }

        private void uiMnuCancelarCuenta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPuntoVenta frmo = frmPuntoVenta.GetInstance();
            if (!frmo.Visible)
            {
                XtraMessageBox.Show("No tiene ninguna cuenta abierta");
            }
            else
            {
                // frmo.guardarTemporal();

                frmo.cancelarCuenta();

            }
        }

        private void uiVentaTelefono_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPuntoVenta frmo = frmPuntoVenta.GetInstance();
            if (frmo.Visible)
            {
                frmo.abrirVentaPOrTelefono();
            }
            
        }

        private void uiPedido_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { 

            frmPuntoVenta frmo = frmPuntoVenta.GetInstance();
            if (frmo.Visible)
            {
                frmo.abrirPedido();
            }
            
        }

        private void uiBuscarPedido_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TacosAna.Desktop.frmCuentasListado frm = new TacosAna.Desktop.frmCuentasListado();
            frm.tipo = 2;
            frm.puntoVentaContext = this.puntoVentaContext;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.llenarGrid();
            frm.ShowDialog();
        }

        private void uiInvRecepcionProd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmInventarioMovRegistro frmo = frmInventarioMovRegistro.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.tipoMovimiento = ERP.Business.Enumerados.tipoMovimientoInventario.AjustePorEntrada;
                frmo.MovimientoInventarioId = 0;

                frmo.Show();
            }
        }

        private void uiCorteCajaSupervisor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            imprimirCorteGeneral();
        }

        private void reimprimir()
        {
            try
            {
                frmAdminPass form = new frmAdminPass();
                form.StartPosition = FormStartPosition.CenterScreen;
                DialogResult dr = form.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    oContext = new ERPProdEntities();
                    int corteId = oContext.doc_corte_caja.Where(w =>
                       w.doc_ventas.SucursalId == puntoVentaContext.sucursalId
                   ).Max(m => (int?)m.CorteCajaId) ?? 0;

                    ERP.Reports.rptCorteCaja oCorte = new ERP.Reports.rptCorteCaja();
                    oCorte.esAdmin = true;
                    ReportViewer oViewer = new ReportViewer(puntoVentaContext.cajaId);

                    oCorte.DataSource = oContext.p_rpt_corte_caja_enc(corteId).ToList();
                    oCorte.esAdmin = this.puntoVentaContext.esSupervisor;
                    oViewer.ShowTicket(oCorte);

                }


            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                               "ERP",
                               this.Name,
                               ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
                
            }

        }

        private void imprimirCorteCajero()
        {
            try
            {
                oContext = new ERPProdEntities();
                ImpresorasBusiness oImpresora = new ImpresorasBusiness();
                cat_impresoras entityImpresora;
                entityImpresora = oImpresora.ObtenerCajaImpresora(this.puntoVentaContext.cajaId);
                ERP.Reports.TacosAna.rptCorteCajaCajero1 oReport = new ERP.Reports.TacosAna.rptCorteCajaCajero1();
                DateTime fechaCorte = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                oReport.DataSource = oContext.p_rpt_corte_caja_cajero(this.puntoVentaContext.sucursalId,
                    fechaCorte, puntoVentaContext.cajaId).ToList();
                oReport.CreateDocument();
                cat_configuracion conf = oContext.cat_configuracion.FirstOrDefault();
                if (conf.vistaPreviaImpresion == true)
                {
                    oReport.ShowPreview();
                }
                else
                {
                    oReport.Print(entityImpresora.NombreRed);
                }


            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                               "ERP",
                               this.Name,
                               ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);

            }

        }


        private void imprimirCorteGeneral()
        {
            try
            {
                oContext = new ERPProdEntities();
                ImpresorasBusiness oImpresora = new ImpresorasBusiness();
                cat_impresoras entityImpresora;
                entityImpresora = oImpresora.ObtenerCajaImpresora(this.puntoVentaContext.cajaId);
                ERP.Reports.TacosAna.rptCorteCaja oReport = new ERP.Reports.TacosAna.rptCorteCaja();
                oReport.DataSource = oContext.p_rpt_corte_caja_general(this.puntoVentaContext.sucursalId,DateTime.Now.AddDays(-1)).ToList();
                oReport.CreateDocument();
                cat_configuracion conf = oContext.cat_configuracion.FirstOrDefault();
                if (conf.vistaPreviaImpresion == true)
                {
                    oReport.ShowPreview();
                }
                else
                {
                    oReport.Print(entityImpresora.NombreRed);
                }

            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                              "ERP",
                              this.Name,
                              ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void mnuProductoSobrante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            frmSobrantesRegistro oForm = new frmSobrantesRegistro();
            oContext = new ERPProdEntities();
            oForm.dtProcess = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
            oForm.habilitarFecha = false;
            oForm.puntoVentaContext = this.puntoVentaContext;
            oForm.StartPosition = FormStartPosition.CenterScreen;
            oForm.ShowDialog();
        }

        private void mneMaxMin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmMaximosMinimos frmo = frmMaximosMinimos.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();

            }
        }

        private void uiMenuMaxMinConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ERP.Common.Productos.frmMaximosMinimosUpd frmo = ERP.Common.Productos.frmMaximosMinimosUpd.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.deshabilitarSucursal = true;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();

            }
        }

        private void uiMenuAjusteInventario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            frmAdminPass oForm = new frmAdminPass();
            oForm.WindowState = FormWindowState.Normal;
            oForm.StartPosition = FormStartPosition.CenterScreen;

            oForm.ShowDialog();

            if (oForm.DialogResult == DialogResult.OK)
            {
                ERP.Common.Productos.frmAjustarInventario frmo = ERP.Common.Productos.frmAjustarInventario.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    frmo.MdiParent = this;
                    frmo.deshabilitarSucursal = true;
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.WindowState = FormWindowState.Maximized;
                    frmo.Show();

                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmInventarioMovRegistro frmo = frmInventarioMovRegistro.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.tipoMovimiento = ERP.Business.Enumerados.tipoMovimientoInventario.AjustePorSalida;
                frmo.MovimientoInventarioId = 0;

                frmo.Show();
            }
        }
    }
}
