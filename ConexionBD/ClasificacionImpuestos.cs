using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class ClasificacionImpuestos
    {

       public ERPProdEntities oContext;

        public ClasificacionImpuestos()
        {
            oContext = new ERPProdEntities();
        }

        public string validar(cat_clasificacion_impuestos entity, string accion)
        {
            int clave = entity.Clave;
            string error = "";

            if (accion == "ins")
            {
                if (oContext.cat_clasificacion_impuestos.Where(
                    w => w.Clave == clave
                    ).Count() > 0)
                {
                    error = "Ya existe un registro con la misma clave";
                }
            }

            if (entity.NombreSAT.Trim() == "")
            {
                error = "El nombre es requerido";
            }

            if (clave <= 0)
            {
                error = "La clave debe de ser mayor a cero";
            }

            return error;
        }

        public string Insertar(cat_clasificacion_impuestos entity)
        {
            string error = "";

            try
            {
                error = validar(entity, "ins");
                if (error.Length > 0)
                    return error;

                oContext.cat_clasificacion_impuestos.Add(entity);
                oContext.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                
            }

            return error;
           
        }

        public string Actualizar(cat_clasificacion_impuestos entity)
        {
            string error = "";
            int clave = entity.Clave;

            try
            {
                error = validar(entity, "upd");
                if (error.Length > 0)
                    return error;

                cat_clasificacion_impuestos entityUpd = this.oContext.cat_clasificacion_impuestos.
                    Where(w => w.Clave == clave).FirstOrDefault();

                entityUpd.NombreSAT = entity.NombreSAT;
                entityUpd.Activo = entity.Activo;
                oContext.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;

            }

            return error;

        }

        public void Eliminar(int clave)
        {

            cat_clasificacion_impuestos entityUpd = this.oContext.cat_clasificacion_impuestos.
                Where(w => w.Clave == clave).FirstOrDefault();

            oContext.cat_clasificacion_impuestos.Remove(entityUpd);
            oContext.SaveChanges();
        }



    }
}
