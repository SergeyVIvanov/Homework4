using Domain.Entities;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Abstractions;

public interface ICustomerRepository : IRepository<Customer, long>
{
}
