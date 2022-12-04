using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.Abstractions;
using Services.Abstractions;

namespace Services.Implementations;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<long> AddAsync(CustomerDto customerDto)
    {
        var customer = await _customerRepository.AddAsync(_mapper.Map<Customer>(customerDto));
        await _customerRepository.SaveChangesAsync();
        return customer.Id;
    }

    public async Task<CustomerDto?> GetAsync(long id)
    {
        var customer = await _customerRepository.GetAsync(id);
        return _mapper.Map<CustomerDto>(customer);
    }
}
