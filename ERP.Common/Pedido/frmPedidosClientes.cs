using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Business;
using ERP.Common.Base;
using ERP.Common.Forms;
using ERP.Models;
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

namespace ERP.Common.Pedido
{
    public partial class frmPedidosClientes : FormBaseXtraForm
    {
        LoadingForm oFormLoading;
        public int IDForm;
        int err = 0;
        private doc_pedidos_orden pedido;
        private doc_pedidos_orden_detalle pedidoDetalle;
        private static frmPedidosClientes _instance;
        public ConexionBD.PedidoOrdenBusiness oPedidoB;
        string error = "";
        public static frmPedidosClientes GetInstance()
        {
            if (_instance == null) _instance = new frmPedidosClientes();
            else _instance.BringToFront();
            return _instance;
        }

        private void HabilitarDeshabilitarDetalle()
        {
            if(this.IDForm > 0)
            {
                if (uiEstado.Text.Contains("Pagado"))
                {
                    uiGuardarDetalle.Enabled = false;
                    uiCancelarDetalle.Enabled = false;
                    uiProducto.Enabled = false;
                    uiCantidad.Enabled = false;
                    colRepDelete.Visible = false;
                    uiPagar.Enabled = false;
                    uiGuardarDetalle.Enabled = false;
                    uiGuardar.Enabled = false;
                }
                else
                {
                    uiGuardarDetalle.Enabled = true;
                    uiCancelarDetalle.Enabled = true;
                    uiProducto.Enabled = true;
                    uiCantidad.Enabled = true;
                    uiPagar.Enabled = true;
                    uiGuardarDetalle.Enabled = true;
                }
               
            }
            else
            {
                uiGuardarDetalle.Enabled = false;
                uiCancelarDetalle.Enabled = false;
                uiProducto.Enabled = false;
                uiCantidad.Enabled = false;
            }
        }
        public frmPedidosClientes()
        {
            oContext = new ERPProdEntities();
            oPedidoB = new PedidoOrdenBusiness();
            InitializeComponent();
        }

        private void ClearObjects()
        {
            oPedidoB = null;
        }

        private void frmPedidosClientes_Load(object sender, EventArgs e)
        {
            oFormLoading = new LoadingForm("Procesando...");
            loadSucursales();
            loadSucursalesCobro();
            loadClientes();
            buscarRegistro();
           
        }

        private void buscarRegistro()
        {
            try
            {
                if(this.IDForm > 0)
                {
                    uiFolio.EditValue = this.IDForm;
                    pedido = oContext.doc_pedidos_orden
                        .Where(w => w.PedidoId == this.IDForm).FirstOrDefault();
                    uiGrid.DataSource = pedido.doc_pedidos_orden_detalle.ToList();
                    uiCliente.EditValue = pedido.ClienteId;
                    uiSucursal.EditValue = pedido.SucursalId;
                    uiFechaEntrega.EditValue = pedido.doc_pedidos_orden_programacion.FirstOrDefault().FechaProgramada;
                    uiHoraEntrega.EditValue = pedido.doc_pedidos_orden_programacion.FirstOrDefault().HoraProgramada;
                    uiNotas.Text = pedido.Notas;
                    uiEstado.Text = ConexionBD.PedidoOrdenBusiness.ObtenerEstado(pedido);
                    uiSucursalCobro.EditValue = pedido.SucursalCobroId;
                    uiCredito.Checked = pedido.Credito??false;
                    uiCliente.Enabled = false;



                }
                else
                {
                    uiFolio.EditValue = 0;
                    uiHoraEntrega.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 00, 00);
                    uiFechaEntrega.EditValue = DateTime.Now;
                    uiEstado.Text = ConexionBD.PedidoOrdenBusiness.ObtenerEstado(null);
                    uiCliente.Enabled = true;
                    uiCredito.Checked = false;
                }
                HabilitarDeshabilitarDetalle();
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

        private void loadClientes()
        {
            try
            {
                uiCliente.Properties.DataSource =
                    oContext.cat_clientes
                    .Where(w=> w.rh_empleados == null)
                    .OrderBy(o => o.Nombre)
                    .ToList();
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

        private void loadSucursales()
        {
            try
            {
                uiSucursal.Properties.DataSource = ERP.Business.SucursalBusiness
                    .ObtenSucursalesPorUsuario(this.puntoVentaContext.empresaId,this.puntoVentaContext.usuarioId)
                    .OrderBy(o=> o.NombreSucursal)
                    .ToList();
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

        private void loadSucursalesCobro()
        {
            try
            {
                uiSucursalCobro.Properties.DataSource = ERP.Business.SucursalBusiness
                    .ObtenSucursalesPorUsuario(this.puntoVentaContext.empresaId, this.puntoVentaContext.usuarioId)
                    .OrderBy(o => o.NombreSucursal)
                    .ToList();
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

        private void loadProductosDetalle()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiGrid.DataSource = oContext.doc_pedidos_orden_detalle
                    .Where(w => w.PedidoId == this.IDForm && (w.Cancelado??false)==false).ToList();
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

        private void frmPedidosClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearObjects();
            _instance = null;
        }

        #region encabezado
        private bool validarEncabezado()
        {
            bool result = true;
            try
            {
                if (ConexionBD.PedidoOrdenBusiness.ObtenerEstado(this.pedido).Contains("Pagado"))
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("No es posible modificar un pedido Pagado");
                    return false;
                }
                if(uiCliente.EditValue == null)
                {

                    dxErrorProvider1.SetError(uiCliente, "El cliente es requerido", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    result= false;
                }
                if (uiSucursal.EditValue == null)
                {

                    dxErrorProvider1.SetError(uiSucursal, "La sucursal es requerida", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    result= false;
                }
                if (uiSucursalCobro.EditValue == null)
                {

                    dxErrorProvider1.SetError(uiSucursalCobro, "La sucursal de cobro es requerida", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    result = false;
                }
                if (uiFechaEntrega.EditValue == null)
                {
                    dxErrorProvider1.SetError(uiFechaEntrega, "La fecha de entrega es requerida", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    result= false;
                }
                if (uiHoraEntrega.EditValue == null)
                {
                    dxErrorProvider1.SetError(uiHoraEntrega, "La hora de entrega es requerida", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    result= false;
                }
                if(uiFechaEntrega.DateTime.Date < DateTime.Now.Date && this.IDForm == 0)
                {
                    dxErrorProvider1.SetError(uiFechaEntrega, "La fecha de entrega no puede ser menor a la actual", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    result = false;
                }

                if (!result)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Revise nuevamente la información");
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                "ERP",
                                                this.Name,
                                                ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);

                return false;
            }
        }

        private void GuardarEncabezado()
        {
            try
            {
                ResultAPIModel result = new ResultAPIModel();
                oContext = new ERPProdEntities();
                if (validarEncabezado())
                {
                    using (DbContextTransaction transaction = oContext.Database.BeginTransaction())
                    {
                        try
                        {
                            if (IDForm == 0)
                            {
                                pedido = new doc_pedidos_orden();
                                pedido.PedidoId = (oContext.doc_pedidos_orden
                                    .Max(m => (int?)m.PedidoId) ?? 0) + 1;
                                pedido.ClienteId = Convert.ToInt32(uiCliente.EditValue);
                                pedido.CreadoEl = DateTime.Now;
                                pedido.CreadoPor = puntoVentaContext.usuarioId;
                                pedido.FechaApertura = DateTime.Now;
                                pedido.FechaCierre = DateTime.Now;
                                pedido.Notas = uiNotas.Text;
                                pedido.SucursalId = Convert.ToInt32(uiSucursal.EditValue);
                                pedido.Activo = true;
                                pedido.TipoPedidoId = (int)ERP.Business.Enumerados.tipoPedido.PedidoClienteMayoreo;
                                pedido.Folio = oPedidoB.ObtenerFolio(Business.Enumerados.tipoPedido.PedidoClienteMayoreo, this.puntoVentaContext.sucursalId);
                                pedido.SucursalCobroId = Convert.ToInt32(uiSucursalCobro.EditValue);
                                pedido.Credito = uiCredito.Checked;
                                oContext.doc_pedidos_orden.Add(pedido);
                                oContext.SaveChanges();

                                ERP.Business.SisBitacoraBusiness
                                 .GuardaBitacoraGeneral(puntoVentaContext.sucursalId, pedido, puntoVentaContext.usuarioId);


                                doc_pedidos_orden_programacion entityProgramacion = new doc_pedidos_orden_programacion();
                                entityProgramacion.PedidoId = pedido.PedidoId;
                                entityProgramacion.ClienteId = Convert.ToInt32(uiCliente.EditValue);
                                entityProgramacion.CreadoEl = 1;
                                entityProgramacion.CreadoPor = puntoVentaContext.usuarioId;
                                entityProgramacion.FechaProgramada = uiFechaEntrega.DateTime;
                                entityProgramacion.HoraProgramada = new TimeSpan(uiHoraEntrega.Time.Hour, uiHoraEntrega.Time.Minute, 0);
                                entityProgramacion.PedidoProgramacionId = (oContext.doc_pedidos_orden_programacion
                                    .Max(m => (int?)m.PedidoProgramacionId) ?? 0) + 1;

                                oContext.doc_pedidos_orden_programacion.Add(entityProgramacion);
                                oContext.SaveChanges();

                                ERP.Business.SisBitacoraBusiness
                                 .GuardaBitacoraGeneral(puntoVentaContext.sucursalId, entityProgramacion, puntoVentaContext.usuarioId);




                            }
                            else
                            {
                                pedido = oContext.doc_pedidos_orden
                                    .Where(w => w.PedidoId == this.IDForm)
                                    .FirstOrDefault();

                                pedido.ClienteId = Convert.ToInt32(uiCliente.EditValue);
                                pedido.CreadoEl = DateTime.Now;
                                pedido.CreadoPor = puntoVentaContext.usuarioId;
                                pedido.FechaApertura = DateTime.Now;
                                pedido.FechaCierre = DateTime.Now;
                                pedido.Notas = uiNotas.Text;
                                pedido.SucursalId = Convert.ToInt32(uiSucursal.EditValue);
                                pedido.SucursalCobroId = Convert.ToInt32(uiSucursalCobro.EditValue);
                                pedido.Credito = uiCredito.Checked;
                                oContext.SaveChanges();

                                this.IDForm = pedido.PedidoId;

                                ERP.Business.SisBitacoraBusiness
                                   .GuardaBitacoraGeneral(puntoVentaContext.sucursalId, pedido, puntoVentaContext.usuarioId);


                                doc_pedidos_orden_programacion entityProgramacion = oContext.doc_pedidos_orden_programacion
                                    .Where(w => w.PedidoId == this.IDForm).FirstOrDefault();

                               
                                entityProgramacion.ClienteId = Convert.ToInt32(uiCliente.EditValue);                               
                                entityProgramacion.FechaProgramada = uiFechaEntrega.DateTime;
                                entityProgramacion.HoraProgramada = new TimeSpan(uiHoraEntrega.Time.Hour, uiHoraEntrega.Time.Minute,0);

                                oContext.SaveChanges();

                                ERP.Business.SisBitacoraBusiness
                                 .GuardaBitacoraGeneral(puntoVentaContext.sucursalId, entityProgramacion, puntoVentaContext.usuarioId);




                            }

                            if (uiCredito.Checked)
                            {
                                CargoBusiness.GuardarCargoPedido(oContext, pedido.ClienteId??0, 
                                    pedido, pedido.Total, uiFechaEntrega.DateTime, 
                                    puntoVentaContext.usuarioId,ref error );

                                if (error.Length > 0)
                                {
                                    transaction.Rollback();
                                    ERP.Utils.MessageBoxUtil.ShowError(result.error);
                                    return;
                                }
                            }
                            else
                            {
                                //Desactivar cargo
                                doc_cargos oCargo = oContext.doc_cargos
                                    .Where(w => w.doc_pedidos_orden.Where(s1 => s1.PedidoId == pedido.PedidoId).Count() > 0).FirstOrDefault();

                                if(oCargo!= null)
                                {
                                    if(oCargo.doc_pagos.Count() > 0)
                                    {
                                        ERP.Utils.MessageBoxUtil.ShowWarning("No fue posible desactivar el cargo ya que tiene pagos asociados");
                                        return;
                                    }
                                    else
                                    {
                                        oCargo.Activo = false;
                                        oContext.SaveChanges();
                                    }
                                    
                                }
                            }
                           

                            transaction.Commit();
                            ERP.Utils.MessageBoxUtil.ShowOk();
                            this.IDForm = pedido.PedidoId;
                            dxErrorProvider1.ClearErrors();
                            buscarRegistro();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                  "ERP",
                                                  this.Name,
                                                  ex);
                            ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
                        }
                       

                    }
                   


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


        private bool validarDetalle()
        {
            bool result = true;
            try
            {
                if (uiSucursal.EditValue == null)
                {

                    dxErrorProvider1.SetError(uiSucursal, "La sucursal de Producción es Requerida", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    result = false;
                }
                if (uiSucursalCobro.EditValue == null)
                {

                    dxErrorProvider1.SetError(uiSucursalCobro, "La sucursal de Cobro es Requerida", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    result = false;
                }
                if (uiProducto.EditValue == null)
                {

                    dxErrorProvider1.SetError(uiProducto, "El producto es requerido", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    result = false;
                }
                if (uiCantidad.Value<=0)
                {

                    dxErrorProvider1.SetError(uiCantidad, "La cantidad debe de ser mayor a cero", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    result = false;
                }
               

                if (!result)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Revise nuevamente la información");
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                "ERP",
                                                this.Name,
                                                ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);

                return false;
            }
        }

        private void GuardarDetalle()
        {
            try
            {
                if (validarDetalle())
                {
                    int productoId = Convert.ToInt32(uiProducto.EditValue);
                    int clienteId = Convert.ToInt32(uiCliente.EditValue);
                    doc_clientes_productos_precios clientesProductoPrecio = oContext
                            .doc_clientes_productos_precios.Where(w => w.ClienteId == clienteId && w.ProductoId == productoId)
                            .FirstOrDefault();

                    cat_productos productoDetalle = oContext.cat_productos
                          .Where(w => w.ProductoId == productoId).FirstOrDefault();

                    if (clientesProductoPrecio == null)
                    {
                        ERP.Utils.MessageBoxUtil.ShowError("El producto no tiene un precio configurado para el cliente");
                        return;
                    }

                    using (DbContextTransaction transaction = oContext.Database.BeginTransaction())
                    {
                        try
                        {
                            if (pedidoDetalle == null)
                            {
                                pedidoDetalle = new doc_pedidos_orden_detalle();

                                pedidoDetalle.Cantidad = uiCantidad.Value;
                                pedidoDetalle.CreadoEl = DateTime.Now;
                                pedidoDetalle.CreadoPor = puntoVentaContext.usuarioId;
                                pedidoDetalle.Descripcion = productoDetalle.Descripcion;
                                pedidoDetalle.PedidoDetalleId =
                                        (oContext.doc_pedidos_orden_detalle
                                        .Max(m => (int?)m.PedidoDetalleId) ?? 0) + 1;
                                pedidoDetalle.PedidoId = this.IDForm;
                                pedidoDetalle.ProductoId = productoId;
                                pedidoDetalle.PrecioUnitario = clientesProductoPrecio.Precio ?? 0;
                                pedidoDetalle.Total = pedidoDetalle.Cantidad * pedidoDetalle.PrecioUnitario;

                                oContext.doc_pedidos_orden_detalle.Add(pedidoDetalle);
                                oContext.SaveChanges();

                                ERP.Business.SisBitacoraBusiness.GuardaBitacoraGeneral(puntoVentaContext.sucursalId,
                                        pedidoDetalle, puntoVentaContext.usuarioId);

                                
                                LimpiarCapturaDetalle();

                            }
                            else
                            {
                                int pedidoDetalleId = pedidoDetalle.PedidoDetalleId;

                                pedidoDetalle = oContext.doc_pedidos_orden_detalle
                                    .Where(w => w.PedidoDetalleId == pedidoDetalleId).FirstOrDefault();

                                pedidoDetalle.Cantidad = Convert.ToInt32(uiCantidad.EditValue);
                                pedidoDetalle.ProductoId = productoId;
                                pedidoDetalle.Cantidad = uiCantidad.Value;
                                pedidoDetalle.Total = pedidoDetalle.Cantidad * clientesProductoPrecio.Precio ?? 0;

                                oContext.SaveChanges();

                                ERP.Business.SisBitacoraBusiness.GuardaBitacoraGeneral(puntoVentaContext.sucursalId,
                                        pedidoDetalle, puntoVentaContext.usuarioId);

                                LimpiarCapturaDetalle();

                            }
                            transaction.Commit();

                            actualizarTotalPedido();

                            loadProductosDetalle();
                        }
                        catch (Exception ex)
                        {

                            transaction.Rollback();
                            int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                               "ERP",
                                               this.Name,
                                               ex);
                            ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
                        }
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

        private void actualizarTotalPedido()
        {
            try
            {
                oContext = new ERPProdEntities();
            
                pedido = oContext.doc_pedidos_orden.Where(w => w.PedidoId == this.IDForm).FirstOrDefault();
                pedido.Total = oContext.doc_pedidos_orden_detalle
                        .Where(w => w.PedidoId == this.IDForm && (w.Cancelado ?? false) == false).Sum(s => s.Total);
                oContext.SaveChanges();

                CargoBusiness.ActualizarCargoPedido(oContext, this.IDForm, pedido.Total, puntoVentaContext.usuarioId);
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

        #endregion

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            GuardarEncabezado();
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void repBtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (uiGridView.FocusedRowHandle < 0)
                    return;

                doc_pedidos_orden_detalle entityDel = (doc_pedidos_orden_detalle)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                if (XtraMessageBox.Show("¿Está seguro(a) de eliminar el registro?", "Aviso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)== DialogResult.Yes)
                {
                    int idDet = entityDel.PedidoDetalleId;

                    entityDel = oContext.doc_pedidos_orden_detalle
                        .Where(w => w.PedidoDetalleId == idDet).FirstOrDefault();

                    if(entityDel.doc_basculas_bitacora.Count() > 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("No es posible eliminar esta partida, ya se tiene un registro de báscula");
                    }
                    else
                    {
                        oContext.doc_pedidos_orden_detalle.Remove(entityDel);
                        oContext.SaveChanges();

                        actualizarTotalPedido();
                        LimpiarCapturaDetalle();
                        loadProductosDetalle();
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

        private void repBtnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    this.pedidoDetalle = (doc_pedidos_orden_detalle)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    uiProducto.EditValue = this.pedidoDetalle.ProductoId;
                    uiCantidad.EditValue = this.pedidoDetalle.Cantidad;
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

        private void LimpiarCapturaDetalle()
        {
            this.pedidoDetalle = null;
            uiProducto.EditValue = null;
            uiCantidad.EditValue = null;

        }

        private void uiGuardarDetalle_Click(object sender, EventArgs e)
        {
            GuardarDetalle();
        }

        private void uiCancelarDetalle_Click(object sender, EventArgs e)
        {
            LimpiarCapturaDetalle();
        }

        private void LoadProductosPrecios()
        {
            try
            {
                if (uiCliente.EditValue == null)
                    return;

                int clienteId = Convert.ToInt32(uiCliente.EditValue);

                uiProducto.Properties.DataSource = oContext.cat_productos
                    .Where(s1 => s1.doc_clientes_productos_precios
                    .Where(s2 => s2.ClienteId == clienteId).Count() > 0).ToList();
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

        private void uiSucursal_EditValueChanged(object sender, EventArgs e)
        {
            LoadProductosPrecios();
        }

        private void uiCliente_EditValueChanged(object sender, EventArgs e)
        {
            LoadProductosPrecios();
        }

        private void uiPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if(pedido.VentaId == null)
                {
                    if(
                        XtraMessageBox.Show("Se generará una venta para la sucursal asignada al cobro por el monto del pedido.¿Está seguro(a) de continuar?","Aviso",
                        MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int sucursalId = Convert.ToInt32(uiSucursalCobro.EditValue);
                        int cajaId = 0;

                        if (oContext.cat_cajas
                           .Where(w => w.Sucursal == sucursalId).Count() > 0)
                        {
                            cajaId = oContext.cat_cajas
                           .Where(w => w.Sucursal == sucursalId).FirstOrDefault().Clave;
                        }
                        else
                        {
                            ERP.Utils.MessageBoxUtil.ShowWarning("La sucursal de Cobro no tiene una caja creada, es necesario crearla antes de continuar");
                            return;
                        } 



                        oFormLoading.Show();
                        long ventaId = 0;
                        
                        GuardarEncabezado();

                       

                        List<ProductoModel0> lst = ((List<doc_pedidos_orden_detalle>)uiGrid.DataSource).ToList().Select(
                                s => new ProductoModel0()
                                {
                                    cantidad = s.Cantidad,
                                    cantidadCobroReparto = 0,
                                    cantidadDevolucion = 0,
                                    cantidadFinalReparto = 0,
                                    cantidadOriginal = 0,
                                    cargoAdicionalId = null,
                                    clave = s.cat_productos.Clave,
                                    descripcion = s.cat_productos.Descripcion,
                                    impuestos = 0,
                                    montoDescuento = 0,
                                    paraLlevar = true,
                                    paraMesa = false,
                                    partida = 0,
                                    pedidoDetalleId = s.PedidoDetalleId,
                                    porcDescuento = 0,
                                    porcDescuentoPartida = 0,
                                    porcDescunetoVta = 0,
                                    porcImpuestos = 0,
                                    precioCompra = 0,
                                    precioNeto = s.PrecioUnitario,
                                    precioUnitario = s.PrecioUnitario,
                                    productoId = s.ProductoId,
                                    promocionCMId = 0,
                                    tieneBascula = s.cat_productos.ProdVtaBascula ?? false,
                                    tienePromocion = false,
                                    tipoDescuentoId = 0,
                                    total = s.Total,
                                    unidadId = s.cat_productos.ClaveUnidadMedida ?? 0

                                }
                                ).ToList();

                        List<FormaPagoModel> lstFP = new List<FormaPagoModel>();
                        lstFP.Add(new FormaPagoModel() { cantidad = lst.Sum(s=> s.total), 
                            id = (int)ERP.Business.Enumerados.formasPago.EFECTIVO });

                        error= ERP.Business.VentasBusiness.pagar(ref ventaId, 
                                    Convert.ToInt32(uiCliente.EditValue),
                                    "", 0M, 0M, 0M, 0M,
                                     ((List<doc_pedidos_orden_detalle>)uiGrid.DataSource).Sum(s => s.Total),
                                    ((List<doc_pedidos_orden_detalle>)uiGrid.DataSource).Sum(s => s.Total),
                                    ((List<doc_pedidos_orden_detalle>)uiGrid.DataSource).Sum(s => s.Total),
                                    0,
                                    false,
                                    Convert.ToInt32(uiSucursalCobro.EditValue),
                                    puntoVentaContext.usuarioId,
                                    cajaId,
                                    lst, 
                                    new List<FormaPagoModel>(), 
                                    new List<ConexionBD.Models.ValeFPModel>(), pedido.PedidoId, false, false, null);

                        if(error.Length == 0)
                        {
                            ERP.Reports.rptVentaTicket oTicket2 = new ERP.Reports.rptVentaTicket();

                            ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer();

                            oTicket2.DataSource = oContext.p_rpt_VentaTicket((int?)ventaId).ToList();

                            oViewer.ShowTicket(oTicket2);

                            uiPagar.Enabled = false;
                            colEdit.Visible = false;
                            colRepDelete.Visible = false;
                            uiGuardarDetalle.Enabled = false;
                            uiPagar.Enabled = false;
                            oFormLoading.Hide();
                        }
                        else
                        {
                            oFormLoading.Hide();
                            ERP.Utils.MessageBoxUtil.ShowError(error);
                        }


                    } 
                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("El pedido ya está PAGADO");
                }
            }
            catch (Exception ex)
            {
                oFormLoading.Hide();
                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                 "ERP",
                                                 this.Name,
                                                 ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void Imprimir()
        {
            ERP.Reports.rptPedido oTicket2 = new ERP.Reports.rptPedido();


            ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer();
            oContext = new ERPProdEntities();
            oTicket2.DataSource = oContext.p_rpt_pedido_orden_sel(pedido.PedidoId).ToList();

            oViewer.ShowTicket(oTicket2);
        }
    }
}
