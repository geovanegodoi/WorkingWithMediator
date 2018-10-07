using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WWM.Application.Mappers;

namespace Infrastructure.Extensions
{
    public static class AutoMapperExtension
    {
        public static void InjectAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper();

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            AutoMapperConfig.RegisterMappings();
        }
    }
}
