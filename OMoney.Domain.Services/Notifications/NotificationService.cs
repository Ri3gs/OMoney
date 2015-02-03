using System;
using System.Net.Mail;

namespace OMoney.Domain.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        public void SendEmail(NotificationMessages.EmailNotificationMessage message)
        {
            //throw new NotImplementedException();

            const string sender = "omoneydev@outlook.com";
            const string password = "df997a4e2a83";
            var client = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(sender, password);
            client.EnableSsl = true;
            client.Credentials = credentials;

            try
            {
                var mail = new MailMessage(sender.Trim(), message.Destination.Trim());
                mail.Subject = message.Subject;
                mail.Body = message.Body;
                mail.IsBodyHtml = true;
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
