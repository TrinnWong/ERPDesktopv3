using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class Proveedores
    {
        public ERPProdEntities oContext;

        public Proveedores()
        {
            oContext = new ERPProdEntities();
        }

        public string validar(cat_proveedores entity, string accion)
        {
            int clave = entity.ProveedorId;
            string error = "";

            if (accion == "ins")
            {
                if (oContext.cat_proveedores.Where(
                    w => w.ProveedorId == clave
                    ).Count() > 0)
                {
                    error = "Ya existe un registro con la misma clave";
                }
            }

            if (clave <= 0)
            {
                error = "La clave debe de ser mayor a cero";
            }

            if (entity.Nombre == "")
            {
                error = error + "|El nombre es requerido";
            }

            if (entity.RFC == "")
            {
                error = error + "|El RFC es requerido";
            }

            if (entity.TipoProveedorId <= 0)
            {
                error = error + "|El Tipo de cliente es requerido";
            }


            return error;
        }

        public string Insertar(cat_proveedores entity)
        {
            string error = "";

            try
            {
                error = validar(entity, "ins");
                if (error.Length > 0)
                    return error;

                oContext.cat_proveedores.Add(entity);
                oContext.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;

            }

            return error;

        }

        public string Actualizar(cat_proveedores entity)
        {
            string error = "";
            int clave = entity.ProveedorId;

            try
            {
                error = validar(entity, "upd");
                if (error.Length > 0)
                    return error;

                cat_proveedores entityUpd = this.oContext.cat_proveedores.
                    Where(w => w.ProveedorId == clave).FirstOrDefault();

                entityUpd.ProveedorId = entity.ProveedorId;
                entityUpd.Nombre = entity.Nombre;
                entityUpd.Activo = entity.Activo;
                
                entityUpd.Calle = entity.Calle;
                entityUpd.ClienteEspecial = entity.ClienteEspecial;
                entityUpd.ClienteGral = entity.ClienteGral;
                entityUpd.CodigoPostal = entity.CodigoPostal;
                entityUpd.Colonia = entity.Colonia;
                entityUpd.CreditoDisponible = entity.CreditoDisponible;
                entityUpd.DiasCredito = entity.DiasCredito;
                entityUpd.EstadoId = entity.EstadoId;
                entityUpd.GiroId = entity.GiroId;
                entityUpd.LimiteCredito = entity.LimiteCredito;
                entityUpd.MunicipioId = entity.MunicipioId;
                entityUpd.NumeroExt = entity.NumeroExt;
                entityUpd.NumeroInt = entity.NumeroInt;
                entityUpd.PaisId = entity.PaisId;
                entityUpd.PrecioId = entity.PrecioId;
                entityUpd.RFC = entity.RFC;
                entityUpd.SaldoGlobal = entity.SaldoGlobal;
                entityUpd.Telefono = entity.Telefono;
                entityUpd.Telefono2 = entity.Telefono2;
                entityUpd.TipoProveedorId = entity.TipoProveedorId;

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

            cat_proveedores entityUpd = this.oContext.cat_proveedores.
                Where(w => w.ProveedorId == clave).FirstOrDefault();

            oContext.cat_proveedores.Remove(entityUpd);
            oContext.SaveChanges();
        }

    }
}
