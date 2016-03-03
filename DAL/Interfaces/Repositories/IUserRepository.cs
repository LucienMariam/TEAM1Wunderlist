using DAL.Concrete.Entities;

namespace DAL.Interfaces.Repositories
{
    public interface IUserRepository: IKeyRepository<UserDal>
    {
        UserDal GetByEmail(string email);
    }
}
