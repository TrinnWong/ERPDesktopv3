using ConexionBD;
using ERP.Business.DataMemory;
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

namespace ERP.Common.Productos
{
    public partial class frmProductosBusqueda : FormBaseXtraForm
    {
        public bool soloProductosSucursal { get; set; }
        public int sucursalId { get; set; }
        public bool soloParaVenta { get; set; }
        public bool? cargarEnInicio { get; set; }
        public bool cargado { get; set; }
        public cat_productos response;
        public frmProductosBusqueda()
        {
            cargado = false;
            InitializeComponent();
        }

        public void LoadGrid()
        {
            try
            {
                int sucursalFiltro = sucursalId == 0 ? puntoVentaContext.sucursalId : sucursalId;

                string texto = uiBuscarTexto.Text.ToUpper().Trim();
                if (!(cargarEnInicio==null ? false: (bool)cargarEnInicio) && !cargado)
                    return;

                var lstProds = DataBucket.GetProductosMemory(false)
                    .Where(w =>
                    (w.Descripcion.Contains(texto) || w.CodigoBarras == texto || w.Clave == texto) &&
                    w.ProductoId > 0 && w.Estatus == true &&
                (w.ProdParaVenta == soloParaVenta || !soloParaVenta))
                    .OrderBy(o => o.Descripcion);

                if (soloProductosSucursal)
                {
                    int[] idsProdSucursal = oContext.cat_sucursales_productos.Where(w => w.SucursalId == sucursalFiltro)
                        .Select(s => s.ProductoId).ToArray();

                    uiGrid.DataSource = lstProds.Where(w => idsProdSucursal.Contains(w.ProductoId));
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

        private void frmProductosBusqueda_Load(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();

            if(oContext.sis_preferencias_empresa.Where(w=> w.sis_preferencias.Preferencia == "CargaBuscadorProductosAlAbrir").Count() > 0)
            {
                cargarEnInicio = true;
            }
            LoadGrid();
            uiGridView.ShowFindPanel();
            cargado = true;
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Seleccion()
        {
            try
            {
                if (uiGridView.FocusedRowHandle >= 0)
                {
                    response = (cat_productos)uiGridView.GetRow(uiGridView.FocusedRowHandle);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Selecciona un producto del listado");
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
        private void uiAceptar_Click(object sender, EventArgs e)
        {
            Seleccion();
        }

        private void repBtnAdd_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Seleccion();
        }

        private void uiBuscarTexto_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                LoadGrid();
            }
            
        }
    }
}
