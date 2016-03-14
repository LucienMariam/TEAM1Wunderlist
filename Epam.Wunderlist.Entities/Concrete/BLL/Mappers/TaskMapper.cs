using BLL.Entities;
using DAL.Entities;
using BLL.Mappers;

namespace BLL.Mappers
{
    public class TaskMapper : IMapper<TaskDal, TaskEntity>
    {
        public TaskDal ToDal(TaskEntity task)
        {
            return new TaskDal()
            {
                Id = task.Id,
                FolderId = task.FolderId,
                Title = task.Title,
                Description=task.Description,
                DueTime=task.DueTime,
                IsCompleted=task.IsCompleted
            };
        }

        public TaskEntity ToBll(TaskDal task)
        {
            return (null == task) ? null :
                new TaskEntity()
                {
                    Id = task.Id,
                    FolderId = task.FolderId,
                    Title = task.Title,
                    Description=task.Description,
                    DueTime=task.DueTime,
                    IsCompleted=task.IsCompleted
                };
        }
    }
}
