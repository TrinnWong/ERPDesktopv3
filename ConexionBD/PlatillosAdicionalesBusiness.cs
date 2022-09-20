using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class PlatillosAdicionalesBusiness:BusinessObject
    {
        public string Insertar(cat_rest_platillo_adicionales entity, PuntoVentaContext puntoVentaContext)
        {
            string error = "";
            try
            {

                int id = entity.Id;
                if(entity.Descripcion.Trim().Length == 0)
                {
                    error = "La descripción es requerida";
                }

             

                if(error.Length > 0)
                {
                    return error;
                }

                entity.Id = oContext.cat_rest_platillo_adicionales.Count() > 0 ?
                    oContext.cat_rest_platillo_adicionales.Max(m => m.Id) + 1 : 1;
                entity.Activo = true;
                entity.CreadoPor = puntoVentaContext.usuarioId;
                entity.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                oContext.cat_rest_platillo_adicionales.Add(entity);
                oContext.SaveChanges();

            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }


        public string Actualizar(cat_rest_platillo_adicionales entity)
        {
            string error = "";
            try
            {

                if (entity.Descripcion.Trim().Length == 0)
                {
                    error = "La descripción es requerida";
                }

                if (error.Length > 0)
                {
                    return error;
                }

                int ID = entity.Id;

                cat_rest_platillo_adicionales entityUpd = oContext.cat_rest_platillo_adicionales
                    .Where(w => w.Id == ID).FirstOrDefault();

                entityUpd.Descripcion = entity.Descripcion;
                entityUpd.MostrarSiempre = entity.MostrarSiempre;
                entityUpd.Activo = entity.Activo;
                

                oContext.SaveChanges();

            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }


        public string Eliminar(cat_rest_platillo_adicionales entity)
        {
            string error = "";
            try
            {
                int id = entity.Id;
                if (
                   oContext.cat_rest_platillo_adicionales_sfam
                   .Where(w => w.PlatilloAdicionalId == id).Count() > 0
                   )
                {
                    error = "Es necesario eliminar las subfamilias asignadas";
                }

                if (error.Length > 0)
                {
                    return error;
                }

                int ID = entity.Id;

                cat_rest_platillo_adicionales entityUpd = oContext.cat_rest_platillo_adicionales
                    .Where(w => w.Id == ID).FirstOrDefault();

                oContext.cat_rest_platillo_adicionales.Remove(entityUpd);


                oContext.SaveChanges();

            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }

        public string InsertarSubfam(cat_rest_platillo_adicionales_sfam entity, PuntoVentaContext puntoVentaContext)
        {
            string error = "";
            try
            {
                oContext = new ERPProdEntities();

                if (entity.SubfamiliaId == 0)
                {
                    error = "La subfamilia es requerida";
                }

                if (error.Length > 0)
                {
                    return error;
                }
               
                entity.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                
                oContext.cat_rest_platillo_adicionales_sfam.Add(entity);
                oContext.SaveChanges();

            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }

        public string EliminarsUBFAM(cat_rest_platillo_adicionales_sfam entity)
        {
            string error = "";
            try
            {


                int platilloId = entity.PlatilloAdicionalId;
                int subfamiliaId = entity.SubfamiliaId;

                cat_rest_platillo_adicionales_sfam entityUpd = oContext.cat_rest_platillo_adicionales_sfam
                    .Where(w => w.SubfamiliaId == subfamiliaId && w.PlatilloAdicionalId == platilloId).FirstOrDefault();

                oContext.cat_rest_platillo_adicionales_sfam.Remove(entityUpd);


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
