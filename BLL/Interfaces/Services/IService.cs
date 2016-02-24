using System;
using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : class, IBLLEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity Find(Func<TEntity, bool> f);

        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
    }
}