using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraReports.UI;
using ERP.Common.Forms;
using ERP.Common.Reports;
using ERP.Common.Utils;
using ERP.Models.Mesas;
using ERP.Reports;
using PuntoVenta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Procesos.Restaurante
{
    public partial class frmComandaNueva : Form
    {
        LoadingForm oFormLoading;
        string error = "";
        int copiasImpresion = 2;
        doc_pedidos_orden oPedidoSeleccionado = new doc_pedidos_orden();
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        List<MesaComboBoxModel> lstMesas;
        List<int> mesasId = new List<int>();
        private static frmComandaNueva _instance;
        int mesaId = 0;
        public static frmComandaNueva GetInstance()
        {
            if (_instance == null) _instance = new frmComandaNueva();
            return _instance;
        }

        public frmComandaNueva()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }


        private void llenarLkpComanda()
        {
            try
            {
                int sucursalId = puntoVentaContext.sucursalId;                

                //uiComanda.Properties.DataSource = oContext.cat_rest_comandas
                //    .Where(w => w.SucursalId == sucursalId
                //    && (
                //        w.doc_pedidos_orden_detalle.Count == 0
                //        ||
                //        (
                //            w.doc_pedidos_orden_detalle.Count > 0
                //        )

                //    )
                //    && w.Disponible
                //    ).OrderBy(o => o.Folio).ToList();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Ocurrió un error al obtener las comandas", "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void llenarLkpMesas()
        {
            try
            {
                oContext = new ERPProdEntities();
                int sucursalId = puntoVentaContext.sucursalId;

                
                this.lstMesas = oContext.cat_rest_mesas
                    .Where(w => w.SucursalId == sucursalId && w.Activo)
                    .Select(
                    s => new MesaComboBoxModel()
                    {
                        MesaId = s.MesaId,
                        Nombre = s.Nombre,
                        Abierta = s.doc_pedidos_orden_mesa
                                .Where(
                                    w => w.doc_pedidos_orden.Activo &&
                                    w.doc_pedidos_orden.VentaId == null
                                ).Count() > 0 ? true : false
                    })
                     .ToList();

                int iButton = 1;

                
                foreach (MesaComboBoxModel mesa in lstMesas)
                {
                    SimpleButton button = (SimpleButton)Controls.Find("simpleButton" + iButton.ToString(), true).FirstOrDefault();
                  
                    button.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;                   
                    button.LookAndFeel.UseDefaultLookAndFeel = false;
                    button.Text = mesa.Nombre;
                    button.AccessibleName = mesa.MesaId.ToString();
                   
                    button.Font = new Font("Arial", 13, FontStyle.Bold);
                    if (mesa.Abierta)
                    {
                        button.LookAndFeel.SkinName = "DevExpress Dark Style";
                        button.ForeColor = Color.White;

                    }
                    else
                    {
                        button.LookAndFeel.SkinName = "Skin";
                        button.ForeColor = Color.Black;
                    }

                    button.Click += Button_Click; // Agrega el evento click que manejará la acción
                    button.Enabled = true;

                    iButton++;
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Ocurrió un error al obtener las mesas", "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            oFormLoading.Show();
            limpiarSeccionMesa();

            SimpleButton button = (SimpleButton)sender;
            mesaId = int.Parse(button.AccessibleName);
            string nombreMesa = button.Text;

            // Abre la ventana de punto de venta y pasa los datos necesarios
            BuscarPedidoPorMesa( nombreMesa);


            oFormLoading.Hide();
        }
        private void llenarLkpMeseros()
        {
            try
            {

                //uiMesero.Properties.DataSource = oContext.rh_empleados
                //     .Where(w => w.Estatus == 1
                //     && w.rh_empleado_puestos.Where(s => s.PuestoId == 4/*Mesero*/).Count() > 0).ToList();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Ocurrió un error al obtener las mesas", "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmComandaNueva_Load(object sender, EventArgs e)
        {
            oFormLoading = new LoadingForm("Procesando...");
            frmPuntoVentaRest frmo = frmPuntoVentaRest.GetInstance();

            if (frmo.Visible)
            {
                frmo.Close();

            }

            llenarLkpMesas();
            llenarLkpComanda();
            llenarLkpMeseros();
            HabilitarBotonesMesa(false);
        }

        private void limpiarSeccionMesa()
        {
            oPedidoSeleccionado = new doc_pedidos_orden();
            uiMesaLabel.Text = "";
            uiGrid.DataSource = null;
            mesaId = 0;
        }

        private void HabilitarBotonesMesa(bool valor)
        {
            uiEditarCuenta.Enabled = valor;
            uiPagar.Enabled = valor;
            uiImprimirCuenta.Enabled = valor;

        }
        private void BuscarPedidoPorMesa(string mesa)
        {
            try
            {
               
                int[] indexmesas = new int[] { this.mesaId }; ;
                mesasId = new List<int>();
                mesasId.Add(mesaId);
                oContext = new ERPProdEntities();

                if (
                     oContext.doc_pedidos_orden_mesa
                                .Where(
                                    w => (
                                    w.doc_pedidos_orden.Activo == true &&
                                    w.doc_pedidos_orden.VentaId == null) &&
                                    w.MesaId == mesaId
                                ).Count() >0
                    )
                {
                    HabilitarBotonesMesa(true);
                    PedidoOrdenBusiness oPedido = new PedidoOrdenBusiness();                    

                    //int comandaId = uiComanda.EditValue != null ?
                    //   int.Parse(uiComanda.EditValue.ToString()) : 0;

                    int comandaId = 0;

                    int pedidoId = 0;

                    string error = oPedido.buscarCuenta(mesasId.ToArray(), comandaId, ref pedidoId);



                    if (error.Length > 0)
                    {
                        oPedidoSeleccionado = new doc_pedidos_orden();
                        XtraMessageBox.Show(error,
                       "ERROR",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    else
                    {
                        //AbrirPuntoDeVenta(pedidoId, mesasId.ToArray());
                        //this.Close();

                        oPedidoSeleccionado = oContext.doc_pedidos_orden
                            .Where(w => w.PedidoId == pedidoId).FirstOrDefault();
                        uiMesaLabel.Text = mesa;
                        loadGrid();
                      
                    }
                }
                else
                {

                    HabilitarBotonesMesa(false) ;
                    if (XtraMessageBox.Show("La mesa no tiene ninguna cuenta por pagar. ¿Desea crear una nueva cuenta para la mesa?","AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        AbrirPuntoDeVenta(0, mesasId.ToArray());
                        this.Close();

                    }
                }

                


            }
            catch (Exception)
            {
                XtraMessageBox.Show("Ocurrió un error en el proceso",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }
        }
        private void loadGrid()
        {
           
            uiGrid.DataSource = oPedidoSeleccionado.doc_pedidos_orden_detalle.Where(w=> (w.Cancelado??true) == false).ToList();
            uiTotal.Value = oPedidoSeleccionado.doc_pedidos_orden_detalle.Sum(s => s.Total);
        }
        private void uiContinuar_Click(object sender, EventArgs e)
        {
            
        }

        private void AbrirPuntoDeVenta(int pedidoId,int[] mesas)
        {
            frmPuntoVentaRest frmo = frmPuntoVentaRest.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = frmMenuRest.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.cuentaId = pedidoId;
                frmo.mesasIdInit = mesas;
                frmo.Show();
                
            }
            else
            {
                frmo.Show();
                frmo.nuevaCuenta(pedidoId);
            }


        }

       

        private void uiMesa_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            (sender as GridLookUpEdit).LookAndFeel.UpdateStyleSettings();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.puntoVentaContext != null)
            {
                ConexionBD.PedidoOrdenBusiness.ImpresionAutomaticaPedido(
                    this.puntoVentaContext.usuarioId, 
                    this.puntoVentaContext.sucursalId,
                    this.puntoVentaContext.cajaId);

            }
        }

        private void frmComandaNueva_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiActualizar_Click(object sender, EventArgs e)
        {

            Actualizar();
        }

        private void Actualizar()
        {
            limpiarSeccionMesa();

            llenarLkpMesas();
            llenarLkpComanda();
            llenarLkpMeseros();
        }

        private void simpleButton22_Click(object sender, EventArgs e)
        {
            if(oPedidoSeleccionado.PedidoId > 0)
            {
                uiPagar.Enabled = false;
                abrirFormasPago(oPedidoSeleccionado.PedidoId);
                Actualizar();

            }
            
        }

        public void abrirFormasPago(int pedidoId)
        {
            try
            {
                int cuentaid = pedidoId;


                if (cuentaid == 0)
                {
                    XtraMessageBox.Show("Es necesario abrir una cuenta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                //if (
                //  oContext.doc_pedidos_orden_detalle
                //  .Where(w => w.PedidoId == cuentaid
                //  && (w.Impreso ?? false) == false
                //  && (w.Cancelado ?? false) == false
                //  ).Count() > 0
                //  )
                //{
                //    XtraMessageBox.Show("Existen comandas sin imprimir, no es posible pagar la cuenta",
                //        "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    return;
                //}

                decimal total = oContext.doc_pedidos_orden_detalle.Where(w => w.PedidoId == cuentaid).Count() > 0 ?
                    oContext.doc_pedidos_orden_detalle.Where(w => w.PedidoId == cuentaid && (w.Cancelado ?? false) == false).Sum(S => S.Total) : 0;


                frmVentaFormasPagoDialog fpForm = new frmVentaFormasPagoDialog();
                fpForm.StartPosition = FormStartPosition.CenterScreen;
                fpForm.totalVenta = total;

                var resultDailog = fpForm.ShowDialog();

                if (resultDailog == DialogResult.OK)
                {
                    pagar(fpForm.lstFormasPago, new List<ValeFPModel>(), fpForm.lstFormasPago.Sum(s => s.cantidad) ?? 0, fpForm.cambio);
                
                }

                uiPagar.Enabled = true;
            }
            catch (Exception ex)
            {

                uiPagar.Enabled = true;
            }
           
            



        }


        public void pagar(List<FormaPagoModel> _formasPago, List<ValeFPModel> _vales, decimal totalRecibido, decimal cambio)
        {
            

            int _cuentaid = oPedidoSeleccionado.PedidoId;
            ConexionBD.PuntoVenta oData = new ConexionBD.PuntoVenta();

            List<doc_pedidos_orden_detalle> detalleVenta = oContext.doc_pedidos_orden_detalle.Where(w => w.PedidoId == _cuentaid && (w.Cancelado ?? false) == false).ToList();
            List<ProductoModel0> lstProductos = detalleVenta
                .Select(s => new ProductoModel0()
                {
                    cantidad = s.Cantidad,
                    clave = s.cat_productos.Clave,
                    descripcion = s.cat_productos.DescripcionCorta,
                    impuestos = s.Impuestos,
                    montoDescuento = s.Descuento,
                    partida = 0,
                    porcDescuento = s.PorcDescuento,
                    porcDescuentoPartida = s.PorcDescuento,
                    porcDescunetoVta = 0,
                    porcImpuestos = 0,
                    precioCompra = 0,
                    precioNeto = 0,
                    precioUnitario = s.PrecioUnitario,
                    productoId = s.ProductoId,
                    total = s.Total,
                    unidadId = s.cat_productos.ClaveVendidaPor ?? 0,
                    tipoDescuentoId = s.TipoDescuentoId ?? 0,
                    promocionCMId = s.PromocionCMId ?? 0,
                    cargoAdicionalId = s.CargoAdicionalId
                }
                ).ToList();

            decimal total = detalleVenta.Sum(S => S.Total);
            decimal totalDescuento = detalleVenta.Sum(s => s.Descuento);


            List<FormaPagoModel> lstFormasPago = _formasPago;
            long ventaId = 0;
            int? clienteId =  0;
            decimal descuentoPartidas = 0;// lstProductos.Sum(s => s.montoDescuento);
            string error = "";

            //error = guarClienteId(ref clienteId);

            if (error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR");
                return;
            }
            error = oData.pagar(ref ventaId, clienteId, "", 0, 0, descuentoPartidas, 0, totalDescuento, total,
                totalRecibido, cambio, false, puntoVentaContext.sucursalId, puntoVentaContext.usuarioId, puntoVentaContext.cajaId, lstProductos, lstFormasPago, _vales, _cuentaid, false);

            if (error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR");
                return;
            }
            else
            {
                //MessageBox.Show("La venta con FOLIO:" + uiFolio.Text + " se ha registrado con éxito");

                try
                {
                    error = RawPrinterHelper.AbreCajon(this.puntoVentaContext.nombreImpresoraCaja);
                    if (error.Length > 0)
                    {
                        XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = "";
                    }

                    cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault(); ;

                    if (total >= (entity.MontoImpresionTicket ?? 0))
                    {
                        if (entity.ImprimirTicketMediaCarta == true)
                        {
                            rptVentaTicket_CartaM oTicket1 = new rptVentaTicket_CartaM();


                            ReportViewer oViewer = new ReportViewer(this.puntoVentaContext, false);

                            oTicket1.DataSource = oContext.p_rpt_VentaTicket(int.Parse(ventaId.ToString())).ToList();

                            oViewer.ShowTicket(oTicket1);
                        }
                        else
                        {
                            rptVentaTicket oTicket2 = new rptVentaTicket();


                            ReportViewer oViewer = new ReportViewer(this.puntoVentaContext, false);

                            var resultRpt = oContext.p_rpt_VentaTicket(int.Parse(ventaId.ToString())).ToList();

                            oTicket2.DataSource = resultRpt;
                            oViewer.ShowTicket(oTicket2);

                            if (copiasImpresion > 1)
                            {
                                for (int i = 1; i < copiasImpresion; i++)
                                {
                                    oTicket2 = new rptVentaTicket();
                                    oViewer = new ReportViewer(this.puntoVentaContext, false);
                                    oTicket2.DataSource = resultRpt;
                                    oViewer.ShowTicket(oTicket2);
                                }
                            }


                        }


                        //oViewer.Show();
                    }



                }
                catch (Exception ex)
                {
                    uiPagar.Enabled = true;
                    MessageBox.Show("Ocurrió un error al intentar imprimir el ticket." + ex.Message, "ERROR");
                }


                frmComandaNueva frmo = frmComandaNueva.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    frmo.MdiParent = frmMenuRest.GetInstance();
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.StartPosition = FormStartPosition.CenterParent;
                    frmo.WindowState = FormWindowState.Normal;
                    frmo.Show();


                }
                //nuevaCuenta();

                limpiarSeccionMesa();

                //frmMenuRest.GetInstance().AbrirComanda();


            }


        }


        private void uCargoTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                error = ConexionBD.PedidoOrdenBusiness.CargoPorTarjeta(this.puntoVentaContext.empresaId,
               this.puntoVentaContext.sucursalId,
               this.oPedidoSeleccionado.PedidoId, this.puntoVentaContext.usuarioId, !uCargoTarjeta.Checked);

                if (error.Length > 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowError(error);
                }
                else
                {
                    BuscarPedidoPorMesa(this.uiMesaLabel.Text);
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                     "ERP",
                                     this.Name,
                                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
            
        }

        public void imprimirCuenta()
        {
            try
            {
                if(oPedidoSeleccionado.PedidoId == 0)
                {
                    return;
                }
                int pedidoId = oPedidoSeleccionado.PedidoId;

                if (pedidoId == 0)
                {
                    XtraMessageBox.Show("Es necesario abrir una cuenta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                error = ConexionBD.PedidoOrdenBusiness.CargoPorTarjeta(this.puntoVentaContext.empresaId,
                    this.puntoVentaContext.sucursalId,
                    pedidoId,
                    this.puntoVentaContext.sucursalId, !uCargoTarjeta.Checked);

                if (error.Length > 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowError(error);
                    return;
                }

                cat_configuracion conf = oContext.cat_configuracion.FirstOrDefault();


                rptCuenta oReport = new rptCuenta();
               

                List<p_rpt_cuenta_Result> lstResult = oContext.p_rpt_cuenta(pedidoId).ToList();

                if (lstResult.Count > 0)
                {
                    oReport.DataSource = lstResult;
                    oReport.CreateDocument();

                    if (conf.vistaPreviaImpresion == true)
                    {
                        oReport.ShowPreview();
                    }
                    else
                    {
                        oReport.Print(conf.NombreImpresora);
                    }



                    //this.Close();

                    //frmMenuRest.GetInstance().AbrirComanda();


                }
                else
                {
                    XtraMessageBox.Show("No hay información pendiente de imprimir",
                      "ERROR",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                }




            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message,
                      "ERROR",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);

            }
        }

        private void uiImprimirCuenta_Click(object sender, EventArgs e)
        {
            imprimirCuenta();
        }

        private void uiEditarCuenta_Click(object sender, EventArgs e)
        {
            if (oPedidoSeleccionado.PedidoId == 0)
            {
                return;
            }

            AbrirPuntoDeVenta(oPedidoSeleccionado.PedidoId, mesasId.ToArray());
            limpiarSeccionMesa();


        }
    }
}
