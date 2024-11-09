using Domain.Common;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
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
    }
    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
    }
    public void Delete(T entity)
    {
        context.Remove(entity);
    }
    public void Delete(IEnumerable<T> entities)
    {
        context.Remove(entities);
    }

    public async Task<T?> Get(uint id, CancellationToken ct)
    {
        var entity = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, ct) as T;
        return entity;
    }

    public async Task<List<T>> GetAllAsync(CancellationToken ct)
    {
        return await context.Set<T>().ToListAsync(ct);
    }

    public IEnumerable<T> GetAll()
    {
        return context.Set<T>();
    }
}
