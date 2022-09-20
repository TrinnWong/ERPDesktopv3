using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class Login
    {
        public ERPProdEntities oContext;

        public Login()
        {
            oContext = new ERPProdEntities();
        }

        public string validar(string usuario, string password, ref PuntoVentaContext context)
        {

            string error = "";
            try
            {
                cat_usuarios entity = oContext.cat_usuarios.Where(w => w.NombreUsuario == usuario).FirstOrDefault();
                cat_configuracion entityConf = oContext.cat_configuracion.FirstOrDefault();

                if (entity.EsSupervisor == false)
                {
                    error = "El usuario no tiene privilegios";
                    return error;
                }

                if (entity == null)
                {
                    error = "El usuario no existe";

                    return error;
                }
                else {
                    if (entity.Password != password.Trim())
                    {
                        error = "Contraseña incorrecta";

                        return error;
                    }
                }

                context = new PuntoVentaContext();
                context.cajaId = 0;
                context.empresaId = entity.rh_empleados.Empresa ?? 1;
                context.esSupervisor = false;
                context.sucursalId = 1;
                context.usuarioId = entity.IdUsuario;
                context.giroPuntoVenta = entityConf.Giro;
                

            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;

        }
    }
}

