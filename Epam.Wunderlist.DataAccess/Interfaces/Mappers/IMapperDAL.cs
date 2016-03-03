using ORM;
using DAL.Interfaces.Entities;

namespace DAL.Interfaces.Mappers
{
    public interface IMapperDal< TOrmEntity, TDalEntity> where TOrmEntity : IOrmEntity
                                                  where TDalEntity : IDalEntity
    {
        TOrmEntity ToOrm(TDalEntity entity);
        TDalEntity ToDal(TOrmEntity entity);
    }
}
