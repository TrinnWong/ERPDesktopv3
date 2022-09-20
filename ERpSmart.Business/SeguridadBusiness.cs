using ConexionBD;
using ConexionBD.Models;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class SeguridadBusiness : BusinessObject
    {
        public string InsertarUsuarioRol(sis_usuarios_roles entity, PuntoVentaContext context)
        {
            string error = "";
            try
            {
                if (entity.RolId == 0 || entity.UsuarioId == 0)
                {
                    error = "Es necesario ingresar el rol y el usuario";
                    return error;
                }

                entity.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                oContext.sis_usuarios_roles.Add(entity);

                oContext.SaveChanges();
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }

        public string InsertarUsuarioSucursal(cat_usuarios_sucursales entity, PuntoVentaContext context)
        {
            string error = "";
            try
            {
                if (entity.SucursalId == 0 || entity.UsuarioId == 0)
                {
                    error = "Es necesario ingresar la sucursal y el usuario";
                    return error;
                }

                oContext.p_cat_usuarios_sucursales_ins(entity.UsuarioId, entity.SucursalId);

            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }

        public string EliminarUsuarioRol(sis_usuarios_roles entity, PuntoVentaContext context)
        {
            string error = "";
            try
            {
                int usuarioId = entity.UsuarioId;
                int rolId = entity.RolId;

                sis_usuarios_roles entityDel = oContext.sis_usuarios_roles
                    .Where(w => w.RolId == rolId && w.UsuarioId == usuarioId).FirstOrDefault();

                oContext.sis_usuarios_roles.Remove(entityDel);

                oContext.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;

            }

            return error;
        }

        public string EliminarUsuarioSucursal(cat_usuarios_sucursales entity, PuntoVentaContext context)
        {
            string error = "";
            try
            {
                int usuarioId = entity.UsuarioId;
                int sucursalId = entity.SucursalId;

                cat_usuarios_sucursales entityDel = oContext.cat_usuarios_sucursales
                    .Where(w => w.SucursalId == sucursalId && w.UsuarioId == usuarioId).FirstOrDefault();

                oContext.cat_usuarios_sucursales.Remove(entityDel);

                oContext.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;

            }

            return error;
        }

        public static ResultAPIModel ValidarAcceso(int usuarioId,int sucursalId,string idPantalla) 
        {
            ERPProdEntities oContext2 = new ERPProdEntities();
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                cat_usuarios entityUsuario = oContext2.cat_usuarios
                    .Where(w => w.IdUsuario == usuarioId && w.Activo == true).FirstOrDefault();

                if(entityUsuario != null)
                {
                    if(entityUsuario.sis_usuarios_roles
                        .Where(w=> w.RolId == (int)ERP.Business.Enumerados.roles.adiministradorSistema ).Count() > 0)
                    {
                        result.ok = true;
                    }
                    else
                    {
                        if(oContext2.sis_usuarios_roles
                            .Where(
                                w=> w.UsuarioId == usuarioId && 
                                w.cat_usuarios.Activo == true &&
                                w.sis_roles.Activo == true &&
                                w.sis_roles.sis_roles_perfiles                               
                                .Where(
                                     s1=> s1.sis_perfiles.Activo == true &&
                                     s1.sis_perfiles.sis_perfiles_menu
                                     .Where(s2=> s2.sis_menu.MenuWinBarNameId == idPantalla).Count() >0
                                ).Count() >0
                            ).Count() > 0)
                        {
                            result.ok = true;
                        }
                        else
                        {
                            result.error = "El usuario no tiene privilegios para usar este recurso";
                        }
                    }
                }
                else
                {
                    result.error = "El usuario no tiene privilegios para usar este recurso";
                }
            }
            catch (Exception ex)
            {

                result.error = "Ocurrió un error inesperado al validar el acceso";
            }

            return result;
        }
    }
}
