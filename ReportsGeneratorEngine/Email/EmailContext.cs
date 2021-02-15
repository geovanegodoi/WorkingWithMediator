using System.Threading.Tasks;
using ReportsGeneratorEngine.Exceptions;
using ReportsGeneratorEngine.Models;
using ReportsGeneratorEngine.Policies.CircuitBreaker;

namespace ReportsGeneratorEngine.Email
{
    public interface IEmailService
    {
        Task ChangeSmtpAsync();
        IEmailCircuitBreaker CircuitBreaker();
        Task<EmailResponse> SendEmailAsync(EmailModel emailModel);
    }

    public class EmailContext : IEmailService
    {
        private static int retry = 0;
        private IEmailCircuitBreaker _circuitBreaker;

        public EmailContext(IEmailCircuitBreaker circuitBreaker)
        {
            _circuitBreaker = circuitBreaker;
        }

        public Task ChangeSmtpAsync() => Task.CompletedTask;

        public IEmailCircuitBreaker CircuitBreaker() => _circuitBreaker;

        public Task<EmailResponse> SendEmailAsync(EmailModel emailModel)
        {
            var statusCode = FailureRules.ThrowFail() ? FailureRules.FAIL_CODE : FailureRules.SUCESS_CODE;

            return Task.FromResult(result: new EmailResponse(statusCode));
        }
    }
}
