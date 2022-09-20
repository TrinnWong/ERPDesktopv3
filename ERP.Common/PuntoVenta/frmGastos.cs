using ConexionBD;
using ConexionBD.Models;
using ERP.Common.Reports;
using ERP.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.PuntoVenta
{
    public partial class frmGastos : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        GastosInterface oGasto;
        public int accionForm;
        private static frmGastos _instance;
        public int idForm;

        public static frmGastos GetInstance()
        {
            if (_instance == null) _instance = new frmGastos();
            return _instance;
        }

        public frmGastos()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            oGasto = new GastosInterface();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cargarForma()
        {

            try
            {
                oContext = new ERPProdEntities();
                doc_gastos entity = oContext.doc_gastos.Where(w => w.GastoId == idForm).FirstOrDefault();

                if (entity != null)
                {
                    uiCentroCosto.SelectedValue = entity.CentroCostoId;
                    uiConcepto.SelectedValue = entity.GastoConceptoId;
                    uiMonto.Value = entity.Monto;
                    uiObservaciones.Text = entity.Obervaciones;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void llenarCombos()
        {
            uiCentroCosto.DataSource = oContext.cat_centro_costos.Where(w=> w.Estatus == true).ToList();

            LlenarComboConcepto();



        }

        private void LlenarComboConcepto()
        {
            int? cc = (int?)uiCentroCosto.SelectedValue;

            uiConcepto.DataSource = oContext.cat_gastos.Where(w => w.Estatus ==true &&
                        (w.ClaveCentroCosto == cc || cc==null)
                        ).ToList();

            uiConcepto.Text = ""; ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void imprimir(int id)
        {
            rptGastoTicket oTicket = new rptGastoTicket();

            ReportViewer oViewer = new ReportViewer(puntoVentaContext.cajaId);

            oTicket.DataSource = oContext.p_rpt_gasto_ticket(id).ToList();

            oViewer.ShowTicket(oTicket);
            //oViewer.Show();
        }

        private void guardar()
        {
            try
            {
                oContext = new ERPProdEntities();
                string error="";
                int cc = uiCentroCosto.SelectedValue == null ? 0 : (int)uiCentroCosto.SelectedValue;
                int GastoConceptoId = uiConcepto.SelectedValue == null ? 0 :(int)uiConcepto.SelectedValue;

                if (
                   cc <= 0
                    )
                {
                    error = "El centro de costos es requerido";
                }
                if (
                   GastoConceptoId <= 0
                    )
                {
                    error = error + "|El concepto es requerido";
                }
                if (uiMonto.Value <= 0)
                {
                    error = error + "|El monto es requerido";
                }

                if (error.Length > 0)
                {
                    MessageBox.Show( error,"ERROR");
                    return;
                }

               


                if (accionForm == (int)Enumerados.accionForm.agregar)
                {
                    doc_gastos entityGasto = new doc_gastos();

                    entityGasto.GastoId = oContext.doc_gastos.Count() > 0 ? oContext.doc_gastos.Max(m => m.GastoId) + 1 : 1;
                    entityGasto.CajaId = this.puntoVentaContext.cajaId;
                    entityGasto.CentroCostoId = (int)uiCentroCosto.SelectedValue;
                    entityGasto.GastoConceptoId = (int)uiConcepto.SelectedValue;
                    entityGasto.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                    entityGasto.CreadoPor = this.puntoVentaContext.usuarioId;

                    entityGasto.Activo = true;
                    entityGasto.Monto = uiMonto.Value;
                    entityGasto.Obervaciones = uiObservaciones.Text;
                    entityGasto.SucursalId = this.puntoVentaContext.sucursalId;

                    error = oGasto.InsertargastoVenta(entityGasto);

                    imprimir(entityGasto.GastoId);


                }

                if (accionForm == (int)Enumerados.accionForm.actualizar)
                {

                    var resultVal = oContext.p_doc_gasto_del_valida(idForm).FirstOrDefault();

                    if (resultVal.Length > 0)
                    {
                        MessageBox.Show(resultVal.ToString(), "ERROR");
                        return;
                    }

                    doc_gastos entityGasto = oContext.doc_gastos.Where(w => w.GastoId == idForm).FirstOrDefault();

                    
                    entityGasto.CajaId = this.puntoVentaContext.cajaId;
                    entityGasto.CentroCostoId = (int)uiCentroCosto.SelectedValue;
                    entityGasto.GastoConceptoId = (int)uiConcepto.SelectedValue;
                    //entityGasto.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                    //entityGasto.CreadoPor = this.puntoVentaContext.usuarioId;

                    //entityGasto.Activo = true;
                    entityGasto.Monto = uiMonto.Value;
                    entityGasto.Obervaciones = uiObservaciones.Text;
                    //entityGasto.SucursalId = this.puntoVentaContext.sucursalId;

                    oContext.SaveChanges();


                    imprimir(entityGasto.GastoId);
                }

                if (accionForm == (int)Enumerados.accionForm.eliminar)
                {

                    if (
                        MessageBox.Show("¿Está seguro de continuar?", "AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes
                        )
                    {

                        var resultVal = oContext.p_doc_gasto_del_valida(idForm).FirstOrDefault();

                        if (resultVal.Length > 0)
                        {
                            MessageBox.Show(resultVal.ToString(), "ERROR");
                            return;
                        }
                       

                        doc_gastos entityGasto = oContext.doc_gastos.Where(w => w.GastoId == idForm).FirstOrDefault();

                        oContext.doc_gastos.Remove(entityGasto);

                        oContext.SaveChanges();
                    }
                    else {
                        return;
                    }
                    
                }



                if (error.Length > 0)
                {
                    MessageBox.Show(error, "ERROR");
                }
                else {
                    MessageBox.Show("EL PROCESO CONCLUYÓ CON ÉXITO");
                    this.Close();

                    frmGastosList instance = frmGastosList.GetInstance();

                    instance.Buscar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
                this.Close();
            }
        }

        private void frmGastos_Load(object sender, EventArgs e)
        {
            llenarCombos();

            if (accionForm == (int)Enumerados.accionForm.actualizar )               
            {
                cargarForma();
            }

            var resultVal = oContext.p_doc_gasto_del_valida(idForm).FirstOrDefault();          

            if (accionForm == (int)Enumerados.accionForm.eliminar
                ||
                resultVal.Length > 0
                )
            {
                cargarForma();
                uiCentroCosto.Enabled = false;
                uiConcepto.Enabled = false;
                uiObservaciones.Enabled = false;
                uiMonto.Enabled = false;

                if (resultVal.Length > 0)
                {
                    uiGuardar.Enabled = false;
                }


                if (accionForm == (int)Enumerados.accionForm.eliminar)
                {
                    uiGuardar.Text = "ELIMINAR";
                }
                
            }
        }

        private void Habilitar()
        {
            uiCentroCosto.Enabled = true;
            uiConcepto.Enabled = true;
            uiObservaciones.Enabled = true;
            uiMonto.Enabled = true;

        }

        private void uiCentroCosto_SelectedValueChanged(object sender, EventArgs e)
        {
            LlenarComboConcepto();
        }

        private void frmGastos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
