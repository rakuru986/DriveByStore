using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Models.Common;
using Services.Interfaces;

namespace Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings mailSettings;

        public MailService(IOptions<MailSettings> settings)
        {
            mailSettings = settings.Value;
        }

        public void SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            //using (MailMessage mail = new MailMessage())
            //{
            //    mail.From = new MailAddress(mailSettings.Mail);
            //    mail.To.Add(mailRequest.ToEmail);
            //    mail.Subject = mailRequest.Subject;
            //    mail.Body = mailRequest.Body;
            //    mail.IsBodyHtml = true; 
            //    using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(mailSettings.Host, mailSettings.Port))
            //    {
            //        smtp.Credentials = new NetworkCredential(mailSettings.Mail, mailSettings.Password);
            //        smtp.EnableSsl = true;
            //        smtp.Send(mail);
            //    }
            //}

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.SslOnConnect);
            smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
