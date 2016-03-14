using System.Collections.Generic;
using DAL.Entities;

namespace DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity: IDalEntity
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();

        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}