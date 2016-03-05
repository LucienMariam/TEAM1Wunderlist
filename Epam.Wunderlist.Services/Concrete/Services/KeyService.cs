using System;
using DAL.Interfaces;
using BLL.Interfaces.Services;
using BLL.Interfaces.Entities;
using DAL.Interfaces.Entities;
using DAL.Interfaces.Repositories;

namespace BLL
{
    public class KeyService<TDto, TEntity, TRepository, TEntityMapper> : BaseService<TDto, TEntity, TRepository, TEntityMapper>, IKeyService<TEntity>
        where TDto : class, IDalKeyEntity
        where TEntity : class, IBllKeyEntity 
        where TRepository : IKeyRepository<TDto>
        where TEntityMapper : IMapper<TDto, TEntity>, new()
    {
        public KeyService(TRepository repository, IUnitOfWork uow) : base(repository, uow) { }

        public TEntity GetById(int key)
        {
            return EntityMapper.ToBll(Repository.GetById(key));
        }
    }
}