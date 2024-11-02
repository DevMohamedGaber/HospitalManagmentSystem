using Application.RepositoryInterfaces;
using Domain.Common;
using Persistence.Contexts;

namespace Persistence.Repositories;

public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext context;
    public BaseRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public void Create(T entity)
    {
        context.Set<T>().Add(entity);
        context.SaveChanges();
    }
    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
        context.SaveChanges();
    }
    public void Delete(T entity)
    {
        context.Remove(entity);
        context.SaveChanges();
    }
    public void Delete(IEnumerable<T> entities)
    {
        context.Remove(entities);
        context.SaveChanges();
    }

    public Task<T> Get(uint id, CancellationToken cancellationToken)
    {
        var entity = context.Set<T>().FirstOrDefault(x => x.Id == id) as T;
        return entity;
    }

    public Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return context.Set<T>();
    }
}
