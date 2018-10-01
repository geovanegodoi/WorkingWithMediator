using System;
using AutoMapper;
using WWM.Application.Customers.Commands;
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

            cfg.CreateMap<CreateCustomer, Customer>()
               .AfterMap((src, dst) => dst.Id = src.Id == Guid.Empty ? Guid.NewGuid() : src.Id);
        }
    }
}
