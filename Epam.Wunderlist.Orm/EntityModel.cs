using System.Data.Entity;
using System.Diagnostics;
using ORM.EntitiesConfiguration;

namespace ORM
{
    public class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
            Debug.WriteLine("Context is created.");
        }

        public virtual DbSet<Folder> Folders { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TaskEntityConfiguration());
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new FolderEntityConfiguration());
        }

        public new void Dispose()
        {
            base.Dispose();
            Debug.WriteLine("Context is disposed.");
        }
    }
}
