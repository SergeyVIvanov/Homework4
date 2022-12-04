using AutoMapper;
using Domain.Entities;
using Services.Abstractions;

namespace Services.Implementations.Mappings;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();
    }
}
