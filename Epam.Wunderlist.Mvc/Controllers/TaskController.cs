using TaskService;
using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Models;
using FolderService;
using System.Collections;

namespace TaskManager.Controllers
{
    public class TaskController : ApiController
    {
        ITaskService _tasks = (ITaskService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ITaskService));
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
            var result = _tasks.GetById(id);

            return new TaskModel()
            {
                Description = result.Description,
                DueTime = result.DueTime,
                FolderId = result.FolderId,
                Id = result.Id,
                IsCompleted = result.IsCompleted,
                Title = result.Title,
                PresentationPriority = result.PresentationPriority
            };

        }

        [ActionName("GetByParentId")]
        public IEnumerable<TaskModel> GetByParentId(int id)
        {

            var task = _tasks.GetTaskList(id).Select(x =>
                                     new TaskModel()
                                     {
                                         Description = x.Description,
                                         DueTime = x.DueTime,
                                         FolderId = x.FolderId,
                                         Id = x.Id,
                                         IsCompleted = x.IsCompleted,
                                         Title = x.Title,
                                         PresentationPriority = x.PresentationPriority

                                     });
            return task.OrderByDescending(x => x.PresentationPriority);
        }

        // POST: api/TaskList
        [ActionName("DefaultAction")]
        public void Post(TaskModel value)
        {
            if (value.Title == null) { }
            else {
                _tasks.Add(new TaskEntity()
                {
                    Title = value.Title,
                    IsCompleted = value.IsCompleted,
                    FolderId = value.FolderId,
                    PresentationPriority = _tasks.GetTaskList(value.FolderId).Count()
                });
            }
            return;
        }
        [ActionName("PutTask")]
        public void PostTask(TaskModel value)
        {
            var temp = _tasks.GetById(value.Id);
            var taskForUpdate = new TaskEntity()
            {
                Id = temp.Id,
                Description = (value.Description != null ? value.Description : temp.Description),
                FolderId = (value.FolderId != 0 ? value.FolderId : temp.FolderId),
                DueTime = (value.DueTime != null ? value.DueTime : temp.DueTime),
                IsCompleted = value.IsCompleted,
                Title = (value.Title != null ? value.Title : temp.Title)
            };
            _tasks.Edit(taskForUpdate);
        }

        [ActionName("RerangeTask")]
        public void PostRerangeTask(RerangeTaskModel value)
        {
            if (value.ListId != _tasks.GetById(value.TaskId).FolderId)
            {
                _tasks.MoveTaskToFolder(value.TaskId, value.ListId);
                return;
            }
            
            _tasks.ChangeTasksPriority(value.TaskId, value.ListId, value.Index);
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
            _tasks.DeleteTask(id);
        }
    }
}
