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
    public class TaskController : ApiController
    {
        ITaskService tasks = (ITaskService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ITaskService));
        // GET: api/TaskList
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TaskList/5
        public IEnumerable<TaskModel> Get(int id)
        {
            IEnumerable<TaskModel> result = tasks.GetTaskList(id).Select(x=>new TaskModel() {Description = x.Description, DueTime = x.DueTime, FolderId = x.FolderId, Id = x.Id, IsCompleted = x.IsCompleted, Title = x.Title });

             return result;
        }

        // POST: api/TaskList
        public void Post(TaskModel value)
        {
            tasks.Add(new TaskEntity() { Title = value.Title, IsCompleted = value.IsCompleted, FolderId = value.FolderId });
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
