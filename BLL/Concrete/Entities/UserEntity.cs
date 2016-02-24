using System;
using BLL.Interfaces.Entities;

namespace BLL.Concrete.Entities
{
    public class UserEntity : IBLLKeyEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
    }
}
