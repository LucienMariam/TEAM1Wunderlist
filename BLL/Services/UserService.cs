using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using DAL.Concrete.Entities;
using BLL.Interfaces.Services;

namespace BLL
{
    public class UserService : BaseService<UserDAL,
                                               UserEntity,
                                               IRepository<UserDAL>,
                                               UserMapper
                                              >, IUserService
    {
        public UserService(IUserRepository repository, IUnitOfWork uow) : base(repository, uow) { }

        public UserEntity GetUserEntityById(Guid userId)
        {
            UserDAL userDAL = ((IUserRepository)_repository).GetUserDAL(userId);
            return new UserEntity()
            {
               Email= userDAL.Email,
               Id= userDAL.Id,
               Login= userDAL.Login,
               Password= userDAL.Password,
               Photo= userDAL.Photo
            };
        }
        public UserEntity GetUserEntityByName(string userName)
        {
            UserDAL userDAL = ((IUserRepository)_repository).GetUserDAL(userName);
            return new UserEntity()
            {
                Email = userDAL.Email,
                Id = userDAL.Id,
                Login = userDAL.Login,
                Password = userDAL.Password,
                Photo = userDAL.Photo
            };
        }

    }
}
