using ERP.Common.Base;
using ERP.Models.ProductoSobrante;
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
    public partial class frmPreferenciaSucursal : FormBaseXtraForm
    {
        int err;
        int year;
        int day;
        int month;

        public static frmPreferenciaSucursal GetInstance()
        {
            if (_instance == null) _instance = new frmPreferenciaSucursal();
            return _instance;
        }
        private static frmPreferenciaSucursal _instance;

        public frmPreferenciaSucursal()
        {
            InitializeComponent();
        }

        public void LoadGrid()
        {
            try
            {
                year = uiFecha.DateTime.Year;
                month = uiFecha.DateTime.Month;
                day = uiFecha.DateTime.Day;

                oContext = new ConexionBD.ERPProdEntities();

                uiGrid.DataSource = oContext.doc_productos_sobrantes_registro
                    .Where(
                        w => w.SucursalId == puntoVentaContext.sucursalId &&
                        w.CreadoEl.Value.Year == year &&
                        w.CreadoEl.Value.Month == month &&
                        w.CreadoEl.Value.Day == day
                    )
                    .Select(s=> new ProductoSobranteModel() {
                         cantidadInventarioTeorico = s.CantidadInventario ?? 0M,
                          cantidadSobrante = s.CantidadSobrante ?? 0,
                           nombreSucursal = s.cat_sucursales.NombreSucursal,
                            producto = s.cat_productos.Descripcion,
                             productoId = s.ProductoId ?? 0,
                              sucursalId = s.SucursalId ?? 0,
                              fecha = s.CreadoEl ?? DateTime.MinValue
                    }).OrderBy(o=> o.producto).ToList();
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

        private void uiGrid_Load(object sender, EventArgs e)
        {
            uiFecha.DateTime = DateTime.Now;
            LoadGrid();
        }

        private void uiFecha_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void frmSobrantesConsulta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
    }
}
