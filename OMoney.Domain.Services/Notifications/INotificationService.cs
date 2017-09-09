using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Notifications.NotificationMessages;

namespace OMoney.Domain.Services.Notifications
{
    public interface INotificationService
    {
        void SendEmail(EmailNotificationMessage message);
        void SendConfirmationEmailForNewUser(User user);
        void SendConfirmationEmailForExistingUser(string email);
        void SendResetPasswordEmail(string email);

        EmailNotificationMessage BuildConfirmEmailForNewUserNotificationMessage(string link, string email);
        EmailNotificationMessage BuildConfirmEmailForExistingUserNotificationMessage(string link, string email);
        EmailNotificationMessage BuildResetPasswordNotificationMessage(string link, string email);
        
        string BuildEmailConfirmationLink(string userId, string code, bool passwordRecovery);
        string BuildPasswordResetLink(string userId, string code);
    }
}
