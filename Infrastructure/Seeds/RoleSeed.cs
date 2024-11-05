using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Seeds;

public static class RoleSeed
{
    public static void SeedRoles(this ModelBuilder modelBuilder)
    {
        IdentityRole<uint>[] Roles = [
            new IdentityRole<uint> { Id = 1, Name= "Admin", NormalizedName = "ADMIN"},
        ];
        modelBuilder.Entity<IdentityRole<uint>>().HasData(Roles);
    }
}
