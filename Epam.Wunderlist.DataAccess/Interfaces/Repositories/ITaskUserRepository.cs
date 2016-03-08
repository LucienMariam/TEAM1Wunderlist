using System.Collections.Generic;
using DAL.Concrete.Entities;

namespace DAL.Interfaces.Repositories
{
    public interface ITaskUserRepository: IRepository<TaskUserDal>
    {
        IEnumerable<TaskUserDal> GetByUserId(int userId);
        IEnumerable<TaskUserDal> GetByTaskId(int taskId);
        IEnumerable<TaskUserDal> GetByUsername(string userName);
        TaskDal GetTask(int taskId);
        TaskUserDal CreateUserTask(string taskName, string userName);
    }
}
