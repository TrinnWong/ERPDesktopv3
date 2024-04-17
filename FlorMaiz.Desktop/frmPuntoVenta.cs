using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Business;
using ERP.Business.DataMemory;
using ERP.Business.Tools;
using ERP.Common.Base;
using ERP.Common.Catalogos;
using ERP.Common.Dialogos;
using ERP.Common.Forms;
using ERP.Common.Pedido;
using ERP.Common.Productos;
using ERP.Common.PuntoVenta;
using ERP.Common.Seguridad;
using ERP.Models.CalculoConta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ERP.Business.Enumerados;

namespace PuntoVenta.Desktop
{
    public partial class frmPuntoVenta : FormBaseXtraForm
    {
        LoadingForm oFormLoading;
        int productoDefaultId = 0;
        SerialPort portBascula;
        List<ProductoModel0> lstProductos;
        bool desactivarBotonesTouch=false;
        int idTortilla = 118;
        int idMasa = 118;
        int idProductoSel = 0;
        int numBotonesFam = 12;
        int numBotonesProd = 18;
        cat_productos productoSeleccionado;
        bool capturaMontoManual = false;
        bool pagando = false;
        cat_basculas_configuracion configBascula;
        private static frmPuntoVenta _instance;
        int err=0;
        BasculaLectura basculaControlador;
        doc_pedidos_orden pedido;
        PedidoOrdenBusiness oPedido;
        string error = "";
        private bool solicitarRecibido=true;
        cat_configuracion entityConfig = null;
        decimal valorImrpesionTicket = 0;
        bool imprimirTicket = false;
        bool pesoInteligenteLecturaLocal = false;
        bool desvincularBascula = false;
        public static frmPuntoVenta GetInstance()
        {
            if (_instance == null) _instance = new frmPuntoVenta();
            else _instance.BringToFront();
            return _instance;
        }
        public frmPuntoVenta()
        {
            InitializeComponent();
            
        }

        private void uiGrid_Click(object sender, EventArgs e)
        {

        }

       
        private void frmPuntoVenta_Load(object sender, EventArgs e)
        {
            try
            {
                oFormLoading = new LoadingForm("Procesando...");
                LoadClientes();
                entityConfig = oContext.cat_configuracion.FirstOrDefault();
                oPedido = new PedidoOrdenBusiness();
                basculaControlador = new BasculaLectura(this.puntoVentaContext);
                ConfigurarColoresBotones();
                LlenarBotonesFamilias();
                LoadFormasPago();
                inicializar();
                limpiar();

                if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                    this.puntoVentaContext.sucursalId, "DesactivarBotonesProductosTouchPV", this.puntoVentaContext.usuarioId))
                {
                    desactivarBotonesTouch = true;
                }

                LlenarBotonesProducto("uiFamilia1");

                if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                   this.puntoVentaContext.sucursalId, "PVExcluirReibido", this.puntoVentaContext.usuarioId))
                {
                    solicitarRecibido = false;
                }

                if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                   this.puntoVentaContext.sucursalId, "HabilitarCambioPrecioEnVenta", this.puntoVentaContext.usuarioId))
                {
                    colCambioPrecio.Visible = true;
                }
                else
                {
                    colCambioPrecio.Visible = false;

                }

                //VALIDAR PREFERENCIA BOTÓN PEDIDOS APP
                if(ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                   this.puntoVentaContext.sucursalId, "PVBotonRegistroBasculaPedidosApp", this.puntoVentaContext.usuarioId))
                {
                    uiLayoutBotonPedidosApp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                  
                }
                else
                {
                    uiLayoutBotonPedidosApp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                   
                }
                
                if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                   this.puntoVentaContext.sucursalId, "PVProductoDefault", this.puntoVentaContext.usuarioId,ref error))
                {
                    if(error.Length > 0)
                    {
                       productoDefaultId=  DataBucket.GetProductosMemory(false).Where(w => w.Clave == error).FirstOrDefault().ProductoId;
                    }
                }
                if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                   this.puntoVentaContext.sucursalId, "PV-ImprimirTicket", this.puntoVentaContext.usuarioId, ref error))
                {
                    imprimirTicket = true;
                    if (error.Length > 0)
                    {
                        valorImrpesionTicket = Convert.ToInt32(error);
                    }
                }
                if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                   this.puntoVentaContext.sucursalId, "UsarPesoInteligente", this.puntoVentaContext.usuarioId, ref error))
                {
                    abrirTareaBascula();
                }

                HabilitarBasculaSiNo();
                

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

        #region  métodos
        private void abrirTareaBascula()
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
        public void inicializar()
        {
            try
            {
                if (puntoVentaContext.conectarConBascula)
                {
                    configBascula = BasculasBusiness.GetConfiguracionPCLocal(puntoVentaContext.usuarioId, puntoVentaContext.sucursalId);
                    if (configBascula != null)
                    {
                        portBascula = new SerialPort(configBascula.PortName);
                        portBascula.BaudRate = configBascula.BaudRate;
                        portBascula.ReadBufferSize = configBascula.ReadBufferSize;
                        portBascula.WriteBufferSize = configBascula.WriteBufferSize;
                        portBascula.DataBits = 8;
                        portBascula.DiscardNull = true;
                        portBascula.ParityReplace = 63;
                        portBascula.Parity = Parity.None;

                    }
                    else
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("No será posible utilziar la báscula, falta la configuración");
                    }
                }                
                uiTipoCortesia.EditValue = 0;
                oContext = new ERPProdEntities();
                idProductoSel = 0;
                lstProductos = new List<ProductoModel0>();
                uiGrid.DataSource = lstProductos;
                uiGridView.RefreshData();
                productoSeleccionado = null;
                capturaMontoManual = false;
                pedido = new doc_pedidos_orden();
                uiCliente.EditValue = null;
                uiClave.Select();
                uiClave.SelectAll();
                uiPagar.Enabled = true;
                

               
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

        private void ConfigurarColoresBotones()
        {
            try
            {
                
                for (int i = 1; i <= numBotonesFam; i++)
                {
                    Control controlA = Controls.Find("uiFamilia" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        SimpleButton btnFam = (SimpleButton)controlA;

                        btnFam.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                        btnFam.LookAndFeel.UseDefaultLookAndFeel = false;
                        btnFam.BackColor = Color.LightSkyBlue;
                        btnFam.Padding = new Padding(5);
                    }
                }
                for (int i = 1; i <= numBotonesProd; i++)
                {
                    Control controlA = Controls.Find("uiProducto" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        SimpleButton btnFam = (SimpleButton)controlA;

                        btnFam.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                        btnFam.Font = new Font("Arial", 13, FontStyle.Bold);
                        btnFam.ForeColor = Color.Black;
                        
                        btnFam.LookAndFeel.UseDefaultLookAndFeel = false;
                        //btnFam.BackColor = Color.Black;
                        btnFam.Padding = new Padding(5);
                        btnFam.Text = "";
                        
                       
                    }
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
        private void abrirBascula()
        {
            try
            {
                if (puntoVentaContext.conectarConBascula)
                {
                    if (!portBascula.IsOpen)
                    {
                        portBascula.Open();
                        timer1.Enabled = true;

                    }
                }
                else
                {
                    timer1.Enabled = true;
                }
               
            }
            catch (Exception ex)
            {
                uiPesoVal.ReadOnly = false;
                uiPesoVal.Focus();
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMain.GetInstance().puntoVentaContext.usuarioId,
                                      "ERP",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowError("ERROR AL INTENTAR ABRIR LA BÁSCULA, REVISE LA CONFIGURACIÓN:"+err);
            }
        }
        private void cerrarBascula()
        {
            try
            {
                if (puntoVentaContext.conectarConBascula)
                {
                    if (portBascula.IsOpen)
                    {
                        portBascula.Close();
                        timer1.Enabled = false;
                    }
                }
                else
                {
                    basculaControlador.cerrarBascula();
                    timer1.Enabled = false;
                }
               
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMain.GetInstance().puntoVentaContext.usuarioId,
                                      "ERP",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowError("ERROR AL INTENTAR ABRIR LA BÁSCULA, REVISE LA CONFIGURACIÓN:" + err);
            }
        }

        private void leerBascula()
        {
            try
            {
                if (desvincularBascula)
                    return;

                if (puntoVentaContext.conectarConBascula)
                {
                    if (portBascula.IsOpen)
                    {
                        portBascula.Write("P");
                        string value = portBascula.ReadExisting();

                        value = value.Replace("Kg", "").Replace("+", "").Replace("KG", "").Replace("kg", "");

                        decimal cantidad = 0;


                        decimal.TryParse(value, out cantidad);

                        uiPesoVal.EditValue = cantidad;



                    }
                }
                else
                {
                    if (puntoVentaContext.usarTareaBascula)
                    {
                        if (pesoInteligenteLecturaLocal)
                        {
                            uiPesoVal.EditValue = basculaControlador.ObtenPesoBDLocal();
                        }
                        else
                        {
                            uiPesoVal.EditValue = basculaControlador.ObtenPesoBD();
                        }
                        
                    }
                    
                }
                
                
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMain.GetInstance().puntoVentaContext.usuarioId,
                                      "ERP",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowError("ERROR AL INTENTAR ABRIR LA BÁSCULA, REVISE LA CONFIGURACIÓN:" + err);
            }
        }
        private void agregarProducto()
        {
            try
            {
                cat_productos producto =productoSeleccionado;

                //Validar activo
                if(producto == null)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("El producto no está activo");
                    return;
                }

                //validar precio 
                if (uiPrecioProducto.Value == 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("El producto no tiene precio");
                    return;
                }


                if (producto.ProdVtaBascula == true)
                {
                    if(Convert.ToDecimal(uiPesoVal.EditValue) == 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("El peso no puede ser 0");
                        return;
                    }
                }
                else
                {
                    if (Convert.ToDecimal(uiMontoManual.EditValue) == 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("El monto no puede ser 0");
                        return;
                    }

                }

                ImporteDesgloceModel impuestos = null;
                ProductoModel0 productoItem = new ProductoModel0();

                productoItem.partida = lstProductos.Count + 1;
                productoItem.productoId = producto.ProductoId;
                productoItem.descripcion = producto.DescripcionCorta;
                productoItem.total = uiPrecioProducto.Value * BasculasBusiness.ObtenerValorPorRangoGramos(Convert.ToDecimal(uiPesoVal.EditValue)) ;//Convert.ToDecimal(uiPesoVal.EditValue);
                productoItem.precioUnitario = uiPrecioProducto.Value;
                productoItem.clave = producto.Clave;
                productoItem.cantidad = Convert.ToDecimal(uiPesoVal.EditValue);
                productoItem.tieneBascula =  producto.ProdVtaBascula ?? false;
                if (producto.cat_productos_impuestos.Count > 0)
                {
                    impuestos = ERP.Utils.CalculosContaTool.DesgloceImpuestos(productoItem.total,
                       producto.cat_productos_impuestos.Sum(s => s.cat_impuestos.Porcentaje ?? 0));
                    productoItem.impuestos = impuestos.impuestos;                    
                    productoItem.precioNeto = productoItem.total - impuestos.impuestos;
                }

                

                lstProductos.Add(productoItem);

                uiGrid.DataSource = lstProductos.OrderByDescending(o=> o.partida);
                uiGridView.RefreshData();
                uiGrid.Refresh();

                if (productoItem.tieneBascula)
                {
                    cerrarBascula();
                }
                limpiar();
                uiPesoVal.EditValue = 1;                               
                uiClave.Focus();
                calcularTotales();
                LlenarBotonesProducto("uiFamilia1");
                if (productoDefaultId > 0)
                {
                    SeleccionProducto("", productoDefaultId);
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

        private void mostrarProducto()
        {
            try
            {
                if(productoSeleccionado!= null)
                {
                    uiProductoDescripcion.Text = productoSeleccionado.DescripcionCorta;

                   
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

        public void limpiar()
        {
            
            
            pagando = false;
            capturaMontoManual = false;
            uiMontoManual.ReadOnly = true;
            uiPrecioProducto.ReadOnly = true;
            //uiPesoVal.ReadOnly = true;
            uiMontoManual.EditValue = 0;
            uiPrecioProducto.EditValue = 0;
            //uiPesoVal.EditValue = 0;
            productoSeleccionado = null;
            idProductoSel = 0;
            uiProductoDescripcion.Text = "";
            productoSeleccionado = null;
            uiRecibi.EditValue = 0;
            uiCambio.EditValue = 0;
            uiRecibi.ReadOnly = true;
            limpiarCaptura();
            uiTotal.EditValue = 0;
            uiClave.EditValue = "";
            uiClave.Select();
            uiClave.SelectAll();
            uiFormaPago.EditValue = 1;
            
        }

        private void calcularTotales()
        {
            try
            {
                uiTotal.EditValue = lstProductos.Sum(s => s.total);
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

        private void habilitarCapturaMonto()
        {
            if(idProductoSel <= 0)
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("Seleccionar primero un producto");
                return;
            }
            capturaMontoManual = !capturaMontoManual;
            uiMontoManual.ReadOnly = !capturaMontoManual;

            if (!capturaMontoManual)
            {
                uiPesoVal.EditValue = 0;
                uiMontoManual.EditValue = 0;
            }
            else
            {
                cerrarBascula();
            }

        }

        private void buscarProducto()
        {
            try
            {
                productoSeleccionado = oContext.cat_productos
                    .Where(
                    w => 
                    (w.ProductoId == idProductoSel
                    || (idProductoSel == 0 && (w.Clave.Trim() == uiClave.Text.Trim()||w.CodigoBarras == uiClave.Text)))
                    &&
                    w.ProductoId > 0
                    ).FirstOrDefault();

                if(productoSeleccionado != null)
                {
                    idProductoSel = productoSeleccionado.ProductoId;
                    uiPrecioProducto.EditValue = uiCliente.EditValue == null ?
                    ERP.Business.ProductoBusiness.ObtenerPrecio(idProductoSel, tipoPrecioProducto.PublicoGeneral, puntoVentaContext.usuarioId,puntoVentaContext.sucursalId) :
                    ERP.Business.ProductoBusiness.ObtenerPrecioPorCliente(idProductoSel, Convert.ToInt32(uiCliente.EditValue), puntoVentaContext.usuarioId,puntoVentaContext.sucursalId) ?? 0;
                    
                    if (productoSeleccionado.ProdVtaBascula == true)
                    {
                        //gcMonedas.Enabled = true;
                        uiPesoVal.ReadOnly = false;
                        abrirBascula();
                    }
                    else
                    {
                        //gcMonedas.Enabled = false;
                        cerrarBascula();
                        uiPesoVal.ReadOnly = false;
                        //uiPesoVal.EditValue = 1;
                    }
                }
                else
                {
                    limpiarCaptura();
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

        private void limpiarCaptura()
        {
            uiProductoDescripcion.Text = "";
            //uiPesoVal.EditValue = 0;
            uiPrecioProducto.EditValue = 0;
            uiMontoManual.EditValue = 0;
        }
        private void RefreshGrid()
        {
            uiGrid.DataSource = lstProductos;
            uiGridView.RefreshData();
        }

        private void calcularCambio()
        {
            try
            {
                decimal recibo = Convert.ToDecimal( uiRecibi.EditValue);
                if(recibo > 0)
                {
                    uiCambio.EditValue = (recibo - lstProductos.Sum(s => s.total)) <0 ? 0 : (recibo - lstProductos.Sum(s => s.total));
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
        private void pagar()
        {
            try
            {

                uiPagar.Enabled = false;
                //Si es un pedido con reparto, verificar si se debe de registrar devolución de reparto
                if (pedido != null)
                {
                    if(pedido.PedidoId > 0)
                    {
                        //Verificar si se debe de solicitar devolución en pedido
                        
                        if(ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                            this.puntoVentaContext.sucursalId, "SolictarDevolucionPedido",
                            this.puntoVentaContext.usuarioId))
                        {

                            frmPedidoDevolucionReparto oForm = new frmPedidoDevolucionReparto();
                            oForm.puntoVentaContext = this.puntoVentaContext;
                            oForm.pedido = this.pedido;
                            oForm.StartPosition = FormStartPosition.CenterScreen;
                            var result = oForm.ShowDialog();

                            if(result == DialogResult.OK)
                            {
                                inicializar();
                                return;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    
                }

                if(lstProductos.Sum(s=> s.total) <= 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("No hay productos agregados");
                    return;
                }
                if (!solicitarRecibido && !pagando)
                {
                    pagando = true;
                    uiRecibi.EditValue = lstProductos.Sum(S => S.total);
                    pagar();
                    return;
                }

                    if (!pagando)
                    {
                        pagando = true;
                        uiRecibi.EditValue = uiTotal.Value;
                        uiRecibi.ReadOnly = false;
                        uiRecibi.Focus();
                    }
                    else
                    {
                        if (Convert.ToDecimal(uiRecibi.EditValue) >= lstProductos.Sum(s => s.total)
                            || Convert.ToInt32(uiTipoCortesia.EditValue) > 0)
                        {
                            registrarVenta();

                        }
                        else
                        {
                            ERP.Utils.MessageBoxUtil.ShowWarning("La cantidad reibida no es suficiente");
                            return;
                        }
                    }

                uiPagar.Enabled = true;
            }
            catch (Exception ex)
            {
                uiPagar.Enabled = true;

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMain.GetInstance().puntoVentaContext.usuarioId,
                                      "ERP",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void cortesia() {
            try
            {
                for (int i = 0; i < lstProductos.Count(); i++)
                {
                    lstProductos[i].montoDescuento = lstProductos[i].total;
                    lstProductos[i].total = 0;
                    lstProductos[i].precioUnitario = 0;
                    lstProductos[i].precioNeto = 0;

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

        public void registrarVenta( )
        {
            if(uiFormaPago.EditValue == null)
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("La forma de pago es requerida");
                return;
            }
            List<FormaPagoModel> formasPago = new List<FormaPagoModel>();
           
            formasPago.Add(new FormaPagoModel() {
                cantidad = Convert.ToDecimal(uiRecibi.EditValue), id = Convert.ToInt32(uiFormaPago.EditValue)
            });

            long ventaId = 0;
            int? clienteId = uiCliente.EditValue == null ? null : (int?)Convert.ToInt32(uiCliente.EditValue);
            decimal descuentoPartidas = lstProductos.Sum(s => s.montoDescuento);
            string error = "";

            ConexionBD.PuntoVenta oData = new ConexionBD.PuntoVenta();

            if (Convert.ToInt32(uiTipoCortesia.EditValue) > 0)
            {
                cortesia();
                uiRecibi.Value = 0;
            }

            error = ERP.Business.VentasBusiness.pagar(ref ventaId, clienteId, "", 0, lstProductos.Sum(s=> s.montoDescuento),
                lstProductos.Sum(s => s.montoDescuento), lstProductos.Sum(s=> s.impuestos),
                (Convert.ToInt32(uiTipoCortesia.EditValue) > 0) ? 0 : lstProductos.Sum(s => s.total) - lstProductos.Sum(s => s.impuestos),
                (Convert.ToInt32(uiTipoCortesia.EditValue) > 0) ? 0 : uiTotal.Value,
                Convert.ToDecimal(uiRecibi.EditValue), Convert.ToDecimal(uiCambio.EditValue), 
                lstProductos.Sum(s => s.montoDescuento) > 0 ? true:false, 
                puntoVentaContext.sucursalId, 
                puntoVentaContext.usuarioId, 
                puntoVentaContext.cajaId, lstProductos, formasPago, new List<ValeFPModel>(), pedido.PedidoId,
                Convert.ToInt32(uiTipoCortesia.EditValue) == 1 ? true : false, Convert.ToInt32(uiTipoCortesia.EditValue) == 2 ? true : false);

            if (error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR");
                return;
            }
            else
            {
                error = "";

                if(imprimirTicket)
                {
                    if(uiTotal.Value >= valorImrpesionTicket)
                    {
                        if (entityConfig.ImprimirTicketMediaCarta == true)
                        {
                            ERP.Reports.rptVentaTicket_CartaM oTicket1 = new ERP.Reports.rptVentaTicket_CartaM();


                            ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer();

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


                    }
                }
                inicializar();
                limpiar();

                 if (productoDefaultId > 0)
                 {
                        SeleccionProducto("", productoDefaultId);
                 }


            }


        }
        private void calcularPesoPorMonto()
        {

            try
            {
                if (!capturaMontoManual)
                    return;

                if (productoSeleccionado == null)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Seleccione un producto");
                    return;
                }
                if (productoSeleccionado.cat_productos_precios.Count == 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("El producto no tiene precios configurados");
                    return;
                }
                else
                {
                    if (productoSeleccionado.cat_productos_precios
                        .Where(w => w.IdPrecio == 1).FirstOrDefault() != null)
                    {
                        decimal precio = productoSeleccionado.cat_productos_precios
                        .Where(w => w.IdPrecio == 1).FirstOrDefault().Precio;

                        if (precio == 0)
                        {
                            ERP.Utils.MessageBoxUtil.ShowWarning("El producto no tiene precios configurados");
                            return;
                        }
                        else
                        {
                            uiPesoVal.EditValue = Convert.ToDecimal(uiMontoManual.EditValue) * 1 / precio;
                        }
                    }
                    else
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("El producto no tiene precios configurados");
                        return;
                    }
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

        private void LlenarBotonesFamilias()
        {
            try
            {
                int i = 1;
                List<cat_familias> familias = DataBucket.GetFamiliasMemory(false).Where(w => w.Estatus == true && !w.Descripcion.Contains("SOBRANTE")).ToList();

                familias = familias.Where(W => W.cat_productos.Where(s1 => s1.ProdParaVenta == true).Count() > 0).ToList();

                familias.Add(new cat_familias() {  Clave = 0,Descripcion = "PRINCIPALES"});
                familias = familias.OrderBy(o=> o.Clave).ToList();

                foreach (var item in familias)
                {
                    Control controlA = Controls.Find("uiFamilia" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.AccessibleName = item.Clave.ToString();
                        controlA.Text = item.Descripcion;
                    }
                    i++;
                }

                /****Habilitar todos los botones****/
                for (int j = 1; j <= numBotonesFam; j++)
                {
                    Control controlA = Controls.Find("uiFamilia" + j.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.Enabled = true;
                        
                    }
                }




                /*Deshabilitar botones sin productos*/
                if ((familias.Count() + 1) <= numBotonesFam)
                {
                    for (int j = (familias.Count() + 1); j <= numBotonesFam; j++)
                    {
                        Control controlA = Controls.Find("uiFamilia" + j.ToString(), true).FirstOrDefault();
                        if (controlA != null)
                        {
                            controlA.Enabled = false;
                            controlA.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(
                    puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LlenarBotonesProducto(string btnFamilia)
        {
            try
            {
                if (desactivarBotonesTouch)
                    return;

                Control controlBTtnFam = Controls.Find(btnFamilia, true).FirstOrDefault();

                if (controlBTtnFam == null)
                    return;

                int FamiliaId = Convert.ToInt32(controlBTtnFam.AccessibleName);
                List<cat_productos> lstProds;

                if(FamiliaId > 0)
                {
                    lstProds = DataBucket.GetProductosMemory(this.puntoVentaContext.sucursalId,false).Where(w => w.Estatus == true && w.ProdParaVenta == true &&
                    w.ClaveFamilia == FamiliaId).OrderBy(o => o.DescripcionCorta).ToList();
                    
                }
                else
                {
                    lstProds = DataBucket.GetProductosMemory(this.puntoVentaContext.sucursalId, false).Where(w => w.Estatus == true && 
                    w.ProdParaVenta == true &&
                    w.cat_productos_principales.Count() > 0
                    ).OrderBy(o => o.DescripcionCorta).ToList();
                }

                int i = 1;
                foreach (var item in lstProds)
                {
                    Control controlA = Controls.Find("uiProducto" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.AccessibleName = item.ProductoId.ToString();
                        controlA.Text = String.Format("{0}", item.DescripcionCorta);
                    }
                    i++;
                }

                /****Habilitar todos los botones****/
                for (int j = 1; j <= numBotonesProd; j++)
                {
                    Control controlA = Controls.Find("uiProducto" + j.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.Enabled = true;
                    }
                }




                /*Deshabilitar botones sin productos*/
                if ((lstProds.Count() + 1) <= numBotonesProd)
                {
                    for (int j = (lstProds.Count() + 1); j <= numBotonesProd; j++)
                    {
                        Control controlA = Controls.Find("uiProducto" + j.ToString(), true).FirstOrDefault();
                        if (controlA != null)
                        {
                            controlA.Enabled = false;
                            controlA.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(
                    puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void SeleccionProducto(string btnName,int idProducto=0)
        {
            try
            {
                Control controlBTtn = null;
                if (idProducto == 0)
                {
                    if(btnName.Length > 0)
                    {
                        controlBTtn = Controls.Find(btnName, true).FirstOrDefault();

                        if (controlBTtn == null)
                            return;

                        idProductoSel = Convert.ToInt32(controlBTtn.AccessibleName);
                    }
                   
                }
                else
                {
                    idProductoSel = idProducto;
                }               
                
                buscarProducto();
                uiPesoVal.EditValue = uiPesoVal.Value > 1 ? uiPesoVal.Value : (productoSeleccionado==null ? new cat_productos() : productoSeleccionado).ProdVtaBascula == true ? 0 : 1;
                mostrarProducto();

                if((productoSeleccionado == null ? new cat_productos() : productoSeleccionado).ProdVtaBascula??false)
                {
                    uiPesoVal.Focus();
                }
                
                uiPesoVal.SelectAll();

                if(productoSeleccionado!= null)
                {
                    if (productoSeleccionado.ProdVtaBascula == false)
                    {
                        CalcularMontoProducto();
                        agregarProducto();
                    }
                }
                
                
            }
            catch (Exception ex)
            {


                int err = ERP.Business.SisBitacoraBusiness.Insert(
                    puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LoadClientes()
        {
            try
            {
                oContext = new ERPProdEntities();
                if(puntoVentaContext != null)
                {
                    uiCliente.Properties.DataSource = oContext.cat_clientes
                    .Where(
                        w => w.Activo == true &&
                        w.EmpleadoId == null &&
                        ((w.SucursalBaseId == puntoVentaContext.sucursalId && uiSoloMostrarClientesSucursal.Checked)
                        ||
                        !uiSoloMostrarClientesSucursal.Checked)
                    ).ToList();
                }
                
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(
                   puntoVentaContext.usuarioId,
                          "ERP",
                          this.Name,
                          ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
        #endregion


        private void uiTortilla_Click(object sender, EventArgs e)
        {
            idProductoSel = idTortilla;
            buscarProducto();
            mostrarProducto();
        }

        private void uiMasa_Click(object sender, EventArgs e)
        {
            idProductoSel = idMasa;
            buscarProducto();
            mostrarProducto();
        }

        private void uiAgregar_Click(object sender, EventArgs e)
        {
            agregarProducto();
        }

        private void uiHabilitarPrecio_Click(object sender, EventArgs e)
        {
            habilitarCapturaMonto();
            
            uiMontoManual.Focus();
        }

        private void uiMontoManual_EditValueChanged(object sender, EventArgs e)
        {
            calcularPesoPorMonto();
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            frmCancelacionVentaComentario oForm = new frmCancelacionVentaComentario();
            oForm.lstProductos = this.lstProductos;
            oForm.puntoVentaContext = this.puntoVentaContext;
            oForm.pedidoId = this.pedido!= null ? this.pedido.PedidoId : 0;
            oForm.StartPosition = FormStartPosition.CenterScreen;
            var resultForm = oForm.ShowDialog();

            if(resultForm == DialogResult.OK)
            {
                inicializar();
            }
            
        }       

        private void uiRepEliminar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(XtraMessageBox.Show("Está seguro(a) de eliminar el registro?","Aviso",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation)== DialogResult.Yes)
                {
                    ProductoModel0 itemDel = (ProductoModel0)uiGridView.GetRow(uiGridView.FocusedRowHandle);                   
                   
                    lstProductos.Remove(itemDel);

                    CancelarProductoBascula(itemDel);

                    RefreshGrid();

                    calcularTotales();
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

        private void uiRecibi_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            calcularCambio();
        }

        private void uiMontoManual_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
           
        }

        private void uiMontoManual_Leave(object sender, EventArgs e)
        {
            
        }

        private void uiPagar_Click(object sender, EventArgs e)
        {
            oFormLoading.Show();
            pagar();
            oFormLoading.Hide();
        }

        private void uiRecibi_EditValueChanged(object sender, EventArgs e)
        {
            calcularCambio();
        }

        private void uiRecibi_Leave(object sender, EventArgs e)
        {
            calcularCambio();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            leerBascula();
        }

        private void frmPuntoVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            cerrarBascula();
            _instance = null;
        }

        private void uiFamilia1_Click(object sender, EventArgs e)
        {
            LlenarBotonesProducto(((SimpleButton)sender).Name);
        }

        private void uiProducto7_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void uiFamilia2_Click(object sender, EventArgs e)
        {
            LlenarBotonesProducto(((SimpleButton)sender).Name);
        }

        private void uiFamilia3_Click(object sender, EventArgs e)
        {
            LlenarBotonesProducto(((SimpleButton)sender).Name);
        }

        private void uiFamilia4_Click(object sender, EventArgs e)
        {
            LlenarBotonesProducto(((SimpleButton)sender).Name);
        }

        private void uiFamilia5_Click(object sender, EventArgs e)
        {
            LlenarBotonesProducto(((SimpleButton)sender).Name);
        }

        private void uiFamilia6_Click(object sender, EventArgs e)
        {
            LlenarBotonesProducto(((SimpleButton)sender).Name);
        }

        private void uiFamilia7_Click(object sender, EventArgs e)
        {
            LlenarBotonesProducto(((SimpleButton)sender).Name);
        }

        private void uiFamilia8_Click(object sender, EventArgs e)
        {
            LlenarBotonesProducto(((SimpleButton)sender).Name);
        }

        private void uiFamilia9_Click(object sender, EventArgs e)
        {
            LlenarBotonesProducto(((SimpleButton)sender).Name);
        }

        private void uiFamilia10_Click(object sender, EventArgs e)
        {
            LlenarBotonesProducto(((SimpleButton)sender).Name);
        }

        private void uiFamilia11_Click(object sender, EventArgs e)
        {
            LlenarBotonesProducto(((SimpleButton)sender).Name);
        }

        private void uiFamilia12_Click(object sender, EventArgs e)
        {
            LlenarBotonesProducto(((SimpleButton)sender).Name);
        }

        private void uiProducto1_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void CalcularMontoProducto()
        {
            try
            {
                
                uiMontoManual.EditValue = uiPrecioProducto.Value  * uiPesoVal.Value;
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

        private void uiPesoVal_EditValueChanged(object sender, EventArgs e)
        {
            CalcularMontoProducto();
        }

        private void BuscarProductoDialog()
        {
            frmProductosBusqueda frmBuscar = new frmProductosBusqueda();
            frmBuscar.soloParaVenta = true;
            frmBuscar.puntoVentaContext = this.puntoVentaContext;

            var result = frmBuscar.ShowDialog();

            if (result == DialogResult.OK)
            {
                SeleccionProducto("", frmBuscar.response.ProductoId);
            }
        }

        private void uiBuscar_Click(object sender, EventArgs e)
        {

            BuscarProductoDialog();


        }

        private void uiPesoVal_Leave(object sender, EventArgs e)
        {
            CalcularMontoProducto();
        }

        private void uiProducto2_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void uiProducto3_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void uiProducto4_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void uiProducto5_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void uiProducto6_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void uiProducto8_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void uiProducto9_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void uiProducto10_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void uiProducto11_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void uiProducto12_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void uiPesoVal_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //CalcularMontoProducto();
        }

        private void uiClave_Leave(object sender, EventArgs e)
        {
            idProductoSel = uiClave.Text.Length >0 ? 0 : productoDefaultId;
            SeleccionProducto("", idProductoSel);
        }

        private void uiProducto13_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void uiProducto14_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void uiProducto15_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void uiProducto16_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void uiProducto17_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void uiProducto18_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void uiGuardarCantidadGranel_Click(object sender, EventArgs e)
        {
            try
            {
                //EstablecerPorPrecio(uiValorGranel.Value);
                agregarProducto();

            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMain.GetInstance().puntoVentaContext.usuarioId,
                                   "ERP",
                                   this.Name,
                                   ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void EstablecerPorPrecio(decimal cantidad)
        {
            try
            {
                if(cantidad > 0)
                {
                    uiMontoManual.EditValue = cantidad;
                }
                
                

                uiPrecioProducto.EditValue = uiCliente.EditValue == null ?
                   ERP.Business.ProductoBusiness.ObtenerPrecio(idProductoSel, tipoPrecioProducto.PublicoGeneral, puntoVentaContext.usuarioId,puntoVentaContext.sucursalId) :
                   ERP.Business.ProductoBusiness.ObtenerPrecioPorCliente(idProductoSel, Convert.ToInt32(uiCliente.EditValue), puntoVentaContext.usuarioId,puntoVentaContext.sucursalId) ?? 0;

                uiPesoVal.EditValue = uiMontoManual.Value / uiPrecioProducto.Value;

                agregarProducto();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMain.GetInstance().puntoVentaContext.usuarioId,
                                  "ERP",
                                  this.Name,
                                  ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiMoneda5_Click(object sender, EventArgs e)
        {
            EstablecerPorPrecio(5);
        }

        private void uiMoneda10_Click(object sender, EventArgs e)
        {
            EstablecerPorPrecio(10);
        }

        private void uiMoneda15_Click(object sender, EventArgs e)
        {
            EstablecerPorPrecio(15);
        }

        private void uiMoneda20_Click(object sender, EventArgs e)
        {
            EstablecerPorPrecio(20);
        }

        private void uiMoneda25_Click(object sender, EventArgs e)
        {
            EstablecerPorPrecio(25);
        }

        private void uiMoneda30_Click(object sender, EventArgs e)
        {
            EstablecerPorPrecio(30);
        }

        private void uiMoneda50_Click(object sender, EventArgs e)
        {
            EstablecerPorPrecio(50);
        }

        private void CancelarProductoBascula(ProductoModel0 itemDel)
        {
            //Regidtrar Báscula
            if (itemDel.tieneBascula)
            {
                if (configBascula == null)
                {
                    configBascula = BasculasBusiness.GetConfiguracionPCLocal(puntoVentaContext.usuarioId, puntoVentaContext.sucursalId);
                }
                if (configBascula != null)
                {
                    ERP.Business.BasculasBusiness.InsertBitacora(configBascula.BasculaId, puntoVentaContext.sucursalId,
                    puntoVentaContext.usuarioId, itemDel.cantidad,
                    (int)ERP.Business.Enumerados.tipoBasculaBitacora.CancelacionProductoPV,
                    itemDel.productoId, null);
                }
                
            }
        }

        private void CancelarVenta()
        {
            try
            {
                foreach (var item in lstProductos)
                {
                    
                }   
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMain.GetInstance().puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiClienteAgregar_Click(object sender, EventArgs e)
        {
            frmClienteForm oForm = new frmClienteForm();
            oForm.clienteId = 0;
            oForm.puntoVentaContext = puntoVentaContext;
            var result = oForm.ShowDialog();

            if(result == DialogResult.OK)
            {
                LoadClientes();

                if(oForm.cliente != null)
                {
                    uiCliente.EditValue = oForm.cliente.ClienteId;
                }
                
            }
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId, this.puntoVentaContext.sucursalId, "PV-Local", this.puntoVentaContext.usuarioId))
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("Usa la opción de REPARTO(REGISTRO EXPRESS) para el registro de pedidos");
                return;
            }

            uiGuardar.Enabled = false;
            try
            {
                if(pedido == null)
                {
                    pedido = new doc_pedidos_orden();
                }
                pedido.ClienteId = Convert.ToInt32(uiCliente.EditValue);
                pedido.SucursalId = puntoVentaContext.sucursalId;

                pedido = oPedido.GuardarPedido(pedido,ERP.Business.Enumerados.tipoPedido.PedidoTelefono,
                    this.lstProductos, puntoVentaContext.usuarioId, puntoVentaContext.sucursalId, ref error);

                if(error.Length > 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowError(error);
                }
                else
                {
                    ERP.Reports.rptPedido oTicket2 = new ERP.Reports.rptPedido();


                    ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer(this.puntoVentaContext.cajaId);
                    oContext = new ERPProdEntities();
                    oTicket2.DataSource = oContext.p_rpt_pedido_orden_sel(pedido.PedidoId).ToList();

                    oViewer.ShowTicket(oTicket2);
                    ERP.Utils.MessageBoxUtil.ShowOk();
                    inicializar();
                }

                uiGuardar.Enabled = true;

            }
            catch (Exception ex) 
            {
                uiGuardar.Enabled = true;
                err = ERP.Business.SisBitacoraBusiness.Insert(frmMain.GetInstance().puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiBuscarPedido_Click(object sender, EventArgs e)
        {
            if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId, this.puntoVentaContext.sucursalId, "PV-Local", this.puntoVentaContext.usuarioId))
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("Usa la opción de REPARTO(REGISTRO EXPRESS) para el registro de pedidos");
                return;
            }

            ERP.Common.Dialogos.frmCuentasListado oForm = new frmCuentasListado();
            oForm.puntoVentaContext = this.puntoVentaContext;
            
            oForm.StartPosition = FormStartPosition.CenterScreen;
            var result = oForm.ShowDialog();

            if(result == DialogResult.OK)
            {
                this.pedido = oForm.pedido;
                limpiar();
                BuscarPedido();
            }


        }

        private void BuscarPedido()
        {
            try
            {
                if(pedido != null)
                {
                    uiCliente.EditValue = pedido.ClienteId;

                    this.lstProductos = pedido.doc_pedidos_orden_detalle
                        .ToList().Select(s=> new ProductoModel0(){
                             cantidad = s.Cantidad,
                              clave = s.cat_productos.Clave,
                               descripcion = s.cat_productos.Descripcion,
                                precioNeto = s.PrecioUnitario,
                                  impuestos = 0,
                                   productoId = s.ProductoId,
                                    unidadId = s.cat_productos.ClaveUnidadMedida ?? 0,
                                     unidad = s.cat_productos.cat_unidadesmed.Descripcion,
                                      precioUnitario = s.PrecioUnitario,
                                      total = s.Total

                    }).ToList();

                    uiGrid.DataSource = lstProductos;

                    calcularTotales();
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMain.GetInstance().puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiValorGranel_Enter(object sender, EventArgs e)
        {
           
           
        }

        private void uiValorGranel_MouseUp(object sender, MouseEventArgs e)
        {
            //uiValorGranel.SelectAll();
        }

        private void uiValorGranel_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                try
                {
                    //EstablecerPorPrecio(uiValorGranel.Value);
                    

                }
                catch (Exception ex)
                {

                    err = ERP.Business.SisBitacoraBusiness.Insert(frmMain.GetInstance().puntoVentaContext.usuarioId,
                                       "ERP",
                                       this.Name,
                                       ex);
                    ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
                }
            }
        }

        private void frmPuntoVenta_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.F10)
            {
                pagar();
            }
        }

        private void frmPuntoVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void frmPuntoVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                pagar();
            }
        }

        private void uiPesoVal_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                if(uiClave.Text.Length > 0 || productoSeleccionado != null)
                {
                    agregarProducto();
                }
                else
                {
                    uiClave.Select();
                    uiClave.SelectAll();
                }
                
            }
            if (e.KeyCode == Keys.F2)
            {
                oFormLoading.Show();
                pagar();
                oFormLoading.Hide();
            }

            if (e.KeyCode == Keys.F3)
            {
               
                BuscarProductoDialog();
                
            }
            if (e.KeyCode == Keys.F4)
            {
                SeleccionProducto("", 1);
            }
            if (e.KeyCode == Keys.F5)
            {
                SeleccionProducto("", 2);
            }
        }

        private void uiClave_KeyUp(object sender, KeyEventArgs e)
        {


            if (e.KeyCode== Keys.Enter)
            {
                SeleccionProducto("", 0);
            }
            if (e.KeyCode == Keys.F2)
            {
                oFormLoading.Show();
                pagar();
                oFormLoading.Hide();
            }
            if (e.KeyCode == Keys.F3)
            {                
                BuscarProductoDialog();
                
            }
            if (e.KeyCode == Keys.F4)
            {
                SeleccionProducto("",1);
            }
            if (e.KeyCode == Keys.F5)
            {
                SeleccionProducto("", 2);
            }

        }

        private void uiRepCambioPrecio_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(uiGridView.FocusedRowHandle >= 0)
            {
                ProductoModel0 row = (ProductoModel0)uiGridView.GetRow(uiGridView.FocusedRowHandle);
                if(row != null)
                {
                    frmProductoInventarioForm oForm = new frmProductoInventarioForm();
                    oForm.clave = row.clave;
                    oForm.esParaCambioPrecio = true;
                    oForm.puntoVentaContext = this.puntoVentaContext;
                    var result = oForm.ShowDialog();

                    if(result == DialogResult.OK)
                    {
                        row.precioUnitario = oForm.precioRetorno;
                        row.total = row.precioUnitario * row.cantidad;

                        uiGridView.SetRowCellValue(uiGridView.FocusedRowHandle, "precioUnitario", row.precioUnitario);
                        uiGridView.SetRowCellValue(uiGridView.FocusedRowHandle, "total", row.total);
                        calcularTotales();
                    }

                }
                
            }
            
        }

        private void uiRecibi_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                pagar();
            }
        }

        private void uiPesoVal_MouseDown(object sender, MouseEventArgs e)
        {
            uiPesoVal.Select();
            uiPesoVal.SelectAll();
        }

        private void LoadFormasPago()
        {
            try
            {
                uiFormaPago.Properties.DataSource = oContext.cat_formas_pago.ToList();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMain.GetInstance().puntoVentaContext.usuarioId,
                                       "ERP",
                                       this.Name,
                                       ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiSoloMostrarClientesSucursal_CheckedChanged(object sender, EventArgs e)
        {
            LoadClientes();
        }

        private void uiTimerPedidosApp_Tick(object sender, EventArgs e)
        {
            try
            {
                oContext = new ERPProdEntities();
                if (oContext.p_doc_pedidos_ordenes_detalle_sel(puntoVentaContext.sucursalId, DateTime.Now, DateTime.Now,
                    (int)ERP.Business.Enumerados.tipoPedido.PedidoTelefono)
                    .Count() > 0)
                {
                    if (uiBotonPedidosApp.BackColor == Color.Red)
                    {
                        uiBotonPedidosApp.BackColor = Color.Blue;
                    }
                    else
                    {
                        uiBotonPedidosApp.BackColor = Color.Red;
                    }
                   
                }
                else {
                    uiBotonPedidosApp.BackColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMain.GetInstance().puntoVentaContext.usuarioId,
                                      "PUNTO DE VENTA",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiBotonPedidosApp_Click(object sender, EventArgs e)
        {
            frmBasculaExpressVenta frmo = new frmBasculaExpressVenta();
            frmo.habilitarRedireccionarPV = true;
            frmo.puntoVentaContext = this.puntoVentaContext;
            frmo.ShowDialog();
            
        }

        private void uiCliente_EditValueChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt32(uiCliente.EditValue) > 0 &&
                ERP.Business.PreferenciaBusiness.AplicaPreferencia(puntoVentaContext.empresaId,
                       puntoVentaContext.sucursalId, "PVExcluirBasculaPedidos", puntoVentaContext.usuarioId))
            {
                puntoVentaContext.conectarConBascula = false;
                puntoVentaContext.usarTareaBascula = false;
            }
            else
            {
                HabilitarBasculaSiNo();
            }
        }

        private void HabilitarBasculaSiNo()
        {
            if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(puntoVentaContext.empresaId,
                       puntoVentaContext.sucursalId, "ConectarConBascula", puntoVentaContext.usuarioId))
            {
                puntoVentaContext.conectarConBascula = true;

            }
            else
            {
                puntoVentaContext.conectarConBascula = false;
            }

            if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(puntoVentaContext.empresaId,
                puntoVentaContext.sucursalId, "UsarPesoInteligente", puntoVentaContext.usuarioId,ref error))
            {
                if(error.ToUpper() == "LOCAL")
                {
                    pesoInteligenteLecturaLocal = true;
                }
                puntoVentaContext.usarTareaBascula = true;
            }
            else
            {
                puntoVentaContext.usarTareaBascula = false;
            }

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

            if(Convert.ToInt32(uiCliente.EditValue) == 0)
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario seleccionar un cliente para continuar");
            }
            else
            {
                frmClienteForm oForm = new frmClienteForm();
                oForm.clienteId = Convert.ToInt32(uiCliente.EditValue);
                oForm.puntoVentaContext = puntoVentaContext;
                var result = oForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadClientes();

                    uiCliente.EditValue = oForm.cliente.ClienteId;
                }
            }
            
        }

        private void uiRgVincularBascula_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(uiRgVincularBascula.EditValue) == 1)
                {
                    desvincularBascula = false;
                }
                if (Convert.ToInt32(uiRgVincularBascula.EditValue) == 2)
                {
                    frmAdminPass oForm = new frmAdminPass();

                    oForm.StartPosition = FormStartPosition.CenterScreen;
                    oForm.ShowDialog();

                    if (oForm.DialogResult == DialogResult.OK)
                    {
                        desvincularBascula = true;

                        ERP.Business.SisBitacoraBusiness.GuardarBitacoraGeneral("desvinculación-bascula",
                            this.puntoVentaContext.sucursalId, "Solicitud de desvinculación del Punto de Venta",
                            this.puntoVentaContext.usuarioId);
                        ERP.Utils.MessageBoxUtil.ShowWarning("La báscula se ha desvinculado temporalmente, se guardó registro en bitácora de la solicitud de desvinculación");
                    }
                    else
                    {
                        if (Convert.ToInt32(uiRgVincularBascula.EditValue) == 1)
                        {
                            uiRgVincularBascula.EditValue = 2;
                        }
                        if (Convert.ToInt32(uiRgVincularBascula.EditValue) == 2)
                        {
                            uiRgVincularBascula.EditValue = 1;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(frmMain.GetInstance().puntoVentaContext.usuarioId,
                                      "PUNTO DE VENTA",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);

            }
        }

        private void uiClave_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void uiGridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
           
        }
    }
}
