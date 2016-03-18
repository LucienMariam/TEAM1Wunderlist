using System.Collections.Generic;
using ORM;

namespace DAL.Entities
{
    public class UserDal: IDalEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public ICollection<Folder> Folders { get; set; }
    }
}
