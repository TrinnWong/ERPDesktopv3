using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionBD.Utilerias;
using System.Data;

namespace ConexionBD
{
    public class Business
    {
        CadenaConexion con;
        //SqlConnection Con = new SqlConnection("Data Source=.; Initial Catalog=ERP;Integrated Security=True");    
        private SqlCommandBuilder cb;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;
        public SqlCommand comando;
        Resultado resultado;

        public Business()
        {
            con = new CadenaConexion();
        }

        public DataTable Select(string sql, string tabla)
        {
            ds.Tables.Clear();
            da = new SqlDataAdapter(sql, con.sqlCon);
            cb = new SqlCommandBuilder(da);
            da.Fill(ds, tabla);
            return ds.Tables[tabla];
        }

        public Resultado Insert(string sql)
        {
            resultado = new Resultado();
            try
            {
                con.sqlCon.Open();
                comando = new SqlCommand(sql, con.sqlCon);
                int i = comando.ExecuteNonQuery();
                if (i > 0)
                {
                    resultado.ok = true;
                    resultado.mensaje = "Los datos se agregarón correctamente";
                }
                else
                {
                    resultado.mensaje = "No se insertó el registro";
                }
                con.sqlCon.Close();
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrión un error al querer insertar lo datos. " + ex.Message;
                con.sqlCon.Close();
            }
            return resultado;
        }

        public Resultado Insert(string sql, byte[] foto)
        {
            resultado = new Resultado();
            try
            {
                con.sqlCon.Open();
                comando = new SqlCommand(sql, con.sqlCon);
                comando.Parameters.AddWithValue("@Pic", foto);
                int i = comando.ExecuteNonQuery();
                if (i > 0)
                {
                    resultado.ok = true;
                    resultado.mensaje = "Los datos se agregarón correctamente";
                }
                else
                {
                    resultado.mensaje = "No se insertó el registro";
                }
                con.sqlCon.Close();
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrión un error al querer insertar lo datos. " + ex.Message;
                con.sqlCon.Close();
            }
            return resultado;
        }

        public Resultado Update(string sql)
        {
            resultado = new Resultado();
            try
            {
                con.sqlCon.Open();
                comando = new SqlCommand(sql, con.sqlCon);
                int i = comando.ExecuteNonQuery();
                if (i > 0)
                {
                    resultado.ok = true;
                    resultado.mensaje = "Los datos se actualizarón correctamente";
                }
                else
                {
                    resultado.mensaje = "No se actualizó el registro";
                }
                con.sqlCon.Close();
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al querer actualizar el registro. " + ex.Message;
                con.sqlCon.Close();
            }
            return resultado;
        }

        public Resultado Update(string sql, byte[] foto)
        {
            resultado = new Resultado();
            try
            {
                comando = new SqlCommand(sql, con.sqlCon);
                comando.Parameters.AddWithValue("@Pic", foto);
                con.sqlCon.Open();
                int i = comando.ExecuteNonQuery();
                if (i > 0)
                {
                    resultado.ok = true;
                    resultado.mensaje = "Los datos se actualizarón correctamente";
                }
                else
                {
                    resultado.mensaje = "No se actualizó el registro";
                }
                con.sqlCon.Close();
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al querer actualizar el registro. " + ex.Message;
                con.sqlCon.Close();
            }
            return resultado;
        }

        public Resultado Delete(string sql)
        {
            resultado = new Resultado();
            try
            {
                con.sqlCon.Open();
                comando = new SqlCommand(sql, con.sqlCon);
                int i = comando.ExecuteNonQuery();
                if (i > 0)
                {
                    resultado.ok = true;
                    resultado.mensaje = "Los datos se eliminarón correctamente";
                }
                else
                {
                    resultado.mensaje = "No se eliminó el registro";
                }
                con.sqlCon.Close();
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al querer eliminar el registro. " + ex.Message;
                con.sqlCon.Close();
            }
            return resultado;
        }
    }
    
}
