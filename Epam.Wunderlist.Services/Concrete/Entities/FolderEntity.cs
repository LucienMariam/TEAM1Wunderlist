using BLL.Interfaces.Entities;

namespace BLL.Concrete.Entities
{
    public class FolderEntity: IBllKeyEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? ParentFolderId { get; set; }
        public string Title { get; set; }
    }
}
