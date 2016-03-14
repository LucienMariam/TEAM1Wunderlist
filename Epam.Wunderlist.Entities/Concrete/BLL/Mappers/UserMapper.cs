using BLL.Entities;
using DAL.Entities;
using BLL.Mappers;

namespace BLL.Mappers
{
    public class UserMapper : IMapper<UserDal, UserEntity>
    {
        public UserDal ToDal(UserEntity user)
        {
            return new UserDal()
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                Password = user.Password,
                Photo=user.Photo
            };
        }

        public UserEntity ToBll(UserDal user)
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
