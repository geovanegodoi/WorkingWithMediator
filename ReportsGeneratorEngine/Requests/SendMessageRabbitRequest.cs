using MediatR;
using ReportsGeneratorEngine.Notifications;
using ReportsGeneratorEngine.RabbitMQ;

namespace ReportsGeneratorEngine.Requests
{
    public class SendMessageRabbitRequest : IRequest
    {
        public NotificationBase Notification { get; set; }

        public SendMessageRabbitRequest(NotificationBase notification)
        {
            Notification = notification;
        }
    }
}
