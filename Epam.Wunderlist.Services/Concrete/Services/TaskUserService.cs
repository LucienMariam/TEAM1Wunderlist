using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Concrete.Entities;
using BLL.Concrete.Entities;
using BLL.Interfaces.Services;
using DAL.Interfaces.Repositories;

namespace BLL
{
    public class TaskUserService : BaseService<TaskUserDal, 
                                               TaskUserEntity, 
                                               ITaskUserRepository,
                                               TaskUserMapper
                                              >, ITaskUserService
    {
        public TaskUserService(ITaskUserRepository repository, IUnitOfWork contextChanger) : base(repository, contextChanger) { }

        public IEnumerable<TaskUserEntity> GetByUserId(int userId)
        {
            return Repository.GetByUserId(userId).Select(dalEntity => EntityMapper.ToBll(dalEntity));
        }

        public IEnumerable<TaskUserEntity> GetByTaskId(int taskId)
        {
            return Repository.GetByTaskId(taskId).Select(dalEntity => EntityMapper.ToBll(dalEntity));
        }

        public TaskEntity GetTaskEntity(int taskId)
        {
            TaskDal taskDal = Repository.GetTask(taskId);
            return new TaskEntity()
            {
                Id = taskDal.Id,
                Title = taskDal.Title,
                Description = taskDal.Description
            };
        }
        public IEnumerable<TaskUserEntity> GetTaskByUser(string userName)
        {
            return Repository.GetByUsername(userName).Select(dalEntity => EntityMapper.ToBll(dalEntity));
        }
        public void ResolveTask(int id, string userName)
        {
            var taskUser = GetTaskByUser(userName).FirstOrDefault(t => t.TaskId == id);
            Edit(taskUser);
        }

        public void ReopenTask(int id, string userName)
        {
            var taskUser = GetTaskByUser(userName).FirstOrDefault(t => t.TaskId == id);
            Edit(taskUser);
        }

        public void DeleteTask(int id, string userName)
        {
            var taskUser = GetTaskByUser(userName).FirstOrDefault(t => t.TaskId == id);
            Delete(taskUser);
        }


        public void CreateTask(string taskName, string userName)
        {
            TaskUserDal td = Repository.CreateUserTask(taskName, userName);
            TaskUserEntity tue = new TaskUserEntity()
            {
                TaskId = td.TaskId,
                UserId = td.UserId,
            };
            Add(tue);
        }
    }
}
