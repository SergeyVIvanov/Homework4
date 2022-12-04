using Domain.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations;

public class CustomerRepository : Repository<Customer, long>, ICustomerRepository
{
    public CustomerRepository(DatabaseContext context) : base(context)
    {
    }
}
