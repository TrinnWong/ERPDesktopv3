using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Pedido
{
    public partial class frmRepartosTortillaCaptura : FormBaseXtraForm
    {
        private static frmRepartosTortillaCaptura _instance;
        int err = 0;
        string error = "";
        public static frmRepartosTortillaCaptura GetInstance()
        {
            if (_instance == null) _instance = new frmRepartosTortillaCaptura();
            else _instance.BringToFront();
            return _instance;
        }

        public frmRepartosTortillaCaptura()
        {
            InitializeComponent();
        }

        private void frmRepartosTortillaCaptura_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void frmRepartosTortillaCaptura_Load(object sender, EventArgs e)
        {
            try
            {
                oContext = new ERPProdEntities();
                uiFecha.DateTime = DateTime.Now;
                uiSucursal.Text = puntoVentaContext.nombreSucursal;
                uiCliente.Properties.DataSource = oContext.cat_clientes
                    .Where(w => w.SucursalBaseId == puntoVentaContext.sucursalId).ToList();
                LoadProductos();
                uiTortillaKilos.Select();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                 "ERP",
                                                 this.Name,
                                                 ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            uiGuardar.Enabled = false;
            uiSalir.Enabled = false;
            Guardar();
            
        }

        private void LoadProductos()
        {
            try
            {
                int clienteId = Convert.ToInt32(uiCliente.EditValue);
                var lstPrecios = oContext.doc_clientes_productos_precios
                    .Where(w=> w.ClienteId == clienteId).ToList();
                

                if(lstPrecios.Where(w=> w.ProductoId == 1).Count() > 0)
                {
                    uiPrecioTortilla.Value = lstPrecios.Where(w => w.ProductoId == 1).Max(v=> v.Precio) ?? 0;
                 
                }

                if (lstPrecios.Where(w => w.ProductoId == 2).Count() > 0)
                {
                    uiPrecioMasa.Value = lstPrecios.Where(w => w.ProductoId == 2).Max(v => v.Precio) ?? 0;


                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                 "ERP",
                                                 this.Name,
                                                 ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        
        private void Guardar()
        {
            try
            {
                #region validaciones
                if(uiFecha.DateTime.Date < DateTime.Now.Date)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("No es posible registrar repartos de días anteriores");
                    uiGuardar.Enabled = true;
                    uiSalir.Enabled = true;
                    return;
                }
                if(uiCliente.EditValue == null)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("El cliente es requerido");
                    uiGuardar.Enabled = true;
                    uiSalir.Enabled = true;
                    return;
                }
                if(uiTortillaKilos.Value < 0 || uiTortillaKilosDev.Value <0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Los kilos de Tortilla/Devolución no pueden ser negativos");
                    uiGuardar.Enabled = true;
                    uiSalir.Enabled = true;
                    return;
                }
                if (uiMasaKilos.Value < 0 || uiMasaKilosDev.Value < 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Los kilos de Masa/Devolución no pueden ser negativos");
                    uiGuardar.Enabled = true;
                    uiSalir.Enabled = true;
                    return;
                }
                if(uiTortillaKilosDev.Value > uiTortillaKilos.Value || uiMasaKilosDev.Value > uiMasaKilos.Value)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Los kilos de Devolución no pueden ser mayor a los de reparto");
                    uiGuardar.Enabled = true;
                    uiSalir.Enabled = true;
                    return;
                }
                #endregion

                List<ProductoModel0> lstPedido = new List<ProductoModel0>();
                ProductoModel0 oPedidoDetalle = new ProductoModel0();

                //Tortilla
                oPedidoDetalle.cantidad = uiTortillaKilos.Value - uiTortillaKilosDev.Value;
                oPedidoDetalle.cantidadCobroReparto = uiTortillaKilos.Value - uiTortillaKilosDev.Value;
                oPedidoDetalle.cantidadDevolucion = uiTortillaKilosDev.Value;
                oPedidoDetalle.cantidadFinalReparto = uiTortillaKilos.Value - uiTortillaKilosDev.Value;
                oPedidoDetalle.cantidadOriginal = uiTortillaKilos.Value;
                oPedidoDetalle.clave = "1";
                oPedidoDetalle.descripcion = "TORTILLA";
                oPedidoDetalle.impuestos = 0;
                oPedidoDetalle.montoDescuento = 0;
                oPedidoDetalle.precioUnitario = uiPrecioTortilla.Value;
                oPedidoDetalle.productoId = 1;
                oPedidoDetalle.tieneBascula = false;
                oPedidoDetalle.total = oPedidoDetalle.cantidad * oPedidoDetalle.precioUnitario;
                oPedidoDetalle.unidadId = oContext.cat_productos.Where(w => w.ProductoId == 1).FirstOrDefault().cat_unidadesmed.Clave;
                lstPedido.Add(oPedidoDetalle);

                oPedidoDetalle = new ProductoModel0();
                //Masa
                oPedidoDetalle.cantidad = uiMasaKilos.Value - uiMasaKilosDev.Value;
                oPedidoDetalle.cantidadCobroReparto = uiMasaKilos.Value - uiMasaKilosDev.Value;
                oPedidoDetalle.cantidadDevolucion = uiMasaKilosDev.Value;
                oPedidoDetalle.cantidadFinalReparto = uiMasaKilos.Value - uiMasaKilosDev.Value;
                oPedidoDetalle.cantidadOriginal = uiMasaKilos.Value;
                oPedidoDetalle.clave = "2";
                oPedidoDetalle.descripcion = "MASA";
                oPedidoDetalle.impuestos = 0;
                oPedidoDetalle.montoDescuento = 0;
                oPedidoDetalle.precioUnitario = uiPrecioMasa.Value;
                oPedidoDetalle.productoId = 2;
                oPedidoDetalle.tieneBascula = false;
                oPedidoDetalle.total = oPedidoDetalle.cantidad * oPedidoDetalle.precioUnitario;
                oPedidoDetalle.unidadId = oContext.cat_productos.Where(w => w.ProductoId == 2).FirstOrDefault().cat_unidadesmed.Clave;
                lstPedido.Add(oPedidoDetalle);

                //Guardar

                doc_pedidos_orden pedido = new doc_pedidos_orden();
                pedido.ClienteId = Convert.ToInt32(uiCliente.EditValue);
                pedido.SucursalId = puntoVentaContext.sucursalId;

                PedidoOrdenBusiness oPedido = new PedidoOrdenBusiness();

                pedido = oPedido.GuardarPedido(pedido, ERP.Business.Enumerados.tipoPedido.PedidoTelefono,
                   lstPedido, puntoVentaContext.usuarioId, puntoVentaContext.sucursalId, ref error,false,true);

                if(error.Length == 0)
                {
                    List<FormaPagoModel> formasPago = new List<FormaPagoModel>();

                    formasPago.Add(new FormaPagoModel() { cantidad = uiTotal.Value, id = 1, descripcion = "EFECTIVO" });

                    long ventaId = 0;
                    int? clienteId = pedido.ClienteId;
                    decimal descuentoPartidas = lstPedido.Sum(s => s.montoDescuento);
                    error = "";

                    ConexionBD.PuntoVenta oData = new ConexionBD.PuntoVenta();

                    error = ERP.Business.VentasBusiness.pagar(ref ventaId, clienteId, "", 0,
                        lstPedido.Sum(s => s.montoDescuento),
                        lstPedido.Sum(s => s.montoDescuento), lstPedido.Sum(s => s.impuestos),
                        lstPedido.Sum(s => s.total) - lstPedido.Sum(s => s.impuestos),
                        uiTotal.Value,
                        uiTotal.Value, 0,
                        lstPedido.Sum(s => s.montoDescuento) > 0 ? true : false,
                        puntoVentaContext.sucursalId,
                        puntoVentaContext.usuarioId,
                        puntoVentaContext.cajaId, lstPedido, formasPago, new List<ValeFPModel>(), pedido.PedidoId,
                        false, false,null,true);

                    if (error.Length > 0)
                    {
                        XtraMessageBox.Show(error, "ERROR");
                        return;
                    }
                    else
                    {
                        oContext = new ERPProdEntities();
                        //ASEGURARSE QUE EL PEDIDO TENGA VENTA LIGADA                    
                        ERP.Reports.rptPedidoDevolucion oTicketPedido = new ERP.Reports.rptPedidoDevolucion();


                        ERP.Common.Reports.ReportViewer oViewerPedido = new ERP.Common.Reports.ReportViewer(this.puntoVentaContext.cajaId);
                        oContext = new ERPProdEntities();
                        oTicketPedido.DataSource = oContext.p_rpt_pedido_orden_sel(pedido.PedidoId).ToList();

                        oViewerPedido.ShowTicket(oTicketPedido);

                        #region registrar mov Bascula

                        #endregion
                        oContext = new ERPProdEntities();
                        cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

                        if (uiTotal.Value >= (entity.MontoImpresionTicket ?? 0))
                        {
                            if (entity.ImprimirTicketMediaCarta == true)
                            {
                                ERP.Reports.rptVentaTicket_CartaM oTicket1 = new ERP.Reports.rptVentaTicket_CartaM();


                                ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer(this.puntoVentaContext.cajaId);

                                oTicket1.DataSource = oContext.p_rpt_VentaTicket((int?)ventaId).ToList();

                                oViewer.ShowTicket(oTicket1);
                            }
                            else
                            {
                                ERP.Reports.rptVentaTicket oTicket2 = new ERP.Reports.rptVentaTicket();


                                ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer(this.puntoVentaContext.cajaId);

                                oTicket2.DataSource = oContext.p_rpt_VentaTicket((int?)ventaId).ToList();

                                oViewer.ShowTicket(oTicket2);
                            }


                            //oViewer.Show();
                        }

                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                }
                else
                {
                    uiGuardar.Enabled = true;
                    uiSalir.Enabled = true;
                    ERP.Utils.MessageBoxUtil.ShowError(error);
                    return;
                }
               

            }
            catch (Exception ex)
            {
                uiGuardar.Enabled = true;
                uiSalir.Enabled = true;
                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                "ERP",
                                                this.Name,
                                                ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        

        private void CalculaTotales()
        {
            try
            {
                uiTotalTortilla.Value = (uiTortillaKilos.Value - uiTortillaKilosDev.Value) * uiPrecioTortilla.Value;
                uiTotalMasa.Value = (uiMasaKilos.Value - uiMasaKilosDev.Value) * uiPrecioMasa.Value;
                uiTotal.Value = uiTotalMasa.Value + uiTotalTortilla.Value;
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                 "ERP",
                                                 this.Name,
                                                 ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

       

        private void uiCliente_EditValueChanged(object sender, EventArgs e)
        {
            LoadProductos();
            uiTortillaKilos.Select();
        }

        private void uiMasaKilosDev_Validating(object sender, CancelEventArgs e)
        {
            CalculaTotales();
        }

        private void uiTortillaKilos_Validating(object sender, CancelEventArgs e)
        {
            CalculaTotales();
        }

        private void uiTortillaKilosDev_Validating(object sender, CancelEventArgs e)
        {
            CalculaTotales();
        }

        private void uiMasaKilos_Validating(object sender, CancelEventArgs e)
        {
            CalculaTotales();
        }

        private void uiSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiTortillaKilos_KeyUp(object sender, KeyEventArgs e)
        {
            CalculaTotales();
        }

        private void uiTortillaKilosDev_KeyUp(object sender, KeyEventArgs e)
        {
            CalculaTotales();
        }

        private void uiMasaKilos_KeyUp(object sender, KeyEventArgs e)
        {
            CalculaTotales();
        }

        private void uiMasaKilosDev_KeyUp(object sender, KeyEventArgs e)
        {
            CalculaTotales();
        }
    }
}
