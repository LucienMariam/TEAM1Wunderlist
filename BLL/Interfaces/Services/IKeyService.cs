using System;

namespace BLL.Interfaces
{
    public interface IKeyService<TEntity> : IService<TEntity>
           where TEntity : class, IBLLKeyEntity
    {
        TEntity GetById(Guid Id);
    }
}