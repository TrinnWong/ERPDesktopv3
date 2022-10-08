using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Models.Mesas;
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
    public partial class frmComandaNueva : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;


        private static frmComandaNueva _instance;
        public static frmComandaNueva GetInstance()
        {
            if (_instance == null) _instance = new frmComandaNueva();
            return _instance;
        }

        public frmComandaNueva()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }


        private void llenarLkpComanda()
        {
            try
            {
                int sucursalId = puntoVentaContext.sucursalId;                

                //uiComanda.Properties.DataSource = oContext.cat_rest_comandas
                //    .Where(w => w.SucursalId == sucursalId
                //    && (
                //        w.doc_pedidos_orden_detalle.Count == 0
                //        ||
                //        (
                //            w.doc_pedidos_orden_detalle.Count > 0
                //        )

                //    )
                //    && w.Disponible
                //    ).OrderBy(o => o.Folio).ToList();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Ocurrió un error al obtener las comandas", "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void llenarLkpMesas()
        {
            try
            {
                oContext = new ERPProdEntities();
                int sucursalId = puntoVentaContext.sucursalId;

                uiMesa.Properties.DataSource = oContext.cat_rest_mesas
                    .Where(w => w.SucursalId == sucursalId && w.Activo)
                    .Select(
                    s=> new MesaComboBoxModel()
                    {
                        MesaId = s.MesaId,
                        Nombre = s.Nombre,
                        Abierta = s.doc_pedidos_orden_mesa
                                .Where(
                                    w=> w.doc_pedidos_orden.Activo 
                                ).Count() > 0 ? true : false
                    })
                     .ToList();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Ocurrió un error al obtener las mesas", "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void llenarLkpMeseros()
        {
            try
            {

                //uiMesero.Properties.DataSource = oContext.rh_empleados
                //     .Where(w => w.Estatus == 1
                //     && w.rh_empleado_puestos.Where(s => s.PuestoId == 4/*Mesero*/).Count() > 0).ToList();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Ocurrió un error al obtener las mesas", "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmComandaNueva_Load(object sender, EventArgs e)
        {
            frmPuntoVentaRest frmo = frmPuntoVentaRest.GetInstance();

            if (frmo.Visible)
            {
                frmo.Close();

            }

            llenarLkpMesas();
            llenarLkpComanda();
            llenarLkpMeseros();
        }

        private void uiContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                PedidoOrdenBusiness oPedido = new PedidoOrdenBusiness();


                #region mesas
                int[] indexmesas = uiMesaView.GetSelectedRows();
                List<int> mesasId = new List<int>();

                foreach (int item in indexmesas)
                {
                    MesaComboBoxModel itemMesa = (MesaComboBoxModel)uiMesaView.GetRow(item);
                    mesasId.Add(itemMesa.MesaId);
                }
                #endregion

                //int comandaId = uiComanda.EditValue != null ?
                //   int.Parse(uiComanda.EditValue.ToString()) : 0;

                int comandaId = 0;

                int pedidoId = 0;

                string error = oPedido.buscarCuenta(mesasId.ToArray(), comandaId, ref pedidoId);

                if(error.Length > 0)
                {
                    XtraMessageBox.Show(error,
                   "ERROR",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
                else
                {
                    AbrirPuntoDeVenta(pedidoId,mesasId.ToArray());
                    this.Close();
                }


            }
            catch (Exception)
            {
                XtraMessageBox.Show("Ocurrió un error en el proceso",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                
            }
        }

        private void AbrirPuntoDeVenta(int pedidoId,int[] mesas)
        {
            frmPuntoVentaRest frmo = frmPuntoVentaRest.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = frmMenuRest.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.cuentaId = pedidoId;
                frmo.mesasIdInit = mesas;
                frmo.Show();
                //if (mdiParenAux == null)
                //{
                //    mdiParenAux = frmo.MdiParent;
                //}

            }
            else
            {
                frmo.Show();
                frmo.nuevaCuenta(pedidoId);
            }


        }

        private void uiMesa_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            int[] selectedR = uiMesaView.GetSelectedRows();

            string text = "";

            foreach (var item in selectedR)
            {
                text = text + ";" + ((MesaComboBoxModel)uiMesaView.GetRow(item)).Nombre;
            }

            e.DisplayText = text;
        }

        private void uiMesa_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            (sender as GridLookUpEdit).LookAndFeel.UpdateStyleSettings();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.puntoVentaContext != null)
            {
                ConexionBD.PedidoOrdenBusiness.ImpresionAutomaticaPedido(
                    this.puntoVentaContext.usuarioId, 
                    this.puntoVentaContext.sucursalId,
                    this.puntoVentaContext.cajaId);

            }
        }

        private void frmComandaNueva_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiActualizar_Click(object sender, EventArgs e)
        {
            
            
            llenarLkpMesas();
            llenarLkpComanda();
            llenarLkpMeseros();
            uiMesa.EditValue = null;
            uiMesa.Text = "";
        }
    }
}
