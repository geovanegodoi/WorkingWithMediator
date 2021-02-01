using System.Threading;
using System.Threading.Tasks;
using MediatR;
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

        public Task Handle(EmailSentNotification notification, CancellationToken cancellationToken)
        {
            // comunicate with salesforce API
            var message = $"message to salesforce, {notification.Email.ToString()}";
            var response = _salesforceApi.PostMessage(message);

            // write result in database
            var databaseLog = $"Message : {message} | Response : {response}";
            _repository.WriteAsync(databaseLog);

            return Task.CompletedTask;
        }
    }
}
