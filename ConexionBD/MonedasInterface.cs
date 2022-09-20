using ConexionBD.Utilerias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class MonedasInterface
    {
        Business con;
        Resultado resultado;

        public MonedasInterface()
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
                comandoSelect = "select Clave, Descripcion [Moneda], cast(cast(TipoCambio as decimal(19,2)) as varchar) [Tipo de Cambio], case when Estatus = 1 then 'Activo' else 'Inactivo' end [Estatus] from cat_monedas ";
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

                tabla = "Monedas";

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
                comandoSelect = "select IdMonedaAbreviatura,Clave,  Descripcion [Moneda], Abreviacion [Abreviación], TipoCambio , case when Estatus = 1 then 'Activo' else 'Inactivo' end [EstatusLetra], Estatus "
                                + "from cat_monedas "
                                + "where Clave " + (verificarNoExistaClave ? "!" : "") + "= " + clave;
                tabla = "Monedas";

                dt = con.Select(comandoSelect, tabla);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de consultar el registro. " + ex.Message;
            }
            return dt;
        }

        public Resultado Agregar(int clave, string descripcion, string abreviacion, decimal tipoCambio, bool estatus, int? empresa, int? sucursal,
            int? IdMonedaAbreviatura)
        {
            resultado = new Resultado();
            string strEmpresa = empresa == null ? "null" : empresa.ToString();
            string strSucursal = sucursal == null ? "null" : sucursal.ToString();
            string comandoInsert = "";
            try
            {
                comandoInsert = "insert into cat_monedas "
                                + "(Clave, Descripcion, Abreviacion, TipoCambio, Estatus, Empresa, Sucursal,IdMonedaAbreviatura) "
                                + "values(" + clave + ", '" + descripcion + "', '" + abreviacion + "', " + tipoCambio + ", " + (estatus == true ? 1 : 0) + ", " + strEmpresa + ", " 
                                + strSucursal +","+ IdMonedaAbreviatura.ToString() + ")";
                resultado = con.Insert(comandoInsert);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de insertar los datos. " + ex.Message;
            }

            return resultado;
        }

        public Resultado Actualizar(int clave, string descripcion, string abreviacion, decimal tipoCambio, bool estatus,
            int IdMonedaAbreviatura)
        {
            resultado = new Resultado();
            string comandoUpdate = "";
            try
            {
                comandoUpdate = "update cat_monedas "
                                + "set Descripcion = '" + descripcion + "',"
                                + "Abreviacion = '" + abreviacion + "', "
                                + "TipoCambio = " + tipoCambio + ", "
                                + "Estatus = " + (estatus == true ? 1 : 0) + " ,"
                                + "IdMonedaAbreviatura = " + IdMonedaAbreviatura.ToString() + " "
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
                comandoDelete = string.Format("delete from cat_monedas where Clave = {0}", clave);
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
                comandoSelect = "select Clave, Descripcion from cat_monedas where Estatus = 1";
                tabla = "Monedas";

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
