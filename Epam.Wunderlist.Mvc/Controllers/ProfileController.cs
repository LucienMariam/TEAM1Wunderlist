using BLL.Concrete.Entities;
using BLL.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class ProfileController : ApiController
    {
        IUserService users = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        // GET: api/Default
        [ActionName("DefaultAction")]
        public IEnumerable<User> Get()
        {
            return users.GetAll().Select(x => new User() { Email = x.Email, Login = x.Login, Photo = x.Photo, Password = x.Password });
        }

        // GET: api/Default/5
        [ActionName("DefaultAction")]
        public User Get(int id)
        {
            var user = users.GetById(id);
            return new User() { Email = user.Email, Login = user.Login, Photo = user.Photo, Id= user.Id };

        }

        // POST: api/Default
        [ActionName("DefaultAction")]
        public void Post(User value)
        {
            var temp = users.GetById(value.Id);
            var userForUpdate = new UserEntity()
            {
                Id = temp.Id,
                Email = (value.Email != null ? value.Email : temp.Email),
                Login = (value.Login != null ? value.Login : temp.Login),
                Password = (value.Password != null ? value.Password : temp.Password),
                Photo = (value.Photo != null ? value.Photo : temp.Photo)
            };
            users.Edit(userForUpdate);
        }

        // PUT: api/Default/5
        [ActionName("DefaultAction")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        [ActionName("DefaultAction")]
        public void Delete(int id)
        {
        }
    }
}
