using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConexionBD.Utilerias;
using ConexionBD;
using ConexionBD.Models;

namespace ERPv1.Catalogos
{
    public partial class frmFamilias : Form
    {
        Resultado resultado;
        FamiliasInterface fI;
        ERPProdEntities oContext;
        public frmFamilias()
        {
            InitializeComponent();
            fI = new FamiliasInterface();
            dgvFamilia.DefaultCellStyle.ForeColor = Color.Black;
            oContext = new ERPProdEntities();
           
        }

        #region Metodos

        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();

            dgvFamilia.DataSource = fI.ConsultarListado(busqueda);
            dgvFamilia.Refresh();
        }

        private void LimpiarControles()
        {
            nClave.Enabled = true;
            nClave.Value = 0;
            txtNombreFamilia.Text = "";
            chkEstatus.Checked = true;
            uiProductoPortada.SelectedValue = 0;
            uiOrden.Value = 0;
        }

        private Resultado ValidarAgregar(int clave, string nomFamilia)
        {
            resultado = new Resultado();
            if (clave <= 0)
            {
                resultado.mensaje += "La clave debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            else
            {
                DataTable dt = fI.ConsultarRegistro(clave, false);
                if (clave > 0 && dt != null && dt.Rows.Count > 0)
                {
                    resultado.mensaje += "La clave " + clave + " ya existe. \n";
                    resultado.ok = false;
                }
            }
            if (nomFamilia == "")
            {
                resultado.mensaje += "Capture el nombre de la familia.";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEditar(int clave, string nomFamilia)
        {
            resultado = new Resultado();
            DataTable dt = fI.ConsultarRegistro(clave, false);
            if (clave <= 0)
            {
                resultado.mensaje += "La clave debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            if (clave > 0 && (dt == null || dt.Rows.Count <= 0))
            {
                resultado.mensaje += "La clave " + clave + " no existe. \n";
                resultado.ok = false;
            }
            if (nomFamilia == "")
            {
                resultado.mensaje += "Capture el nombre de la familia.";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEliminar(int clave)
        {
            resultado = new Resultado();
            DataTable dt = fI.ConsultarRegistro(clave, false);
            if (clave <= 0)
            {
                resultado.mensaje += "La clave debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            if (clave > 0 && (dt == null || dt.Rows.Count <= 0))
            {
                resultado.mensaje += "La clave " + clave + " no existe. \n";
                resultado.ok = false;
            }            
            return resultado;
        }

        private void Insertar()
        {
            resultado = new Resultado();
            int clave = (int)nClave.Value;
            string nomFamilia = txtNombreFamilia.Text.Trim();
            bool estatus = chkEstatus.Checked ? true : false;
            int? empresa = null;
            int? sucursal = null;
            int? productoPortadaId = uiProductoPortada.SelectedValue != null ?
                int.Parse(uiProductoPortada.SelectedValue.ToString()) : 0;
            int orden = int.Parse(uiOrden.Value.ToString());
            if (!ValidarAgregar(clave, nomFamilia).ok)
            {
                MessageBox.Show(resultado.mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return;
            }
            resultado = fI.Agregar(clave, nomFamilia, estatus, empresa, sucursal, orden, productoPortadaId );
            MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (resultado.ok)
            {
                LimpiarControles();
                Buscar();
            }
        }
        
        private void Editar()
        {
            resultado = new Resultado();
            int clave = (int)nClave.Value;
            string nomFamilia = txtNombreFamilia.Text.Trim();
            bool estatus = chkEstatus.Checked ? true : false;
            int? productoPortadaId = uiProductoPortada.SelectedValue != null ?
               int.Parse(uiProductoPortada.SelectedValue.ToString()) : 0;
            int orden = int.Parse(uiOrden.Value.ToString());
            if (!ValidarEditar(clave, nomFamilia).ok)
            {
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = fI.Actualizar(clave, nomFamilia, estatus,orden, productoPortadaId);
            MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (resultado.ok)
            {
                LimpiarControles();
                Buscar();
            }
        }

        private void Eliminar()
        {
            int clave = (int)nClave.Value;
            if (!ValidarEliminar(clave).ok)
            {
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var opcion = MessageBox.Show("¿Seguro que desea eliminar el registro " + clave +"?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (opcion == DialogResult.OK)
            {
                resultado = new Resultado();                
                resultado = fI.Eliminar(clave);
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (resultado.ok)
                {
                    LimpiarControles();
                    Buscar();
                }
            }
        }

        private int BuscarRegistro(int clave)
        {
            DataTable dt = fI.ConsultarRegistro(clave, false);
            if (dt.Rows != null && dt.Rows.Count > 0)
            {
               
                nClave.Enabled = false;
                nClave.Value = clave;
                txtNombreFamilia.Text = dt.Rows[0]["Descripcion"].ToString();
                chkEstatus.Checked = bool.Parse(dt.Rows[0]["Estatus"].ToString());
                uiProductoPortada.SelectedValue = int.Parse(dt.Rows[0]["ProductoPortadaId"].ToString());
                uiOrden.Value = int.Parse(dt.Rows[0]["Orden"]==DBNull.Value ? "0": dt.Rows[0]["Orden"].ToString());
            }
            return dt == null ? 0 : (dt.Rows == null ? 0 : dt.Rows.Count);
        }

        #endregion

        #region Eventos

        private void frmFamilias_Load(object sender, EventArgs e)
        {
            dgvFamilia.DefaultCellStyle.ForeColor = Color.Black;
            cargarCombos();

            Buscar();
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Buscar();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Insertar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void nClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                int clave = 0;
                try
                {
                    clave = (int)nClave.Value;
                }
                catch {  }

                int numero = BuscarRegistro(clave);
                if (numero == 0)
                {
                    txtNombreFamilia.Focus();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buscar();            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }
        
        private void dgvFamilia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dgvFamilia.Rows[rowIndex];
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

        private void txtNombreFamilia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                chkEstatus.Focus();
            }
        }

        #endregion

        #region Combo
        public void cargarCombos()
        {
            try
            {
                List<ComboBoxViewModel> result = oContext.cat_productos
                    .Where(
                        w => w.cat_productos_imagenes.Count > 0 &&
                        w.Estatus == true
                    )
                    .Select(
                        s => new ComboBoxViewModel()
                        {
                            id = s.ProductoId,
                            descripcion = s.Descripcion
                        }
                    ).ToList();

                result.Add(new ComboBoxViewModel() { id = 0, descripcion = "(Seleccionar)" });

                uiProductoPortada.DataSource = result.ToList();

                uiProductoPortada.SelectedValue = 0;
            }
            catch (Exception)
            {

                
            }
        }
        #endregion
    }
}
