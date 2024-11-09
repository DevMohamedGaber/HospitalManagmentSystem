namespace Domain.Repositories;

public interface IUnitOfWork
{
    Task SaveChanges(CancellationToken cancellationToken);
}
