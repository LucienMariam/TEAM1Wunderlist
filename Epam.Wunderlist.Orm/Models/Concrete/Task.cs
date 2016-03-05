using System;
using System.Collections.Generic;

namespace ORM
{
    public class Task : IOrmKeyEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }        
        public string Description { get; set; }
        public DateTime? DueTime { get; set; }
        public bool IsCompleted { get; set; }
        public virtual ICollection<TaskUser> Users { get; set; }
        public Task()
        {
            Users = new HashSet<TaskUser>();
        }
    }
}
