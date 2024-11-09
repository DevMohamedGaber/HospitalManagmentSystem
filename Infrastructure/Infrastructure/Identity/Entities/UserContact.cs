using Domain.Entities;

namespace Infrastructure.Identity.Entities;

public class UserContact : Contact
{
    public UserIdentity User { get; set; }
}
