using System;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repository;
using Persistence.UnitOfWork;
using WWM.Service.City;
using WWM.Service.Customer;

namespace Infrastructure.Extensions
{
    public static class DenpencyInjectionExtension
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<ICityService, CityService>();

            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICityRepository, CityRepository>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

        }
    }
}
