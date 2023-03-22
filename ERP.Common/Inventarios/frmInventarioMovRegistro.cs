using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Business;
using ERP.Business.Tools;
using ERP.Common.Base;
using ERP.Common.Productos;
using ERP.Common.Reports;
using ERP.Common.Utils;
using ERP.Models;
using ERP.Models.Inventario;
using ERP.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace ERP.Common.Inventarios
{
    public partial class frmInventarioMovRegistro : FormBaseXtraForm
    {
        LoadingTool loading;
        int err = 0;
        public int MovimientoInventarioId { get; set; }
        bool autorizar = false;
        doc_inv_movimiento entity { get; set; }
        cat_productos productoSelecionado;
        List<cat_productos> lstProductos;
        BasculaLectura basculaControlador;
        int sucursalOrigen = 0;
        int sucursalDestinoId=0;
        List<ERP.Models.Inventario.ProductoInventarioModel> lstProductosTraspaso;
        public ERP.Business.Enumerados.tipoMovimientoInventario tipoMovimiento { get; set; }
        private ERP.Business.Enumerados.tipoBasculaBitacora tipoMovBascula;
        public string titulo { get; set; }
        public string ClaveProductoDefault { get; set; }
        public frmInventarioMovRegistro()
        {
            InitializeComponent();
        }
        private static frmInventarioMovRegistro _instance;
        public static frmInventarioMovRegistro GetInstance()
        {
            if (_instance == null) _instance = new frmInventarioMovRegistro();
            else _instance.BringToFront();
            return _instance;
        }

        private void frmTraspasosSalidaLite_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void LoadGrid(bool rellenarProductos)
        {
            try
            {
                sucursalOrigen = Convert.ToInt32(uiSucursalOrigen.EditValue);
                sucursalDestinoId = Convert.ToInt32(uiSucursalDestino.EditValue);
                oContext = new ERPProdEntities();
                if (rellenarProductos)
                {
                    uiGrid.DataSource = oContext.cat_productos
                    .Where(w => w.cat_sucursales_productos.Where(s1 => s1.SucursalId == puntoVentaContext.sucursalId).Count() > 0)
                    .OrderBy(o=> o.Orden)
                    .Select(
                        s => new ProductoInventarioModel()
                        {
                            unidad = s.cat_unidadesmed.Descripcion,
                            cantidad = 0,
                            clave = s.Clave,
                            descripcion = s.Descripcion,
                            productoId = s.ProductoId,
                            unidadId = s.ClaveUnidadMedida ?? 0,
                            existenciaSucursalOrigen = s.cat_productos_existencias.Count() > 0 ? s.cat_productos_existencias
                            .Where(s2=> s2.SucursalId == sucursalOrigen).FirstOrDefault().ExistenciaTeorica ?? 0 : 0,
                            existenciaSucursalDestino = s.cat_productos_existencias.Count() > 0 ? s.cat_productos_existencias
                            .Where(s2 => s2.SucursalId == sucursalDestinoId).FirstOrDefault().ExistenciaTeorica ?? 0 : 0
                        }
                    ).ToList();
                }
                else
                {
                    uiGrid.DataSource = oContext.doc_inv_movimiento_detalle
                            .Where(w => w.MovimientoId == MovimientoInventarioId)
                            .Select(s => new ProductoInventarioModel()
                            {
                                unidad = s.cat_productos.cat_unidadesmed.Descripcion,
                                cantidad = s.Cantidad ?? 0,
                                clave = s.cat_productos.Clave,
                                descripcion = s.cat_productos.Descripcion,
                                productoId = s.ProductoId,
                                unidadId = s.cat_productos.ClaveUnidadMedida ?? 0,
                                precioUnitario = s.PrecioUnitario,
                                precioNeto = s.PrecioNeto ?? 0,
                                total = s.Importe,
                                existenciaSucursalOrigen = s.cat_productos.cat_productos_existencias.Count() > 0 ?
                                                        s.cat_productos.cat_productos_existencias
                                                        .Where(s2 => s2.SucursalId == sucursalOrigen).FirstOrDefault().ExistenciaTeorica ?? 0 : 0,

                                existenciaSucursalDestino = s.cat_productos.cat_productos_existencias.Count() > 0 ?
                                                        s.cat_productos.cat_productos_existencias
                                                        .Where(s2 => s2.SucursalId == sucursalDestinoId).FirstOrDefault().ExistenciaTeorica ?? 0 : 0
                            }).ToList();
                }
                uiGridView.ExpandAllGroups();
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

        private void LlenarBotones()
        {
            try
            {
                int i = 1;
                foreach (var item in lstProductos.OrderBy(o => o.Descripcion))
                {
                    Control controlA = Controls.Find("uiProducto" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.AccessibleName = item.ProductoId.ToString();
                        controlA.Text = item.DescripcionCorta;
                    }
                    i++;
                }

                /****Habilitar todos los botones****/
                for (int j = 1; j <= 24; j++)
                {
                    Control controlA = Controls.Find("uiProducto" + j.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.Enabled = true;
                    }
                }




                /*Deshabilitar botones sin productos*/
                if ((lstProductos.Count + 1) <= 24)
                {
                    for (int j = (lstProductos.Count + 1); j <= 24; j++)
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

        private void LoadEntity()
        {
            try
            {
                oContext = new ERPProdEntities();
                entity = oContext.doc_inv_movimiento
                    .Where(w => w.MovimientoId == MovimientoInventarioId).FirstOrDefault();

                if(entity == null)
                {
                    entity = new doc_inv_movimiento();
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
        private void frmTraspasosSalidaLite_Load(object sender, EventArgs e)
        {
            try
            {
                loading = new LoadingTool();
                oContext = new ERPProdEntities();
                var tipoMov = oContext.cat_tipos_movimiento_inventario
                    .Where(w=> w.TipoMovimientoInventarioId == (int)tipoMovimiento).FirstOrDefault();

               
                this.lblTitulo.Text = tipoMov.Descripcion;

                this.Text = this.lblTitulo.Text;

              
                uiTipoMovimiento.Properties.DataSource = oContext.cat_tipos_mermas.ToList();

                LoadEntity();

                if(entity.MovimientoId > 0)
                {
                    tipoMovimiento = (ERP.Business.Enumerados.tipoMovimientoInventario)entity.TipoMovimientoId;
                }

                //Si es por devolucion
                if(tipoMovimiento == Business.Enumerados.tipoMovimientoInventario.SalidaPorTraspasoDev)
                {
                    uiSucursalOrigen.ReadOnly = false;
                    uiSucursalDestino.ReadOnly = true;
                        
                    uiSucursalOrigen.Properties.DataSource = ERP.Business.SucursalBusiness
                 .ObtenSucursalesPorUsuario(puntoVentaContext.empresaId, puntoVentaContext.usuarioId)
                        .Where(w => w.Clave != puntoVentaContext.sucursalId).ToList();
                    
                   

                    uiSucursalDestino.Properties.DataSource = ERP.Business.SucursalBusiness
                        .ObtenSucursalesPorUsuario(puntoVentaContext.empresaId, puntoVentaContext.usuarioId).ToList();

                    uiSucursalDestino.EditValue = puntoVentaContext.sucursalId;


                    if (entity.MovimientoId > 0)
                    {
                        uiSucursalOrigen.EditValue = entity.SucursalOrigenId;
                        uiSucursalDestino.EditValue = entity.SucursalDestinoId;
                    }
                    else
                    {
                        uiSucursalOrigen.EditValue = null;
                        uiSucursalDestino.EditValue = puntoVentaContext.sucursalId;
                    }
                }
                else
                {
                    uiSucursalOrigen.ReadOnly = true;
                    uiSucursalDestino.ReadOnly = false;

                    uiSucursalOrigen.Properties.DataSource = ERP.Business.SucursalBusiness
                 .ObtenSucursalesPorUsuario(puntoVentaContext.empresaId, puntoVentaContext.usuarioId).ToList();
                    uiSucursalOrigen.EditValue = puntoVentaContext.sucursalId;

                    uiSucursalDestino.Properties.DataSource = ERP.Business.SucursalBusiness
                        .ObtenSucursalesPorUsuario(puntoVentaContext.empresaId, puntoVentaContext.usuarioId)
                        .Where(w => w.Clave != puntoVentaContext.sucursalId).ToList();

                }

                lstProductosTraspaso = new List<ProductoInventarioModel>();
                basculaControlador = new BasculaLectura(this.puntoVentaContext);
                oContext = new ERPProdEntities();

                if(oContext.doc_sucursales_productos_recepcion.Where(w=> w.SucursalId == puntoVentaContext.sucursalId).Count() > 0)
                {
                    lstProductos = oContext
                          .cat_productos
                          .Where(w => w.Estatus == true
                            && w.doc_sucursales_productos_recepcion
                                .Where(s1=> s1.SucursalId == puntoVentaContext.sucursalId).Count() > 0
                          )
                          .OrderByDescending(o => o.DescripcionCorta)
                          .ToList();
                }
                else
                {
                    lstProductos = oContext
                              .cat_productos
                              .Where(w => w.Estatus == true)
                              .OrderByDescending(o => o.DescripcionCorta)
                              .ToList();
                }

              

                uiSucursalOrigen.Text = this.puntoVentaContext.nombreSucursal;
                HabilitarDeshabilitarBotones();
                LoadGrid(false);
                LlenarBotones();

                if(ClaveProductoDefault != null)
                {
                    AbrirMosaico();
                }
                else
                {
                    uiClave.Select();
                    uiClave.SelectAll();
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

        private void EntradaSeleccion(string buttonName)
        {
            try
            {
                uiCantidad.EditValue = 0;
                Control button = Controls.Find(buttonName, true).FirstOrDefault();

                int productoEntradaSel = Convert.ToInt32(button.AccessibleName);

                productoSelecionado = oContext.cat_productos
                    .Where(w => w.ProductoId == productoEntradaSel).FirstOrDefault();

                if (productoSelecionado != null)
                {

                    uiProductoSeleccion.Text = productoSelecionado.Clave + "-" + productoSelecionado.DescripcionCorta;
                    if (productoSelecionado.ProdVtaBascula == true)
                    {
                        uiCantidad.Enabled = false;
                        timerBascula.Enabled = true;
                        basculaControlador.abrirBascula();
                    }
                    else
                    {
                        uiCantidad.Enabled = true;
                        uiCantidad.Focus();
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
        private void uiProducto1_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto1");
        }

        private void agregar()
        {
            try
            {
                if (uiCantidad.Value <= 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("La cantidad debe de ser mayor a 0");
                    return;
                }
                if (productoSelecionado != null)
                {
                    if (lstProductosTraspaso == null)
                    {
                        lstProductosTraspaso = new List<Models.Inventario.ProductoInventarioModel>();
                    }

                    ProductoInventarioModel item = new ProductoInventarioModel();

                    item.partida = (lstProductosTraspaso.Max(m => (int?)m.partida) ?? 0) + 1;
                    item.clave = productoSelecionado.Clave;
                    item.productoId = productoSelecionado.ProductoId;
                    item.descripcion = productoSelecionado.DescripcionCorta;
                    item.unidad = productoSelecionado.cat_unidadesmed.DescripcionCorta;
                    item.cantidad = uiCantidad.Value;
                    lstProductosTraspaso.Add(item);

                    uiGrid.DataSource = lstProductosTraspaso;
                    uiGridView.RefreshData();
                    uiGridView.ExpandAllGroups();

                    uiProductoSeleccion.Text = "";
                    uiCantidad.EditValue = 0;

                    timerBascula.Enabled = false;
                    basculaControlador.cerrarBascula();
                    uiCantidad.Value = 0;

                    uiClave.Text = "";
                    uiClave.Select();
                    uiClave.SelectAll();

                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowError("Seleccione un producto");
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
        private void uiAgregar_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void timerBascula_Tick(object sender, EventArgs e)
        {
            try
            {
                uiCantidad.EditValue = basculaControlador.ObtenPeso();
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

        private void uiProducto2_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto2");
        }

        private void uiProducto3_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto3");
        }

        private void uiProducto4_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto4");
        }

        private void uiProducto5_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto5");
        }

        private void uiProducto6_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto6");
        }

        private void uiProducto7_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto7");
        }

        private void uiProducto8_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto8");
        }

        private void repBtnDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    lstProductosTraspaso = (List<ProductoInventarioModel>)uiGridView.DataSource;
                    ProductoInventarioModel item = (ProductoInventarioModel)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    if(item!= null)
                    {
                       lstProductosTraspaso.Remove(item);

                        uiGrid.DataSource = lstProductosTraspaso;
                        uiGridView.RefreshData();
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

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool btnGuardar()
        {
            try
            {

                if (!ValidaGuardar())
                    return false;
               
                
                ResultAPIModel result = new ResultAPIModel();

                result = Guardar(0,autorizar);
                if (result.ok)
                {
                    return true;

                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowError(result.error);
                    return false;
                }
                

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

        private async void uiGuardar_Click(object sender, EventArgs e)
        {
            autorizar = false;

            loading.Show();
            Task<bool> oTask = new Task<bool>(btnGuardar);

            oTask.Start();
            await oTask;
            loading.Hide();
            if (oTask.Result)
            {
                HabilitarDeshabilitarBotones();
            }
            
           
        }

        private void limpiar()
        {
            uiClave.Text = "";
            productoSelecionado = null;
            lstProductos = new List<cat_productos>();
            lstProductosTraspaso = new List<ProductoInventarioModel>();
            uiGrid.DataSource = null;
            uiClave.Select();
            uiClave.SelectAll();

        }

        private ResultAPIModel Guardar(int _tipoMovimientoId=0,bool borrarPartidasEnCero =false)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                if(((List<ProductoInventarioModel>)uiGrid.DataSource).Count() == 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Agregue productos al listado para continuar");
                    result.error = "Agregue productos al listado para continuar";
                    return result ;
                }
                
                var configBascula = ERP.Business.BasculasBusiness.GetConfiguracionPCLocal(puntoVentaContext.usuarioId,
                    puntoVentaContext.sucursalId);
                doc_inv_movimiento entityMov = new doc_inv_movimiento();

                entityMov.MovimientoId = this.MovimientoInventarioId;
                entityMov.Activo = true;
                entityMov.SucursalId = sucursalOrigen;
                entityMov.SucursalDestinoId = uiSucursalDestino.EditValue != null ? (int?)(uiSucursalDestino.EditValue) : null;
                entityMov.SucursalOrigenId = sucursalOrigen;
                entityMov.FechaMovimiento = DateTime.Now;
                entityMov.HoraMovimiento = DateTime.Now.TimeOfDay;
                entityMov.Autorizado = false;
                entityMov.AutorizadoPor = null;
                entityMov.Cancelado = false;
                entityMov.Comentarios = "";
                entityMov.FechaAutoriza = null;
                entityMov.TipoMovimientoId = _tipoMovimientoId > 0 ? _tipoMovimientoId : (int)tipoMovimiento;
                entityMov.TipoMermaId = (short?)(uiTipoMovimiento.EditValue);
                entityMov.Comentarios = uiComentarios.Text;


                List<doc_inv_movimiento_detalle> lstMovsDetalle = new List<doc_inv_movimiento_detalle>();

                foreach (ProductoInventarioModel itemDet in ((List<ProductoInventarioModel>)uiGrid.DataSource)
                    .Where(W=> (W.cantidad > 0 && borrarPartidasEnCero) || borrarPartidasEnCero == false).ToList())
                {
                    doc_inv_movimiento_detalle entityMovDet = new doc_inv_movimiento_detalle();

                    entityMovDet.Cantidad = itemDet.cantidad;
                    entityMovDet.ProductoId = itemDet.productoId;
                    entityMovDet.CreadoPor = puntoVentaContext.usuarioId;

                    lstMovsDetalle.Add(entityMovDet);
                }
                oContext = new ERPProdEntities();
                
                
                    try
                    {
                        result = ERP.Business.InventarioBusiness
                        .Guardar(ref entityMov, puntoVentaContext.usuarioId, oContext);

                    /********Eliminar detalle************/
                    if(MovimientoInventarioId > 0)
                    {
                        oContext.p_doc_inv_movimiento_detalle_del(MovimientoInventarioId);
                    }
                                       

                        if (result.ok)
                        {
                            for (int i = 0; i < lstMovsDetalle.Count; i++)
                            {
                                doc_inv_movimiento_detalle itemUpd = lstMovsDetalle[i];

                                result = ERP.Business.InventarioBusiness.GuardarDetalle(ref itemUpd,
                                    entityMov, puntoVentaContext.usuarioId, oContext);

                                if (!result.ok)
                                {
                                   
                                    ERP.Utils.MessageBoxUtil.ShowError(result.error);
                                }

                                //Guarda Bitácora Báscula
                                if (oContext.cat_productos.Where(w => w.ProductoId == itemUpd.ProductoId).FirstOrDefault()
                                    .ProdVtaBascula == true)
                                {
                                    ERP.Business.BasculasBusiness.InsertBitacora(configBascula.BasculaId, puntoVentaContext.sucursalId,
                                   puntoVentaContext.usuarioId, itemUpd.Cantidad ?? 0,
                                   (int)tipoMovBascula, itemUpd.ProductoId, null);
                                }

                                

                            }
                        }


                       

                        this.MovimientoInventarioId = entityMov.MovimientoId;
                    }
                    catch (Exception ex)
                    {
                        

                        int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                        

                        result.error = String.Format("Ocurrió un error inesperado {0}",err.ToString());

                    }


                
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                

                result.error = String.Format("Ocurrió un error inesperado {0}", err.ToString());
            }

            return result;
        }

        private void uiProducto9_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto9");
        }

        private void uiProducto10_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto10");
        }

        private void uiProducto11_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto11");
        }

        private void uiProducto12_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto12");
        }

        private void uiProducto13_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto13");
        }

        private void uiProducto14_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto14");
        }

        private void uiProducto15_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto15");
        }

        private void uiProducto16_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto16");
        }

        private void uiProducto17_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto17");
        }

        private void uiProducto18_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto18");
        }

        private void uiProducto19_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto19");
        }

        private void uiProducto20_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto20");
        }

        private void uiProducto21_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto21");

        }

        private void uiProducto22_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto22");
        }

        private void uiProducto23_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto23");
        }

        private void uiProducto24_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiProducto24");
        }

        private void uiProductosMosaico_Click(object sender, EventArgs e)
        {
            AbrirMosaico();  
        }

        private void AbrirMosaico()
        {
            ERP.Common.Productos.frmProductosMosaico frmo = new Productos.frmProductosMosaico(this.puntoVentaContext, 
                Business.Enumerados.tipoModalProducto.venta);

            if(this.ClaveProductoDefault != null)
            {
                frmo = ERP.Common.Productos.frmProductosMosaico.GetInstance(this.puntoVentaContext, Business.Enumerados.tipoModalProducto.traspasoSucursal, false);

            }

            
            frmo.ClaveProductoDefault = this.ClaveProductoDefault;
            DialogResult result = frmo.ShowDialog();


            if (result == DialogResult.OK)
            {
                var producto = frmo.resultForm;
                productoSelecionado = new cat_productos()
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
                    }
                };
                uiProductoSeleccion.Text = producto.descripcion;
                uiCantidad.EditValue = producto.cantidad;
            }
        }

        private void uiClave_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                bsucarProducto();

            }
            if (e.KeyCode == Keys.F3)
            {
                F3Buscar();
            }
        }

        private void bsucarProducto()
        {
            ERPProdEntities oContext = new ERPProdEntities();
            productoSelecionado = oContext.cat_productos
                .Where(W => W.Clave == uiClave.Text || W.CodigoBarras == uiClave.Text).FirstOrDefault();

            if (productoSelecionado != null)
            {
                uiProductoSeleccion.Text = productoSelecionado.Descripcion;
                uiCantidad.Enabled = true;
                uiCantidad.Select();
                uiCantidad.SelectAll();

            }
        }

        private void uiCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                agregar();
            }
            if(e.KeyCode == Keys.F3)
            {
                F3Buscar();
            }
        }

        private void F3Buscar()
        {
            frmProductosBusqueda frmBuscar = new frmProductosBusqueda();
            frmBuscar.soloParaVenta = true;
            frmBuscar.puntoVentaContext = this.puntoVentaContext;
            frmBuscar.cargarEnInicio = false;
            frmBuscar.soloProductosSucursal = true;
            var result = frmBuscar.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (frmBuscar.response != null)
                {
                    uiClave.Text = frmBuscar.response.CodigoBarras;

                    bsucarProducto();

                }


            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            F3Buscar();
        }

        private void zoomTrackBarControl1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void uiRellenarProductosSucursal_CheckedChanged(object sender, EventArgs e)
        {
            if(MovimientoInventarioId > 0)
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("No es posible cargar los productos cuando ya hay una captura previa");
            }
            else
            {
                LoadGrid(uiRellenarProductosSucursal.Checked);
            }
            
        }

        private void uiImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if(MovimientoInventarioId > 0)
                {
                    doc_inv_movimiento eMov = oContext.doc_inv_movimiento.Where(w => w.MovimientoId == MovimientoInventarioId).FirstOrDefault();

                    if (eMov.Cancelado ?? false)
                    {
                        imprimirCancelacion();
                    }
                    else
                    {
                        imprimir();
                    }
                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Aun no se guarda la información, no es posible imprimir");
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
        }

        private void boton_imprimir()
        {
            try
            {
                doc_inv_movimiento eMov = oContext.doc_inv_movimiento.Where(w => w.MovimientoId == this.MovimientoInventarioId).FirstOrDefault();

                if (eMov.Cancelado ?? false)
                {
                    imprimirCancelacion();
                }
                else
                {
                    imprimir();
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


        private void imprimir()
        {
            rptMovimientoInventario oTicket = new rptMovimientoInventario();
            ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer();
            oContext = new ERPProdEntities();
            var ds = oContext.p_inv_movimiento_rpt(MovimientoInventarioId).ToList();
            oTicket.DataSource = ds;
            oTicket.autorizadoPor = ds.FirstOrDefault().AutorizadoPor;
            oTicket.comentarios = ds.FirstOrDefault().Comentarios;
            oViewer.ShowTicket(oTicket);
        }

        private void imprimirCancelacion()
        {
            rptMovimientoInventarioCancelacion oTicket = new rptMovimientoInventarioCancelacion();
            ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer();
            oContext = new ERPProdEntities();
            var ds = oContext.p_rpt_movimiento_cancela_inv(MovimientoInventarioId, 0).ToList();
            oTicket.DataSource = ds;
            oTicket.autorizadoPor = ds.FirstOrDefault().AutorizadoPor;

            oViewer.ShowTicket(oTicket);
        }

        private  void HabilitarDeshabilitarBotones()
        {
            try
            {

                LoadEntity();

                //Controles Traspaso
                if(entity.TipoMovimientoId == (int)ERP.Business.Enumerados.tipoMovimientoInventario.EntradaPorTraspaso ||
                    entity.TipoMovimientoId == (int)ERP.Business.Enumerados.tipoMovimientoInventario.SalidaPorTraspaso ||
                    entity.TipoMovimientoId == (int)ERP.Business.Enumerados.tipoMovimientoInventario.SalidaPorTraspasoDev)
                {
                    colexistenciaDestino.Width = 120;
                    
                    laySucursalDestino.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    colexistenciaDestino.Width = 0;
                    laySucursalDestino.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }

                //Controles Salida por ajuste
                if (tipoMovimiento == ERP.Business.Enumerados.tipoMovimientoInventario.AjustePorSalida)
                {
                    layComentario.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layTipoMov.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    layComentario.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layTipoMov.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }

                if (entity.MovimientoId == 0)
                {
                    if(tipoMovimiento == Business.Enumerados.tipoMovimientoInventario.EntradaPorTraspaso ||
                       tipoMovimiento == Business.Enumerados.tipoMovimientoInventario.SalidaPorTraspaso ||
                       tipoMovimiento == Business.Enumerados.tipoMovimientoInventario.SalidaPorTraspasoDev)
                    {
                        laySucursalDestino.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        colexistenciaDestino.Width = 120;
                    }
                    else
                    {
                        laySucursalDestino.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        colexistenciaDestino.Width = 0;

                    }
                }

                if(entity.MovimientoId > 0)
                {
                    uiRellenarProductosSucursal.Enabled = false;
                    uiSucursalDestino.ReadOnly = true;
                }
                if (entity.Autorizado ?? false)
                {

                    uiImprimir.Enabled = true;
                    uiGuardar.Enabled = false;
                    uiAutorizar.Enabled = false;
                    uiAgregar.Enabled = false;
                    colAccion.Visible = false;
                }
                else {

                    uiImprimir.Enabled = false;
                    uiGuardar.Enabled = true;
                    uiAutorizar.Enabled = true;
                    colAccion.Visible = true;
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
        }

        private bool ValidaGuardar()
        {
            try
            {
                if(uiSucursalOrigen.EditValue == null)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("La sucursal origen es requerida");
                }
                if(tipoMovimiento== Business.Enumerados.tipoMovimientoInventario.AjustePorSalida)
                {
                    if(uiTipoMovimiento.EditValue == null)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario ingresar el tipo de movimiento");
                    }
                    if (uiComentarios.Text.Trim().Length == 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario ingresar un comentario");
                    }
                }

                if (tipoMovimiento == Business.Enumerados.tipoMovimientoInventario.SalidaPorTraspaso)
                {
                    if (uiSucursalDestino.EditValue == null)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario ingresar una sucursal Destino");
                    }
                    
                }

                if (((List<ProductoInventarioModel>)uiGrid.DataSource).Where(w=> w.cantidad > 0).Count() == 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Agregue productos al listado con cantidad para continuar");

                    return false;
                }



                if (XtraMessageBox.Show("¿Está seguro(a) de continuar?",
                    "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                     "ERP",
                                     this.Name,
                                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);

                return false;
            }
        }
        private void uiGrid_Click(object sender, EventArgs e)
        {

        }

        public ResultAPIModel GeneraTraspasoAutomatico(int empresaId, int movimientoInvOrigenId, int usuarioId)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                oContext = new ERPProdEntities();

                cat_empresas_config_inventario confEmpresaIn = oContext.cat_empresas_config_inventario
                    .Where(w => w.EmpresaId == empresaId).FirstOrDefault();



                if (confEmpresaIn == null)
                {
                    result.error = "No están habilitados los traspasos automáticos";
                    return result;
                }
                if (!confEmpresaIn.EnableTraspasoAutomatico)
                {
                    result.error = "No están habilitados los traspasos automáticos";
                    return result;
                }


                doc_inv_movimiento movOrigen = oContext.doc_inv_movimiento
                    .Where(w => w.Activo == true
                    && w.Autorizado == true
                    && w.Activo == true
                    && (w.Cancelado ?? false) == false
                    && w.MovimientoId == movimientoInvOrigenId).FirstOrDefault();

                //TRASPASOS
                if (movOrigen.TipoMovimientoId == (int)ConexionBD.Enumerados.tipoMovsInventario.salidaPorTraspaso)
                {


                    if (movOrigen != null)
                    {
                        int tipoMovimientoId = (int)ConexionBD.Enumerados.tipoMovsInventario.entradaPorTraspaso;
                        doc_inv_movimiento movDestino = new doc_inv_movimiento();
                        int sucursalOrigenId = movOrigen.SucursalDestinoId ?? 0;
                        DateTime fechaMov = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                        movDestino.MovimientoId = (oContext.doc_inv_movimiento
                            .Max(m => (int?)m.MovimientoId) ?? 0) + 1;
                        movDestino.Activo = true;
                        movDestino.Autorizado = true;
                        movDestino.AutorizadoPor = movOrigen.AutorizadoPor;
                        movDestino.Cancelado = movOrigen.Cancelado;
                        movDestino.Comentarios = (movOrigen.Comentarios ?? "") + "|TRASPASO GENERADO DE MENERA AUTMÁTICA";
                        movDestino.Consecutivo = (oContext.doc_inv_movimiento
                            .Where(w => w.SucursalId == sucursalOrigenId &&
                            w.TipoMovimientoId == tipoMovimientoId).Max(m => (int?)m.Consecutivo) ?? 0) + 1;
                        movDestino.CreadoEl = fechaMov;
                        movDestino.CreadoPor = usuarioId;
                        movDestino.FechaAutoriza = fechaMov;
                        movDestino.FechaMovimiento = fechaMov;
                        movDestino.FolioMovimiento = movDestino.Consecutivo.ToString();
                        movDestino.HoraMovimiento = fechaMov.Date.TimeOfDay;
                        movDestino.ImporteTotal = movOrigen.ImporteTotal;
                        movDestino.SucursalOrigenId = movOrigen.SucursalOrigenId;
                        movDestino.SucursalDestinoId = movOrigen.SucursalDestinoId;
                        movDestino.SucursalId = sucursalOrigenId;
                        movDestino.TipoMovimientoId = tipoMovimientoId;

                        oContext.doc_inv_movimiento.Add(movDestino);
                        oContext.SaveChanges();
                        oContext = new ERPProdEntities();

                        short consecutivoDet = 1;

                        foreach (var itemDestinoDet in movOrigen.doc_inv_movimiento_detalle)
                        {
                            fechaMov = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            doc_inv_movimiento_detalle movDestinoDet = new doc_inv_movimiento_detalle();

                            movDestinoDet.Cantidad = itemDestinoDet.Cantidad;
                            movDestinoDet.Comisiones = itemDestinoDet.Comisiones;
                            movDestinoDet.Consecutivo = consecutivoDet;
                            movDestinoDet.CostoPromedio = 0;
                            movDestinoDet.CostoUltimaCompra = 0;
                            movDestinoDet.CreadoEl = fechaMov;
                            movDestinoDet.CreadoPor = usuarioId;
                            movDestinoDet.Disponible = null;
                            movDestinoDet.Flete = itemDestinoDet.Flete;
                            movDestinoDet.Importe = itemDestinoDet.Importe;
                            movDestinoDet.MovimientoDetalleId = (oContext.doc_inv_movimiento_detalle
                                .Max(m => (int?)m.MovimientoDetalleId) ?? 0) + 1;
                            movDestinoDet.MovimientoId = movDestino.MovimientoId;
                            movDestinoDet.PrecioUnitario = itemDestinoDet.PrecioUnitario;
                            movDestinoDet.ProductoId = itemDestinoDet.ProductoId;
                            movDestinoDet.ValCostoPromedio = 0;
                            movDestinoDet.ValCostoUltimaCompra = 0;
                            movDestinoDet.ValorMovimiento = 0;

                           
                            oContext.doc_inv_movimiento_detalle.Add(movDestinoDet);
                            oContext.SaveChanges();

                           
                                
                        }


                    }

                }
                if (movOrigen.TipoMovimientoId == (int)ConexionBD.Enumerados.tipoMovsInventario.entradaPorTraspaso)
                {


                    if (movOrigen != null)
                    {
                        int tipoMovimientoId = (int)ConexionBD.Enumerados.tipoMovsInventario.salidaPorTraspaso;
                        doc_inv_movimiento movDestino = new doc_inv_movimiento();
                        int sucursalOrigenId = movOrigen.SucursalOrigenId ?? 0;
                        DateTime fechaMov = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                        movDestino.MovimientoId = (oContext.doc_inv_movimiento
                            .Max(m => (int?)m.MovimientoId) ?? 0) + 1;
                        movDestino.Activo = true;
                        movDestino.Autorizado = true;
                        movDestino.AutorizadoPor = movOrigen.AutorizadoPor;
                        movDestino.Cancelado = movOrigen.Cancelado;
                        movDestino.Comentarios = (movOrigen.Comentarios ?? "") + "|TRASPASO GENERADO DE MENERA AUTMÁTICA";
                        movDestino.Consecutivo = (oContext.doc_inv_movimiento
                            .Where(w => w.SucursalId == sucursalOrigenId &&
                            w.TipoMovimientoId == tipoMovimientoId).Max(m => (int?)m.Consecutivo) ?? 0) + 1;
                        movDestino.CreadoEl = fechaMov;
                        movDestino.CreadoPor = usuarioId;
                        movDestino.FechaAutoriza = fechaMov;
                        movDestino.FechaMovimiento = fechaMov;
                        movDestino.FolioMovimiento = movDestino.Consecutivo.ToString();
                        movDestino.HoraMovimiento = fechaMov.Date.TimeOfDay;
                        movDestino.ImporteTotal = movOrigen.ImporteTotal;
                        movDestino.SucursalDestinoId = movOrigen.SucursalDestinoId;
                        movDestino.SucursalId = sucursalOrigenId;
                        movDestino.TipoMovimientoId = tipoMovimientoId;
                        movDestino.SucursalOrigenId = movOrigen.SucursalOrigenId;

                        oContext.doc_inv_movimiento.Add(movDestino);
                        oContext.SaveChanges();
                        oContext = new ERPProdEntities();

                        short consecutivoDet = 1;

                        foreach (var itemDestinoDet in movOrigen.doc_inv_movimiento_detalle)
                        {
                            fechaMov = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            doc_inv_movimiento_detalle movDestinoDet = new doc_inv_movimiento_detalle();

                            movDestinoDet.Cantidad = itemDestinoDet.Cantidad;
                            movDestinoDet.Comisiones = itemDestinoDet.Comisiones;
                            movDestinoDet.Consecutivo = consecutivoDet;
                            movDestinoDet.CostoPromedio = 0;
                            movDestinoDet.CostoUltimaCompra = 0;
                            movDestinoDet.CreadoEl = fechaMov;
                            movDestinoDet.CreadoPor = usuarioId;
                            movDestinoDet.Disponible = null;
                            movDestinoDet.Flete = itemDestinoDet.Flete;
                            movDestinoDet.Importe = itemDestinoDet.Importe;
                            movDestinoDet.MovimientoDetalleId = (oContext.doc_inv_movimiento_detalle
                                .Max(m => (int?)m.MovimientoDetalleId) ?? 0) + 1;
                            movDestinoDet.MovimientoId = movDestino.MovimientoId;
                            movDestinoDet.PrecioUnitario = itemDestinoDet.PrecioUnitario;
                            movDestinoDet.ProductoId = itemDestinoDet.ProductoId;
                            movDestinoDet.ValCostoPromedio = 0;
                            movDestinoDet.ValCostoUltimaCompra = 0;
                            movDestinoDet.ValorMovimiento = 0;

                            oContext.doc_inv_movimiento_detalle.Add(movDestinoDet);
                            oContext.SaveChanges();

                        }


                    }

                }

                //TRASPASOS POR DEVOLUCIÓN
                if (movOrigen.TipoMovimientoId == (int)ConexionBD.Enumerados.tipoMovsInventario.salidaTraspasoDev)
                {


                    if (movOrigen != null)
                    {
                        int tipoMovimientoId = (int)ConexionBD.Enumerados.tipoMovsInventario.entradaTraspasoDev;
                        doc_inv_movimiento movDestino = new doc_inv_movimiento();
                        int sucursalOrigenId = movOrigen.SucursalDestinoId ?? 0;
                        DateTime fechaMov = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                        movDestino.MovimientoId = (oContext.doc_inv_movimiento
                            .Max(m => (int?)m.MovimientoId) ?? 0) + 1;
                        movDestino.Activo = true;
                        movDestino.Autorizado = true;
                        movDestino.AutorizadoPor = movOrigen.AutorizadoPor;
                        movDestino.Cancelado = movOrigen.Cancelado;
                        movDestino.Comentarios = (movOrigen.Comentarios ?? "") + "|TRASPASO GENERADO DE MENERA AUTMÁTICA";
                        movDestino.Consecutivo = (oContext.doc_inv_movimiento
                            .Where(w => w.SucursalId == sucursalOrigenId &&
                            w.TipoMovimientoId == tipoMovimientoId).Max(m => (int?)m.Consecutivo) ?? 0) + 1;
                        movDestino.CreadoEl = fechaMov;
                        movDestino.CreadoPor = usuarioId;
                        movDestino.FechaAutoriza = fechaMov;
                        movDestino.FechaMovimiento = fechaMov;
                        movDestino.FolioMovimiento = movDestino.Consecutivo.ToString();
                        movDestino.HoraMovimiento = fechaMov.Date.TimeOfDay;
                        movDestino.ImporteTotal = movOrigen.ImporteTotal;
                        movDestino.SucursalOrigenId = movOrigen.SucursalOrigenId;
                        movDestino.SucursalDestinoId = movOrigen.SucursalDestinoId;
                        movDestino.SucursalId = movOrigen.SucursalDestinoId??0;
                        movDestino.TipoMovimientoId = tipoMovimientoId;

                        oContext.doc_inv_movimiento.Add(movDestino);
                        oContext.SaveChanges();
                        oContext = new ERPProdEntities();

                        short consecutivoDet = 1;

                        foreach (var itemDestinoDet in movOrigen.doc_inv_movimiento_detalle)
                        {
                            fechaMov = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            doc_inv_movimiento_detalle movDestinoDet = new doc_inv_movimiento_detalle();

                            movDestinoDet.Cantidad = itemDestinoDet.Cantidad;
                            movDestinoDet.Comisiones = itemDestinoDet.Comisiones;
                            movDestinoDet.Consecutivo = consecutivoDet;
                            movDestinoDet.CostoPromedio = 0;
                            movDestinoDet.CostoUltimaCompra = 0;
                            movDestinoDet.CreadoEl = fechaMov;
                            movDestinoDet.CreadoPor = usuarioId;
                            movDestinoDet.Disponible = null;
                            movDestinoDet.Flete = itemDestinoDet.Flete;
                            movDestinoDet.Importe = itemDestinoDet.Importe;
                            movDestinoDet.MovimientoDetalleId = (oContext.doc_inv_movimiento_detalle
                                .Max(m => (int?)m.MovimientoDetalleId) ?? 0) + 1;
                            movDestinoDet.MovimientoId = movDestino.MovimientoId;
                            movDestinoDet.PrecioUnitario = itemDestinoDet.PrecioUnitario;
                            movDestinoDet.ProductoId = itemDestinoDet.ProductoId;
                            movDestinoDet.ValCostoPromedio = 0;
                            movDestinoDet.ValCostoUltimaCompra = 0;
                            movDestinoDet.ValorMovimiento = 0;


                            oContext.doc_inv_movimiento_detalle.Add(movDestinoDet);
                            oContext.SaveChanges();



                        }


                    }

                }
                if (movOrigen.TipoMovimientoId == (int)ConexionBD.Enumerados.tipoMovsInventario.entradaTraspasoDev)
                {


                    if (movOrigen != null)
                    {
                        int tipoMovimientoId = (int)ConexionBD.Enumerados.tipoMovsInventario.salidaTraspasoDev;
                        doc_inv_movimiento movDestino = new doc_inv_movimiento();
                        int sucursalOrigenId = movOrigen.SucursalOrigenId ?? 0;
                        DateTime fechaMov = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                        movDestino.MovimientoId = (oContext.doc_inv_movimiento
                            .Max(m => (int?)m.MovimientoId) ?? 0) + 1;
                        movDestino.Activo = true;
                        movDestino.Autorizado = true;
                        movDestino.AutorizadoPor = movOrigen.AutorizadoPor;
                        movDestino.Cancelado = movOrigen.Cancelado;
                        movDestino.Comentarios = (movOrigen.Comentarios ?? "") + "|TRASPASO GENERADO DE MENERA AUTMÁTICA";
                        movDestino.Consecutivo = (oContext.doc_inv_movimiento
                            .Where(w => w.SucursalId == sucursalOrigenId &&
                            w.TipoMovimientoId == tipoMovimientoId).Max(m => (int?)m.Consecutivo) ?? 0) + 1;
                        movDestino.CreadoEl = fechaMov;
                        movDestino.CreadoPor = usuarioId;
                        movDestino.FechaAutoriza = fechaMov;
                        movDestino.FechaMovimiento = fechaMov;
                        movDestino.FolioMovimiento = movDestino.Consecutivo.ToString();
                        movDestino.HoraMovimiento = fechaMov.Date.TimeOfDay;
                        movDestino.ImporteTotal = movOrigen.ImporteTotal;
                        movDestino.SucursalDestinoId = movOrigen.SucursalDestinoId;
                        movDestino.SucursalId = sucursalOrigenId;
                        movDestino.TipoMovimientoId = tipoMovimientoId;
                        movDestino.SucursalOrigenId = movOrigen.SucursalOrigenId;

                        oContext.doc_inv_movimiento.Add(movDestino);
                        oContext.SaveChanges();
                        oContext = new ERPProdEntities();

                        short consecutivoDet = 1;

                        foreach (var itemDestinoDet in movOrigen.doc_inv_movimiento_detalle)
                        {
                            fechaMov = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            doc_inv_movimiento_detalle movDestinoDet = new doc_inv_movimiento_detalle();

                            movDestinoDet.Cantidad = itemDestinoDet.Cantidad;
                            movDestinoDet.Comisiones = itemDestinoDet.Comisiones;
                            movDestinoDet.Consecutivo = consecutivoDet;
                            movDestinoDet.CostoPromedio = 0;
                            movDestinoDet.CostoUltimaCompra = 0;
                            movDestinoDet.CreadoEl = fechaMov;
                            movDestinoDet.CreadoPor = usuarioId;
                            movDestinoDet.Disponible = null;
                            movDestinoDet.Flete = itemDestinoDet.Flete;
                            movDestinoDet.Importe = itemDestinoDet.Importe;
                            movDestinoDet.MovimientoDetalleId = (oContext.doc_inv_movimiento_detalle
                                .Max(m => (int?)m.MovimientoDetalleId) ?? 0) + 1;
                            movDestinoDet.MovimientoId = movDestino.MovimientoId;
                            movDestinoDet.PrecioUnitario = itemDestinoDet.PrecioUnitario;
                            movDestinoDet.ProductoId = itemDestinoDet.ProductoId;
                            movDestinoDet.ValCostoPromedio = 0;
                            movDestinoDet.ValCostoUltimaCompra = 0;
                            movDestinoDet.ValorMovimiento = 0;

                            oContext.doc_inv_movimiento_detalle.Add(movDestinoDet);
                            oContext.SaveChanges();

                        }


                    }

                }


            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }

            return result;
        }

        private void GuardarTraspasoAutomatico()
        {
            #region traspaso automático
            int empresaId = this.puntoVentaContext.empresaId;
            cat_empresas_config_inventario confEmp = oContext
                .cat_empresas_config_inventario
                .Where(w => w.EmpresaId == empresaId).FirstOrDefault();

            if ((confEmp == null ? false : confEmp.EnableTraspasoAutomatico)
                && (
                    tipoMovimiento == ERP.Business.Enumerados.tipoMovimientoInventario.SalidaPorTraspaso ||
                    tipoMovimiento == ERP.Business.Enumerados.tipoMovimientoInventario.EntradaPorTraspaso ||
                    tipoMovimiento == ERP.Business.Enumerados.tipoMovimientoInventario.SalidaPorTraspasoDev
                ))
            {

                ResultAPIModel result = GeneraTraspasoAutomatico(empresaId, MovimientoInventarioId, this.puntoVentaContext.usuarioId);

                if (!result.ok)
                {
                    ERP.Utils.MessageBoxUtil.ShowError(result.error);

                    
                }

            }
            #endregion

        }
        private bool autorizarInv()
        {
            try
            {

                if (btnGuardar())
                {
                    oContext.p_inv_movimiento_autoriza(this.MovimientoInventarioId, 1);

                    GuardarTraspasoAutomatico();


                    ERP.Utils.MessageBoxUtil.ShowOk();

                   

                    return true;
                }
                return false;



            }
            catch (Exception ex)
            {
                

                err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                     "ERP",
                                     this.Name,
                                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);

                return false;
            }
        }

        private  void uiAutorizar_Click(object sender, EventArgs e)
        {


            //loading.Show();
            //autorizar = true;
            //Task<bool> oTask = new Task<bool>(autorizarInv);

            //oTask.Start();
            //await oTask;
            //loading.Hide();
            //if (oTask.Result)
            //{
            //    GuardarTraspasoAutomatico();
            //    HabilitarDeshabilitarBotones();
            //    imprimir();
            //}

            if (!ValidaGuardar())
            {
                return;
            }

            loading.Show();
            autorizar = true;
            
            
            if (autorizarInv())
            {
                
                HabilitarDeshabilitarBotones();
                imprimir();
                LoadGrid(false);
            }

            loading.Hide();


        }

        private void uiSucursalOrigen_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void uiSucursalOrigen_EditValueChanged_1(object sender, EventArgs e)
        {
            uiRellenarProductosSucursal.Checked = false;
            uiGrid.DataSource = null;
            sucursalOrigen = Convert.ToInt32(uiSucursalOrigen.EditValue);
        }

        private void uiSucursalDestino_EditValueChanged(object sender, EventArgs e)
        {
            uiRellenarProductosSucursal.Checked = false;
            uiGrid.DataSource = null;
            sucursalDestinoId = Convert.ToInt32(uiSucursalDestino.EditValue);
        }
    }
}
