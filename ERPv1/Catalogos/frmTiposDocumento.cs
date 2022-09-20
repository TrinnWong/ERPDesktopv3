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
    public partial class frmTiposDocumento : Form
    {
        ConexionBD.TiposDocumento oData;
        public frmTiposDocumento()
        {
            InitializeComponent();

            oData = new ConexionBD.TiposDocumento();

            Buscar();
        }

        #region eventos de controles
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                cat_tipos_documento entity = new cat_tipos_documento();

                entity.TipoDocumentoId = (byte)uiClave.Value;
                entity.Abreviatura = uiAbreviatura.Text;
                entity.Descripcion = uiDescripcion.Text;
                entity.FolioInicial = (int)uiFolioInicial.Value;
                entity.IntegrarCorteCaja = uiIntegrarCorte.Checked;
                entity.RequiereClaveSuper = uiReqClaveSup.Checked;                

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                cat_tipos_documento entity = new cat_tipos_documento();

                entity.TipoDocumentoId = (byte)uiClave.Value;
                entity.Abreviatura = uiAbreviatura.Text;
                entity.Descripcion = uiDescripcion.Text;
                entity.FolioInicial = (int)uiFolioInicial.Value;
                entity.IntegrarCorteCaja = uiIntegrarCorte.Checked;
                entity.RequiereClaveSuper = uiReqClaveSup.Checked;

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
                    if ((byte)row.Cells[0].Value > 0)
                    {
                        int clave = (byte)row.Cells[0].Value;
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

        #region funciones
        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();

            dgvGrid.DataSource = oData.oContext.cat_tipos_documento.Where(
                w => w.Descripcion.Contains(busqueda)
                ||
                w.Abreviatura.Contains(busqueda)
                ||
                busqueda == ""
                )
                .Select(
                    s=> new {
                        Clave = s.TipoDocumentoId,
                        Descripción = s.Descripcion
                    }
                )
                .ToList();
            dgvGrid.Refresh();
        }

        private void Limpiar()
        {
            uiClave.Value = 0;
            uiAbreviatura.Text = "";
            uiDescripcion.Text = "";
            uiFolioInicial.Value = 0;
            uiIntegrarCorte.Checked = false;

            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            
        }


        private void BuscarRegistro(int clave)
        {
            cat_tipos_documento entity = oData.oContext.cat_tipos_documento
                .Where(w => w.TipoDocumentoId == clave).FirstOrDefault();

            this.uiClave.Value = entity.TipoDocumentoId;
            this.uiAbreviatura.Text = entity.Abreviatura;
            this.uiDescripcion.Text = entity.Descripcion;
            this.uiFolioInicial.Value = entity.FolioInicial;
            this.uiIntegrarCorte.Checked = entity.IntegrarCorteCaja;
            this.uiReqClaveSup.Checked = entity.RequiereClaveSuper;

            btnAgregar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;

        }


        #endregion


    }
}
