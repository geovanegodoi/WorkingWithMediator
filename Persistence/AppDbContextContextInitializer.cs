using System;
using Microsoft.EntityFrameworkCore;
using WWM.Domain.Entities;

namespace WWM.Persistence
{
    public class AppDbContextInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            var initializer = new AppDbContextInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(AppDbContext context)
        {
            SeedCustomers(context);
        }

        public void SeedCustomers(AppDbContext context)
        {
            var customers = new[]
            {
            new Customer { Name = "Geovane de Godoi", Email = "geovane.godoi@mail.com" },
            new Customer { Name = "Vanessa Pistoni Godoi", Email = "vanessa.godoi@mail.com"}
        };
            context.Customers.AddRange(customers);

            context.SaveChanges();
        }
    }
}
