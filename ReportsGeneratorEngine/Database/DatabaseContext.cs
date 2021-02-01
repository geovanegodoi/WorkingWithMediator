using System.Data;
using System.Threading.Tasks;

namespace ReportsGeneratorEngine
{
    public interface IRepository
    {
        Task<DataTable> RunQueryAsync(string query);
        Task WriteAsync(string statement);
    }

    public class Repository : IRepository
    {
        public Task<DataTable> RunQueryAsync(string query)
        {
            return Task.FromResult(result: new DataTable());
        }

        public Task WriteAsync(string statement)
        {
            return Task.CompletedTask;
        }
    }
}
