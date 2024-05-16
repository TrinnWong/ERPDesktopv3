using ConexionBD;
using ERP.Common.Base;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace ERPv1.Reportes
{
    public partial class frmEstadoCuenta : FormBaseXtraForm
    {
        private static frmEstadoCuenta _instance;
        string error = "";
        List<p_rpt_estado_cuenta_detalle_Result> lstResult;
        int err;
        public static frmEstadoCuenta GetInstance()
        {
            if (_instance == null) _instance = new frmEstadoCuenta();
            else _instance.BringToFront();
            return _instance;
        }

        public frmEstadoCuenta()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void exportarExcel()
        {
            try
            {
                LlenarGrid();

                //Creación de EXCEL
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage workbook = new ExcelPackage();
                ExcelWorksheet workSheet = workbook.Workbook.Worksheets.Add("VentasGastos");

                int rowIni = 1;


                var tipoMovimiento = lstResult.Where(w => w.Movimiento.Contains("Gasto") || w.Movimiento.Contains("Venta")).OrderBy(o => o.CargoAbono).Select(s => new { TipoMovimiento = s.Movimiento }).Distinct().ToList();

                foreach (var itemTipoMovimiento in tipoMovimiento)
                {
                    //Encabezado 
                    using (ExcelRange titulos = workSheet.Cells[String.Format("A{0}:G{0}", rowIni)])
                    {
                        titulos.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        titulos.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#203764"));
                        titulos.Style.Font.Bold = true;
                        titulos.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                        titulos.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    workSheet.Column(1).Width = 20;
                    workSheet.Column(2).Width = 20;
                    workSheet.Column(3).Width = 40;
                    workSheet.Column(4).Width = 25;
                    workSheet.Column(5).Width = 20;
                    workSheet.Column(6).Width = 20;
                    workSheet.Column(7).Width = 20;
                    workSheet.Cells[String.Format("A{0}", rowIni)].Value = "Tipo";
                    workSheet.Cells[String.Format("B{0}", rowIni)].Value = "Fecha";
                    workSheet.Cells[String.Format("C{0}", rowIni)].Value = "Sucursal";
                    workSheet.Cells[String.Format("D{0}", rowIni)].Value = "Movimiento";
                    workSheet.Cells[String.Format("E{0}", rowIni)].Value = "Detalle Movimiento";
                    workSheet.Cells[String.Format("F{0}", rowIni)].Value = "Total";
                    workSheet.Cells[String.Format("G{0}", rowIni)].Value = "Cargo/Abono";

                    rowIni++;

                    var filasExcel = this.lstResult.Where(w => w.Movimiento == itemTipoMovimiento.TipoMovimiento);

                    foreach (var itemFilaExcel in filasExcel)
                    {
                        workSheet.Cells[String.Format("A{0}", rowIni)].Value = itemFilaExcel.Tipo;
                        workSheet.Cells[String.Format("B{0}", rowIni)].Value = itemFilaExcel.Fecha.ToString("dd-MMM-yyyy").ToLower();
                        workSheet.Cells[String.Format("C{0}", rowIni)].Value = itemFilaExcel.Sucursal;
                        workSheet.Cells[String.Format("D{0}", rowIni)].Value = itemFilaExcel.Movimiento;
                        workSheet.Cells[String.Format("E{0}", rowIni)].Value = itemFilaExcel.DetalleMovimiento;
                        workSheet.Cells[String.Format("F{0}", rowIni)].Value = string.Format("{0:C2}", itemFilaExcel.Total);
                        workSheet.Cells[String.Format("G{0}", rowIni)].Value = (itemFilaExcel.CargoAbono ?? false) ? "Abono" : "Cargo";

                        rowIni++;
                    }

                    //Encabezado 
                    using (ExcelRange titulos = workSheet.Cells[String.Format("E{0}:F{0}", rowIni)])
                    {
                        titulos.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        titulos.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#203764"));
                        titulos.Style.Font.Bold = true;
                        titulos.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                        titulos.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    workSheet.Cells[String.Format("E{0}", rowIni)].Value = String.Format("Total {0}", itemTipoMovimiento.TipoMovimiento);
                    workSheet.Cells[String.Format("F{0}", rowIni)].Value = string.Format("{0:C2}", filasExcel.Sum(s => s.Total));

                    rowIni++;
                    rowIni++;
                }

                var datos1 = lstResult.Where(w => w.Movimiento.Contains("Venta") || w.Movimiento.Contains("Gasto")).ToList();

                //Fila Resummen

                decimal gastos = 0, ventas = 0, balance = 0, costoCompra = 0, utilidad = 0;

                gastos = datos1.Where(w => w.CargoAbono == false).Sum(s => s.Total) ?? 0;
                ventas = datos1.Where(w => w.CargoAbono == true).Sum(s => s.Total) ?? 0;
                balance = ventas + gastos;


                workSheet.Cells[String.Format("A{0}", rowIni)].Value = "Gastos";
                workSheet.Cells[String.Format("B{0}", rowIni)].Value = string.Format("{0:C2}", gastos);
                workSheet.Cells[String.Format("C{0}", rowIni)].Value = "Ventas";
                workSheet.Cells[String.Format("D{0}", rowIni)].Value = string.Format("{0:C2}", ventas);
                workSheet.Cells[String.Format("E{0}", rowIni)].Value = "Balance";
                workSheet.Cells[String.Format("F{0}", rowIni)].Value = string.Format("{0:C2}", balance);



                var compras = lstResult.Where(w => !w.Movimiento.Contains("Venta") && !w.Movimiento.Contains("Gasto") && w.CargoAbono == false).ToList();

                //Costo compra
                int sucursalid = Convert.ToInt32(uiSucursal.EditValue);
                DateTime fechaDel = uiDel.DateTime;
                DateTime fechaAl = uiAl.DateTime;
                var ventasRango = oContext.doc_ventas_detalle.Where(w => DbFunctions.TruncateTime(w.FechaCreacion) >= DbFunctions.TruncateTime(fechaDel) &&
                                    DbFunctions.TruncateTime(w.FechaCreacion) <= DbFunctions.TruncateTime(fechaAl) && w.doc_ventas.Activo == true && w.doc_ventas.SucursalId == sucursalid)
                    .ToList();

                decimal costoCompraTotal = ventasRango.Select(s => new {
                    costo =
                            s.cat_productos.cat_productos_existencias.Where(w1 => w1.SucursalId == sucursalid).Count() > 0 ?
                                 (s.cat_productos.cat_productos_existencias.Where(w1 => w1.SucursalId == sucursalid).FirstOrDefault().CostoCapturaUsuario ?? 0) == 0 ?
                                 (
                                   s.cat_productos.cat_productos_existencias.Where(w1 => w1.SucursalId == sucursalid).FirstOrDefault().CostoUltimaCompra == 0 ?
                                    s.cat_productos.cat_productos_existencias.Where(w1 => w1.SucursalId == sucursalid).FirstOrDefault().CostoPromedio : s.cat_productos.cat_productos_existencias.Where(w1 => w1.SucursalId == sucursalid).FirstOrDefault().CostoUltimaCompra
                                 ) : (s.cat_productos.cat_productos_existencias.Where(w1 => w1.SucursalId == sucursalid).FirstOrDefault().CostoCapturaUsuario ?? 0)
                            : 0
                }).Sum(s1 => s1.costo);

                rowIni++;
                workSheet.Cells[String.Format("E{0}", rowIni)].Value = "Costo de Compra";
                workSheet.Cells[String.Format("F{0}", rowIni)].Value = string.Format("{0:C2}", costoCompraTotal);

                utilidad = balance - costoCompraTotal;

                rowIni++;
                workSheet.Cells[String.Format("E{0}", rowIni)].Value = "Utilidad";
                workSheet.Cells[String.Format("F{0}", rowIni)].Value = string.Format("{0:C2}", utilidad);

                rowIni++;
                rowIni++;
                workSheet.Cells[String.Format("E{0}", rowIni)].Value = "Total Compras";
                workSheet.Cells[String.Format("F{0}", rowIni)].Value = string.Format("{0:C2}", compras.Sum(s => s.Total));

                rowIni++;
                rowIni++;


                foreach (var itemCompra in compras)
                {
                    workSheet.Cells[String.Format("E{0}", rowIni)].Value = itemCompra.DetalleMovimiento;
                    workSheet.Cells[String.Format("F{0}", rowIni)].Value = string.Format("{0:C2}", itemCompra.Total);
                    rowIni++;
                }

                // Mostrar el diálogo de guardado
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Guardar el archivo en la ubicación seleccionada
                        workbook.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                        MessageBox.Show("El archivo se ha guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al guardar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {

                ERP.Utils.MessageBoxUtil.ShowError("Ocurrió un error al obtener el reporte");
            }
          

        }

        public void LlenarGrid()
        {
            try
            {
                oContext = new ERPProdEntities();
                lstResult = oContext.p_rpt_estado_cuenta_detalle(Convert.ToInt32(uiSucursal.EditValue),"all", uiDel.DateTime, uiAl.DateTime,1).ToList();

                uiGrid.DataSource = lstResult;

                uiCargos.EditValue = lstResult.Where(w => w.CargoAbono == false).Sum(s => s.Total)*-1;
                uiVentas.EditValue = lstResult.Where(w => w.CargoAbono == true).Sum(s => s.Total);
                uiBalance.EditValue = uiVentas.Value - uiCargos.Value;
                uiGridView.ExpandAllGroups();

            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                               "ERP",
                                               this.Name,
                                               ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmEstadoCuenta_HelpButtonClicked(object sender, CancelEventArgs e)
        {

        }

        private void frmEstadoCuenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        public void LlenarSucursales()
        {
            try
            {
                oContext = new ERPProdEntities();

                uiSucursal.Properties.DataSource = ERP.Business.SucursalBusiness.ObtenSucursalesPorUsuario(this.puntoVentaContext.empresaId,this.puntoVentaContext.usuarioId);

            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                               "ERP",
                                               this.Name,
                                               ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmEstadoCuenta_Load(object sender, EventArgs e)
        {
            LlenarSucursales();
            uiDel.DateTime = DateTime.Now;
            uiAl.DateTime = DateTime.Now;
        }

        private void uiSucursal_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            exportarExcel();
        }
    }
}
