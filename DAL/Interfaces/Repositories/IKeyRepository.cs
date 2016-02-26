using System;
using DAL.Interfaces.Entities;

namespace DAL.Interfaces.Repositories
{
    public interface IKeyRepository<TEntity>: IRepository<TEntity> where TEntity: IDALKeyEntity
    {
        TEntity GetById(Guid id);
    }
}