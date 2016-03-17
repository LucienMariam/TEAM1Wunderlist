using DAL.Interfaces.Mappers;
using DAL.Concrete.Entities;
using ORM;

namespace DAL.Concrete.Mappers
{
    public class TaskUserMapperDal: IMapperDal<TaskUser, TaskUserDal>
    {
        public TaskUser ToOrm(TaskUserDal item)
        {
            return new TaskUser()
            {
                UserId = item.UserId,
                TaskId = item.TaskId
            };
        }
        public TaskUserDal ToDal(TaskUser item)
        {
            return new TaskUserDal()
            {
                UserId = item.UserId,
                TaskId = item.TaskId
            };
        }
    }
}
