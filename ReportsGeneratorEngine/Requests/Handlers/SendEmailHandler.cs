using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ReportsGeneratorEngine.Email;
using ReportsGeneratorEngine.Logger;
using ReportsGeneratorEngine.Mediator;
using ReportsGeneratorEngine.Notifications;
using ReportsGeneratorEngine.Policies.Retry;

namespace ReportsGeneratorEngine.Requests.Handlers
{
    public class SendEmailHandler : AsyncRequestHandler<SendEmailRequest>
    {
        private readonly IMediatorContext _mediator;
        private readonly IEmailService _emailService;
        private readonly ILogger _logger;
        private readonly IEmailRetryPolicy _emailPolicy;

        public SendEmailHandler(IMediatorContext mediator, IEmailService emailService, ILogger logger, IEmailRetryPolicy emailPolicy)
        {
            _mediator     = mediator;
            _emailService = emailService;
            _logger       = logger;
            _emailPolicy  = emailPolicy;
        }

        protected override async Task Handle(SendEmailRequest request, CancellationToken cancellationToken)
        {
            var notification = new EmailSentNotification().WithEmail(request.Email);

            try
            {
                var result = await _emailPolicy.RunAsync(() => _emailService.SendEmailAsync(request.Email));

                if (result.IsOk())
                {
                    notification.WithSuccess();
                }
                else
                {
                    notification.WithError(error: result.Message);
                }
                _logger.LogInfo("Sending notification <EmailSentNotification>");
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
