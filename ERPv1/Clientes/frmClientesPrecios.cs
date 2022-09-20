using ConexionBD;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPv1.Clientes
{
    public partial class frmClientesPrecios : ERP.Common.Base.FormBaseXtraForm
    {
        private int clienteId { get; set; }
        private int productoId { get; set; }
        private static frmClientesPrecios _instance;
        private doc_clientes_productos_precios entityUpd;
        public static frmClientesPrecios GetInstance()
        {
            if (_instance == null) _instance = new frmClientesPrecios();
            else _instance.BringToFront();
            return _instance;
        }

        public frmClientesPrecios()
        {
            InitializeComponent();
        }

        private void frmClientesPrecios_Load(object sender, EventArgs e)
        {
            try
            {
                oContext = new ERPProdEntities();
                entityUpd = new doc_clientes_productos_precios();
                LoadClientes();
                LoadProductos();
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

        private void LoadClientes()
        {
            try
            {
                uiCliente.Properties.DataSource = oContext
                    .cat_clientes
                    .Where(w => w.Activo == true).ToList();
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

        private void LoadProductos()
        {
            try
            {
                uiProducto.Properties
                    .DataSource = oContext.cat_productos
                    .Where(w => w.Estatus == true & w.ProductoId > 0)
                    .ToList();
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
        private void LoadGrid()
        {
            try
            {
                uiGrid.DataSource = oContext.doc_clientes_productos_precios
                    .Where(W => W.ClienteId == clienteId).ToList();
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

        private void LimpiarCaptura()
        {
            uiProducto.EditValue = null;
            uiPrecio.Value = 0;
            entityUpd = new doc_clientes_productos_precios();
        }

        private void uiCliente_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clienteId = Convert.ToInt32(uiCliente.EditValue);
                LoadGrid();
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

        private bool ValidarGuardar()
        {
            try
            {
                
                if(clienteId == 0)
                {
                    
                    dxErrorProvider1.SetError(uiCliente, "El cliente es requerido", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                    ERP.Utils.MessageBoxUtil.ShowWarning("El cliente es requerido");
                    return false;

                }
                if (uiPrecio.Value <= 0)
                {
                    dxErrorProvider1.SetError(uiPrecio, "El precio no puede ser 0");
                    ERP.Utils.MessageBoxUtil.ShowWarning("El precio no puede ser 0");
                    return false;
                    
                }
                if(uiProducto.EditValue == null)
                {
                    dxErrorProvider1.SetError(uiProducto, "El producto es requerido");
                    ERP.Utils.MessageBoxUtil.ShowWarning("El producto es requerido");
                    return false;
                   

                }

                int productoId = Convert.ToInt32( uiProducto.EditValue);

                if(oContext.doc_clientes_productos_precios
                    .Where(w=> w.ClienteId == clienteId && w.ProductoId == productoId
                    &&w.ClienteProductoPrecioId != entityUpd.ClienteProductoPrecioId
                    ).Count() > 0 
                )
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Solo es posible agregar un precio por producto");
                    return false;
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

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!ValidarGuardar())
                    return;
                int id = 0;

                if(entityUpd == null)
                {
                    entityUpd = new doc_clientes_productos_precios();
                }

                if (entityUpd.ClienteProductoPrecioId > 0)
                {
                    id = entityUpd.ClienteProductoPrecioId;
                    entityUpd = oContext.doc_clientes_productos_precios
                        .Where(w => w.ClienteProductoPrecioId == id).FirstOrDefault();

                    entityUpd.ProductoId = Convert.ToInt32(uiProducto.EditValue);
                    entityUpd.Precio = uiPrecio.Value;
                    entityUpd.CreadoEl = DateTime.Now;

                    oContext.SaveChanges();

                    ERP.Utils.MessageBoxUtil.ShowOk();
                    LimpiarCaptura();
                    LoadGrid();
                }
                else
                {
                    entityUpd = new doc_clientes_productos_precios();

                    entityUpd.ClienteProductoPrecioId = (oContext
                        .doc_clientes_productos_precios.Max(m => (int?)m.ClienteProductoPrecioId) ?? 0) + 1;
                    entityUpd.ProductoId = Convert.ToInt32(uiProducto.EditValue);
                    entityUpd.Precio = uiPrecio.Value;
                    entityUpd.ClienteId = clienteId;
                    entityUpd.CreadoEl = DateTime.Now;

                    oContext.doc_clientes_productos_precios.Add(entityUpd);
                    oContext.SaveChanges();

                    ERP.Utils.MessageBoxUtil.ShowOk();
                    LimpiarCaptura();
                    LoadGrid();

                }
                dxErrorProvider1.ClearErrors();
                
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
            LimpiarCaptura();
        }

        private void repBtnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                LimpiarCaptura();
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    entityUpd = (doc_clientes_productos_precios)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    if(entityUpd != null)
                    {
                        uiProducto.EditValue = entityUpd.ProductoId;
                        uiPrecio.EditValue = entityUpd.Precio;

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

        private void repBtnDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                LimpiarCaptura();

                if (XtraMessageBox.Show("¿Estás Seguro(a) de continuar?", "Aviso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                if (uiGridView.FocusedRowHandle >= 0)
                {
                    entityUpd = (doc_clientes_productos_precios)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    if (entityUpd != null)
                    {
                        int Id = entityUpd.ClienteProductoPrecioId;

                        oContext.doc_clientes_productos_precios.Remove(entityUpd);
                        oContext.SaveChanges();

                        ERP.Utils.MessageBoxUtil.ShowOk();
                        LoadGrid();

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

        private void frmClientesPrecios_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
    }
}
