using ORM;
using DAL.Interfaces.Mappers;
using DAL.Concrete.Entities;

namespace DAL.Concrete.Mappers
{
    public class UserMapperDal: IMapperDal<User, UserDal>
    {
        public User ToOrm(UserDal item)
        {
            return new User()
            {
                Id = item.Id,
                Email = item.Email,
                Login = item.Login,
                Password = item.Password,
                Photo = item.Photo
            };
        }
        public UserDal ToDal(User item)
        {
            return new UserDal()
            {
                Id = item.Id,
                Email = item.Email,
                Login = item.Login,
                Password = item.Password,
                Photo = item.Photo
            };
        }
    }
}
