using System;
using BLL.Interfaces.Entities;

namespace BLL.Concrete.Entities
{
    public class TaskUserEntity : IBllEntity
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
    }
}
