using ConexionBD;
using ConexionBD.Models;
using ERP.Business.Tools;
using ERP.Common.Base;
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
    public partial class frmBasculaExpress : FormBaseXtraForm
    {
        private static frmBasculaExpress _instance;
        Models.Pedidos.PedidoDetalleModel pedidoSeleccionado;
        BasculaLectura basculaControlador;
        cat_basculas_configuracion basculaConfiguracion;
        public bool habilitarRedireccionarPV { get; set; }//Si está activa, se habilitará un botónpara un vez registrada la báscula, redireccionar al PV
        public string tipoForm { get; set; }
        public static frmBasculaExpress GetInstance()
        {
            if (_instance == null) _instance = new frmBasculaExpress();
            else _instance.BringToFront();
            return _instance;
        }

        public frmBasculaExpress()
        {
            InitializeComponent();

            pedidoSeleccionado = new Models.Pedidos.PedidoDetalleModel();
        }
        #region metodos

        private List<Models.Pedidos.PedidoDetalleModel> GetPedidosPendientes(bool soloPedidosMayoreo=false)
        {
            try
            {
                List<Models.Pedidos.PedidoDetalleModel> result =  oContext.p_doc_pedidos_ordenes_detalle_sel(puntoVentaContext.sucursalId, DateTime.Now, DateTime.Now,
                    soloPedidosMayoreo ? (int)ERP.Business.Enumerados.tipoPedido.PedidoClienteMayoreo : 3)
                    .Select(s=> new Models.Pedidos.PedidoDetalleModel() {
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
                        cantidadPendienteBascula = s.CantidadPendienteBascula ??0,
                        tipoPedidoId = s.TipoPedidoId ??0,
                        fechaEntrega = s.FechaProgramada ?? DateTime.MinValue,
                        horaEntrega = s.HoraProgramada ?? new TimeSpan(),
                        basculaPendiente = s.CantidadPendienteBascula > 0 ? true:false,
                        ventaId = s.VentaId ,
                        TipoCaja = s.TipoCaja,
                        requiereBascula = s.RequiereBascula ?? false
                       
                    }).ToList();

                
                return result.Where(w=> ((w.basculaPendiente && !uiMostrarPedidoSinVenta.Checked) || 
                (uiMostrarPedidoSinVenta.Checked && (w.ventaId) == 0 )) && w.TipoCaja.ToUpper().Contains("MOVIL") 
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
        public void LoadPedidos()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();

                if(tipoForm == "PRODUCCION")
                {
                    uiGridPedidos.DataSource = GetPedidosPendientes(true);
                }
                else
                {
                    uiGridPedidos.DataSource = GetPedidosPendientes(false);
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



        private void PrepararSiguienteProductoBascula(int PedidoDetalleId=0)
        {
            try
            {
                List<Models.Pedidos.PedidoDetalleModel> lstPedidos = (List<Models.Pedidos.PedidoDetalleModel>)uiGridPedidos.DataSource;

                if(lstPedidos.Count> 0)
                {
                    if(PedidoDetalleId == 0)
                    {
                        pedidoSeleccionado = lstPedidos.OrderBy(o => o.pedidoId).FirstOrDefault();
                    }
                    else
                    {
                        pedidoSeleccionado = lstPedidos.Where(w=> w.pedidoDetalleId == PedidoDetalleId).OrderBy(o => o.pedidoId).FirstOrDefault();
                    }
                   
                    if(pedidoSeleccionado != null)
                    {
                        if(pedidoSeleccionado.requiereBascula == true)
                        {
                            timerBascula.Enabled = false;
                            uiPedido.Text = pedidoSeleccionado.pedidoId.ToString();
                            uiProducto.Text = String.Format("{0}-{1}", pedidoSeleccionado.clave, pedidoSeleccionado.descripcion);
                            uiCantidad.EditValue = pedidoSeleccionado.cantidad;
                            uiTotal.EditValue = pedidoSeleccionado.total;
                            uiCantidadPendiente.EditValue = pedidoSeleccionado.cantidadPendienteBascula;
                            uiCliente.Text = pedidoSeleccionado.cliente;

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
                    if(basculaControlador == null)
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

            if(pedidoSeleccionado == null)
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
                uiGuardar.Enabled = false;
                timerBascula.Enabled = false;
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

                    if(uiPeso.Value == 0)
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
                        ERP.Utils.MessageBoxUtil.ShowOk();

                        //Si el Ultimo Pedido ya no tiene pendientes, entonces ir a cobrar automáticamente
                        LoadPedidos();
                        if (!tienePendienteBascula())
                        {
                            frmPedidoPagoCajaList oForm = new frmPedidoPagoCajaList();
                            oForm.esDialogForm = true;
                            oForm.puntoVentaContext = this.puntoVentaContext;
                            oForm.pedidoId = pedidoSeleccionado.pedidoId;
                            var resultDialog = oForm.ShowDialog();

                            if(resultDialog == DialogResult.OK)
                            {
                                Limpiar();
                                LoadPedidos();
                                PrepararSiguienteProductoBascula();
                            }
                        }
                        else
                        {
                            Limpiar();
                            LoadPedidos();
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
            uiPeso.EditValue = 0;
            uiPedido.Text = "";
            uiProducto.Text = "";
            uiTotal.Text = "";
            uiCantidad.Text = "";
            uiTotalBascula.Text = "";
            uiCantidadPendiente.EditValue = 0;
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

        private void repBtnSeleccion_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {

                Models.Pedidos.PedidoDetalleModel itemGrid = (Models.Pedidos.PedidoDetalleModel)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                if (itemGrid != null)
                {
                    
                   PrepararSiguienteProductoBascula(itemGrid.pedidoDetalleId);

                    if (!tienePendienteBascula())
                    {
                        frmPedidoPagoCajaList oForm = new frmPedidoPagoCajaList();
                        oForm.esDialogForm = true;
                        oForm.puntoVentaContext = this.puntoVentaContext;
                        oForm.pedidoId = pedidoSeleccionado.pedidoId;
                        var resultDialog = oForm.ShowDialog();

                        if (resultDialog == DialogResult.OK)
                        {
                            Limpiar();
                            LoadPedidos();
                            PrepararSiguienteProductoBascula();
                        }
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

        private void uiPeso_Properties_ValueChanged(object sender, EventArgs e)
        {
            calcularTotalBascula();
        }
        private void calcularTotalBascula()
        {
            try
            {
                if(pedidoSeleccionado != null)
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
            if((pedidoSeleccionado == null ? new Models.Pedidos.PedidoDetalleModel() : pedidoSeleccionado).pedidoDetalleId == 0 && timerBascula.Enabled == false)
            {
                LoadPedidos();
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
            if(e.KeyCode == Keys.F5)
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

                if(pedidoGridSelect != null)
                {
                    List<Models.Pedidos.PedidoDetalleModel> lstPedidoGridSelect = (List<Models.Pedidos.PedidoDetalleModel>)uiGridView.DataSource;

                    if(lstPedidoGridSelect.Where(w=> w.pedidoId == pedidoGridSelect.pedidoId && w.cantidadPendienteBascula  > 0).Count() > 0)
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
    }


}
