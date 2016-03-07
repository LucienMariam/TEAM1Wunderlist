using System.Collections.Generic;
using BLL.Concrete.Entities;


namespace BLL.Interfaces.Services
{
    public interface ITaskUserService : IService<TaskUserEntity>
    {
        IEnumerable<TaskUserEntity> GetByUserId(int userId);
        IEnumerable<TaskUserEntity> GetByTaskId(int taskId);
        IEnumerable<TaskUserEntity> GetTaskByUser(string userName);
        void ResolveTask(int id, string userId);
        void ReopenTask(int id, string userName);
        void DeleteTask(int id, string userName);
        TaskEntity GetTaskEntity(int taskId);
        void CreateTask(string taskName, string userName);
    }
}
