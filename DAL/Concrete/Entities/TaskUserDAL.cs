using System;
using DAL.Interfaces.Entities;

namespace DAL.Concrete.Entities
{
    class TaskUserDAL: IDALEntity
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
    }
}
