using System;
using DAL.Interfaces.Entities;

namespace DAL.Concrete.Entities
{
<<<<<<< HEAD
    public class TaskUserDAL: IDALEntity
=======
    public  class TaskUserDAL: IDALEntity
>>>>>>> origin/Develop
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
    }
}
