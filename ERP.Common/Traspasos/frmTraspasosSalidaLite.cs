using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Business.Tools;
using ERP.Common.Base;
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
using System.Windows.Forms;

namespace ERP.Common.Traspasos
{
    public partial class frmTraspasosSalidaLite : FormBaseXtraForm
    {
        cat_productos productoSelecionado;
        List<cat_productos> lstProductos;
        BasculaLectura basculaControlador;
        List<ERP.Models.Inventario.ProductoInventarioModel> lstProductosTraspaso;
        public frmTraspasosSalidaLite()
        {
            InitializeComponent();
        }
        private static frmTraspasosSalidaLite _instance;
        public static frmTraspasosSalidaLite GetInstance()
        {
            if (_instance == null) _instance = new frmTraspasosSalidaLite();
            else _instance.BringToFront();
            return _instance;
        }

        private void frmTraspasosSalidaLite_FormClosing(object sender, FormClosingEventArgs e)
        {
            basculaControlador.cerrarBascula();
            _instance = null;
        }


        public void LoadDestinos()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();

                int sucursalOrigenId = this.puntoVentaContext.sucursalId;

                uiDestino.Properties.DataSource = oContext
                    .cat_sucursales
                    .Where(w => w.Estatus == true &&
                    w.Clave != sucursalOrigenId).ToList();
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
                for (int j = 1; j <= 8; j++)
                {
                    Control controlA = Controls.Find("uiProducto" + j.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.Enabled = true;
                    }
                }




                /*Deshabilitar botones sin productos*/
                if ((lstProductos.Count + 1) <= 8)
                {
                    for (int j = (lstProductos.Count + 1); j <= 8; j++)
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
                lstProductosTraspaso = new List<ProductoInventarioModel>();
                basculaControlador = new BasculaLectura(this.puntoVentaContext);
                oContext = new ERPProdEntities();
                lstProductos = oContext
                    .cat_productos
                    .Where(w => w.Estatus == true && 
                        (w.ProductoId == 119 || 
                        w.ProductoId==669 || 
                        w.ProductoId == 185 || 
                        w.ProductoId == 118 || 
                        w.ProductoId == 161)
                    )
                    .OrderByDescending(o=> o.DescripcionCorta)
                    .ToList();

                uiSucursalOrigen.Text = this.puntoVentaContext.nombreSucursal;
                LlenarBotones();
                LoadDestinos();
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

        private void uiAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if(uiCantidad.Value <= 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("La cantidad debe de ser mayor a 0");
                    return;
                }
                if(productoSelecionado != null)
                {
                    if(lstProductosTraspaso == null)
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

                    basculaControlador.cerrarBascula();
                    uiCantidad.Value = 0;

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

        private void timerBascula_Tick(object sender, EventArgs e)
        {
            try
            {
                uiCantidad.EditValue = basculaControlador.ObtenPeso();
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
                if(lstProductosTraspaso.Count <= 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowError("No hay productos para el traspaso");
                    return;
                }
                if(Convert.ToInt32(uiDestino.EditValue) == 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowError("Seleccione una sucursal destino");
                    return;
                }

                if(XtraMessageBox.Show("¿Está seguro(a) de continuar?, no será posible revertir los cambios",
                    "Aviso", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                doc_inv_movimiento entityMov = new doc_inv_movimiento();

                entityMov.Activo = true;
                entityMov.SucursalId = puntoVentaContext.sucursalId;
                entityMov.SucursalDestinoId = Convert.ToInt32(uiDestino.EditValue);
                entityMov.SucursalOrigenId = puntoVentaContext.sucursalId;
                entityMov.FechaMovimiento = DateTime.Now;
                entityMov.HoraMovimiento = DateTime.Now.TimeOfDay;
                entityMov.Autorizado = true;
                entityMov.AutorizadoPor = puntoVentaContext.usuarioId;
                entityMov.Cancelado = false;
                entityMov.Comentarios = "";
                entityMov.FechaAutoriza = DateTime.Now;              
                entityMov.TipoMovimientoId = (int)Enumerados.tipoMovsInventario.salidaPorTraspaso;

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
                ResultAPIModel result= ERP.Business.InventarioBusiness
                    .GuardarTraspaso(ref entityMov, lstMovsDetalle, puntoVentaContext.usuarioId, puntoVentaContext.empresaId,
                    oContext);

                if (result.ok)
                {
                    ERP.Utils.MessageBoxUtil.ShowOk();
                    this.Close();
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

        private void uiMosaico_Click(object sender, EventArgs e)
        {

            ERP.Common.Productos.frmProductosMosaico frmo = ERP.Common.Productos.frmProductosMosaico.GetInstance(this.puntoVentaContext, Business.Enumerados.tipoModalProducto.traspasoSucursal );
          
            DialogResult result = frmo.ShowDialog();
            

            if (result == DialogResult.OK)
            {
                var producto = frmo.resultForm;
                productoSelecionado = new cat_productos() {
                    ProductoId = producto.productoId, Descripcion = producto.descripcion ,DescripcionCorta = producto.descripcion,
                    Clave = producto.clave,
                    cat_unidadesmed = new cat_unidadesmed() {
                        Clave = producto.unidadId,Descripcion = producto.unidad,DescripcionCorta = producto.unidad
                    }
                };
                uiProductoSeleccion.Text = producto.descripcion;
                uiCantidad.EditValue = producto.cantidad;
            }
        }
    }
}
