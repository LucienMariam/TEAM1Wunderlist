using BLL.Interfaces;
using DAL.Concrete.Entities;

namespace BLL
{
    public class TaskMapper : IMapper<TaskDAL, TaskEntity>
    {
        public TaskDAL ToDAL(TaskEntity task)
        {
            return new TaskDAL()
            {
                Id = task.Id,              
                Title = task.Title,
                Desciption=task.Desciption,
                DueTime=task.DueTime,
                IsCompleted=task.IsCompleted
            };
        }

        public TaskEntity ToBLL(TaskDAL task)
        {
            return (null == task) ? null :
                new TaskEntity()
                {
                    Id = task.Id,
                    Title = task.Title,
                    Desciption=task.Desciption,
                    DueTime=task.DueTime,
                    IsCompleted=task.IsCompleted
                };
        }
    }
}
