using ConexionBD;
using ConexionBD.Models;
using ERP.Common.Procesos.Restaurante;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ConexionBD.Enumerados;

namespace ERP.Common.Procesos
{
    public partial class frmVentaFormasPagoDialog : Form
    {
        decimal totalTarjeta { get; set; }
        public decimal totalVenta { get; set; }

        public decimal cambio { get; set; }
        public List<FormaPagoModel> lstFormasPago { get; set; }
        public List<ValeFPModel> lstVales { get; set; }

        ERPProdEntities oContext;
        public frmVentaFormasPagoDialog()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        #region eventos de la forma
        private void frmVentaFormasPago_Load(object sender, EventArgs e)
        {
            this.Show();
            lstVales = new List<ValeFPModel>();

            uiGridFormasPago.AutoGenerateColumns = false;
            //uiGridFormasPago.DataSource =
            lstFormasPago = 
            oContext.cat_formas_pago
            .Where(w=> w.Activo == true)
            .Select(
                
                s => new FormaPagoModel()
                {
                     cantidad= 0,
                      descripcion = s.Descripcion,
                       digitoVerificador = "",
                        id = s.FormaPagoId
                }
                ).ToList();

            uiGridFormasPago.DataSource = lstFormasPago;

            uiTotalVenta.Value = totalVenta;



            if (uiGridFormasPago.Rows.Count > 0)
            {
                DataGridViewCell cell = uiGridFormasPago.Rows[0].Cells[2];
                cell.Selected = true;
                uiGridFormasPago.CurrentCell = cell;
                uiGridFormasPago.BeginEdit(false);
            }

         
           
        }
        #endregion

        #region eventos de controles
        private void uiGridFormasPago_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                calcularCantidades();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        #endregion

        #region metodos
        private void calcularCantidades()
        {
            decimal totalFormasPago=0;
            decimal totalEfectivo = 0;
            totalTarjeta = 0;

            lstFormasPago = new List<FormaPagoModel>();            

            foreach (DataGridViewRow itemRow in uiGridFormasPago.Rows)
            {
                FormaPagoModel entity = new FormaPagoModel();

                entity.cantidad = (itemRow.Cells["Cantidad"].Value != null ? decimal.Parse(itemRow.Cells["Cantidad"].Value.ToString()) : 0);
                entity.id = int.Parse(itemRow.Cells["ID"].Value.ToString());
                entity.digitoVerificador = itemRow.Cells["digitoVerificador"].Value != null ? itemRow.Cells["digitoVerificador"].Value.ToString() : "";
                entity.descripcion = itemRow.Cells["FormaPago"].Value.ToString();

                if (itemRow.Cells["FormaPago"].Value.ToString().ToUpper().Contains("EFECTIVO"))
                {
                    totalEfectivo = totalEfectivo + (itemRow.Cells["Cantidad"].Value != null ? decimal.Parse(itemRow.Cells["Cantidad"].Value.ToString()) : 0);
                }

                if (
                    itemRow.Cells["FormaPago"].Value.ToString().ToUpper().Contains("TARJETA")
                    ||
                    itemRow.Cells["FormaPago"].Value.ToString().ToUpper().Contains("VALE")

                    )
                {
                    totalTarjeta = totalTarjeta + (itemRow.Cells["Cantidad"].Value != null ? decimal.Parse(itemRow.Cells["Cantidad"].Value.ToString()) : 0);
                }


                lstFormasPago.Add(entity);

                totalFormasPago = totalFormasPago +( itemRow.Cells["Cantidad"].Value != null ? decimal.Parse(itemRow.Cells["Cantidad"].Value.ToString()) : 0);
                
            }

            uiTotalRecibido.Value = totalFormasPago;
            uiFaltante.Value = (totalVenta - totalFormasPago) <0 ? 0 : (totalVenta - totalFormasPago);

            if ((totalVenta - totalFormasPago) < 0)
            {
                uiCambio.Value = Math.Abs((totalVenta - totalFormasPago));
                if (uiCambio.Value > totalEfectivo)
                {
                    uiCambio.Value = 0;
                }
            }
            else
            {
                uiCambio.Value = 0;
            }

            
        }

        private void pagar()
        {

            uiPagar.Enabled = false;
            string error = "";
            if (double.Parse(uiFaltante.Value.ToString()) > 0.01)
            {
                error = "Es necesario cubrir el total de la venta";
                
            }

            if (totalTarjeta > (uiTotalVenta.Value + (decimal)0.01))
            {
                error="\nEl total recibido en tarjeta no puede ser mayor al total de la venta";
                
            }         

            //validar digito verificador
            List<cat_formas_pago> lstFP = oContext.cat_formas_pago.ToList();
            foreach (var itemFP in lstFormasPago)
            {
                int formaPagoId = itemFP.id;
                cat_formas_pago entityFP = lstFP.Where(w => w.FormaPagoId == formaPagoId).FirstOrDefault();

                //if (entityFP.RequiereDigVerificador == true && itemFP.cantidad > 0 && itemFP.digitoVerificador.Trim() == "")
                //{
                //    error = "\nEs necesario ingresar el digito verificador para la forma de pago:" + itemFP.descripcion;
                    
                //}

                if (itemFP.cantidad < 0)
                {
                    error = "\nNo es posible capturar cantidades en negativo";
                }
            }
            cambio = uiCambio.Value;
            if (error.Length == 0)
            {
                //frmPuntoVenta oForm = (frmPuntoVenta)this.Owner.MdiChildren[0];

                this.DialogResult = DialogResult.OK;

                this.Close();
                //System.Threading.Thread.Sleep(2000);

            }
            else
            {
                MessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                uiPagar.Enabled = true;

               
            }

        }

        private void agregarVale()
        {
            try
            {
                int valeId;

                int.TryParse(uiFolioVale.Text,out valeId);

                DateTime fechaActual=oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                if (valeId > 0)
                {
                    doc_devoluciones entityDev = oContext.doc_devoluciones.Where(
                        w => w.DevolucionId == valeId && w.FechaVencimiento >= fechaActual
                        && w.doc_ventas_formas_pago_vale.Count == 0
                    ).FirstOrDefault();

                    if (entityDev != null)
                    {

                        ValeFPModel valeModel = new ValeFPModel();

                        valeModel.index = lstVales.Count + 1;
                        valeModel.folioVale = valeId;
                        valeModel.monto = entityDev.Total;
                        valeModel.tipoVale = (int)tipoVale.devolucion;
                        valeModel.fechaVencimiento = entityDev.FechaVencimiento ?? DateTime.MinValue;

                        if (lstVales.Where(w => w.folioVale == valeId).Count() > 0)
                            return;

                        lstVales.Add(valeModel);

                        uiGriVales.AutoGenerateColumns = false;
                        uiGriVales.DataSource = lstVales.ToList();

                        decimal totalVale = lstVales.Sum(s => s.monto);

                        calcularVales();


                       

                        calcularCantidades();

                    }
                    else {
                        MessageBox.Show("El vale no existe, se encuentra vencido o ya fue utiizado en otra venta","ERROR");
                    }
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void calcularVales()
        {

            lstFormasPago.Where(w => w.id == 5).First().cantidad = lstVales.Sum(s => s.monto);

            uiGridFormasPago.DataSource = lstFormasPago;
        }





        #endregion

        private void uiPagar_Click(object sender, EventArgs e)
        {
            pagar();
        }

        private void btnAgregarVale_Click(object sender, EventArgs e)
        {
            agregarVale();
        }

        private void uiGridFormasPago_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (
                    uiGridFormasPago.Rows[e.RowIndex].Cells["FormaPago"].Value.ToString().Contains("VALE")
                    )
                {
                 e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message,"ERROR");
            }
        }

        private void uiGriVales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
               e.RowIndex >= 0 &&
               lstVales.Count > 0
               )
            {
                int index = int.Parse(uiGriVales.Rows[e.RowIndex].Cells["Folio"].Value.ToString());

                ValeFPModel deleteItem = lstVales.Where(w => w.folioVale == index).FirstOrDefault();

                lstVales.Remove(deleteItem);

                // senderGrid.Rows.RemoveAt(e.RowIndex);
                uiGriVales.AutoGenerateColumns = false;
                uiGriVales.DataSource = lstVales.ToList();

                calcularVales();
                calcularCantidades();
            }

            //foreach (DataGridViewRow item in this.uiGriVales.SelectedRows)
            //{
            //    uiGriVales.Rows.RemoveAt(item.Index);
            //}
        }

        private void uiGridFormasPago_CausesValidationChanged(object sender, EventArgs e)
        {

        }

        private void frmVentaFormasPagoDialog_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.F2)
            {
                pagar();
            }
        }

        private void uiGridFormasPago_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                pagar();
            }
        }

        private void uiGridFormasPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pagar();
            }
        }

        private void uiGridFormasPago_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyDown += Control_KeyDown;
        }


        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificar si la tecla presionada es F2
            if (e.KeyCode == Keys.F3)
            {
                // Llamar al método "pagar()"
                pagar();
            }
        }
    }

   
   
}
