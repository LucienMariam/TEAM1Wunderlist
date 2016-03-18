using DAL.Entities;
using ORM;

namespace DAL.Mappers
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
                IsCompleted = item.IsCompleted,
                PresentationPriority =  item.PresentationPriority
            };
        }

        public TaskDal ToDal(Task item)
        {
            return new TaskDal()
            {
                Id = item.Id,
                Title = item.Title,
                FolderId = item.FolderId,
                Description = item.Description,
                DueTime = item.DueTime,
                IsCompleted = item.IsCompleted,
                PresentationPriority = item.PresentationPriority
            };
        }
    }
}
