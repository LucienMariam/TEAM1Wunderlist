using BLL.Concrete.Entities;
using BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class AccountController : ApiController
    {
        IKeyService<UserEntity> users = (IKeyService<UserEntity>)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IKeyService<UserEntity>));

        
        public IEnumerable<User> GetUsers()
        {

            return users.GetAll().Select(x => new User() { Email = x.Email, Login = x.Login, Photo = x.Photo, Password = x.Password });

        }

       
        public string GetUsers(int x)
        {

            return x.ToString();

        }

        
        public User GetUsers(string email)
        {
            var user = users.Find(x => (x.Email == email));
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return new User() { Email = "qwedqd",Login = user.Login };

        }
    }
}
