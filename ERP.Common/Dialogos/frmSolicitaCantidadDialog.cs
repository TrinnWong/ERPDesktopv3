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
    public partial class frmSolicitaCantidadDialog : Form
    {
        public string titulo { get; set; }
        public decimal cantidad { get; set; }
        public decimal cantidadMaxima { get; set; }

        public frmSolicitaCantidadDialog()
        {
            InitializeComponent();
        }

        private void frmSolicitaCantidadDialog_Load(object sender, EventArgs e)
        {
            this.lblTitulo.Text = this.titulo;
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            if(uiCantidad.Value <= 0)
            {
                ERP.Utils.MessageBoxUtil.ShowError("La cantidad debe de ser mayor a 0");
                return;
            }
            if(cantidadMaxima > 0)
            {
                if(uiCantidad.Value > cantidadMaxima)
                {
                    ERP.Utils.MessageBoxUtil.ShowError("La cantidad sobrepasa el límite permitido");
                    return;
                }
            }
                this.cantidad = this.uiCantidad.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
