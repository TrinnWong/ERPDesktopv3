using ConexionBD;
using ConexionBD.Models;
using PuntoVenta.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class frmDevolucionesUpd : Form
    {
        public int ventaId;
        public int devolucionId;
        ERPProdEntities oContext;
        public int accionForm;
        private static frmDevolucionesUpd _instance;
        public PuntoVentaContext puntoVentaContext;

        public static frmDevolucionesUpd GetInstance()
        {
            if (_instance == null) _instance = new frmDevolucionesUpd();
            else _instance.BringToFront();
            return _instance;
        }

        List<DevolucionGridModel> lstDevoluciones { get; set; }
        public frmDevolucionesUpd()
        {
            InitializeComponent();
        }

        public void buscarRegistro()
        {
            try
            {
                doc_devoluciones entity = oContext.doc_devoluciones.Where(w => w.DevolucionId == devolucionId).FirstOrDefault();

                uiFolioDevolucion.Value = entity.DevolucionId;
                uiFolioTocket.Text = entity.VentaId.ToString();
                uiFecha.Value = entity.CreadoEl;

                uiGrid.AutoGenerateColumns = false;

                lstDevoluciones = oContext.p_doc_devoluciones_grid(0, devolucionId)
                  .ToList()
                  .Select(
                      s => new DevolucionGridModel()
                      {
                          cantidad = s.Cantidad,
                          devolucionDetId = s.DevolucionDetId ?? 0,
                          devolucionId = s.DevolucionId ??0,
                          precioUnitario = s.PrecioUnitario??0,
                          producto = s.Producto,
                          productoId = s.ProductoId,
                          seleccionar = s.Seleccionar ?? false,
                          total = s.Total,
                          ventaId = s.VentaId,
                          cantidadTicket = s.CantidadTicket ?? 0
                      }
                  ).ToList();

                uiGrid.DataSource = lstDevoluciones;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void frmDevolucionesUpd_Load(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();

            uiTipoDevolucion.DataSource = oContext.cat_tipos_devolucion.ToList();

            if (accionForm == 2)
            {
                buscarRegistro();

                panel3.Enabled = true;
                panel1.Enabled = false;
                panel2.Enabled = false;

                uiGuardar.Enabled = false;

            }

            if (accionForm == 3)
            {
                buscarRegistro();
                uiGuardar.Text = "ELIMINAR";
                panel1.Enabled = false;
                panel2.Enabled = false;
            }
        }

        private void buscarTicket()
        {
            try
            {
                uiGrid.AutoGenerateColumns = false;

                int.TryParse(uiFolioTocket.Text, out ventaId);

                lstDevoluciones = oContext.p_doc_devoluciones_grid(ventaId, 0)
                    .ToList()
                    .Select(
                        s => new DevolucionGridModel()
                        {
                            cantidad = s.Cantidad,
                            devolucionDetId = s.DevolucionDetId ?? 0,
                            devolucionId = s.DevolucionId ?? 0,
                            precioUnitario = s.PrecioUnitario??0,
                            producto = s.Producto,
                            productoId = s.ProductoId,
                            seleccionar = s.Seleccionar ?? false,
                            total = s.Total,
                            ventaId = s.VentaId,
                            cantidadTicket = s.CantidadTicket ?? 0,
                            fechaTicket = s.FechaTicket
                        }
                    ).ToList();

                if (lstDevoluciones.Count > 0)
                {
                    uiFechaTicket.Value = lstDevoluciones[0].fechaTicket;
                }

                uiGrid.DataSource = lstDevoluciones;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void uiFolioTocket_Validated(object sender, EventArgs e)
        {

        }

        private void frmDevolucionesUpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiFolioTocket_Validating(object sender, CancelEventArgs e)
        {
            buscarTicket();
        }

        private void uiGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (uiGrid.Columns[e.ColumnIndex].Name == "Seleccionar")
            //    {
            //        bool seleccionar = bool.Parse(uiGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

            //        uiGrid.

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "ERROR");
            //}
        }

        private void uiGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal cantidad = decimal.Parse(uiGrid.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString());
                decimal precioUnitario = decimal.Parse(uiGrid.Rows[e.RowIndex].Cells["PrecioUnitario"].Value.ToString());
                decimal total = cantidad * precioUnitario;
                bool seleccionar = bool.Parse(uiGrid.Rows[e.RowIndex].Cells["Seleccionar"].Value.ToString());

                if (seleccionar)
                {
                    uiGrid.Rows[e.RowIndex].Cells["Total"].Value = total;
                }
                else {


                    uiGrid.Rows[e.RowIndex].Cells["Total"].Value = decimal.Parse("0");
                }

                calcularTotal();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void calcularTotal()
        {
            try
            {
                decimal total = 0;
                int filas = uiGrid.Rows.Count;

                for (int i = 0; i < filas; i++)
                {
                    if (
                        bool.Parse(uiGrid.Rows[i].Cells["Seleccionar"].Value.ToString())
                        )
                    {
                        total = total + decimal.Parse(uiGrid.Rows[i].Cells["total"].Value.ToString());
                    }

                }

                uiTotalDevolucion.Value = total;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un problema al calcular los totales", "ERROR");
            }
        }

        private string validar()
        {
            string error = "";

            oContext = new ERPProdEntities();

            if (uiTotalDevolucion.Value <= 0)
            {
                error = "No es posible realizar una devolución con cantidades en cero";
            }
            int tipoDev = uiTipoDevolucion.SelectedValue == null ? 0 : int.Parse(uiTipoDevolucion.SelectedValue.ToString());

            if (tipoDev <= 0)
            {
                error = error + "|Es necesario especificar el tipo de devolución";
            }

            /****POR DEVOLUCION*****/
            DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
            if (tipoDev == 1)
            {
                int diasGarantia = oContext.cat_configuracion.FirstOrDefault().DevDiasGarantia??0;

                if ((fechaActual - uiFechaTicket.Value).TotalDays > diasGarantia)
                {
                    error = error + "|La fecha de la venta excede los días de garantía";
                }

            }
            /****EXPRESSS***************/
            if (tipoDev == 2)
            {
                int horasGarantia = oContext.cat_configuracion.FirstOrDefault().DevHorasGarantia??0;

                if ((fechaActual - uiFechaTicket.Value).TotalHours > horasGarantia)
                {
                    error = error + "|La fecha de la venta excede las horas de garantía";
                }

            }

            return error;
        }

        private void guardar()
        {

            try
            {
                if (
               MessageBox.Show("¿Está seguro de continuar?", "AVISO", MessageBoxButtons.YesNo) == DialogResult.No
               )
                {
                    return;
                }

                ObjectParameter pDevolucionId = new ObjectParameter("pDevolucionId", 0);
                ObjectParameter pDevolucionDetId = new ObjectParameter("pDevolucionDetId", 0);

                string error = "";

                error = validar();

                if (error.Length > 0)
                {

                    MessageBox.Show(error, "ERROR");
                    return;


                }
                else
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        oContext = new ERPProdEntities();



                        oContext.p_doc_devolucion_ins(pDevolucionId, ventaId, uiTotalDevolucion.Value, DateTime.Now, this.puntoVentaContext.usuarioId,
                            int.Parse(uiTipoDevolucion.SelectedValue.ToString()));

                        for (int i = 0; i < uiGrid.Rows.Count; i++)
                        {

                            ObjectParameter pError = new ObjectParameter("pError", "");

                            if (bool.Parse(uiGrid.Rows[i].Cells["Seleccionar"].Value.ToString()))
                            {
                                int productoId = int.Parse(uiGrid.Rows[i].Cells["ProductoId"].Value.ToString());
                                decimal cantidad = decimal.Parse(uiGrid.Rows[i].Cells["Cantidad"].Value.ToString());
                                decimal total = decimal.Parse(uiGrid.Rows[i].Cells["Total"].Value.ToString());
                                oContext.p_doc_devolucion_detalle_ins(pDevolucionDetId, int.Parse(pDevolucionId.Value.ToString()), ventaId, productoId, cantidad, total, DateTime.Now,
                                    this.puntoVentaContext.usuarioId, pError);

                                if (pError.Value.ToString().Length > 0)
                                {
                                    MessageBox.Show(pError.Value.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }

                        }


                        oContext.p_doc_devolucion_mov_inv_genera(int.Parse(pDevolucionId.Value.ToString()), puntoVentaContext.usuarioId);

                        scope.Complete();
                    }

                    imprimir(int.Parse(pDevolucionId.Value.ToString()));

                    frmDevoluciones frm = frmDevoluciones.GetInstance();
                    frm.LlenarGrid();

                    this.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void imprimir(int id)
        {
            rptDevolucionTicket oTicket = new rptDevolucionTicket();

            ReportViewer oViewer = new ReportViewer();

            oTicket.DataSource = oContext.p_rpt_devolucion(id).ToList();

            oViewer.ShowTicket(oTicket);
            //oViewer.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = devolucionId;

            imprimir(devolucionId);
        }

        private void uiFolioTocket_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarTicket();
            }
        }
    }
}
