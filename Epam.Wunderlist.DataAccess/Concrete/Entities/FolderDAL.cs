using DAL.Interfaces.Entities;

namespace DAL.Concrete.Entities
{
    public class FolderDal: IDalKeyEntity
    {
        public int Id { get; set; }
        public int? ParentFolderId { get; set; }
        public string Title { get; set; }
    }
}
