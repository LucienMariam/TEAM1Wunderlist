using System;
using System.Collections.Generic;
using DAL.Concrete.Entities;

namespace DAL.Interfaces.Repositories
{
    public interface ITaskUserRepository: IRepository<TaskUserDal>
    {
        IEnumerable<TaskUserDal> GetByUserId(Guid userId);
        IEnumerable<TaskUserDal> GetByTaskId(Guid taskId);
        IEnumerable<TaskUserDal> GetByUsername(string userName);
        TaskDal GetTask(Guid taskId);
        TaskUserDal CreateUserTask(string taskName, string userName);
    }
}
