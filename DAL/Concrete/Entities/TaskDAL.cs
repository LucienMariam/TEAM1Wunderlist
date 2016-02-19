using System;
using DAL.Interfaces.Entities;

namespace DAL.Concrete.Entities
{
    class TaskDAL: IDALKeyEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        public DateTime? DueTime { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
