using System.Collections.Generic;
using DAL.Concrete.Entities;

namespace DAL.Interfaces.Repositories
{
    public interface ITaskRepository: IKeyRepository<TaskDal>
    {
        IEnumerable<TaskDal> GetTaskList(int folderId);
    }
}
