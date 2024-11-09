using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Contact : BaseEntity
{
    public uint? OwnerId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public int? Phone { get; set; }
    public ContactType? Type { get; set; }
    public RelationshipToPatient? Relationship { get; set; }

    public Contact GetContact(Contact contact)
    {
        return new()
        {
            Id = contact.Id,
            OwnerId = contact.OwnerId,
            Name = contact.Name,
            Email = contact.Email,
            Phone = contact.Phone,
            Type = contact.Type,
            Relationship = contact.Relationship
        };
    }
}
