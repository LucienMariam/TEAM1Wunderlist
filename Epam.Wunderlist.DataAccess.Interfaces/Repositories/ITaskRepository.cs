using System.Collections.Generic;
using DAL.Entities;

namespace DataAccess.Interfaces
{
    public interface ITaskRepository: IRepository<TaskDal>
    {
        IEnumerable<TaskDal> GetTaskList(int folderId);
        IEnumerable<TaskDal> GetResolvedTaskList(int folderId);
    }
}
