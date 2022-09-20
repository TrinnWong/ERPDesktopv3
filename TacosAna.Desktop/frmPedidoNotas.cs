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
    public partial class frmPedidoNotas : Form
    {
        public ERP.Business.Enumerados.tipoPedido TipoPedido { get; set; }
        public frmPedidoNotas()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmPuntoVenta frmo = frmPuntoVenta.GetInstance();
            if (!frmo.Visible)
            {
                XtraMessageBox.Show("No tiene ninguna cuenta abierta","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if(uiNotas.Text.Trim().Length == 0)
                {
                    XtraMessageBox.Show("Las notas son requeridas", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string error = frmo.guardarTemporal(uiNotas.Text, TipoPedido);

                    if(error.Length == 0)
                    {
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
        }

        private void frmPedidoNotas_Load(object sender, EventArgs e)
        {
            frmPuntoVenta frmo = frmPuntoVenta.GetInstance();

            if (frmo.Visible)
            {
                uiNotas.Text = frmo.notas;
            }
        }
    }
}
