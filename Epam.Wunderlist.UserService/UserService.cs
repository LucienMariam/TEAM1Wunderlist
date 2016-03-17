using BLL.Entities;
using DAL.Entities;
using DataAccess.Interfaces;
using BLL.Mappers;
using ServiceAbstraction;

namespace UserService
{
    public class UserService : BaseService<UserDal,
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
