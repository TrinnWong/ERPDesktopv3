using ConexionBD;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using ERP.Business.Tools;
using ERP.Common.Bascula;
using ERP.Common.Base;
using ERP.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Productos
{
    public partial class frmSobrantesRegistro : FormBaseXtraForm
    {
        public DateTime? dtProcess { get; set; }
        List<p_productos_sobrantes_grd_Result> lstGrid;
        doc_productos_sobrantes_registro productoSobrante;
        public bool habilitarFecha = false;
        int err = 0;
        string error = "";
        public frmSobrantesRegistro()
        {
            InitializeComponent();
        }

        private void uiSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void guardar()
        {
            try
            {
                
                uiGuardar.Text = "ESPERE......";
                
                Thread.Sleep(2000);
                lstGrid = (List<p_productos_sobrantes_grd_Result>)uiGrid.DataSource;
                oContext = new ERPProdEntities();

                oContext.Database.ExecuteSqlCommand(@"DELETE doc_productos_sobrantes_registro 
                                                    WHERE CONVERT(VARCHAR,CreadoEl,112)=CONVERT(VARCHAR,{0},112) AND 
                                                        SucursalId={1}", uiFecha.DateTime, puntoVentaContext.sucursalId);

                foreach (p_productos_sobrantes_grd_Result itemGrid in lstGrid)
                {
                    productoSobrante = new doc_productos_sobrantes_registro();

                    productoSobrante.CantidadSobrante = Convert.ToDouble(itemGrid.CantidadSobrante);
                    productoSobrante.CreadoEl = uiFecha.DateTime;
                    productoSobrante.CreadoPor = puntoVentaContext.usuarioId;
                    productoSobrante.Id = (oContext.doc_productos_sobrantes_registro.Max(m => (int?)m.Id) ?? 0) + 1;
                    productoSobrante.ProductoId = itemGrid.ProductoId;
                    productoSobrante.SucursalId = puntoVentaContext.sucursalId;

                    oContext.doc_productos_sobrantes_registro.Add(productoSobrante);
                    oContext.SaveChanges();

                }

                llenarGrid();

                ERP.Utils.MessageBoxUtil.ShowOk();

                uiGuardar.Text = "GUARDAR";

               

            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
        private void llenarGrid()
        {
            oContext = new ERPProdEntities();
            uiGrid.DataSource = oContext.p_productos_sobrantes_grd(puntoVentaContext.sucursalId, uiFecha.DateTime).ToList();

        }

        private void frmSobrantesRegistro_Load(object sender, EventArgs e)
        {
            try
            {
                oContext = new ERPProdEntities();
                if(dtProcess == null)
                {
                    dtProcess = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                }
                uiFecha.Enabled = habilitarFecha;
                uiFecha.DateTime = dtProcess?? DateTime.MinValue;

                if(ERP.Business.PreferenciaBusiness.AplicaPreferencia(puntoVentaContext.empresaId,
                    puntoVentaContext.sucursalId,
                    "SOB-HabilitarDevolucion",
                    puntoVentaContext.usuarioId) &&
                    oContext.cat_sucursales.Where(w=> w.NombreSucursal.ToUpper().Contains("COCINA")).Count() > 0)                
                {
                    colRepDevolucion.Visible = true;
                }
                else
                {
                    colRepDevolucion.Visible = false;
                }
                
                llenarGrid();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
           
        }

        private void uiTerminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("¿Está seguro(a) de continuar?, YA NO SERÁ POSIBLE REALIZAR CAMBIOS Y SE ACTUALIZARÁ EL INVENTARIO DE ACUERDO A LO CAPTURADO.EL PROCESO PUEDE TARDAR ALGUNOS MINUTOS.....",
                "Aviso",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oContext = new ERPProdEntities();
                    List<p_productos_sobrantes_grd_Result>  lstDevs = (List<p_productos_sobrantes_grd_Result>)uiGrid.DataSource;

                    guardar();

                    ObjectParameter pError = new ObjectParameter("pError", "");
                    oContext.p_doc_sobrantes_ajustes_inventario(this.puntoVentaContext.sucursalId,
                        uiFecha.DateTime, puntoVentaContext.usuarioId, pError);

                    if (pError.Value.ToString().Length > 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowError(pError.Value.ToString());
                    }
                    else
                    {
                        //DEVOLUCIONES
                        int sucursalDestino = oContext.cat_sucursales
                            .Where(w => w.NombreSucursal.Contains("COCINA")).FirstOrDefault() != null ?
                            oContext.cat_sucursales
                            .Where(w => w.NombreSucursal.Contains("COCINA")).FirstOrDefault().Clave :
                            0;
                        if(sucursalDestino > 0)
                        {
                            lstGrid = (List<p_productos_sobrantes_grd_Result>)uiGrid.DataSource;                            

                            doc_inv_movimiento entityInv = new doc_inv_movimiento();
                            entityInv.Activo = true;
                            entityInv.Autorizado = true;
                            entityInv.AutorizadoPor = puntoVentaContext.usuarioId;
                            entityInv.Cancelado = false;
                            entityInv.Comentarios = "DEVOLUCIÓN DE SUCURSAL";
                            entityInv.Consecutivo = 1;
                            entityInv.CreadoEl = ERP.Business.Tools.TimeTools.ConvertToTimeZoneDefault();
                            entityInv.CreadoPor = puntoVentaContext.usuarioId;
                            entityInv.FechaAutoriza = ERP.Business.Tools.TimeTools.ConvertToTimeZoneDefault();
                            entityInv.FechaCancelacion = null;
                            entityInv.FechaMovimiento = ERP.Business.Tools.TimeTools.ConvertToTimeZoneDefault();
                            entityInv.FolioMovimiento = entityInv.Consecutivo.ToString();
                            entityInv.CreadoEl = ERP.Business.Tools.TimeTools.ConvertToTimeZoneDefault();
                            entityInv.CreadoPor = puntoVentaContext.usuarioId;
                            entityInv.HoraMovimiento = ERP.Business.Tools.TimeTools.ConvertToTimeZoneDefault().TimeOfDay;
                            entityInv.ImporteTotal = 0;
                            entityInv.SucursalId = puntoVentaContext.sucursalId;
                            entityInv.SucursalDestinoId = sucursalDestino;
                            entityInv.SucursalOrigenId = puntoVentaContext.sucursalId;
                            entityInv.TipoMovimientoId = (int)ERP.Business.Enumerados.tipoMovimientoInventario
                                .SalidaPorTraspasoDev;


                            var resultAPI = ERP.Business.InventarioBusiness.GuardarTraspaso(ref entityInv,
                                lstDevs.Select(s => new doc_inv_movimiento_detalle()
                                {
                                    //Cantidad = s.CantidadDevolucionCocina,
                                    Comisiones = 0,
                                    Consecutivo = 0,
                                    CostoPromedio = 0,
                                    CreadoEl = DateTime.Now,
                                    ProductoId = s.ProductoId,
                                    PrecioNeto = 0,
                                    PrecioUnitario = 0

                                }).ToList(),
                                puntoVentaContext.usuarioId,
                                puntoVentaContext.empresaId,
                                oContext,true);

                            if (resultAPI.ok)
                            {
                                ERP.Utils.MessageBoxUtil.ShowOk();
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                ERP.Utils.MessageBoxUtil.ShowError(resultAPI.error);
                            }
                         }
                        else
                        {
                            ERP.Utils.MessageBoxUtil.ShowOk();
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                       

                       
                    }
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
            
        }

        private void uiGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(uiGridView.FocusedRowHandle >= 0)
            {
                p_productos_sobrantes_grd_Result row = (p_productos_sobrantes_grd_Result)uiGridView
                    .GetRow(uiGridView.FocusedRowHandle);

                if(row!= null)
                {
                    if (row.RequiereBascula)
                    {
                        frmBasculaDialog oForm = new frmBasculaDialog();

                        oForm.puntoVentaContext = this.puntoVentaContext;
                        oForm.productoDescripcion = row.Descripcion;
                        var result = oForm.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            uiGridView.SetRowCellValue(uiGridView.FocusedRowHandle,
                                   "CantidadSobrante", oForm.cantidad);
                        }
                    }
                    
                }
            }
        }

        private void uiGridView_ShowingEditor(object sender, CancelEventArgs e)
        {
            ColumnView view = (ColumnView)sender;

            if (uiGridView.FocusedRowHandle >= 0 && view.FocusedColumn.FieldName == "CantidadSobrante")
            {
                p_productos_sobrantes_grd_Result row = (p_productos_sobrantes_grd_Result)uiGridView
                    .GetRow(uiGridView.FocusedRowHandle);

                if (row.RequiereBascula)
                {
                    e.Cancel = true;
                }

            }
        }

        private void uiGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
           
        }
    }
}
