using System;
using DAL.Interfaces;
using BLL.Interfaces.Services;
using BLL.Interfaces.Entities;
using DAL.Interfaces.Entities;
using DAL.Interfaces.Repositories;

namespace BLL
{
    public class KeyService<TDto, TEntity, TRepository, TEntityMapper> : BaseService<TDto, TEntity, TRepository, TEntityMapper>, IKeyService<TEntity>
        where TDto : class, IDALKeyEntity
        where TEntity : class, IBLLKeyEntity 
        where TRepository : IKeyRepository<TDto>
        where TEntityMapper : IMapper<TDto, TEntity>, new()
    {
        public KeyService(TRepository repository, IUnitOfWork uow) : base(repository, uow) { }

        public TEntity GetById(Guid key)
        {
            return _entityMapper.ToBLL(_repository.GetById(key));
        }
    }
}