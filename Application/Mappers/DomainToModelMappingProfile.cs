using System;
using AutoMapper;
using WWM.Application.Customers.Models;
using WWM.Domain.Entities;

namespace WWM.Application.Mappers
{
    public static class DomainToModelMapping
    {
        public static void ApplyMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Customer, CustomerDetailModel>();
        }
    }
}
