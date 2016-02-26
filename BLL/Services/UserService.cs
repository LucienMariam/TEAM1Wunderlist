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
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository repository, IUnitOfWork uow) : base(repository, uow)
        {
            _userRepository = ((IUserRepository) _repository);
        }

        public UserEntity GetById(Guid id)
        {
            return _entityMapper.ToBLL(_userRepository.GetById(id));
        }

        public UserEntity GetUserEntityById(Guid userId)
        {
            UserDAL userDAL = _userRepository.GetById(userId);
            return _entityMapper.ToBLL(userDAL);
        }

        public UserEntity GetUserEntityByEmail(string email)
        {
            UserDAL userDAL = _userRepository.GetByEmail(email);
            return _entityMapper.ToBLL(userDAL);
        }
    }
}
