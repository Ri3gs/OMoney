using System;
using System.Net;
using System.Net.Mail;
using System.Web;
using OMoney.Domain.Services.Notifications.NotificationMessages;
using OMoney.Domain.Services.Validation;

namespace OMoney.Domain.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        public void SendEmail(EmailNotificationMessage message)
        {
            //throw new NotImplementedException();

            const string sender = "omoneydev@outlook.com";
            const string password = "df997a4e2a831";
            var client = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            NetworkCredential credentials = new NetworkCredential(sender, password);
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

        public EmailNotificationMessage BuildConfirmEmailForNewUserNotificationMessage(string link, string email)
        {
            return new EmailNotificationMessage
            {
                Subject = "Welcome to OMoney",
                Body = string.Format("Please follow this link: <a href='{0}'>link</a>", link),
                Destination = email
            };
        }

        public EmailNotificationMessage BuildConfirmEmailForExistingUserNotificationMessage(string link, string email)
        {
            return new EmailNotificationMessage
            {
                Subject = "Email confirmation from OMoney",
                Body = string.Format("Please follow this link to confirm your email: <a href='{0}'>link</a>", link),
                Destination = email
            };
        }

        public EmailNotificationMessage BuildResetPasswordNotificationMessage(string link, string email)
        {
            return new EmailNotificationMessage
            {
                Subject = "Password reset from OMoney", 
                Body = string.Format("Please follow this link to reset your password: <a href='{0}'>link</a>", link),
                Destination = email
            };
        }

        public string BuildEmailConfirmationLink(string userId, string code)
        {
            return string.Format("http://localhost:4598/#/emailconfirmation?userId={0}&code={1}", HttpUtility.UrlEncode(userId), HttpUtility.UrlEncode(code));
        }

        public string BuildPasswordResetLink(string userId, string code)
        {
            return string.Format("http://localhost:4598/#/resetpassword?userId={0}&code={1}", HttpUtility.UrlEncode(userId), HttpUtility.UrlEncode(code));
        }

    }
}
