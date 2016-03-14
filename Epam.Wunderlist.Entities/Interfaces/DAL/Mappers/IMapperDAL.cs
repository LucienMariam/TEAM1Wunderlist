using ORM;
using DAL.Entities;

namespace DAL.Mappers
{
    public interface IMapperDal<TOrmEntity, TDalEntity> where TOrmEntity : IOrmEntity
                                                  where TDalEntity : IDalEntity
    {
        TOrmEntity ToOrm(TDalEntity entity);
        TDalEntity ToDal(TOrmEntity entity);
    }
}
