using DAL.Concrete.Entities;
using BLL.Interfaces.Services;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using BLL.Concrete.Entities;

namespace BLL
{
    public class UserService : KeyService<UserDal,
        UserEntity,
        IUserRepository,
        UserMapper
        >, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository repository, IUnitOfWork contextChanger) : base(repository, contextChanger)
        {
            _userRepository = Repository;
        }

        public UserEntity GetUserEntityByEmail(string email)
        {
            UserDal userDal = _userRepository.GetByEmail(email);
            return EntityMapper.ToBll(userDal);
        }
    }
}
