using ConexionBD;
using ConexionBD.Models;
using ERP.Business.Tools;
using ERP.Common.Base;
using ERP.Common.Productos;
using ERP.Models.Pedidos;
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

namespace ERP.Common.PuntoVenta
{
    public partial class frmBasculaExpressVenta : FormBaseXtraForm
    {
        int err = 0;
        public bool esNuevaVenta;
        bool listoParaPagar = false;
        private static frmBasculaExpressVenta _instance;
        Models.Pedidos.PedidoDetalleModel pedidoSeleccionado;
        BasculaLectura basculaControlador;
        cat_basculas_configuracion basculaConfiguracion;
        public bool habilitarRedireccionarPV { get; set; }//Si está activa, se habilitará un botónpara un vez registrada la báscula, redireccionar al PV
        public string tipoForm { get; set; }
        public cat_productos productoNuevo { get; set; }
        public bool listoAgregarProducto { get; set; }
        public static frmBasculaExpressVenta GetInstance()
        {
            if (_instance == null) _instance = new frmBasculaExpressVenta();
            else _instance.BringToFront();
            return _instance;
        }

        public frmBasculaExpressVenta()
        {
            InitializeComponent();

            pedidoSeleccionado = new Models.Pedidos.PedidoDetalleModel();
        }
        #region metodos

        private List<Models.Pedidos.PedidoDetalleModel> GetPedidosPendientes(bool soloPedidosMayoreo = false, int pedidoId = 0)
        {
            try
            {
                List<Models.Pedidos.PedidoDetalleModel> result = oContext.p_doc_pedidos_ordenes_detalle_sel(puntoVentaContext.sucursalId, DateTime.Now, DateTime.Now,
                    soloPedidosMayoreo ? (int)ERP.Business.Enumerados.tipoPedido.PedidoClienteMayoreo : 3)
                    .Select(s => new Models.Pedidos.PedidoDetalleModel()
                    {
                        folio = s.PedidoId.ToString(),
                        pedidoDetalleId = s.PedidoDetalleId,
                        cantidad = s.Cantidad,
                        clave = s.Clave,
                        descripcion = s.Descripcion,
                        pedidoId = s.PedidoId,
                        total = s.Total,
                        precioUnitario = s.PrecioUnitario,
                        productoId = s.ProductoId,
                        registradoPor = s.RegistradoPor,
                        cliente = s.Cliente,
                        cantidadPendienteBascula = s.CantidadPendienteBascula ?? 0,
                        tipoPedidoId = s.TipoPedidoId ?? 0,
                        fechaEntrega = s.FechaProgramada ?? DateTime.MinValue,
                        horaEntrega = s.HoraProgramada ?? new TimeSpan(),
                        basculaPendiente = s.CantidadPendienteBascula > 0 ? true : false,
                        ventaId = s.VentaId,
                        TipoCaja = s.TipoCaja,
                        requiereBascula = s.RequiereBascula ?? false,
                        totalDetalle = s.TotalDetalle

                    }).ToList();


                return result.Where(w =>
                (pedidoId == 0 || w.pedidoId == pedidoId) &&
                ((w.basculaPendiente && !uiMostrarPedidoSinVenta.Checked) ||
                (uiMostrarPedidoSinVenta.Checked && (w.ventaId) == 0)) && 
                (w.TipoCaja.ToUpper().Contains("MOVIL") || w.TipoCaja.ToUpper().Contains("EN SUCURSAL"))
                ).ToList();


            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                   "ERP",
                                   this.Name,
                                   ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }

            return null;
        }
        public void LoadPedidos(int pedidoId = 0)
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();

                if (tipoForm == "PRODUCCION")
                {
                    uiGridPedidos.DataSource = GetPedidosPendientes(true, pedidoId);
                }
                else
                {
                    uiGridPedidos.DataSource = GetPedidosPendientes(false, pedidoId);
                }

                uiGridView.ExpandAllGroups();


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



        private void PrepararSiguienteProductoBascula(int PedidoDetalleId = 0)
        {
            try
            {
                List<Models.Pedidos.PedidoDetalleModel> lstPedidos = (List<Models.Pedidos.PedidoDetalleModel>)uiGridPedidos.DataSource;

                if (lstPedidos.Count > 0)
                {
                    if (PedidoDetalleId == 0)
                    {
                        pedidoSeleccionado = lstPedidos.Where(w => w.cantidadPendienteBascula > 0).OrderBy(o => o.pedidoId)
                            .FirstOrDefault();
                    }
                    else
                    {
                        pedidoSeleccionado = lstPedidos.Where(w => w.pedidoDetalleId == PedidoDetalleId).OrderBy(o => o.pedidoId).FirstOrDefault();
                    }

                    if (pedidoSeleccionado != null)
                    {
                        if (pedidoSeleccionado.requiereBascula == true)
                        {
                            timerBascula.Enabled = false;
                            uiClaveProducto.EditValue = pedidoSeleccionado.clave;
                            uiPedido.Text = pedidoSeleccionado.pedidoId.ToString();
                            uiProducto.Text = String.Format("{0}-{1}", pedidoSeleccionado.clave, pedidoSeleccionado.descripcion);
                            uiCantidad.EditValue = pedidoSeleccionado.cantidad;
                            uiTotal.EditValue = pedidoSeleccionado.total;
                            uiCantidadPendiente.EditValue = pedidoSeleccionado.cantidadPendienteBascula;
                            uiCliente.Text = pedidoSeleccionado.cliente;
                            uiPrecio.EditValue = pedidoSeleccionado.precioUnitario;

                            if (pedidoSeleccionado.pedidoDetalleId > 0)
                            {
                                if (puntoVentaContext.conectarConBascula)
                                {
                                    basculaControlador.abrirBascula();
                                }

                                timerBascula.Enabled = true;
                            }
                        }

                    }


                }



            }
            catch (Exception ex)
            {
                basculaControlador = new BasculaLectura(this.puntoVentaContext);
                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                   "ERP",
                                                   this.Name,
                                                   ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        #endregion

        private void frmBasculaExpress_Load(object sender, EventArgs e)
        {
            ERP.Business.DataMemory.DataBucket.GetProductosMemory(true);
            basculaConfiguracion = Business.BasculasBusiness.GetConfiguracionPCLocal(puntoVentaContext.usuarioId,
                puntoVentaContext.sucursalId);
            basculaControlador = new BasculaLectura(this.puntoVentaContext);

            LoadPedidos();
            PrepararSiguienteProductoBascula();

            colCobrarPV.Visible = false;


        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void timerBascula_Tick(object sender, EventArgs e)
        {

            try
            {
                if (this.puntoVentaContext.conectarConBascula)
                {
                    uiPeso.EditValue = basculaControlador.ObtenPesoSinDefault();
                }
                else
                {
                    if (basculaControlador == null)
                    {
                        basculaControlador = new BasculaLectura(this.puntoVentaContext);
                    }
                    uiPeso.EditValue = basculaControlador.ObtenPesoBD();
                }

            }
            catch (Exception ex)
            {
                timerBascula.Enabled = false;

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private bool tienePendienteBascula()
        {
            var lstPedidos = (List<PedidoDetalleModel>)uiGridPedidos.DataSource;

            if (pedidoSeleccionado == null)
            {
                pedidoSeleccionado = new PedidoDetalleModel();
            }
            return lstPedidos.Where(w =>
                         w.pedidoId == pedidoSeleccionado.pedidoId &&
                         w.basculaPendiente).Count() > 0 ? true : false;

        }
        private void Guardar()
        {
            try
            {
                //uiGuardar.Enabled = false;
                timerBascula.Enabled = false;
                timerBascula2.Enabled = false;
                if (puntoVentaContext.conectarConBascula)
                {
                    basculaControlador.cerrarBascula();
                }

                if (pedidoSeleccionado != null)
                {

                    //if (
                    // (pedidoSeleccionado.cantidad -
                    // (ConexionBD.PedidoOrdenBusiness.ObtenerCantidadRegistradaEnBascula(pedidoSeleccionado.pedidoDetalleId, puntoVentaContext.usuarioId) +
                    // uiPeso.Value))
                    //    < -(ERP.Business.BasculasBusiness.rangoTolerancia)
                    // )
                    //{
                    //    ERP.Utils.MessageBoxUtil.ShowWarning("El peso sobrepasa lo requerido en la órden");
                    //    uiGuardar.Enabled = true;
                    //    return;
                    //}

                    //if (
                    //    (ConexionBD.PedidoOrdenBusiness.ObtenerCantidadRegistradaEnBascula(pedidoSeleccionado.pedidoDetalleId, puntoVentaContext.usuarioId) +
                    //    uiPeso.Value)
                    //    < pedidoSeleccionado.cantidad

                    // )
                    //{
                    //    ERP.Utils.MessageBoxUtil.ShowWarning("El peso es menor a lo requerido en la órden");
                    //    uiGuardar.Enabled = true;
                    //    return;
                    //}

                    if (uiPeso.Value == 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("El peso debe de ser mayor a cero");
                        uiGuardar.Enabled = true;
                        return;
                    }

                    if (basculaConfiguracion == null)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("La configuración de la báscula no está completada");
                        uiGuardar.Enabled = true;
                        return;
                    }


                    doc_basculas_bitacora resultBitacora = Business.BasculasBusiness.InsertBitacora(basculaConfiguracion.BasculaId, puntoVentaContext.sucursalId,
                   puntoVentaContext.usuarioId, Convert.ToDecimal(uiPeso.EditValue),
                   (int)pedidoSeleccionado.tipoPedidoId == (int)ERP.Business.Enumerados.tipoPedido.PedidoClienteMayoreo ? (int)Business.Enumerados.tipoBasculaBitacora.VentaPedidoMayoreo : (int)Business.Enumerados.tipoBasculaBitacora.VentaMostrador,
                   pedidoSeleccionado.productoId, pedidoSeleccionado.pedidoDetalleId);

                    if (resultBitacora.Id > 0)
                    {

                        //Si el Ultimo Pedido ya no tiene pendientes, entonces ir a cobrar automáticamente
                        LoadPedidos();
                        if (!tienePendienteBascula())
                        {
                            lblMensaje.Text = "PAGANDO...";
                            uiGuardar.Enabled = false;
                            pagar();

                        }
                        else
                        {


                            PrepararSiguienteProductoBascula();
                        }


                    }
                    else
                    {
                        ERP.Utils.MessageBoxUtil.ShowError("Ocurrió un error inesperado, revisa la bitácora del sistema");
                    }

                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario seleccionar un Pedido");
                }

                uiGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                uiGuardar.Enabled = true;

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                     "ERP",
                                     this.Name,
                                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }



        private void Limpiar()
        {
            pedidoSeleccionado = null;
            uiCantidad.EditValue = 0;
            uiPeso.EditValue = 0;
            uiPedido.Text = "";
            uiProducto.Text = "";
            uiTotal.Text = "";
            uiCantidad.Text = "";
            uiTotalBascula.Text = "";
            uiCantidadPendiente.EditValue = 0;
            listoParaPagar = false;
            lyMensaje.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lblMensaje.Text = "";
            productoNuevo = null;
            uiPrecio.EditValue = 0;
            uiClaveProducto.Text = "";
            listoAgregarProducto = false;
            timerBascula.Enabled = false;
            timerBascula2.Enabled = false;
            
            esNuevaVenta = false;
        }

        private void frmBasculaExpress_FormClosing(object sender, FormClosingEventArgs e)
        {

            basculaControlador.cerrarBascula();
            _instance = null;
        }

        private void uiActualizar_Click(object sender, EventArgs e)
        {
            LoadPedidos();

        }

        private void SeleccionarGridFila()
        {
            try
            {

                Models.Pedidos.PedidoDetalleModel itemGrid = (Models.Pedidos.PedidoDetalleModel)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                if (itemGrid != null)
                {

                    PrepararSiguienteProductoBascula(itemGrid.pedidoDetalleId);

                    if (!tienePendienteBascula())
                    {
                        listoParaPagar = false;
                        pagar();
                    }



                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowError("Ocurrió un poblema al intentar obtener el registro");
                }







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
        private void repBtnSeleccion_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SeleccionarGridFila();
        }

        private void uiPeso_Properties_ValueChanged(object sender, EventArgs e)
        {
            calcularTotalBascula();
        }
        private void calcularTotalBascula()
        {
            try
            {
                if (pedidoSeleccionado != null)
                {
                    uiTotalBascula.EditValue = uiPeso.Value * pedidoSeleccionado.precioUnitario;
                }

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

        private void uiPeso_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {


        }

        private void uiPeso_Leave(object sender, EventArgs e)
        {
            calcularTotalBascula();
        }

        private void timerLoadPedidos_Tick(object sender, EventArgs e)
        {
            if ((pedidoSeleccionado == null ? new Models.Pedidos.PedidoDetalleModel() : pedidoSeleccionado).pedidoDetalleId == 0 && timerBascula.Enabled == false)
            {
                LoadPedidos();
                PrepararSiguienteProductoBascula();
            }
        }

        private void uiLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void uiGridView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {


                if (Convert.ToString(uiGridView.GetRowCellValue(e.RowHandle, "cliente")).Length > 0)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                if(Convert.ToString(uiGridView.GetRowCellValue(e.RowHandle, "TipoCaja"))!= "")
                {
                    if (Convert.ToString(uiGridView.GetRowCellValue(e.RowHandle, "TipoCaja")).ToUpper() != "MOVIL")
                    {
                        e.Appearance.BackColor = Color.Green;
                        e.Appearance.ForeColor = Color.White;

                    }
                }
               

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

        private void frmBasculaExpress_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                LoadPedidos();
            }
        }

        private void frmBasculaExpress_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmBasculaExpress_KeyDown(object sender, KeyEventArgs e)
        {

        }

        public bool validarVenta()
        {
            try
            {
                Models.Pedidos.PedidoDetalleModel pedidoGridSelect = (Models.Pedidos.PedidoDetalleModel)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                if (pedidoGridSelect != null)
                {
                    List<Models.Pedidos.PedidoDetalleModel> lstPedidoGridSelect = (List<Models.Pedidos.PedidoDetalleModel>)uiGridView.DataSource;

                    if (lstPedidoGridSelect.Where(w => w.pedidoId == pedidoGridSelect.pedidoId && w.cantidadPendienteBascula > 0).Count() > 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("Hay productos que requieren báscula aún pendientes");
                        return false;
                    }

                }


                return true;
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                  "ERP",
                                  this.Name,
                                  ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);

                return false;
            }
        }


        private void repBtnCobrarPV_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (validarVenta())
            {
                frmPedidoPagoCajaList oForm = new frmPedidoPagoCajaList();

                oForm.puntoVentaContext = this.puntoVentaContext;
                oForm.ShowDialog();
            }
        }

        private void uiMostrarPedidoSinVenta_CheckedChanged(object sender, EventArgs e)
        {
            LoadPedidos();
        }
        private void calcularCambio()
        {
            try
            {
                uiCambio.EditValue = (uiRecibi.Value - uiTotal2.Value) < 0 ? 0 : (uiRecibi.Value - uiTotal2.Value);
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
        private void pagar()
        {
            try
            {
                if (!tienePendienteBascula())
                {
                    lyMensaje.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lblMensaje.Text = "LISTO PARA PAGAR";
                    if (!listoParaPagar)
                    {
                        uiTotal2.EditValue = pedidoSeleccionado.total;
                        uiRecibi.ReadOnly = false;
                        uiRecibi.EditValue = pedidoSeleccionado.total;
                        uiRecibi.Focus();
                        uiRecibi.SelectAll();
                        listoParaPagar = true;
                    }
                    else
                    {
                        registrarVenta();
                    }

                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("EXISTEN ARTICULOS CON BÁSCULA PENDIENTE");
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

        private void uiPagar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "PAGANDO....";
            pagar();
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiRecibi_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            calcularCambio();
        }

        private void uiRecibi_EditValueChanged(object sender, EventArgs e)
        {
            calcularCambio();
        }

        private void uiRecibi_Leave(object sender, EventArgs e)
        {
            calcularCambio();
        }

        public void registrarVenta()
        {

            if (!validarVenta())
            {
                return;
            }
            doc_pedidos_orden pedidoPago = oContext.doc_pedidos_orden
                .Where(w => w.PedidoId == pedidoSeleccionado.pedidoId).FirstOrDefault();

            List<FormaPagoModel> formasPago = new List<FormaPagoModel>();
            List<ProductoModel0> lstProductos = pedidoPago
                .doc_pedidos_orden_detalle
                .Where(w => (w.Cancelado ?? false) == false)
                .Select(s => new ProductoModel0()
                {
                    cantidad = s.Cantidad,
                    productoId = s.ProductoId,
                    total = s.Total,
                    tieneBascula = s.cat_productos.ProdVtaBascula ?? false,
                    precioUnitario = s.PrecioUnitario

                }).ToList();

            formasPago.Add(new FormaPagoModel() { cantidad = Convert.ToDecimal(uiRecibi.EditValue), id = 1, descripcion = "EFECTIVO" });

            long ventaId = 0;
            int? clienteId = null;
            string error = "";

            ConexionBD.PuntoVenta oData = new ConexionBD.PuntoVenta();

            error = ERP.Business.VentasBusiness.pagar(ref ventaId, clienteId, "", 0, 0, 0, lstProductos.Sum(s => s.impuestos),
                lstProductos.Sum(s => s.total) - lstProductos.Sum(s => s.impuestos), uiTotal2.Value,
                Convert.ToDecimal(uiRecibi.EditValue), Convert.ToDecimal(uiCambio.EditValue), false,
                puntoVentaContext.sucursalId,
                puntoVentaContext.usuarioId,
                puntoVentaContext.cajaId, lstProductos, formasPago, new List<ValeFPModel>(), pedidoSeleccionado.pedidoId);

            if (error.Length > 0)
            {
                uiGuardar.Enabled = false;
                ERP.Utils.MessageBoxUtil.ShowError(error);

                return;
            }
            else

                Limpiar();
            LoadPedidos();
            PrepararSiguienteProductoBascula();
            uiTotal2.EditValue = 0;
            uiCambio.EditValue = 0;
            uiRecibi.EditValue = 0;

            uiGuardar.Enabled = true;
            return;

        }




        public void seleccionarProducto(string clave, decimal cantidad)
        {
            try
            {
                if (productoNuevo != null)
                {
                    uiProducto.Text = productoNuevo.Descripcion;
                    uiCantidad.EditValue = cantidad;
                    uiClaveProducto.EditValue = clave;
                    uiPrecio.EditValue = ERP.Business.ProductoBusiness.ObtenerPrecio(productoNuevo.ProductoId,
                         Business.Enumerados.tipoPrecioProducto.PublicoGeneral, puntoVentaContext.usuarioId, puntoVentaContext.sucursalId);
                    uiTotal.EditValue = cantidad * uiPrecio.Value;
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
        public void agregarProducto()
        {
            try
            {
                if(pedidoSeleccionado == null && !esNuevaVenta)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Necesita especificar si es nueva venta o seleccionar algún pedido");
                    return;
                }
                
                if (pedidoSeleccionado.pedidoId == 0)
                {
                    doc_pedidos_orden entityNew = new doc_pedidos_orden();
                    entityNew.PedidoId = (oContext.doc_pedidos_orden.Max(m => (int?)m.PedidoId) ?? 0)+1;
                    entityNew.Activo = true;
                    entityNew.CajaId = this.puntoVentaContext.cajaId;
                    entityNew.Cancelada = false;
                    entityNew.CreadoEl = DateTime.Now;
                    entityNew.CreadoPor = this.puntoVentaContext.usuarioId;
                    entityNew.FechaApertura = DateTime.Now;
                    entityNew.Folio = ConexionBD.PedidoOrdenBusiness.ObtenerFolioPorTipo(Business.Enumerados.tipoPedido.PedidoVentaCaja, this.puntoVentaContext.sucursalId);
                    entityNew.Impuestos = 0;
                    entityNew.Subtotal = 0;
                    entityNew.Total = 0;
                    entityNew.FechaCierre = DateTime.Now;
                    entityNew.TipoPedidoId = (int)Business.Enumerados.tipoPedido.PedidoVentaCaja;
                    entityNew.SucursalId = this.puntoVentaContext.sucursalId;

                    oContext.doc_pedidos_orden.Add(entityNew);

                    oContext.SaveChanges();
                    pedidoSeleccionado.pedidoId = entityNew.PedidoId;
                   
                }

                DateTime date = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                doc_pedidos_orden_detalle oPedidoDetalle = new doc_pedidos_orden_detalle();

                oPedidoDetalle.PedidoId = pedidoSeleccionado.pedidoId;
                oPedidoDetalle.PedidoDetalleId = (oContext.doc_pedidos_orden_detalle.Max(m => (int?)m.PedidoDetalleId) ?? 0) + 1;
                oPedidoDetalle.Cantidad = Convert.ToDecimal(uiCantidad.Text);
                oPedidoDetalle.CreadoEl = date;
                oPedidoDetalle.CreadoPor = this.puntoVentaContext.usuarioId;
                oPedidoDetalle.Descripcion = uiProducto.Text;
                oPedidoDetalle.PrecioUnitario = ERP.Business.ProductoBusiness.ObtenerPrecio(productoNuevo.ProductoId, Business.Enumerados.tipoPrecioProducto.PublicoGeneral,
                    puntoVentaContext.usuarioId, puntoVentaContext.sucursalId);
                oPedidoDetalle.Total = oPedidoDetalle.Cantidad * oPedidoDetalle.PrecioUnitario;
                oPedidoDetalle.Impuestos = 0;
                oPedidoDetalle.ProductoId = productoNuevo.ProductoId;
                oContext.doc_pedidos_orden_detalle.Add(oPedidoDetalle);
                oContext.SaveChanges();

                oContext.p_doc_pedidos_orden_total_upd(oPedidoDetalle.PedidoId);

                if (productoNuevo.ProdVtaBascula == true)
                {
                    Business.BasculasBusiness.InsertBitacora(basculaConfiguracion.BasculaId, puntoVentaContext.sucursalId,
                   puntoVentaContext.usuarioId, oPedidoDetalle.Cantidad,
                   (int)pedidoSeleccionado.tipoPedidoId == (int)ERP.Business.Enumerados.tipoPedido.PedidoClienteMayoreo ? (int)Business.Enumerados.tipoBasculaBitacora.VentaPedidoMayoreo : (int)Business.Enumerados.tipoBasculaBitacora.VentaMostrador,
                   oPedidoDetalle.ProductoId, oPedidoDetalle.PedidoDetalleId);
                }

                Limpiar();
                LoadPedidos(oPedidoDetalle.PedidoId);
              
                PrepararSiguienteProductoBascula();



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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if(pedidoSeleccionado == null)
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario seleccionar un pedido para continuar o seleccionar nueva venta");
                return;
            }
            else
            {
                if(pedidoSeleccionado.pedidoId == 0 && !esNuevaVenta)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario seleccionar un pedido para continuar o seleccionar nueva venta");
                    return;
                }
            }

            frmProductosMosaico oForm = new frmProductosMosaico(this.puntoVentaContext, Business.Enumerados.tipoModalProducto.venta);
            oForm.StartPosition = FormStartPosition.CenterScreen;
            DialogResult result = oForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                var producto = oForm.resultForm;

                productoNuevo = new cat_productos()
                {
                    ProductoId = producto.productoId,
                    Descripcion = producto.descripcion,
                    DescripcionCorta = producto.descripcion,
                    Clave = producto.clave,
                    cat_unidadesmed = new cat_unidadesmed()
                    {
                        Clave = producto.unidadId,
                        Descripcion = producto.unidad,
                        DescripcionCorta = producto.unidad
                    },
                    ProdVtaBascula = producto.requiereBascula

                };
                seleccionarProducto(producto.clave, producto.cantidad);
                agregarProducto();

            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (listoAgregarProducto)
            {
                agregarProducto();
            }
            else
            {
                Guardar();
            }

        }
        private void habilitarEdicionCantidad(bool enable)
        {
            uiCantidad.Enabled = enable;
            uiClaveProducto.Enabled = enable;
            uiCantidad.ReadOnly = !enable;
            uiClaveProducto.Enabled = !enable;
        }

        private void uiBuscarProducto_Click(object sender, EventArgs e)
        {
            if (pedidoSeleccionado == null)
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario seleccionar un pedido para continuar o seleccionar nueva venta");
                return;
            }
            else
            {
                if (pedidoSeleccionado.pedidoId == 0 && !esNuevaVenta )
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario seleccionar un pedido para continuar o seleccionar nueva venta");
                    return;
                }
            }

            frmProductosBusqueda frmBuscar = new frmProductosBusqueda();
            frmBuscar.soloParaVenta = true;
            frmBuscar.puntoVentaContext = this.puntoVentaContext;
            frmBuscar.cargarEnInicio = false;
            var result = frmBuscar.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (frmBuscar.response != null)
                {
                    string clave = frmBuscar.response.CodigoBarras;

                    uiClaveProducto.EditValue = clave;

                    productoNuevo = ERP.Business.DataMemory.DataBucket.GetProductosMemory(false)
                        .Where(w => w.Clave == clave).FirstOrDefault();

                    

                    seleccionarProducto("", 1);
                    habilitarEdicionCantidad(true);
                    if(productoNuevo.ProdVtaBascula == true)
                    {
                        timerBascula2.Enabled = true;
                    }
                    uiCantidad.Focus();
                    listoAgregarProducto = true;

                }


            }
        }

        private void eliminarDetalle()
        {
            try
            {
                PedidoDetalleModel row = (PedidoDetalleModel)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                if (row != null)
                {
                    doc_pedidos_orden_detalle oDelete = oContext.doc_pedidos_orden_detalle
                        .Where(w => w.PedidoDetalleId == row.pedidoDetalleId).FirstOrDefault();

                    #region eliminar Bitacora
                    oContext.Database.ExecuteSqlCommand(@"
                                UPDATE doc_basculas_bitacora
                                SET PedidoDetalleId = NULL
                                Where PedidoDetalleId = {0}", oDelete.PedidoDetalleId);
                    #endregion

                    oContext.doc_pedidos_orden_detalle.Remove(oDelete);
                    oContext.SaveChanges();


                    oContext = new ERPProdEntities();
                    oContext.p_doc_pedidos_orden_total_upd(oDelete.PedidoId);

                    LoadPedidos(oDelete.PedidoId);
                    PrepararSiguienteProductoBascula();
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

        private void repDelete_Click(object sender, EventArgs e)
        {
            eliminarDetalle();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Limpiar();
            LoadPedidos();
            PrepararSiguienteProductoBascula();
        }

        private void uiRecibi_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                lblMensaje.Text = "PAGANDO....";
                pagar();
            }
        }

        private void uiCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                agregarProducto();
            }
        }

        private void uiNuevaVenta_Click(object sender, EventArgs e)
        {
            esNuevaVenta = true;
            pedidoSeleccionado = new PedidoDetalleModel();  
            this.lblMensaje.Text = "NUEVA VENTA (AGREGA LOS PRODUCTOS)";
            lyMensaje.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void uiGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            SeleccionarGridFila();
        }

        private void timerBascula2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.puntoVentaContext.conectarConBascula)
                {
                    uiPeso.EditValue = basculaControlador.ObtenPesoSinDefault();
                }
                else
                {
                    if (basculaControlador == null)
                    {
                        basculaControlador = new BasculaLectura(this.puntoVentaContext);
                    }
                    uiCantidad.EditValue = basculaControlador.ObtenPesoBD();
                }

            }
            catch (Exception ex)
            {
                timerBascula.Enabled = false;

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
    }


}
