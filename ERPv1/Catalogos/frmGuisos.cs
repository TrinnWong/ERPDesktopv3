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
    public partial class frmGuisos : XtraForm
    {
        ERPProdEntities oContext;
        private static frmGuisos _instance;
        public static frmGuisos GetInstance()
        {
            if (_instance == null) _instance = new frmGuisos();
            else _instance.BringToFront();
            return _instance;
        }

        public frmGuisos()
        {
            InitializeComponent();
        }

        public  void cargarGridProductos()
        {
            try
            {
                oContext = new ERPProdEntities();
               uiGrid.DataSource=  oContext.cat_productos
                    .Where(w => w.cat_guisos == null && w.Estatus == true && w.ProductoId > 0)
                    .Select(s=> new {
                        ProductoId = s.ProductoId,
                        Clave = s.Clave,
                        Descripcion = s.Descripcion
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBoxUtil.ShowError("Ocurrió un erro al cargar los productos");
               
            }
        }
        public void cargarGridGuisos()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiGridGuisos.DataSource = oContext.cat_guisos    
                    
                     .Select(s => new {
                         ProductoId = s.productoId,
                         Clave = s.cat_productos.Clave,
                         Descripcion = s.cat_productos.Descripcion
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
            cargarGridProductos();
            cargarGridGuisos();
        }

        private void repBtnAdd_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    var id = uiGridView.GetRowCellValue(uiGridView.FocusedRowHandle, "ProductoId");

                    oContext = new ERPProdEntities();
                    cat_guisos entityNew = new cat_guisos();
                    entityNew.productoId = Convert.ToInt32(id);
                    entityNew.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                    oContext.cat_guisos.Add(entityNew);
                    oContext.SaveChanges();

                    cargarGridGuisos();
                    cargarGridProductos();

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
                    int id = Convert.ToInt32(uiGridViewGuisos.GetRowCellValue(uiGridViewGuisos.FocusedRowHandle, "ProductoId"));

                    oContext = new ERPProdEntities();

                    cat_guisos entityDel = oContext.cat_guisos.Where(w => w.productoId == id).FirstOrDefault();

                    oContext.cat_guisos.Remove(entityDel);
                    oContext.SaveChanges();

                    cargarGridGuisos();

                }
            }
            catch (Exception ex)
            {

                MessageBoxUtil.ShowError("Ocurrió un error al eliminar");
            }
        }
    }
}
