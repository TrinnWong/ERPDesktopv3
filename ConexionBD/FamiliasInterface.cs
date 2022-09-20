using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionBD.Utilerias;

namespace ConexionBD
{
    public class FamiliasInterface
    {
        Business con;
        Resultado resultado;

        public FamiliasInterface()
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
                comandoSelect = "select Clave, Descripcion as [Nombre Familia], case when Estatus = 1 then 'Activo' else 'Inactivo' end as [Estatus] from cat_familias ";
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
                    
                tabla = "Familias";

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
                    comandoSelect = "select Clave, Descripcion as [Nombre Familia],ProductoPortadaId=isnull(ProductoPortadaId,0), Descripcion, case when Estatus = 1 then 'Activo' else 'Inactivo' end as [EstatusLetra], Estatus,Orden "
                                    + "from cat_familias "
                                    + "where Clave "+ (verificarNoExistaClave  ? "!" : "")+ "= " + clave;
                
                tabla = "Familias";

                dt = con.Select(comandoSelect, tabla);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de consultar el registro. " + ex.Message;
            }
            return dt;
        }

        public Resultado Agregar(int clave, string descripcion, bool estatus, int? empresa, 
            int? sucursal,
            int Orden,
            int? productoProtadaId)
        {
            resultado = new Resultado();
            string comandoInsert = "";
            string strEmpresa = empresa == null ? "null" : empresa.ToString();
            string strSucursal = sucursal == null ? "null" : sucursal.ToString();
            string strProductoPortada = productoProtadaId == null || productoProtadaId == 0 ? "null" : productoProtadaId.ToString();
            try
            {
                comandoInsert = "insert into cat_familias "
                                + "(Clave, Descripcion, Estatus, Empresa, Sucursal,ProductoPortadaId,Orden) "
                                + "values(" + clave + ", '" + descripcion + "', " + (estatus ? 1 : 0) + ", " + strEmpresa + ", " + strSucursal + ","+ strProductoPortada+","+Orden.ToString()+")";
                resultado = con.Insert(comandoInsert);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de insertar los datos. " + ex.Message;
            }

            return resultado;
        }

        public Resultado Actualizar(int clave, string descripcion, bool estatus, 
            int orden,
            int? productoProtadaId)
        {
            resultado = new Resultado();
            string comandoUpdate = "";
            string strProductoPortada = productoProtadaId == null || productoProtadaId == 0 ? "null" : productoProtadaId.ToString();
            try
            {
                comandoUpdate = "update cat_familias "
                                +"set Descripcion = '"+ descripcion + "', Estatus = " + (estatus ? 1 : 0) + ", "
                                +"ProductoPortadaId = " + strProductoPortada + ","+
                                "Orden = "+orden.ToString()+
                                 " where Clave = " + clave;
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
                comandoDelete = string.Format("delete from cat_familias where Clave = {0}", clave);
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
                comandoSelect = "select Clave, Descripcion from cat_familias where Estatus = 1";
                tabla = "Familias";

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
