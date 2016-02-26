using System;
using DAL.Concrete.Entities;
using BLL.Interfaces.Services;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using BLL.Concrete.Entities;

namespace BLL
{
    public class UserService : BaseService<UserDAL,
                                               UserEntity,
                                               IRepository<UserDAL>,
                                               UserMapper
                                              >, IUserService
    {
        public UserService(IUserRepository repository, IUnitOfWork uow) : base(repository, uow) { }

        public UserEntity GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public UserEntity GetUserEntityById(Guid userId)
        {
            UserDAL userDAL = ((IUserRepository)_repository).GetById(userId);
            return _entityMapper.ToBLL(userDAL);
        }
        public UserEntity GetUserEntityByName(string userName)
        {
            UserDAL userDAL = ((IUserRepository)_repository).GetUserDAL(userName);
            return _entityMapper.ToBLL(userDAL);
        }
    }
}
