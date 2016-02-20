using System;
using DAL.Interfaces.Entities;

namespace DAL.Concrete.Entities
{
    public class UserDAL: IDALKeyEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
    }
}
