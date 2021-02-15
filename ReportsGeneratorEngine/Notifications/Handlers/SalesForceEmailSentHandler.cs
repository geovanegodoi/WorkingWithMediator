using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Polly;
using ReportsGeneratorEngine.External;
using ReportsGeneratorEngine.Logger;

namespace ReportsGeneratorEngine.Notifications.Handlers
{
    public class SalesForceEmailSentHandler : INotificationHandler<EmailSentNotification>
    {
        private readonly ISalesforceApi _salesforceApi;
        private readonly IRepository    _repository;

        public SalesForceEmailSentHandler(ISalesforceApi salesforceApi, IRepository databaseContext)
        {
            _salesforceApi = salesforceApi;
            _repository = databaseContext;
        }

        public async Task Handle(EmailSentNotification notification, CancellationToken cancellationToken)
        {
            // comunicate with salesforce API
            var message = $"message to salesforce, {notification.Email}";

            /*
            var response = await Policy
                .HandleResult<Task<bool>>(r => r.Result.Equals(false))
                .WaitAndRetry(3, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)))
                .Execute(() => _salesforceApi.PostMessageAsync(message));
            */
            var response = await _salesforceApi.PostMessageAsync(message);

            // write result in database
            var databaseLog = $"Message : {message} | Response : {response}";
            await _repository.WriteAsync(databaseLog);
        }
    }
}
