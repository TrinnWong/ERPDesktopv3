using ConexionBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class PagoBusiness: BusinessObject
    {
        CargoBusiness oCargoB;
        int err = 0;
        public PagoBusiness()
        {
            oContext = new ERPProdEntities();
            oCargoB = new CargoBusiness();
        }
        public doc_pagos Guardar(doc_pagos datos,int usuarioId,int sucursalId, ref string error)
        {
            doc_pagos entityNew = new doc_pagos();
            error = "";
            try
            {
                oContext = new ERPProdEntities();
                entityNew.PagoId = (oContext.doc_pagos.Max(m => (int?)m.PagoId) ?? 0) + 1;
                entityNew.Activo = true;
                entityNew.CreadoEl = DateTime.Now;
                entityNew.CreadoPor = usuarioId;
                entityNew.CargoId = datos.CargoId;
                entityNew.ClienteId = datos.ClienteId;
                entityNew.FechaPago = datos.FechaPago;
                entityNew.Monto = datos.Monto;
                entityNew.FormaPagoId = datos.FormaPagoId;
                oContext.doc_pagos.Add(entityNew);
                oContext.SaveChanges();

                if(entityNew.CargoId > 0)
                {
                    oCargoB.CalcularSaldosPagos(entityNew.CargoId ?? 0);
                }
                
                SisBitacoraBusiness.GuardaBitacoraGeneral("INS",sucursalId, entityNew, usuarioId);
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                      "ERP",
                                      "BasculasBusiness",
                                      ex);

                error = ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());
            }

            return entityNew;
        }

        public bool Eliminar(int pagoId,int usuarioId,int sucursalId,ref string error)
        {
            try
            {
                doc_pagos entityPago = oContext.doc_pagos
                    .Where(w => w.PagoId == pagoId).FirstOrDefault();

                if(entityPago != null)
                {
                    int? cargoId = entityPago.CargoId;
                    oContext.doc_pagos.Remove(entityPago);
                    oContext.SaveChanges();

                    if (cargoId > 0)
                    {
                        oCargoB.CalcularSaldosPagos(cargoId ?? 0);
                    }

                    SisBitacoraBusiness.GuardaBitacoraGeneral("DEL",sucursalId, entityPago, usuarioId);
                }
                return true;
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                     "ERP",
                                     "BasculasBusiness",
                                     ex);

                error = ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());

                return false;
            }
        }
    }
}
