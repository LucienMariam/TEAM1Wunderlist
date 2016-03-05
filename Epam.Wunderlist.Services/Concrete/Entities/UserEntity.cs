using System;
using BLL.Interfaces.Entities;

namespace BLL.Concrete.Entities
{
    public class UserEntity : IBllKeyEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
    }
}
