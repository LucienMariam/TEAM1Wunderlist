using DAL.Interfaces.Mappers;
using DAL.Concrete.Entities;
using ORM;

namespace DAL.Concrete.Mappers
{
    public class TaskUserMapperDAL: IMapperDAL<TaskUser, TaskUserDAL>
    {
        public TaskUser ToORM(TaskUserDAL item)
        {
            return new TaskUser()
            {
                UserId = item.UserId,
                TaskId = item.TaskId
            };
        }
        public TaskUserDAL ToDAL(TaskUser item)
        {
            return new TaskUserDAL()
            {
                UserId = item.UserId,
                TaskId = item.TaskId
            };
        }
    }
}
