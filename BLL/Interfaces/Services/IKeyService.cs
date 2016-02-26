using System;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface IKeyService<TEntity> : IService<TEntity>
           where TEntity : class, IBLLKeyEntity
    {
        TEntity GetById(Guid id);
    }
}