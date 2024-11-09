using Domain.Entities;
using Domain.Enums;

namespace Domain.Interfaces;

public interface IUserIdentity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string? NationalID { get; set; }
    public string? Email { get; set; }
    public Gender? Gender { get; set; }
    public string? Address { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastModified { get; set; }

}
