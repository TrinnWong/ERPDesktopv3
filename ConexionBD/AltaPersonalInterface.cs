using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionBD.Utilerias;
using System.Data;
using System.Data.SqlClient;

namespace ConexionBD
{
    public class AltaPersonalInterface
    {
        Business con;
        Resultado resultado;
        CadenaConexion cc;
        SqlCommand cmd;
        ERPProdEntities oContext;

        public AltaPersonalInterface()
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
            {// t1.Foto,
                comandoSelect = "select t1.NumEmpleado as [Clave], t1.Nombre, t2.Descripcion [Puesto], t3.Descripcion [Departamento], isnull(t4.Descripcion, '') [Forma Pago], "
                                + "isnull(t5.Descripcion, '') [Tipo Contrato], '$'+cast(cast(t1.SueldoNeto as decimal(19,2)) as varchar) [Sueldo Neto], '$'+cast(cast(t1.SueldoDiario as decimal(19,2)) as varchar) [Sueldo Diario], "
                                + "'$'+cast(cast(t1.SueldoHra as decimal(19,2)) as varchar) [Sueldo Hora], case when t1.Estatus = 1 then 'Activo' else 'Inactivo' end as [Estatus], t1.FechaIngreso "
                                + "from rh_empleados t1 "
                                + "left join rh_puestos t2 on t2.Clave = t1.Puesto "
                                + "left join rh_departamentos t3 on t3.Clave = t1.Departamento "
                                + "left join rh_formaspagonom t4 on t4.Clave = t1.FormaPago "
                                + "left join rh_tipos_contrato t5 on t5.Clave = t1.TipoContrato ";
                int clave = 0;
                if (int.TryParse(busqueda, out clave))
                {
                    comandoSelect = comandoSelect + "where " + clave + " = 0 or NumEmpleado = " + clave;
                }
                else
                {
                    if (busqueda != "")
                        comandoSelect = comandoSelect + "where Nombre like '%" + busqueda + "%'";
                }

                tabla = "AltaPersonal";

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
                comandoSelect = "select NumEmpleado, Nombre, SueldoNeto, SueldoDiario, SueldoHra, FormaPago, TipoContrato, Puesto, "
                                + "Departamento, FechaIngreso, FechaInicioLab, Estatus, Foto, Empresa, Sucursal "
                                + "from rh_empleados "
                                + "where NumEmpleado " + (verificarNoExistaClave ? "!" : "") + "= " + clave;
                tabla = "AltaPersonal";

                dt = con.Select(comandoSelect, tabla);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de consultar el registro. " + ex.Message;
            }
            return dt;
        }

        public Resultado Agregar(int clave, string descripcion, decimal sueldoNeto, decimal sueldoDiario, decimal sueldoHra, int formaPago, int? tipoContrato, int puesto,
            int departamento, DateTime fechaIngreso, DateTime fechaInicioLab, byte[] foto, bool estatus, int? empresa, int? sucursal)
        {
            resultado = new Resultado();
            string comandoInsert = "";
            string strEmpresa = empresa == null ? "null" : empresa.ToString();
            string strSucursal = sucursal == null ? "null" : sucursal.ToString();
            string strFormaPago = formaPago == 0 ? "null" : formaPago.ToString();
            string strFoto = foto == null ? "null" : "@Pic";
            string strtipoContrato = tipoContrato == 0 ? "null" : tipoContrato.ToString();
            string strPuesto = puesto == 0 ? "null" : puesto.ToString();
            string strDepartamento = departamento == 0 ? "null" : departamento.ToString();

            try
            {

                rh_empleados entity = new rh_empleados();
                entity.Departamento = departamento == 0 ? null : (int?)departamento;
                entity.Estatus = estatus == true ? 1 : 0;
                entity.FechaIngreso = fechaIngreso.Date;
                entity.FechaInicioLab = fechaInicioLab.Date;
                entity.FormaPago = formaPago == 0 ? null : (int?)formaPago;
                entity.Foto = foto;
                entity.Nombre = descripcion;
                entity.NumEmpleado = clave;
                entity.Puesto = puesto == 0 ? null : (int?)puesto;
                entity.Sucursal = sucursal == 0 ? null : sucursal;
                entity.SueldoDiario = sueldoDiario ;
                entity.SueldoHra = sueldoHra;
                entity.SueldoNeto = sueldoNeto;
                entity.TipoContrato = tipoContrato == 0 ? null : tipoContrato;

                oContext.rh_empleados.Add(entity);

                oContext.SaveChanges();

                oContext.p_rh_empleado_cliente_gen(entity.NumEmpleado);

                resultado.ok = true;
                resultado.mensaje = "Los datos se agregaron correctamente";

                //comandoInsert = "insert into rh_empleados "
                //                + "(NumEmpleado, Nombre, SueldoNeto, SueldoDiario, SueldoHra, FormaPago, TipoContrato, Puesto,"
                //                + "Departamento, FechaIngreso, FechaInicioLab, Foto, Estatus, Empresa, Sucursal) "
                //                + "values(" + clave + ", '" + descripcion + "', " + sueldoNeto + ", " + sueldoDiario + ", " + sueldoHra + ", " + strFormaPago
                //                + ", " + strtipoContrato + ", " + strPuesto + ", " + strDepartamento + ", '" + fechaIngreso.ToShortDateString() + "', '" 
                //                + fechaInicioLab.ToShortDateString() + "', "+ strFoto + ", " + (estatus ? 1 : 0) + ", " + strEmpresa + ", " + strSucursal + ")";
                //if (foto == null)
                //    resultado = con.Insert(comandoInsert);
                //else
                //    resultado = con.Insert(comandoInsert, foto);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de insertar los datos. " + ex.Message;
            }

            return resultado;
        }

        public Resultado Actualizar(int clave, string descripcion, decimal sueldoNeto, decimal sueldoDiario, decimal sueldoHra, int formaPago,
             int tipoContrato, int puesto, int departamento, DateTime fechaIngreso, DateTime fechaInicioLab, byte[] foto, bool estatus)
        {
            resultado = new Resultado();
            string strFormaPago = formaPago == 0 ? "null" : formaPago.ToString();
            string strFoto = foto == null ? "null" : "@Pic";
            string strtipoContrato = tipoContrato == 0 ? "null" : tipoContrato.ToString();
            string strPuesto = puesto == 0 ? "null" : puesto.ToString();
            string strDepartamento = departamento == 0 ? "null" : departamento.ToString();

            string comandoUpdate = "";
            try
            {

                rh_empleados entity = oContext.rh_empleados.Where(W => W.NumEmpleado == clave).FirstOrDefault();
                entity.Departamento = departamento == 0 ? null : (int?)departamento;
                entity.Estatus = estatus == true ? 1 : 0;
                entity.FechaIngreso = fechaIngreso.Date;
                entity.FechaInicioLab = fechaInicioLab.Date;
                entity.FormaPago = formaPago == 0 ? null : (int?)formaPago;
                entity.Foto = foto;
                entity.Nombre = descripcion;
                entity.NumEmpleado = clave;
                entity.Puesto = puesto == 0 ? null : (int?)puesto;
                //entity.Sucursal = sucursal == 0 ? null : sucursal;
                entity.SueldoDiario = sueldoDiario;
                entity.SueldoHra = sueldoHra;
                entity.SueldoNeto = sueldoNeto;
                //entity.TipoContrato = tipoContrato == 0 ? null : tipoContrato;

                // oContext.rh_empleados.Add(entity);



                oContext.SaveChanges();

                oContext.p_rh_empleado_cliente_gen(entity.NumEmpleado);


                resultado.ok = true;
                resultado.mensaje = "Los datos se agregaron correctamente";

                //comandoUpdate = "update rh_empleados "
                //                + "set Nombre = '" + descripcion + "', "
                //                + "SueldoNeto = " + sueldoNeto + ", "
                //                + "SueldoDiario = " + sueldoDiario + ", "
                //                + "SueldoHra = " + sueldoHra + ", "
                //                + "FormaPago = " + strFormaPago + ", "
                //                + "TipoContrato = " + strtipoContrato + ", "
                //                + "Puesto = " + strPuesto + ", "
                //                + "Departamento = " + strDepartamento + ", "
                //                + "FechaIngreso = '" + fechaIngreso.ToShortDateString() + "', "
                //                + "FechaInicioLab = '" + fechaInicioLab.ToShortDateString() + "', "
                //                + "Foto = "+ (foto == null ? "null" : "@Pic" ) + ", "
                //                + "Estatus = " + (estatus ? 1 : 0) + " "
                //                + "where NumEmpleado = " + clave;
                //if(foto == null)
                //    resultado = con.Update(comandoUpdate);
                //else
                //    resultado = con.Update(comandoUpdate, foto);

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
                comandoDelete = string.Format("delete from rh_empleados where NumEmpleado = {0}", clave);
                resultado = con.Delete(comandoDelete);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de eliminar los datos. " + ex.Message;
            }
            return resultado;
        }

        #region SPs

        public Resultado spAltaPersonalIns(int clave, string descripcion, decimal sueldoNeto, decimal sueldoDiario, decimal sueldoHra, int formaPago,
            int tipoContrato, int puesto, int departamento, DateTime fechaIngreso, DateTime fechaInicioLab, byte[] foto, bool estatus, int? empresa, int? sucursal)
        {
            resultado = new Resultado();
            cc = new CadenaConexion();
            cmd = new SqlCommand();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cc.sqlCon;
                cmd.CommandText = "spAltaPersonalIns";

                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pNumEmpleado", Value = clave, DbType = DbType.Int32 });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pNombre", Value = descripcion, DbType = DbType.String });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pSueldoNeto", Value = sueldoNeto, DbType = DbType.Decimal });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pSueldoDiario", Value = sueldoDiario, DbType = DbType.Decimal });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pSueldoHra", Value = sueldoHra, DbType = DbType.Decimal });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pFormaPago", Value = formaPago, DbType = DbType.Int16 });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pTipoContrato", Value = tipoContrato, DbType = DbType.Int16 });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pPuesto", Value = puesto, DbType = DbType.Int16 });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pDepartamento", Value = departamento, DbType = DbType.Int16 });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pFechaIngreso", Value = fechaIngreso, DbType = DbType.DateTime });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pFechaInicioLab", Value = fechaInicioLab, DbType = DbType.DateTime });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pEstatus", Value = estatus, DbType = DbType.Boolean });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pFoto", Value = foto });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pEmpresa", Value = empresa, DbType = DbType.Int16 });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pSucursal", Value = sucursal, DbType = DbType.Int16 });

                cc.sqlCon.Open();
                int error = cmd.ExecuteNonQuery();
                if (error > 0)
                    resultado.mensaje = "El registro se agregó correctamente";
                else
                {
                    resultado.ok = false;
                    resultado.mensaje = "No se agregarón registros";
                }
            }
            catch (Exception ex)
            {
                cc.sqlCon.Close();
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error. " + ex.Message;
            }
            return resultado;
        }


        public Resultado spAltaPersonalUpd(int clave, string descripcion, decimal sueldoNeto, decimal sueldoDiario, decimal sueldoHra, int formaPago,
            int tipoContrato, int puesto, int departamento, DateTime fechaIngreso, DateTime fechaInicioLab, byte[] foto, bool estatus)
        {
            resultado = new Resultado();
            cc = new CadenaConexion();
            cmd = new SqlCommand();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cc.sqlCon;
                cmd.CommandText = "spAltaPersonalUpd";

                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pNumEmpleado", Value = clave, DbType = DbType.Int32 });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pNombre", Value = descripcion, DbType = DbType.String });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pSueldoNeto", Value = sueldoNeto, DbType = DbType.Decimal });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pSueldoDiario", Value = sueldoDiario, DbType = DbType.Decimal });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pSueldoHra", Value = sueldoHra, DbType = DbType.Decimal });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pFormaPago", Value = formaPago, DbType = DbType.Int16 });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pTipoContrato", Value = tipoContrato, DbType = DbType.Int16 });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pPuesto", Value = puesto, DbType = DbType.Int16 });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pDepartamento", Value = departamento, DbType = DbType.Int16 });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pFechaIngreso", Value = fechaIngreso, DbType = DbType.DateTime });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pFechaInicioLab", Value = fechaInicioLab, DbType = DbType.DateTime });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pEstatus", Value = estatus, DbType = DbType.Boolean });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pFoto", Value = foto, SqlDbType = SqlDbType.Image });

                cc.sqlCon.Open();
                int error = cmd.ExecuteNonQuery();
                if (error > 0)
                    resultado.mensaje = "El registro se agregó correctamente";
                else
                {
                    resultado.ok = false;
                    resultado.mensaje = "No se agregarón registros";
                }
            }
            catch (Exception ex)
            {
                cc.sqlCon.Close();
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error. " + ex.Message;
            }
            return resultado;
        }

        #endregion

        #region ComboBox

        public DataTable ConsultaComboBox()
        {
            string comandoSelect = "", tabla = "";
            resultado = new Resultado();

            DataTable dt = new DataTable();
            try
            {
                comandoSelect = "select Clave, Descripcion from rh_empleados where Estatus = 1";
                tabla = "AltaPersonal";

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
