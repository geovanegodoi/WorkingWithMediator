using System;
using System.Threading;
using System.Threading.Tasks;
using WWM.Domain.Entities;

namespace Persistence.Repository
{
    public interface ICustomerRepository : IRepository<Customer> 
    {
        Task<Customer> GetByEmail(string email, CancellationToken cancellationToken);
    }
}
