using System;

namespace ORM
{
    public interface IOrmKeyEntity : IOrmEntity
    {
        Guid Id { get; }
    }
}
