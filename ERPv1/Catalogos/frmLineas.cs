using ConexionBD.Utilerias;
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

namespace ERPv1.Catalogos
{
    public partial class frmLineas : Form
    {
        Resultado resultado;
        LineasInterface lI;
        ERPProdEntities oContext;

        public frmLineas()
        {
            InitializeComponent();
            lI = new LineasInterface();
            dgvLinea.DefaultCellStyle.ForeColor = Color.Black;
            oContext = new ERPProdEntities();
        }

        #region Metodos

        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();

            dgvLinea.DataSource = lI.ConsultarListado(busqueda);
            dgvLinea.Refresh();
        }

        private void LimpiarControles()
        {
            nClave.Enabled = true;
            nClave.Value = 0;
            txtNombreLinea.Text = "";
            chkEstatus.Checked = true;
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
                DataTable dt = lI.ConsultarRegistro(clave, false);
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
            DataTable dt = lI.ConsultarRegistro(clave, false);
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
            DataTable dt = lI.ConsultarRegistro(clave, false);
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
            cat_lineas oEntity = oContext.cat_lineas.Where(w => w.Clave == clave).FirstOrDefault();

            if (oEntity != null)
            {
                if (oEntity.cat_productos.Count > 0)
                {
                    resultado.mensaje += "No es posible eliminar la línea ya que está asociada a uno o más productos. \n";
                    resultado.ok = false;
                }
            }
            else {
                resultado.mensaje += "La clave " + clave + " no existe. \n";
                resultado.ok = false;
            }
            return resultado;
        }

        private void Insertar()
        {
            resultado = new Resultado();
            int clave = (int)nClave.Value;
            string nomLinea = txtNombreLinea.Text.Trim();
            bool estatus = chkEstatus.Checked ? true : false;
            int? empresa = null;
            int? sucursal = null;
            if (!ValidarAgregar(clave, nomLinea).ok)
            {
                MessageBox.Show(resultado.mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = lI.Agregar(clave, nomLinea, estatus, empresa, sucursal);
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
            string nomLinea = txtNombreLinea.Text.Trim();
            bool estatus = chkEstatus.Checked ? true : false;
            if (!ValidarEditar(clave, nomLinea).ok)
            {
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = lI.Actualizar(clave, nomLinea, estatus);
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

            var opcion = MessageBox.Show("¿Seguro que desea eliminar el registro " + clave + "?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (opcion == DialogResult.OK)
            {
                resultado = new Resultado();
                resultado = lI.Eliminar(clave);
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
            DataTable dt = lI.ConsultarRegistro(clave, false);
            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                nClave.Enabled = false;
                nClave.Value = clave;
                txtNombreLinea.Text = dt.Rows[0]["Descripcion"].ToString();
                chkEstatus.Checked = bool.Parse(dt.Rows[0]["Estatus"].ToString());
            }
            return dt == null ? 0 : (dt.Rows == null ? 0 : dt.Rows.Count);
        }

        #endregion


        private void frmLineas_Load(object sender, EventArgs e)
        {
            dgvLinea.DefaultCellStyle.ForeColor = Color.Black;
            Buscar();
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
                catch { }

                int numero = BuscarRegistro(clave);
                if (numero == 0)
                {
                    txtNombreLinea.Focus();
                }
            }
        }

        private void txtNombreLinea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                chkEstatus.Focus();
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void dgvLinea_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dgvLinea.Rows[rowIndex];
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
