using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Common;
using ERP.Common.Procesos;
using ERP.Common.Reports;
using ERP.Reports;
using PuntoVenta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.PuntoVenta
{
    public partial class frmCorteCajaGen : Form
    {
        int err;
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmCorteCajaGen _instance;
        public static frmCorteCajaGen GetInstance()
        {

            if (_instance == null) _instance = new frmCorteCajaGen();
            return _instance;
        }
        public frmCorteCajaGen()
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

        public bool generarCorteCaja(bool imprimirCorte,bool cerrarSistema=true)
        {
            try
            {
                oContext = new ERPProdEntities();
                DateTime fechaAct = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                /********Validar si hay pedidos pendientes************************/
                if (oContext.doc_pedidos_orden
                    .Where(w =>
                    w.SucursalId == (int)puntoVentaContext.sucursalId &&
                    w.doc_pedidos_orden_programacion.Count() > 0 
                    
                     &&
                    w.Activo == true &&
                    w.VentaId == null &&
                    w.TipoPedidoId == (int)ERP.Business.Enumerados.tipoPedido.PedidoTelefono &&
                    (w.Cancelada??false) == false
                    )
                    .Count() > 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Existen pedidos sin cerrar, es necesario cancelarlos para poder continuar");
                    return false;
                }


                /*********Validar si existen movimientos para corte**************/
                bool permitirCorteCeros = false;
                ObjectParameter pHayMovs = new ObjectParameter("pHayMovimientos", false);
               
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
                        else
                        {
                            return false;
                        }

                    }
                    else
                    {
                        return false;
                    }


                }

                if (MessageBox.Show("¿Está seguro(a) de generar el CORTE DE CAJA?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    oContext = new ERPProdEntities();
                    cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

                    bool requiereDeclaracion = (this.puntoVentaContext.esSupervisor ? (entity.SupDeclaracionFondoCorte ?? false) : (entity.CajDeclaracionFondoCorte ?? false)) 
                        || ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                this.puntoVentaContext.sucursalId,
                "PVCorteCajaOcultarDetalleCajero", this.puntoVentaContext.usuarioId);

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
                                frm.tipo = "corteCaja";
                                frm.imprimirCorte = imprimirCorte;
                                frm.cerrarSistema = cerrarSistema;
                                var resultDF = frm.ShowDialog();
                                if(resultDF == DialogResult.OK)
                                {
                                    return true;
                                }
                               
                            }
                            else
                            {
                                frmMenuRest.GetInstance().puntoVentaContext = this.puntoVentaContext;

                                if(oContext.sis_preferencias_empresa
                                    .Where(w=> w.sis_preferencias.Preferencia == "SoloEnviarEmailCorteCaja").Count() > 0) {
                                    imprimirCorte = false;
                                }
                                frmMenuRest.GetInstance().CorteCaja(null, permitirCorteCeros,imprimirCorte,cerrarSistema);
                                return true;
                            }

                        }
                    }



                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                 "ERP",
                                 this.Name,
                                 ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);


            }
            return false;
        }

        private void uiGenerar_Click(object sender, EventArgs e)
        {

            generarCorteCaja(true);
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

                    rptCorteCaja oCorte = new rptCorteCaja(this.puntoVentaContext.sucursalId);
                    ReportViewer oViewer = new ReportViewer(this.puntoVentaContext.cajaId);

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

                    oContext = new ERPProdEntities();
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
                            ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId, this.puntoVentaContext.sucursalId,
                                "CorteCajaEmail", this.puntoVentaContext.usuarioId, ref emailEnvio);
                            

                            if (emailEnvio.Length > 0)
                            {
                                string error = oMail.Send("Corte de Caja", emailEnvio, "CORTE DE CAJA", "", attachmentList);

                                if(error.Length > 0)
                                {
                                    ERP.Utils.MessageBoxUtil.ShowError(error);
                                }
                                else
                                {
                                    MessageBox.Show("El corte ha sido enviado nuevamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }

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
                ReportViewer oViewer = new ReportViewer(this.puntoVentaContext.cajaId);

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
