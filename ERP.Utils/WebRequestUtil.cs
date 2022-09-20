using System;
using System.IO;
using System.Net;
using System.Text;

namespace ERP.Utils
{
    public class WebRequestUtil
    {

        public string Get(string url)
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

                            responseBody = responseBody.Replace("\\", "");
                            //replace the "[ to [
                            responseBody = responseBody.Replace("\"[", "[");
                            //replace the ]" to ]
                            responseBody = responseBody.Replace("]\"", "]");

                            return responseBody;//.Replace("\\", "");
                        }
                    }
                }
            }
            catch (WebException ex)
            {
               
               // error.error = ex.Message;

            }

            return result;
        }

        public string Get(string action, string urlParams, ref string error)
        {
            string result = "";

            
            string url =  action;


            try
            {
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] data = encoder.GetBytes(urlParams); // a json object, or xml, whatever...

                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                request.Expect = "application/json";

                if (data.Length > 0)
                {
                    request.GetRequestStream().Write(data, 0, data.Length);
                }



                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();

                result = responseFromServer;
            }
            catch (WebException ex)
            {
                error = ex.Message;
            }

            return result;
        }


        public string Post(string url, string paramJSON,ref string error)
        {
            string token = "";


            try
            {


                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = paramJSON;

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    token = streamReader.ReadToEnd();
                }



            }
            catch (WebException ex)
            {
               
                error = ex.Message;

            }

            return token;


        }

        public string Put(string url, string paramJSON, ref string error)
        {
            string token = "";


            try
            {


                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = paramJSON;

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    token = streamReader.ReadToEnd();
                }



            }
            catch (WebException ex)
            {

                error = ex.Message;

            }

            return token;


        }
    }
}