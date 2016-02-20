using DAL.Interfaces.Mappers;
using DAL.Concrete.Entities;
using ORM;

namespace DAL.Concrete.Mappers
{
    public class TaskMapperDAL: IMapperDAL<Task, TaskDAL>
    {
        public Task ToORM(TaskDAL item)
        {
            return new Task()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                DueTime = item.DueTime,
                IsCompleted = item.IsCompleted
            };
        }

        public TaskDAL ToDAL(Task item)
        {
            return new TaskDAL()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                DueTime = item.DueTime,
                IsCompleted = item.IsCompleted
            };
        }
    }
}
