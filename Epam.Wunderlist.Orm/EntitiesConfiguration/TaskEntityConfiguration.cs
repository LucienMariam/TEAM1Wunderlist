using System.Data.Entity.ModelConfiguration;

namespace ORM
{
    public class TaskEntityConfiguration : EntityTypeConfiguration<Task>
    {
        public TaskEntityConfiguration()
        {
            HasKey(u => u.Id);
            Property(t => t.Title).IsRequired();
            Property(t => t.Description).IsOptional();
            Property(t => t.DueTime).IsOptional();
            Property(t => t.IsCompleted);
        }
    }
}
