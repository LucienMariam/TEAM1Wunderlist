using System.Collections.Generic;

namespace ORM
{
    public class User : IOrmEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public virtual ICollection<Folder> Folders { get; set; }
    }
}
