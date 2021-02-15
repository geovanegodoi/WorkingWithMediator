using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ReportsGeneratorEngine.Logger;
using ReportsGeneratorEngine.Mediator;
using ReportsGeneratorEngine.Requests;

namespace ReportsGeneratorEngine.Notifications.Handlers
{
    public class ReportGeneratedHandler : INotificationHandler<ReportGeneratedNotification>
    {
        private readonly IMediatorContext _mediator;
        private readonly ILogger _logger;

        public ReportGeneratedHandler(IMediatorContext mediator, ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Handle(ReportGeneratedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInfo("Report generated sucessfully!", notification.Report);

            if (notification.HasError())
            {
                await _mediator.Send(new SendMessageRabbitRequest(notification));
            }
            await _mediator.Send(new SendEmailRequest(notification.Report));
        }
    }
}
