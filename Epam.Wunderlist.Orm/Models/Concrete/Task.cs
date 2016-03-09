using System;

namespace ORM
{
    public class Task : IOrmEntity
    {
        public int Id { get; set; }
        public int FolderId { get; set; }
        public string Title { get; set; }        
        public string Description { get; set; }
        public DateTime? DueTime { get; set; }
        public bool IsCompleted { get; set; }
        public int? PresentationPriority { get; set; }
    }
}
