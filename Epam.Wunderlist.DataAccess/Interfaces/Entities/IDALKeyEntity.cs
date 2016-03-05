using System;

namespace DAL.Interfaces.Entities
{
    public interface IDalKeyEntity: IDalEntity
    {
        int Id { get; }
    }
}
