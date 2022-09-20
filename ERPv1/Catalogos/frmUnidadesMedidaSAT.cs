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
    public partial class frmUnidadesMedidaSAT : Form
    {
        ConexionBD.UnidadesMedidasSAT oData;
        public frmUnidadesMedidaSAT()
        {
            oData = new UnidadesMedidasSAT();
            InitializeComponent();
            Buscar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                cat_unidades_medida_SAT entity = new cat_unidades_medida_SAT();

                entity.IdUnidadMedidaSAT =oData.oContext.cat_unidades_medida_SAT.Count() > 0 ?
                    oData.oContext.cat_unidades_medida_SAT.Count() + 1 : 1;
                entity.Activo = chkEstatus.Checked;
                entity.ClaveSAT = uiClave.Text;
                entity.DescripcionSAT = uiDescripcionSAT.Text;
                entity.NombreSAT = uiNombreSAT.Text;

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

            uiGrid.DataSource = oData.oContext.cat_unidades_medida_SAT.Where(
                w => w.ClaveSAT.Contains(busqueda)
                ||
                w.DescripcionSAT.Contains(busqueda)
                ||
                busqueda == ""
                ).ToList();
            uiGrid.Refresh();
        }

        private void Limpiar()
        {

            this.uiClave.Text = "";
            this.uiDescripcionSAT.Text = "";
            uiNombreSAT.Text = "";
            this.chkEstatus.Checked = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                cat_unidades_medida_SAT entity = new cat_unidades_medida_SAT();

                entity.IdUnidadMedidaSAT = (int)this.nClave.Value;
                entity.Activo = chkEstatus.Checked;
                entity.DescripcionSAT = uiDescripcionSAT.Text;
                entity.NombreSAT = uiNombreSAT.Text;
                entity.ClaveSAT = uiClave.Text;

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

        private void uiGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = uiGrid.Rows[rowIndex];
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
            cat_unidades_medida_SAT entity = oData.oContext.cat_unidades_medida_SAT
                .Where(w => w.IdUnidadMedidaSAT == clave).FirstOrDefault();

            this.nClave.Value = entity.IdUnidadMedidaSAT;
            this.uiClave.Text = entity.ClaveSAT;
            uiDescripcionSAT.Text = entity.DescripcionSAT;
            this.uiNombreSAT.Text = entity.NombreSAT;
            this.chkEstatus.Checked = entity.Activo;
        }
    }
}
