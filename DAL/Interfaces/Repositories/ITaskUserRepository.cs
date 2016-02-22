using System;
using System.Collections.Generic;
using DAL.Concrete.Entities;

namespace DAL.Interfaces.Repositories
{
    public interface ITaskUserRepository: IRepository<TaskUserDAL>
    {
        IEnumerable<TaskUserDAL> GetByUserId(Guid userId);
        IEnumerable<TaskUserDAL> GetByTaskId(Guid taskId);
        IEnumerable<TaskUserDAL> GetByUsername(string userName);
        TaskDAL GetTask(Guid taskId);
        TaskUserDAL CreateUserTask(string taskName, string userName);
    }
}
