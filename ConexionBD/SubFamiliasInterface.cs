using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionBD.Utilerias;
using System.Data;

namespace ConexionBD
{
    public class SubFamiliasInterface
    {
        Business con;
        Resultado resultado;

        public SubFamiliasInterface()
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
                comandoSelect = "select sf.Clave, sf.Descripcion as Descripción, cf.Descripcion [Familia], case when sf.Estatus = 1 then 'Activo' else 'Inactivo' end [Estatus] "
                                + "from cat_subfamilias sf "
                                + "inner join cat_familias cf on cf.Clave = sf.Familia ";
                if (int.TryParse(busqueda, out clave))
                {
                    comandoSelect = comandoSelect + "where "+clave+" = 0 or sf.Clave = " + clave;
                }
                else
                {
                    if(busqueda != "")
                        comandoSelect = comandoSelect + "where sf.Descripcion like '%" + busqueda + "%' or cf.Descripcion like '%" + busqueda + "%'";
                }

                tabla = "SubFamilia";

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
                comandoSelect = "select Clave, Descripcion, Familia, Estatus "
                                + "from cat_subfamilias "
                                + "where Clave " + (verificarNoExistaClave ? "!" : "") + "= " + clave;

                tabla = "SubFamilia";

                dt = con.Select(comandoSelect, tabla);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de consultar el registro. " + ex.Message;
            }
            return dt;
        }

        public Resultado Agregar(int clave, string descripcion, int familia, bool estatus, int? empresa, int? sucursal)
        {
            resultado = new Resultado();
            string comandoInsert = "";
            string strEmpresa = empresa == null ? "null" : empresa.ToString();
            string strSucursal = sucursal == null ? "null" : sucursal.ToString();
            try
            {
                comandoInsert = "insert into cat_subfamilias "
                                + "(Clave, Descripcion, Familia, Estatus, Empresa, Sucursal) "
                                + "values(" + clave + ", '" + descripcion + "', "+familia+ ", " + (estatus ? 1 : 0) + ", " + strEmpresa + ", " + strSucursal + ")";
                resultado = con.Insert(comandoInsert);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de insertar los datos. " + ex.Message;
            }

            return resultado;
        }

        public Resultado Actualizar(int clave, string descripcion, int familia, bool estatus)
        {
            resultado = new Resultado();
            string comandoUpdate = "";
            try
            {
                comandoUpdate = "update cat_subfamilias "
                                + "set Descripcion = '" + descripcion + "', "
                                + "Familia = "+familia+", "
                                + "Estatus = " + (estatus ? 1 : 0) + " "
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
                comandoDelete = string.Format("delete from cat_subfamilias where Clave = {0}", clave);
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
                comandoSelect = "select Clave, Descripcion from cat_subfamilias where Estatus = 1";
                tabla = "SubFamilia";

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
