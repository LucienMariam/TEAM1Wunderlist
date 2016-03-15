using DAL.Entities;
using BLL.Entities;

namespace BLL.Mappers
{
    public interface IMapper<TDalEntity, TBllEntity>
        where TDalEntity : IDalEntity
        where TBllEntity : IBllEntity
    {
        TDalEntity ToDal(TBllEntity bllEntity);
        TBllEntity ToBll(TDalEntity dalEntity);
    }
}
