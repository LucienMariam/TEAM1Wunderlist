using System;
using DataAccess.Interfaces;
using DAL.Entities;
using DAL.Mappers;
using ORM;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.MsSql.Repositories
{
    public class UserRepository : BaseRepository<User, UserDal, UserMapperDal>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }
        public UserDal GetByEmail(string email)
        {
            Func<User, UserDal> f = (obj) => EntityMapper.ToDal(obj);
            return Context.Set<User>().AsNoTracking().Where(u => u.Email == email).Select(f).FirstOrDefault();
        }
    }
}
