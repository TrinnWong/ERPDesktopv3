using ConexionBD;
using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class DeclaracionFondoBusiness:BusinessObject
    {
        public  doc_declaracion_fondo_inicial GuardaFondoInicial(List<DeclaracionFondoModel> datos,
            int usuarioId,
            int sucursalId,
            int cajaId,
            ref string error)
        {
            doc_declaracion_fondo_inicial result = null;
            try
            {
                if (datos != null)
                {
                    if(datos.Count() > 0)
                    {
                        oContext = new ERPProdEntities();
                        using (DbContextTransaction transaction = oContext.Database.BeginTransaction())
                        {
                            try
                            {
                                result = new doc_declaracion_fondo_inicial();

                                result.CreadoEl = DateTime.Now;
                                result.CreadoPor = usuarioId;
                                result.DeclaracionFondoId = (oContext.doc_declaracion_fondo_inicial
                                    .Max(m => (int?)m.DeclaracionFondoId) ?? 0) + 1;
                                result.SucursalId = sucursalId;
                                result.CajaId = cajaId;
                                result.Total = datos.Sum(s => s.total);
                                oContext.doc_declaracion_fondo_inicial.Add(result);
                                oContext.SaveChanges();

                                foreach (DeclaracionFondoModel itemDetalle in datos)
                                {
                                    doc_declaracion_fondo_inicial_detalle entityDet = new doc_declaracion_fondo_inicial_detalle();

                                    entityDet.Cantidad = itemDetalle.cantidad??0;
                                    entityDet.CreadoEl = DateTime.Now;
                                    entityDet.CreadoPor = usuarioId;
                                    entityDet.DeclaracionFondoDetalleId = (oContext.doc_declaracion_fondo_inicial_detalle
                                    .Max(m => (int?)m.DeclaracionFondoDetalleId) ?? 0) + 1;
                                    entityDet.DeclaracionFondoId = result.DeclaracionFondoId;
                                    entityDet.DenominacionId = itemDetalle.clave;
                                    entityDet.Total = itemDetalle.total??0;

                                    oContext.doc_declaracion_fondo_inicial_detalle.Add(entityDet);
                                    oContext.SaveChanges();


                                }


                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                    "ERP",
                                    "DeclaracionFondoBusiness.GuardaFondoInicial",
                                    ex);

                                error = ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());

                                return null;
                            }
                        }
                        
                    }
                    else
                    {
                        error = "No hay información para procesar";
                    }

                }
                else {
                    error = "No hay información para procesar";
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                    "ERP",
                                    "DeclaracionFondoBusiness.GuardaFondoInicial",
                                    ex);

                error = ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());
            }

            return result;
        }
    }
}
