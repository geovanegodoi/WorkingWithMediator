using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ReportsGeneratorEngine.Logger;
using ReportsGeneratorEngine.Mediator;
using ReportsGeneratorEngine.Requests;

namespace ReportsGeneratorEngine.Notifications.Handlers
{
    public class EmailSentHandler : INotificationHandler<EmailSentNotification>
    {
        private readonly IMediatorContext _mediator;
        private readonly ILogger _logger;

        public EmailSentHandler(IMediatorContext mediator, ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Handle(EmailSentNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInfo($"Email sent sucessfully!", notification.Email);

            if (notification.HasError())
            {
                await _mediator.Send(new SendMessageRabbitRequest(notification));
            }
        }
    }
}
