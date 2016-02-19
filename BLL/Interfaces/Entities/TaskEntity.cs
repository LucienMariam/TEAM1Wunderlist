using System;

namespace BLL.Interfaces
{
    public class TaskEntity : IBLLKeyEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        public DateTime? DueTime { get; set; }
        public bool IsCompleted { get; set; }
    }
}
