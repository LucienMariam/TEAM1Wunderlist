using System.Data.Entity.ModelConfiguration;

namespace ORM
{
    public class TaskUserEntityConfiguration : EntityTypeConfiguration<TaskUser>
    {
        public TaskUserEntityConfiguration()
        {
            HasKey(u => new { u.UserId, u.TaskId });
        }
    }
}