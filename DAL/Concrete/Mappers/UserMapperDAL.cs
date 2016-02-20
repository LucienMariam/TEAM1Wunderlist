using ORM;
using DAL.Interfaces.Mappers;
using DAL.Concrete.Entities;

namespace DAL.Concrete.Mappers
{
    public class UserMapperDAL: IMapperDAL<User, UserDAL>
    {
        public User ToORM(UserDAL item)
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
        public UserDAL ToDAL(User item)
        {
            return new UserDAL()
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
