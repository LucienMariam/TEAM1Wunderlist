using DAL.Interfaces.Entities;
using BLL.Interfaces.Entities;

namespace BLL
{
    public interface IMapper<TDalEntity, TBllEntity>
        where TDalEntity : IDalEntity
        where TBllEntity : IBllEntity
    {
        TDalEntity ToDal(TBllEntity bllEntity);
        TBllEntity ToBll(TDalEntity dalEntity);
    }
}
