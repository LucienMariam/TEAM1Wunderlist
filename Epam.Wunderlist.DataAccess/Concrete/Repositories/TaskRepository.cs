using DAL.Interfaces.Repositories;
using DAL.Concrete.Entities;
using DAL.Concrete.Mappers;
using ORM;
using System.Data.Entity;

namespace DAL.Concrete.Repositories
{
    public class TaskRepository: KeyRepository<Task, TaskDal, TaskMapperDal>, ITaskRepository 
    {
        public TaskRepository(DbContext context): base(context) { }
    }
}
