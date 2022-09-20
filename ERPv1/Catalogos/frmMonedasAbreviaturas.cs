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
    public partial class frmMonedasAbreviaturas : Form
    {
        ConexionBD.MonedasAbreviaturas oData;
        public frmMonedasAbreviaturas()
        {
            oData = new MonedasAbreviaturas();
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                cat_monedas_abreviaturas entity = new cat_monedas_abreviaturas();

                entity.IdMonedaAbreviatura = (int)this.nClave.Value;
                entity.Activo = chkEstatus.Checked;
                entity.ClaveSAT = txtCodigoSAT.Text;
                entity.NombreMonedaSAT = txtNombreAlmacen.Text;

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

            dgvGrid.DataSource = oData.oContext.cat_monedas_abreviaturas.Where(
                w => w.ClaveSAT.Contains(busqueda)
                ||
                w.NombreMonedaSAT.Contains(busqueda)
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
                cat_monedas_abreviaturas entity = new cat_monedas_abreviaturas();

                entity.IdMonedaAbreviatura = (int)this.nClave.Value;
                entity.Activo = chkEstatus.Checked;
                entity.ClaveSAT = txtCodigoSAT.Text;
                entity.NombreMonedaSAT = txtNombreAlmacen.Text;

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
            cat_monedas_abreviaturas entity = oData.oContext.cat_monedas_abreviaturas
                .Where(w => w.IdMonedaAbreviatura == clave).FirstOrDefault();

            this.nClave.Value = entity.IdMonedaAbreviatura;
            this.txtNombreAlmacen.Text = entity.NombreMonedaSAT;
            txtCodigoSAT.Text = entity.ClaveSAT;
            this.chkEstatus.Checked = entity.Activo;
        }

        private void frmMonedasAbreviaturas_Load(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
