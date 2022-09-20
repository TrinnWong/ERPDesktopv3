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
    public partial class frmSucursalProductoRecepcion2 : FormBaseXtraForm
    {
        private static frmSucursalProductoRecepcion2 _instance;
        public static frmSucursalProductoRecepcion2 GetInstance()
        {
            if (_instance == null) _instance = new frmSucursalProductoRecepcion2();
            else _instance.BringToFront();
            return _instance;
        }
        public frmSucursalProductoRecepcion2()
        {
            InitializeComponent();
        }

        private void uiAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();

                doc_sucursales_productos_recepcion entityNew = new doc_sucursales_productos_recepcion();
                int productoId = Convert.ToInt32(uiProducto.EditValue == null ? 0 : uiProducto.EditValue);
                int sucursalId = Convert.ToInt32(uiSucursal.EditValue == null ? 0 : uiSucursal.EditValue);


                if (productoId > 0 && sucursalId > 0)
                {

                    entityNew = oContext.doc_sucursales_productos_recepcion
                        .Where(w => w.SucursalId == sucursalId &&
                        w.ProductoId == productoId).FirstOrDefault();

                    if (entityNew != null)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("El producto ya existe para la Sucursal Seleccionada");
                    }
                    else
                    {
                        entityNew = new doc_sucursales_productos_recepcion();
                        entityNew.ProductoId = productoId;
                        entityNew.SucursalId = sucursalId;
                        entityNew.CreadoEl = DateTime.Now;

                        oContext.doc_sucursales_productos_recepcion.Add(entityNew);
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

                uiGrid.DataSource = oContext.doc_sucursales_productos_recepcion
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
                uiSucursal.Properties.DataSource = oContext
                    .cat_sucursales
                    .Where(w => w.Estatus == true).ToList();
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
                        doc_sucursales_productos_recepcion enityDel = oContext
                            .doc_sucursales_productos_recepcion
                            .Where(w => w.ProductoId == entity.productoId && w.SucursalId == entity.sucursalId).FirstOrDefault();

                        oContext.doc_sucursales_productos_recepcion.Remove(enityDel);
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
