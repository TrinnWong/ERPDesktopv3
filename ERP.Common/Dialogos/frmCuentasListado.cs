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

namespace ERP.Common.Dialogos
{
    public partial class frmCuentasListado : XtraForm
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        public doc_pedidos_orden pedido;
        int err = 0;
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
                        (w.Notas??"") != "" &&
                        w.SucursalId == sucursalID && 
                        (
                            w.Activo == true &&
                            (w.VentaId == null &&  (w.Cancelada??false) == false && soloPendientes)
                            || 
                            !soloPendientes
                         ) 
                         && (w.doc_pedidos_cargos.Count() == 0 || 
                            
                                (w.doc_pedidos_cargos.Count() > 0 && w.doc_pedidos_cargos.Where(s1=>s1.doc_cargos.Saldo > 0).Count() > 0) 
                            
                            )
                    )
                    .OrderByDescending(o=> o.PedidoId)
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
                        folio = s.Folio,
                        cliente = s.cat_clientes.Nombre
                        



                    }
                    ).ToList();

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
            pedido = new doc_pedidos_orden();
            llenarGrid();
        }

        private void repBtnVer_Click(object sender, EventArgs e)
        {
            try
            {
                CuentaPendienteViewModel cuenta = (CuentaPendienteViewModel)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                pedido = oContext.doc_pedidos_orden
                    .Where(w => w.PedidoId == cuenta.cuentaId).FirstOrDefault();

                this.DialogResult = DialogResult.OK;

                this.Close();
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

        private void uiSoloPendientes_CheckedChanged(object sender, EventArgs e)
        {
            llenarGrid();
        }
    }

   
}
