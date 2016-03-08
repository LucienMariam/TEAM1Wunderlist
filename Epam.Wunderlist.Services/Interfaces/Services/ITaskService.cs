using BLL.Concrete.Entities;
using System.Collections.Generic;
using System;

namespace BLL.Interfaces.Services
{
    public interface ITaskService: IKeyService<TaskEntity>
    {
        IEnumerable<TaskEntity> GetTaskList(int folderId);
        void Rename(int id, string newTitle);
        void AddNote(int id, string note);
        void SetDate(int id, DateTime? date);
    }
}
