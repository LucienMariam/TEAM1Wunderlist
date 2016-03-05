using System;

namespace ORM
{
    public interface IOrmKeyEntity : IOrmEntity
    {
        int Id { get; }
    }
}
