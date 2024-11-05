using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Identity.Entities;
using Persistence.Seeds;

namespace Persistence.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : IdentityDbContext<User, IdentityRole<uint>, uint>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.SeedRoles();
        builder.SeedSuperAdmin();

        base.OnModelCreating(builder);
    }
}
