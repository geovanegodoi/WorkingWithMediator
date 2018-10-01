using WWM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WWM.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}