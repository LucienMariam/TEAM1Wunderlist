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
    public class TaskController : ApiController
    {
        IUserService users = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));
        // GET: api/Task
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Task/5
        public IEnumerable<TaskModel> Get(string id)
        {
            var x = new List<TaskModel>() { new TaskModel() { Title = "Hi" }, new TaskModel() { Title = "Hello" } };
            return x;
        }

        // POST: api/Task
        public void Post(TaskModel value)
        {
        }

        // PUT: api/Task/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Task/5
        public void Delete(string id)
        {
        }
    }
}
