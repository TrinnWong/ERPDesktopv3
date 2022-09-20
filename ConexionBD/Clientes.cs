using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class Clientes
    {
        public ERPProdEntities oContext;

        public Clientes()
        {
            oContext = new ERPProdEntities();
        }

        public string validar(cat_clientes entity, string accion)
        {
            int clave = entity.ClienteId;
            string error = "";

            if (accion == "ins")
            {
                if (oContext.cat_clientes.Where(
                    w => w.ClienteId == clave
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
                error =error + "|El nombre es requerido";
            }           

            if (entity.Telefono.Trim() == ""
                &&
                entity.Telefono2.Trim() == ""
                )
            {
                error = error + "|Es necesario capturar por lo menos un teléfono";
            }

            if (entity.TipoClienteId<= 0)
            {
                error = error + "|El Tipo de cliente es requerido";
            }


            return error;
        }

        public string Insertar(cat_clientes entity)
        {
            string error = "";

            try
            {
                error = validar(entity, "ins");
                if (error.Length > 0)
                    return error;

                oContext.cat_clientes.Add(entity);
                oContext.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;

            }

            return error;

        }

        public string Actualizar(cat_clientes entity)
        {
            string error = "";
            int clave = entity.ClienteId;

            try
            {
                error = validar(entity, "upd");
                if (error.Length > 0)
                    return error;

                cat_clientes entityUpd = this.oContext.cat_clientes.
                    Where(w => w.ClienteId == clave).FirstOrDefault();

                entityUpd.ClienteId = entity.ClienteId;
                entityUpd.Nombre = entity.Nombre;
                entityUpd.Activo = entity.Activo;
                entityUpd.AntecedenteId = entity.AntecedenteId;
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
                entityUpd.TipoClienteId = entity.TipoClienteId;
                
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

            cat_clientes entityUpd = this.oContext.cat_clientes.
                Where(w => w.ClienteId == clave).FirstOrDefault();

            oContext.cat_clientes.Remove(entityUpd);
            oContext.SaveChanges();
        }
    }
}
