using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using DAL.Entities;
using BLL.Mappers;
using DataAccess.Interfaces;

namespace ServiceAbstraction
{
    public abstract class BaseService<TDto, TEntity, TRepository, TEntityMapper> : IService<TEntity>
        where TDto : class, IDalEntity
        where TEntity : class, IBllEntity
        where TRepository : IRepository<TDto>
        where TEntityMapper : IMapper<TDto, TEntity>, new()
    {
        public readonly TRepository Repository;
        protected readonly IUnitOfWork Uow;
        protected IMapper<TDto, TEntity> EntityMapper = new TEntityMapper();

        protected BaseService(TRepository repository, IUnitOfWork uow)
        { 
            Repository = repository;
            Uow = uow;
        }

        public TEntity GetById(int id)
        {
            return EntityMapper.ToBll(Repository.GetById(id));
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll().Select(dalEntity => EntityMapper.ToBll(dalEntity));
        }

        public virtual TEntity Find(Func<TEntity, bool> f)
        {
            return Repository.GetAll().Select(dalEntity => EntityMapper.ToBll(dalEntity)).FirstOrDefault(f);
        }

        public virtual void Add(TEntity entity)
        {            
            Repository.Create(EntityMapper.ToDal(entity));
            Uow.Commit();
        }

        public virtual void Edit(TEntity entity)
        {
            Repository.Update(EntityMapper.ToDal(entity));
            Uow.Commit();
        }

        public virtual void Delete(TEntity entity)
        {
            Repository.Delete(EntityMapper.ToDal(entity));
            Uow.Commit();
        } 
    }
}