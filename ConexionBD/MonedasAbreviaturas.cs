using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class MonedasAbreviaturas
    {

        public ERPProdEntities oContext;

        public MonedasAbreviaturas()
        {
            oContext = new ERPProdEntities();
        }

        public string validar(cat_monedas_abreviaturas entity, string accion)
        {
            int clave = entity.IdMonedaAbreviatura;
            string error = "";

            if (accion == "ins")
            {
                if (oContext.cat_monedas_abreviaturas.Where(
                    w => w.IdMonedaAbreviatura == clave
                    ).Count() > 0)
                {
                    error = "Ya existe un registro con la misma clave";
                }
            }

            if (entity.NombreMonedaSAT.Trim() == "")
            {
                error = "El nombre es requerido es requerida";
            }

            if (entity.ClaveSAT.Trim() == "")
            {
                error = error+ "|La clave SAT es requerido";
            }

            if (clave <= 0)
            {
                error = "La clave debe de ser mayor a cero";
            }

            return error;
        }

        public string Insertar(cat_monedas_abreviaturas entity)
        {
            string error = "";

            try
            {
                error = validar(entity, "ins");
                if (error.Length > 0)
                    return error;

                oContext.cat_monedas_abreviaturas.Add(entity);
                oContext.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;

            }

            return error;

        }

        public string Actualizar(cat_monedas_abreviaturas entity)
        {
            string error = "";
            int clave = entity.IdMonedaAbreviatura;

            try
            {
                error = validar(entity, "upd");
                if (error.Length > 0)
                    return error;

                cat_monedas_abreviaturas entityUpd = this.oContext.cat_monedas_abreviaturas.
                    Where(w => w.IdMonedaAbreviatura == clave).FirstOrDefault();

                entityUpd.ClaveSAT = entity.ClaveSAT;
                entityUpd.NombreMonedaSAT = entity.NombreMonedaSAT;
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

            cat_monedas_abreviaturas entityUpd = this.oContext.cat_monedas_abreviaturas.
                Where(w => w.IdMonedaAbreviatura == clave).FirstOrDefault();

            oContext.cat_monedas_abreviaturas.Remove(entityUpd);
            oContext.SaveChanges();
        }
    }
}
