using System;
using BLL.Interfaces.Entities;

namespace BLL.Concrete.Entities
{
    public class TaskUserEntity : IBLLEntity
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
    }
}
