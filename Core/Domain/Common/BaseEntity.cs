using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Common;

public class BaseEntity : IBaseEntity
{
    [Key]
    public uint Id { get; set; }
}
