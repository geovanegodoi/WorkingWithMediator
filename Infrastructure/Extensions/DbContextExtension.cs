using System;
using Infrastructure.Identity.Context;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WWM.Persistence.Context;

namespace Infrastructure.Extensions
{
    public static class DbContextExtension
    {
        public static void InjectDbContext(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("APPLICATION_DB"));

            services.AddDbContext<AppIdentityDbContext>(opt => opt.UseInMemoryDatabase("IDENTITY_DB"));
        }
    }
}
