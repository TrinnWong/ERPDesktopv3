using ConexionBD.Utilerias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class GastosInterface
    {
        Business con;
        Resultado resultado;
        ERPProdEntities oContext;

        public GastosInterface()
        {
            con = new Business();
            oContext = new ERPProdEntities();
        }

        public DataTable ConsultarListado(string busqueda)
        {
            string comandoSelect = "", tabla = "";
            resultado = new Resultado();

            DataTable dt = new DataTable();
            try
            {
                int clave = 0;
                comandoSelect = "select g.Clave, g.Descripcion as Descripción, cc.Descripcion [Centro de Costos], case when g.Estatus = 1 then 'Activo' else 'Inactivo' end [Estatus] "
                                + "from cat_gastos g "
                                + "inner join cat_centro_costos cc on cc.Clave = g.ClaveCentroCosto ";
                if (int.TryParse(busqueda, out clave))
                {
                    comandoSelect = comandoSelect + "where " + clave + " = 0 or sf.Clave = " + clave;
                }
                else
                {
                    if (busqueda != "")
                        comandoSelect = comandoSelect + "where g.Descripcion like '%" + busqueda + "%' or cc.Descripcion like '%" + busqueda + "%'";
                }

                tabla = "Gastos";

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
                comandoSelect = "select Clave, Descripcion, ClaveCentroCosto, Estatus "
                                + "from cat_gastos "
                                + "where Clave " + (verificarNoExistaClave ? "!" : "") + "= " + clave;
                tabla = "Gastos";

                dt = con.Select(comandoSelect, tabla);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de consultar el registro. " + ex.Message;
            }
            return dt;
        }

        public Resultado Agregar(int clave, string descripcion, int ClaCentrocosto, bool estatus, int? empresa, int? sucursal)
        {
            resultado = new Resultado();
            string comandoInsert = "";
            string strEmpresa = empresa == null ? "null" : empresa.ToString();
            string strSucursal = sucursal == null ? "null" : sucursal.ToString();
            try
            {
                comandoInsert = "insert into cat_gastos "
                                + "(Clave, Descripcion, ClaveCentroCosto, Estatus, Empresa, Sucursal) "
                                + "values(" + clave + ", '" + descripcion + "', " + ClaCentrocosto + ", " + (estatus ? 1 : 0) + ", " + strEmpresa + ", " + strSucursal + ")";
                resultado = con.Insert(comandoInsert);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de insertar los datos. " + ex.Message;
            }

            return resultado;
        }

        public Resultado Actualizar(int clave, string descripcion, int ClaCentrocosto, bool estatus)
        {
            resultado = new Resultado();
            string comandoUpdate = "";
            try
            {
                comandoUpdate = "update cat_gastos "
                                + "set Descripcion = '" + descripcion + "', "
                                + "ClaveCentroCosto = " + ClaCentrocosto + ", "
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
                comandoDelete = string.Format("delete from cat_gastos where Clave = {0}", clave);
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
                comandoSelect = "select Clave, Descripcion from cat_gastos where Estatus = 1";
                tabla = "Gastos";

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

        public string InsertargastoVenta(
            doc_gastos entity
            )
        {
            string error="";
            try
            {
                if (
                    entity.CentroCostoId <= 0
                    )
                {
                    error = "El centro de costos es requerido";
                }
                if (
                    entity.GastoConceptoId <= 0
                    )
                {
                    error = error + "|El concepto es requerido"; 
                }
                if (entity.Monto <= 0)
                {
                    error = error + "|El monto es requerido";
                }

                if (error.Length > 0)
                {
                    return error;
                }

                oContext.doc_gastos.Add(entity);
                oContext.SaveChanges();


            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }

        public string ActualizarrgastoVenta(
          doc_gastos entity
          )
        {
            string error = "";
            try
            {
               

                
                oContext.SaveChanges();


            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }

    }
}
