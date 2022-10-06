using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Sucursales
{
    public partial class frmSucursalesProductos : FormBaseXtraForm
    {
        int err = 0;
        int sucursalId = 0;
        int productoId = 0;
        private static frmSucursalesProductos _instance;
        public static frmSucursalesProductos GetInstance()
        {
            if (_instance == null) _instance = new frmSucursalesProductos();
            else _instance.BringToFront();
            return _instance;
        }
        public frmSucursalesProductos()
        {
            InitializeComponent();
            oContext = new ConexionBD.ERPProdEntities();
        }

        private void LlenarSucursales()
        {
            try
            {
                uiSucursal.Properties.DataSource = ERP.Business.SucursalBusiness.ObtenSucursalesPorUsuario(this.puntoVentaContext.empresaId,this.puntoVentaContext.usuarioId);

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

        private void LlenarProductos()
        {
            try
            {
                uiProductos.Properties.DataSource = oContext.cat_productos
                    .Where(w=> w.ProductoId >0)
                    .ToList();
                    
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

        private void LlenarGrid()
        {
            try
            {
                sucursalId = Convert.ToInt32(uiSucursal.EditValue);

                uiGrid.DataSource = oContext.cat_sucursales_productos
                    .Where(w => w.SucursalId == sucursalId).ToList();
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
        private void frmSucursalesProductos_Load(object sender, EventArgs e)
        {
            LlenarSucursales();
            LlenarProductos();
        }

        private void uiSucursal_EditValueChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void Agregar()
        {
            try
            {
                sucursalId = Convert.ToInt32( uiSucursal.EditValue);
                
                var productos = uiProductos.Properties.View.GetSelectedRows();
                List<cat_sucursales_productos> lstGrid = (List<cat_sucursales_productos>)uiGrid.DataSource;

                if(sucursalId  > 0 && productos.Count() > 0)
                {
                    foreach (int itemProducto in productos)
                    {
                        productoId = ((cat_productos)uiProductos.Properties.View.GetRow(itemProducto)).ProductoId;
                        if (lstGrid.Where(w => w.SucursalId == sucursalId && w.ProductoId == productoId).Count() == 0)
                        {
                            cat_sucursales_productos entitySucursalProducto = new cat_sucursales_productos();
                            entitySucursalProducto.ProductoId = productoId;
                            entitySucursalProducto.SucursalId = sucursalId;
                            entitySucursalProducto.CreadoEl = DateTime.Now;
                            oContext.cat_sucursales_productos.Add(entitySucursalProducto);
                            oContext.SaveChanges();
                        }
                    }

                    uiProductos.Properties.View.ClearSelection();
                    LlenarGrid();
                    ERP.Utils.MessageBoxUtil.ShowOk();
                  
                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("La sucursal y prpoducto(s) son requeridos");
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

        private void uiAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void uiProductos_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void repDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(XtraMessageBox.Show("¿Está seguro(a) de eliminar el registro?","Aviso", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var row = (cat_sucursales_productos)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    cat_sucursales_productos entityRemove = oContext.cat_sucursales_productos
                        .Where(w => w.ProductoId == row.ProductoId && w.SucursalId == row.SucursalId).FirstOrDefault();

                    oContext.cat_sucursales_productos.Remove(entityRemove);
                    oContext.SaveChanges();
                    LlenarGrid();
                 

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
    }
}
