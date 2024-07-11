using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Common.Base;
using ERP.Common.Productos;
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

namespace ERP.Common.Inventarios
{
    public partial class frmInventarioRegistro : FormBaseXtraForm
    {
        public bool esParaCambioPrecio { get; set; }
        int err=0;
        cat_productos producto;
        doc_inventario_captura entityRegistroInv;
        public frmInventarioRegistro()
        {
            InitializeComponent();
        }

        private void guardar()
        {
            try
            {
                
                uiAlerta.Text = "GUARDANDO...";
                oContext = new ERPProdEntities();
                doc_inventario_captura entityNew;
                if (entityRegistroInv != null)
                {
                    entityNew = oContext.doc_inventario_captura
                        .Where(w => w.Id == entityRegistroInv.Id).FirstOrDefault();

                    entityNew.Cantidad = uiCantidad.Value;
                    oContext.SaveChanges();
                }
                else {
                    entityNew = new doc_inventario_captura();
                    entityNew.Id = (oContext.doc_inventario_captura.Max(m => (int?)m.Id) ?? 0) + 1;
                    entityNew.ProductoId = producto.ProductoId;
                    entityNew.SucursalId = puntoVentaContext.sucursalId;
                    entityNew.Cantidad = uiCantidad.Value;
                    entityNew.CreadoEl = DateTime.Now;
                    entityNew.CreadoPor = puntoVentaContext.usuarioId;

                    oContext.doc_inventario_captura.Add(entityNew);
                    oContext.SaveChanges();
                }

                LoadGrid();
                Limpiar();
                

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
                    uiCantidad.Select();
                    uiCantidad.SelectAll();

                }
                else
                {
                    uiDescripcion.Select();
                    uiDescripcion.SelectAll();
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
            entityRegistroInv = null;
            uiCodigoBarras.Text = "";            
            uiDescripcion.Text = "";
            uiCantidad.Value = 0;
            uiCodigoBarras.Select();


        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void frmProductoInventarioForm_Load(object sender, EventArgs e)
        {
            uiCodigoBarras.Select();
            LoadGrid();
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

        private void LoadGrid()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiGrid.DataSource = oContext.doc_inventario_captura
                    .Where(w => w.Cerrado == false && w.SucursalId == puntoVentaContext.sucursalId).ToList();

                uiGridView.ExpandAllGroups();
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

        private void uiCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                guardar();
            }
        }

        private void uiRefrescarGrid_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void uiRegistrarProducto_Click(object sender, EventArgs e)
        {
            frmProductoInventarioForm oForm = new frmProductoInventarioForm();

            oForm.puntoVentaContext = this.puntoVentaContext;
            oForm.ShowDialog();
        }

        private void uiCerrarInventario_Click(object sender, EventArgs e)
        {
            try
            {
                oContext = new ERPProdEntities();

                if(XtraMessageBox.Show("¿Está seguro(a) de cerrar el inventario?, no será posible realizar modificaciones",
                    "Aviso",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oContext.p_inventario_cierre(this.puntoVentaContext.sucursalId, this.puntoVentaContext.usuarioId);
                    LoadGrid();
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
    }
}
