using ConexionBD;
using ConexionBD.Models;
using ERP.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace ERPv1.Catalogos
{
    public partial class frmConfigurador : FormBaseXtraForm
    {
        private static frmConfigurador _instance;

        public static frmConfigurador GetInstance()
        {
            if (_instance == null) _instance = new frmConfigurador();
            else _instance.BringToFront();
            return _instance;
        }
        public frmConfigurador()
        {
            InitializeComponent();            
            oContext = new ERPProdEntities();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void uiSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LlenarForma()
        {
            try
            {
                int empresaId = this.puntoVentaContext.empresaId;
                oContext = new ERPProdEntities();

                cat_configuracion entity = oContext.cat_configuracion.Where(w => w.ConfiguradorId == 1).FirstOrDefault();

                cat_configuracion_restaurante entityRestaurante = oContext.cat_configuracion_restaurante.Where(w => w.Id == 1).FirstOrDefault();

                cat_empresas_config_inventario configInve = oContext.cat_empresas_config_inventario
                    .Where(w => w.EmpresaId == empresaId).FirstOrDefault();
                if (entity != null)
                {
                    uiUnaformapago.Checked = entity.UnaFormaPago ?? false;
                    uiMasunaformapago.Checked = entity.MasUnaFormaPago ?? false;
                    uiInvPromedios.Checked = entity.CosteoPromedio ?? false;
                    uiInvUeps.Checked = entity.CosteoUEPS ?? false;
                    uiInvPeps.Checked = entity.CosteoPEPS ?? false;
                    uiInvEnLinea.Checked = entity.AfectarInventarioLinea ?? false;
                    uiInvAlCorteCaja.Checked = entity.AfectarInventarioCorte ?? false;
                    uiInvManualmente.Checked = entity.AfectarInventarioManual ?? false;
                    uiInvEnlazarPV_INV.Checked = entity.EnlazarPuntoVentaInventario ?? false;
                    uiCCCajIncluirDetVenta.Checked = entity.CajeroIncluirDetalleVenta ?? false;
                    uiCCCajRequiereCveSup.Checked = entity.CajeroReqClaveSupervisor ?? false;
                    uiCCSupIncluirDetVenta.Checked = entity.SuperIncluirDetalleVenta ?? false;
                    uiCCIncluirVtasTelefono.Checked = entity.SuperIncluirVentaTel ?? false;
                    uiCCIncluirGatos.Checked = entity.SuperIncluirDetGastos ?? false;
                    uiCCCorreo1.Text = entity.SuperEmail1;
                    uiCorreo2.Text = entity.SuperEmail2;
                    uiCorreo3.Text = entity.SuperEmail3;
                    uiCorreo4.Text = entity.SuperEmail4;
                    uiRetMonto.Value = entity.RetiroMontoEfec??0;
                    uiRetLectura.Checked = entity.RetiroLectura ?? false;
                    uiRetEscritura.Checked = entity.RetiroEscritura ?? false;
                    uiHarPuntoVenta.SelectedValue = entity.NombreImpresora;
                    uiHarCaracterCajon.Text = entity.HardwareCaracterCajon;
                    uiVenPorcDescuento.Value = entity.EmpleadoPorcDescuento??0;
                    uiVenGlobal.Checked = entity.EmpleadoGlobal??false;
                    uiVenIndividual.Checked = entity.EmpleadoIndividual ?? false;
                    uiTickImprimirAPartir.Value = entity.MontoImpresionTicket ?? 0;
                    uiTicketDesglosar.Checked = entity.DesgloceMontoTicket??false;
                    uiAnticipoDe1.Value = entity.ApartadoAnticipo1 ?? 0;
                    uiAnticipoDe2.Value = entity.ApartadoAnticipo2??0;
                    uiAnticipoDe3.Value = entity.ApartadoAnticipoHasta1 ?? 0;
                    uiAnticipoDe4.Value = entity.ApatadoAnticipoEnAdelante2 ?? 0;
                    uiCajDeclaracionFondo.Checked = entity.CajDeclaracionFondoCorte ?? false;
                    uiSubDeclaracionFond.Checked = entity.SupDeclaracionFondoCorte ?? false;
                    uiVistaPreviaImp.Checked = entity.vistaPreviaImpresion ?? false;
                    uiCajCorteCancelaciones.Checked = entity.CajeroCorteCancelaciones ?? false;
                    uiCajGastosDet.Checked = entity.CajeroCorteDetGasto ?? false;
                    uiSupCorteCancelaciones.Checked = entity.SupCorteCancelaciones ?? false;
                    uiSupGastosDet.Checked = entity.SupCorteDetGasto ?? false;
                    uiDiasVale.Value = entity.DevDiasVale ?? 0;
                    uiDiasGarantia.Value = entity.DevDiasGarantia ?? 0;
                    uiHorasDevolucion.Value = entity.DevHorasGarantia ?? 0;
                    uiDiasLiquidacionApartado.Value = entity.ApartadoDiasLiq ?? 0;
                    uiDiasProrrogaApartado.Value = entity.ApartadoDiasProrroga ?? 0;
                    uiRetiroReqClaveSup.Checked = entity.RetiroReqClaveSup ?? false;
                    uiReqClaveSupReimpresionTicketPV.Checked = entity.ReqClaveSupReimpresionTicketPV ?? false;
                    uiReqClaveSupCancelaTicketPV.Checked = entity.ReqClaveSupCancelaTicketPV ?? false;
                    uiReqClaveSupGastosPV.Checked = entity.ReqClaveSupGastosPV ?? false;
                    uiReqClaveSupDevolucionPV.Checked = entity.ReqClaveSupDevolucionPV ?? false;
                    uiReqClaveSupApartadoPV.Checked = entity.ReqClaveSupApartadoPV ?? false;
                    uiReqClaveSupExistenciaPV.Checked = entity.ReqClaveSupExistenciaPV ?? false;
                    uiIncluirExistencias.Checked = entity.CorteCajaIncluirExistencia ?? false;
                    uiImprimirMediaCarta.Checked = entity.ImprimirTicketMediaCarta ?? false;
                    uiSolicitarComanda.Checked = entity.SolicitarComanda ?? false;
                    uiGiro.SelectedItem = entity.Giro;
                    uiPedidoAnticipoPorc.Value = entity.PedidoAnticipoPorc??0;
                    uiPedidoPolitica.EditValue = entity.PedidoPoliticaId;
                }
                else {
                    MessageBox.Show("Existió un error al obtener la configración del sistema");
                }

                if(entityRestaurante != null)
                {
                    uiSolicitarComanda.Checked = entityRestaurante.SolicitarFolioComanda;
                }
                if(configInve != null)
                {
                    uiInvTraspasoAutom.Checked = configInve.EnableTraspasoAutomatico;
                    uiInvValidarExisTraspaso.Checked = configInve.ValidarExistenciaTraspaso??false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void guardar()
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    oContext.p_cat_configuracion_ins_upd(
                    0,
                    uiUnaformapago.Checked,
                   uiMasunaformapago.Checked,
                   uiInvUeps.Checked,
                   uiInvPeps.Checked,
                   uiInvPromedios.Checked,
                   uiInvEnLinea.Checked,
                   uiInvManualmente.Checked,
                   uiInvAlCorteCaja.Checked, uiInvEnlazarPV_INV.Checked,
                   uiCCCajIncluirDetVenta.Checked,
                   uiCCCajRequiereCveSup.Checked,
                   uiCCSupIncluirDetVenta.Checked, uiCCIncluirVtasTelefono.Checked,
                   uiCCIncluirGatos.Checked,
                   uiCCCorreo1.Text, uiCorreo2.Text, uiCorreo3.Text, uiCorreo4.Text,
                   uiRetMonto.Value, uiRetLectura.Checked, uiRetEscritura.Checked, uiHarPuntoVenta.Text, uiHarCaracterCajon.Text, uiVenPorcDescuento.Value,
                   uiVenGlobal.Checked, uiVenIndividual.Checked, uiTickImprimirAPartir.Value,
                   uiAnticipoDe1.Value,
                   uiAnticipoDe3.Value,
                   uiAnticipoDe2.Value,
                   uiAnticipoDe4.Value, 0, uiTicketDesglosar.Checked,
                   uiRetiroReqClaveSup.Checked, uiCajDeclaracionFondo.Checked, uiSubDeclaracionFond.Checked, uiVistaPreviaImp.Checked,
                   uiCajGastosDet.Checked, uiCajCorteCancelaciones.Checked,
                   uiSupGastosDet.Checked, uiSupCorteCancelaciones.Checked,
                   byte.Parse(uiDiasVale.Value.ToString()),
                   byte.Parse(uiDiasGarantia.Value.ToString()),
                   byte.Parse(uiHorasDevolucion.Value.ToString()),
                   byte.Parse(uiDiasLiquidacionApartado.Value.ToString()),
                   byte.Parse(uiDiasProrrogaApartado.Value.ToString()),
                   uiReqClaveSupReimpresionTicketPV.Checked,
                   uiReqClaveSupCancelaTicketPV.Checked,
                   uiReqClaveSupGastosPV.Checked,
                   uiReqClaveSupDevolucionPV.Checked,
                   uiReqClaveSupApartadoPV.Checked,
                   uiReqClaveSupExistenciaPV.Checked,
                   uiIncluirExistencias.Checked,
                   uiImprimirMediaCarta.Checked,
                   uiSolicitarComanda.Checked,
                   uiGiro.SelectedItem.ToString(),
                   uiPedidoAnticipoPorc.Value,
                   this.uiPedidoPolitica.EditValue == null ? null : (int?)(this.uiPedidoPolitica.EditValue)

                   );

                    int empresaid = this.puntoVentaContext.empresaId;
                    oContext.p_cat_configuracion_rest_ins_upd(1, uiSolicitarComanda.Checked);

                    #region inventarios
                    cat_empresas_config_inventario confInv;
                    if(oContext.cat_empresas_config_inventario
                        .Where(w=> w.EmpresaId == empresaid).Count() == 0)
                    {
                        confInv = new cat_empresas_config_inventario();

                        confInv.EmpresaId = empresaid;
                        confInv.EnableTraspasoAutomatico = uiInvTraspasoAutom.Checked;
                        confInv.ValidarExistenciaTraspaso = uiInvValidarExisTraspaso.Checked;

                        oContext.cat_empresas_config_inventario.Add(confInv);
                        oContext.SaveChanges();
                    }
                    else
                    {
                        confInv = oContext.cat_empresas_config_inventario
                        .Where(w => w.EmpresaId == empresaid).FirstOrDefault();

                        confInv.EnableTraspasoAutomatico = uiInvTraspasoAutom.Checked;
                        confInv.ValidarExistenciaTraspaso = uiInvValidarExisTraspaso.Checked;
                        oContext.SaveChanges();
                    }
                    #endregion

                    scope.Complete();

                    MessageBox.Show("Los datos se han guardado correctamente", "OK");

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void PopulateInstalledPrintersCombo()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            List<impresora> lstImpresoras = new List<impresora>();
            
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                impresora item = new impresora();
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                item.nombre = pkInstalledPrinters;
                lstImpresoras.Add(item);
                //comboInstalledPrinters.Items.Add(pkInstalledPrinters);
            }

            uiHarPuntoVenta.DataSource = lstImpresoras; 
        }

        private void frmConfigurador_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void frmConfigurador_Load(object sender, EventArgs e)
        {
            ValidarAcceso(this.puntoVentaContext.usuarioId, this.puntoVentaContext.sucursalId, "frmConfigurador");
            PopulateInstalledPrintersCombo();

            gpProd1.Enabled = true;
            gpProd2.Enabled = false;
            gpProd3.Enabled = false;
            uiProd2ConiVA.Checked = false;
            uiProd2SinIVA.Checked = false;
            uiProd3ConiVA.Checked = false;
            uiProd3SinIVA.Checked = false;

            if(puntoVentaContext.giroPuntoVenta != Enumerados.systemGiro.REST.ToString())
            {
                uiTabs.TabPages.Remove(tabRestaurante);
                
            }
            
            

            LlenarForma();

            #region llenar listado de politicas
            uiPedidoPolitica.Properties.DataSource = oContext.cat_politicas.ToList();
            #endregion
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (uiRadio1.Checked)
            {
                gpProd1.Enabled = true;
                gpProd2.Enabled = false;
                gpProd3.Enabled = false;
                uiProd2ConiVA.Checked = false;
                uiProd2SinIVA.Checked = false;
                uiProd3ConiVA.Checked = false;
                uiProd3SinIVA.Checked = false;
            }
        }

        private void uiRadio2_CheckedChanged(object sender, EventArgs e)
        {
            gpProd1.Enabled = false;
            gpProd2.Enabled = true;
            gpProd3.Enabled = false;
            uiProd1ConiVA.Checked = false;
            uiProd1SinIVA.Checked = false;
            uiProd3ConiVA.Checked = false;
            uiProd3SinIVA.Checked = false;
        }

        private void uiRadio3_CheckedChanged(object sender, EventArgs e)
        {
            gpProd1.Enabled = false;
            gpProd2.Enabled = false;
            gpProd3.Enabled = true;
            uiProd1ConiVA.Checked = false;
            uiProd1SinIVA.Checked = false;
            uiProd2ConiVA.Checked = false;
            uiProd2SinIVA.Checked = false;
        }

        private void uiCajDeclaracionFondo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

    public class impresora
    {
        public string nombre { get; set; }
    }
}
