using ConexionBD;
using ConexionBD.Models;
using ERP.Common;
using ERP.Common.Forms;
using ERP.Common.Inventarios;
using ERP.Reports;
using PuntoVenta.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class frmMenuTA : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        object mdiParenAux;

        private static frmMenuTA _instance;
        public static frmMenuTA GetInstance()
        {
            if (_instance == null) _instance = new frmMenuTA();
            else _instance.BringToFront();
            return _instance;
        }
        public frmMenuTA()
        {
            InitializeComponent();
            //puntoVentaContext = new PuntoVentaContext();
            oContext = new ERPProdEntities();

        }

        private void toolStripContainer1_Click(object sender, EventArgs e)
        {

        }

        private void frmMenuTA_Load(object sender, EventArgs e)
        {
            AbrirPuntoDeVenta();

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
          

           // splitContainer1.Panel2.Controls.Add(frmo);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmPuntoVenta frmo = frmPuntoVenta.GetInstance();
            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;

                frmo.Show();


               
            }
            else
            {
                if (frmo.tieneVentaPendiente)
                {
                    if (MessageBox.Show("Tiene una venta pendiente, ¿Aún asi desea iniciar una nueva venta?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmo.Limpiar();
                    }
                }
                else
                {
                    frmo.Limpiar();
                }
                
            }
           

            if (mdiParenAux == null)
            {
                mdiParenAux = frmo.MdiParent;
            }

            HabilitarMenu();

        }

        private void AbrirPuntoDeVenta()
        {
            frmApartadosList frmo = frmApartadosList.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
               
                if (mdiParenAux == null)
                {
                    mdiParenAux = frmo.MdiParent;
                }
               
            }

           
        }

        private void button4_Click(object sender, EventArgs e)
        {

            AbrirPuntoDeVenta();
            frmReimprimirTicket f = new frmReimprimirTicket();
            f.Text = "Buscar Ticket";
            f.StartPosition = FormStartPosition.CenterParent;            
            f.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            oContext = new ERPProdEntities();

            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if (entity.ReqClaveSupCancelaTicketPV ?? false)
            {
                frmAutorizacion frm = new frmAutorizacion();
                frm.puntoVentaContext = this.puntoVentaContext;
                frm.opcionLlamado = (int)Enumerados.opcionesPV.cancelarTicket;
                frm.ShowDialog();
            }
            else
            {
                cancelar();
            }

           
        }

        public void cancelar()
        {
            AbrirPuntoDeVenta();
            frmPuntoVenta frmo = frmPuntoVenta.GetInstance();
            if (!frmo.Visible)
            {
                MessageBox.Show("Es necesario primero buscar el ticket a cancelar", "ERROR");
            }
            else
            {
                frmo.Cancelar();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            oContext = new ERPProdEntities();

            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if (entity.ReqClaveSupReimpresionTicketPV ?? false)
            {
                frmAutorizacion frm = new frmAutorizacion();
                frm.puntoVentaContext = this.puntoVentaContext;
                frm.opcionLlamado = (int)Enumerados.opcionesPV.reimpresionTicket;
                frm.ShowDialog();
            }
            else
            {
                frmReimprimirTicket frm = new frmReimprimirTicket();
                frm.esReimpresion = true;
                frm.MdiParent = this;
                frm.Show();
            }

           
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {

            oContext = new ERPProdEntities();

            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if (entity.ReqClaveSupGastosPV ?? false)
            {
                frmAutorizacion frm = new frmAutorizacion();
                frm.puntoVentaContext = this.puntoVentaContext;
                frm.opcionLlamado = (int)Enumerados.opcionesPV.registroGastos;
                frm.ShowDialog();
            }
            else
            {
                abrirGastos();
            }

           
        }

        public void abrirGastos()
        {
            frmGastosList frmo = frmGastosList.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;
                frmo.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();

            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if (entity.RetiroReqClaveSup ?? false)
            {
                frmAutorizacion frm = new frmAutorizacion();
                frm.puntoVentaContext = this.puntoVentaContext;
                frm.opcionLlamado = 1;
                frm.ShowDialog();
            }
            else {
                frmRetiros frm = new frmRetiros();
                frm.puntoVentaContext = this.puntoVentaContext;
                frm.ShowDialog();
            }

           
        }

        public void HabilitarDeshabilitarMenu(bool nuevaVenta,bool reimpresiones,bool cancelaciones,bool buscarTicket,bool listaPrecio,bool retiroEfectivo,bool gastos)
        {
            //uiNuevaVenta.Enabled = nuevaVenta;
            uiReimpresiones.Enabled = reimpresiones;
            uiCancelaciones.Enabled = cancelaciones;
            uiBuscarTicket.Enabled = buscarTicket;
            //uiListaPrecios.Enabled = listaPrecio;
            //uiRetiroEfectivo.Enabled = retiroEfectivo;
            //uiGastos.Enabled = gastos;

        }

        public void HabilitarMenu()
        {
            //uiNuevaVenta.Enabled = true;
            uiReimpresiones.Enabled = true;
            uiCancelaciones.Enabled = true;
            uiBuscarTicket.Enabled = true;
            //uiListaPrecios.Enabled = true;
            //uiRetiroEfectivo.Enabled = true;
            //uiGastos.Enabled = true;

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

            frmCorteCaja frmo = frmCorteCaja.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;
                frmo.Show();
            }
        }

        //public void CorteCaja(List<DeclaracionFondoModel> denominaciones)
        //{
        //    try
        //    {
        //        oContext = new ERPEntities();
        //        DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
        //        ObjectParameter pCorteCajaId = new ObjectParameter("pCorteCajaId", 0);

        //        using (TransactionScope scope = new TransactionScope())
        //        {
                    
        //            oContext.p_corte_caja_generacion(this.puntoVentaContext.cajaId, this.puntoVentaContext.usuarioId, fechaActual, pCorteCajaId);

        //            foreach (DeclaracionFondoModel item in denominaciones)
        //            {
        //                if (item.total > 0)
        //                {
        //                    oContext.doc_corte_caja_denominaciones_ins(int.Parse(pCorteCajaId.Value.ToString()), item.clave, item.cantidad, item.valor, item.total, this.puntoVentaContext.usuarioId);
        //                }                       

        //            }
        //            scope.Complete();
        //            MessageBox.Show("El corte de caja se generó con éxito", "AVISO");                  

        //        }

        //        rptCorteCaja oCorte = new rptCorteCaja();
        //        ReportViewer oViewer = new ReportViewer();

        //        oCorte.DataSource = oContext.p_rpt_corte_caja_enc(int.Parse(pCorteCajaId.Value.ToString())).ToList();
        //        oCorte.esAdmin = this.puntoVentaContext.esSupervisor;
        //        oViewer.ShowTicket(oCorte);
        //        //oViewer.Show();

        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
        //        MessageBox.Show(message, "ERROR");

        //    }
        //}

        public void CorteCaja(List<DeclaracionFondoModel> denominaciones,bool permitirCorteCero)
        {
            try
            {
                oContext = new ERPProdEntities();
                DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                ObjectParameter pCorteCajaId = new ObjectParameter("pCorteCajaId", 0);
                oContext.p_corte_caja_generacion(this.puntoVentaContext.cajaId, this.puntoVentaContext.usuarioId, fechaActual, pCorteCajaId,permitirCorteCero);

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
               


                rptCorteCaja oCorte = new rptCorteCaja();
                ReportViewer oViewer = new ReportViewer();

                oCorte.DataSource = oContext.p_rpt_corte_caja_enc(int.Parse(pCorteCajaId.Value.ToString())).ToList();
                oCorte.esAdmin = this.puntoVentaContext.esSupervisor;
                oViewer.ShowTicket(oCorte);
                //oViewer.Show();

                MessageBox.Show("El corte de caja se generó con éxito", "AVISO");

                #region enviar por correo

                List<System.Net.Mail.Attachment> attachmentList = new List<System.Net.Mail.Attachment>();
                ActiveReportExportTo exportTool = new ActiveReportExportTo();

                #region obtener corte de caja
                oCorte.DataSource = oContext.p_rpt_corte_caja_enc(int.Parse(pCorteCajaId.Value.ToString())).ToList();
                oCorte.esAdmin = this.puntoVentaContext.esSupervisor;

               
                Stream pdfStream = new System.IO.MemoryStream();
                pdfStream = exportTool.ToPDF(oCorte);

                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(pdfStream,"Corte_de_Caja.pdf", "application/pdf");
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
                else {
                    Mail oMail = new Mail(entity.ServidorMailSMTP, entity.ServidorMailFrom,int.Parse(entity.ServidorMailPort.ToString()), entity.ServidorMailPassword);

                    //Obtener los usuarios de tipo supervisor general
                    //List<cat_usuarios> usuarios = oContext.cat_usuarios.Where(w=> w.EsSupervisor == true && w.Email != "" && w.Email != null).ToList();
                    cat_configuracion entityConf = oContext.cat_configuracion.FirstOrDefault();

                    string emailEnvio = "";

                    if (entityConf != null)
                    {
                        emailEnvio = entityConf.SuperEmail1 != null ? entityConf.SuperEmail1 +";": "";
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
                    else {
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

        private void uiDevoluciones_Click(object sender, EventArgs e)
        {

            oContext = new ERPProdEntities();

            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if (entity.ReqClaveSupDevolucionPV ?? false)
            {
                frmAutorizacion frm = new frmAutorizacion();
                frm.puntoVentaContext = this.puntoVentaContext;
                frm.opcionLlamado = (int)Enumerados.opcionesPV.devoluciones;
                frm.ShowDialog();
            }
            else
            {
                abrirDevoluciones();
            }

           
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

        private void uiApartados_Click(object sender, EventArgs e)
        {


            oContext = new ERPProdEntities();

            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if (entity.ReqClaveSupApartadoPV ?? false)
            {
                frmAutorizacion frm = new frmAutorizacion();
                frm.puntoVentaContext = this.puntoVentaContext;
                frm.opcionLlamado = (int)Enumerados.opcionesPV.apartados;
                frm.ShowDialog();
            }
            else
            {
                abrirApartados();
            }
            
        }

        public void abrirApartados()
        {
            
            frmApartadosList frmo = frmApartadosList.GetInstance();

            if (!frmo.Visible)
            {
                this.Activate();
                //frmo = new frmPuntoVenta();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;
               
                frmo.Show();
            }
        }



        

        private void btnCerrarSesion_Click_1(object sender, EventArgs e)
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
            else {
                this.Close();
            }
        }

        private void frmMenuTA_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


        public void abrirExistencias()
        {
            frmExistenciasAgrupado frmo = frmExistenciasAgrupado.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;
                frmo.Show();
            }
        }
        private void btnExistencias_Click(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();

            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if (entity.ReqClaveSupExistenciaPV ?? false)
            {
                frmAutorizacion frm = new frmAutorizacion();
                frm.puntoVentaContext = this.puntoVentaContext;
                frm.opcionLlamado = (int)Enumerados.opcionesPV.existencias;
                frm.ShowDialog();
            }
            else
            {
                abrirExistencias();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
            this.Close();
        }
    }
}
