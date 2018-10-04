using System;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repository;
using Persistence.UnitOfWork;

namespace Infrastructure.Extensions
{
    public static class DenpencyInjectionExtension
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
