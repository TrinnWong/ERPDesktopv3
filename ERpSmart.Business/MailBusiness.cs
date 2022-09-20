using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class MailBusiness
    {
        public string smtp { get; set; }
        public string mailFrom { get; set; }
        public int port { get; set; }
        public string passFrom { get; set; }

        public MailBusiness()
        {
            smtp = "mail.english-user.com";
            mailFrom = "notificaciones@english-user.com";
            port = 8889;
            passFrom = "Trinn2018_";
        }

        public MailBusiness(string _smtp, string _mailFrom, int _port, string _password)
        {
            smtp = _smtp;
            mailFrom = _mailFrom;
            port = _port;
            passFrom = _password;

        }


        public string Send(string message, string mailTo, string subject, string EmailToAux, List<Attachment> attachmentList)
        {

            //  Our mail

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


            if (EmailToAux.Trim() != "") { ourMessage.CC.Add(new MailAddress(EmailToAux)); }
            ourMessage.From = new MailAddress(mailFrom, "English-User.com");
            ourMessage.Body = message;
            ourMessage.IsBodyHtml = true;
            //ourMessage.IsBodyHtml = false;

            ourMessage.Subject = subject;


            using (SmtpClient Client = new SmtpClient(smtp, port))
            {


                //Client.EnableSsl = false;
                Client.Credentials = new System.Net.NetworkCredential(mailFrom, passFrom);
                Client.EnableSsl = false;

                //Client.UseDefaultCredentials = true;
//                 ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };


                try
                {
                    Client.Send(ourMessage);    // Try to send your mail.
                    return "";                // Mail sended
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    return ex.Message;               // Send error
                }
            }


        }

        public string Send(string message, string[] mailTo, string subject,  List<Attachment> attachmentList)
        {

            //  Our mail

            MailMessage ourMessage = new MailMessage();

            foreach (string item in mailTo)
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


            //if (EmailToAux.Trim() != "") { ourMessage.CC.Add(new MailAddress(EmailToAux)); }
            ourMessage.From = new MailAddress(mailFrom, mailFrom);
            ourMessage.Body = message;
            ourMessage.IsBodyHtml = true;
            //ourMessage.IsBodyHtml = false;

            ourMessage.Subject = subject;


            using (SmtpClient Client = new SmtpClient(smtp, port))
            {


                //Client.EnableSsl = false;
                Client.Credentials = new System.Net.NetworkCredential(mailFrom, passFrom);
                Client.EnableSsl = false;

                //Client.UseDefaultCredentials = true;
                //                 ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };


                try
                {
                    Client.Send(ourMessage);    // Try to send your mail.
                    return "";                // Mail sended
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    return ex.Message;               // Send error
                }
            }


        }




    }
}
