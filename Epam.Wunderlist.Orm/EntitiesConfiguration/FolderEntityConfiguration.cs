using System.Data.Entity.ModelConfiguration;

namespace ORM.EntitiesConfiguration
{
    public class FolderEntityConfiguration: EntityTypeConfiguration<Folder>
    {
        public FolderEntityConfiguration()
        {
            HasKey(u => u.Id);
            Property(t => t.UserId).IsRequired();
            Property(t => t.Title).IsRequired();
            Property(t => t.ParentFolderId).IsOptional();
        }
    }
}
