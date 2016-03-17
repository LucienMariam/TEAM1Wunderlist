using System;

namespace DAL.Interfaces.Entities
{
    public interface IDalKeyEntity: IDalEntity
    {
        Guid Id { get; }
    }
}
