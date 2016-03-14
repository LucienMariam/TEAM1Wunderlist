using System;
using ServiceAbstraction;
using BLL.Entities;
using BLL.Mappers;
using DAL.Entities;
using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace TaskService
{
    public class TaskService : BaseService<TaskDal, TaskEntity, ITaskRepository, TaskMapper>, ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository repository, IUnitOfWork contextChanger) : base(repository, contextChanger)
        {
            _taskRepository = Repository;
        }

        public IEnumerable<TaskEntity> GetTaskList(int folderId)
        {
            return _taskRepository.GetTaskList(folderId)
                .Select(dalEntity => EntityMapper.ToBll(dalEntity))
                .OrderByDescending(x => x.PresentationPriority);
        }

        public IEnumerable<TaskEntity> GetResolvedTaskList(int folderId)
        {
            return _taskRepository.GetResolvedTaskList(folderId)
                .Select(dalEntity => EntityMapper.ToBll(dalEntity));
        }

        public void RenameTask(int id, string newTitle)
        {
            TaskEntity task = EntityMapper.ToBll(_taskRepository.GetById(id));
            task.Title = newTitle;
            Edit(task);
        }

        public void AddNoteToTask(int taskId, string note)
        {
            TaskEntity task = EntityMapper.ToBll(_taskRepository.GetById(taskId));
            task.Description = note;
            Edit(task);
        }

        public void SetDateInTask(int taskId, DateTime? date)
        {
            TaskEntity task = EntityMapper.ToBll(_taskRepository.GetById(taskId));
            task.DueTime = date;
            Edit(task);
        }
        public void ResolveTask(int id)
        {
            TaskEntity task = EntityMapper.ToBll(_taskRepository.GetById(id));
            task.IsCompleted = true;
            Edit(task);
        }
        public void DeleteTask(int id)
        {
            TaskEntity task = EntityMapper.ToBll(_taskRepository.GetById(id));
            Delete(task);
        }
        public void CreateTask(TaskEntity newTask)
        {
            Add(newTask);
        }

        public void ChangeTasksPriority(int higherTaskId, int lowerTaskId)
        {
            TaskEntity higherTask = EntityMapper.ToBll(_taskRepository.GetById(higherTaskId));
            TaskEntity lowerTask = EntityMapper.ToBll(_taskRepository.GetById(lowerTaskId));
            higherTask.PresentationPriority = lowerTaskId;
            lowerTask.PresentationPriority = higherTaskId;
            Edit(higherTask);
            Edit(lowerTask);
        }

        public void MoveTaskToFolder(int taskId, int folderId)
        {
            TaskEntity task = EntityMapper.ToBll(_taskRepository.GetById(taskId));
            task.FolderId = folderId;
            Edit(task);
        }
    }
}
