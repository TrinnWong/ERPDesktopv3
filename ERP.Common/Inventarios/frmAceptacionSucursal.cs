using ERP.Common.Base;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Inventarios
{
    public partial class frmAceptacionSucursal : FormBaseXtraForm
    {
        ERP.Business.InventarioBusiness oInventario;
        int err = 0;
        string error = "";
        public int idForm { get; set; }
        private static frmAceptacionSucursal _instance;
        public static frmAceptacionSucursal GetInstance()
        {
            if (_instance == null) _instance = new frmAceptacionSucursal();
            else _instance.BringToFront();
            return _instance;
        }

        public frmAceptacionSucursal()
        {
            InitializeComponent();
        }

        private void frmAceptacionSucursal_Load(object sender, EventArgs e)
        {
            LoadTraspasos();
        }

        private void LoadTraspasos()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();

                uiTraspasos.Properties.DataSource = oContext.doc_inv_movimiento
                    .Where(w => w.SucursalDestinoId == puntoVentaContext.sucursalId &&
                    w.TipoMovimientoId == (int)ERP.Business.Enumerados.tipoMovimientoInventario.SalidaPorTraspaso &&
                    w.doc_aceptaciones_sucursal.Count() == 0).ToList();
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

        private void LoadGrid()
        {
            try
            {
                int movimientoId = Convert.ToInt32(uiTraspasos.EditValue);

                uiGrid.DataSource = oContext.p_doc_aceptaciones_sucursal_grd(movimientoId)
                    .Select(
                        S=> new ERP.Models.Inventario.AceptacionSucursalGrdModel()
                        {
                             cantidadMovimiento = S.CantidadMovimiento ?? 0,
                              cantidadReal = S.CantidadReal ??0,
                               id = S.Id ??0,
                                movimientoDetalleAjusteId = S.MovimientoDetalleAjusteId ?? 0,
                                 movimientoDetalleId = S.MovimientoDetalleId,
                                  movimientoId = S.MovimientoId,
                                   producto = S.Producto,
                                    productoId = S.ProductoId
                        }
                    ).ToList();
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
            try
            {
                if(((List<ERP.Models.Inventario.AceptacionSucursalGrdModel>)uiGrid.DataSource).Count() > 0)
                {
                    oInventario = new Business.InventarioBusiness();

                    ResultAPIModel result = oInventario.GuardarAceptacionSucursal(
                        (List<ERP.Models.Inventario.AceptacionSucursalGrdModel>)uiGrid.DataSource,
                        puntoVentaContext.usuarioId, puntoVentaContext.sucursalId);

                    if (result.ok)
                    {
                        LoadTraspasos();
                        uiTraspasos.EditValue = null;                        
                        ERP.Utils.MessageBoxUtil.ShowOk();
                    }
                    else
                    {
                        ERP.Utils.MessageBoxUtil.ShowError(result.error);
                    }
                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("No hay elementos para guardar");
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

        private void uiTraspasos_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void frmAceptacionSucursal_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
