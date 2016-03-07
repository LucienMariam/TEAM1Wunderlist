using System;
using DAL.Interfaces.Entities;

namespace DAL.Concrete.Entities
{
    public class TaskDal: IDalKeyEntity
    {
        public int Id { get; set; }
        public int FolderId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueTime { get; set; }
        public bool IsCompleted { get; set; }
    }
}
