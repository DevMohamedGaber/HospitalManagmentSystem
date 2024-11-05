using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Contact : BaseEntity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public int? Phone { get; set; }
    public ContactType? Type { get; set; }
    public RelationshipToPatient? Relationship { get; set; }
}
