using WWM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WWM.Persistence
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