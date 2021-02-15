using System.Threading.Tasks;
using ReportsGeneratorEngine.External;

namespace ReportsGeneratorEngine.Policies.CircuitBreaker
{
    public interface ISalesforceCircuitBreaker : ICircuitBreaker<ISalesforceApi>
    {}

    public class SalesforceCircuitBreaker : CircuitBreakerBase<ISalesforceApi>, ISalesforceCircuitBreaker
    {}

}
