using System.Collections.Generic;

namespace ORM
{
    public class FolderList: IOrmKeyEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Folder> Folders { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }  
    }
}
