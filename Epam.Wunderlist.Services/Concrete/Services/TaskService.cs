using System;
using DAL.Concrete.Entities;
using BLL.Interfaces.Services;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using BLL.Concrete.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class TaskService : KeyService<TaskDal, TaskEntity, ITaskRepository, TaskMapper>, ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository repository, IUnitOfWork contextChanger) : base(repository, contextChanger)
        {
            _taskRepository = Repository;
        }

        public IEnumerable<TaskEntity> GetTaskList(int folderId)
        {
            return _taskRepository.GetTaskList(folderId).Select(dalEntity => EntityMapper.ToBll(dalEntity));
        }

        public void Rename(int id, string newTitle)
        {
            TaskEntity task = EntityMapper.ToBll(_taskRepository.GetById(id));
            task.Title = newTitle;
            Edit(task);
        }

        public void AddNote(int id, string note)
        {
            TaskEntity task = EntityMapper.ToBll(_taskRepository.GetById(id));
            task.Description = note;
            Edit(task);
        }

        public void SetDate(int id, DateTime? date)
        {
            TaskEntity task = EntityMapper.ToBll(_taskRepository.GetById(id));
            task.DueTime = date;
            Edit(task);
        }
    }
}
