using System;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Models
{
    public class WebUIContextInitializer
    {
        public static void Initialize(WebUIContext context)
        {
            var initializer = new WebUIContextInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(WebUIContext context)
        {
            SeedCustomers(context);
        }

        public void SeedCustomers(WebUIContext context)
        {
            var customers = new[]
            {
            new Customer { Name = "Geovane de Godoi", Email = "geovane.godoi@mail.com" },
            new Customer { Name = "Vanessa Pistoni Godoi", Email = "vanessa.godoi@mail.com"}
        };
            context.Customer.AddRange(customers);

            context.SaveChanges();
        }
    }
}
