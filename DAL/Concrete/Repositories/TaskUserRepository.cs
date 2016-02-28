using System;
using System.Collections.Generic;
using System.Linq;
using ORM;
using System.Data.Entity;
using DAL.Concrete.Entities;
using DAL.Concrete.Mappers;
using DAL.Interfaces.Repositories;


namespace DAL.Concrete.Repositories
{
    public class TaskUserRepository : Repository<TaskUser, TaskUserDal, TaskUserMapperDal>, ITaskUserRepository
    {
        public TaskUserRepository(DbContext context) : base(context) { }

        public IEnumerable<TaskUserDal> GetByUserId(Guid userId)
        {
            Func<TaskUser, TaskUserDal> f = (obj) => EntityMapper.ToDal(obj);
            return Context.Set<TaskUser>().AsNoTracking().Where(x => x.UserId == userId).Select(f);
        }

        public IEnumerable<TaskUserDal> GetByTaskId(Guid taskId)
        {
            Func<TaskUser, TaskUserDal> f = (obj) => EntityMapper.ToDal(obj);
            return Context.Set<TaskUser>().AsNoTracking().Where(x => x.TaskId == taskId).Select(f);
        }

        public IEnumerable<TaskUserDal> GetByUsername(string username)
        {
            Func<TaskUser, TaskUserDal> f = (obj) => EntityMapper.ToDal(obj);
            Guid userId = Context.Set<User>().AsNoTracking().Where(u => u.Login == username).Select(u => u.Id).FirstOrDefault();
            return Context.Set<TaskUser>().AsNoTracking().Where(x => x.UserId == userId).Select(f);
        }
        public TaskDal GetTask(Guid taskId)
        {
            Task task = Context.Set<Task>().AsNoTracking().Where(x => x.Id == taskId).FirstOrDefault();
            return new TaskDal()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueTime = task.DueTime,
                IsCompleted = task.IsCompleted
            };
        }
        public TaskUserDal CreateUserTask(string taskName, string userName)
        {
            Guid userId = Context.Set<User>().Where(u => u.Login == userName).FirstOrDefault().Id;
            Guid taskId = Context.Set<Task>().Where(u => u.Title == taskName).FirstOrDefault().Id;
            return new TaskUserDal()
            {
                TaskId = taskId,
                UserId = userId,
            };
        }
    }
}
