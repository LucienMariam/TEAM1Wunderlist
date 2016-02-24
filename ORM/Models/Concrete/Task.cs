using System;
using System.Collections.Generic;

namespace ORM
{
    public class Task : IORMKeyEntity
    {
        public Guid Id { get; set; }  // set? May be private set?
        public string Title { get; set; }        
        public string Description { get; set; }
        public DateTime? DueTime { get; set; }
        public bool IsCompleted { get; set; } = false;
        public virtual ICollection<TaskUser> Users { get; set; }
        public Task()
        {
            Users = new HashSet<TaskUser>();
        }
    }
}
