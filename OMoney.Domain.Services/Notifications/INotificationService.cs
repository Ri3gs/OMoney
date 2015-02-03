using OMoney.Domain.Services.Notifications.NotificationMessages;

namespace OMoney.Domain.Services.Notifications
{
    public interface INotificationService
    {
        void SendEmail(EmailNotificationMessage message);

        EmailNotificationMessage BuildConfirmEmailForNewUserNotificationMessage(string link, string email);
        EmailNotificationMessage BuildConfirmEmailForExistingUserNotificationMessage(string link, string email);
        EmailNotificationMessage BuildResetPasswordNotificationMessage(string link, string email);
        
        string BuildEmailConfirmationLink(string userId, string code);
        string BuildPasswordResetLink(string userId, string code);
    }
}
