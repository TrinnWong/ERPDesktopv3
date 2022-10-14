using ConexionBD;
using ERP.Common.Base;
using ERP.Models.Sucursal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPv1.Inventarios
{
    public partial class frmSucursalProductoProduccion : FormBaseXtraForm
    {
        private static frmSucursalProductoProduccion _instance;
        public static frmSucursalProductoProduccion GetInstance()
        {
            if (_instance == null) _instance = new frmSucursalProductoProduccion();
            else _instance.BringToFront();
            return _instance;
        }
        public frmSucursalProductoProduccion()
        {
            InitializeComponent();
        }

        private void uiAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();

                cat_produccion_productos_sucursal entityNew = new cat_produccion_productos_sucursal();
                int productoId = Convert.ToInt32(uiProducto.EditValue == null ? 0 : uiProducto.EditValue);
                int sucursalId = Convert.ToInt32(uiSucursal.EditValue == null ? 0 : uiSucursal.EditValue);


                if (productoId > 0 && sucursalId > 0)
                {

                    entityNew = oContext.cat_produccion_productos_sucursal
                        .Where(w => w.SucursalId == sucursalId &&
                        w.ProductoId == productoId).FirstOrDefault();

                    if (entityNew != null)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("El producto ya existe para la Sucursal Seleccionada");
                    }
                    else
                    {
                        entityNew = new cat_produccion_productos_sucursal();
                        entityNew.ProductoId = productoId;
                        entityNew.SucursalId = sucursalId;
                        entityNew.CreadoEl = DateTime.Now;
                        entityNew.Id = (oContext.cat_produccion_productos_sucursal.Max(m => (int?)m.Id) ?? 0) + 1;
                        oContext.cat_produccion_productos_sucursal.Add(entityNew);
                        oContext.SaveChanges();

                        LoadGrid();
                    }


                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Selecciona una Sucursal y un Producto");
                }


            }
            catch (Exception ex)
            {


                int err = ERP.Business.SisBitacoraBusiness.Insert(
                   this.puntoVentaContext.usuarioId,
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
                oContext = new ConexionBD.ERPProdEntities();

                int sucursalId = Convert.ToInt32(uiSucursal.EditValue == null ? 0 : uiSucursal.EditValue);

                uiGrid.DataSource = oContext.cat_produccion_productos_sucursal
                    .Where(w => w.SucursalId == sucursalId)
                    .Select(s => new SucursalProductoModel()
                    {
                        clave = s.cat_productos.Clave,
                        descripcion = s.cat_productos.Descripcion,
                        productoId = s.ProductoId,
                        sucursalId = s.SucursalId
                    }).OrderBy(o => o.descripcion).ToList();

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(
                    this.puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LoadSucursales()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiSucursal.Properties.DataSource = ERP.Business.SucursalBusiness.ObtenSucursalesPorUsuario(this.puntoVentaContext.empresaId,
                    this.puntoVentaContext.usuarioId);
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(
                   this.puntoVentaContext.usuarioId,
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
                uiProducto.Properties.DataSource = oContext
                    .cat_productos
                    .Where(w => w.Estatus == true && w.ProductoId > 0).ToList();
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(
                   this.puntoVentaContext.usuarioId,
                          "ERP",
                          this.Name,
                          ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmSucursalProductoRecepcion2_Load(object sender, EventArgs e)
        {
            LoadSucursales();
            LoadProductos();
            LoadGrid();
        }

        private void frmSucursalProductoRecepcion2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiProducto_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void uiSucursal_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void repBtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if(uGridView.FocusedRowHandle >= 0)
                {
                    SucursalProductoModel entity = (SucursalProductoModel)uGridView.GetRow(uGridView.FocusedRowHandle);

                    if(entity != null)
                    {
                        cat_produccion_productos_sucursal enityDel = oContext
                            .cat_produccion_productos_sucursal
                            .Where(w => w.ProductoId == entity.productoId && w.SucursalId == entity.sucursalId).FirstOrDefault();

                        oContext.cat_produccion_productos_sucursal.Remove(enityDel);
                        oContext.SaveChanges();

                        LoadGrid();
                    }
                }


            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(
                                  this.puntoVentaContext.usuarioId,
                                         "ERP",
                                         this.Name,
                                         ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
    }
}
