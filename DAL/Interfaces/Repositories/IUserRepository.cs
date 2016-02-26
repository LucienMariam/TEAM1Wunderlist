using DAL.Concrete.Entities;

namespace DAL.Interfaces.Repositories
{
    public interface IUserRepository: IKeyRepository<UserDAL>
    {
        UserDAL GetByEmail(string email);
    }
}
