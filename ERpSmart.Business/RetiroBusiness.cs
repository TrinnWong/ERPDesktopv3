using ConexionBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class RetiroBusiness : BusinessObject
    {
        public static p_retiro_automatico_SiNo_Result p_retiro_automatico_SiNo(int pSucursalId, int pCajaId)
        {
            ERPProdEntities oContext = new ERPProdEntities();
            using (SqlConnection connection = new SqlConnection(oContext.Database.Connection.ConnectionString))
            {                
                connection.Open();

                using (SqlCommand command = new SqlCommand("p_retiro_automatico_SiNo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agrega los parámetros al procedimiento almacenado
                    command.Parameters.AddWithValue("@pSucursalId", pSucursalId);
                    command.Parameters.AddWithValue("@pCajaId", pCajaId);

                    // Crea el objeto de resultado
                    p_retiro_automatico_SiNo_Result result = new p_retiro_automatico_SiNo_Result();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Lee los valores del resultado y asigna al objeto result
                            result.AplicaSiNo = Convert.ToBoolean(reader["AplicaSiNo"]);
                            result.CantidadDisponibleRetiro = Convert.ToDecimal(reader["CantidadDisponibleRetiro"]);
                        }
                    }

                    return result;
                }

               
            }

        }
    }
}
