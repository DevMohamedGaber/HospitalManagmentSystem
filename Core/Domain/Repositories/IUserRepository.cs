using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Repositories;

public interface IUserRepository
{
    void Create(User user);
    void Update(User user);
    void Delete(User user);
    Task<User?> Get(uint id, CancellationToken cancellationToken);
    Task<List<IUserIdentity>> GetAllAsync(CancellationToken cancellationToken);
    IEnumerable<IUserIdentity> GetAll();
}
