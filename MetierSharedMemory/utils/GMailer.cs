/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace fatt.utils
{
    public class GMailer
    {
        Logger logger = new Logger();
        public static string GmailUsername {  get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }
        public string ToEmail {  get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }

        static GMailer()
        {
            GmailHost = "smtp.gmail.com";
            GmailPort = 25;
            GmailSSL = true;
        }
        public void Send()
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = GmailHost;
            smtp.Port = GmailPort;
            smtp.EnableSsl = GmailSSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

            try
            {
                using (var message = new MailMessage(GmailUsername, ToEmail))
                {
                    message.Subject = Subject;
                    message.Body = Body;
                    message.IsBodyHtml = IsHtml;
                    smtp.Send(message);
                }
            }catch (Exception e)
            {
                logger.WriteDataError("GMailer-Send", e.ToString());
            }
        }
        //public static void SenMail(string address, string subject, string body)
        //{
          //  using (MailMessage message = new MailMessage())
            //{
              //  message.Subject=subject;
              //  message.Body = "<pre>" + body + "</pre";
              //  message.To.Add(address);
              //  message.Priority = MailPriority.High;
               // message.IsBodyHtml = true;
               // using (SmtpClient client = new SmtpClient())
               // {
                 //   try
                  //  {
                  //      client.Send(message);
                  //  }catch (Exception e)
                  //  {
                  //      e.GetBaseException();
                    //}
                //}
            //}
       // }
        public static void SenMail(string destinataire, string subject, string body)
        {
            try
            {
                GMailer.GmailUsername = "abdoufatahndiaye234@gmail.com";
                GMailer.GmailPassword = "gqbx zvmn oqtr ddqr";

                GMailer mailer = new GMailer();
                mailer.ToEmail = destinataire;
                mailer.Subject = subject;
                mailer.Body = body;
                mailer.IsHtml = true;
                mailer.Send();
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
*/