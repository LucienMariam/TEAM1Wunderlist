using DAL.Entities;

namespace DataAccess.Interfaces
{
    public interface IUserRepository: IRepository<UserDal>
    {
        UserDal GetByEmail(string email);
    }
}
