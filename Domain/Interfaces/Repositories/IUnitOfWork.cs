namespace Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    Task SaveChanges(CancellationToken cancellationToken);
}
