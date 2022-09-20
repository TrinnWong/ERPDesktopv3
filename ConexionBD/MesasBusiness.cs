using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class MesasBusiness:BusinessObject
    {
        public List<cat_rest_mesas> GETBySucursal(int suscursalId)
        {
            oContext = new ERPProdEntities();
            return oContext.cat_rest_mesas.Where(w => w.SucursalId == suscursalId)
                .ToList();

        }

        public string ValidarMesa(cat_rest_mesas entity)
        {
            string error = "";
            if (
                   entity.SucursalId <= 0
                   )
            {
                error = "La sucursal es requerida";
            }
            if (entity.Nombre.Trim().Length == 0)
            {
                error = error + ".El nombre es requerido";
            }

            return error;
        }

        public string Editar(ref cat_rest_mesas entity, int modificadoPor)
        {
            string error = "";
            try
            {
                error = ValidarMesa(entity);
                if (error.Length > 0)
                    return error;

                int mesaId = entity.MesaId;
                cat_rest_mesas entity2 = oContext.cat_rest_mesas
                    .Where(w => w.MesaId == mesaId).FirstOrDefault();

                entity2.Nombre = entity.Nombre;
                entity2.Descripcion = entity.Descripcion;
                entity2.Activo = entity.Activo;
                entity2.ModificadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                entity2.ModificadoPor = entity.CreadoPor;


                oContext.SaveChanges();
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }
            return error;
        }

        public string Insertar(ref cat_rest_mesas entity)
        {
            string error = "";
            try
            {
                error = ValidarMesa(entity);
                if (error.Length > 0)
                    return error;


                entity.MesaId = oContext.cat_rest_mesas.Count() > 0 ?
                    oContext.cat_rest_mesas.Max(m => m.MesaId) + 1 : 1;
                entity.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                
                oContext.cat_rest_mesas.Add(entity);

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
