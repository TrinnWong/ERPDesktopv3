using ConexionBD.Utilerias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class CajasInterface
    {
        Business con;
        Resultado resultado;

        public CajasInterface()
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
                comandoSelect = "select Clave, Descripcion [Caja], Ubicacion [Ubicación], case when Estatus = 1 then 'Activo' else 'Inactivo' end [Estatus] from cat_cajas ";
                int clave = 0;
                if (int.TryParse(busqueda, out clave))
                {
                    comandoSelect = comandoSelect + "where " + clave + " = 0 or Clave = " + clave;
                }
                else
                {
                    if (busqueda != "")
                        comandoSelect = comandoSelect + "where Descripcion like '%" + busqueda + "%'";
                }

                tabla = "Cajas";

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
                comandoSelect = "select Clave, Descripcion [Caja], Ubicacion [Ubicación], case when Estatus = 1 then 'Activo' else 'Inactivo' end [EstatusLetra], Estatus ,TipoCajaId,Sucursal "
                                + "from cat_cajas "
                                + "where Clave " + (verificarNoExistaClave ? "!" : "") + "= " + clave;

                tabla = "Cajas";

                dt = con.Select(comandoSelect, tabla);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de consultar el registro. " + ex.Message;
            }
            return dt;
        }

        public Resultado Agregar(int clave, string descripcion, string ubicacion, bool estatus, int? empresa, int? sucursal, int tipoCajaId)
        {
            resultado = new Resultado();
            string comandoInsert = "";
            string strEmpresa = empresa == null ? "null" : empresa.ToString();
            string strSucursal = sucursal == null ? "null" : sucursal.ToString();
            try
            {
                if(tipoCajaId <= 0)
                {
                    resultado.ok = false;
                    resultado.mensaje = "El tipo es requerido";
                    return resultado;
                }
                comandoInsert = "insert into cat_cajas "
                                + "(Clave, Descripcion, Ubicacion, Estatus, Empresa, Sucursal) "
                                + "values(" + clave + ", '" + descripcion + "', '" + ubicacion + "', " + (estatus == true ? 1 : 0) + ", " + strEmpresa + ", " + strSucursal + ")";


                resultado = con.Insert(comandoInsert);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de insertar los datos. " + ex.Message;
            }

            return resultado;
        }

        public Resultado Actualizar(int clave, string descripcion, string ubicacion, bool estatus, int? empresa, int? sucursal, int tipoCajaId)
        {
            resultado = new Resultado();
            string strEmpresa = empresa == null ? "null" : empresa.ToString();
            string strSucursal = sucursal == null ? "null" : sucursal.ToString();
            string comandoUpdate = "";
            try
            {
                if (tipoCajaId <= 0)
                {
                    resultado.ok = false;
                    resultado.mensaje = "El tipo es requerido";
                    return resultado;
                }
                comandoUpdate = "update cat_cajas "
                                + "set Descripcion = '" + descripcion + "', Ubicacion = '" + ubicacion + "', Estatus = " + (estatus == true ? 1 : 0) + ",TipoCajaId= " + tipoCajaId.ToString() +" ,Sucursal = "+ strSucursal + " "
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
                comandoDelete = string.Format("delete from cat_cajas where Clave = {0}", clave);
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
                comandoSelect = "select Clave, Descripcion from cat_cajas where Estatus = 1";
                tabla = "Cajas";

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
