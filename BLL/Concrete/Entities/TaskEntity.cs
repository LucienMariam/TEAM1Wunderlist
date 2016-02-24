using System;
using BLL.Interfaces.Entities;

namespace BLL.Concrete.Entities
{
    public class TaskEntity : IBLLKeyEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueTime { get; set; }
        public bool IsCompleted { get; set; }
    }
}
