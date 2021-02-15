using System;
using System.Threading.Tasks;
using Polly;
using ReportsGeneratorEngine.Email;
using ReportsGeneratorEngine.External;
using ReportsGeneratorEngine.Logger;
using ReportsGeneratorEngine.Models;

namespace ReportsGeneratorEngine.Policies.Retry
{
    public interface ISalesforceApiRetryPolicy
    {
        Task<SalesforceResponse> RunAsync(Func<Task<SalesforceResponse>> action);
    }
    
    public class SalesforceApiRetryPolicy : ISalesforceApiRetryPolicy
    {
        private readonly ISalesforceApi _salesforceApi;
        private readonly ILogger _logger;
        private readonly Policy<Task<SalesforceResponse>> _policy;

        public SalesforceApiRetryPolicy(ISalesforceApi salesforceApi, ILogger logger)
        {
            _salesforceApi = salesforceApi;
            _logger = logger;
            _policy = Policy
                .Handle<Exception>()
                .OrResult<Task<SalesforceResponse>>(response => response.Result.IsOk().Equals(false))
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
                                          _salesforceApi.ChangeApiGatewayAsync();
                                          break;

                                      case 3:
                                          _logger.LogFatal($"Falhou 3 vezes, 3o e ultimo retry | Erro: {error}");
                                          _salesforceApi.CircuitBreaker().EnableAsync();
                                          break;
                                  }
                              });
        }

        public Task<SalesforceResponse> RunAsync(Func<Task<SalesforceResponse>> action) => _policy.Execute(action);
    }
}
