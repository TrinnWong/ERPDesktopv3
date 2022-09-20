using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class Usuarios
    {

        public ERPProdEntities oContext;

        public Usuarios()
        {
            oContext = new ERPProdEntities();
        }

        public string validar(cat_usuarios entity, string accion)
        {
            int clave = entity.IdUsuario;
            string usuario = entity.NombreUsuario;
            string error = "";

            if (accion == "ins")
            {
                if (oContext.cat_usuarios.Where(
                    w => w.IdUsuario == clave
                    ).Count() > 0)
                {
                    error = "Ya existe un registro con la misma clave";
                }
            }

            if (entity.EsSupervisor == true && entity.PasswordSupervisor.Trim() == "")
            {
                error = error + "|El password de supervisor es requerido";
            }
            if (oContext.cat_usuarios
                .Where(u => u.NombreUsuario == usuario
                && u.IdUsuario != clave).Count() > 0
                )
            {
                error = error + "|El nombre de usuario ya está ocupado";
            }

            if (entity.NombreUsuario.Trim() == "")
            {
                error = error+"|El nombre es requerido";
            }

            if (entity.Password.Trim() == "")
            {
                error = error + "El password es requerido";
            }

            if (clave <= 0)
            {
                error = error + "La clave debe de ser mayor a cero";
            }

            if (entity.IdEmpleado <= 0)
            {
                error = error + "El empleado es requerido";
            }

            if (entity.IdSucursal <= 0)
            {
                error = error + "|La sucursal es requerida";
            }

            return error;
        }

        public string Insertar(cat_usuarios entity)
        {
            string error = "";

            try
            {
                oContext = new ERPProdEntities();
                error = validar(entity, "ins");
                if (error.Length > 0)
                    return error;

                oContext.cat_usuarios.Add(entity);
                oContext.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;

            }

            return error;

        }

        public string Actualizar(cat_usuarios entity)
        {
            string error = "";
            int clave = entity.IdUsuario;

            try
            {
                error = validar(entity, "upd");
                if (error.Length > 0)
                    return error;

                cat_usuarios entityUpd = this.oContext.cat_usuarios.
                    Where(w => w.IdUsuario == clave).FirstOrDefault();

                entityUpd.IdUsuario = entity.IdUsuario;
                entityUpd.IdEmpleado = entity.IdEmpleado;
                entityUpd.NombreUsuario = entity.NombreUsuario;
                entityUpd.Activo = entity.Activo;
                entityUpd.Password = entity.Password;
                entityUpd.EsSupervisor = entity.EsSupervisor;
                entityUpd.PasswordSupervisor = entity.PasswordSupervisor;
                entityUpd.IdSucursal = entity.IdSucursal;
                entityUpd.EsSupervisorCajero = entity.EsSupervisorCajero;
                entityUpd.PasswordSupervisorCajero = entity.PasswordSupervisorCajero;
                entityUpd.Email = entity.Email;
                entityUpd.CajaDefaultId = entity.CajaDefaultId;
                oContext.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.InnerException.Message;

            }

            return error;

        }

        public void Eliminar(int clave)
        {

            cat_usuarios entityUpd = this.oContext.cat_usuarios.
                Where(w => w.IdUsuario == clave).FirstOrDefault();

            oContext.cat_usuarios.Remove(entityUpd);
            oContext.SaveChanges();
        }

        public void obtenerSessionPuntoVenta(int usuarioId)
        {
        }
    }
}
