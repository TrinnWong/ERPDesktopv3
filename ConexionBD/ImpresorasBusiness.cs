using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class ImpresorasBusiness:BusinessObject
    {

        public string Validar(cat_impresoras entity, PuntoVentaContext puntoVentaContext)
        {
            string error = "";
            try
            {
                if(entity.NombreImpresora.Trim() == "")
                {
                    error = error + ".El nombre de la impresora es requerida";
                }

                if (entity.NombreRed.Trim() == "")
                {
                    error = error+".El nombre de la impresora es requerida";
                }
                if (entity.SucursalId == 0)
                {
                    error = error + ".La sucursal es requerida";
                }
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }
        public string Insertar(ref cat_impresoras entity, PuntoVentaContext puntoVentaContext)
        {
            string error = "";
            try
            {
                error = Validar(entity,puntoVentaContext);
                int id = oContext.cat_impresoras.Count() > 0 ?
                    oContext.cat_impresoras.Max(m => m.ImpresoraId) + 1 : 1;

                entity.ImpresoraId = (short)id;
                entity.Activa = true;
                entity.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                oContext.cat_impresoras.Add(entity);

                oContext.SaveChanges();
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }
            return error;
        }

        public string Actualizar(cat_impresoras entity, PuntoVentaContext puntoVentaContext)
        {
            string error = "";
            try
            {
                error = Validar(entity, puntoVentaContext);

                short id = entity.ImpresoraId;

                cat_impresoras entity2 = oContext.cat_impresoras
                    .Where(w => w.ImpresoraId == id).FirstOrDefault();

                entity2.Activa = entity.Activa;
                entity2.NombreImpresora = entity.NombreImpresora;
                entity2.NombreRed = entity.NombreRed;
                oContext.SaveChanges();


            }
            catch (Exception ex)
            {

                error = ex.Message;
            }
            return error;
        }


        public string Eliminar(cat_impresoras entity, PuntoVentaContext puntoVentaContext)
        {
            string error = "";
            try
            {
              

                short id = entity.ImpresoraId;

                cat_impresoras entity2 = oContext.cat_impresoras
                    .Where(w => w.ImpresoraId == id).FirstOrDefault();

                oContext.cat_impresoras.Remove(entity2);
                oContext.SaveChanges();


            }
            catch (Exception ex)
            {

                error = ex.Message;
            }
            return error;
        }

        public string CajasImpresoraUpd(cat_cajas_impresora entity, PuntoVentaContext puntoVentaContext)
        {
            string error = "";
            try
            {
                if(entity.CajaId == 0 || entity.ImpresoraId == 0)
                {
                    error = "La caja y la impresora es requerida";
                    return error;
                }

                if(entity.CajaImpresoraId == 0)
                {
                    entity.CajaImpresoraId = oContext.cat_cajas_impresora.Count() > 0 ?
                        oContext.cat_cajas_impresora.Max(m => m.CajaImpresoraId) + 1 : 1;

                    entity.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                    oContext.cat_cajas_impresora.Add(entity);

                    oContext.SaveChanges();
                }
                else
                {
                    int id = entity.CajaImpresoraId;
                    cat_cajas_impresora entityUpd = oContext.cat_cajas_impresora.Where(w => w.CajaImpresoraId == id).FirstOrDefault();

                    entityUpd.ImpresoraId = entity.ImpresoraId;

                    oContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }


        public string ComandaImpresoraUpd(cat_impresoras_comandas entity, PuntoVentaContext puntoVentaContext)
        {
            string error = "";
            try
            {
                if (entity.ImpresoraId == 0)
                {
                    error = "La impresora es requerida";
                    return error;
                }
                int sucursalId = puntoVentaContext.sucursalId;
                int id = entity.ImpresoraId;
                List<cat_impresoras_comandas> lstEntityDel = oContext.cat_impresoras_comandas
                    .Where(w => w.cat_impresoras.SucursalId == sucursalId).ToList();

                if(lstEntityDel.Count > 0)
                {
                    foreach (cat_impresoras_comandas itemDel in lstEntityDel)
                    {
                        oContext.cat_impresoras_comandas.Remove(itemDel);
                        oContext.SaveChanges();
                    }
                    
                }

                cat_impresoras_comandas entity1 = new cat_impresoras_comandas();

                entity1.ImpresoraId = entity.ImpresoraId;
                entity1.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                oContext.cat_impresoras_comandas.Add(entity1);

                oContext.SaveChanges();
                
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }

        public cat_impresoras ObtenerCajaImpresora(int cajaId)
        {
            oContext = new ERPProdEntities();
            return oContext.cat_impresoras
                .Where(
                w => w.cat_cajas_impresora.Where(s1 => s1.CajaId == cajaId).Count() > 0
                ).FirstOrDefault();
        }

        public cat_impresoras ObtenerComandaImpresora(int sucursalId)
        {
            return oContext.cat_impresoras
                .Where(w => w.SucursalId == sucursalId &&
                w.cat_impresoras_comandas != null).FirstOrDefault();
        }
    }
}
