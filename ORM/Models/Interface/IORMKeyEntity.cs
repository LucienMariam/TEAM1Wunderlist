using System;

namespace ORM
{
    public interface IORMKeyEntity : IORMEntity
    {
        Guid Id { get; set; }
    }
}
