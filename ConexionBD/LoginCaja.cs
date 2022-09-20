using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class LoginCaja
    {
        ERPProdEntities model;

        public LoginCaja()
        {
            model = new ERPProdEntities();
        }

        public string validarLogin(string usuario, string password, 
            int cajaId,ref cat_usuarios entity,
            ref bool esSupervisor,
            ref int sesionId)
        {
            string error = "";
            entity = null;
            model = new ERPProdEntities();

            try
            {
                /***VALIDAR**********/
                if (usuario.Trim() == "" || password.Trim() == "")
                {
                    error = "Es necesario ingresar el usuario y contraseña";
                    
                }
                if (cajaId <= 0)
                {
                    error = "\n Es necesario seleccionar una caja";
                }
               

                if (error.Length > 0)
                {
                    return error;
                }


                entity = model.cat_usuarios.Where(w => w.NombreUsuario.Trim() == usuario.Trim()).FirstOrDefault();

                if (entity != null)
                {
                    if (entity.Password.Trim() != password.Trim())
                    {
                        error = "La contraseña es incorrecta";
                    }
                    else {
                        esSupervisor = entity.EsSupervisor??false;
                    }

                    /***********Validar la session***/
                    ObjectParameter pError = new ObjectParameter("pError", "");
                    ObjectParameter pSesionId = new ObjectParameter("pSesionId", 0);
                    model.p_punto_venta_validar_sesion(entity.IdUsuario, cajaId, pError, pSesionId);

                    if (pError.Value.ToString().Length > 0 && !esSupervisor)
                    {
                        error = pError.Value.ToString();
                    }
                    else {
                        if (int.Parse(pSesionId.Value.ToString()) > 0)
                        {
                            sesionId = int.Parse(pSesionId.Value.ToString());
                        }

                       
                    }
                }
                else {
                    error = "El usuario no existe";
                }

            }
            catch (Exception ex)
            {

                error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            return error;

        }

        public string validarLogin(string usuario, string password,
           ref cat_usuarios entity,
           ref bool esSupervisor,
           ref int sesionId)
        {
            string error = "";
            entity = null;
            model = new ERPProdEntities();

            try
            {
                /***VALIDAR**********/
                if (usuario.Trim() == "" || password.Trim() == "")
                {
                    error = "Es necesario ingresar el usuario y contraseña";

                }              


                if (error.Length > 0)
                {
                    return error;
                }


                entity = model.cat_usuarios.Where(w => w.NombreUsuario.Trim() == usuario.Trim()).FirstOrDefault();

                if (entity != null)
                {
                    if (entity.Password.Trim() != password.Trim())
                    {
                        error = "La contraseña es incorrecta";
                    }
                    else
                    {
                        esSupervisor = entity.EsSupervisor ?? false;
                    }

                    /***********Validar la session***/
                    ObjectParameter pError = new ObjectParameter("pError", "");
                    ObjectParameter pSesionId = new ObjectParameter("pSesionId", 0);
                    model.p_punto_venta_validar_sesion(entity.IdUsuario, null, pError, pSesionId);

                    if (pError.Value.ToString().Length > 0 && !esSupervisor)
                    {
                        error = pError.Value.ToString();
                    }
                    else
                    {
                        if (int.Parse(pSesionId.Value.ToString()) > 0)
                        {
                            sesionId = int.Parse(pSesionId.Value.ToString());
                        }


                    }
                }
                else
                {
                    error = "El usuario no existe";
                }

            }
            catch (Exception ex)
            {

                error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            return error;

        }
    }
}
