using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class TipoFactorSAT
    {
        public ERPProdEntities oContext;

        public TipoFactorSAT()
        {
            oContext = new ERPProdEntities();
        }

        public string validar(cat_tipo_factor_SAT entity, string accion)
        {
            int clave = entity.Clave;
            string error = "";

            if (accion == "ins")
            {
                if (oContext.cat_tipo_factor_SAT.Where(
                    w => w.Clave == clave
                    ).Count() > 0)
                {
                    error = "Ya existe un registro con la misma clave";
                }
            }

            if (entity.NombreFactorSAT.Trim() == "")
            {
                error = "El nombre es requerido";
            }

            if (clave <= 0)
            {
                error = "La clave debe de ser mayor a cero";
            }

            return error;
        }

        public string Insertar(cat_tipo_factor_SAT entity)
        {
            string error = "";

            try
            {
                error = validar(entity, "ins");
                if (error.Length > 0)
                    return error;

                oContext.cat_tipo_factor_SAT.Add(entity);
                oContext.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;

            }

            return error;

        }

        public string Actualizar(cat_tipo_factor_SAT entity)
        {
            string error = "";
            int clave = entity.Clave;

            try
            {
                error = validar(entity, "upd");
                if (error.Length > 0)
                    return error;

                cat_tipo_factor_SAT entityUpd = this.oContext.cat_tipo_factor_SAT.
                    Where(w => w.Clave == clave).FirstOrDefault();

                entityUpd.NombreFactorSAT = entity.NombreFactorSAT;
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

            cat_tipo_factor_SAT entityUpd = this.oContext.cat_tipo_factor_SAT.
                Where(w => w.Clave == clave).FirstOrDefault();

            oContext.cat_tipo_factor_SAT.Remove(entityUpd);
            oContext.SaveChanges();
        }

    }
}
