using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WWM.Persistence.Context;

namespace Infrastructure.Extensions
{
    public static class DbContextExtension
    {
        public static void InjectDbContext(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("APP_DB"));
        }
    }
}
