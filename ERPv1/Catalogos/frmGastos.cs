using ConexionBD;
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

namespace ERPv1.Catalogos
{
    public partial class frmGastos : Form
    {
        Resultado resultado;
        GastosInterface gI;
        CentroCostosInterface ccI;
        ERPProdEntities model;
        public frmGastos()
        {
            model = new ERPProdEntities();
            InitializeComponent();
            gI = new GastosInterface();
            ccI = new CentroCostosInterface();
           
        }

        #region Metodos

        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();

            dgvGasto.DataSource = gI.ConsultarListado(busqueda);
            dgvGasto.Refresh();
        }

        private void LimpiarControles()
        {
            nClave.Enabled = true;
            nClave.Value = 0;
            txtNombreGasto.Text = "";
            cmbCentroCosto.SelectedIndex = 0;
        }

        private Resultado ValidarAgregar(int clave, string nomGasto, int cmbCentroCosto)
        {
            resultado = new Resultado();
            if (clave <= 0)
            {
                resultado.mensaje += "La clave debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            else
            {
                DataTable dt = gI.ConsultarRegistro(clave, false);
                if (clave > 0 && dt != null && dt.Rows.Count > 0)
                {
                    resultado.mensaje += "La clave " + clave + " ya existe. \n";
                    resultado.ok = false;
                }
            }
            if (nomGasto == "")
            {
                resultado.mensaje += "Capture el nombre del Gatso. \n";
                resultado.ok = false;
            }
            if (cmbCentroCosto == null || cmbCentroCosto == 0)
            {
                resultado.mensaje += "Selecione el Centro de Costo.";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEditar(int clave, string nomGasto, int cmbCentroCosto)
        {
            resultado = new Resultado();
            DataTable dt = gI.ConsultarRegistro(clave, false);
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
            if (nomGasto == "")
            {
                resultado.mensaje += "Capture el nombre del Gatso. \n";
                resultado.ok = false;
            }
            if (cmbCentroCosto == null || cmbCentroCosto == 0)
            {
                resultado.mensaje += "Selecione el Centro de Costo.";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEliminar(int clave)
        {
            resultado = new Resultado();
            DataTable dt = gI.ConsultarRegistro(clave, false);
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
            string nomGasto = txtNombreGasto.Text.Trim();
            int gasto = 0;
            if (cmbCentroCosto != null && cmbCentroCosto.SelectedItem != null)
                gasto =  int.Parse(((cat_centro_costos)cmbCentroCosto.SelectedItem).Clave.ToString());
            bool estatus = chkEstatus.Checked ? true : false;
            int? empresa = null;
            int? sucursal = null;
            if (!ValidarAgregar(clave, nomGasto, gasto).ok)
            {
                MessageBox.Show(resultado.mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = gI.Agregar(clave, nomGasto, gasto, estatus, empresa, sucursal);
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
            string nomGasto = txtNombreGasto.Text.Trim();
            int gasto = 0;
            if (cmbCentroCosto != null && cmbCentroCosto.SelectedItem != null)
                gasto = int.Parse(((cat_centro_costos)cmbCentroCosto.SelectedItem).Clave.ToString());
            bool estatus = chkEstatus.Checked ? true : false;
            if (!ValidarEditar(clave, nomGasto, gasto).ok)
            {
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = gI.Actualizar(clave, nomGasto, gasto, estatus);
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
                resultado = gI.Eliminar(clave);
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
            DataTable dt = gI.ConsultarRegistro(clave, false);
            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                int centroCosto = int.Parse(dt.Rows[0]["ClaveCentroCosto"].ToString());
                nClave.Enabled = false;
                nClave.Value = clave;
                txtNombreGasto.Text = dt.Rows[0]["Descripcion"].ToString();
                this.cmbCentroCosto.SelectedValue = centroCosto;            
            }
            return dt == null ? 0 : (dt.Rows == null ? 0 : dt.Rows.Count);
        }

        public List<ComboBoxItem> CargarComboBox(ref ComboBox comboBox, bool filtroTodos, string clave, string descripcion, DataTable dt)
        {
            List<ComboBoxItem> lista = new List<ComboBoxItem>();
            string textoInicial = filtroTodos ? "(TODOS)" : "(SELECCIONAR)";
            ComboBoxItem cmb = new ComboBoxItem();
            cmb.texo = "(SELECCIONAR)";
            cmb.valor = 0;
            comboBox.Items.Add(cmb);

            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        cmb = new ComboBoxItem();
                        cmb.valor = int.Parse(item[clave].ToString());
                        cmb.texo = item[descripcion].ToString();
                        comboBox.Items.Add(cmb);
                    }
                }
                catch { }
            }
            comboBox.SelectedIndex = 0;
            comboBox.DisplayMember = "texo";
            comboBox.ValueMember = "valor";
            return lista;
        }

        private void SeleccionarRegistroCombo(ref ComboBox cmb, int id)
        {
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                var prop = cmb.Items[i].GetType().GetProperty(cmb.ValueMember);
                if (prop != null && prop.GetValue(cmb.Items[i], null).ToString() == id.ToString())
                {
                    cmb.SelectedIndex = i;
                    break;
                }
            }
        }

        #endregion

        private void frmGastos_Load(object sender, EventArgs e)
        {
            dgvGasto.DefaultCellStyle.ForeColor = Color.Black;
            //CargarComboBox(ref cmbCentroCosto, false, "Clave", "Descripcion", gI.ConsultaComboBox());

            List<cat_centro_costos> ds = model.cat_centro_costos.ToList();

            ds.Add(new cat_centro_costos() {
                Clave = 0,
                Descripcion = "(Seleccionar)"
            });

            cmbCentroCosto.DataSource = ds.OrderBy(O=> O.Clave).ToList();

            
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
                    txtNombreGasto.Focus();
                }
            }
        }

        private void txtNombreGasto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                chkEstatus.Focus();
            }
        }

        private void chkEstatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cmbCentroCosto.Focus();
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

        private void dgvGasto_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dgvGasto.Rows[rowIndex];
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
                catch (Exception ex) { }
            }
        }
    }
}
