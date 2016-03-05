using System;

namespace BLL.Interfaces.Entities
{
    public interface IBllKeyEntity : IBllEntity
    {
        int Id { get; }
    }
}