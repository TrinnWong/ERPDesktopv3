using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Common.Base;
using ERP.Common.Forms;
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

namespace ERP.Common.Productos
{
    public partial class frmAjustarInventario : FormBaseXtraForm
    {
        public bool deshabilitarSucursal = false;
        int err = 0;
        public static frmAjustarInventario GetInstance()
        {
            if (_instance == null) _instance = new frmAjustarInventario();
            return _instance;
        }
        private static frmAjustarInventario _instance;

        public frmAjustarInventario()
        {
            InitializeComponent();
        }

        private void LoadGrid()
        {
            try
            {
                int sucursalId = Convert.ToInt32(uiSucursal.EditValue);
                if (oContext.cat_sucursales_productos
                    .Where(w=> w.SucursalId == sucursalId).Count() > 0)
                {
                    //uiGrid.DataSource = oContext.cat_productos_existencias
                    //.Where(w => w.SucursalId == sucursalId
                    //&&
                    //w.cat_productos.cat_sucursales_productos
                    //.Where(s1 => s1.SucursalId == sucursalId).Count() > 0
                    //).Select(s=> new AjusteInventarioGridModel()
                    //{
                    //    Producto = s.cat_productos.Descripcion,
                    //    ClaveProducto = s.cat_productos.Clave,
                    //    ProductoId = s.ProductoId,
                    //    CantidadActual = s.ExistenciaTeorica ?? 0
                    //}
                    //).ToList();

                    uiGrid.DataSource = oContext.cat_productos
                    .Where(w=>
                         w.cat_sucursales_productos
                        .Where(s1 => s1.SucursalId == sucursalId).Count() > 0
                        
                    )
                    .Select(s => new AjusteInventarioGridModel()
                    {
                        Producto = s.Descripcion,
                        ClaveProducto = s.Clave,
                        ProductoId = s.ProductoId,
                        CantidadActual =
                                s.cat_productos_existencias
                                .Where(
                                    s1 => s1.SucursalId == sucursalId &&
                                    s1.ProductoId == s.ProductoId
                                    ).Count() > 0 ?
                                (s.cat_productos_existencias
                                .Where(
                                    s1=> s1.SucursalId == sucursalId && 
                                    s1.ProductoId == s.ProductoId
                                    ).FirstOrDefault().ExistenciaTeorica ?? 0) : 0
                    }
                    ).ToList();

                }
                else
                {
                    uiGrid.DataSource = oContext.cat_productos
                   .Where(w =>
                        w.Inventariable == true &&
                        (w.Estatus??false) == true
                   )
                   .Select(s => new AjusteInventarioGridModel()
                   {
                       Producto = s.Descripcion,
                       ClaveProducto = s.Clave,
                       ProductoId = s.ProductoId,
                       CantidadActual =
                               s.cat_productos_existencias
                               .Where(
                                   s1 => s1.SucursalId == sucursalId &&
                                   s1.ProductoId == s.ProductoId
                                   ).Count() > 0 ?
                               (s.cat_productos_existencias
                               .Where(
                                   s1 => s1.SucursalId == sucursalId &&
                                   s1.ProductoId == s.ProductoId
                                   ).FirstOrDefault().ExistenciaTeorica ?? 0) : 0
                   }
                   ).ToList();
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

        private void frmMaximosMinimosUpd_Load(object sender, EventArgs e)
        {
            oContext = new ConexionBD.ERPProdEntities();
            oFormLoading = new LoadingForm("Procesando...");
            loadSucursales();
            if(deshabilitarSucursal)
            {
                uiSucursal.EditValue = this.puntoVentaContext.sucursalId;
                uiSucursal.Enabled = false;
            }
            LoadGrid();
        }

        private void uiSucursal_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            oFormLoading.Show();
            guardar();
            oFormLoading.Hide();
        }

        private void guardar()
        {
            try
            {
                int sucursalId = Convert.ToInt32(uiSucursal.EditValue);
                doc_inventario_captura entity = new doc_inventario_captura();
                foreach (AjusteInventarioGridModel item in (List<AjusteInventarioGridModel>)uiGrid.DataSource)
                {
                    if(oContext.doc_inventario_captura
                        .Where(w=> w.SucursalId == sucursalId
                        && w.ProductoId == item.ProductoId && w.Cerrado == false).Count() > 0)
                    {
                        entity = oContext.doc_inventario_captura
                            .Where(w => w.SucursalId == sucursalId
                        && w.ProductoId == item.ProductoId && w.Cerrado == false).FirstOrDefault();

                        entity.Cantidad = item.CantidadAjuste;

                        oContext.SaveChanges();
                    }
                    else
                    {
                        entity = new doc_inventario_captura();

                        entity.Id = (oContext.doc_inventario_captura.Max(m => (int?)m.Id) ?? 0) + 1;
                        entity.Cantidad = item.CantidadAjuste;
                        entity.Cerrado = false;
                        entity.CreadoEl = DateTime.Now;
                        entity.CreadoPor = puntoVentaContext.usuarioId;
                        entity.ProductoId = item.ProductoId;
                        entity.SucursalId = Convert.ToInt32(uiSucursal.EditValue);

                        oContext.doc_inventario_captura.Add(entity);

                        oContext.SaveChanges();
                    }
                }

                LoadGrid();
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

        private void loadSucursales()
        {
            try
            {
                uiSucursal.Properties.DataSource =
                    ERP.Business.SucursalBusiness.ObtenSucursalesPorUsuario(this.puntoVentaContext.empresaId,
                    this.puntoVentaContext.usuarioId);
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

        private void frmMaximosMinimosUpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if(XtraMessageBox.Show("¿Está seguro(a) de continuar?.Se actualizará el inventario de los productos del listado inculyendo los productos que tengan 0 en [Cantidad Ajuste]",
                "Aviso",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oFormLoading.Show();
                guardar();
                oContext.p_inventario_cierre(this.puntoVentaContext.sucursalId, this.puntoVentaContext.usuarioId);
                LoadGrid();
                oFormLoading.Hide();
            }
           
        }
    }
}
