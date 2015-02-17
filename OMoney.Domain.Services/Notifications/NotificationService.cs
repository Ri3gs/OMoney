using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Transactions;
using System.Web;
using OMoney.Data.Users;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Notifications.NotificationMessages;
using OMoney.Domain.Services.Validation;
using OMoney.Domain.Services.Validation.Users;

namespace OMoney.Domain.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly IUserRepository _userRepository;

        public NotificationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

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
                throw new DomainEntityValidationException {ValidationErrors = new List<string>{"User was created but there is some email troubles."}};
            }
        }

        public void SendConfirmationEmailForNewUser(User user)
        {
            var id = _userRepository.GetId(user.Email);
            var code = _userRepository.GenerateEmailToken(id);
            var link = BuildEmailConfirmationLink(id, code, false);
            var message = BuildConfirmEmailForNewUserNotificationMessage(link, user.Email);

            SendEmail(message);
        }

        public void SendConfirmationEmailForExistingUser(string email)
        {
            using (var transaction = new TransactionScope())
            {
                var validator = new SendResetLinkValidator(_userRepository);
                var validationErrors = validator.Validate(email).ToList();
                if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };

                var id = _userRepository.GetId(email);
                var code = _userRepository.GenerateEmailToken(id);
                var link = BuildEmailConfirmationLink(id, code, true);
                var message = BuildConfirmEmailForExistingUserNotificationMessage(link, email);

                SendEmail(message);

                transaction.Complete();
            }
        }

        public void SendResetPasswordEmail(string email)
        {
            using (var transaction = new TransactionScope())
            {
                var validator = new SendResetLinkValidator(_userRepository);
                var validationErrors = validator.Validate(email).ToList();
                if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };

                var id = _userRepository.GetId(email);
                var code = _userRepository.GeneratePwdToken(id);
                var link = BuildPasswordResetLink(id, code);
                var message = BuildResetPasswordNotificationMessage(link, email);

                SendEmail(message);

                transaction.Complete();
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

        public string BuildEmailConfirmationLink(string userId, string code, bool passwordRecovery)
        {
            return string.Format("http://localhost:4598/#/emailconfirmation?userId={0}&code={1}&passwordrecovery={2}", HttpUtility.UrlEncode(userId), HttpUtility.UrlEncode(code), passwordRecovery);
        }

        public string BuildPasswordResetLink(string userId, string code)
        {
            return string.Format("http://localhost:4598/#/resetpassword?userId={0}&code={1}", HttpUtility.UrlEncode(userId), HttpUtility.UrlEncode(code));
        }
    }
}
