using System.Collections.Generic;
using DAL.Interfaces.Entities;

namespace DAL.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity: IDALEntity
    {
        IEnumerable<TEntity> GetAll();

        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}