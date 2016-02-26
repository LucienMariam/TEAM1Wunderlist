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
    public class TaskUserService : BaseService<TaskUserDAL, 
                                               TaskUserEntity, 
                                               IRepository<TaskUserDAL>,
                                               TaskUserMapper
                                              >, ITaskUserService
    {
        public TaskUserService(ITaskUserRepository repository, IUnitOfWork uow) : base(repository, uow) { }

        public IEnumerable<TaskUserEntity> GetByUserId(Guid userId)
        {
            return ((ITaskUserRepository)_repository).GetByUserId(userId).Select(dalEntity => _entityMapper.ToBLL(dalEntity));
        }

        public IEnumerable<TaskUserEntity> GetByTaskId(Guid taskId)
        {
            return ((ITaskUserRepository)_repository).GetByTaskId(taskId).Select(dalEntity => _entityMapper.ToBLL(dalEntity));
        }

        public TaskEntity GetTaskEntity(Guid taskId)  // some functional should be replaced into TaskService => need to create TaskRepository
        {
            TaskDAL taskDAL = ((ITaskUserRepository)_repository).GetTask(taskId);
            return new TaskEntity()
            {
                Id = taskDAL.Id,
                Title = taskDAL.Title,
                Description = taskDAL.Description,
                DueTime = taskDAL.DueTime,
                IsCompleted = taskDAL.IsCompleted
            };
        }
        public IEnumerable<TaskUserEntity> GetTaskByUser(string userName)
        {
            return ((ITaskUserRepository)_repository).GetByUsername(userName).Select(dalEntity => _entityMapper.ToBLL(dalEntity));
        }
        public void ResolveTask(Guid id, string userName)
        {
            var taskUser = GetTaskByUser(userName).Where(t=>t.TaskId == id).FirstOrDefault();
            Edit(taskUser);
        }

        public void ReopenTask(Guid id, string userName)
        {
            var taskUser = GetTaskByUser(userName).Where(t => t.TaskId == id).FirstOrDefault();
            Edit(taskUser);
        }

        public void DeleteTask(Guid id, string userName)
        {
            var taskUser = GetTaskByUser(userName).Where(t => t.TaskId == id).FirstOrDefault();
            Delete(taskUser);
        }


        public void CreateTask(string taskName, string userName)
        {
            TaskUserDAL td = ((ITaskUserRepository)_repository).CreateUserTask(taskName, userName);
            TaskUserEntity tue = _entityMapper.ToBLL(td);
            Add(tue);
        }
    }
}
