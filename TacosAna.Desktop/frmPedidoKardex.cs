using ConexionBD;
using DevExpress.XtraEditors;
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
    public partial class frmPedidoKardex : XtraForm
    {

        public int pedidoId { get; set; }
        private doc_pedidos_orden pedido;
        private ERPProdEntities context;
        public frmPedidoKardex()
        {
            InitializeComponent();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void memoEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmPedidoKardex_Load(object sender, EventArgs e)
        {
            llenarForma();
        }

        private void llenarForma()
        {
            try
            {
                context = new ERPProdEntities();
                pedido = context.doc_pedidos_orden
                    .Where(w => w.PedidoId == pedidoId).FirstOrDefault();

                if(pedido != null)
                {
                    uiPedido.Text = pedido.PedidoId.ToString();
                    uiFechaReg.DateTime = pedido.CreadoEl;
                    uiClienteClave.Text = pedido.ClienteId.ToString() + pedido.cat_clientes.Nombre;
                    uiFechaProg.DateTime = pedido.doc_pedidos_orden_programacion.FirstOrDefault().FechaProgramada;
                    uiHoraProg.EditValue = pedido.doc_pedidos_orden_programacion.FirstOrDefault().HoraProgramada;
                    uiNotas.Text = pedido.Notas;
                    uiPagos.DataSource = pedido.doc_cargos.doc_pagos.ToList().OrderByDescending(o => o.FechaPago);
                    uiSaldo.Value = pedido.doc_cargos.Saldo??0;
                }
                else
                {
                    XtraMessageBox.Show("No fue posible obtener la información del pedido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error inesperado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiClienteClave_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void uiHoraProg_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void uiFechaProg_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void uiPedido_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void uiPagos_Click(object sender, EventArgs e)
        {

        }
    }
}
