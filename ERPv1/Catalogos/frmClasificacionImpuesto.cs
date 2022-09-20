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
    public partial class frmClasificacionImpuesto : Form
    {
        ConexionBD.ClasificacionImpuestos oData;

        public frmClasificacionImpuesto()
        {
            oData = new ClasificacionImpuestos();
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                cat_clasificacion_impuestos entity = new cat_clasificacion_impuestos();

                entity.Clave = (int)this.nClave.Value;
                entity.Activo = chkEstatus.Checked;
                entity.NombreSAT = txtNombreAlmacen.Text;

                error= oData.Insertar(entity);

                if (error.Length > 0)
                {
                    MessageBox.Show(error, "Error");
                }
                else {
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

            dgvGrid.DataSource = oData.oContext.cat_clasificacion_impuestos.Where(
                w=> w.NombreSAT.Contains(busqueda) 
                ||
                busqueda == ""
                ).ToList();
            dgvGrid.Refresh();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                cat_clasificacion_impuestos entity = new cat_clasificacion_impuestos();

                entity.Clave = (int)this.nClave.Value;
                entity.Activo = chkEstatus.Checked;
                entity.NombreSAT = txtNombreAlmacen.Text;

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

        private void dgvGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void BuscarRegistro(int clave)
        {
            cat_clasificacion_impuestos entity = oData.oContext.cat_clasificacion_impuestos
                .Where(w => w.Clave == clave).FirstOrDefault();

            this.nClave.Value = entity.Clave;
            this.txtNombreAlmacen.Text = entity.NombreSAT;
            this.chkEstatus.Checked = entity.Activo;
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

        private void Limpiar()
        {

            this.nClave.Value = 0;
            this.txtNombreAlmacen.Text = "";
            this.chkEstatus.Checked = true;
        }

        private void frmClasificacionImpuesto_Load(object sender, EventArgs e)
        {
            
            Buscar();
            Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
