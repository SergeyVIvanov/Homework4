using AutoMapper;
using Services.Abstractions;
using WebApi.Models;

namespace WebApi.Mappings;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<CustomerDto, CustomerModel>();
        CreateMap<CustomerModel, CustomerDto>();
    }
}