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

namespace ERPv1.Productos
{
    public partial class frmProductoListEdit : FormBaseXtraForm
    {
        int err = 0;
        private static frmProductoListEdit _instance;
        public static frmProductoListEdit GetInstance()
        {
            if (_instance == null) _instance = new frmProductoListEdit();
            else _instance.BringToFront();
            return _instance;
        }
        public frmProductoListEdit()
        {
            InitializeComponent();
        }

        private void LlenarGrid()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();
                uiGrid.DataSource = oContext.cat_productos.Where(W=> W.ProdParaVenta == true)
                    .OrderBy(O=> O.Orden).ToList();
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

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void frmProductoListEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void frmProductoListEdit_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }
        private void Guardar()
        {
            try
            {
                if(XtraMessageBox.Show("¿Está seguro(a) de continuar?","Aviso",MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (cat_productos itemProd in (List<cat_productos>)uiGrid.DataSource)
                    {
                        cat_productos itemUpd = oContext.cat_productos
                            .Where(w => w.ProductoId == itemProd.ProductoId)
                            .FirstOrDefault();

                        itemUpd.Orden = itemProd.Orden;
                        oContext.SaveChanges();
                    }

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

        private void uiSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
