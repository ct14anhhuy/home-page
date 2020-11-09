using System;
using System.Net;
using System.Net.Mail;

namespace Utilities
{
    /// <summary>
    /// Gmail: poscovstbot@gmail.com
    /// Password: Pvst@123
    /// </summary>
    public class EmailService
    {
        private const string SENDER_EMAIL = "poscovstbot@gmail.com";
        private const string SENDER_PASSWORD = "Pvst@123";
        private const string SMTP_HOST = "smtp.gmail.com";

        public static void SendEmail(string email, string subject, string content)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(SENDER_EMAIL);
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = content;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = SMTP_HOST;
                smtp.Credentials = new NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD);
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}