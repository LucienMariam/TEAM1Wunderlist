using System;
using DAL.Interfaces.Repositories;
using DAL.Concrete.Entities;
using DAL.Concrete.Mappers;
using ORM;
using System.Data.Entity;
using System.Linq;

namespace DAL.Concrete.Repositories
{
    public class UserRepository : KeyRepository<User, UserDal, UserMapperDal>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }
        public UserDal GetByEmail(string email)
        {
            Func<User, UserDal> f = (obj) => EntityMapper.ToDal(obj);
            return Context.Set<User>().AsNoTracking().Where(u => u.Email == email).Select(f).FirstOrDefault();
        }
    }
}
