using System.Collections.Generic;

namespace ORM
{
    public class Folder: IOrmEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? ParentFolderId { get; set; }
        public string Title { get; set; }
<<<<<<< HEAD
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Folder> Folders { get; set; }
=======
>>>>>>> refs/remotes/origin/Develop
    }
}
