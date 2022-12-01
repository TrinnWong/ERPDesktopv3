using ConexionBD;
using ConexionBD.Models;
using ERP.Business;
using PuntoVenta;
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
    public partial class frmDeclaracionFondo : Form
    {
        public string error = "";
        public string tipo = "fondoInicial";
        public bool imprimirCorte = true;
        public bool cerrarSistema = true;
        ERPProdEntities oCOntext;
        public PuntoVentaContext puntoVentaContext;
        List<DeclaracionFondoModel> model1;
        List<DeclaracionFondoModel> model2;

        DeclaracionFondoBusiness oDeclaracionB;
        public frmDeclaracionFondo()
        {
            InitializeComponent();
            oDeclaracionB = new DeclaracionFondoBusiness();
            model1 = new List<DeclaracionFondoModel>();
            model2 = new List<DeclaracionFondoModel>();

            this.uiGrid1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGrid1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGrid1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGrid1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGrid1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGrid1.Columns[2].DefaultCellStyle.Format = "c2";
            //this.uiGrid1.Columns[3].DefaultCellStyle.Format = "c2";
            this.uiGrid1.Columns[4].DefaultCellStyle.Format = "c2";

            this.uiGrid2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGrid2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGrid2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGrid2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGrid2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGrid2.Columns[2].DefaultCellStyle.Format = "c2";
            //this.uiGrid1.Columns[3].DefaultCellStyle.Format = "c2";
            this.uiGrid2.Columns[4].DefaultCellStyle.Format = "c2";

        }

        private void ClearObjets()
        {
            oDeclaracionB = null;
        }
        private void llenarGrids()
        {
            try
            {
                uiGrid1.AutoGenerateColumns = false;
                uiGrid2.AutoGenerateColumns = false;

             

                model1 = oCOntext.cat_denominaciones.OrderBy(o => o.Orden).Select(
                        s => new DeclaracionFondoModel
                        {
                            clave = s.Clave,
                            descripcion = s.Descripcion,
                            cantidad = 0,
                            total = 0,
                            valor = s.Valor ?? 0,
                            sucursalId = puntoVentaContext.sucursalId
                        }
                    ).ToList();

                model2 = oCOntext.cat_denominaciones.OrderBy(o => o.Orden).Select(
                       s => new DeclaracionFondoModel
                       {
                           clave = s.Clave,
                           descripcion = s.Descripcion,
                           cantidad = 0,
                           total = 0,
                           valor = s.Valor ?? 0,
                           sucursalId = puntoVentaContext.sucursalId
                       }
                   ).ToList();

                uiGrid1.DataSource = model1;


                uiGrid2.DataSource = model2;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void frmDeclaracionFondo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_instance = null;
            ClearObjets();
        }

        private void frmDeclaracionFondo_Load(object sender, EventArgs e)
        {
            oCOntext = new ERPProdEntities();
            llenarGrids();
        }

        private void uiGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uiGrid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal total = 0;
                int cantidad = 0;
                decimal valor = 0;
                int clave = 0;

                DeclaracionFondoModel itemModel = new DeclaracionFondoModel();

                

                cantidad = uiGrid1.Rows[e.RowIndex].Cells["cantidad"].Value != null? 
                        int.Parse(uiGrid1.Rows[e.RowIndex].Cells["cantidad"].Value.ToString())
                        :
                        0;
                //Asegurarse de no capturar ceros
                if (cantidad < 0)
                {
                    uiGrid1.Rows[e.RowIndex].Cells["cantidad"].Value = 0;
                    cantidad = 0;
                }
                clave = int.Parse(uiGrid1.Rows[e.RowIndex].Cells["clave"].Value.ToString());
                valor = decimal.Parse(uiGrid1.Rows[e.RowIndex].Cells["valor"].Value.ToString());
                total = cantidad * valor;


                uiGrid1.Rows[e.RowIndex].Cells["cantidad"].Value = cantidad;
                uiGrid1.Rows[e.RowIndex].Cells["total"].Value = total;

                model1.First(w => w.clave == clave).cantidad = cantidad;
                model1.First(w => w.clave == clave).total = total;       

                uiTotal1.Value = model1.Sum(s => s.total??0);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message, "ERROR");
            }
        }

        private void uiGrid2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               decimal total = 0;
                int cantidad = 0;
                decimal valor = 0;
                int clave = 0;

                cantidad = uiGrid2.Rows[e.RowIndex].Cells["cantidad2"].Value != null ?
                       int.Parse(uiGrid2.Rows[e.RowIndex].Cells["cantidad2"].Value.ToString())
                       :
                       0;
                //Asegurarse de no capturar ceros
                if (cantidad < 0)
                {
                    uiGrid2.Rows[e.RowIndex].Cells["cantidad2"].Value = 0;
                    cantidad = 0;
                }

              //  cantidad = int.Parse(uiGrid2.Rows[e.RowIndex].Cells["cantidad2"].Value.ToString());
                clave = int.Parse(uiGrid2.Rows[e.RowIndex].Cells["clave2"].Value.ToString());
                valor = decimal.Parse(uiGrid2.Rows[e.RowIndex].Cells["valor2"].Value.ToString());
                total = cantidad * valor;

                uiGrid2.Rows[e.RowIndex].Cells["cantidad2"].Value = cantidad;
                uiGrid2.Rows[e.RowIndex].Cells["total2"].Value = total;

                model2.First(w => w.clave == clave).cantidad = cantidad;
                model2.First(w => w.clave == clave).total = total;

                uiTotal2.Value = model2.Sum(s => s.total??0);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message, "ERROR");
            }
        }

        private void uiContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                uiGrid1.Columns[3].Visible = false;
                uiGrid1.Columns[4].Visible = false;
                uiGrid2.Columns[3].Visible = true;
                uiGrid2.Columns[4].Visible = true;
                groupBox2.Enabled = true;
                uiTerminar.Enabled = true;

                uiContinuar.Enabled = false;
                groupBox1.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        private void uiTerminar_Click(object sender, EventArgs e)
        {
            try
            {

                error = "";
                for (int i = 0; i < model1.Count; i++)
                {
                    if (model1[i].cantidad != model2[i].cantidad)
                    {
                        error = error + "," + model1[i].valor.ToString();
                    }
                }
                if (error.Length > 0)
                {
                    error = "No coinciden las siguientes denominaciones:" + error;
                   
                    ERP.Utils.MessageBoxUtil.ShowError(error);

                    uiGrid1.Columns[3].Visible = true;
                    uiGrid1.Columns[4].Visible = true;
                    uiGrid2.Columns[3].Visible = false;
                    uiGrid2.Columns[4].Visible = false;
                    groupBox2.Enabled = false;
                    uiTerminar.Enabled = false;

                    uiContinuar.Enabled = true;
                    groupBox1.Enabled = true;

                   

                }
                else {

                    if (tipo == "fondoInicial")
                    {
                        oDeclaracionB.GuardaFondoInicial(model2, this.puntoVentaContext.usuarioId, 
                            this.puntoVentaContext.sucursalId,
                            this.puntoVentaContext.cajaId,
                            ref error);

                        if(error.Length > 0)
                        {
                            ERP.Utils.MessageBoxUtil.ShowError(error);
                        }
                        else
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                       
                    }
                    else
                    {
                        frmMenuRest oForm = frmMenuRest.GetInstance();
                        oForm.puntoVentaContext = this.puntoVentaContext;
                        oForm.CorteCaja(model1, false,imprimirCorte,cerrarSistema);
                        this.Close();

                        this.DialogResult = DialogResult.OK;
                    }
                    
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
