using System;
using System.Threading.Tasks;
using ReportsGeneratorEngine.Email;
using ReportsGeneratorEngine.External;

namespace ReportsGeneratorEngine.Policies.CircuitBreaker
{
    public interface IEmailCircuitBreaker : ICircuitBreaker<IEmailService>
    {}

    public class EmailCircuitBreaker : CircuitBreakerBase<IEmailService>, IEmailCircuitBreaker
    {}
}
