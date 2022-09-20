using ERP.Models.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConexionBD
{
    public class ProduccionBusiness:BusinessObject
    {

        public  List<ProduccionDetalleModel> GetDetalleByProducto(int productoId)
        {
          return  oContext.cat_productos_base
                .Where(p=> p.ProductoId == productoId)
                 .Select(
                 s => new ProduccionDetalleModel()
                 {
                     Cantidad = s.Cantidad??0,
                     ProductoBaseId = s.ProductoBaseId,
                     ProductoId = s.ProductoId,
                     ProductoMateriaPrimaId = s.ProductoMateriaPrimaId,
                     Unidad = s.cat_productos1.cat_unidadesmed.Descripcion,
                     UnidadCocina = s.cat_unidadesmed.Descripcion,
                     UnidadConcinaId = s.UnidadCocinaId ?? 0,
                     Cocina = s.ParaCocina ?? false,
                     costoPromedio = (s.Cantidad ?? 0)* (
                                                         s.cat_productos.cat_productos_existencias
                                                         .Where(w => w.SucursalId == 1)
                                                         .FirstOrDefault() == null ? 0 :
                                                         s.cat_productos.cat_productos_existencias
                                                         .Where(w=> w.SucursalId == 1)
                                                         .FirstOrDefault().CostoPromedio),
                     Requerido = s.Requerido??false,
                     Orden = s.Orden??0,
                     GenerarSalidaVenta = s.GenerarSalidaVenta??false
                 }
                )
                .OrderBy(o=> o.Orden)
                .ToList();

        }

        public string InsertDetalle(int productoId, List<ProduccionDetalleModel> items)
        { 

            string error = "";
            try
            {
                if(productoId ==0)
                {
                    error = "Es necesario especificar el producto principal";
                }
                if(items.Where(w=> w.ProductoBaseId == productoId).Count() > 0)
                {
                    error = error +".No es posible utilizar el produto principal como produto base";
                }
                if(error.Length > 0)
                {
                    return error;
                }
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (var itemRow in items)
                    { 
                        
                        cat_productos_base entity = new cat_productos_base();

                        entity.ProductoMateriaPrimaId = oContext.cat_productos_base.Count() > 0 ?
                            oContext.cat_productos_base.Max(m => m.ProductoMateriaPrimaId) + 1 :1;
                        entity.ProductoId = productoId;
                        entity.ProductoBaseId = itemRow.ProductoBaseId;
                        entity.Cantidad = itemRow.Cantidad;
                        entity.CreadoEl = DateTime.Now.Date;
                        entity.ModificadoEl = DateTime.Now.Date;

                        oContext.cat_productos_base.Add(entity);
                        oContext.SaveChanges();
                     }
                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                error= ex.Message;

                
            }

            return error;
        }

        public string InsertDetalle(int productoId,ref ProduccionDetalleModel itemRow)
        {

            string error = "";
            try
            {
                int ProductoBaseId = itemRow.ProductoBaseId;
                if (productoId == 0)
                {
                    error = "Es necesario especificar el producto principal";
                }
                if (itemRow.ProductoBaseId == productoId)
                {
                    error = error + ".No es posible utilizar el produto principal como produto base";
                }
                if(itemRow.Cantidad == 0)
                {
                    error = error + ".La cantidad debe de ser mayor a cero";
                }
                if(oContext.cat_productos_base
                    .Where(
                        w=> w.ProductoBaseId == ProductoBaseId &&
                        w.ProductoId == productoId
                    ).Count() >0 && itemRow.ProductoMateriaPrimaId == 0)
                {
                    error = error + ".No se pueden duplicar productos base";
                }


                if (error.Length > 0)
                {
                    return error;
                }
                using (TransactionScope scope = new TransactionScope())
                {
                    int ProductoMateriaPrimaId = itemRow.ProductoMateriaPrimaId;

                    if (itemRow.ProductoMateriaPrimaId == 0)
                    {

                        cat_productos_base entity = new cat_productos_base();

                        entity.ProductoMateriaPrimaId = oContext.cat_productos_base.Count() > 0 ?
                            oContext.cat_productos_base.Max(m => m.ProductoMateriaPrimaId) + 1 : 1;
                        entity.ProductoId = productoId;
                        entity.ProductoBaseId = itemRow.ProductoBaseId;
                        entity.Cantidad = itemRow.Cantidad;
                        entity.CreadoEl = DateTime.Now.Date;
                        entity.ModificadoEl = DateTime.Now.Date;
                        entity.UnidadCocinaId = itemRow.UnidadConcinaId;
                        entity.ParaCocina = itemRow.Cocina;
                        entity.Requerido = itemRow.Requerido;
                        entity.Orden = itemRow.Orden;
                        entity.GenerarSalidaVenta = itemRow.GenerarSalidaVenta;
                        oContext.cat_productos_base.Add(entity);

                        itemRow.ProductoMateriaPrimaId = entity.ProductoMateriaPrimaId;
                        oContext.SaveChanges();

                    }
                    else {
                        cat_productos_base entity = oContext.cat_productos_base
                            .Where(w => w.ProductoMateriaPrimaId == ProductoMateriaPrimaId).FirstOrDefault();

                                                                  
                       
                        entity.ProductoBaseId = itemRow.ProductoBaseId;
                        entity.Cantidad = itemRow.Cantidad;
                        entity.ModificadoEl = DateTime.Now.Date;
                        entity.UnidadCocinaId = itemRow.UnidadConcinaId;
                        entity.ParaCocina = itemRow.Cocina;
                        entity.Requerido = itemRow.Requerido;
                        entity.Orden = itemRow.Orden;
                        entity.GenerarSalidaVenta = itemRow.GenerarSalidaVenta;
                        oContext.SaveChanges();


                    }

                    //
                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                error = ex.Message;


            }

            return error;
        }

        public string DeleteDetalle(int productoMateriaPrimaId)
        {
            string error = "";
            try
            {
                cat_productos_base entity = oContext.cat_productos_base
                           .Where(w => w.ProductoMateriaPrimaId == productoMateriaPrimaId).FirstOrDefault();

                oContext.cat_productos_base.Remove(entity);

                oContext.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                
            }
            return error;
        }
    }
}
