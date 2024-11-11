using Domain.Common;

namespace Domain.Entities;

public class Patient : BaseUser
{
    public string? Password { get; set; }
    public ICollection<PatientContact>? Contacts { get; set; }
}
