using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public sealed class PatientRepository : BaseRepository<Patient>, IPatientRepository
{
    public PatientRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Patient?> GetByNationalID(string nationalID)
    {
        var patient = await context.Patients.FirstOrDefaultAsync(p => p.NationalID == nationalID);
        return patient;
    }

    public async Task<Patient?> GetWithRelationships(uint Id, CancellationToken ct)
    {
        var patient = await context.Patients.Include(p => p.Contacts).SingleOrDefaultAsync(p => p.Id == Id);

        return patient;
    }
}
