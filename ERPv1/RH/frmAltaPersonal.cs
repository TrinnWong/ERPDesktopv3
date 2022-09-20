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
using System.IO;
using System.Drawing.Imaging;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Common.Base;

namespace ERPv1.RH
{
    public partial class frmAltaPersonal : FormBaseWinForm
    {
        Resultado resultado;
        AltaPersonalInterface apI;
        PuestosInterface pI;
        DepartamentosInterface dI;
        TipoContratoInterface tcI;
        FormaPagoNominaInterface fpnI;
        EmpleadossBusiness oEmpleado;
       
        

        public frmAltaPersonal()
        {
            InitializeComponent();
            apI = new AltaPersonalInterface();
            pI = new PuestosInterface();
            dI = new DepartamentosInterface();
            tcI = new TipoContratoInterface();
            fpnI = new FormaPagoNominaInterface();
            oEmpleado = new EmpleadossBusiness();
            oContext = new ERPProdEntities();

           
        }
        
        #region Metodos

        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();
            dtFechaIngreso.Value = DateTime.Today;
            dgvAltaPersonal.DataSource = apI.ConsultarListado(busqueda);
            dgvAltaPersonal.Refresh();
        }

        private void LimpiarControles()
        {
            nClave.Enabled = true;
            nClave.Value = 0;
            txtNomPersonal.Text = "";
            cmbPuesto.SelectedValue = 0;
            cmbDepartamento.SelectedValue = 0;
            cmbFormaPago.SelectedValue = 0;
            cmbTipoContrato.SelectedValue = 0;
            dtFechaIngreso.Value = DateTime.Today;
            dtInicioLabores.Value = DateTime.Today;
            nudSueldoNeto.Value = 0;
            nudSueldoDiario.Value = 0;
            nudSueldoHora.Value = 0;
            pbFoto.Image = null;
            chkEstatus.Checked = true;

            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private Resultado ValidarAgregar(int clave, string nomPersonal, int cmbPuesto, int cmbDepartamento, int cmbTipoContrato, decimal sueldoNeto)
        {
            resultado = new Resultado();
            if (clave <= 0)
            {
                resultado.mensaje += "La clave debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            else
            {
                DataTable dt = apI.ConsultarRegistro(clave, false);
                if (clave > 0 && dt != null && dt.Rows.Count > 0)
                {
                    resultado.mensaje += "La clave " + clave + " ya existe. \n";
                    resultado.ok = false;
                }
            }
            if (nomPersonal == "")
            {
                resultado.mensaje += "Capture el nombre de la Persona. \n";
                resultado.ok = false;
            }
            //if (cmbPuesto == null || cmbPuesto == 0)
            //{
            //    resultado.mensaje += "Selecione el Puesto de la Persona. \n";
            //    resultado.ok = false;
            //}
            //if (cmbDepartamento == null || cmbDepartamento == 0)
            //{
            //    resultado.mensaje += "Selecione el Departamento de la Persona. \n";
            //    resultado.ok = false;
            //}
            //if (cmbTipoContrato == null || cmbTipoContrato == 0)
            //{
            //    resultado.mensaje += "Selecione el Tipo de Contrato de la Persona. \n";
            //    resultado.ok = false;
            //}
            //if (sueldoNeto <= 0)
            //{
            //    resultado.mensaje += "El Sueldo Neto debe ser mayor a cero.";
            //    resultado.ok = false;
            //}

            return resultado;
        }

        private Resultado ValidarEditar(int clave, string nomDepto, int cmbPuesto, int cmbDepartamento, int cmbTipoContrato, decimal sueldoNeto)
        {
            resultado = new Resultado();
            DataTable dt = apI.ConsultarRegistro(clave, false);
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
                resultado.mensaje += "Capture el nombre del Departamento. \n";
                resultado.ok = false;
            }
            //if (cmbPuesto == null || cmbPuesto == 0)
            //{
            //    resultado.mensaje += "Selecione el Puesto de la Persona. \n";
            //    resultado.ok = false;
            //}
            //if (cmbDepartamento == null || cmbDepartamento == 0)
            //{
            //    resultado.mensaje += "Selecione el Departamento de la Persona. \n";
            //    resultado.ok = false;
            //}
            //if (cmbTipoContrato == null || cmbTipoContrato == 0)
            //{
            //    resultado.mensaje += "Selecione el Tipo de Contrato de la Persona. \n";
            //    resultado.ok = false;
            //}
            //if (sueldoNeto <= 0)
            //{
            //    resultado.mensaje += "El Sueldo Neto debe ser mayor a cero.";
            //    resultado.ok = false;
            //}
            return resultado;
        }

        private Resultado ValidarEliminar(int clave)
        {
            resultado = new Resultado();
            DataTable dt = apI.ConsultarRegistro(clave, false);
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
            string nomPersonal = txtNomPersonal.Text.Trim();
            decimal sueldoNeto = nudSueldoNeto.Value;
            decimal sueldoDiario = nudSueldoDiario.Value;
            decimal sueldoHora = nudSueldoHora.Value;
            DateTime fechaIngreso = dtFechaIngreso.Value;
            DateTime fechaInicio = dtInicioLabores.Value;
            int puesto = 0;
            if (cmbPuesto != null && cmbPuesto.SelectedItem != null)
                puesto = int.Parse(((ComboBoxItem)cmbPuesto.SelectedItem).valor.ToString());
            int departamento = 0;
            if (cmbDepartamento != null && cmbDepartamento.SelectedItem != null)
                departamento = int.Parse(((ComboBoxItem)cmbDepartamento.SelectedItem).valor.ToString());
            int formaPago = 0;
            if (cmbFormaPago != null && cmbFormaPago.SelectedItem != null)
                formaPago = int.Parse(((ComboBoxItem)cmbFormaPago.SelectedItem).valor.ToString());
            int tipoContrato = 0;
            if (cmbTipoContrato != null && cmbTipoContrato.SelectedItem != null)
                tipoContrato = int.Parse(((ComboBoxItem)cmbTipoContrato.SelectedItem).valor.ToString());
            bool estatus = chkEstatus.Checked ? true : false;
            int? empresa = null;
            int? sucursal = null;

            if (!ValidarAgregar(clave, nomPersonal, puesto, departamento, tipoContrato, sueldoNeto).ok)
            {
                MessageBox.Show(resultado.mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (pbFoto.Image == null)
            {
                byte[] foto = null;                
                resultado = apI.Agregar(clave, nomPersonal, sueldoNeto, sueldoDiario, sueldoHora, formaPago, tipoContrato, puesto, departamento, fechaIngreso, fechaInicio, foto, estatus, empresa, sucursal);
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (resultado.ok)
                {
                    LimpiarControles();
                    Buscar();
                }
            }
            else
            {
                MemoryStream stream = new MemoryStream();
                pbFoto.Image.Save(stream, ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();

                resultado = apI.Agregar(clave, nomPersonal, sueldoNeto, sueldoDiario, sueldoHora, formaPago, tipoContrato, puesto, departamento, fechaIngreso, fechaInicio, pic, estatus, empresa, sucursal);
                //resultado = apI.spAltaPersonalUpd(clave, nomPersonal, sueldoNeto, sueldoDiario, sueldoHora, formaPago, tipoContrato, puesto, departamento, fechaIngreso, fechaInicio, img_arr1, estatus);
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (resultado.ok)
                {
                    LimpiarControles();
                    Buscar();
                }
            }            
        }

        private void Editar()
        {
            resultado = new Resultado();
            int clave = (int)nClave.Value;
            string nomPersonal = txtNomPersonal.Text.Trim();
            decimal sueldoNeto = nudSueldoNeto.Value;
            decimal sueldoDiario = nudSueldoDiario.Value;
            decimal sueldoHora = nudSueldoHora.Value;
            DateTime fechaIngreso = dtFechaIngreso.Value;
            DateTime fechaInicio = dtInicioLabores.Value;
            int puesto = 0;
            if (cmbPuesto != null && cmbPuesto.SelectedItem != null)
                puesto = int.Parse(((ComboBoxItem)cmbPuesto.SelectedItem).valor.ToString());
            int departamento = 0;
            if (cmbDepartamento != null && cmbDepartamento.SelectedItem != null)
                departamento = int.Parse(((ComboBoxItem)cmbDepartamento.SelectedItem).valor.ToString());
            int formaPago = 0;
            if (cmbFormaPago != null && cmbFormaPago.SelectedItem != null)
                formaPago = int.Parse(((ComboBoxItem)cmbFormaPago.SelectedItem).valor.ToString());
            int tipoContrato = 0;
            if (cmbTipoContrato != null && cmbTipoContrato.SelectedItem != null)
                tipoContrato = int.Parse(((ComboBoxItem)cmbTipoContrato.SelectedItem).valor.ToString());
            bool estatus = chkEstatus.Checked ? true : false;
            
            if (!ValidarEditar(clave, nomPersonal, puesto, departamento, tipoContrato, sueldoNeto).ok)
            {
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (pbFoto.Image == null)
            {
                byte[] foto = null; 
                resultado = apI.Actualizar(clave, nomPersonal, sueldoNeto, sueldoDiario, sueldoHora, formaPago, tipoContrato, puesto, departamento, fechaIngreso, fechaInicio   , foto, estatus);
                //resultado = apI.spAltaPersonalUpd(clave, nomPersonal, sueldoNeto, sueldoDiario, sueldoHora, formaPago, tipoContrato, puesto, departamento, fechaIngreso, fechaInicio, foto, estatus);
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (resultado.ok)
                {
                    
                    LimpiarControles();
                    Buscar();
                }
            }
            else
            {
                MemoryStream stream = new MemoryStream();
                pbFoto.Image.Save(stream, ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();

                //resultado = apI.spAltaPersonalUpd(clave, nomPersonal, sueldoNeto, sueldoDiario, sueldoHora, formaPago, tipoContrato, puesto, departamento, fechaIngreso, fechaInicio, img_arr1, estatus);
                resultado = apI.Actualizar(clave, nomPersonal, sueldoNeto, sueldoDiario, sueldoHora, formaPago, tipoContrato, puesto, departamento, fechaIngreso, fechaInicio, pic, estatus);
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (resultado.ok)
                {
                    LimpiarControles();
                    Buscar();
                }
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
                resultado = apI.Eliminar(clave);
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
            DataTable dt = apI.ConsultarRegistro(clave, false);
            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                nClave.Enabled = false;
                nClave.Value = clave;
                txtNomPersonal.Text = dt.Rows[0]["Nombre"].ToString();
                nudSueldoNeto.Value = decimal.Parse(dt.Rows[0]["SueldoNeto"].ToString());
                nudSueldoDiario.Value = decimal.Parse(dt.Rows[0]["SueldoDiario"].ToString());
                nudSueldoHora.Value = decimal.Parse(dt.Rows[0]["SueldoHra"].ToString());
                dtFechaIngreso.Value = DateTime.Parse(dt.Rows[0]["FechaIngreso"].ToString());
                dtInicioLabores.Value = DateTime.Parse(dt.Rows[0]["FechaInicioLab"].ToString());
                chkEstatus.Checked = int.Parse(dt.Rows[0]["Estatus"].ToString()) == 1 ? true:false;
                pbFoto.Image = null;
                if (dt.Rows[0]["Foto"] != DBNull.Value)
                {
                    using (var ms = new MemoryStream((byte[])dt.Rows[0]["Foto"]))
                    {
                        pbFoto.Image = Image.FromStream(ms);
                    }
                }
                int puestoId = int.Parse(dt.Rows[0]["Puesto"] == DBNull.Value ? "0" : dt.Rows[0]["Puesto"].ToString());
                int departamentoId = int.Parse(dt.Rows[0]["Departamento"] == DBNull.Value ? "0" : dt.Rows[0]["Departamento"].ToString());
                int formaPagoId = dt.Rows[0]["FormaPago"] != System.DBNull.Value ? int.Parse(dt.Rows[0]["FormaPago"].ToString()) : 0;
                int tipoContratoId = dt.Rows[0]["TipoContrato"] != DBNull.Value ? int.Parse(dt.Rows[0]["TipoContrato"].ToString()) : 0;
                SeleccionarRegistroCombo(ref cmbFormaPago, formaPagoId);
                SeleccionarRegistroCombo(ref cmbTipoContrato, tipoContratoId);
                SeleccionarRegistroCombo(ref cmbPuesto, puestoId);
                SeleccionarRegistroCombo(ref cmbDepartamento, departamentoId);
                CalcularSueldos();
                llenarGridPuestos();

                Byte[] data = new Byte[0];
                data = (Byte[])(dt.Rows[0]["Foto"]);
                MemoryStream mem = new MemoryStream(data);
                pbFoto.Image = Image.FromStream(mem);

                //uiGridPuestos.DataSource = oEmpleado.GetPuestos(clave);
            }
            return dt == null ? 0 : (dt.Rows == null ? 0 : dt.Rows.Count);
        }

        private void SeleccionarRegistroCombo(ref System.Windows.Forms.ComboBox cmb, int id)
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

        public List<ComboBoxItem> CargarComboBox(ref System.Windows.Forms.ComboBox comboBox, bool filtroTodos, string clave, string descripcion, DataTable dt)
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

        private void llenarComboPuestos()
        {
            int sucursalId = puntoVentaContext.sucursalId;
            repLkpPuestos.DataSource = oContext.rh_puestos
                .Where(w=> w.Sucursal == sucursalId)
                .ToList();

            uiPuesto.Properties.DataSource = oContext.rh_puestos
                .Where(w => w.Sucursal == sucursalId)
                .ToList();

        }

        private void llenarGridPuestos()
        {
            int empleadoId = int.Parse(nClave.Value.ToString());
            uiGridPuestos.DataSource = oEmpleado.GetPuestos(empleadoId);
        }

        private void SeleccionarFoto()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "images| *.JPG; *.PNG; *.GJF"; // you can add any other image type 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbFoto.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void EliminarFoto()
        {
            pbFoto.Image = null; 
        }

        private void CalcularSueldos()
        {
            decimal sueldoNeto = nudSueldoNeto.Value, sueldoDíario = 0, sueldoHora = 0;
            int formaPago = 0;
            if (cmbFormaPago != null && cmbFormaPago.SelectedItem != null)
                formaPago = int.Parse(((ComboBoxItem)cmbFormaPago.SelectedItem).valor.ToString());            

            if (formaPago > 0 && sueldoNeto > 0)
            {                
                DataTable dt = fpnI.ConsultarRegistro(formaPago, false);
                if(dt != null && dt.Rows.Count > 0)
                {
                    int numeroDias = int.Parse(dt.Rows[0]["NumDias"].ToString());
                    int horasDia = int.Parse(dt.Rows[0]["HrasDia"].ToString());

                    sueldoDíario = sueldoNeto / numeroDias;
                    sueldoHora = sueldoDíario / horasDia;
                }
            }
            nudSueldoDiario.Value = sueldoDíario;
            nudSueldoHora.Value = sueldoHora;
        }

        #endregion

        private void frmAltaPersonal_Load(object sender, EventArgs e)
        {
            ValidarAcceso(frmMenu.GetInstance().puntoVentaContext.usuarioId,
                frmMenu.GetInstance().puntoVentaContext.sucursalId, "frmAltaPersonal");

            dgvAltaPersonal.DefaultCellStyle.ForeColor = Color.Black;
            CargarComboBox(ref cmbPuesto, false, "Clave", "Descripcion", pI.ConsultaComboBox());
            CargarComboBox(ref cmbDepartamento, false, "Clave", "Descripcion", dI.ConsultaComboBox());
            CargarComboBox(ref cmbFormaPago, false, "Clave", "Descripcion", fpnI.ConsultaComboBox());
            CargarComboBox(ref cmbTipoContrato, false, "Clave", "Descripcion", tcI.ConsultaComboBox());
            Buscar();

            LimpiarControles();

            llenarComboPuestos();
            LimpiarControles();
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
                    chkEstatus.Focus();
                }
            }            
        }

        private void pbFoto_Click(object sender, EventArgs e)
        {
            SeleccionarFoto();
        }

        private void lblCambiarFoto_Click(object sender, EventArgs e)
        {
            SeleccionarFoto();
        }

        private void lblEliminarFoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EliminarFoto();
        }

        private void chkEstatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtNomPersonal.Focus();
            }
        }

        private void txtNomPersonal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cmbPuesto.Focus();
            }
        }

        private void cmbPuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cmbDepartamento.Focus();
            }
        }

        private void cmbDepartamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                dtFechaIngreso.Focus();
            }
        }

        private void dtFechaIngreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                dtInicioLabores.Focus();
            }
        }

        private void dtInicioLabores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {                
                tcDatos.SelectedTab = tcDatos.TabPages[1];
                tcDatos.TabPages[1].Focus();
                cmbFormaPago.Focus();
            }
        }

        private void cmbFormaPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cmbTipoContrato.Focus();
            }
        }

        private void cmbTipoContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                nudSueldoNeto.Focus();
            }
        }

        private void nudSueldoNeto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                nudSueldoDiario.Focus();
            }
        }

        private void nudSueldoNeto_Leave(object sender, EventArgs e)
        {
            CalcularSueldos();
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
        
        private void cmbFormaPago_Leave(object sender, EventArgs e)
        {
            CalcularSueldos();
        }
        
        private void dgvAltaPersonal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dgvAltaPersonal.Rows[rowIndex];
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

            btnAgregar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void uiGridViewPuestos_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            

           
        }

        private void uiAgregarPuesto_Click(object sender, EventArgs e)
        {
            int empleadoId = 0;
            int puestoid = 0;
            try
            {
                int.TryParse(nClave.Value.ToString(), out empleadoId);

                int.TryParse(uiPuesto.EditValue.ToString(), out puestoid);

                if(
                    oContext.rh_empleado_puestos
                    .Where(w=> w.EmpleadoId == empleadoId &&
                    w.PuestoId == puestoid).Count() > 0
                    )
                {
                    XtraMessageBox.Show("Ya existe el puesto para el empleado", "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Asterisk);

                    return;
                }


                if (empleadoId > 0 && puestoid>0)
                {
                    rh_empleado_puestos item = new rh_empleado_puestos();

                    item.PuestoId = int.Parse(uiPuesto.EditValue.ToString());
                    item.EmpleadoId = empleadoId;
                    item.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                    item.CreadoPor = puntoVentaContext.usuarioId;
                   


                    oContext.rh_empleado_puestos.Add(item);
                    oContext.SaveChanges();

                    llenarGridPuestos();

                    XtraMessageBox.Show("El puesto se guardó con éxito", "OK",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);

                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurripo un error al asignar el puesto", "Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Asterisk);
            }
        }

        private void repBtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int empleadoId = 0;

            try
            {
                int.TryParse(nClave.Value.ToString(), out empleadoId);


                if (empleadoId > 0)
                {
                    if(
                        XtraMessageBox.Show("¿Está seguro de eliminar el puesto?",
                        "Aviso",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Asterisk) == DialogResult.Yes
                        )   
                    {
                        rh_empleado_puestos item = (rh_empleado_puestos)uiGridViewPuestos.GetRow(uiGridViewPuestos.FocusedRowHandle);

                        item.EmpleadoId = empleadoId;
                        item.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                        item.CreadoPor = puntoVentaContext.usuarioId;

                        int puestoid = item.PuestoId;

                        rh_empleado_puestos del = oContext.rh_empleado_puestos.Where(w => w.EmpleadoId == empleadoId && w.PuestoId == puestoid).FirstOrDefault();

                        oContext.rh_empleado_puestos.Remove(del);
                        oContext.SaveChanges();

                        llenarGridPuestos();

                        XtraMessageBox.Show("El proceso terminó con éxito", "OK",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                    }

                    

                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurripo un error al asignar el puesto", "Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Asterisk);
            }
        }
    }
}
