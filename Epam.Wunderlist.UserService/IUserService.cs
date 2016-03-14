using BLL.Entities;
using ServiceAbstraction;

namespace UserService
{
    public interface IUserService :IService<UserEntity>
    {
        UserEntity GetUserEntityByEmail(string userEmail);
    }
}
