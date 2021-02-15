using System;
using System.Threading.Tasks;
using Polly;
using ReportsGeneratorEngine.Email;
using ReportsGeneratorEngine.Logger;
using ReportsGeneratorEngine.Models;

namespace ReportsGeneratorEngine.Policies.Retry
{
    public interface IEmailRetryPolicy
    {
        Task<EmailResponse> RunAsync(Func<Task<EmailResponse>> action);
    }
    
    public class EmailRetryPolicy : IEmailRetryPolicy
    {
        private readonly IEmailService _emailService;
        private readonly ILogger _logger;
        private readonly Policy<Task<EmailResponse>> _policy;

        public EmailRetryPolicy(IEmailService emailService, ILogger logger)
        {
            _emailService = emailService;
            _logger = logger;
            _policy = Policy
                .Handle<Exception>()
                .OrResult<Task<EmailResponse>>(response => response.Result.IsOk().Equals(false))
                .WaitAndRetry(retryCount: 3,
                              sleepDurationProvider: (attempt) => TimeSpan.FromSeconds(Math.Pow(2, attempt)),
                              onRetry: (outcome, timespan, retryCount, context) =>
                              {
                                  var error = outcome.Result.Result.Message;
                                  switch (retryCount)
                                  {
                                      case 1:
                                          _logger.LogInfo($"Falhou 1 vez, 1o retry | Erro: {error}");
                                          break;

                                      case 2:
                                          _logger.LogWarn($"Falhou 2 vezes, 2o retry | Erro: {error}");
                                          _emailService.ChangeSmtpAsync();
                                          break;

                                      case 3:
                                          _logger.LogFatal($"Falhou 3 vezes, 3o e ultimo retry | Erro: {error}");
                                          _emailService.CircuitBreaker().EnableAsync();
                                          break;
                                  }
                              });
        }

        public Task<EmailResponse> RunAsync(Func<Task<EmailResponse>> action) => _policy.Execute(action);
    }
}
