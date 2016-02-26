using System;
using DAL.Interfaces.Repositories;
using DAL.Concrete.Entities;
using DAL.Concrete.Mappers;
using ORM;
using System.Data.Entity;
using System.Linq;

namespace DAL.Concrete.Repositories
{
    public class UserRepository : Repository<User, UserDAL, UserMapperDAL>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }
        public UserDAL GetByEmail(string email)
        {
            Func<User, UserDAL> f = (obj) => _entityMapper.ToDAL(obj);
            return _context.Set<User>().AsNoTracking().Where(u => u.Email == email).Select(f).FirstOrDefault();
        }

        public UserDAL GetById(Guid id)
        {
            Func<User, UserDAL> f = (obj) => _entityMapper.ToDAL(obj);
            return _context.Set<User>().AsNoTracking().Where(u => u.Id == id).Select(f).FirstOrDefault();
        }
    }
}
