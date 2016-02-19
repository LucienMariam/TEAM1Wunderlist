using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ITaskUserService : IService<TaskUserEntity>
    {
        IEnumerable<TaskUserEntity> GetByUserId(Guid userId);
        IEnumerable<TaskUserEntity> GetByTaskId(Guid taskId);
        IEnumerable<TaskUserEntity> GetTaskByUser(string userId);
        void ResolveTask(Guid id, string userId);
        void ReopenTask(Guid id, string userName);
        void DeleteTask(Guid id, string userName);
        TaskEntity GetTaskEntity(Guid taskId);
        void CreateTask(Guid taskID, string userName);
    }
}
