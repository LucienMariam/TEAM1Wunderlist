using System;
using System.Collections.Generic;
using BLL.Concrete.Entities;


namespace BLL.Interfaces.Services
{
    public interface ITaskUserService : IService<TaskUserEntity>
    {
        IEnumerable<TaskUserEntity> GetByUserId(Guid userId);
        IEnumerable<TaskUserEntity> GetByTaskId(Guid taskId);
        IEnumerable<TaskUserEntity> GetTaskByUser(string userName);
        void ResolveTask(Guid id, string userId);
        void ReopenTask(Guid id, string userName);
        void DeleteTask(Guid id, string userName);
        TaskEntity GetTaskEntity(Guid taskId);
        void CreateTask(string taskName, string userName);
    }
}
