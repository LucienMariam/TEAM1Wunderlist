using System;

namespace BLL.Interfaces
{
    public interface IBLLKeyEntity : IBLLEntity
    {
        Guid Id { get; set; }
    }
}