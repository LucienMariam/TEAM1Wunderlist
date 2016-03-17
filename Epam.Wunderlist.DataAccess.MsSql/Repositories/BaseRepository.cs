using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using DataAccess.Interfaces;
using DAL.Entities;
using DAL.Mappers;
using ORM;

namespace DataAccess.MsSql
{
    public abstract class BaseRepository<TEntity, TDalEntity, TEntityMapper>: IRepository<TDalEntity>
        where TEntity : class, IOrmEntity, new()
        where TDalEntity : class, IDalEntity, new()
        where TEntityMapper : IMapperDal<TEntity, TDalEntity>, new()
    {
        protected readonly DbContext Context;
        protected IMapperDal<TEntity, TDalEntity> EntityMapper = new TEntityMapper();

        protected BaseRepository(DbContext context)
        {
            Context = context;
        }

        public virtual TDalEntity GetById(int id)
        {
            Func<TEntity, TDalEntity> f = (obj) => EntityMapper.ToDal(obj);
            return Context.Set<TEntity>().AsNoTracking().Where(x => x.Id == id).Select(f).FirstOrDefault();
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
