using System;
using DAL.Interfaces.Entities;

namespace DAL.Concrete.Entities
{
    public  class TaskUserDal: IDalEntity
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
    }
}
