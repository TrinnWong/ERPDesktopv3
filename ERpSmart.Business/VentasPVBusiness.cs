using ConexionBD;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class VentasPVBusiness
    {

        public static string ObtenFolioVentaSiguiente(int sucursalId)
        {
            int folio = 0;
            string serie = ObtenSerie();
            ERPProdEntities oContext = new ERPProdEntities();

            var folioStr = oContext.doc_ventas
                .Where(w => w.Serie == serie).Max(f => f.Folio);

            int.TryParse(folioStr, out folio);

            return (folio + 1).ToString();
        }

        public static string ObtenSerie()
        {
            ERPProdEntities oContext = new ERPProdEntities();

            return oContext.cat_configuracion.FirstOrDefault().SerieTicketVenta;
        }

        public static ResultAPIModel GuardaVentaCancelada(List<ConexionBD.ProductoModel0> lstProductos,
            string moticoCancelacion,
            int usuarioId,
            int cajaId,
            int sucursalId)
        {
            int err = 0;
            ResultAPIModel result = new ResultAPIModel();
            cat_basculas_configuracion configBascula = null;
            try
            {
                using (ERPProdEntities oContext = new ERPProdEntities())
                {
                    using (var dbContextTransaction = oContext.Database.BeginTransaction())
                    {
                        try
                        {
                            doc_ventas entityVenta = new doc_ventas();

                            entityVenta.Activo = false;
                            entityVenta.CajaId = cajaId;
                            entityVenta.Cambio = 0;
                            entityVenta.ClienteId = null;
                            entityVenta.DescuentoEnPartidas = 0;
                            entityVenta.DescuentoVentaSiNo = false;
                            entityVenta.Facturar = false;
                            entityVenta.Fecha = DateTime.Now;
                            entityVenta.FechaCancelacion = DateTime.Now;
                            entityVenta.FechaCreacion = DateTime.Now;
                            entityVenta.Folio = ObtenFolioVentaSiguiente(sucursalId);
                            entityVenta.Impuestos = 0;
                            entityVenta.MontoDescuentoVenta = 0;
                            entityVenta.MotivoCancelacion = moticoCancelacion;
                            entityVenta.PorcDescuentoVenta = 0;
                            entityVenta.Rec = false;
                            entityVenta.Serie = ObtenSerie();
                            entityVenta.SubTotal = 0;
                            entityVenta.SucursalId = sucursalId;
                            entityVenta.TotalDescuento = 0;
                            entityVenta.TotalRecibido = 0;
                            entityVenta.TotalVenta = lstProductos.Sum(s => s.total);
                            entityVenta.UsuarioCancelacionId = usuarioId;
                            entityVenta.UsuarioCreacionId = usuarioId;
                            entityVenta.VentaId = (oContext.doc_ventas
                                .Max(m => (int?)m.VentaId) ?? 0) + 1;

                            oContext.doc_ventas.Add(entityVenta);
                            oContext.SaveChanges();


                            foreach (var itemDet in lstProductos)
                            {
                                doc_ventas_detalle entityDet = new doc_ventas_detalle();

                                entityDet.Cantidad = itemDet.cantidad;
                                entityDet.CargoAdicionalId = null;
                                entityDet.CargoDetalleId = null;
                                entityDet.Descripcion = itemDet.descripcion;
                                entityDet.Descuento = 0;
                                entityDet.FechaCreacion = DateTime.Now;
                                entityDet.Impuestos = 0;
                                entityDet.ParaLlevar = false;
                                entityDet.ParaMesa = false;
                                entityDet.PorcDescuneto = 0;
                                entityDet.PrecioUnitario = itemDet.precioUnitario;
                                entityDet.ProductoId = itemDet.productoId;
                                entityDet.PromocionCMId = null;
                                entityDet.TasaIVA = 0;
                                entityDet.TipoDescuentoId = null;
                                entityDet.Total = itemDet.total;
                                entityDet.UsuarioCreacionId = usuarioId;
                                entityDet.VentaDetalleId = (oContext.doc_ventas_detalle
                                    .Max(m => (long?)m.VentaDetalleId) ?? 0) + 1;
                                entityDet.VentaId = entityVenta.VentaId;


                                oContext.doc_ventas_detalle.Add(entityDet);
                                oContext.SaveChanges();
                            }

                            if (configBascula == null)
                            {
                                configBascula = BasculasBusiness.GetConfiguracionPCLocal(usuarioId);
                            }
                            //Bitácora Báscula
                            foreach (var itemBascula in lstProductos.Where(w => w.tieneBascula))
                            {
                                ERP.Business.BasculasBusiness.InsertBitacora(configBascula.BasculaId, sucursalId,
                                usuarioId, itemBascula.cantidad,
                                (int)ERP.Business.Enumerados.tipoBasculaBitacora.CancelacionVentaPV,
                                itemBascula.productoId, null);
                            }
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {

                            dbContextTransaction.Rollback();

                            err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                                "ERP",
                                                "ERP.VentaBusiness.GuardaVentaCancelada",
                                                ex);

                            result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                                 "ERP",
                                                 "ERP.VentaBusiness.GuardaVentaCancelada",
                                                 ex);

                result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
            }

            return result;
        }
    }
}
