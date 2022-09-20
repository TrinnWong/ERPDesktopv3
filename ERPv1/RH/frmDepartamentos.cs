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

namespace ERPv1.RH
{
    public partial class frmDepartamentos : Form
    {
        Resultado resultado;
        DepartamentosInterface dI;
        ERPProdEntities model;

        public frmDepartamentos()
        {
            InitializeComponent();
            dI = new DepartamentosInterface();
            model = new ERPProdEntities();
        }

        #region Metodos

        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();

            dgvDepartamento.DataSource = dI.ConsultarListado(busqueda);
            dgvDepartamento.Refresh();
        }

        private void LimpiarControles()
        {
            nClave.Enabled = true;
            nClave.Value = 0;
            txtNombreDepartamento.Text = "";
            chkEstatus.Checked = true;
        }

        private Resultado ValidarAgregar(int clave, string nomDepto)
        {
            resultado = new Resultado();
            if (clave <= 0)
            {
                resultado.mensaje += "La clave debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            else
            {
                DataTable dt = dI.ConsultarRegistro(clave, false);
                if (clave > 0 && dt != null && dt.Rows.Count > 0)
                {
                    resultado.mensaje += "La clave " + clave + " ya existe. \n";
                    resultado.ok = false;
                }
            }
            if (nomDepto == "")
            {
                resultado.mensaje += "Capture el nombre del Departamento.";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEditar(int clave, string nomDepto)
        {
            resultado = new Resultado();
            DataTable dt = dI.ConsultarRegistro(clave, false);
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
            if (nomDepto == "")
            {
                resultado.mensaje += "Capture el nombre del Departamento.";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEliminar(int clave)
        {
            resultado = new Resultado();
            DataTable dt = dI.ConsultarRegistro(clave, false);

            if (
                model.rh_empleados.Where(w => w.Departamento == clave).Count() > 0
                )
            {
                resultado.mensaje += "No es posible eliminar el departamento ya que está asignado a un empleado \n";
                resultado.ok = false;
            }

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
            string nomDepto = txtNombreDepartamento.Text.Trim();
            bool estatus = chkEstatus.Checked ? true : false;
            int? empresa = null;
            int? sucursal = null;
            if (!ValidarAgregar(clave, nomDepto).ok)
            {
                MessageBox.Show(resultado.mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = dI.Agregar(clave, nomDepto, estatus, empresa, sucursal);
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
            string nomDepto = txtNombreDepartamento.Text.Trim();
            bool estatus = chkEstatus.Checked ? true : false;
            if (!ValidarEditar(clave, nomDepto).ok)
            {
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = dI.Actualizar(clave, nomDepto, estatus);
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
                resultado = dI.Eliminar(clave);
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
            DataTable dt = dI.ConsultarRegistro(clave, false);
            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                nClave.Enabled = false;
                nClave.Value = clave;
                txtNombreDepartamento.Text = dt.Rows[0]["Descripcion"].ToString(); ;
                chkEstatus.Checked = bool.Parse(dt.Rows[0]["Estatus"].ToString()); ;
            }
            return dt == null ? 0 : (dt.Rows == null ? 0 : dt.Rows.Count);
        }

        #endregion

        #region Eventos

        private void frmDepartamentos_Load(object sender, EventArgs e)
        {
            dgvDepartamento.DefaultCellStyle.ForeColor = Color.Black;
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
                    txtNombreDepartamento.Focus();
                }
            }
        }

        private void txtNombreDepartamento_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Buscar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvDepartamento_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dgvDepartamento.Rows[rowIndex];
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
    }
}
