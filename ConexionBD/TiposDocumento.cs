using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class TiposDocumento
    {
        public ERPProdEntities oContext;

        public TiposDocumento()
        {
            oContext = new ERPProdEntities();
        }

        public string validar(cat_tipos_documento entity, string accion)
        {
            int clave = entity.TipoDocumentoId;
            string error = "";

            if (accion == "ins")
            {
                if (oContext.cat_tipos_documento.Where(
                    w => w.TipoDocumentoId == clave
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

        public string Insertar(cat_tipos_documento entity)
        {
            string error = "";

            try
            {
                error = validar(entity, "ins");
                if (error.Length > 0)
                    return error;

                oContext.cat_tipos_documento.Add(entity);
                oContext.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;

            }

            return error;

        }

        public string Actualizar(cat_tipos_documento entity)
        {
            string error = "";
            int clave = entity.TipoDocumentoId;

            try
            {
                error = validar(entity, "upd");
                if (error.Length > 0)
                    return error;

                cat_tipos_documento entityUpd = this.oContext.cat_tipos_documento.
                    Where(w => w.TipoDocumentoId == clave).FirstOrDefault();

                entityUpd.Abreviatura = entity.Abreviatura;
                entityUpd.Descripcion = entity.Descripcion;
                entityUpd.FolioInicial = entity.FolioInicial;
                entityUpd.IntegrarCorteCaja = entity.IntegrarCorteCaja;
                entityUpd.RequiereClaveSuper = entity.RequiereClaveSuper;
                entityUpd.TipoDocumentoId = entity.TipoDocumentoId;
                
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

            cat_tipos_documento entityUpd = this.oContext.cat_tipos_documento.
                Where(w => w.TipoDocumentoId == clave).FirstOrDefault();

            oContext.cat_tipos_documento.Remove(entityUpd);
            oContext.SaveChanges();
        }

    }
}
