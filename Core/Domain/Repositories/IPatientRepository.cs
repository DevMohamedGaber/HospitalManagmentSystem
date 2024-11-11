using Domain.Entities;

namespace Domain.Repositories;

public interface IPatientRepository : IRepository<Patient>
{
    Task<Patient?> GetByNationalID(string nationalID);
    Task<Patient?> GetWithRelationships(uint Id, CancellationToken ct);
}
