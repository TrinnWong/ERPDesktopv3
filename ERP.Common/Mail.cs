using ConexionBD;
using ERP.Reports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common
{
    public class Mail
    {
        
        string smtp { get; set; }
        string mailFrom { get; set; }
        int port { get; set; }
        string passFrom { get; set; }

        public Mail(string _smtp,string _mailFrom, int _port,string _password)
        {
            smtp = _smtp;
            mailFrom = _mailFrom;
            port = _port;
            passFrom = _password;
            
        }

      

        public string Send(string message, string mailTo, string subject, string EmailToAux, List<Attachment> attachmentList)
        {

            //  Our mail
            EmailToAux = EmailToAux == null ? "" : EmailToAux;

            MailMessage ourMessage = new MailMessage();

            foreach (string item in mailTo.Split(';'))
            {
                if (item.Trim() != "")
                {
                    ourMessage.To.Add(new MailAddress(item));
                }
            }


            if (attachmentList != null)
            {
                if (attachmentList != null && attachmentList.Count > 0)
                {
                    for (int i = 0; i < attachmentList.Count; i++)
                    {
                        if (attachmentList[i] != null)
                            ourMessage.Attachments.Add(attachmentList[i]);
                    }
                }
            }


            if (EmailToAux.Trim() != "" && EmailToAux != null) { ourMessage.CC.Add(new MailAddress(EmailToAux)); }
            ourMessage.From = new MailAddress(mailFrom);
            ourMessage.Body = message;
            ourMessage.IsBodyHtml = true;
            //ourMessage.IsBodyHtml = false;

            ourMessage.Subject = subject;


            using (SmtpClient Client = new SmtpClient(smtp, port))
            {


                Client.EnableSsl = false;
                Client.Credentials = new System.Net.NetworkCredential(mailFrom, passFrom);
                //Client.EnableSsl = true;

                //Client.UseDefaultCredentials = true;
                // ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };


                try
                {
                    Client.Send(ourMessage);    // Try to send your mail.
                    return "";                // Mail sended
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    return ex.Message + (ex.InnerException != null ? ex.InnerException.Message : "");               // Send error
                }
            }


        }
    }
}
