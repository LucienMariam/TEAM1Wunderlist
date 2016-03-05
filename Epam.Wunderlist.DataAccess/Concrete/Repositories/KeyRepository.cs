using System;
using System.Linq;
using DAL.Interfaces.Repositories;
using DAL.Interfaces.Entities;
using DAL.Interfaces.Mappers;
using ORM;
using System.Data.Entity;

namespace DAL.Concrete.Repositories
{
    public class KeyRepository<TEntity, TDalEntity, TEntityMapper>: Repository<TEntity, TDalEntity, TEntityMapper>, IKeyRepository<TDalEntity>
        where TEntity: class, IOrmKeyEntity, new()
        where TDalEntity: class, IDalKeyEntity, new()
        where TEntityMapper: class, IMapperDal<TEntity, TDalEntity>, new()
    {
        public KeyRepository(DbContext context): base(context) { }
        public TDalEntity GetById(int id)
        {
            Func<TEntity, TDalEntity> f = (obj) => EntityMapper.ToDal(obj);
            return Context.Set<TEntity>().AsNoTracking().Where(x => x.Id == id).Select(f).FirstOrDefault();
        }
    }
}
