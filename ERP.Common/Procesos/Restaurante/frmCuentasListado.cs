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

namespace ERP.Common.Procesos.Restaurante
{
    public partial class frmCuentasListado : XtraForm
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        public frmCuentasListado()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        public void llenarGrid()
        {
            try
            {
                bool soloPendientes = uiSoloPendientes.Checked;
                int sucursalID = puntoVentaContext.sucursalId;
                List<CuentaPendienteViewModel> lst = oContext
                    .doc_pedidos_orden
                    .Where(w => 
                    w.Activo == true &&
                    w.SucursalId == sucursalID && 
                        (
                            (w.VentaId == null &&  (w.Cancelada??false) == false && soloPendientes)
                            || 
                            !soloPendientes
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
                                        s.VentaId > 0 ? "Pagada" : "Pendiente"                                              



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
            llenarGrid();
        }

        private void repBtnVer_Click(object sender, EventArgs e)
        {
            CuentaPendienteViewModel cuenta = (CuentaPendienteViewModel)uiGridView.GetRow(uiGridView.FocusedRowHandle);

         

            frmPuntoVentaRest frmo = frmPuntoVentaRest.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = frmMenuRest.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();


            }
            frmo.marcarVerTodo(true);
            frmPuntoVentaRest.GetInstance().obtenerCuenta(cuenta.cuentaId);

            this.Close();

        }

        private void uiSoloPendientes_CheckedChanged(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void uiActualizar_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }
    }

   
}
