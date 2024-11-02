using Domain.Common;
using Domain.Interfaces;

namespace Domain.Repositories;

public interface IRepository<T> where T : IBaseEntity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> Get(uint id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}
