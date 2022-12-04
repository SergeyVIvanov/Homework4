using Domain.Entities;

namespace Services.Repositories.Abstractions;

public interface IReadRepository<T, TPrimaryKey> where T : IEntity<TPrimaryKey>
{
    T? Get(TPrimaryKey id);
    Task<T?> GetAsync(TPrimaryKey id);

    IQueryable<T> GetAll(bool noTracking = false);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken, bool noTracking = false);
}
