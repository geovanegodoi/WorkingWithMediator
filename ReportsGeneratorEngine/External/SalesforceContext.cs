using System;
using System.Net;
using System.Threading.Tasks;
using ReportsGeneratorEngine.Exceptions;
using ReportsGeneratorEngine.Models;
using ReportsGeneratorEngine.Policies;
using ReportsGeneratorEngine.Policies.CircuitBreaker;

namespace ReportsGeneratorEngine.External
{
    public interface ISalesforceApi
    {
        Task ChangeApiGatewayAsync();
        ISalesforceCircuitBreaker CircuitBreaker();
        Task<SalesforceResponse> PostMessageAsync(string message);
    }

    public class SalesforceApi : ISalesforceApi
    {
        private static int retry = 0;
        private readonly ISalesforceCircuitBreaker _circuitBreaker;

        public SalesforceApi(ISalesforceCircuitBreaker circuitBreaker)
        {
            _circuitBreaker = circuitBreaker;
        }

        public Task ChangeApiGatewayAsync() => Task.CompletedTask;

        public ISalesforceCircuitBreaker CircuitBreaker() => _circuitBreaker;

        public Task<SalesforceResponse> PostMessageAsync(string message)
        {
            var statusCode = FailureRules.ThrowFail() ? HttpStatusCode.InternalServerError : HttpStatusCode.OK;

            return Task.FromResult(result: new SalesforceResponse(statusCode));
        }
    }
}
