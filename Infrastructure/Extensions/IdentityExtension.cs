using System;
using Infrastructure.Identity.Authorization;
using Infrastructure.Identity.Context;
using Infrastructure.Identity.Models;
using Infrastructure.Identity.Policy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class IdentityExtension
    {
        public static void InjectIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppIdentityDbContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policy.CanWriteCustomer, policy => policy.Requirements.Add(new ClaimRequirement("Customers", "Write")));
                options.AddPolicy(Policy.CanDeleteCustomer, policy => policy.Requirements.Add(new ClaimRequirement("Customers", "Remove")));
            });
        }
    }
}
