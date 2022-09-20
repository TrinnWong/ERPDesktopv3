using ConexionBD;
using ConexionBD.Models;
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

namespace ERP.Common.Procesos.Restaurante
{
    public partial class frmPedidoCancelacion : XtraForm
    {
        public int pedidoId { get; set; }
        ERPProdEntities oCOntext;
        public PuntoVentaContext puntoVentaContext;
        public bool nuevaComanda = true;

        public frmPedidoCancelacion()
        {
            InitializeComponent();
            oCOntext = new ERPProdEntities();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if(uiMotivo.Text.Trim() == "")
                {
                    XtraMessageBox.Show("El motivo es requerido",
                    "ERROR",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                    return;
                }

                oCOntext.p_doc_pedidos_orden_cancelacion(pedidoId, uiMotivo.Text, puntoVentaContext.usuarioId);
                this.DialogResult = DialogResult.OK;
                this.Close();
                if(nuevaComanda)
                {
                    frmPuntoVentaRest.GetInstance().Close();
                    frmComandaNueva frmo = new frmComandaNueva();
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.StartPosition = FormStartPosition.CenterParent;
                    frmo.ShowDialog();
                }
               

               


            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al cancelar el pedido",
                    "ERROR",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }
    }
}
