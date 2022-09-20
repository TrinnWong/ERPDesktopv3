using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionBD.Utilerias;
using System.Data;

namespace ConexionBD
{
    public class EmpresasInterface
    {
        Business con;
        Resultado resultado;

        public EmpresasInterface()
        {
            con = new Business();
        }

        public DataTable ConsultarListado(string busqueda)
        {
            string comandoSelect = "", tabla = "";
            resultado = new Resultado();

            DataTable dt = new DataTable();
            try
            {
                int clave = 0;
                comandoSelect = "select Clave, Nombre [Nombre Empresa], NombreComercial [Nombre Comercial], RegimenFiscal [Régimen Fiscal], "
                                + "RFC, Calle, Colonia, NoExt [No. Ext], NoInt [No. Int], CP, Ciudad, Estado, Pais, Telefono1 [Telefono 1], "
                                + "Telefono2 [Telefono 2], Email [Correo], FechaAlta, case when Estatus = 1 then 'Activa' else  'Inactiva' end [Estatus] "
                                + "from cat_empresas ";

                if (int.TryParse(busqueda, out clave))
                {
                    comandoSelect = comandoSelect + "where " + clave + " = 0 or Clave = " + clave;
                }
                else
                {
                    if(busqueda != "")
                        comandoSelect = comandoSelect + "where Nombre like '%" + busqueda + "%' or NombreComercial like '%"+busqueda+"%'";                  
                }
                tabla = "Empresa";

                dt = con.Select(comandoSelect, tabla);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de consultar los datos. " + ex.Message;
            }
            return dt;
        }

        public DataTable ConsultarRegistro(int clave, bool verificarNoExistaClave)
        {
            string comandoSelect = "", tabla = "";
            resultado = new Resultado();

            DataTable dt = new DataTable();
            try
            {
                comandoSelect = "select Clave, Nombre, NombreComercial, RegimenFiscal, "
                                 + "RFC, Calle, Colonia, NoExt, NoInt, CP, Ciudad, Estado, Pais, Telefono1, "
                                 + "Telefono2, Email, FechaAlta, case when Estatus = 1 then 'Activa' else  'Inactiva' end [EstatusLetra], Estatus "
                                 + "from cat_empresas "
                                 + "where Clave " + (verificarNoExistaClave ? "!" : "") + "= " + clave;

                tabla = "Empresas";

                dt = con.Select(comandoSelect, tabla);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de consultar el registro. " + ex.Message;
            }
            return dt;
        }

        public Resultado Agregar(int clave, string nombre, string nombreComercial, string regimenFiscal, string rfc, string calle, string colonia, string numExt, string numInt,
            string cp, string ciudad, string estado, string pais, string telefono1, string telefono2, string email, bool estatus)
        {
            resultado = new Resultado();
            string comandoInsert = "";
            try
            {
                comandoInsert = "insert into cat_empresas "
                                + "(Clave, Nombre, NombreComercial, RegimenFiscal, RFC, Calle, Colonia, NoExt, NoInt, CP, Ciudad, Estado, Pais, Telefono1, Telefono2, Email, FechaAlta, Estatus) "
                                + "values(" + clave + ", '" + nombre + "', '" + nombreComercial + "', '" + regimenFiscal + "', '" + rfc + "', '" + calle + "', '" + colonia + "', '" + numExt
                                + "', '" + numInt + "', '" + cp + "', '" + ciudad + "', '" + estado + "', '" + pais + "', '" + telefono1 + "', '" + telefono2 + "', '" + email + "', getdate(), '" + estatus + "')";
                resultado = con.Insert(comandoInsert);
            } 
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de insertar los datos. " + ex.Message;
            }

            return resultado;
        }

        public Resultado Actualizar(int clave, string nombre, string nombreComercial, string regimenFiscal, string rfc, string calle, string colonia, string numExt, string numInt,
            string cp, string ciudad, string estado, string pais, string telefono1, string telefono2, string email, bool estatus)
        {
            resultado = new Resultado();
            string comandoUpdate = "";
            try
            {
                comandoUpdate = "update cat_empresas "
                                + "set Nombre = '" + nombre + "', "
                                + "NombreComercial = '" + nombreComercial + "', "
                                + "RegimenFiscal = '" + regimenFiscal + "', "
                                + "RFC = '" + rfc + "', "
                                + "Calle = '" + calle + "', "
                                + "Colonia = '" + colonia + "', "
                                + "NoExt = '" + numExt + "', "
                                + "NoInt = '" + numInt + "', "
                                + "CP = '" + cp + "', "
                                + "Ciudad = '" + ciudad + "', "
                                + "Estado = '" + estado + "', "
                                + "Pais = '" + pais + "', "
                                + "Telefono1 = '" + telefono1 + "', "
                                + "Telefono2 = '" + telefono2 + "', "
                                + "Email = '" + email + "', "
                                + "Estatus = '" + (estatus ? 1 : 0) + "' "
                                + "where Clave = " + clave;
                resultado = con.Update(comandoUpdate);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de actualizar los datos. " + ex.Message;
            }
            return resultado;
        }

        public Resultado Eliminar(int clave)
        {
            resultado = new Resultado();
            string comandoDelete = "";
            try
            {
                comandoDelete = string.Format("delete from cat_empresas where Clave = {0}", clave);
                resultado = con.Delete(comandoDelete);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de eliminar los datos. " + ex.Message;
            }
            return resultado;
        }

        #region ComboBox

        public DataTable ConsultaComboBox()
        {
            string comandoSelect = "", tabla = "";
            resultado = new Resultado();

            DataTable dt = new DataTable();
            try
            {
                comandoSelect = "select Clave, Descripcion from cat_empresas where Estatus = 1";
                tabla = "Empresas";

                dt = con.Select(comandoSelect, tabla);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de consultar los datos. " + ex.Message;
            }

            return dt;
        }

        #endregion
    }
}
