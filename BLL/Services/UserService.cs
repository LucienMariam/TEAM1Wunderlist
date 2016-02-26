﻿using System;
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
            return _entityMapper.ToBLL(((IUserRepository)_repository).GetById(Id)); 
        }

        public UserEntity GetUserEntityById(Guid userId)
        {
            UserDAL userDAL = ((IUserRepository)_repository).GetById(userId);
            return new UserEntity()
            {
               Email= userDAL.Email,
               Id= userDAL.Id,
               Login= userDAL.Login,
               Password= userDAL.Password,
               Photo= userDAL.Photo
            };
        }
        public UserEntity GetUserEntityByName(string email)
        {
            UserDAL userDAL = ((IUserRepository)_repository).GetByEmail(email);
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
