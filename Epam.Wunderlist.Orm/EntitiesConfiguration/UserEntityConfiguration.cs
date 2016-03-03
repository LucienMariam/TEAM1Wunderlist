using System.Data.Entity.ModelConfiguration;

namespace ORM
{
    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            HasKey(u => u.Id);
            Property(u => u.Login).IsRequired();
            Property(u => u.Email).IsRequired();
            Property(u => u.Password).IsRequired();
            Property(u => u.Photo).IsOptional();
        }
    }
}