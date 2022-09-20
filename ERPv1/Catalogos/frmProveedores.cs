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
    public partial class frmProveedores : Form
    {
        bool isLoad = false;
        ConexionBD.Proveedores oData;
        ERPProdEntities oContext;
        public frmProveedores()
        {
            InitializeComponent();

            oData = new ConexionBD.Proveedores();
            oContext = new ERPProdEntities();

            Buscar();
            LlenarCombos();


        }


        private void LlenarCombos()
        {
            uiPais.DataSource = oContext.cat_paises                                
                .ToList();
            uiPais.SelectedValue = 0;

            uiTipoProveedor.DataSource = oContext.cat_tipos_proveedor.ToList();
            uiTipoProveedor.SelectedValue = 0;

            //uiAntecedente.DataSource = oContext.cat_antecedentes.ToList();
            //uiAntecedente.SelectedValue = 0;

            //uiListaPrecios.DataSource = oContext.cat_precios.ToList();
            //uiListaPrecios.SelectedValue = 0;
            //uiListaPrecios.Enabled = false;

            uiGiro.DataSource = oContext.cat_giros_neg.ToList();
            uiGiro.SelectedValue = 0;
        }
        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();

            dgvGrid.DataSource = oData.oContext.cat_proveedores.Where(
                w => w.Nombre.Contains(busqueda)                
                ||
                busqueda == ""
                ).Select(
                    S=> new {
                        Clave = S.ProveedorId,
                        Nombre = S.Nombre,
                        RFC = S.RFC,
                        Activo = S.Activo
                    }
                ).ToList();
            dgvGrid.Refresh();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                cat_proveedores entity = new cat_proveedores();

                entity.ProveedorId = (int)this.uiClave.Value;
                entity.Activo = uiActivo.Checked;
                //entity.AntecedenteId = uiAntecedente.SelectedValue!= null ? (int?)uiAntecedente.SelectedValue : null;
                entity.Calle = uiCalle.Text;
               // entity.ClienteEspecial = uiClienteEspecial.Checked;
               // entity.ClienteGral = uiClienteGral.Checked;
                entity.CodigoPostal = uiCP.Text;
                entity.Colonia = uiColonia.Text;
                entity.CreditoDisponible = (decimal)uiCreditoDisponible.Value;
                entity.DiasCredito = (short)uiDiasCred.Value;
                entity.EstadoId =uiEstado.SelectedValue != null ? (int?)uiEstado.SelectedValue : null;
                entity.GiroId = uiGiro.SelectedValue != null ? (int?)uiGiro.SelectedValue : null;
                entity.LimiteCredito = (decimal)uiLimiteCred.Value;
                entity.MunicipioId = uiMunicipio.SelectedValue != null ? (int?)uiMunicipio.SelectedValue:null;
                entity.Nombre = uiNombre.Text;
                entity.NumeroExt = uiNumExt.Text;
                entity.NumeroInt = uiNumInt.Text;
                entity.PaisId = uiPais.SelectedValue!= null ? (short?)uiPais.SelectedValue : null;
               // entity.PrecioId = uiListaPrecios.SelectedValue != null ? (byte?)uiListaPrecios.SelectedValue : null;
                entity.RFC = uiRFC.Text;
                entity.SaldoGlobal = uiSaldoGlobal.Value;
                entity.Telefono = uiTelefono.Text;
                entity.Telefono2 = uiTelefono2.Text;
                entity.TipoProveedorId = uiTipoProveedor.SelectedValue != null ? (byte?)uiTipoProveedor.SelectedValue : null;                

             
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

        private void Limpiar()
        {

            this.uiActivo.Checked = false;
           // this.uiAntecedente.SelectedValue = 0;
            this.uiCalle.Text = "";
            this.uiClave.Value = 0;
            //this.uiClienteEspecial.Checked = false;
            //this.uiClienteGral.Checked = false;
            this.uiColonia.Text = "";
            this.uiCP.Text = "";
            this.uiCreditoDisponible.Value = 0;
            this.uiDiasCred.Value = 0;
            this.uiEstado.SelectedValue = 0;
            this.uiGiro.SelectedValue = 0;
            this.uiLimiteCred.Value = 0;
            //this.uiListaPrecios.SelectedValue = 0;
            this.uiMunicipio.Text = "";
            this.uiNombre.Text = "";
            this.uiNumExt.Text = "";
            this.uiNumInt.Text = "";
            this.uiPais.SelectedValue = 0;
            this.uiRFC.Text = "";
            this.uiSaldoGlobal.Value = 0;
            this.uiTelefono.Text = "";
            this.uiTelefono2.Text = "";
            this.uiTipoProveedor.SelectedValue = 0;
            //uiListaPrecios.Enabled = false;

            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                cat_proveedores entity = new cat_proveedores();

                entity.ProveedorId = (int)this.uiClave.Value;
                entity.Activo = uiActivo.Checked;
               // entity.AntecedenteId = uiAntecedente.SelectedValue != null ? (int?)uiAntecedente.SelectedValue : null;
                entity.Calle = uiCalle.Text;
                //entity.ClienteEspecial = uiClienteEspecial.Checked;
               // entity.ClienteGral = uiClienteGral.Checked;
                entity.CodigoPostal = uiCP.Text;
                entity.Colonia = uiColonia.Text;
                entity.CreditoDisponible = (decimal)uiCreditoDisponible.Value;
                entity.DiasCredito = (short)uiDiasCred.Value;
                entity.EstadoId = uiEstado.SelectedValue != null ? (int?)uiEstado.SelectedValue : null;
                entity.GiroId = uiGiro.SelectedValue != null ? (int?)uiGiro.SelectedValue : null;
                entity.LimiteCredito = (decimal)uiLimiteCred.Value;
                entity.MunicipioId = uiMunicipio.SelectedValue != null ? (int?)uiMunicipio.SelectedValue : null;
                entity.Nombre = uiNombre.Text;
                entity.NumeroExt = uiNumExt.Text;
                entity.NumeroInt = uiNumInt.Text;
                entity.PaisId = uiPais.SelectedValue != null ? (short?)uiPais.SelectedValue : null;
                //entity.PrecioId = uiListaPrecios.SelectedValue != null ? (byte?)uiListaPrecios.SelectedValue : null;
                entity.RFC = uiRFC.Text;
                entity.SaldoGlobal = uiSaldoGlobal.Value;
                entity.Telefono = uiTelefono.Text;
                entity.Telefono2 = uiTelefono2.Text;
                entity.TipoProveedorId = uiTipoProveedor.SelectedValue != null ? (byte?)uiTipoProveedor.SelectedValue : null;

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

        private void dgvGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void BuscarRegistro(int clave)
        {
            oContext = new ERPProdEntities();
            cat_proveedores entity = oData.oContext.cat_proveedores
                .Where(w => w.ProveedorId == clave).FirstOrDefault();

            this.uiActivo.Checked = entity.Activo??false;
           // this.uiAntecedente.SelectedValue = entity.AntecedenteId??0;
            this.uiCalle.Text = entity.Calle;
            this.uiClave.Value = entity.ProveedorId;
            //this.uiClienteEspecial.Checked = entity.ClienteEspecial??false;
           // this.uiClienteGral.Checked = entity.ClienteGral ??false;
            this.uiColonia.Text = entity.Colonia;
            this.uiCP.Text = entity.CodigoPostal;
            this.uiCreditoDisponible.Value = entity.CreditoDisponible??0;
            this.uiDiasCred.Value = entity.DiasCredito ?? 0;
           
            this.uiGiro.SelectedValue = entity.GiroId ?? 0;
            this.uiLimiteCred.Value = entity.LimiteCredito ?? 0;
           // this.uiListaPrecios.SelectedValue = entity.PrecioId ?? 0;
            
            this.uiNombre.Text = entity.Nombre;
            this.uiNumExt.Text = entity.NumeroExt;
            this.uiNumInt.Text = entity.NumeroInt;
            this.uiPais.SelectedValue = entity.PaisId ?? 0;
            this.uiEstado.SelectedValue = entity.EstadoId ?? 0;
            this.uiMunicipio.SelectedValue = entity.MunicipioId ?? 0;
            this.uiRFC.Text = entity.RFC;
            this.uiSaldoGlobal.Value = entity.SaldoGlobal ??0;
            this.uiTelefono.Text = entity.Telefono;
            this.uiTelefono2.Text = entity.Telefono2;
            this.uiTipoProveedor.SelectedValue = entity.TipoProveedorId ?? 0;

            btnAgregar.Enabled = false;
            btnEliminar.Enabled = true;
            btnEditar.Enabled = true;
            


        }

        private void uiPais_SelectedValueChanged(object sender, EventArgs e)
        {
            if(isLoad)
            { 
            int paisId = uiPais.SelectedValue != null ? int.Parse(uiPais.SelectedValue.ToString()) : 0;

            uiEstado.DataSource = oContext.cat_estados.Where(w => w.PaisId == paisId).ToList();
            }
        }

        private void uiEstado_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isLoad)
            {
                int estadoId = uiEstado.SelectedValue != null ? int.Parse(uiEstado.SelectedValue.ToString()) : 0;
                uiMunicipio.DataSource = oContext.cat_municipios.Where(w => w.EstadoId == estadoId).ToList();
            }
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
                catch(Exception ex) {
                    MessageBox.Show(ex.Message, "ERROR");

                }
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            isLoad = true;
        }

    
    }
}
