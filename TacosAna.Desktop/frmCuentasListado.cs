using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Models.Cuentas;
using PuntoVenta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TacosAna.Desktop
{
    public partial class frmCuentasListado : XtraForm
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        public short tipo;// 1. VENTA POR TELEFONO 2 PEDIDO
        public frmCuentasListado()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        public void llenarGrid()
        {
            try
            {
                bool soloPendientes = true;
                int sucursalID = puntoVentaContext.sucursalId;
                List<CuentaPendienteViewModel> lst = oContext
                    .doc_pedidos_orden
                    .Where(
                        w => w.SucursalId == sucursalID &&
                        (
                            (w.VentaId == null && (w.Cancelada ?? false) == false && soloPendientes)
                            ||
                            !soloPendientes
                         )
                         &&(
                            (tipo==1 && w.CargoId == null )
                            ||
                            tipo == 2 && w.CargoId > 0
                         )
                    )
                    .Select(
                    s => new CuentaPendienteViewModel()
                    {
                        cuentaId = s.PedidoId,
                        sucursalId = s.SucursalId,
                        fechaApertura = s.FechaApertura,
                        importe = s.Total,
                        mesas = s.doc_pedidos_orden_mesa.FirstOrDefault().cat_rest_mesas.Nombre,
                        status = s.Cancelada == true ? "Cancelada" :
                                        s.VentaId > 0 ? "Pagada" : "Pendiente",
                        notas = s.Notas,
                        fechaProgramada = s.doc_pedidos_orden_programacion.Count > 0  ? 
                                                        (DateTime?)s.doc_pedidos_orden_programacion.FirstOrDefault().FechaProgramada
                                                        : null,
                        horaProgramada = s.doc_pedidos_orden_programacion.Count > 0 ?
                                                        (TimeSpan?)s.doc_pedidos_orden_programacion.FirstOrDefault().HoraProgramada
                                                        : null,
                        saldo = s.doc_cargos != null ? s.doc_cargos.Saldo  : 0,
                        tipo = s.cat_tipos_pedido.Nombre,
                        telefono = s.cat_clientes.Telefono,
                        folio = s.Folio

                    }
                    ).OrderByDescending(o=> o.fechaApertura).ToList();

                uiGrid.DataSource = lst;
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Ocurrió un error al intentr obtener las cuentas pendientes",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                
            }
        }

        private void frmCuentasListado_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            {
                gcSaldo.Visible = false;
            }
            else
            {
                gcSaldo.Visible = true;
            }
            llenarGrid();
        }

        private void repBtnVer_Click(object sender, EventArgs e)
        {
            CuentaPendienteViewModel cuenta = (CuentaPendienteViewModel)uiGridView.GetRow(uiGridView.FocusedRowHandle);

            frmPuntoVenta frmo = frmPuntoVenta.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = frmMenuRest.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();


            }

            frmPuntoVenta.GetInstance().obtenerCuenta(cuenta.cuentaId);
            this.Close();


        }

        private void uiSoloPendientes_CheckedChanged(object sender, EventArgs e)
        {
            llenarGrid();
        }
    }

   
}
