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
            Mapper.Initialize(cfg => {
                DomainToModelMapping.ApplyMapping(cfg);
                ModelToDomainMapping.ApplyMapping(cfg);
                ModelToModelMapping.ApplyMapping(cfg);
            });
        }
    }
}
