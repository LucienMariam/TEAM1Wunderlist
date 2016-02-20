using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using DAL.Concrete.Entities;

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

        public TaskEntity GetTaskEntity(Guid taskId)
        {
            TaskDAL taskDAL = ((ITaskUserRepository)_repository).GetTaskDAL(taskId);
            return new TaskEntity()
            {
                Id = taskDAL.Id,
                Title = taskDAL.Title,
                Description = taskDAL.Description
            };
        }
        public IEnumerable<TaskUserEntity> GetTaskByUser(string userName)
        {
            return ((ITaskUserRepository)_repository).GetTaskByUser(userName).Select(dalEntity => _entityMapper.ToBLL(dalEntity));
        }
        public void ResolveTask(Guid id, string userName)
        {
            var taskUser = GetTaskByUser(userName).Where(t=>t.TaskId == id).FirstOrDefault();
            taskUser.Progress = 100;
            Edit(taskUser);
        }

        public void ReopenTask(Guid id, string userName)
        {
            var taskUser = GetTaskByUser(userName).Where(t => t.TaskId == id).FirstOrDefault();
            taskUser.Progress = 0;
            Edit(taskUser);
        }

        public void DeleteTask(Guid id, string userName)
        {
            var taskUser = GetTaskByUser(userName).Where(t => t.TaskId == id).FirstOrDefault();
            Delete(taskUser);
        }


        public void CreateTask(Guid taskID, string userName)
        {
            TaskUserDAL td = ((ITaskUserRepository)_repository).CreateUserTask(taskID, userName);
            TaskUserEntity tue = new TaskUserEntity()
            {
                TaskId = td.TaskId,
                UserId = td.UserId,
                Progress = td.Progress
            };
            Add(tue);
        }
    }
}
