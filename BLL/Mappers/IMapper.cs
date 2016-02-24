using DAL.Interfaces.Entities;
using BLL.Interfaces.Entities;

namespace BLL
{
    public interface IMapper<TDALEntity, TBLLEntity>
        where TDALEntity : IDALEntity
        where TBLLEntity : IBLLEntity
    {
        TDALEntity ToDAL(TBLLEntity bllEntity);
        TBLLEntity ToBLL(TDALEntity dalEntity);
    }
}
