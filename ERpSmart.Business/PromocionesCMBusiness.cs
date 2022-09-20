using ConexionBD;
using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class PromocionesCMBusiness : BusinessObject
    {
        public string InsertarActualizar(ref doc_promociones_cm entity, PuntoVentaContext context)
        {
            string error = "";
            try
            {
                DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                if(fechaActual > entity.FechaVigencia && entity.PromocionCMId==0)
                {
                    error = "La fecha de vigencia debe de ser mayor";
                }
                if(entity.NombrePromocion.Length == 0)
                {
                    error = error + "|Es necesario especificar un nombre a la promoción";
                }
                if(entity.Lunes ==false && 
                    entity.Martes == false &&
                    entity.Miercoles == false &&
                    entity.Jueves == false &&
                    entity.Viernes == false &&
                    entity.Sabado == false &&
                    entity.Domingo == false)
                {
                    error = error + "|Es necesario seleccionar por lo menos un día de la semana";
                }

                if(error.Length > 0)
                {
                    return error;
                }

                ObjectParameter pPromocionCMId = new ObjectParameter("pPromocionCMId", entity.PromocionCMId);

                oContext.p_doc_promociones_cm_ins_upd(pPromocionCMId, entity.SucursalId, entity.NombrePromocion, entity.FechaVigencia,
                    entity.HoraVigencia, entity.Lunes, entity.Martes, entity.Miercoles, entity.Jueves, entity.Viernes, entity.Sabado, entity.Domingo,
                    context.usuarioId, entity.Activo);

                entity.PromocionCMId = int.Parse(pPromocionCMId.Value.ToString());
            }
            catch (Exception ex)
            {
                error = ex.Message;
                
            }

            return error;
        }

        public string InsertarActualizarDetalle(ref doc_promociones_cm_detalle entity, PuntoVentaContext context)
        {
            string error = "";

            try
            {
                if(entity.ProductoId <= 0)
                {
                    error = "No se ha seleccionado un producto";
                }
                if (entity.CantidadCompraMinima <= 0)
                {
                    error = error + "|La cantidad mínima debe de ser mayor a cero";
                }
                if (entity.CantidadCobro > entity.CantidadCompraMinima)
                {
                    error = error + "|La cantidad a pagar no puede ser mayor a la de la compra mínima";
                }
                int p = entity.ProductoId;
                int i = entity.PromocionCMId;
                int iDet = entity.PromocionCMDetId;
                if(
                    oContext.doc_promociones_cm_detalle
                    .Where(w=> w.ProductoId ==p && w.PromocionCMId ==i
                    && w.PromocionCMDetId != iDet
                    ).Count() > 0
                    )
                {
                    error = error + "|No se puede agregar el mismo producto";
                }
                if(error.Length > 0)
                {
                    return error;
                }

                ObjectParameter pPromocionCMDetId = new ObjectParameter("pPromocionCMDetId", entity.PromocionCMDetId);
                oContext.p_doc_promociones_cm_detalle(pPromocionCMDetId,entity.PromocionCMId, entity.ProductoId, entity.CantidadCompraMinima, entity.CantidadCobro);

                entity.PromocionCMDetId = int.Parse(pPromocionCMDetId.Value.ToString());
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }
            return error;
        }
    }
}
