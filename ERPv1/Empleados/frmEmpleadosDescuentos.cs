using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Models.Empleados;
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
    public partial class frmEmpleadosDescuentos : ERP.Common.Base.FormBaseXtraForm
    {
        private int? clienteId { get; set; }
        private int productoId { get; set; }
        private decimal precioProducto { get; set; }
        private static frmEmpleadosDescuentos _instance;
        private doc_empleados_productos_descuentos entityUpd;
        public static frmEmpleadosDescuentos GetInstance()
        {
            if (_instance == null) _instance = new frmEmpleadosDescuentos();
            else _instance.BringToFront();
            return _instance;
        }

        public frmEmpleadosDescuentos()
        {
            InitializeComponent();
        }

        private void frmClientesPrecios_Load(object sender, EventArgs e)
        {
            try
            {
                oContext = new ERPProdEntities();
                entityUpd = new doc_empleados_productos_descuentos();
                LoadClientes();
                LoadProductos();
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

        private void LoadClientes()
        {
            try
            {
                //uiCliente.Properties.DataSource = oContext
                //    .rh_empleados
                //    .Where(w => w.Estatus == 1).ToList();
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
                    .Where(w => w.Estatus == true & w.ProductoId > 0 && w.ProdParaVenta == true)
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
                oContext = new ERPProdEntities();
                uiGrid.DataSource = oContext.p_empleados_productos_descuentos_grd(clienteId).ToList();
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
            entityUpd = new doc_empleados_productos_descuentos();
        }

        private void uiCliente_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clienteId = null;
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
                int productoId = Convert.ToInt32(uiProducto.EditValue);
                int id = (entityUpd == null ? 0 : entityUpd.Id);
                if (uiPrecio.Value > 
                    ERP.Business.ProductoBusiness
                    .ObtenerPrecio(productoId, 
                                    ERP.Business.Enumerados.tipoPrecioProducto.PublicoGeneral, 
                                    puntoVentaContext.usuarioId,puntoVentaContext.sucursalId))
                {
                    dxErrorProvider1.SetError(uiPrecio, "El descuento no puede ser mayor al precio del producto");
                    ERP.Utils.MessageBoxUtil.ShowWarning("El descuento no puede ser mayor al precio del producto");
                    return false;
                }

                if (uiPrecio.Value <= 0)
                {
                    dxErrorProvider1.SetError(uiPrecio, "El descuento no puede ser 0");
                    ERP.Utils.MessageBoxUtil.ShowWarning("El descuento no puede ser 0");
                    return false;
                    
                }
                if(uiProducto.EditValue == null)
                {
                    dxErrorProvider1.SetError(uiProducto, "El producto es requerido");
                    ERP.Utils.MessageBoxUtil.ShowWarning("El producto es requerido");
                    return false;
                   

                }

               

                if(
                    oContext.doc_empleados_productos_descuentos
                    .Where(w=> w.ProductoId == productoId && w.Id != id
                    ).Count() > 0 
                )
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Solo es posible agregar un descuento por producto");
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
                    entityUpd = new doc_empleados_productos_descuentos();
                }

                if (entityUpd.Id > 0)
                {
                    id = entityUpd.Id;
                    entityUpd = oContext.doc_empleados_productos_descuentos
                        .Where(w => w.Id == id).FirstOrDefault();

                    entityUpd.ProductoId = Convert.ToInt32(uiProducto.EditValue);
                    entityUpd.MontoDescuento = uiPrecio.Value;                    
                    entityUpd.ModificadoPor = puntoVentaContext.usuarioId;
                    entityUpd.ModificadoEl = DateTime.Now;

                    oContext.SaveChanges();

                    ERP.Utils.MessageBoxUtil.ShowOk();
                    LimpiarCaptura();
                    LoadGrid();
                }
                else
                {
                    oContext = new ERPProdEntities();
                    entityUpd = new doc_empleados_productos_descuentos();

                    
                    entityUpd.ProductoId = Convert.ToInt32(uiProducto.EditValue);
                    entityUpd.MontoDescuento = uiPrecio.Value;
                    entityUpd.EmpleadoId = clienteId;
                    entityUpd.CreadoEl = DateTime.Now;
                    entityUpd.CreadoPor = puntoVentaContext.usuarioId;
                    entityUpd.ModificadoPor = puntoVentaContext.usuarioId;
                    entityUpd.ModificadoEl = DateTime.Now;
                    oContext.doc_empleados_productos_descuentos.Add(entityUpd);
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
                if (uiGridView.FocusedRowHandle >= 0)
                {
                    var entityUpd2 = (p_empleados_productos_descuentos_grd_Result)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    entityUpd = oContext.doc_empleados_productos_descuentos.Where(w => w.Id == entityUpd2.Id).FirstOrDefault();

                    if(entityUpd != null)
                    {
                        uiProducto.EditValue = entityUpd.ProductoId;
                        uiPrecio.EditValue = entityUpd.MontoDescuento;

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
                    var entityUpd2 = (p_empleados_productos_descuentos_grd_Result)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    entityUpd = oContext.doc_empleados_productos_descuentos.FirstOrDefault(f => f.Id == entityUpd2.Id);

                    if (entityUpd != null)
                    {
                        int Id = entityUpd.Id;

                        oContext.doc_empleados_productos_descuentos.Remove(entityUpd);
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

        private void uiPrecio_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                uiPrecioDescuento.EditValue = precioProducto - Convert.ToDecimal(uiPrecio.EditValue);
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

        private void uiProducto_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(uiProducto.EditValue != null)
                {
                    productoId = Convert.ToInt32(uiProducto.EditValue);
                    precioProducto = ERP.Business.ProductoBusiness.ObtenerPrecio(productoId, ERP.Business.Enumerados.tipoPrecioProducto.PublicoGeneral, puntoVentaContext.usuarioId,puntoVentaContext.sucursalId);
                    uiPrecioDescuento.EditValue = precioProducto;
                }
                else
                {
                    precioProducto = 0;
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
    }
}
