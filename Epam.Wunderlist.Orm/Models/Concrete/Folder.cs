using System.Collections.Generic;

namespace ORM
{
    public class Folder: IOrmKeyEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? ParentFolderId { get; set; }
        public string Title { get; set; }
    }
}
