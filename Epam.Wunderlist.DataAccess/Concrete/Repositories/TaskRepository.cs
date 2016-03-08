using System.Collections.Generic;
using DAL.Interfaces.Repositories;
using DAL.Concrete.Entities;
using DAL.Concrete.Mappers;
using ORM;
using System.Data.Entity;
using System;
using System.Linq;

namespace DAL.Concrete.Repositories
{
    public class TaskRepository: KeyRepository<Task, TaskDal, TaskMapperDal>, ITaskRepository 
    {
        public TaskRepository(DbContext context): base(context) { }

        public IEnumerable<TaskDal> GetTaskList(int folderId)
        {
            Func<Task, TaskDal> f = (obj) => EntityMapper.ToDal(obj);
            return Context.Set<Task>().AsNoTracking().Where(x => x.FolderId == folderId).Select(f);
        }
    }
}
