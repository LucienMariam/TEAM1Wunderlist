using System;
using DAL.Interfaces.Entities;

namespace DAL.Concrete.Entities
{
<<<<<<< HEAD
    public class TaskDAL: IDALKeyEntity
=======
  public  class TaskDAL: IDALKeyEntity
>>>>>>> origin/Develop
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueTime { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
