using DAL.Interfaces.Mappers;
using DAL.Concrete.Entities;
using ORM;

namespace DAL.Concrete.Mappers
{
    public class TaskMapperDal: IMapperDal<Task, TaskDal>
    {
        public Task ToOrm(TaskDal item)
        {
            return new Task()
            {
                Id = item.Id,
                FolderId = item.FolderId,
                Title = item.Title,
                Description = item.Description,
                DueTime = item.DueTime,
                IsCompleted = item.IsCompleted
            };
        }

        public TaskDal ToDal(Task item)
        {
            return new TaskDal()
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
