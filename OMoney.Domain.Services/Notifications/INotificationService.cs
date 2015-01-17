using OMoney.Domain.Services.Notifications.NotificationMessages;

namespace OMoney.Domain.Services.Notifications
{
    public interface INotificationService
    {
        void SendEmail(EmailNotificationMessage message);
    }
}
