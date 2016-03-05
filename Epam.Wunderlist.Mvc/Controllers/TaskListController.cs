using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskListController : ApiController
    {
        // GET: api/TaskList
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TaskList/5
        public IEnumerable<TaskModel> Get(int id)
        {
            IEnumerable<TaskModel> result;
            if (id>1)
            {
                result = new List<TaskModel>() { new TaskModel() { Title = "Hi", Id = 1 }, new TaskModel() { Title = "Hello", Id = 2 } };
            }
            else
            {
                result = new List<TaskModel>() { new TaskModel() { Title = "Hi", Id = 1 } };
            }
            
            return result;
        }

        // POST: api/TaskList
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TaskList/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaskList/5
        public void Delete(int id)
        {
        }
    }
}
