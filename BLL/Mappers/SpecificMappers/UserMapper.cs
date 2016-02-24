using BLL.Concrete.Entities;
using DAL.Concrete.Entities;

namespace BLL
{
    public class UserMapper : IMapper<UserDAL, UserEntity>
    {
        public UserDAL ToDAL(UserEntity user)
        {
            return new UserDAL()
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                Password = user.Password,
                Photo=user.Photo
            };
        }

        public UserEntity ToBLL(UserDAL user)
        {
            return (null == user) ? null :
                new UserEntity()
                {
                    Id = user.Id,
                    Login = user.Login,
                    Email = user.Email,
                    Password = user.Password,
                    Photo=user.Photo
                };
        }
    }
}
