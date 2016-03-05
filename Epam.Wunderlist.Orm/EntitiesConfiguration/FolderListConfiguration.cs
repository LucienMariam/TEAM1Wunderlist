using System.Data.Entity.ModelConfiguration;

namespace ORM.EntitiesConfiguration
{
    public class FolderListConfiguration : EntityTypeConfiguration<FolderList>
    {
        public FolderListConfiguration()
        {
            HasKey(u => u.Id);
            Property(t => t.Title).IsRequired();
        }
    }
}