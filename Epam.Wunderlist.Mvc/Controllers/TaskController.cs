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
        [ActionName("DefaultAction")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TaskList/5
        [ActionName("DefaultAction")]
        public TaskModel Get(int id)
        {
            var result = tasks.GetById(id);

            return new TaskModel()
            {
                Description = result.Description,
                DueTime = result.DueTime,
                FolderId = result.FolderId,
                Id = result.Id,
                IsCompleted = result.IsCompleted,
                Title = result.Title
            };
        }

        [ActionName("GetByParentId")]
        public IEnumerable<TaskModel> GetByParentId(int id)
        {
            
            var task = tasks.GetTaskList(id).Select(x =>
                                     new TaskModel()
                                     {
                                         Description = x.Description,
                                         DueTime = x.DueTime,
                                         FolderId = x.FolderId,
                                         Id = x.Id,
                                         IsCompleted = x.IsCompleted,
                                         Title = x.Title
                                     }); 
            return task;
        }

        // POST: api/TaskList
        [ActionName("DefaultAction")]
        public void Post(TaskModel value)
        {   if(value.Title==null) { }
            else { tasks.Add(new TaskEntity() { Title = value.Title, IsCompleted = value.IsCompleted, FolderId = value.FolderId }); }
       
        }
        [ActionName("PutTask")]
        public void PostTask(TaskModel value)
        {
            var temp = tasks.GetById(value.Id);
            var taskForUpdate = new TaskEntity()
            {
                Id = temp.Id,
                Description = (value.Description != null ? value.Description : temp.Description),
                FolderId = (value.FolderId != 0 ? value.FolderId : temp.FolderId),
                DueTime = (value.DueTime != null ? value.DueTime : temp.DueTime),
                IsCompleted = value.IsCompleted,
                Title = (value.Title != null ? value.Title : temp.Title)
            };
            tasks.Edit(taskForUpdate);
        }

        [ActionName("RerangeTask")]
        public void PostRerangeTask(RerangeTaskModel value)
        {
            var forUpdate = tasks.Find(x => x.Id == value.TaskId);
            forUpdate.FolderId = value.ListId;
            tasks.Edit(forUpdate);
        }

        // PUT: api/TaskList/5
        [ActionName("DefaultAction")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaskList/5
        [ActionName("DefaultAction")]
        public void Delete(int id)
        {
        }
    }
}
