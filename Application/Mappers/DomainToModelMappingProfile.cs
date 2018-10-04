using System;
using AutoMapper;
using WWM.Application.Customers.Models;
using WWM.Domain.Entities;

namespace WWM.Application.Mappers
{
    public class DomainToModelMappingProfile : Profile
    {
        public DomainToModelMappingProfile()
        {
            CreateMap<Customer, CustomerDetailModel>();
        }
    }
}
