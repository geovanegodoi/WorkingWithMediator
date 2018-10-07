using System;
using AutoMapper;
using WWM.Application.Customers.Commands;
using WWM.Application.Customers.Events;
using WWM.Application.Customers.Models;

namespace WWM.Application.Mappers
{
    public static class ModelToModelMapping
    {
        public static void ApplyMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CustomerDetailModel, CreateCustomerCommand>();

            cfg.CreateMap<CreateCustomerCommand, CustomerCreatedEvent>();
        }
    }
}
