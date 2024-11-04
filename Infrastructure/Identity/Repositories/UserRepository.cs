using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Identity.Entities;
using Persistence.Repositories;

namespace Persistence.Identity.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(User entity)
    {
        _context.Set<User>().Add(entity);
    }
    public void Update(User entity)
    {
        _context.Set<User>().Update(entity);
    }
    public void Delete(User entity)
    {
        _context.Remove(entity);
    }
    public void Delete(IEnumerable<User> entities)
    {
        _context.Remove(entities);
    }

    public async Task<User?> Get(uint id, CancellationToken ct)
    {
        var entity = await _context.Set<User>().FirstOrDefaultAsync(x => x.Id == id, ct);
        return entity;
    }

    public async Task<List<User>> GetAllAsync(CancellationToken ct)
    {
        return await _context.Set<User>().ToListAsync(ct);
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Set<User>();
    }
}
