using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Catalogos
{
    public partial class frmClientesAutolav : XtraForm
    {
        public int id;
        public int clienteAutomovilId;
        public PuntoVentaContext puntoVentaContext;
        ERPProdEntities oContext;
        private static frmClientesAutolav _instance;

        PaisEstadoCiudadBusiness oPaisEstCiudB;
        ClientesBusiness oClienteB;

        public static frmClientesAutolav GetInstance()
        {

            if (_instance == null) _instance = new frmClientesAutolav();
            else _instance.BringToFront();
            return _instance;
        }

        public frmClientesAutolav()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            oPaisEstCiudB = new PaisEstadoCiudadBusiness();
            
            oClienteB = new ClientesBusiness();
        }

        public void llenarCombosPais()
        {
            try
            {
                uiPais.Properties.DataSource = oPaisEstCiudB.GetPaisesAll();

            }
            catch (Exception  ex)
            {
             
            }
        }

        public void llenarComboTipoCliente()
        {
            try
            {
                uiTipoCliente.Properties.DataSource = oContext.cat_tipos_cliente.ToList();
            }
            catch (Exception ex)
            {

              
            }
        }

        private void uiPais_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int paisId = uiPais.EditValue == null ? 0 : int.Parse(uiPais.EditValue.ToString());
                uiEstado.Properties.DataSource = oPaisEstCiudB.GetEstadosByPais(paisId);
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al obtener los estados", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiMunicipio_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int estadoId = uiEstado.EditValue == null ? 0 : int.Parse(uiEstado.EditValue.ToString());
                uiEstado.Properties.DataSource = oPaisEstCiudB.GetEstadosByPais(estadoId);
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Ocurrió un error al obtener los municipios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frmClientesAutolav_Load(object sender, EventArgs e)
        {
            llenarCombosPais();
            llenarComboTipoCliente();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string error = "";


                cat_clientes cliente = new cat_clientes();
                cat_clientes_automovil clienteAuto = new cat_clientes_automovil();

                cliente.Activo = uiActivo.Checked;
                cliente.AntecedenteId = uiAntecedente.EditValue != null ? int.Parse(uiAntecedente.EditValue.ToString()) : 0;
                cliente.Calle = uiCalle.Text;
                cliente.ClienteEspecial = false;
                cliente.ClienteGral = true;

                cliente.ClienteId = this.id;
                cliente.CodigoPostal = uiCP.Text;
                cliente.Colonia = uiColonia.Text;
                cliente.CreditoDisponible = uiCreditoDisponible.Value;
                cliente.DiasCredito = short.Parse(uiDiasCredito.Value.ToString());
                cliente.EstadoId = uiEstado.EditValue != null ? int.Parse(uiEstado.EditValue.ToString()) : 0;
                cliente.GiroId = null;
                cliente.LimiteCredito = uiLimiteCredito.Value;
                cliente.MunicipioId = uiMunicipio.EditValue != null ? int.Parse(uiMunicipio.EditValue.ToString()) : 0;
                cliente.Nombre = uiNombre.Text;
                cliente.NumeroExt = uiNoExt.Text;
                cliente.NumeroInt = uiNoInt.Text;
                cliente.PaisId = uiPais.EditValue != null ? short.Parse(uiPais.EditValue.ToString()) : (short)0;
                cliente.PrecioId = null;
                cliente.RFC = uiRFC.Text;
                cliente.SaldoGlobal = uiSaldoGlobal.Value;
                cliente.Telefono = uiWhatsapp.Text;
                cliente.TipoClienteId = uiTipoCliente.EditValue != null ? byte.Parse(uiTipoCliente.EditValue.ToString()) : (byte)0;


                cat_clientes_automovil clienteAutomovil = new cat_clientes_automovil();
                clienteAutomovil.ClienteAutoId = this.clienteAutomovilId;
                clienteAutomovil.ClienteId = this.id;
                clienteAutomovil.Color = uiColor.Text;
                clienteAutomovil.Modelo = uiModelo.Text;
                clienteAutomovil.Observaciones = uiObservaciones.Text;

                clienteAutomovil.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                clienteAutomovil.Placas = uiPlacas.Text;




               error = oClienteB.InsertarClienteAutomovil(ref cliente,ref clienteAutomovil);

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
