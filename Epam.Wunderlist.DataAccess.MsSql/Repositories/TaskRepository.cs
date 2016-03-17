using System.Collections.Generic;
using DataAccess.Interfaces;
using DAL.Entities;
using DAL.Mappers;
using ORM;
using System.Data.Entity;
using System;
using System.Linq;

namespace DataAccess.MsSql
{
    public class TaskRepository: BaseRepository<Task, TaskDal, TaskMapperDal>, ITaskRepository 
    {
        public TaskRepository(DbContext context): base(context) { }

        public IEnumerable<TaskDal> GetTaskList(int folderId)
        {
            Func<Task, TaskDal> f = (obj) => EntityMapper.ToDal(obj);
            return Context.Set<Task>().AsNoTracking().Where(x => (x.FolderId == folderId)).Select(f);
        }
        public IEnumerable<TaskDal> GetResolvedTaskList(int folderId)
        {
            Func<Task, TaskDal> f = (obj) => EntityMapper.ToDal(obj);
            return Context.Set<Task>().AsNoTracking().Where(x => (x.FolderId == folderId && x.IsCompleted)).Select(f);
        }
    }
}
