using System;
using DAL.Interfaces.Entities;

namespace DAL.Concrete.Entities
{
    public class TaskUserDAL: IDALEntity
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
    }
}
