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

        public IEnumerable<TaskUserDal> GetByUserId(int userId)
        {
            Func<TaskUser, TaskUserDal> f = (obj) => EntityMapper.ToDal(obj);
            return Context.Set<TaskUser>().AsNoTracking().Where(x => x.UserId == userId).Select(f);
        }

        public IEnumerable<TaskUserDal> GetByTaskId(int taskId)
        {
            Func<TaskUser, TaskUserDal> f = (obj) => EntityMapper.ToDal(obj);
            return Context.Set<TaskUser>().AsNoTracking().Where(x => x.TaskId == taskId).Select(f);
        }

        public IEnumerable<TaskUserDal> GetByUsername(string username)
        {
            Func<TaskUser, TaskUserDal> f = (obj) => EntityMapper.ToDal(obj);
            int userId = Context.Set<User>().AsNoTracking().Where(u => u.Login == username).Select(u => u.Id).FirstOrDefault();
            return Context.Set<TaskUser>().AsNoTracking().Where(x => x.UserId == userId).Select(f);
        }
        public TaskDal GetTask(int taskId)
        {
            Task task = Context.Set<Task>().AsNoTracking().FirstOrDefault(x => x.Id == taskId);
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
            int userId = Context.Set<User>().FirstOrDefault(u => u.Login == userName).Id;
            int taskId = Context.Set<Task>().FirstOrDefault(u => u.Title == taskName).Id;
            return new TaskUserDal()
            {
                TaskId = taskId,
                UserId = userId
            };
        }
    }
}
