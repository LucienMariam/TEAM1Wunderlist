using System;

namespace BLL.Interfaces.Entities
{
    public interface IBLLKeyEntity : IBLLEntity
    {
        Guid Id { get; set; }
    }
}