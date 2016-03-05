using System.Data.Entity.ModelConfiguration;

namespace ORM.EntitiesConfiguration
{
    public class FolderConfiguration: EntityTypeConfiguration<Folder>
    {
        public FolderConfiguration()
        {
            HasKey(u => u.Id);
            Property(t => t.Title).IsRequired();
        }
    }
}
