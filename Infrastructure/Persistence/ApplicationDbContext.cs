using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Identity.Entities;
using Persistence.Seeds;
using Domain.Entities;

namespace Persistence.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : IdentityDbContext<UserIdentity, IdentityRole<uint>, uint>(options)
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<UserContact> UserContacts { get; set; }
    public DbSet<PatientContact> PatientContacts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // seeders
        builder.SeedRoles();
        builder.SeedSuperAdmin();

        // relationships
        builder.Entity<UserContact>().HasOne(e => e.User)
                                     .WithMany(e => e.Contacts)
                                     .HasForeignKey(e => e.OwnerId);

        builder.Entity<PatientContact>().HasOne(e => e.Patient)
                                     .WithMany(e => e.Contacts)
                                     .HasForeignKey(e => e.OwnerId);

        base.OnModelCreating(builder);
    }
}
