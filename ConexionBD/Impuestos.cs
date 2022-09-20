using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
   public  class Impuestos
    {

        public ERPProdEntities oContext;

        public Impuestos()
        {
            oContext = new ERPProdEntities();
        }

        public string validar(cat_impuestos entity, string accion)
        {
            int clave = entity.Clave;
            string error = "";

            if (accion == "ins")
            {
                if (oContext.cat_impuestos.Where(
                    w => w.Clave == clave
                    ).Count() > 0)
                {
                    error = "Ya existe un registro con la misma clave";
                }
            }

            if (entity.CodigoSAT.Trim()=="")
            {
                error = error + "!El código SAT es requerido";
            }

           
            //if (entity.DecimalesPorcCuota <= 0)
            //{
            //    error = error + "|Las decimales son requeridas";
            //}

            if (entity.Descripcion.Trim()=="")
            {
                error = error + "|Descripción es requerida";
            }
            if (entity.IdAbreviatura <= 0)
            {
                error = error + "|La abreviatura es requerida";
            }

            if (entity.IdClasificacionImpuesto <= 0)
            {
                error = error + "|La clasificación es requerida";
            }

            if (entity.IdTipoFactor <= 0)
            {
                error = error + "|El tipo factor es requerida";
            }

            if (entity.OrdenImpresion <= 0)
            {
                error = error + "|El orden de impresión es requerida";
            }

            

            if (clave <= 0)
            {
                error = error + "|La clave debe de ser mayor a cero";
            }

            return error;
        }

        public string Insertar(cat_impuestos entity)
        {
            string error = "";

            try
            {
                error = validar(entity, "ins");
                if (error.Length > 0)
                    return error;

                oContext.cat_impuestos.Add(entity);
                oContext.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;

            }

            return error;

        }

        public string Actualizar(cat_impuestos entity)
        {
            string error = "";
            int clave = entity.Clave;

            try
            {
                error = validar(entity, "upd");
                if (error.Length > 0)
                    return error;

                cat_impuestos entityUpd = this.oContext.cat_impuestos.
                    Where(w => w.Clave == clave).FirstOrDefault();

                entityUpd.AgregarImpPrecioVta = entity.AgregarImpPrecioVta;
                entityUpd.CodigoSAT = entity.CodigoSAT;
                entityUpd.CuotaFija = entity.CuotaFija;
                entityUpd.DecimalesPorcCuota = entity.DecimalesPorcCuota;
                entityUpd.Descripcion = entity.Descripcion;
                entityUpd.DesglosarImpPrecioVta = entity.DesglosarImpPrecioVta;
                entityUpd.IdAbreviatura = entity.IdAbreviatura;
                entityUpd.IdClasificacionImpuesto = entity.IdClasificacionImpuesto;
                entityUpd.IdTipoFactor = entity.IdTipoFactor;
                entityUpd.OrdenImpresion = entity.OrdenImpresion;
                entityUpd.Porcentaje = entity.Porcentaje;
                
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

            List<cat_impuestos> entityUpd = this.oContext.cat_impuestos.
                Where(w => w.Clave == clave).ToList();

            if(entityUpd.Count() > 0)
            {

                cat_impuestos del = entityUpd.FirstOrDefault();
                oContext.cat_impuestos.Remove(del);
                oContext.SaveChanges();
            }

           
        }
    }
}
