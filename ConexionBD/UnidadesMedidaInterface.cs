using ConexionBD.Utilerias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class UnidadesMedidaInterface
    {
        Business con;
        Resultado resultado;
        ERPProdEntities model;

        public UnidadesMedidaInterface()
        {
            model = new ERPProdEntities();
            con = new Business();
        }

        public DataTable ConsultarListado(string busqueda)
        {
            string comandoSelect = "", tabla = "";
            resultado = new Resultado();

            DataTable dt = new DataTable();
            try
            {
                comandoSelect = "select Clave, Descripcion [Nombre Unidad Medida], DescripcionCorta [Nombre Corto], Decimales, case when Estatus = 1 then 'Activo' else 'Inactivo' end [Estatus] from cat_unidadesmed ";
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

                tabla = "UnidadesMedida";

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
                comandoSelect = "select  Clave, Descripcion [Nombre Unidad Medida], DescripcionCorta [Nombre Corto], Decimales, case when Estatus = 1 then 'Activo' else 'Inactivo' end [EstatusLetra], Estatus,IdCodigoSAT "
                                + "from cat_unidadesmed "
                                + "where Clave " + (verificarNoExistaClave ? "!" : "") + "= " + clave;

                tabla = "UnidadesMedida";

                dt = con.Select(comandoSelect, tabla);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de consultar el registro. " + ex.Message;
            }
            return dt;
        }

        public Resultado Agregar(int clave, string descripcion, string nomCorto, int? decimales, bool estatus, int? empresa, int? sucursal,
            int idCodigoSAT
            /*,
            int marca, int familia, int subfamilia, int linea, int unidad, int inventariadoPor, int? vendidoPor, bool? productoTerminado, bool? inventariable,
            bool? materiaPrima, bool? prodParaVenta, bool? ProdVtaBascula, bool? seriado, decimal? PorcDescuentoEmpleado, int? ContenidoCaja, byte[] foto*/)
        {
            resultado = new Resultado();
            string strEmpresa = empresa == null ? "null" : empresa.ToString();
            string strSucursal = sucursal == null ? "null" : sucursal.ToString();
            string comandoInsert = "";
            try
            {
                //model.p_cat_productos_ins(0, clave, descripcion, nomCorto, DateTime.Now, marca, familia, subfamilia, linea, unidad, inventariadoPor,
                //    vendidoPor, estatus, productoTerminado, inventariable, materiaPrima, prodParaVenta, ProdVtaBascula, seriado,(byte?)decimales, PorcDescuentoEmpleado,
                //     ContenidoCaja, empresa, sucursal, foto);
                comandoInsert = "insert into cat_unidadesmed "
                                + "(Clave, Descripcion, DescripcionCorta, Decimales, Estatus, Empresa, Sucursal,IdCodigoSAT) "
                                + "values(" + clave + ", '" + descripcion + "', '" + nomCorto + "', " + decimales + ", " + (estatus == true ? 1 : 0) + ", " + strEmpresa + ", " + strSucursal +","
                                 + idCodigoSAT.ToString() + ")";
                resultado = con.Insert(comandoInsert);

            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de insertar los datos. " + ex.Message;
            }

            return resultado;
        }

        public Resultado Actualizar(int clave, string descripcion, string nomCorto, int decimales, bool estatus,
            int idCodigoSAT)
        {
            resultado = new Resultado();
            string comandoUpdate = "";
            try
            {
                comandoUpdate = "update cat_unidadesmed "
                                + "set Descripcion = '" + descripcion + "',"
                                + "DescripcionCorta = '" + nomCorto + "', "
                                + "Decimales = " + decimales + ", "
                                + "Estatus = " + (estatus == true ? 1 : 0) + ", "
                                + "IdCodigoSAT = " + idCodigoSAT.ToString() + " "
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
                comandoDelete = string.Format("delete from cat_unidadesmed where Clave = {0}", clave);
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
                comandoSelect = "select Clave, Descripcion from cat_unidadesmed where Estatus = 1";
                tabla = "UnidadesMedida";

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
