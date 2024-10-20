﻿using ConexionBD;
using ConexionBD.Models;
using ERP.Common;
using ERP.Common.Procesos;
using ERP.Reports;
using PuntoVenta.Reports;
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
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class frmCorteCaja : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmCorteCaja _instance;
        public static frmCorteCaja GetInstance()
        {

            if (_instance == null) _instance = new frmCorteCaja();
            else _instance.BringToFront();
            return _instance;
        }
        public frmCorteCaja()
        {
            InitializeComponent();
            this.uiGrid.Columns[2].DefaultCellStyle.Format = "c2";
            this.uiGrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void uiSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCorteCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        #region metodos
        private void llenarGrid()
        {
            uiGrid.AutoGenerateColumns = false;
            oContext = new ERPProdEntities();
            uiGrid.DataSource = oContext.p_doc_corte_caja_grd(puntoVentaContext.sucursalId, puntoVentaContext.usuarioId,
                uiDel.Value, uiAl.Value).ToList();
            

        }
        #endregion

        private void frmCorteCaja_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void uiGenerar_Click(object sender, EventArgs e)
        {

            try
            {
                /*********Validar si existen movimientos para corte**************/
                bool permitirCorteCeros = false;
                ObjectParameter pHayMovs = new ObjectParameter("pHayMovimientos", false);
                DateTime fechaAct = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                string validaMovs = oContext.p_corte_caja_validaMovs(this.puntoVentaContext.cajaId, 
                    this.puntoVentaContext.usuarioId
                    , fechaAct, pHayMovs).FirstOrDefault();

                if (validaMovs.Length > 0)
                {
                    MessageBox.Show(validaMovs, "ERROR");
                    if (bool.Parse(pHayMovs.Value.ToString()) == false)
                    {
                        if (
                            MessageBox.Show(
                                "¿Desea permitir corte en ceros?",
                                 "Aviso",
                                  MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question
                                ) == DialogResult.Yes)
                                {
                            permitirCorteCeros = true;
                        }
                        else {
                            return;
                        }
                            
                    }
                    else {
                        return;
                    }
                    
                    
                }

                if (MessageBox.Show("¿Está seguro de continuar?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    oContext = new ERPProdEntities();
                    cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

                    bool requiereDeclaracion = this.puntoVentaContext.esSupervisor ? (entity.SupDeclaracionFondoCorte ?? false) : (entity.CajDeclaracionFondoCorte ?? false);

                    //bool reqClave = oContext.cat_configuracion.FirstOrDefault().CajeroReqClaveSupervisor ?? false;
                    if (entity != null)
                    {
                        if (entity.CajeroReqClaveSupervisor ?? false)
                        {
                            frmAutorizacion frm = new frmAutorizacion();
                            frm.puntoVentaContext = this.puntoVentaContext;
                            frm.opcionLlamado = requiereDeclaracion ? 3 : 2;
                            frm.ShowDialog();
                        }
                        else
                        {
                            if (requiereDeclaracion)
                            {
                                frmDeclaracionFondo frm = new frmDeclaracionFondo();
                                frm.puntoVentaContext = this.puntoVentaContext;

                                frm.ShowDialog();
                            }
                            else
                            {
                                frmMenu.GetInstance().CorteCaja(null,permitirCorteCeros);
                            }

                        }
                    }



                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void uiReimprimir_Click(object sender, EventArgs e)
        {
            reimprimir();
        }

        private void uiBuscar_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }
        private void reimprimir()
        {
            try
            {
                int i = uiGrid.CurrentCell.RowIndex;

                if (i >= 0)
                {
                    int corteId = int.Parse(uiGrid.Rows[i].Cells["ID"].Value.ToString());

                    rptCorteCaja oCorte = new rptCorteCaja();
                    ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer();

                    oCorte.DataSource = oContext.p_rpt_corte_caja_enc(corteId).ToList();
                    oCorte.esAdmin = this.puntoVentaContext.esSupervisor;
                    oViewer.ShowTicket(oCorte);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void reenviar()
        {
            try
            {
                #region enviar por correo

                int i = uiGrid.CurrentCell.RowIndex;

                if (i >= 0)
                {
                    int corteId = int.Parse(uiGrid.Rows[i].Cells["ID"].Value.ToString());

                    rptCorteCaja oCorte = new rptCorteCaja();
                    ReportViewer oViewer = new ReportViewer();

                    oCorte.DataSource = oContext.p_rpt_corte_caja_enc(corteId).ToList();
                    oCorte.esAdmin = this.puntoVentaContext.esSupervisor;
               

                    List<System.Net.Mail.Attachment> attachmentList = new List<System.Net.Mail.Attachment>();
                    ActiveReportExportTo exportTool = new ActiveReportExportTo();
                    Stream pdfStream = new System.IO.MemoryStream();
                    pdfStream = exportTool.ToPDF(oCorte);

                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(pdfStream, "Corte_de_Caja.pdf", "application/pdf");
                    attachmentList.Add(attachment);

                    int sucursalId = puntoVentaContext.sucursalId;

                    cat_sucursales entity = oContext.cat_sucursales.Where(w => w.Clave == sucursalId).FirstOrDefault();

                    if ((entity.ServidorMailSMTP == null ? "" : entity.ServidorMailSMTP)  =="")
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

                                MessageBox.Show("El corte ha sido enviado nuevamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reenviar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                ObjectParameter pCorteCajaId = new ObjectParameter("pCorteCajaId", 0);
                oContext.p_corte_caja_generacion_previo(puntoVentaContext.cajaId,
                    puntoVentaContext.usuarioId, fecha, pCorteCajaId, true);


                reimprimirPrevio(int.Parse(pCorteCajaId.Value.ToString()));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //ERP.Common.Procesos.frmCorteCajaPrevioList oForm = new frmCorteCajaPrevioList();
            //oForm.puntoVentaContext = this.puntoVentaContext;
            //oForm.ShowDialog();
        }

        private void reimprimirPrevio(int corteCaja)
        {
            try
            {
                int corteId = corteCaja;

                rptCorteCajaPrevioV2 oCorte = new rptCorteCajaPrevioV2();
                ReportViewer oViewer = new ReportViewer();

                oCorte.DataSource = oContext.p_rpt_corte_caja_enc_previo(corteId).ToList();
                oCorte.esAdmin = this.puntoVentaContext.esSupervisor;
                oViewer.ShowTicket(oCorte);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
