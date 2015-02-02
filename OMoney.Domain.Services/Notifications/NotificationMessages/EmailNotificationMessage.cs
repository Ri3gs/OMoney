namespace OMoney.Domain.Services.Notifications.NotificationMessages
{
    public class EmailNotificationMessage
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Destination { get; set; }
    }
}
