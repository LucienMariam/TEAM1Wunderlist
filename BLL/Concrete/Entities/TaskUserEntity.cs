using System;
using BLL.Interfaces.Entities;

namespace BLL.Concrete.Entities
{
    public class TaskUserEntity : IBllEntity
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
    }
}
