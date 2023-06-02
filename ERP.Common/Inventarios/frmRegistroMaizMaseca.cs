using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Business;
using ERP.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Inventarios
{
    public partial class frmRegistroMaizMaseca : FormBaseXtraForm
    {

        private static frmRegistroMaizMaseca _instance;
        public static frmRegistroMaizMaseca GetInstance()
        {
            if (_instance == null) _instance = new frmRegistroMaizMaseca();
            else _instance.BringToFront();
            return _instance;
        }
        string error = "";
        ConexionBD.doc_maiz_maseca_rendimiento entitySelect;
        int err = 0;
        public frmRegistroMaizMaseca()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            try
            {
                uiFecha.EditValue = DateTime.Now;
                uiMaizSacos.EditValue = 0;
                uiMasecaSacos.EditValue = 0;

                entitySelect = new doc_maiz_maseca_rendimiento();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(
                     puntoVentaContext.usuarioId,
                            "ERP",
                            this.Name,
                            ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void Guardar()
        {
            try
            {
                oContext = new ERPProdEntities();
                double kgTortillaMaiz = 0;
                double KgTortillaMaseca = 0;
                int productoMaizSacoId = 0;
                int productoMasecaSacoId = 0;

                if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                   this.puntoVentaContext.sucursalId, "MAIZ-SACO-CLAVE", this.puntoVentaContext.usuarioId, ref error))
                {
                    if (error.Length == 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario configurar las preferencias MAIZ-SACO-CLAVE y MASECA-SACO-CLAVE");
                        return;
                    }
                    else
                    {
                        productoMaizSacoId = oContext.cat_productos.Where(w => w.Clave == error).FirstOrDefault().ProductoId;
                    }
                }
                else 
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario configurar las preferencias MAIZ-SACO-CLAVE y MASECA-SACO-CLAVE");
                    return;
                }

                if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                   this.puntoVentaContext.sucursalId, "MASECA-SACO-CLAVE", this.puntoVentaContext.usuarioId, ref error))
                {
                    if (error.Length == 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario configurar las preferencias MAIZ-SACO-CLAVE y MASECA-SACO-CLAVE");
                        return;
                    }
                    else
                    {
                        productoMasecaSacoId = oContext.cat_productos.Where(w => w.Clave == error).FirstOrDefault().ProductoId;
                    }
                }
                else 
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario configurar las preferencias MAIZ-SACO-CLAVE y MASECA-SACO-CLAVE");
                    return;
                }


                if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                   this.puntoVentaContext.sucursalId, "PROD-EquivalenciaMaizSacoTortillaKg", this.puntoVentaContext.usuarioId, ref error))
                {
                    kgTortillaMaiz = Convert.ToDouble(error);
                }

                if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                   this.puntoVentaContext.sucursalId, "PROD-EquivalenciaMasecaSacoTortillaKg", this.puntoVentaContext.usuarioId, ref error))
                {
                    KgTortillaMaseca = Convert.ToDouble(error);
                }

                if (kgTortillaMaiz <= 0 || KgTortillaMaseca <= 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario configurar la preferencia EquivalenciaMaizSacoTortillaKg y EquivalenciaMasecaSacoTortillaKg, por favor avise al administrador");
                    return;
                }


                if (XtraMessageBox.Show("¿Está seguro(a) de continuar?, ya no será posible modificar la infórmación capturada", "Aviso"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                int sucursalId = puntoVentaContext.sucursalId;
                DateTime timeBD = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                using (oContext = new ERPProdEntities())
                {

                    using (var dbContextTransaction = oContext.Database.BeginTransaction())
                    {
                        try
                        {
                            doc_maiz_maseca_rendimiento entityUpd = new doc_maiz_maseca_rendimiento();

                            if (entitySelect.Id == 0)
                            {
                                entityUpd.Id = (oContext.doc_maiz_maseca_rendimiento
                                    .Max(m => (int?)m.Id) ?? 0) + 1;
                                entityUpd.SucursalId = puntoVentaContext.sucursalId;
                                entityUpd.MaizSacos = Convert.ToDouble(uiMaizSacos.EditValue);
                                entityUpd.MasecaSacos = Convert.ToDouble(uiMasecaSacos.EditValue);
                                entityUpd.TortillaMaizRendimiento = kgTortillaMaiz * Convert.ToDouble(uiMaizSacos.EditValue);
                                entityUpd.TortillaMasecaRendimiento = KgTortillaMaseca * Convert.ToDouble(uiMasecaSacos.EditValue);
                                entityUpd.TortillaTotalRendimiento = entityUpd.TortillaMaizRendimiento + entityUpd.TortillaMasecaRendimiento;
                                entityUpd.CreadoEl = DateTime.Now;
                                entityUpd.CreadoPor = puntoVentaContext.usuarioId;
                                entityUpd.Fecha = uiFecha.DateTime;
                                entityUpd.ModificadoEl = DateTime.Now;
                                entityUpd.ModificadoPor = puntoVentaContext.usuarioId;
                                oContext.doc_maiz_maseca_rendimiento.Add(entityUpd);
                                oContext.SaveChanges();


                                //Encabezado MOv Inventario
                                doc_inv_movimiento entityMov = new doc_inv_movimiento();

                                entityMov.HoraMovimiento = DateTime.Now.TimeOfDay;
                                entityMov.Activo = true;
                                entityMov.Autorizado = true;
                                entityMov.AutorizadoPor = puntoVentaContext.usuarioId;
                                entityMov.Cancelado = false;
                                entityMov.Comentarios = "";
                                entityMov.Consecutivo = (oContext.doc_inv_movimiento
                                                    .Where(w => w.SucursalId == sucursalId)
                                                    .Max(m => (int?)m.Consecutivo) ?? 0) + 1;
                                entityMov.CreadoEl = DateTime.Now;
                                entityMov.CreadoPor = puntoVentaContext.usuarioId;
                                entityMov.FechaAutoriza = DateTime.Now;
                                entityMov.FechaCancelacion = null;
                                entityMov.FechaMovimiento = DateTime.Now;
                                entityMov.FolioMovimiento = entityMov.Consecutivo.ToString();
                                entityMov.HoraMovimiento = ERP.Business.Tools.TimeTools.ConvertToTimeZoneDefault().TimeOfDay;
                                entityMov.ImporteTotal = 0;
                                entityMov.SucursalId = puntoVentaContext.sucursalId;
                                entityMov.TipoMovimientoId = (int)ERP.Business.Enumerados.tipoMovimientoInventario.AjustePorSalida;                                
                                entityMov.MovimientoId = (oContext.doc_inv_movimiento.Max(m => (int?)m.MovimientoId)??0)+1;

                                oContext.doc_inv_movimiento.Add(entityMov);
                                oContext.SaveChanges();

                                //mAIZ Sacos
                                doc_inv_movimiento_detalle entityMovDet = new doc_inv_movimiento_detalle();

                                entityMovDet.Cantidad = Convert.ToDecimal(uiMaizSacos.EditValue);
                                entityMovDet.Comisiones = 0;
                                entityMovDet.Consecutivo = 1;
                                entityMovDet.CostoPromedio = 0;
                                entityMovDet.CostoUltimaCompra = 0;
                                entityMovDet.CreadoEl = ERP.Business.Tools.TimeTools.ConvertToTimeZoneDefault();
                                entityMovDet.CreadoPor = puntoVentaContext.usuarioId;
                                entityMovDet.Disponible = 0;
                                entityMovDet.Flete = 0;
                                entityMovDet.Importe = 0;
                                entityMovDet.MovimientoDetalleId = (oContext.doc_inv_movimiento_detalle.Max(m => (int?)m.MovimientoDetalleId) ?? 0) + 1;
                                entityMovDet.MovimientoId = entityMov.MovimientoId;
                                entityMovDet.PrecioNeto = 0;
                                entityMovDet.PrecioUnitario = 0;
                                entityMovDet.ProductoId = productoMaizSacoId;
                                entityMovDet.SubTotal = 0;
                                entityMovDet.ValCostoPromedio = 0;
                                entityMovDet.ValCostoUltimaCompra = 0;
                                entityMovDet.ValorMovimiento = 0;

                                oContext.doc_inv_movimiento_detalle.Add(entityMovDet);
                                oContext.SaveChanges();


                                //mASECA Sacos
                                 entityMovDet = new doc_inv_movimiento_detalle();

                                entityMovDet.Cantidad = Convert.ToDecimal(uiMasecaSacos.EditValue);
                                entityMovDet.Comisiones = 0;
                                entityMovDet.Consecutivo = 1;
                                entityMovDet.CostoPromedio = 0;
                                entityMovDet.CostoUltimaCompra = 0;
                                entityMovDet.CreadoEl = ERP.Business.Tools.TimeTools.ConvertToTimeZoneDefault();
                                entityMovDet.CreadoPor = puntoVentaContext.usuarioId;
                                entityMovDet.Disponible = 0;
                                entityMovDet.Flete = 0;
                                entityMovDet.Importe = 0;
                                entityMovDet.MovimientoDetalleId = (oContext.doc_inv_movimiento_detalle.Max(m => (int?)m.MovimientoDetalleId) ?? 0) + 1;
                                entityMovDet.MovimientoId = entityMov.MovimientoId;
                                entityMovDet.PrecioNeto = 0;
                                entityMovDet.PrecioUnitario = 0;
                                entityMovDet.ProductoId = productoMasecaSacoId;
                                entityMovDet.SubTotal = 0;
                                entityMovDet.ValCostoPromedio = 0;
                                entityMovDet.ValCostoUltimaCompra = 0;
                                entityMovDet.ValorMovimiento = 0;

                                oContext.doc_inv_movimiento_detalle.Add(entityMovDet);
                                oContext.SaveChanges();



                            }
                            else
                            {
                                entityUpd = oContext.doc_maiz_maseca_rendimiento
                                    .Where(w => w.Id == entitySelect.Id).FirstOrDefault();

                                entityUpd.MaizSacos = Convert.ToDouble(uiMaizSacos.EditValue);
                                entityUpd.MasecaSacos = Convert.ToDouble(uiMasecaSacos.EditValue);
                                entityUpd.ModificadoEl = DateTime.Now;
                                entityUpd.ModificadoPor = puntoVentaContext.usuarioId;
                                entityUpd.TortillaMaizRendimiento = kgTortillaMaiz * Convert.ToDouble(uiMaizSacos.EditValue);
                                entityUpd.TortillaMasecaRendimiento = KgTortillaMaseca * Convert.ToDouble(uiMasecaSacos.EditValue);
                                entityUpd.TortillaTotalRendimiento = entityUpd.TortillaMaizRendimiento + entityUpd.TortillaMasecaRendimiento;
                                entityUpd.Fecha = uiFecha.DateTime;
                                oContext.SaveChanges();
                            }



                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {

                            dbContextTransaction.Rollback();
                            err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                   "ERP",
                                    this.Name,
                                   ex);

                            ERP.Utils.MessageBoxUtil.ShowErrorBita(err); 
                        }
                    }
                }

                
                Limpiar();
                LoadGrid();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(
                     puntoVentaContext.usuarioId,
                            "ERP",
                            this.Name,
                            ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmRegistroMaizMaseca_Load(object sender, EventArgs e)
        {
            entitySelect = new ConexionBD.doc_maiz_maseca_rendimiento();
            Limpiar();
            LoadGrid();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        

        private void repBtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    entitySelect = (doc_maiz_maseca_rendimiento)uiGridView.GetRow(uiGridView.FocusedRowHandle);
                    
                    uiMaizSacos.EditValue = entitySelect.MaizSacos;
                    uiMasecaSacos.EditValue = entitySelect.MasecaSacos;
                    uiFecha.EditValue = entitySelect.Fecha;
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(
                     puntoVentaContext.usuarioId,
                            "ERP",
                            this.Name,
                            ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void repBtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (uiGridView.FocusedRowHandle >= 0)
                {
                    if(XtraMessageBox.Show("¿Está seguro(a) de continuar?","Aviso",
                        MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        entitySelect = (doc_maiz_maseca_rendimiento)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                        doc_maiz_maseca_rendimiento entityDel = oContext.doc_maiz_maseca_rendimiento
                            .Where(w => w.Id == entitySelect.Id).FirstOrDefault();

                        oContext.doc_maiz_maseca_rendimiento.Remove(entityDel);
                        oContext.SaveChanges();

                        Limpiar();
                    }
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(
                   puntoVentaContext.usuarioId,
                          "ERP",
                          this.Name,
                          ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LoadGrid()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiGrid.DataSource = oContext.doc_maiz_maseca_rendimiento
                    .Where(w => w.SucursalId == puntoVentaContext.sucursalId).ToList();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(
                      puntoVentaContext.usuarioId,
                             "ERP",
                             this.Name,
                             ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmRegistroMaizMaseca_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
