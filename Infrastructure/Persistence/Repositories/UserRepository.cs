using Microsoft.EntityFrameworkCore;
using Infrastructure.Identity.Entities;
using Persistence.Contexts;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;

namespace Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(User user)
    {
        _context.Set<UserIdentity>().Add(new (user));
    }
    public void Update(User user)
    {
        _context.Set<UserIdentity>().Update(new (user));
    }
    public void Delete(User user)
    {
        _context.Remove(new UserIdentity(user));
    }
    public void Delete(IEnumerable<User> entities)
    {
        _context.Remove(entities);
    }

    public async Task<User?> Get(uint id, CancellationToken ct)
    {
        var entity = await _context.Set<UserIdentity>().FirstOrDefaultAsync(x => x.Id == id, ct);
        return entity!.GetUser();
    }

    public async Task<List<IUserIdentity>> GetAllAsync(CancellationToken ct)
    {
        return await _context.Set<IUserIdentity>().ToListAsync<IUserIdentity>(ct);
    }

    public IEnumerable<IUserIdentity> GetAll()
    {
        return _context.Set<IUserIdentity>();
    }
}
