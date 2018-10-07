using System;
using Microsoft.EntityFrameworkCore;
using WWM.Domain.Entities;

namespace WWM.Persistence.Context
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

            SeedCities(context);
        }

        public void SeedCustomers(AppDbContext context)
        {
            var customers = new[]
            {
                new Customer { 
                    Name = "Geovane de Godoi", 
                    Email = "geovane.godoi@mail.com", 
                    Phone = "11982899531", 
                    Address = "Rua Antonio Sibinel, 165", 
                    City = "Jundiai", 
                    Country = "Brasil", 
                    PostalCode = "13212160" 
                },
                new Customer { 
                    Name = "Vanessa Pistoni Godoi", 
                    Email = "vanessa.godoi@mail.com", 
                    Phone = "11952821140", 
                    Address = "Rua Antonio Sibinel, 165", 
                    City = "Jundiai", 
                    Country = "Brasil", 
                    PostalCode = "13212160"
                }
            };
            context.Customers.AddRange(customers);

            context.SaveChanges();
        }

        public void SeedCities(AppDbContext context)
        {
            var cities = new[]
            {
                new City {
                    Name = "Jundiai"
                },
                new City {
                    Name = "Campinas"
                },
                new City {
                    Name = "Valinhos"
                },
                new City {
                    Name = "Vinhedo"
                }
            };
            context.Cities.AddRange(cities);

            context.SaveChanges();
        }
    }
}
