using ConexionBD;
using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace ERP.Common.Forms
{
    public partial class frmApartadosPagos : Form
    {
        public PuntoVentaContext puntoVentaContext;
        ERPProdEntities oContext;
        decimal saldo { get; set; }
        public int id { get; set; }
        public List<FormaPagoModel> lstFormaPago { get; set; }

        private static frmApartadosPagos _instance;
        public static frmApartadosPagos GetInstance()
        {

            if (_instance == null) _instance = new frmApartadosPagos();
            return _instance;
        }
        public frmApartadosPagos()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            lstFormaPago = new List<FormaPagoModel>();
            
        }

        public void LlenarForma()
        {
            try
            {
                doc_apartados entity = oContext.doc_apartados.Where(w => w.ApartadoId == id).FirstOrDefault();

                uiFolio.Value = id;
                uiCliente.Text = entity.cat_clientes.Nombre;
                uiSaldo.Text = entity.Saldo.ToString("c2");
                uiTotal.Text = entity.TotalApartado.ToString("c2");
                saldo = entity.Saldo;
                uiGridPagos.AutoGenerateColumns = false;
                uiGridPagos.DataSource = entity.doc_apartados_pagos.OrderByDescending(w => w.FechaPago)
                    .Select(
                        s => new {
                            s.Importe,
                            s.FechaPago
                            //,
                            //formaPago = s.cat_formas_pago != null ? s.cat_formas_pago.Descripcion : "",
                            //digitoVer = s.DigitoVerificador
                        }
                       
                    )
                    .ToList();
                //uiFormaPago.DataSource = oContext.cat_formas_pago.Where(w => w.Activo == true && !w.Descripcion.ToUpper().Contains("VALE")).ToList();

                if (saldo <= 0)
                {
                    uiGridPagos.Enabled = false;
                    uiImportePago.Enabled = false;
                    uiFechaPago.Enabled = false;
                    uiAgregarPago.Enabled = false;
                    uiPagar.Enabled = false;
                }

            }
            catch (Exception)
            {

                MessageBox.Show("ERROR AL OBTENER LA INFORMACIÓN DE PAGOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmApartadosPagos_Load(object sender, EventArgs e)
        {
            LlenarForma();
        }

        public void calcularTotal()
        {
            uiImportePago.Value = lstFormaPago.Sum(s => s.cantidad).Value;
        }

        private void uiAgregarPago_Click(object sender, EventArgs e)
        {
            try
            {

                frmFormasPagoCaptura oFrm = new frmFormasPagoCaptura();
                oFrm.lstFormasPago = this.lstFormaPago;
                oFrm.opcionPV = (int)Enumerados.opcionesPV.apartadosPagos;
                oFrm.ShowDialog();


               

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error al registrar el pago", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmApartadosPagos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiPagar_Click(object sender, EventArgs e)
        {
            if (uiImportePago.Value <= 0)
            {
                MessageBox.Show("El importe debe de ser mayor que cero", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (uiImportePago.Value > saldo)
            {
                MessageBox.Show("No es posible pagar mas de lo que se adeuda", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (frmApartadosUpd.GetInstance().requiereDigito(int.Parse(uiFormaPago.SelectedValue.ToString())))
            //{
            //    if (uiDigitoVer.Text.Trim() == "")
            //    {
            //        MessageBox.Show("El digito verificador es requerido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}


            int apartadoPago = 0;
            using (TransactionScope scope = new TransactionScope())
            {
                ObjectParameter pApartadoId = new ObjectParameter("pApartadoPagoId", 0);
                //int formaPagoId = int.Parse(uiFormaPago.SelectedValue.ToString());

                foreach (var item in lstFormaPago)
                {
                    if(item.cantidad > 0)
                    {
                        oContext.p_doc_apartados_pagos_ins(pApartadoId, id, item.cantidad, uiFechaPago.Value, puntoVentaContext.usuarioId, false, item.id, item.digitoVerificador,this.puntoVentaContext.cajaId);
                    }
                    
                }
                

                oContext = new ERPProdEntities();

                LlenarForma();

                uiImportePago.Value = 0;
                uiFechaPago.Value = DateTime.Now;

                apartadoPago = int.Parse(pApartadoId.Value.ToString());

                //if (saldo <= 0)
                //{
                //    ObjectParameter pVentaId = new ObjectParameter("pVentaId", 0);
                //    oContext.p_doc_apartado_venta_generacion(id, this.puntoVentaContext.usuarioId, pVentaId);

                //    int ventaId = int.Parse(pVentaId.Value.ToString());
                //    frmApartadosUpd.GetInstance().imprimirTicket(ventaId);


                //}

                scope.Complete();

                lstFormaPago = new List<FormaPagoModel>();

               
            }
            if (frmApartadosList.GetInstance() != null)
            {
                frmApartadosList.GetInstance().LlenarGrid();
            }

            frmApartadosUpd.GetInstance().llenarForma();
            frmApartadosUpd.GetInstance().imprimir(id, apartadoPago);


            MessageBox.Show("El pago se agregó correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
