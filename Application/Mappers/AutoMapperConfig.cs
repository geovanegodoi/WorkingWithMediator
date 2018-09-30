using System;
using AutoMapper;
using WWM.Application.Customers.Models;
using WWM.Domain.Entities;

namespace WWM.Application.Mappers
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => 
            { 
                ApplyAll(cfg); 
            });
        }

        private static void ApplyAll(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Customer, CustomerDetailModel>();
        }
    }
}
