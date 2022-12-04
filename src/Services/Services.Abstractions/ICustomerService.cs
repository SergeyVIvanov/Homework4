namespace Services.Abstractions;

public interface ICustomerService
{
    Task<long> AddAsync(CustomerDto customer);
    Task<CustomerDto?> GetAsync(long id);
}
