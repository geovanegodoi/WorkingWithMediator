using System.Threading.Tasks;

namespace ReportsGeneratorEngine.Policies.CircuitBreaker
{
    public interface ICircuitBreaker<T>
    {
        Task EnableAsync();
        Task DisableAsync();
    }

    public abstract class CircuitBreakerBase<T> : ICircuitBreaker<T>
    {
        public Task DisableAsync()
        {
            return Task.CompletedTask;
        }

        public Task EnableAsync()
        {
            return Task.CompletedTask;
        }
    }
}
