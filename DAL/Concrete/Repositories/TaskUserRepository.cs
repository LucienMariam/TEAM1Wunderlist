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
    public class TaskUserRepository : Repository<TaskUser, TaskUserDAL, TaskUserMapperDAL>, ITaskUserRepository
    {
        public TaskUserRepository(DbContext context) : base(context) { }

        public IEnumerable<TaskUserDAL> GetByUserId(Guid userId)
        {
            Func<TaskUser, TaskUserDAL> f = (obj) => _entityMapper.ToDAL(obj);
            return _context.Set<TaskUser>().AsNoTracking().Where(x => x.UserId == userId).Select(f);
        }

        public IEnumerable<TaskUserDAL> GetByTaskId(Guid taskId)
        {
            Func<TaskUser, TaskUserDAL> f = (obj) => _entityMapper.ToDAL(obj);
            return _context.Set<TaskUser>().AsNoTracking().Where(x => x.TaskId == taskId).Select(f);
        }

        public IEnumerable<TaskUserDAL> GetByUsername(string username)
        {
            Func<TaskUser, TaskUserDAL> f = (obj) => _entityMapper.ToDAL(obj);
            Guid userId = _context.Set<User>().AsNoTracking().Where(u => u.Login == username).Select(u => u.Id).FirstOrDefault();
            return _context.Set<TaskUser>().AsNoTracking().Where(x => x.UserId == userId).Select(f);
        }
        public TaskDAL GetTask(Guid taskId)
        {
            Task task = _context.Set<Task>().AsNoTracking().Where(x => x.Id == taskId).FirstOrDefault();
            return new TaskDAL()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueTime = task.DueTime,
                IsCompleted = task.IsCompleted
            };
        }
        public TaskUserDAL CreateUserTask(string taskName, string userName)
        {
            Guid userId = _context.Set<User>().Where(u => u.Login == userName).FirstOrDefault().Id;
            Guid taskId = _context.Set<Task>().Where(u => u.Title == taskName).FirstOrDefault().Id;
            return new TaskUserDAL()
            {
                TaskId = taskId,
                UserId = userId,
            };
        }
    }
}
