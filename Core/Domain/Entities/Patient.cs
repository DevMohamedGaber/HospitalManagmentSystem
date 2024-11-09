using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Patient : BaseUser
{
    public string? Password { get; set; }
    public ICollection<PatientContact>? Contacts { get; set; }
}
