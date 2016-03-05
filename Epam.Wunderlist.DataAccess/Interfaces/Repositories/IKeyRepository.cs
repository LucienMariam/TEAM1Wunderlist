using System;
using DAL.Interfaces.Entities;

namespace DAL.Interfaces.Repositories
{
    public interface IKeyRepository<TEntity>: IRepository<TEntity> where TEntity: IDalKeyEntity
    {
        TEntity GetById(int id);
    }
}