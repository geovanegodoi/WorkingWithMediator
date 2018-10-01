using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WWM.Domain.Entities;
using WWM.Persistence.Context;

namespace Persistence.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : 
            base(context)
        {
        }

        public async Task<Customer> GetByEmail(string email, CancellationToken cancellationToken)
        {
            return await DbSet.AsNoTracking()
                              .FirstOrDefaultAsync(c => c.Email == email, cancellationToken);
        }
    }
}
