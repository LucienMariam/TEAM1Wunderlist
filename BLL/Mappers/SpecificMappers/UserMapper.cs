using BLL.Concrete.Entities;
using DAL.Concrete.Entities;

namespace BLL
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
