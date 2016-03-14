using System.Collections.Generic;
using ORM;

namespace DAL.Entities
{
    public class FolderDal: IDalEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? ParentFolderId { get; set; }
        public string Title { get; set; }

        public ICollection<Task> Tasks { get; set; }
        public ICollection<Folder> Folders { get; set; }
    }
}
