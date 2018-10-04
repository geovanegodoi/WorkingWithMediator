using System;
using AutoMapper;
using WWM.Application.Customers.Commands;
using WWM.Application.Customers.Models;
using WWM.Domain.Entities;

namespace WWM.Application.Mappers
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg => {
                cfg.AddProfile(new DomainToModelMappingProfile());
                cfg.AddProfile(new ModelToDomainMappingProfile());
                cfg.AddProfile(new ModelToModelMappingProfile());
            });
        }
    }
}
