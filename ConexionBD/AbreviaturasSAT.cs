using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
 public   class AbreviaturasSAT
    {
        public ERPProdEntities oContext;

        public AbreviaturasSAT()
        {
            oContext = new ERPProdEntities();
        }

        public string validar(cat_abreviaturas_SAT entity, string accion)
        {
            int clave = entity.Clave;
            string error = "";

            if (accion == "ins")
            {
                if (oContext.cat_abreviaturas_SAT.Where(
                    w => w.Clave == clave
                    ).Count() > 0)
                {
                    error = "Ya existe un registro con la misma clave";
                }
            }

            if (entity.AbreviaturaSAT.Trim() == "")
            {
                error = "La abreviatura es requerida";
            }

            if (entity.CodigoSAT.Trim() == "")
            {
                error = "El código es requerido";
            }

            if (clave <= 0)
            {
                error = "La clave debe de ser mayor a cero";
            }

            return error;
        }

        public string Insertar(cat_abreviaturas_SAT entity)
        {
            string error = "";

            try
            {
                error = validar(entity, "ins");
                if (error.Length > 0)
                    return error;

                oContext.cat_abreviaturas_SAT.Add(entity);
                oContext.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;

            }

            return error;

        }

        public string Actualizar(cat_abreviaturas_SAT entity)
        {
            string error = "";
            int clave = entity.Clave;

            try
            {
                error = validar(entity, "upd");
                if (error.Length > 0)
                    return error;

                cat_abreviaturas_SAT entityUpd = this.oContext.cat_abreviaturas_SAT.
                    Where(w => w.Clave == clave).FirstOrDefault();

                entityUpd.AbreviaturaSAT = entity.AbreviaturaSAT;
                entityUpd.CodigoSAT = entity.CodigoSAT;
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

            cat_abreviaturas_SAT entityUpd = this.oContext.cat_abreviaturas_SAT.
                Where(w => w.Clave == clave).FirstOrDefault();

            oContext.cat_abreviaturas_SAT.Remove(entityUpd);
            oContext.SaveChanges();
        }

    }
}
