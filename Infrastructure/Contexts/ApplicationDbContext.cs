using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Identity.Entities;

namespace Persistence.Contexts;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<uint>, uint>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}
