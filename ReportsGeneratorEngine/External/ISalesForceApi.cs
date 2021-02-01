using System;
using System.Threading.Tasks;

namespace ReportsGeneratorEngine.External
{
    public interface ISalesforceApi
    {
        Task<bool> PostMessage(string message);
    }

    public class SalesforceApi : ISalesforceApi
    {
        public Task<bool> PostMessage(string message)
        {
            return Task.FromResult(result: true);
        }
    }
}
