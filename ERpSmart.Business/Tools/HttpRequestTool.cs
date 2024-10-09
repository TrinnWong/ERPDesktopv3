using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business.Tools
{
    public class HttpRequestTool
    {

        public static string HttpPOST(string url, string paramJSON, ref string error)
        {


            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset=utf-8";
            request.Accept = "application/json";
            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = paramJSON;

                    streamWriter.Write(json);
                }
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return "";
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();


                            return responseBody;
                        }
                    }
                }
            }
            catch (WebException ex)
            {


                using (var reader = new System.IO.StreamReader(ex.Response.GetResponseStream()))
                {
                    error = reader.ReadToEnd();
                }


            }

            return "";

        }

        public static string HttpPOST(string url, string paramJSON,string token, ref string error)
        {


            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset=utf-8";
            request.PreAuthenticate = true;
            request.Headers.Add("Authorization", "Bearer " + token);
            request.Accept = "application/json";
            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = paramJSON;

                    streamWriter.Write(json);
                }
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return "";
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();


                            return responseBody;
                        }
                    }
                }
            }
            catch (WebException ex)
            {


                using (var reader = new System.IO.StreamReader(ex.Response.GetResponseStream()))
                {
                    error = reader.ReadToEnd();
                }


            }

            return "";

        }


        public static string HttpGet(string url, string token, bool aplicarFormato,ref string error)
        {
            string result = "";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json;charset=utf-8";
            request.PreAuthenticate = true;
            request.Headers.Add("Authorization", "Bearer " + token);
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return "";
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            if (aplicarFormato == true)
                            {
                                responseBody = responseBody.Replace("\\", "");
                                //replace the "[ to [
                                responseBody = responseBody.Replace("\"[", "[");
                                //replace the ]" to ]
                                responseBody = responseBody.Replace("]\"", "]");
                            }
                            return responseBody;//.Replace("\\", "");
                        }
                    }
                }
            }
            catch (WebException ex)
            {
               
                error = ex.Message;

            }

            return result;
        }

        public static string HttpGet(string url, bool aplicarFormato, ref string error)
        {
            string result = "";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json;charset=utf-8";       
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return "";
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            if (aplicarFormato == true)
                            {
                                responseBody = responseBody.Replace("\\", "");
                                //replace the "[ to [
                                responseBody = responseBody.Replace("\"[", "[");
                                //replace the ]" to ]
                                responseBody = responseBody.Replace("]\"", "]");
                            }
                            return responseBody;//.Replace("\\", "");
                        }
                    }
                }
            }
            catch (WebException ex)
            {

                error = ex.Message;

            }

            return result;
        }
    }

    public class NetworkTool
    {

       

        public static bool ConexionInternetSiNo(bool showMessage=false)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.google.com");
                request.Timeout = 600; 
                request.Method = "HEAD"; 

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (WebException)
            {
                if (showMessage)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("NO HAY INTERNET. Por favor intente de nuevo");
                }
                return false;
            }
        }
    }
}
