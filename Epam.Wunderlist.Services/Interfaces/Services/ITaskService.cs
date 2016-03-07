using BLL.Concrete.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces.Services
{
    public interface ITaskService: IKeyService<TaskEntity>
    {
        IEnumerable<TaskEntity> GetTaskList(int folderId);
    }
}
