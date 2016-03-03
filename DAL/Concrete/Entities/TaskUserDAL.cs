using System;
using DAL.Interfaces.Entities;

namespace DAL.Concrete.Entities
{
    public  class TaskUserDal: IDalEntity
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
    }
}
