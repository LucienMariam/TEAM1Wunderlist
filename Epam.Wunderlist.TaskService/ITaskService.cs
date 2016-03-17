using BLL.Entities;
using System.Collections.Generic;
using System;
using ServiceAbstraction;

namespace TaskService
{
    public interface ITaskService: IService<TaskEntity>
    {
        IEnumerable<TaskEntity> GetTaskList(int folderId);
        IEnumerable<TaskEntity> GetResolvedTaskList(int folderId); 
        void RenameTask(int id, string newTitle);
        void AddNoteToTask(int taskId, string note);
        void SetDateInTask(int taskId, DateTime? date);
        void ResolveTask(int id);
        void DeleteTask(int id);
        void CreateTask(TaskEntity newTask);
        void ChangeTasksPriority(int taskId, int folderId, int insertionIndex);
        void MoveTaskToFolder(int taskId, int folderId);
    }
}
