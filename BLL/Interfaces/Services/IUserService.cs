using BLL.Concrete.Entities;

namespace BLL.Interfaces.Services
{
    public interface IUserService :IKeyService<UserEntity>
    {
        UserEntity GetUserEntityByName(string userName);
    }
}
