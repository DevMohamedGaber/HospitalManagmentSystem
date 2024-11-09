using Microsoft.AspNetCore.Identity;
using Domain.Interfaces;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Identity.Entities;

public class UserIdentity : IdentityUser<uint>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string? NationalID { get; set; }
    public Gender? Gender { get; set; }
    public string? Address { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastModified { get; set; }

    public ICollection<UserContact>? Contacts { get; set; }

    public UserIdentity() { }
    public UserIdentity(User user)
    {
        FirstName = user.FirstName;
        LastName = user.LastName;
        DateOfBirth = user.DateOfBirth;
        Gender = user.Gender;
        Address = user.Address;
        CreatedAt = LastModified = user.CreatedAt;
    }
    public User GetUser()
    {
        return new()
        {
            Id = Id,
            FirstName = FirstName,
            LastName = LastName,
            DateOfBirth = DateOfBirth,
            NationalID = NationalID,
            Gender = Gender,
            Address = Address
        };
    }
}
