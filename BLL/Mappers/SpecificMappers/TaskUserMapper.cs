using BLL.Interfaces;
using DAL.Concrete.Entities;


namespace BLL
{
    public class TaskUserMapper : IMapper<TaskUserDAL, TaskUserEntity>
    {
        public TaskUserDAL ToDAL(TaskUserEntity taskUser)
        {
            return new TaskUserDAL()
            {
                UserId = taskUser.UserId,
                TaskId = taskUser.TaskId                
            };
        }

        public TaskUserEntity ToBLL(TaskUserDAL taskUser)
        {
            return (null == taskUser) ? null :
                new TaskUserEntity()
                {
                    UserId = taskUser.UserId,
                    TaskId = taskUser.TaskId
                };
        }
    }
}
