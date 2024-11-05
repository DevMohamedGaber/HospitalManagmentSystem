using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Identity.Entities;

namespace Persistence.Seeds;

public static class AdminSeed
{
    public static void SeedSuperAdmin(this ModelBuilder modelBuilder)
    {
        User admin = new()
        {
            Id = 1,
            FirstName = "Super Admin",
            UserName = "SuperAdmin",
            NormalizedUserName = "SUPERADMIN",
            Email = "admin@hms.com",
            NormalizedEmail = "ADMIN@HMS.COM",
            SecurityStamp = Guid.NewGuid().ToString("D")
        };

        var hasher = new PasswordHasher<User>();
        admin.PasswordHash = hasher.HashPassword(admin, "123456789");

        modelBuilder.Entity<User>().HasData(admin);

        modelBuilder.Entity<IdentityUserRole<uint>>().HasData(new IdentityUserRole<uint>
        {
            RoleId = 1,
            UserId = 1
        });

        modelBuilder.Entity<IdentityUserClaim<uint>>().HasData(new IdentityUserClaim<uint>
        {
            Id = 1,
            UserId = 1,
            ClaimType = "Email",
            ClaimValue = admin.Email
        });
    }
}
