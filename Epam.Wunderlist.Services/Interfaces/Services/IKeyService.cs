using System;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface IKeyService<TEntity> : IService<TEntity>
           where TEntity : class, IBllKeyEntity
    {
        TEntity GetById(int id);
    }
}