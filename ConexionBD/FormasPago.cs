using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class FormasPago
    {

        public ERPProdEntities oContext;

        public FormasPago()
        {
            oContext = new ERPProdEntities();
        }

        public string validar(cat_formas_pago entity, string accion)
        {
            int clave = entity.FormaPagoId;
            string error = "";

            if (accion == "ins")
            {
                if (oContext.cat_formas_pago.Where(
                    w => w.FormaPagoId == clave
                    ).Count() > 0)
                {
                    error = "Ya existe un registro con la misma clave";
                }
            }

            if (entity.Descripcion.Trim() == "")
            {
                error = "La descripción es requerida";
            }

            if (entity.Abreviatura.Trim() == "")
            {
                error = "La abreviatura es requerida";
            }

            if (clave <= 0)
            {
                error = "La clave debe de ser mayor a cero";
            }

            return error;
        }

        public string Insertar(cat_formas_pago entity)
        {
            string error = "";

            try
            {
                error = validar(entity, "ins");
                if (error.Length > 0)
                    return error;

                oContext.cat_formas_pago.Add(entity);
                oContext.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;

            }

            return error;

        }

        public string Actualizar(cat_formas_pago entity)
        {
            string error = "";
            int clave = entity.FormaPagoId;

            try
            {
                error = validar(entity, "upd");
                if (error.Length > 0)
                    return error;

                cat_formas_pago entityUpd = this.oContext.cat_formas_pago.
                    Where(w => w.FormaPagoId == clave).FirstOrDefault();

                entityUpd.Activo = entity.Activo;
                entityUpd.Abreviatura = entity.Abreviatura;
                entityUpd.Descripcion = entity.Descripcion;
                entityUpd.FormaPagoId = entity.FormaPagoId;
                entityUpd.NumeroHacienda = entity.NumeroHacienda;
                entityUpd.Orden = entity.Orden;
                entityUpd.RequiereDigVerificador = entity.RequiereDigVerificador;
                entityUpd.Signo = entity.Signo;
                
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

            cat_formas_pago entityUpd = this.oContext.cat_formas_pago.
                Where(w => w.FormaPagoId == clave).FirstOrDefault();

            oContext.cat_formas_pago.Remove(entityUpd);
            oContext.SaveChanges();
        }
    }
}
