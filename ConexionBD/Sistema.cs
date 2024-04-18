using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConexionBD
{
    public class Sistema:BusinessObject
    {
        public static string scMain = "data source=sql5110.site4now.net;initial catalog=db_a2abca_tacosanamain;user id=db_a2abca_tacosanamain_admin;password=Trinn2023_;MultipleActiveResultSets=True;App=EntityFramework;";

        public static string ObtenVersion()
        {
            return "versión:2024.04.17";
        }
        public string actualizarVersion(bool recortado)
        {
            ERPProdEntities oContextNube = new ERPProdEntities(true);
            string error = "";
            try
            {
                string directorioRaiz = AppDomain.CurrentDomain.BaseDirectory;


                string root = AppDomain.CurrentDomain.BaseDirectory;
                string script = "";

                #region master

                try
                {
                    #region crear base de datos local

                    //CREAR CARPETA ERP en C
                    if (!Directory.Exists(@"C:\ERP"))
                    {
                        try
                        {
                            // Crear la carpeta si no existe
                            Directory.CreateDirectory(@"C:\ERP");
                            Console.WriteLine("Carpeta creada correctamente.");
                        }
                        catch (Exception ex)
                        {
                           
                        }
                    }

                    ServerConnection connMaster = new ServerConnection(oStringConnection.sqlLocalMaster);
                    Server serverMaster = new Server(connMaster);
                    string[] archivosMaster = null;

                    archivosMaster = System.IO.Directory.GetFiles(@"Versiones\00Local\");


                    foreach (var a in archivosMaster)
                    {
                        try
                        {
                            script = File.ReadAllText(root + a.ToString());
                            serverMaster.ConnectionContext.ExecuteNonQuery(script);

                            File.Delete(root + a.ToString());

                        }
                        catch (Exception ex)
                        {
                        }
                       
                    }

                    oStringConnection.sqlLocalMaster.Close();
                    #endregion
                }
                catch (Exception ex)
                {

                    oStringConnection.sqlLocalMaster.Close();
                }
                #endregion




                //Conectar al servidor
                ServerConnection conn = new ServerConnection(oStringConnection.sqlCon);
                Server server = new Server(conn);

                ServerConnection connNube = null;
                Server serverNube = null;
               
              

                //Ejecutar todos los scripts 00

                #region inicializacion

                string install = File.ReadAllText(root + @"Versiones\install.txt");

                string[] archivos = System.IO.Directory.GetFiles(@"Versiones\00\");

                foreach (var a in archivos)
                {
                    script = File.ReadAllText(root+a.ToString());
                    server.ConnectionContext.ExecuteNonQuery(script);
                }
                #endregion

                #region insertar paquete de scripts

                oContext.p_sis_versiones_ins(install);
               
                string[] installFolders = install.Split(',');

                foreach (var itemFolder in installFolders)
                {
                    archivos = System.IO.Directory.GetFiles(@"Versiones\"+ itemFolder.ToString());


                    //Guardar archivos a ejecutar
                    foreach (var a in archivos)
                    {
                        oContext.p_sis_versiones_detalle_ins(itemFolder, Path.GetFileName(a.ToString()));
                       
                    }                  
                   

                }

                //Ejecutar scripts y guardar si terminó con éxito
                oContext = new ERPProdEntities();
                
                //ACTUALIZAR LOCAL
                foreach (var itemFolder in installFolders)
                {
                    
                    List<sis_versiones_detalle> lstScriptsDetalle = new List<sis_versiones_detalle>();
                    
                    lstScriptsDetalle = oContext.sis_versiones_detalle
                           .Where(w => w.sis_versiones.Nombre == itemFolder && !w.Completado).ToList();

                    //Intentar ejecutar cada uno de los scripts de la versión
                    foreach (sis_versiones_detalle itemScript in lstScriptsDetalle)
                    {
                        try
                        {
                            string pathScript = root + "Versiones\\" + itemFolder + "\\" + itemScript.ScriptName;
                            script = File.ReadAllText(pathScript);
                            server.ConnectionContext.ExecuteNonQuery(script);

                            itemScript.Completado = true;

                            oContext.SaveChanges();

                            //File.Delete(pathScript);
                        }
                        catch (Exception ex)
                        {
                            error = ex.InnerException != null ? "SCRIPT: "+ itemScript.ScriptName+"|"+ ex.InnerException.Message : ex.Message;
                            return error;
                        }                    
                        
                    }

                    //marcar la versión como completada o pendienete
                    sis_versiones entityVersiones = oContext.sis_versiones.Where(w => w.Nombre == itemFolder).FirstOrDefault();
                    int versionId = entityVersiones != null ? entityVersiones.VersionId : 0;

                    if (
                        oContext.sis_versiones_detalle
                        .Where(
                            w => w.VersionId == versionId
                            && w.Completado == false
                            ).Count() == 0
                        )
                    {
                        entityVersiones.Completado = true;

                    }
                    else {
                        entityVersiones.Completado = false;
                    }
                    entityVersiones.Intentos++;

                    oContext.SaveChanges();



                }
                //ACTUALIZAR NUBE
                if (ValidateInternet())
                {
                    if (oStringConnection.sqlConMaster != null)
                    {
                        connNube = new ServerConnection(oStringConnection.sqlConMaster);
                        serverNube = new Server(connNube);
                    }

                    oContextNube.p_sis_versiones_ins(install);

                   

                    foreach (var itemFolder in installFolders)
                    {
                        archivos = System.IO.Directory.GetFiles(@"Versiones\" + itemFolder.ToString());


                        //Guardar archivos a ejecutar
                        foreach (var a in archivos)
                        {
                            oContextNube.p_sis_versiones_detalle_ins(itemFolder, Path.GetFileName(a.ToString()));

                        }


                    }


                    if (serverNube != null)
                    {
                        oContextNube = new ERPProdEntities(true);
                        foreach (var itemFolder in installFolders)
                        {

                            List<sis_versiones_detalle> lstScriptsDetalle = new List<sis_versiones_detalle>();

                            lstScriptsDetalle = oContextNube.sis_versiones_detalle
                                   .Where(w => w.sis_versiones.Nombre == itemFolder && !w.Completado).ToList();

                            //Intentar ejecutar cada uno de los scripts de la versión
                            foreach (sis_versiones_detalle itemScript in lstScriptsDetalle)
                            {
                                try
                                {
                                    string pathScript = root + "Versiones\\" + itemFolder + "\\" + itemScript.ScriptName;
                                    script = File.ReadAllText(pathScript);
                                    serverNube.ConnectionContext.ExecuteNonQuery(script);

                                    itemScript.Completado = true;

                                    oContextNube.SaveChanges();

                                    File.Delete(pathScript);
                                }
                                catch (Exception ex)
                                {
                                    error = ex.InnerException != null ? "SCRIPT: " + itemScript.ScriptName + "|" + ex.InnerException.Message : ex.Message;
                                    return error;
                                }

                            }

                            //marcar la versión como completada o pendienete
                            sis_versiones entityVersiones = oContextNube.sis_versiones.Where(w => w.Nombre == itemFolder).FirstOrDefault();
                            int versionId = entityVersiones != null ? entityVersiones.VersionId : 0;

                            if (
                                oContextNube.sis_versiones_detalle
                                .Where(
                                    w => w.VersionId == versionId
                                    && w.Completado == false
                                    ).Count() == 0
                                )
                            {
                                entityVersiones.Completado = true;

                            }
                            else
                            {
                                entityVersiones.Completado = false;
                            }
                            entityVersiones.Intentos++;

                            oContextNube.SaveChanges();



                        }
                    }
                }
               
              

                #endregion

                #region recortado

                try
                {
                    if(recortado)
                    {

                   
                    #region Recortado
                    ServerConnection connMaster = new ServerConnection(oStringConnection.sqlConMaster);
                    Server serverMaster = new Server(connMaster);
                    string[] archivosMaster = null;

                    archivosMaster = System.IO.Directory.GetFiles(@"Versiones\99_REC\");


                    foreach (var a in archivosMaster)
                    {
                        try
                        {
                            script = File.ReadAllText(root + a.ToString());
                            serverMaster.ConnectionContext.ExecuteNonQuery(script);

                            File.Delete(root + a.ToString());

                        }
                        catch (Exception ex)
                        {
                        }

                    }
                        #endregion

                    }
                }
                catch (Exception ex)
                {


                }
                #endregion


            }
            catch (Exception ex)
            {
                error = ex.InnerException != null ? ex.InnerException.Message: ex.Message;               
            }




            return error;
        }

        public  bool ValidateInternet()
        {
            string estadoConexionaRed = "";
            bool RedActiva = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

            if (!RedActiva)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string respaldoDB()
        {
            string folderBackUp = @"C:\ERP_BACKUP\";
            string error = "";
            string script = "";
            string root = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                if (!Directory.Exists(folderBackUp))
                {
                    Directory.CreateDirectory(folderBackUp);
                }

                ServerConnection connMaster = new ServerConnection(oStringConnection.sqlConMaster);
                Server serverMaster = new Server(connMaster);

                script = File.ReadAllText(root + "Versiones\\Utilerias\\00_BACKUP.sql");

                serverMaster.ConnectionContext.ExecuteNonQuery(script);


            }
            catch (Exception ex)
            {

                error = ex.Message;
            }
            return error;
        }


        public static int ObtenSucursalConfigLocal()
        {
            string path = Directory.GetCurrentDirectory();
            bool exists = File.Exists(path + @"\\config.txt");

            if (exists)
            {
                string lecturaSucursal = File.ReadAllText(path + @"\\config.txt");


                if (lecturaSucursal.Length > 0)
                {
                    var empresaRegistrada = lecturaSucursal.Split(',');

                    return Convert.ToInt32(empresaRegistrada[1]);
                }
                else
                {
                    return 0;
                }


            }


            return 0;
        }

        public static int ObtenEmpresaConfigLocal()
        {
            string path = Directory.GetCurrentDirectory();
            bool exists = File.Exists(path + @"\\config.txt");

            if (exists)
            {
                string lecturaSucursal = File.ReadAllText(path + @"\\config.txt");


                if (lecturaSucursal.Length > 0)
                {
                    var empresaRegistrada = lecturaSucursal.Split(',');

                    return Convert.ToInt32(empresaRegistrada[0]);
                }
                else
                {
                    return 0;
                }
                
                
            }


            return 0;
        }
    }
}
