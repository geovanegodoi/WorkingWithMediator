using System;
using AutoMapper;
using WWM.Application.Customers.Commands;
using WWM.Application.Customers.Models;

namespace WWM.Application.Mappers
{
    public class ModelToModelMappingProfile : Profile
    {
        public ModelToModelMappingProfile()
        {
            CreateMap<CustomerDetailModel, CreateCustomerCommand>();
        }
    }
}
