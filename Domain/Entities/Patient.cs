using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Patient : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? NationalID { get; set; }
    public Gender Gender { get; set; }
    public string? Address { get; set; }

    public List<Contact>? contacts { get; set; }
}
