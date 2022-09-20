using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Business;
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

namespace ERP.Common.PuntoVenta
{
    public partial class frmProductoSobranteUpd : FormBaseXtraForm
    {
        cat_productos productoSelecionado;
        List<cat_productos> lstProductos;
        BasculaLectura basculaControlador;
        List<ERP.Models.Inventario.ProductoInventarioModel> lstProductosTraspaso;
        public frmProductoSobranteUpd()
        {
            InitializeComponent();
        }
        private static frmProductoSobranteUpd _instance;
        public static frmProductoSobranteUpd GetInstance()
        {
            if (_instance == null) _instance = new frmProductoSobranteUpd();
            else _instance.BringToFront();
            return _instance;
        }

        private void frmTraspasosSalidaLite_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (puntoVentaContext.conectarConBascula)
            {
                basculaControlador.cerrarBascula();
            }
            
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

                if (puntoVentaContext.conectarConBascula)
                {
                    basculaControlador = new BasculaLectura(this.puntoVentaContext);
                }
                
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
                        if (puntoVentaContext.conectarConBascula)
                        {
                            basculaControlador.abrirBascula();
                        }
                        
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

                    if (puntoVentaContext.conectarConBascula)
                    {
                        basculaControlador.cerrarBascula();
                    }
                    
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
                if (puntoVentaContext.conectarConBascula)
                {
                    uiCantidad.EditValue = basculaControlador.ObtenPeso();
                }
                else
                {
                    uiCantidad.EditValue = basculaControlador.ObtenPesoBD();
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
                    ERP.Utils.MessageBoxUtil.ShowError("No hay productos para continuar");
                    return;
                }
               

                if(XtraMessageBox.Show("¿Está seguro(a) de continuar?, no será posible revertir los cambios",
                    "Aviso", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                ProductoSobranteBusiness oProductoSobrante = new ProductoSobranteBusiness();

                string error = oProductoSobrante.Guardar(lstProductosTraspaso, puntoVentaContext.usuarioId, puntoVentaContext.empresaId, puntoVentaContext.sucursalId);


                if (error.Length == 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowOk();
                    this.Close();
                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowError(error);
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

            ERP.Common.Productos.frmProductosMosaico frmo = ERP.Common.Productos.frmProductosMosaico.GetInstance(this.puntoVentaContext, Business.Enumerados.tipoModalProducto.sobranteProducto);
            
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
