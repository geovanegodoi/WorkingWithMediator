using System;
using AutoMapper;
using WWM.Application.Customers.Commands;
using WWM.Domain.Entities;

namespace WWM.Application.Mappers
{
    public static class ModelToDomainMapping
    {
        public static void ApplyMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CreateCustomerCommand, Customer>()
                .AfterMap((src, dst) => dst.Id = src.Id == Guid.Empty ? Guid.NewGuid() : src.Id);
        }
    }
}
