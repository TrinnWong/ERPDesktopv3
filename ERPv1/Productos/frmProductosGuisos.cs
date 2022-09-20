using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPv1.Catalogos
{
    public partial class frmProductosGuisos : XtraForm
    {
        
        ERPProdEntities oContext;
        private static frmProductosGuisos _instance;
        public static frmProductosGuisos GetInstance()
        {
            if (_instance == null) _instance = new frmProductosGuisos();
            else _instance.BringToFront();
            return _instance;
        }

        public frmProductosGuisos()
        {
            InitializeComponent();
        }

        public  void cargarGrid1()
        {
            try
            {
                int productoId = uiProducto.EditValue == null ? 0 : Convert.ToInt32(uiProducto.EditValue);
                oContext = new ERPProdEntities();
               uiGrid.DataSource=  oContext.cat_guisos
                    .Where(
                        w=> w.cat_productos_guisos.Where(w2=> w2.ProductoId == productoId).Count() == 0 &&
                        w.cat_productos.Estatus == true &&
                        w.cat_productos.ProductoId > 0 &&
                        productoId > 0
                    )
                    .Select(s=> new {
                        ProductoId = s.productoId,
                        Clave = s.cat_productos.Clave,
                        Descripcion = s.cat_productos.Descripcion
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBoxUtil.ShowError("Ocurrió un erro al cargar los productos");
               
            }
        }
        public void cargarGrid2()
        {
            try
            {
                int productoId = uiProducto.EditValue == null ? 0 : Convert.ToInt32(uiProducto.EditValue);
                oContext = new ERPProdEntities();
                uiGridGuisos.DataSource = oContext.cat_productos_guisos
                    .Where(w=> w.ProductoId == productoId)
                     .Select(s => new {
                         ProductoId = s.ProductoGuisoId,
                         Clave = s.cat_guisos.cat_productos.Clave,
                         Descripcion = s.cat_guisos.cat_productos.Descripcion
                     })                     
                     .OrderBy(o=> o.Descripcion)
                     .ToList();
            }
            catch (Exception ex)
            {
                MessageBoxUtil.ShowError("Ocurrió un erro al cargar los productos");

            }
        }

        private void frmGuisos_Load(object sender, EventArgs e)
        {
            llenarComboProductos();
            cargarGrid1();
            cargarGrid2();
        }

        private void repBtnAdd_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    int productoId = uiProducto.EditValue == null ? 0 : Convert.ToInt32(uiProducto.EditValue);
                    var id = uiGridView.GetRowCellValue(uiGridView.FocusedRowHandle, "ProductoId");

                    oContext = new ERPProdEntities();
                    cat_productos_guisos entityNew = new cat_productos_guisos();
                    entityNew.ProductoGuisoId = Convert.ToInt32(id);
                    entityNew.ProductoId = productoId;
                    entityNew.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                    oContext.cat_productos_guisos.Add(entityNew);
                    oContext.SaveChanges();

                    cargarGrid1();
                    cargarGrid2();

                }
               

                
            }
            catch (Exception ex)
            {

                MessageBoxUtil.ShowError("Ocurrió un error inesperado");
            }
        }

        private void frmGuisos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void repBtnDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(uiGridViewGuisos.FocusedRowHandle < 0)
                {
                    return;
                }
               if( XtraMessageBox.Show("¿Estás seguro(a) de continuar?", "AVISO",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    int productoId = uiProducto.EditValue == null ? 0 : Convert.ToInt32(uiProducto.EditValue);
                    int id = Convert.ToInt32(uiGridViewGuisos.GetRowCellValue(uiGridViewGuisos.FocusedRowHandle, "ProductoId"));

                    oContext = new ERPProdEntities();

                    cat_productos_guisos entityDel = oContext.cat_productos_guisos
                        .Where(w => w.ProductoId == productoId && w.ProductoGuisoId == id).FirstOrDefault();

                    oContext.cat_productos_guisos.Remove(entityDel);
                    oContext.SaveChanges();

                    cargarGrid1();
                    cargarGrid2();

                }
            }
            catch (Exception ex)
            {

                MessageBoxUtil.ShowError("Ocurrió un error al eliminar");
            }
        }

        #region functiones
        private void llenarComboProductos()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiProducto.Properties.DataSource =
                    oContext.cat_productos
                    .Where(w => w.Estatus == true &&
                    w.ProductoId > 0).ToList();
            }
            catch (Exception ex)
            {

                ERP.Utils.MessageBoxUtil.ShowError("Ocurrió un error al cargar los productos");
            }
        }
        #endregion
        private void uiProducto_EditValueChanged(object sender, EventArgs e)
        {
            cargarGrid1();
            cargarGrid2();

        }
    }
}
