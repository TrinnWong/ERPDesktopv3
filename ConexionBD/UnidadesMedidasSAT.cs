using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class UnidadesMedidasSAT
    {

        public ERPProdEntities oContext;

        public UnidadesMedidasSAT()
        {
            oContext = new ERPProdEntities();
        }

        public string validar(cat_unidades_medida_SAT entity, string accion)
        {
            int clave = entity.IdUnidadMedidaSAT;
            string claveSAT = entity.ClaveSAT;
            string error = "";

            if (accion == "ins")
            {
                if (oContext.cat_unidades_medida_SAT.Where(
                    w => w.ClaveSAT == claveSAT
                    ).Count() > 0)
                {
                    error = "Ya existe un registro con la misma clave";
                }
            }

            if (entity.ClaveSAT.Trim() == "")
            {
                error = error + "|La clave es requerida";
            }

            if (entity.DescripcionSAT.Trim() == "")
            {
                error = error + "|La descripción es requerida";
            }

            if (entity.NombreSAT.Trim() == "")
            {
                error = error + "|El nombre es requerido";
            }

            if (clave <= 0)
            {
                error = "La clave debe de ser mayor a cero";
            }

            return error;
        }

        public string Insertar(cat_unidades_medida_SAT entity)
        {
            string error = "";

            try
            {
                error = validar(entity, "ins");
                if (error.Length > 0)
                    return error;

                oContext.cat_unidades_medida_SAT.Add(entity);
                oContext.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;

            }

            return error;

        }

        public string Actualizar(cat_unidades_medida_SAT entity)
        {
            string error = "";
            int clave = entity.IdUnidadMedidaSAT;

            try
            {
                error = validar(entity, "upd");
                if (error.Length > 0)
                    return error;

                cat_unidades_medida_SAT entityUpd = this.oContext.cat_unidades_medida_SAT.
                    Where(w => w.IdUnidadMedidaSAT == clave).FirstOrDefault();

                entityUpd.DescripcionSAT = entity.DescripcionSAT;
                entityUpd.NombreSAT = entity.NombreSAT;
                entityUpd.Activo = entity.Activo;
                entityUpd.ClaveSAT = entity.ClaveSAT;
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

            cat_unidades_medida_SAT entityUpd = this.oContext.cat_unidades_medida_SAT.
                Where(w => w.IdUnidadMedidaSAT == clave).FirstOrDefault();

            oContext.cat_unidades_medida_SAT.Remove(entityUpd);
            oContext.SaveChanges();
        }

    }
}
