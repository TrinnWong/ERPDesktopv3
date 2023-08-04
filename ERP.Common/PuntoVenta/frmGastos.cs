using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
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
    public partial class frmGastos : XtraForm
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
                    uiCentroCosto1.EditValue = entity.CentroCostoId;
                    uiConcepto1.EditValue = entity.GastoConceptoId;
                    uiMonto1.Value = entity.Monto;
                    uiObservaciones1.Text = entity.Obervaciones;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void llenarCombos()
        {
            uiCentroCosto1.Properties.DataSource = oContext.cat_centro_costos.Where(w=> w.Estatus == true).ToList();
            uiCentroCosto1.ItemIndex = 0;
            LlenarComboConcepto();



        }

        private void LlenarComboConcepto()
        {
            int? cc = Convert.ToInt32(uiCentroCosto1.EditValue);

            uiConcepto1.Properties.DataSource = oContext.cat_gastos.Where(w => w.Estatus ==true &&
                        (w.ClaveCentroCosto == cc || cc==null)
                        ).ToList();

            uiConcepto1.Text = ""; ;
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
            this.uiGuardar1.Enabled = false;
            uiSalir1.Enabled = false;
            try
            {
                oContext = new ERPProdEntities();
                string error="";
                int cc = Convert.ToInt32(uiCentroCosto1.EditValue);
                int GastoConceptoId = Convert.ToInt32(uiConcepto1.EditValue);

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
                if (uiMonto1.Value <= 0)
                {
                    error = error + "|El monto es requerido";
                }

                if (error.Length > 0)
                {
                    MessageBox.Show( error,"ERROR");
                    this.uiGuardar1.Enabled = true;
                    uiSalir1.Enabled = true;
                    return;
                }

               


                if (accionForm == (int)Enumerados.accionForm.agregar)
                {
                    doc_gastos entityGasto = new doc_gastos();

                    entityGasto.GastoId = oContext.doc_gastos.Count() > 0 ? oContext.doc_gastos.Max(m => m.GastoId) + 1 : 1;
                    entityGasto.CajaId = this.puntoVentaContext.cajaId;
                    entityGasto.CentroCostoId = Convert.ToInt32(uiCentroCosto1.EditValue);
                    entityGasto.GastoConceptoId = Convert.ToInt32(uiConcepto1.EditValue);
                    entityGasto.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                    entityGasto.CreadoPor = this.puntoVentaContext.usuarioId;

                    entityGasto.Activo = true;
                    entityGasto.Monto = uiMonto1.Value;
                    entityGasto.Obervaciones = uiObservaciones1.Text;
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
                    entityGasto.CentroCostoId = Convert.ToInt32(uiCentroCosto1.EditValue);
                    entityGasto.GastoConceptoId = Convert.ToInt32(uiConcepto1.EditValue);
                    //entityGasto.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                    //entityGasto.CreadoPor = this.puntoVentaContext.usuarioId;

                    //entityGasto.Activo = true;
                    entityGasto.Monto = uiMonto1.Value;
                    entityGasto.Obervaciones = uiObservaciones1.Text;
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
                            this.uiGuardar1.Enabled = true;
                            uiSalir1.Enabled = true;
                            return;
                        }
                       

                        doc_gastos entityGasto = oContext.doc_gastos.Where(w => w.GastoId == idForm).FirstOrDefault();

                        oContext.doc_gastos.Remove(entityGasto);

                        oContext.SaveChanges();
                    }
                    else {
                        this.uiGuardar1.Enabled = true;
                        uiSalir1.Enabled = true;
                        return;
                    }
                    
                }

                this.uiGuardar1.Enabled = true;
                uiSalir1.Enabled = true;
                if (error.Length > 0)
                {
                    MessageBox.Show(error, "ERROR");
                }
                else {
                   
                    this.Close();

                    
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
                this.uiGuardar1.Enabled = true;
                uiSalir1.Enabled = true;
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
                uiCentroCosto1.Enabled = false;
                uiConcepto1.Enabled = false;
                uiObservaciones1.Enabled = false;
                uiMonto1.Enabled = false;

                if (resultVal.Length > 0)
                {
                    uiGuardar1.Enabled = false;
                }


                if (accionForm == (int)Enumerados.accionForm.eliminar)
                {
                    uiGuardar1.Text = "ELIMINAR";
                }
                
            }
        }

        private void Habilitar()
        {
            uiCentroCosto1.Enabled = true;
            uiConcepto1.Enabled = true;
            uiObservaciones1.Enabled = true;
            uiMonto1.Enabled = true;

        }

        private void uiCentroCosto_SelectedValueChanged(object sender, EventArgs e)
        {
            LlenarComboConcepto();
        }

        private void frmGastos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

      

        private void uiSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiGuardar1_Click(object sender, EventArgs e)
        {
           
            guardar();
        }

        private void uiMonto1_Click(object sender, EventArgs e)
        {
            uiMonto1.Select();
        }

        private void uiMonto1_Enter(object sender, EventArgs e)
        {
            uiMonto1.Select();
        }

        private void uiConcepto1_EditValueChanged(object sender, EventArgs e)
        {
            uiMonto1.Select();
        }

        private void uiMonto1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                uiObservaciones1.Select();
            }
        }

        private void uiObservaciones1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.uiGuardar1.Enabled = false;
                uiSalir1.Enabled = false;
                guardar();
            }
        }
    }
}
