using ConexionBD;
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

namespace ERP.Common.Dialogos
{
    public partial class frmCancelacionVentaComentario : FormBaseXtraForm
    {
        public List<ProductoModel0> lstProductos { get; set; }
        ResultAPIModel result;
        public int pedidoId { get; set; }

        public frmCancelacionVentaComentario()
        {
            InitializeComponent();
            result = new ResultAPIModel();
        }

        private void frmCancelacionVentaComentario_Load(object sender, EventArgs e)
        {

        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            result = new ResultAPIModel();
            if(uiComentario.Text.Trim() == "")
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario ingresar un comentario");
                this.DialogResult = DialogResult.Cancel;
            }
            if(pedidoId == 0)
            {
                result = ERP.Business.VentasBusiness.GuardaVentaCancelada(this.lstProductos,
               uiComentario.Text,
               this.puntoVentaContext.usuarioId,
               this.puntoVentaContext.cajaId,
               this.puntoVentaContext.sucursalId);
            }
            else
            {
                oContext = new ERPProdEntities();

                doc_pedidos_orden entityPedido = oContext.doc_pedidos_orden
                    .Where(w => w.PedidoId == pedidoId).FirstOrDefault();

                if(entityPedido.doc_pedidos_cargos.Where(w=> w.doc_cargos.doc_pagos.Count() > 0).Count() > 0)
                {
                    result.error = "El pedido ya tiene pagos asociados, no es posible cancelar";
                }
                else
                {
                    entityPedido.Activo = false;
                    entityPedido.FechaCancelacion = ERP.Business.Tools.TimeTools.ConvertToTimeZoneDefault();
                    entityPedido.MotivoCancelacion = uiComentario.Text.Trim();

                    oContext.SaveChanges();
                }

                
            }
           

            if (result.ok)
            {
                this.DialogResult = DialogResult.OK;
                ERP.Utils.MessageBoxUtil.ShowOk();
               
            }
            else
            {
                ERP.Utils.MessageBoxUtil.ShowError(result.error);
                this.DialogResult = DialogResult.Cancel;
                return;
            }

           
            this.Close();
        }
    }
}
