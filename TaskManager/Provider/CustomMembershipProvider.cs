using System;
using System.Web.Helpers;
using BLL.Concrete.Entities;
using BLL.Interfaces.Services;

namespace TaskManager.Providers
{
    public static class CustomMembershipProvider
    {
        public static UserEntity ValidateUserAndReturn(string emailOrLogin, string password)
        {
            IKeyService<UserEntity> users = (IKeyService<UserEntity>)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IKeyService<UserEntity>));

            return users.Find(x => (x.Email == emailOrLogin || x.Login == emailOrLogin) && Crypto.VerifyHashedPassword(x.Password, password));
        }

        /// <summary>
        /// create new user
        /// </summary>
        /// <returns>null if user exist</returns>
        public static UserEntity CreateUser(string login, string email, string password)
        {
            IKeyService<UserEntity> users = (IKeyService<UserEntity>)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IKeyService<UserEntity>));
            UserEntity membershipUser = null;

            if (null == FindUser(login, email))
            {
                UserEntity user = new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Login = login,
                    Email = email,
                    Password = Crypto.HashPassword(password)
                };
                users.Add(user);
                membershipUser = user;
            }

            return membershipUser;
        }

        private static UserEntity FindUser(string login, string email)
        {
            IKeyService<UserEntity> users = (IKeyService<UserEntity>)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IKeyService<UserEntity>));
            return users.Find(x => x.Email == email || x.Login == login);
        }
    }
}