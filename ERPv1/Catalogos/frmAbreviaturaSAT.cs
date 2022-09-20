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

namespace ERPv1.Catalogos
{
    public partial class frmAbreviaturaSAT : Form
    {
        ConexionBD.AbreviaturasSAT oData;
        public frmAbreviaturaSAT()
        {
            oData = new AbreviaturasSAT();
           
            InitializeComponent();

            Buscar();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                cat_abreviaturas_SAT entity = new cat_abreviaturas_SAT();

                entity.Clave = (int)this.nClave.Value;
                entity.Activo = chkEstatus.Checked;
                entity.AbreviaturaSAT = txtNombreAlmacen.Text;
                entity.CodigoSAT = txtCodigoSAT.Text;

                error = oData.Insertar(entity);

                if (error.Length > 0)
                {
                    MessageBox.Show(error, "Error");
                }
                else
                {
                    MessageBox.Show("El registro se agregó correctamente");
                    Buscar();
                    Limpiar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();

            dgvGrid.DataSource = oData.oContext.cat_abreviaturas_SAT.Where(
                w => w.AbreviaturaSAT.Contains(busqueda)
                ||
                w.CodigoSAT.Contains(busqueda)
                ||
                busqueda == ""
                ).ToList();
            dgvGrid.Refresh();
        }

        private void Limpiar()
        {

            this.nClave.Value = 0;
            this.txtNombreAlmacen.Text = "";
            txtCodigoSAT.Text = "";
            this.chkEstatus.Checked = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                cat_abreviaturas_SAT entity = new cat_abreviaturas_SAT();

                entity.Clave = (int)this.nClave.Value;
                entity.Activo = chkEstatus.Checked;
                entity.AbreviaturaSAT = txtNombreAlmacen.Text;
                entity.CodigoSAT = txtCodigoSAT.Text;

                error = oData.Actualizar(entity);

                if (error.Length > 0)
                {
                    MessageBox.Show(error, "Error");
                }
                else
                {
                    MessageBox.Show("Registro Actualizado");
                    Buscar();
                    Limpiar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    MessageBox.Show("¿Está seguro de eliminar el registro", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes
                    )
                {
                    oData.Eliminar((int)this.nClave.Value);
                    Buscar();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dgvGrid.Rows[rowIndex];
                try
                {
                    if ((int)row.Cells[0].Value > 0)
                    {
                        int clave = (int)row.Cells[0].Value;
                        if (clave > 0)
                        {
                            BuscarRegistro(clave);
                        }
                    }
                }
                catch { }
            }
        }

        private void BuscarRegistro(int clave)
        {
            cat_abreviaturas_SAT entity = oData.oContext.cat_abreviaturas_SAT
                .Where(w => w.Clave == clave).FirstOrDefault();

            this.nClave.Value = entity.Clave;
            this.txtNombreAlmacen.Text = entity.AbreviaturaSAT;
            txtCodigoSAT.Text = entity.CodigoSAT;
            this.chkEstatus.Checked = entity.Activo ;
        }
    }
}
