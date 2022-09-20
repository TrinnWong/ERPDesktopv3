using ConexionBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Forms
{
    public partial class frmFormasPagoCaptura : Form
    {
        public List<FormaPagoModel> lstFormasPago;
        public int opcionPV { get; set; }
        ERPProdEntities oContext;
        public frmFormasPagoCaptura()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void frmFormasPagoCaptura_Load(object sender, EventArgs e)
        {
            if (lstFormasPago.Count == 0)
            {
                lstFormasPago = oContext.cat_formas_pago.Where(w => w.Activo == true && !w.Descripcion.Contains("VALE"))
                    .Select(
                        s => new FormaPagoModel()
                        {
                            cantidad = 0,
                            descripcion = s.Descripcion,
                            digitoVerificador = "",
                            id = s.FormaPagoId,
                            requiereDigito = s.RequiereDigVerificador
                        }
                    ).ToList();
                uiFormasPago.DataSource = lstFormasPago;
            }
            else {
                uiFormasPago.DataSource = lstFormasPago.Where(w=> !w.descripcion.Contains("VALE")).ToList();
            }
            


        }

        private void calcularTotales()
        {
            uiTotal.Value = lstFormasPago.Sum(s => s.cantidad).Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string error = validar();

            if (error.Length > 0)
            {
                MessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (opcionPV == (int)Enumerados.opcionesPV.apartados)
            {
                frmApartadosUpd.GetInstance().lstFormasPagoAnticipo = this.lstFormasPago;
                frmApartadosUpd.GetInstance().calcularTotalAnticipo();
            }

            if (opcionPV == (int)Enumerados.opcionesPV.apartadosPagos)
            {
                frmApartadosPagos.GetInstance().lstFormaPago = this.lstFormasPago;
                frmApartadosPagos.GetInstance().calcularTotal();
            }

            this.Close();
        }

        private string validar()
        {
            string error = "";
            foreach (var item in lstFormasPago)
            {
                if (item.requiereDigito && item.digitoVerificador.Trim() == ""
                    && item.cantidad > 0)
                {
                    error = "La forma de pago " + item.descripcion + " requiere digito verificador \n";
                }

                if (item.cantidad < 0)
                {
                    error = error + "La cantidad no puede ser menor a 0";
                }
            }

            return error;
        }

        private void uiFormasPago_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calcularTotales();
        }
    }
}
