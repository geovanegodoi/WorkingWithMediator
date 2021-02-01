using System.Threading.Tasks;
using ReportsGeneratorEngine.Models;

namespace ReportsGeneratorEngine.Email
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(EmailModel emailModel);
    }

    public class EmailContext : IEmailService
    {
        public Task<bool> SendEmailAsync(EmailModel emailModel)
        {
            return Task.FromResult(result: true);
        }
    }
}
