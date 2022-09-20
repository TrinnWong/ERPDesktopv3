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
    public partial class frmFormasPago : Form
    {

        ConexionBD.FormasPago oData;
        public frmFormasPago()
        {
            InitializeComponent();
            oData = new ConexionBD.FormasPago();
            Buscar();
        }

        #region eventos de controles

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {

                

                cat_formas_pago entity = new cat_formas_pago();

                entity.Abreviatura = uiAbreviatura.Text;
                entity.Activo = uiActivo.Checked;
                entity.Descripcion = uiDescripcion.Text;
                entity.FormaPagoId = (int)uiClave.Value;
                entity.NumeroHacienda = (short)uiNumHacienda.Value;
                entity.Orden = (short)uiOrden.Value;
                entity.RequiereDigVerificador = uiRequiereDig.Checked;
                entity.Signo = uiMas.Checked ? "+" : "-";


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

       
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            { 
            cat_formas_pago entity = new cat_formas_pago();

            entity.Abreviatura = uiAbreviatura.Text;
            entity.Activo = uiActivo.Checked;
            entity.Descripcion = uiDescripcion.Text;
            entity.FormaPagoId = (int)uiClave.Value;
            entity.NumeroHacienda = (short)uiNumHacienda.Value;
            entity.Orden = (short)uiOrden.Value;
            entity.RequiereDigVerificador = uiRequiereDig.Checked;
            entity.Signo = uiMas.Checked ? "+" : "-";
            

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    MessageBox.Show("¿Está seguro de eliminar el registro", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes
                    )
                {
                    oData.Eliminar((int)this.uiClave.Value);
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
        #endregion

        #region Funciones
        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();

            dgvGrid.DataSource = oData.oContext.cat_formas_pago.Where(
                w => w.Descripcion.Contains(busqueda)
                ||
                w.Abreviatura.Contains(busqueda)
                ||
                busqueda == ""
                ).ToList();
            dgvGrid.Refresh();
        }

        private void Limpiar()
        {

            uiAbreviatura.Text = "";
            uiActivo.Checked = false;
            uiClave.Value = 0;
            uiDescripcion.Text = "";
            uiMas.Text = "";
            uiMenos.Text = "";
            uiNumHacienda.Value = 0;
            uiOrden.Value = 0;
            uiRequiereDig.Checked = false;
            uiClave.Enabled = true;
            uiDescripcion.Enabled = true;

            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void BuscarRegistro(int clave)
        {
            cat_formas_pago entity = oData.oContext.cat_formas_pago
                .Where(w => w.FormaPagoId == clave).FirstOrDefault();

            uiAbreviatura.Text = entity.Abreviatura;
            uiActivo.Checked = entity.Activo;
            uiClave.Value = entity.FormaPagoId;
            uiDescripcion.Text = entity.Descripcion;
            uiMas.Checked = entity.Signo == "+" ? true : false;
            uiMenos.Checked = entity.Signo == "-" ? true : false;
            uiNumHacienda.Value = entity.NumeroHacienda;
            uiOrden.Value = entity.Orden;
            uiRequiereDig.Checked = entity.RequiereDigVerificador;
            uiClave.Enabled = false;

            btnAgregar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;

            if (uiClave.Value == 1 ||
                uiClave.Value == 2 ||
                uiClave.Value == 3
                )
            {
                uiClave.Enabled = false;
                uiDescripcion.Enabled = false;

            }
            else {
                uiDescripcion.Enabled = true;
            }
            
        }


        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
