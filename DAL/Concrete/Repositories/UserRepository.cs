using System;
using DAL.Interfaces.Repositories;
using DAL.Concrete.Entities;
using DAL.Concrete.Mappers;
using ORM;
using System.Data.Entity;

namespace DAL.Concrete.Repositories
{
    public class UserRepository : Repository<User, UserDAL, UserMapperDAL>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }
        public UserDAL GetByEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public UserDAL GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
