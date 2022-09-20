using ConexionBD.Utilerias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class DenominacionesInterface
    {
        Business con;
        Resultado resultado;

        public DenominacionesInterface()
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
                comandoSelect = "select Clave, Descripcion [Denominación], cast(cast(Orden as decimal(19, 0)) as varchar) [Orden], '$'+cast(cast(Valor as decimal(19, 2)) as varchar) [Valor], case when Estatus = 1 then 'Activo' else 'Inactivo' end [Estatus] from cat_denominaciones ";
                int clave = 0;
                if (int.TryParse(busqueda, out clave))
                {
                    comandoSelect = comandoSelect + "where " + clave + " = 0 or Clave = " + clave + " ";
                }
                else
                {
                    if (busqueda != "")
                        comandoSelect = comandoSelect + "where Descripcion like '%" + busqueda + "%' ";
                }
                comandoSelect = comandoSelect + "order by orden";

                tabla = "Denominaciones";

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
                comandoSelect = "select Clave, Descripcion , Valor, Orden, case when Estatus = 1 then 'Activo' else 'Inactivo' end [EstatusLetra], Estatus "
                                + "from cat_denominaciones "
                                + "where Clave " + (verificarNoExistaClave ? "!" : "") + "= " + clave;

                tabla = "Denominaciones";

                dt = con.Select(comandoSelect, tabla);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de consultar el registro. " + ex.Message;
            }
            return dt;
        }

        public Resultado Agregar(int clave, string descripcion, decimal valor, int orden, bool estatus, int? empresa, int? sucursal)
        {
            resultado = new Resultado();
            string comandoInsert = "";
            string strEmpresa = empresa == null ? "null" : empresa.ToString();
            string strSucursal = sucursal == null ? "null" : sucursal.ToString();
            try
            {
                comandoInsert = "insert into cat_denominaciones "
                                + "(Clave, Descripcion, Valor, Orden, Estatus, Empresa, Sucursal) "
                                + "values(" + clave + ", '" + descripcion + "', '" + valor.ToString("0.00") + "', '" + orden + "', " + (estatus == true ? 1 : 0) + ", " + strEmpresa + ", " + strSucursal + ")";
                resultado = con.Insert(comandoInsert);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de insertar los datos. " + ex.Message;
            }

            return resultado;
        }

        public Resultado Actualizar(int clave, string descripcion, decimal valor, int orden, bool estatus)
        {
            resultado = new Resultado();
            string comandoUpdate = "";
            try
            {
                comandoUpdate = "update cat_denominaciones "
                                + "set Descripcion = '" + descripcion + "',"
                                + "Valor = " + valor + ", "
                                + "Orden = " + orden + ", "
                                + "Estatus = " + (estatus == true ? 1 : 0) + " "
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
                comandoDelete = string.Format("delete from cat_denominaciones where Clave = {0}", clave);
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
                comandoSelect = "select Clave, Descripcion from cat_denominaciones where Estatus = 1";
                tabla = "Denominaciones";

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
