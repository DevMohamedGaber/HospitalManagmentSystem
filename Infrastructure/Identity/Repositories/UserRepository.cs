using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Identity.Entities;
using Persistence.Repositories;

namespace Persistence.Identity.Repositories;

public class UserRepository : IUserRepository
{
    protected readonly ApplicationDbContext context;

    public UserRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public void Create(User entity)
    {
        context.Set<User>().Add(entity);
    }
    public void Update(User entity)
    {
        context.Set<User>().Update(entity);
    }
    public void Delete(User entity)
    {
        context.Remove(entity);
    }
    public void Delete(IEnumerable<User> entities)
    {
        context.Remove(entities);
    }

    public async Task<User?> Get(uint id, CancellationToken ct)
    {
        var entity = await context.Set<User>().FirstOrDefaultAsync(x => x.Id == id, ct);
        return entity;
    }

    public async Task<List<User>> GetAllAsync(CancellationToken ct)
    {
        return await context.Set<User>().ToListAsync(ct);
    }

    public IEnumerable<User> GetAll()
    {
        return context.Set<User>();
    }
}
