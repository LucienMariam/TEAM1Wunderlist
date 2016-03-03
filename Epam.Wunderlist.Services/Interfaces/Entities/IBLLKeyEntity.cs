using System;

namespace BLL.Interfaces.Entities
{
    public interface IBllKeyEntity : IBllEntity
    {
        Guid Id { get; }
    }
}