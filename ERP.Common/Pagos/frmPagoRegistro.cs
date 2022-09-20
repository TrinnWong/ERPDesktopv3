using ConexionBD;
using ERP.Business;
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

namespace ERP.Common.Pagos
{
    public partial class frmPagoRegistro : FormBaseXtraForm
    {
        public int clienteId { get; set; }
        public int cargoId { get; set; }

        private PagoBusiness oPagoB;
        int err = 0;
        string error = "";
        public frmPagoRegistro()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            oPagoB = new PagoBusiness();
        }

        private void ClearObjects()
        {
            oPagoB = null;
        }

        private void frmPagoRegistro_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearObjects();
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadFormasPago()
        {
            try
            {
                uiFormaPago.Properties.DataSource = oContext.cat_formas_pago
                    .Where(w=> w.Activo == true)
                    .ToList();

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
                bool tieneError=false;
                dxErrorProvider1.ClearErrors();

                if (uiFechaPago.EditValue == null)
                {
                    dxErrorProvider1.SetError(uiFechaPago, "La fecha no es válida");
                    tieneError = true;
                }
                if (uiFormaPago.EditValue == null)
                {
                    dxErrorProvider1.SetError(uiFormaPago, "La forma de pago no es válida");
                    tieneError = true;
                }
                if (uiMonto.Value == 0)
                {
                    dxErrorProvider1.SetError(uiMonto, "El monto no es válido");
                    tieneError = true;
                }
                doc_cargos entityCargo = oContext.doc_cargos
                        .Where(w => w.CargoId == cargoId).FirstOrDefault();

                if (entityCargo.Saldo < uiMonto.Value)
                {
                    dxErrorProvider1.SetError(uiMonto, "El monto no puede ser mayor al saldo del cargo");
                    tieneError = true;

                }

                if (tieneError)
                {
                    ERP.Utils.MessageBoxUtil.ShowError("Revise nuevamente la información");
                }
                else
                {
                    doc_pagos entity = new doc_pagos();

                    
                    

                    entity.CargoId = cargoId;
                    entity.ClienteId = clienteId;
                    entity.FechaPago = uiFechaPago.DateTime;
                    entity.FormaPagoId = Convert.ToInt32(uiFormaPago.EditValue);
                    entity.Monto = uiMonto.Value;
                    entity = oPagoB.Guardar(entity,puntoVentaContext.usuarioId,puntoVentaContext.sucursalId, ref error);
                    if(error.Length > 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowError(error);
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                    }
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

        private void frmPagoRegistro_Load(object sender, EventArgs e)
        {
            uiFechaPago.EditValue = DateTime.Now;
            LoadFormasPago();
        }
    }
}
