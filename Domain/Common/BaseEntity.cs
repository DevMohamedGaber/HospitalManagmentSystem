using Domain.Interfaces;

namespace Domain.Common;

public class BaseEntity : IBaseEntity
{
    public uint Id { get; set; }
}
