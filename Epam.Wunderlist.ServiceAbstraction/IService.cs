using System;
using System.Collections.Generic;
using BLL.Entities;

namespace ServiceAbstraction
{
    public interface IService<TEntity> where TEntity : class, IBllEntity
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Find(Func<TEntity, bool> f);

        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
    }
}