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
    public class DefaultController : ApiController
    {
        IUserService users = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        // GET: api/Default
        public IEnumerable<User> Get()
        {
            return users.GetAll().Select(x => new User() { Email = x.Email, Login = x.Login, Photo = x.Photo, Password = x.Password });
        }

        // GET: api/Default/5
        public User Get(string id)
        {
            var user = users.GetUserEntityByEmail(id);
            return new User() { Email = user.Email, Login = user.Login, Photo=user.Photo };

        }

        // POST: api/Default
        public void Post(User value)
        {
            var temp = users.GetUserEntityByEmail(value.Email);
            var userForUpdate=new UserEntity() { Id = temp.Id, Email = (value.Email != null ? value.Email : temp.Email), Login = (value.Login != null ? value.Login : temp.Login),
                Password = (value.Password != null ? value.Password : temp.Password), Photo = (value.Photo != null ? value.Photo : temp.Photo)};
            users.Edit(userForUpdate);
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
