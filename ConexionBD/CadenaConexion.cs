﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class CadenaConexion
    {
        public SqlConnection sqlCon;
        public SqlConnection sqlConMaster;
        public CadenaConexion()
        {
           
                var efConnectionString = !ConexionBD.Enumerados.CS.Contains("##SERVERDB##") ? "metadata = res://*/ERPModel.csdl|res://*/ERPModel.ssdl|res://*/ERPModel.msl;provider=System.Data.SqlClient;provider connection string=\"" +ConexionBD.Enumerados.CS+"\"":
                                          ConfigurationManager.ConnectionStrings["ERPProdEntities"].ConnectionString;
                //ConfigurationManager.ConnectionStrings["ERPProdEntities"].ConnectionString;
                var builder = new EntityConnectionStringBuilder(efConnectionString);
                var regularConnectionString = builder.ProviderConnectionString;

                sqlCon = new SqlConnection(regularConnectionString);

                if (ConfigurationManager.ConnectionStrings["ERPProdMaster"] != null)
                {
                    var efConnectionString2 = ConfigurationManager.ConnectionStrings["ERPProdMaster"].ConnectionString;
                    var builder2 = new EntityConnectionStringBuilder(efConnectionString2);
                    var regularConnectionString2 = builder2.ProviderConnectionString;

                    sqlConMaster = new SqlConnection(regularConnectionString2);
                }
            
               
       
        }

       


        //PROD BANGO
        //public SqlConnection sqlCon = new SqlConnection("Data Source=(LocalDB)\\localdb2014;attachdbfilename=|DataDirectory|\\ERPprod.mdf;integrated security=True;MultipleActiveResultSets=True;");
        //DEV BANGO
        // public SqlConnection sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;attachdbfilename=|DataDirectory|\\ERPprod.mdf;integrated security=True;MultipleActiveResultSets=True;");

        //DEV_INTERNO
        //public SqlConnection sqlCon = new SqlConnection("Data Source=EC2AMAZ-QCNOKHJ\\SQLEXPRESS2017;initial catalog=ERPDev;user id=sa;password=Trinn2018;;MultipleActiveResultSets=True;");

        //DEV_ZAPATOS
        //public SqlConnection sqlCon = new SqlConnection("Data Source=LAPTOP-056\\SQL2012;initial catalog=ERPProd;user id=sa;password=desarrollo;;MultipleActiveResultSets=True;");

        //PROD ZAPATOS
        //public SqlConnection sqlCon = new SqlConnection("Data Source=sql5003.site4now.net;initial catalog=DB_A2ABCA_maszapatos;user id=DB_A2ABCA_maszapatos_admin;password=trinn2018;;MultipleActiveResultSets=True;");

        //demo cloud ZAPATOS
        //public SqlConnection sqlCon = new SqlConnection("Data Source=sql5007.site4now.net;initial catalog=DB_A2ABCA_ERPTest;user id=DB_A2ABCA_ERPTest_admin;password=trinn2018;;MultipleActiveResultSets=True;");

    }
}
