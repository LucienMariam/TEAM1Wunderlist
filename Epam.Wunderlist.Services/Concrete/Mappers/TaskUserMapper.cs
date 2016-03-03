using DAL.Concrete.Entities;
using BLL.Concrete.Entities;


namespace BLL
{
    public class TaskUserMapper : IMapper<TaskUserDal, TaskUserEntity>
    {
        public TaskUserDal ToDal(TaskUserEntity taskUser)
        {
            return new TaskUserDal()
            {
                UserId = taskUser.UserId,
                TaskId = taskUser.TaskId                
            };
        }

        public TaskUserEntity ToBll(TaskUserDal taskUser)
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
