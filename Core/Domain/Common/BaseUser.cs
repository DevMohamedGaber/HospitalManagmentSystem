using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Common;

public class BaseUser : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string? Email { get; set; }
    public string? NationalID { get; set; }
    public Gender? Gender { get; set; }
    public string? Address { get; set; }
    public DateTime? CreatedAt { get; set; }
}
