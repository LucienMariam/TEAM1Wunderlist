using DAL.Concrete.Entities;
using BLL.Interfaces.Services;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using BLL.Concrete.Entities;

namespace BLL.Services
{
    public class TaskService: KeyService<TaskDal, TaskEntity, ITaskRepository, TaskMapper>, ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository, IUnitOfWork contextChanger) : base(repository, contextChanger)
        {
            _repository = repository;
        }
    }
}
