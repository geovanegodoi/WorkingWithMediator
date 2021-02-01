using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ReportsGeneratorEngine.Email;
using ReportsGeneratorEngine.Logger;
using ReportsGeneratorEngine.Mediator;
using ReportsGeneratorEngine.Notifications;
using ReportsGeneratorEngine.Requests;

namespace ReportsGeneratorEngine.Requests.Handlers
{
    public class SendEmailHandler : AsyncRequestHandler<SendEmailRequest>
    {
        private readonly IMediatorContext _mediator;
        private readonly IEmailService _emailService;
        private readonly ILogger _logger;

        public SendEmailHandler(IMediatorContext mediator, IEmailService emailService, ILogger logger)
        {
            _mediator     = mediator;
            _emailService = emailService;
            _logger       = logger;
        }

        protected override async Task Handle(SendEmailRequest request, CancellationToken cancellationToken)
        {
            var notification = new EmailSentNotification();

            try
            {
                notification.WithEmail(request.Email).WithError();

                var result = await _emailService.SendEmailAsync(request.Email);

                if (result)
                {
                    notification.WithSuccess();
                }
                _logger.Log("Sending notification <EmailSentNotification>");
            }
            catch (Exception ex)
            {
                notification.WithExcetion(ex);
            }
            finally
            {
                await _mediator.Publish(notification);
            }            
        }
    }
}
