using MediatR;
using ReportsGeneratorEngine.Models;

namespace ReportsGeneratorEngine.Requests
{
    public class SendEmailRequest : IRequest
    {
        public EmailModel Email { get; private set; }

        public SendEmailRequest(ReportModel reportModel)
        {
            Email = EmailFromReport(reportModel);
        }

        private EmailModel EmailFromReport(ReportModel reportModel) => new EmailModel();
    }
}
