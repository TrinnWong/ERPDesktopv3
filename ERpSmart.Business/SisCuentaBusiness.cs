using ConexionBD;
using ERP.Business.Tools;
using ERP.Models.SDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ERP.Business.Enumerados;

namespace ERP.Business
{
    public class SisCuentaBusiness : BusinessObject
    {
        int err;
        string error = "";
        string resultSDK = "";
        sis_apis apiConfig;
        string token = "";
        string servidorDB = "";
        string userDB = "";
        string passwordDB = "";
        string nombreDB = "";
        public SisCuentaBusiness()
        {
            oContext = new ERPProdEntities();
        }

        public bool ValidaLicencia(int empresaId, int usuarioId, tipoProductoLicencia tipoLicencia)
        {
            try
            {
                token = ObtieneToken(empresaId, usuarioId,ref error);

                if(token.Length > 0)
                {
                    sis_cuenta cuenta =ObtieneArchivoConfiguracionCuenta();

                    if(cuenta != null)
                    {                        

                        resultSDK = HttpRequestTool.HttpGet(String.Format("{0}{1}{2}", cuenta.URLValidacion, "/api/cliente/obtenLicencias/", cuenta.ClienteKey)    
                               , token,true, ref error);

                        List<Models.SDK.ClientesLicencia> lstLicencias = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.SDK.ClientesLicencia>>(resultSDK);

                        if(lstLicencias.Count() == 0)
                        {
                            return false;
                        }
                        else
                        {
                            int tipoLicenciaN = (int)tipoLicencia;
                            if (lstLicencias.Where(w => w.Producto.Clave == tipoLicenciaN.ToString() && w.FechaCaducidad.AddDays(1) <= DateTime.Now).Count() > 0)
                            {
                                return false;
                            }
                            else {
                                return true;
                            }
                        }

                       
                    }
                    else
                    {
                        return false;
                    }

                    

                  
                }
                else
                {
                    return false;
                }

                
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                             "ERP",
                             "ERP.Business.SisCuentaBusiness",
                             ex);

                return false;
            }
        }
                     
        public string ObtieneToken(int empresaId, int usuarioId,ref string error)
        {
            
            try
            {
                sis_cuenta cuenta = ObtieneArchivoConfiguracionCuenta();

                if(cuenta == null)
                {
                    error = "Es necesario configurar la cuenta de sistema";

                }
                else
                {
                    Models.SDK.Usuario usuarioSistema = new Models.SDK.Usuario();

                    usuarioSistema.correoElectronico = cuenta.Email;
                    usuarioSistema.contrasena = cuenta.Password;
                    resultSDK = HttpRequestTool.HttpPOST(String.Format("{0}{1}",cuenta.URLValidacion,"/api/seguridad") , 
                    Newtonsoft.Json.JsonConvert.SerializeObject(usuarioSistema),ref error);

                    usuarioSistema = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.SDK.Usuario>(resultSDK);

                    if(usuarioSistema.id > 0)
                        {
                            token = usuarioSistema.token;
                            return usuarioSistema.token;
                        }
                    else
                    {
                            return "";
                    }

                    
                }

                return "";
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                              "ERP",
                              "ERP.Business.SisCuentaBusiness",
                              ex);

                error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }

            return "";
        }

        public bool TieneArchivoConfiguracionCuenta()
        {
            try
            {
                string path = Application.StartupPath + @"\SystemForms.txt";
                string text = System.IO.File.ReadAllText(path);

                if(text.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

               
            }
            catch (Exception)
            {              
               
                return false;
            }
        }

        public sis_cuenta ObtieneArchivoConfiguracionCuenta()
        {
            sis_cuenta result;
            string[] fileConfig;
            try
            {
                string path = Application.StartupPath + @"\config.txt";
                string text = System.IO.File.ReadAllText(path);

                if (text.Length > 0)
                {
                    result = new sis_cuenta();

                    fileConfig = text.Split(',');

                    //result.ClienteKey = fileConfig[0];
                    //result.Email = fileConfig[1];
                    //result.Password = fileConfig[2];
                    //result.URLValidacion = fileConfig[3].Replace("\n","").Replace("\r","");
                    result.ClaveSucursal = Convert.ToInt32(fileConfig[1].Replace("\n", "").Replace("\r", ""));
                    return result;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception)
            {

                return null;
            }
        }

        public sis_cuenta GuardaArchivoConfiguracionCuenta(sis_cuenta datos)
        {
            try
            {
                string path = Application.StartupPath + @"\SystemForms.txt";
                using (StreamWriter outputFile = new StreamWriter(path))
                {                   
                        outputFile.WriteLine(datos.ClienteKey + "|"+datos.Email+"|"+datos.Password+"|"+datos.URLValidacion+"|"+datos.ClaveSucursal);
                }
                return datos;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool CreateConnection(int tipo)
        {
            try
            {
                ObtieneToken(1, 1, ref error);
                if(token.Length > 0)
                {
                    sis_cuenta cuenta = ObtieneArchivoConfiguracionCuenta();

                    resultSDK = HttpRequestTool.HttpGet(String.Format("{0}{1}{2}{3}", cuenta.URLValidacion, "/api/cliente/obtenClienteBD/", cuenta.ClienteKey,"/"+tipo.ToString())
                              , token, true, ref error);

                    Models.SDK.ClientesBd clienteBD = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.SDK.ClientesBd>(resultSDK);
                    Encript encript = new Encript();

                   

                    if (clienteBD != null)
                    {
                        //Servidor
                        encript.data = clienteBD.ServidorBd;
                        resultSDK = HttpRequestTool.HttpPOST(
                            String.Format("{0}{1}", cuenta.URLValidacion, "/api/Encript/decript"), Newtonsoft.Json.JsonConvert.SerializeObject(encript)
                             , ref error);

                        encript = Newtonsoft.Json.JsonConvert.DeserializeObject<Encript>(resultSDK);

                        servidorDB = encript.decript;

                        ////UsuarioDB
                        encript.data = clienteBD.UsuarioBd;
                        resultSDK = HttpRequestTool.HttpPOST(
                            String.Format("{0}{1}", cuenta.URLValidacion, "/api/Encript/decript"), Newtonsoft.Json.JsonConvert.SerializeObject(encript)
                             , ref error);

                        encript = Newtonsoft.Json.JsonConvert.DeserializeObject<Encript>(resultSDK);

                        userDB = encript.decript;

                        ////Password
                        encript.data = clienteBD.Password;
                        resultSDK = HttpRequestTool.HttpPOST(
                            String.Format("{0}{1}", cuenta.URLValidacion, "/api/Encript/decript"), Newtonsoft.Json.JsonConvert.SerializeObject(encript)
                             , ref error);

                        encript = Newtonsoft.Json.JsonConvert.DeserializeObject<Encript>(resultSDK);

                        passwordDB = encript.decript;

                        ////Password
                        encript.data = clienteBD.NombreBd;
                        resultSDK = HttpRequestTool.HttpPOST(
                            String.Format("{0}{1}", cuenta.URLValidacion, "/api/Encript/decript"), Newtonsoft.Json.JsonConvert.SerializeObject(encript)
                             , ref error);

                        encript = Newtonsoft.Json.JsonConvert.DeserializeObject<Encript>(resultSDK);

                        nombreDB = encript.decript;

                        ConexionBD.Enumerados.CS = ConexionBD.Enumerados.CS.Replace("##SERVERDB##", servidorDB);
                        ConexionBD.Enumerados.CS = ConexionBD.Enumerados.CS.Replace("##BD##", nombreDB);
                        ConexionBD.Enumerados.CS = ConexionBD.Enumerados.CS.Replace("##USERBD##", userDB);
                        ConexionBD.Enumerados.CS = ConexionBD.Enumerados.CS.Replace("##PASSWORD##", passwordDB);


                        return true;
                    }
                    else {
                        return false;
                    }


                    
                }
                else
                {
                    return false;
                }
               
            }
            catch (Exception)
            {
                return false;
              
            }
        }

        public string ObtieneCadenaConnexion(int tipo)
        {
            try
            {
                ObtieneToken(1, 1, ref error);
                if (token.Length > 0)
                {
                    sis_cuenta cuenta = ObtieneArchivoConfiguracionCuenta();

                    resultSDK = HttpRequestTool.HttpGet(String.Format("{0}{1}{2}{3}", cuenta.URLValidacion, "/api/cliente/obtenClienteBD/", cuenta.ClienteKey, "/" + tipo.ToString())
                              , token, true, ref error);

                    Models.SDK.ClientesBd clienteBD = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.SDK.ClientesBd>(resultSDK);
                    Encript encript = new Encript();



                    if (clienteBD != null)
                    {
                        //Servidor
                        encript.data = clienteBD.ServidorBd;
                        resultSDK = HttpRequestTool.HttpPOST(
                            String.Format("{0}{1}", cuenta.URLValidacion, "/api/Encript/decript"), Newtonsoft.Json.JsonConvert.SerializeObject(encript)
                             , ref error);

                        encript = Newtonsoft.Json.JsonConvert.DeserializeObject<Encript>(resultSDK);

                        servidorDB = encript.decript;

                        ////UsuarioDB
                        encript.data = clienteBD.UsuarioBd;
                        resultSDK = HttpRequestTool.HttpPOST(
                            String.Format("{0}{1}", cuenta.URLValidacion, "/api/Encript/decript"), Newtonsoft.Json.JsonConvert.SerializeObject(encript)
                             , ref error);

                        encript = Newtonsoft.Json.JsonConvert.DeserializeObject<Encript>(resultSDK);

                        userDB = encript.decript;

                        ////Password
                        encript.data = clienteBD.Password;
                        resultSDK = HttpRequestTool.HttpPOST(
                            String.Format("{0}{1}", cuenta.URLValidacion, "/api/Encript/decript"), Newtonsoft.Json.JsonConvert.SerializeObject(encript)
                             , ref error);

                        encript = Newtonsoft.Json.JsonConvert.DeserializeObject<Encript>(resultSDK);

                        passwordDB = encript.decript;

                        ////Password
                        encript.data = clienteBD.NombreBd;
                        resultSDK = HttpRequestTool.HttpPOST(
                            String.Format("{0}{1}", cuenta.URLValidacion, "/api/Encript/decript"), Newtonsoft.Json.JsonConvert.SerializeObject(encript)
                             , ref error);

                        encript = Newtonsoft.Json.JsonConvert.DeserializeObject<Encript>(resultSDK);

                        nombreDB = encript.decript;

                        string sc = "data source=##SERVERDB##;initial catalog=##BD##;user id=##USERBD##;password=##PASSWORD##;MultipleActiveResultSets=True;App=EntityFramework";

                        sc = sc.Replace("##SERVERDB##", servidorDB);
                        sc = sc.Replace("##BD##", nombreDB);
                        sc = sc.Replace("##USERBD##", userDB);
                        sc = sc.Replace("##PASSWORD##", passwordDB);


                        return sc;
                    }
                    else
                    {
                        return "";
                    }



                }
                else
                {
                    return "";
                }

            }
            catch (Exception)
            {
                return "";

            }
        }
    }
}
