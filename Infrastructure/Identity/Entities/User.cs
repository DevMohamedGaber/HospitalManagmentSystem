using Microsoft.AspNetCore.Identity;

namespace Persistence.Identity.Entities;

public class User : IdentityUser<uint>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
