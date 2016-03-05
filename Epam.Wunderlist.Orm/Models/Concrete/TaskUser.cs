using System;

namespace ORM
{
    public class TaskUser : IOrmEntity
    {
        public int UserId { get; set; } 
        public int TaskId { get; set; }
        public virtual User User { get; set; }
        public virtual Task Task { get; set; }
    }
}
