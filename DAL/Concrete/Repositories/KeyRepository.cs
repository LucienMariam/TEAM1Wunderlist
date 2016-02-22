using System;
using System.Linq;
using DAL.Interfaces.Repositories;
using DAL.Interfaces.Entities;
using DAL.Interfaces.Mappers;
using ORM;
using System.Data.Entity;

namespace DAL.Concrete.Repositories
{
    public class KeyRepository<TEntity, TDALEntity, TEntityMapper>: Repository<TEntity, TDALEntity, TEntityMapper>, IKeyRepository<TDALEntity>
        where TEntity: class, IORMKeyEntity, new()
        where TDALEntity: class, IDALKeyEntity, new()
        where TEntityMapper: class, IMapperDAL<TEntity, TDALEntity>, new()
    {
        public KeyRepository(DbContext context): base(context) { }
        public TDALEntity GetById(Guid id)
        {
            Func<TEntity, TDALEntity> f = (obj) => _entityMapper.ToDAL(obj);
            return _context.Set<TEntity>().AsNoTracking().Where(x => x.Id == id).Select(f).FirstOrDefault();
        }
    }
}
