using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Business.Tools;
using ERP.Common.Base;
using ERP.Common.Productos;
using ERP.Models;
using ERP.Models.Inventario;
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
    public partial class frmRecepcionProducto : FormBaseXtraForm
    {
        cat_productos productoSelecionado;
        List<cat_productos> lstProductos;
        BasculaLectura basculaControlador;
        List<ERP.Models.Inventario.ProductoInventarioModel> lstProductosTraspaso;
        public Enumerados.tipoMovsInventario tipoMovimiento { get; set; }
        private ERP.Business.Enumerados.tipoBasculaBitacora tipoMovBascula;
        public string titulo { get; set; }
        public string ClaveProductoDefault { get; set; }
        public frmRecepcionProducto()
        {
            InitializeComponent();
        }
        private static frmRecepcionProducto _instance;
        public static frmRecepcionProducto GetInstance()
        {
            if (_instance == null) _instance = new frmRecepcionProducto();
            else _instance.BringToFront();
            return _instance;
        }

        private void frmTraspasosSalidaLite_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
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
        private void frmTraspasosSalidaLite_Load(object sender, EventArgs e)
        {
            try
            {
                if(tipoMovimiento== Enumerados.tipoMovsInventario.entradaDirecta)
                {
                    this.lblTitulo.Text = "Entrada Directa";
                    this.uiGuardar.Text = "Guardar ENTRADA";
                    tipoMovBascula = Business.Enumerados.tipoBasculaBitacora.EntradaInventario;
                }
                if (tipoMovimiento == Enumerados.tipoMovsInventario.ajustePorSalida)
                {
                    this.lblTitulo.Text = "Salida por Traspaso";
                    this.uiGuardar.Text = "Guardar SALIDA";
                    tipoMovBascula = Business.Enumerados.tipoBasculaBitacora.SalidaInventario;
                }
                if (tipoMovimiento == Enumerados.tipoMovsInventario.desperdicioInventario)
                {
                    this.lblTitulo.Text = "Desperdicio de Inventario";
                    this.uiGuardar.Text = "Guardar SALIDA";
                    tipoMovBascula = Business.Enumerados.tipoBasculaBitacora.DesperdicioInventario;
                }
                this.Text = this.lblTitulo.Text;
                
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

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var configBascula = ERP.Business.BasculasBusiness.GetConfiguracionPCLocal(puntoVentaContext.usuarioId);

                if(configBascula == null)
                {
                    ERP.Utils.MessageBoxUtil.ShowError("No existe configuración de Báscula");
                    
                }

                if (lstProductosTraspaso.Count <= 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowError("No hay productos para el traspaso");
                    return;
                }
               

                if(XtraMessageBox.Show("¿Está seguro(a) de continuar?, no será posible revertir los cambios",
                    "Aviso", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                ResultAPIModel result = new ResultAPIModel();
                result = Guardar();
                if (result.ok)
                {
                    if(this.tipoMovimiento == Enumerados.tipoMovsInventario.desperdicioInventario)
                    {
                        List<ProductoInventarioModel> lstProductosDesperdicio = new List<ProductoInventarioModel>();

                        foreach (var itemDesperdicio in lstProductosTraspaso.Where(w=> w.descripcion.ToUpper() == "MASA" ||
                        w.descripcion.ToUpper() == "TORTILLA"
                        ))
                        {
                            ProductoInventarioModel itemAdd = itemDesperdicio;
                            try
                            {
                                if (itemAdd.descripcion.ToUpper() == "TORTILLA")
                                {
                                    itemAdd.productoId = oContext.cat_productos
                                        .Where(w => w.Descripcion == "DESPERDICIO TORTILLA").FirstOrDefault().ProductoId;
                                }

                                if (itemAdd.descripcion.ToUpper() == "MASA")
                                {
                                    itemAdd.productoId = oContext.cat_productos
                                        .Where(w => w.Descripcion == "DESPERDICIO MASA").FirstOrDefault().ProductoId;
                                }
                            }
                            catch (Exception)
                            {
                                                                
                            }
                            

                            lstProductosDesperdicio.Add(itemAdd);
                        }
                        lstProductosTraspaso = lstProductosDesperdicio;
                        if(lstProductosTraspaso.Count() > 0)
                        {
                            Guardar((int)ERP.Business.Enumerados.tipoMovimientoInventario.AjustePorEntrada);
                        }
                        

                    }
                    //ERP.Utils.MessageBoxUtil.ShowOk();
                    //this.Close();
                    limpiar();

                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowError(result.error);
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

        private ResultAPIModel Guardar(int _tipoMovimientoId=0)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                
                var configBascula = ERP.Business.BasculasBusiness.GetConfiguracionPCLocal(puntoVentaContext.usuarioId);
                doc_inv_movimiento entityMov = new doc_inv_movimiento();

                entityMov.Activo = true;
                entityMov.SucursalId = puntoVentaContext.sucursalId;
                entityMov.SucursalDestinoId = null;
                entityMov.SucursalOrigenId = puntoVentaContext.sucursalId;
                entityMov.FechaMovimiento = DateTime.Now;
                entityMov.HoraMovimiento = DateTime.Now.TimeOfDay;
                entityMov.Autorizado = true;
                entityMov.AutorizadoPor = puntoVentaContext.usuarioId;
                entityMov.Cancelado = false;
                entityMov.Comentarios = "Recepción de servicio en Sucursal";
                entityMov.FechaAutoriza = DateTime.Now;
                entityMov.TipoMovimientoId = _tipoMovimientoId > 0 ? _tipoMovimientoId : (int)tipoMovimiento;

                List<doc_inv_movimiento_detalle> lstMovsDetalle = new List<doc_inv_movimiento_detalle>();

                foreach (ProductoInventarioModel itemDet in lstProductosTraspaso)
                {
                    doc_inv_movimiento_detalle entityMovDet = new doc_inv_movimiento_detalle();

                    entityMovDet.Cantidad = itemDet.cantidad;
                    entityMovDet.ProductoId = itemDet.productoId;
                    entityMovDet.CreadoPor = puntoVentaContext.usuarioId;

                    lstMovsDetalle.Add(entityMovDet);
                }
                oContext = new ERPProdEntities();
                
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        result = ERP.Business.InventarioBusiness
                        .Guardar(ref entityMov, puntoVentaContext.usuarioId, oContext);

                        if (result.ok)
                        {
                            for (int i = 0; i < lstMovsDetalle.Count; i++)
                            {
                                doc_inv_movimiento_detalle itemUpd = lstMovsDetalle[i];

                                result = ERP.Business.InventarioBusiness.GuardarDetalle(ref itemUpd,
                                    entityMov, puntoVentaContext.usuarioId, oContext);

                                if (!result.ok)
                                {
                                    scope.Dispose();
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

                                if (tipoMovimiento == Enumerados.tipoMovsInventario.desperdicioInventario)
                                {

                                }

                            }
                        }


                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();

                        int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                        

                        result.error = String.Format("Ocurrió un error inesperado {0}",err.ToString());

                    }


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
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            frmProductosBusqueda frmBuscar = new frmProductosBusqueda();
            frmBuscar.soloParaVenta = true;
            frmBuscar.puntoVentaContext = this.puntoVentaContext;
            frmBuscar.cargarEnInicio = false;
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
    }
}
