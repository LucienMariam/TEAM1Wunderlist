using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using DAL.Interfaces.Repositories;
using DAL.Interfaces.Entities;
using DAL.Interfaces.Mappers;
using ORM;

namespace DAL.Concrete.Repositories
{
    public abstract class Repository<TEntity, TDalEntity, TEntityMapper>: IRepository<TDalEntity>
        where TEntity : class, IOrmEntity, new()
        where TDalEntity : class, IDalEntity, new()
        where TEntityMapper : IMapperDal<TEntity, TDalEntity>, new()
    {
        protected readonly DbContext Context;
        protected IMapperDal<TEntity, TDalEntity> EntityMapper = new TEntityMapper();

        public Repository(DbContext context)
        {
            Context = context;
        }

        public virtual IEnumerable<TDalEntity> GetAll()
        {
            Func<TEntity, TDalEntity> f = (obj) => EntityMapper.ToDal(obj);
            return Context.Set<TEntity>().AsNoTracking().Select(f);
        }

        public virtual void Create(TDalEntity entity)
        {
            TEntity modelEntity = EntityMapper.ToOrm(entity);
            DbEntityEntry<TEntity> dbEntity = Context.Entry<TEntity>(modelEntity);
            dbEntity.State = EntityState.Added;
        }

        public virtual void Delete(TDalEntity entity)
        {
            TEntity modelEntity = EntityMapper.ToOrm(entity);
            DbEntityEntry<TEntity> dbEntity = Context.Entry<TEntity>(modelEntity);
            dbEntity.State = EntityState.Deleted;
        }

        public virtual void Update(TDalEntity entity)
        {
            TEntity modelEntity = EntityMapper.ToOrm(entity);
            DbEntityEntry<TEntity> dbEntity = Context.Entry<TEntity>(modelEntity);
            dbEntity.State = EntityState.Modified;
        }
    }
}
