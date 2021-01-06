using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender
{
    public class EmailSenderService
    {
        public SmtpClient SmtpClient { get; set; }

        public EmailSenderService()
        {
            SmtpClient = new SmtpClient();
            SmtpClient.Port = 587;
            SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpClient.UseDefaultCredentials = false;
            SmtpClient.Host = "smtp.gmail.com";
            SmtpClient.UseDefaultCredentials = false;
            SmtpClient.EnableSsl = true;

            SmtpClient.Credentials = new NetworkCredential("nope", "nope");

        }

        public void SendWelcomeMail(string emailTo, string fullname)
        {
            MailMessage message = new MailMessage();

            message.From = new MailAddress("wencore474@gmail.com");
            message.To.Add(new MailAddress(emailTo));
            message.Subject = "Witamy w Kamilexie";
            message.IsBodyHtml = false;
            message.Body = "Witaj w firmie " + fullname;
            SmtpClient.Send(message);

        }

        public void SendUserCredidentials(Operator oOperator, string emailTo)
        {
            MailMessage message = new MailMessage();

            message.From = new MailAddress("wencore474@gmail.com");
            message.To.Add(new MailAddress(emailTo));
            message.Subject = "Login do systemu Kamilex";
            message.IsBodyHtml = false;
            message.Body = $"Login: {oOperator.Login}, Hasło: {oOperator.Password}";
            SmtpClient.Send(message);
        }

        public void SendNotification(Event eEvent, string emailTo)
        {

        }
    }
}
