using Email.DTOs;
using Email.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Email.Implementation
{
    public class EmailSender : IEmailSender
    {
        private readonly string _fromEmail;
        private readonly string _emailPassword;

        public EmailSender(string fromEmail, string emailPassword)
        {
            _fromEmail = fromEmail;
            _emailPassword = emailPassword;
        }
        public void Send(EmailRegister email)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_fromEmail, _emailPassword)
            };

            var message = new MailMessage(_fromEmail, email.SendTo);
            message.Subject = email.Subject;
            message.Body = email.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
