using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class ProductosFotosBusiness:BusinessObject
    {
        public  string UpLoadImage()
        {
            string error = "";
            try
            {
                var config = oContext.cat_web_configuracion.FirstOrDefault();
                var lstFotos = oContext.cat_productos_imagenes.ToList();

                if (config != null)
                {


                    foreach (var itemFoto in lstFotos)
                    {
                        string pathFileFTP = config.ServidorFTP + "/" + config.FolderProductos+itemFoto.FileName;

                        FtpUploadFile(itemFoto.FileByte, pathFileFTP, config.UsuarioFTP, config.PasswordFTP);
                    }



                }
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
            

        }

        private void FtpUploadFile(byte[] file, string to_uri,
    string user_name, string password)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request =
                (FtpWebRequest)WebRequest.Create(to_uri);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // Get network credentials.
            request.Credentials =
                new NetworkCredential(user_name, password);

            // Read the file's contents into a byte array.
            byte[] bytes = file;

            // Write the bytes into the request stream.
            request.ContentLength = bytes.Length;
            using (Stream request_stream = request.GetRequestStream())
            {
                request_stream.Write(bytes, 0, bytes.Length);
                request_stream.Close();
            }
        }
    }
}
