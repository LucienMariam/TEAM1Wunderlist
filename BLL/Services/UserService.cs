using System;
using DAL.Concrete.Entities;
using BLL.Interfaces.Services;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using BLL.Concrete.Entities;

namespace BLL
{
    public class UserService : BaseService<UserDal,
        UserEntity,
        IRepository<UserDal>,
        UserMapper
        >, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository repository, IUnitOfWork uow) : base(repository, uow)
        {
            _userRepository = ((IUserRepository) Repository);
        }

        public UserEntity GetById(Guid id)
        {
            return EntityMapper.ToBll(_userRepository.GetById(id));
        }

        public UserEntity GetUserEntityById(Guid userId)
        {
            UserDal userDal = _userRepository.GetById(userId);
            return EntityMapper.ToBll(userDal);
        }

        public UserEntity GetUserEntityByEmail(string email)
        {
            UserDal userDal = _userRepository.GetByEmail(email);
            return EntityMapper.ToBll(userDal);
        }
    }
}
