using ConexionBD;
using ERP.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Productos
{
    public partial class frmProductoInventarioForm : FormBaseXtraForm
    {
        public string clave { get; set; }
        private bool cerrarAlGuardar { get; set; }
        public bool esParaCambioPrecio { get; set; }
        public decimal precioRetorno { get; set; }
        int err=0;
        cat_productos producto;
        public frmProductoInventarioForm()
        {
            InitializeComponent();
        }

        private void guardar()
        {
            try
            {
                uiAlerta.Text = "GUARDANDO...";
                oContext = new ERPProdEntities();
                ObjectParameter pInsertado = new ObjectParameter("pInsertado", false);
                ObjectParameter pError = new ObjectParameter("pError", "");
                Guid uuid = Guid.NewGuid();
                oContext.p_productos_importacion(puntoVentaContext.empresaId, puntoVentaContext.sucursalId, uiCategoria.Text,
                     uiCategoria.Text.Trim(), uiCodigoBarras.Text.Trim(),
                    uiDescripcion.Text.Trim(), uiDescripcion.Text.Trim(), uiPrecioVenta.Value, 0,
                    (double)uiPrecioCompra.Value, pInsertado, uiIVA.Checked ? 16 : 0, "Pieza", "SIN MARCA",
                    uiCategoria.Text.Trim(), null, null, null, null, false, puntoVentaContext.usuarioId, uuid, false, true,
                    null, null, null, (double)uiPrecioCompra.Value, true,
                    false, true, false, false,
                    "Pieza", "Pieza", 0, 0, 0, uiCodigoBarras.Text.Trim(), pError);

                producto = oContext.cat_productos
                    .Where(w => w.CodigoBarras == uiCodigoBarras.Text.Trim()).FirstOrDefault();

                producto.Descripcion = uiDescripcion.Text;
                producto.DescripcionCorta = uiDescripcion.Text;
                oContext.SaveChanges();

                //Cambio de Precio
                cat_productos_precios productoPrecio = oContext.cat_productos_precios
                    .Where(w => w.IdProducto == producto.ProductoId && w.IdPrecio == 1).FirstOrDefault();

                if (productoPrecio != null)
                {
                    productoPrecio.Precio = uiPrecioVenta.Value;
                    oContext.SaveChanges();
                }


                if (pError.Value.ToString().Length > 0)
                {
                    uiAlerta.Text = "";
                    ERP.Utils.MessageBoxUtil.ShowError("Ocurrió un error al intentar guardar el registro");
                }
                else
                {
                    uiAlerta.Text = "";
                    if (!cerrarAlGuardar)
                    {
                        ERP.Utils.MessageBoxUtil.ShowOk();
                    }
                    
                    this.precioRetorno = uiPrecioVenta.Value;
                    LoadCategorias();
                    oContext.SaveChanges();
                    Limpiar();

                    if (cerrarAlGuardar)
                    {
                        
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
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
        private void uiGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void BuscarProducto()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();

                producto = oContext.cat_productos.Where(w => w.CodigoBarras == uiCodigoBarras.Text.Trim()).FirstOrDefault();

                if(producto != null)
                {
                    uiDescripcion.Text = producto.Descripcion;
                    uiCategoriaList.EditValue = producto.ClaveLinea;
                    uiCategoria.Text = producto.cat_lineas.Descripcion;
                    uiIVA.Checked = producto.cat_productos_impuestos.Count() > 0 ? true : false;
                    uiPrecioVenta.EditValue = producto.cat_productos_precios.Count() > 0 ? producto.cat_productos_precios
                            .Where(w => w.IdPrecio == 1).FirstOrDefault().Precio : 0;
                    uiPrecioCompra.EditValue = producto.cat_productos_existencias
                        .Where(w => w.SucursalId == 1).Count() > 0 ? producto.cat_productos_existencias
                        .Where(w => w.SucursalId == 1).FirstOrDefault().CostoUltimaCompra : 0;

                    if (esParaCambioPrecio)
                    {
                        uiPrecioVenta.Select();
                        uiPrecioVenta.SelectAll();

                    }

                    

                }
                else
                {
                    if(uiDescripcion.Text.Trim().Length == 0)
                    {
                        uiCodigoBarras.Select();
                        uiCodigoBarras.SelectAll();
                    }
                    else
                    {
                        uiDescripcion.Select();
                        uiDescripcion.SelectAll();

                    }
                    
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

        private void Limpiar()
        {
            uiCodigoBarras.Text = "";
            uiCategoria.Text = "";            
            uiIVA.Checked = true;
            uiPrecioCompra.EditValue = 0;
            uiPrecioVenta.EditValue = 0;
            uiDescripcion.Text = "";
            uiCodigoBarras.Select();
            uiCodigoBarras.SelectAll();

            
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void frmProductoInventarioForm_Load(object sender, EventArgs e)
        {
            uiCodigoBarras.Select();
            LoadCategorias();

            if((clave==null ? "" : clave).Length > 0)
            {
                uiCodigoBarras.Text = clave;
                cerrarAlGuardar = true;
                BuscarProducto();
            }
        }

        private void uiCodigoBarras_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                BuscarProducto();
            }
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCategorias()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiCategoriaList.Properties.DataSource = oContext.cat_lineas.ToList();
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

        private void uiCategoriaList_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                cat_lineas DATA =  (cat_lineas)uiCategoriaList.GetSelectedDataRow();

                uiCategoria.Text = DATA.Descripcion;
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

        private void uiDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                guardar();
            }
        }

        private void uiPrecioVenta_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guardar();
            }
        }

        private void uiPrecioCompra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guardar();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            frmProductosBusqueda frmBuscar = new frmProductosBusqueda();
            frmBuscar.soloParaVenta = true;
            frmBuscar.puntoVentaContext = this.puntoVentaContext;
            frmBuscar.cargarEnInicio = false;
            var result = frmBuscar.ShowDialog();

            if (result == DialogResult.OK)
            {
                if(frmBuscar.response != null)
                {
                    uiCodigoBarras.EditValue = frmBuscar.response.CodigoBarras;
                    BuscarProducto();
                }


            }
        }
    }
}
