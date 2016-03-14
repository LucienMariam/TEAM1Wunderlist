using System.Web.Helpers;
using BLL.Entities;
using ServiceAbstraction;
using UserService;

namespace TaskManager.Providers
{
    public static class CustomMembershipProvider
    {
        public static UserEntity ValidateUserAndReturn(string emailOrLogin, string password)
        {
            var users = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

            return users.Find(x => (x.Email == emailOrLogin || x.Login == emailOrLogin) && Crypto.VerifyHashedPassword(x.Password, password));
        }

        /// <summary>
        /// create new user
        /// </summary>
        /// <returns>null if user exist</returns>
        public static UserEntity CreateUser(string login, string email, string password, string Photo)
        {

            var users = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));
            UserEntity membershipUser = null;

            if (null == FindUser(login, email))
            {
                UserEntity user = new UserEntity()
                {
                    Login = login,
                    Email = email,
                    Password = Crypto.HashPassword(password),
                    Photo = Photo

                };
                users.Add(user);
                membershipUser = user;
            }

            return membershipUser;
        }

        private static UserEntity FindUser(string login, string email)
        {
            var users = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));
            return users.Find(x => x.Email == email || x.Login == login);
        }
    }
}