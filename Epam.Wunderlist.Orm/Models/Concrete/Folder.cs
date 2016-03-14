namespace ORM
{
    public class Folder: IOrmEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? ParentFolderId { get; set; }
        public string Title { get; set; }
    }
}
