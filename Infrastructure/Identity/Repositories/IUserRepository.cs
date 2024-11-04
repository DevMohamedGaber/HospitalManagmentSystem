using Persistence.Identity.Entities;

namespace Persistence.Identity.Repositories;

public interface IUserRepository
{
    void Create(User user);
    void Update(User user);
    void Delete(User user);
    Task<User?> Get(uint id, CancellationToken cancellationToken);
    Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
    IEnumerable<User> GetAll();
}
