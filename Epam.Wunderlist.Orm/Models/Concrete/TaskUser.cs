using System;

namespace ORM
{
    public class TaskUser : IOrmEntity
    {
        public Guid UserId { get; set; } 
        public Guid TaskId { get; set; }
        public virtual User User { get; set; }
        public virtual Task Task { get; set; }
    }
}
