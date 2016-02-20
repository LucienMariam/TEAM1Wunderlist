using ORM;
using DAL.Interfaces.Entities;

namespace DAL.Interfaces.Mappers
{
    public interface IMapperDAL< TORMEntity, TDALEntity> where TORMEntity : IORMEntity
                                                  where TDALEntity : IDALEntity
    {
        TORMEntity ToORM(TDALEntity entity);
        TDALEntity ToDAL(TORMEntity entity);
    }
}
